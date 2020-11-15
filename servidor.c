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

void consultasBBDD (MYSQL *conn, char consulta[512], char respuesta[512]){
	int err;
	err=mysql_query (conn, consulta);
	if (err!=0) {
		sprintf (respuesta, "Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
}
	
int ponConectado (ListaConectados *lista, char usuario[20], int socket){
	if (lista->num == 100)
		return -1;
	else{
		strcpy(lista->conectados[lista->num].usuario, usuario);
		lista->conectados[lista->num].socket = socket;
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

void dameConectados (ListaConectados *lista, char respuesta[512]){
	char conectados[512];
	char nombre[20];
	if (lista->num == 0)
		strcpy(respuesta, "No hay nadie conectado");
	else
	{
		sprintf(conectados, "%d", lista->num);
		int i;
		for (i = 0; i < lista->num; i++)
		{
			sprintf(conectados, "%s/%s", conectados, lista->conectados[i].usuario);
		}
		
		char *p = strtok( conectados, "/");
		int codigo =  atoi (p);
		p = strtok( NULL, "/");
		strcpy (nombre, p);
		sprintf(respuesta, "%s\n", nombre);
		for (i = 1; i < codigo; i++)
		{
			p = strtok( NULL, "/");
			strcpy (nombre, p);
			sprintf(respuesta, "%s%s\n", respuesta, nombre);
		}
	}
}

void registrarUsuario (MYSQL *conn, MYSQL_RES *resultado, MYSQL_ROW row, char usuario[20], char contrasena[20], char respuesta[512]){
	int idd;
	strcpy (consulta, "SELECT JUGADOR.ID FROM JUGADOR ORDER BY ID DESC");
	consultasBBDD (conn, consulta, respuesta);
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
		strcpy (respuesta, "No se han obtenido datos en la consulta\n");
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
			sprintf (respuesta, "Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		else
			sprintf(respuesta, "%s: registrado correctamente", usuario);
	}
	else{
		sprintf(respuesta, "%s: ya existe como usuario", usuario);
	}
}

int iniciarUsuario (MYSQL *conn, MYSQL_RES *resultado, MYSQL_ROW row, char usuario[20], char contrasena[20], char respuesta[512], ListaConectados *lista, int sock){
	sprintf (consulta, "SELECT JUGADOR.CONTRASENA FROM JUGADOR WHERE JUGADOR.USUARIO = '%s'", usuario);
	consultasBBDD (conn, consulta, respuesta);
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL){
		sprintf(respuesta, "error1");
		return -1;
	}
	else{
		if (strcmp(contrasena,row[0]) == 0)
			sprintf(respuesta, "%s: login realizado correctamente", usuario);
		else{
			sprintf(respuesta, "error2");
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
		strcpy (respuesta, "No se han obtenido datos en la consulta\n");
	else
		strcpy (respuesta, row[0]);
	row = mysql_fetch_row (resultado);
	while (row !=NULL) {
		strcat(respuesta,"\n");
		strcat(respuesta,row[0]);
		row = mysql_fetch_row (resultado);
	}
}

void consultaId (MYSQL *conn, MYSQL_RES *resultado, MYSQL_ROW row, char usuario[20], char respuesta[512]){
	sprintf (consulta, "SELECT PARTIDA.ID FROM (JUGADOR, PARTIDA, PUENTE) WHERE JUGADOR.USUARIO = '%s' AND JUGADOR.ID = PUENTE.ID_J AND PUENTE.ID_P = PARTIDA.ID AND PARTIDA.RESULTADO = 'DERROTA'", usuario);
	consultasBBDD (conn, consulta, respuesta);
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado); 
	if (row == NULL)
		strcpy (respuesta, "No se han obtenido datos en la consulta\n");
	else
		strcpy (respuesta, row[0]);
	row = mysql_fetch_row (resultado);
	while (row !=NULL) {
		strcat(respuesta,", ");
		strcat(respuesta,row[0]);
		row = mysql_fetch_row (resultado);
	}
}

void consultaFyH (MYSQL *conn, MYSQL_RES *resultado, MYSQL_ROW row, char contrasena[20], char respuesta[512]){
	sprintf (consulta,"SELECT FECHAYHORA FROM (JUGADOR, PARTIDA, PUENTE) WHERE JUGADOR.CONTRASENA = '%s' AND PARTIDA.ID = PUENTE.ID_P AND PUENTE.ID_J = JUGADOR.ID", contrasena);	
	consultasBBDD (conn, consulta, respuesta);
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
		strcpy (respuesta, "No se han obtenido datos en la consulta\n");
	else
		sprintf (respuesta, "FECHA Y HORA: %s\n", row[0]);
	row = mysql_fetch_row (resultado);
	while (row !=NULL){
		strcat(respuesta, "FECHA Y HORA:");
		strcat(respuesta, row[0]);
		strcat(respuesta,"\n");
		row = mysql_fetch_row (resultado);
	}
}

void *AtenderCliente(void *socket){
	int sock_conn, sock_listen, ret;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	char peticion[512];
	char respuesta[512];
	//BASE DE DATOS
	MYSQL *conn;
	// Estructura especial para almacenar resultados de consultas
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int id;
	char usuario[20];
	char contrasena[20];
	//Creamos una conexion al servidor MYSQL
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "miBBDD",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
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
		else if (codigo == 1){// Registro del usuario
			p = strtok( NULL, "/");
			strcpy (usuario, p);
			p = strtok( NULL, "/");
			strcpy (contrasena, p);
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
		else{
			pthread_mutex_lock( &mutex );
			dameConectados(&lista, respuesta);
			pthread_mutex_unlock( &mutex );
		}
		
		if (codigo != 0)
		{
			printf ("%s\n", respuesta);
			write (sock_conn,respuesta, strlen(respuesta));
		}
	}
	close(sock_conn); 
	mysql_close (conn);
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

	serv_adr.sin_port = htons(9000);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	//La cola de peticiones pendientes no podra ser superior a 3
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	int sockets[100];
	int i;
	pthread_t thread;
	i=0;
	// Bucle para atender clientes
	for (;;){
		printf ("Escuchando\n");
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		sockets[i] =sock_conn;
		//sock_conn es el socket que usaremos para este cliente
		
		// Crear thead y decirle lo que tiene que hacer
		pthread_create (&thread, NULL, AtenderCliente,&sockets[i]);
		i=i+1;
	}
	exit(0);
}


