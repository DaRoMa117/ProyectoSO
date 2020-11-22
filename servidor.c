#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <ctype.h>
#include <mysql.h>
#include <pthread.h>

typedef struct {
	char usuario[20];
	int socket;
} Conectado;

typedef struct {
	Conectado conectados [100];
	int num;
} ListaConectados;

char consulta[512];
ListaConectados lista;
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
int sockets[100];
//int *sockets;
int numSockets;
MYSQL *conn;
// Estructura especial para almacenar resultados de consultas
MYSQL_RES *resultado;
MYSQL_ROW row;
//Creamos una conexion al servidor MYSQL


void consultasBBDD (MYSQL *conn, char consulta[512], char respuesta[512]){
	int err;
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
}
	
int ponConectado (ListaConectados *lista, char usuario[20], int socket){
	if (lista->num == 100)
		return -1;
	else{
		strcpy(lista->conectados[lista->num].usuario, usuario);
		lista->conectados[lista->num].socket = socket;
		printf("Socket: %d\n", socket);
		lista->num++;
		return 0;
	}
}

int posicionUsuario (ListaConectados *lista, char usuario[20]){
	int i = 0;
	int encontrado = 0;
	while ((i < lista->num) && (!encontrado))
	{
		if (strcmp(lista->conectados[i].usuario, usuario) == 0)
			encontrado = 1;
		if (!encontrado)
			i = i + 1;
	}	
	if (encontrado)
		return i;
	else
		return -1;
}

void eliminaConectado (ListaConectados *lista, char usuario[20]){
	int i;
	int pos = posicionUsuario(lista, usuario);
	if (pos == -1)
		printf("Error al eliminar al usuario\n");
	else{
		for (i = pos; i < (lista->num-1); i++)
		{
			lista->conectados[i] = lista->conectados[i+1];
		}
		lista->num--;
		printf("Eliminado correctamente\n");
	}
}

void dameConectados (ListaConectados *lista, char notificacion[512]){
	char conectados[512];
	char nombre[20];
	if (lista->num == 0)
		printf("6/No hay nadie conectado\n");
	else
	{
		sprintf(conectados, "%d", lista->num);
		int i;
		for (i = 0; i < lista->num; i++)
		{
			sprintf(conectados, "%s/%s", conectados, lista->conectados[i].usuario);
		}
		
		char *p = strtok(conectados, "/");
		int codigo =  atoi (p);
		p = strtok( NULL, "/");
		strcpy (nombre, p);
		sprintf(notificacion, "6/%s,", nombre);
		for (i = 1; i < codigo; i++)
		{
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			sprintf(notificacion, "%s%s,", notificacion, nombre);
		}
		
		//if (strlen(notificacion) > 0)
		//{
		//	notificacion[strlen(notificacion)-1] = '\0';
		//}
	}
}

void registrarUsuario (MYSQL *conn, MYSQL_RES *resultado, MYSQL_ROW row, char usuario[20], char contrasena[20], char respuesta[512]){
	int idd;
	strcpy (consulta, "SELECT JUGADOR.ID FROM JUGADOR ORDER BY ID DESC");
	consultasBBDD (conn, consulta, respuesta);
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
		strcpy (respuesta, "1/No se han obtenido datos en la consulta\n");
	else
		idd = atoi(row[0]) + 1;
	
	sprintf (consulta, "SELECT JUGADOR.USUARIO FROM JUGADOR WHERE JUGADOR.USUARIO = '%s'", usuario);
	consultasBBDD (conn, consulta, respuesta);
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL){
		int err;
		sprintf(consulta, "INSERT INTO JUGADOR VALUES('%d','%s','%s')", idd, usuario, contrasena);
		err=mysql_query (conn, consulta);
		if (err!=0) {
			printf ("1/Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		else
			sprintf(respuesta, "1/%s: registrado correctamente", usuario);
	}
	else{
		sprintf(respuesta, "1/%s: ya existe como usuario", usuario);
	}
}

int iniciarUsuario (MYSQL *conn, MYSQL_RES *resultado, MYSQL_ROW row, char usuario[20], char contrasena[20], char respuesta[512], ListaConectados *lista, int sock){
	sprintf (consulta, "SELECT JUGADOR.CONTRASENA FROM JUGADOR WHERE JUGADOR.USUARIO = '%s'", usuario);
	consultasBBDD (conn, consulta, respuesta);
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL){
		sprintf(respuesta, "2/error");
		return -1;
	}
	else{
		if (strcmp(contrasena,row[0]) == 0)
			sprintf(respuesta, "2/%s: login realizado correctamente", usuario);
		else{
			sprintf(respuesta, "2/errorr");
			return -1;
		}
	}
	int res = ponConectado (lista, usuario, sock);
	if (res == -1)
		printf ("Error al añadir conectado\n");
	else
		printf ("Añadido\n");
}

void consultaMasUnaHora (MYSQL *conn, MYSQL_RES *resultado, MYSQL_ROW row, char respuesta[512]){
	strcpy(consulta,"SELECT DISTINCT JUGADOR.USUARIO FROM (JUGADOR, PUENTE, PARTIDA) WHERE PARTIDA.DURACION > 60 AND PARTIDA.ID = PUENTE.ID_P AND PUENTE.ID_J = JUGADOR.ID"); 
	consultasBBDD (conn, consulta, respuesta);
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);	
	if (row == NULL)
		strcpy (respuesta, "3/No se han obtenido datos en la consulta\n");
	else
		sprintf (respuesta, "3/%s, ", row[0]);
	row = mysql_fetch_row (resultado);
	while (row !=NULL) {
		sprintf(respuesta, "%s%s, ", respuesta, row[0]);
		row = mysql_fetch_row (resultado);
	}
}

void consultaId (MYSQL *conn, MYSQL_RES *resultado, MYSQL_ROW row, char usuario[20], char respuesta[512]){
	sprintf (consulta, "SELECT PARTIDA.ID FROM (JUGADOR, PARTIDA, PUENTE) WHERE JUGADOR.USUARIO = '%s' AND JUGADOR.ID = PUENTE.ID_J AND PUENTE.ID_P = PARTIDA.ID AND PARTIDA.RESULTADO = 'DERROTA'", usuario);
	consultasBBDD (conn, consulta, respuesta);
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado); 
	if (row == NULL)
		strcpy (respuesta, "4/No se han obtenido datos en la consulta\n");
	else
		sprintf (respuesta, "4/%s, ", row[0]);
	row = mysql_fetch_row (resultado);
	while (row !=NULL) {
		sprintf(respuesta, "%s%s, ", respuesta, row[0]);
		row = mysql_fetch_row (resultado);
	}
}

void consultaFyH (MYSQL *conn, MYSQL_RES *resultado, MYSQL_ROW row, char contrasena[20], char respuesta[512]){ //revisar formato
	sprintf (consulta,"SELECT FECHAYHORA FROM (JUGADOR, PARTIDA, PUENTE) WHERE JUGADOR.CONTRASENA = '%s' AND PARTIDA.ID = PUENTE.ID_P AND PUENTE.ID_J = JUGADOR.ID", contrasena);	
	consultasBBDD (conn, consulta, respuesta);
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
		strcpy (respuesta, "5/No se han obtenido datos en la consulta\n");
	else
		sprintf (respuesta, "5/FECHA Y HORA: %s, ", row[0]);
	row = mysql_fetch_row (resultado);
	while (row !=NULL){
		sprintf(respuesta, "%sFECHA Y HORA: %s, ", respuesta, row[0]);
		row = mysql_fetch_row (resultado);
	}
}

void *AtenderCliente(void *socket){
	int sock_conn, ret;
	int *s;
	s = (int *) socket;
	sock_conn = *s;
	char peticion[512];
	char respuesta[512];
	int id;
	char usuario[20];
	char contrasena[20];
	int cont = 0;
	//BASE DE DATOS
	
	//Bucle para consultar las peticiones del cliente
	int end = 0;
	while (end == 0)
	{		
		ret=read(sock_conn, peticion, sizeof(peticion));
		printf ("Recibido\n");
		peticion[ret]='\0';
		printf ("Peticion: %s\n",peticion);
		char *p = strtok( peticion, "/");
		int codigo =  atoi (p);		
		if (codigo == 0){
			p = strtok( NULL, "/");
			strcpy (usuario, p);
			pthread_mutex_lock( &mutex );
			eliminaConectado (&lista, usuario);
			pthread_mutex_unlock( &mutex );
			end = 1;
		}
		else if (codigo == 1){ // Registro del usuario
			p = strtok( NULL, "/");
			strcpy (usuario, p);
			p = strtok( NULL, "/");
			strcpy(contrasena, p);
			registrarUsuario(conn, resultado, row, usuario, contrasena, respuesta);
		}
		else if (codigo == 2){ // Login del usuario
			p = strtok( NULL, "/");
			strcpy (usuario, p);
			p = strtok( NULL, "/");
			strcpy (contrasena, p);
			pthread_mutex_lock( &mutex );
			int res = iniciarUsuario(conn, resultado, row, usuario, contrasena, respuesta, &lista, sock_conn);
			pthread_mutex_unlock( &mutex);
			if (res == -1)
				end = 1;
		}
		else if (codigo == 3){
			consultaMasUnaHora(conn, resultado, row, respuesta);
		}
		else if (codigo == 4){
			p = strtok( NULL, "/");
			strcpy (usuario, p);
			consultaId(conn, resultado, row, usuario, respuesta);	
		}
		else if (codigo == 5){
			p = strtok( NULL, "/");
			strcpy (contrasena, p);
			consultaFyH(conn, resultado, row, contrasena, respuesta);
		}
		
		if (codigo != 0)
		{
			printf ("%s\n", respuesta);
			write (sock_conn, respuesta, strlen(respuesta));
		}
		
		if (((codigo == 0) || (codigo == 2)) && (lista.num != 0)){
			char notificacion[512];
			pthread_mutex_lock( &mutex );
			dameConectados(&lista, notificacion);
			pthread_mutex_unlock( &mutex );
			printf("ListaConectados: %s\n", notificacion);
			int j;
			for (j = 0; j < lista.num; j++)
				write (lista.conectados[j].socket, notificacion, strlen(notificacion));
		}		
	}
	close(sock_conn); 
}

int main(int argc, char *argv[])
{	
	lista.num = 0;
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	// INICIALITZACIONS
	// Abrimos el socket de escucha
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la maquina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);

	serv_adr.sin_port = htons(5037);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	//La cola de peticiones pendientes no podra ser superior a 3
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	conn = mysql_real_connect (conn,"localhost","root", "mysql","T7_BBDD",0, NULL, 0);
	//conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T7_BBDD",0, NULL, 0); // HAY QUE CAMBIARLO PARA USAR EN ORDENADOR 
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	pthread_t thread;
	numSockets = 0;
	//sockets = (int *)malloc(numSockets*sizeof(int));
	// Bucle para atender clientes
	for (;;){
		printf ("Escuchando\n");
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		sockets[numSockets] = sock_conn;
		//sock_conn es el socket que usaremos para este cliente
		
		// Crear thead y decirle lo que tiene que hacer
		pthread_create (&thread, NULL, AtenderCliente,&sockets[numSockets]);
		numSockets++;
	}
	exit(0);
}


