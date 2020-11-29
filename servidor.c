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

typedef char TablaPartidas[10][10]; //filas vs columnas

char consulta[512];
ListaConectados lista;
TablaPartidas tpartidas;
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
//int sockets[100];
int *sockets;
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
		//printf("Socket: %d\n", socket);
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
	int i;
	int encontrado = 0;
	if (row == NULL){
		sprintf(respuesta, "2/error");
		return -1;
	}
	else{
		
		while ((i < lista->num) && (!encontrado))
		{
			if(strcmp(lista->conectados[i].usuario,usuario) == 0)
			{
				encontrado = 1;
				sprintf(respuesta, "2/errorrr");
				return -1;
			}
			i = i + 1;
		}
		if (!encontrado)	
		{
			if (strcmp(contrasena,row[0]) == 0)
			{
				sprintf(respuesta, "2/%s: login realizado correctamente", usuario);
			}
			else{
				sprintf(respuesta, "2/errorr");
				return -1;
			}
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

int anadirAnfitrion(ListaConectados *lista, TablaPartidas *tpartidas, int sock, char host[20], char aux[10]){
	//printf("ENTRA 2\n");
	char anfitrion[20];
	int encontrado = 0;
	int i = 0;
	while ((i < lista->num) && (!encontrado))
	{
		if (sock == lista->conectados[i].socket)
		{
			encontrado = 1;
			strcpy(anfitrion, lista->conectados[i].usuario);
		}
		i++;
	}
	if(encontrado)
	{
		//printf("ENTRA 3\n");
		int anadido = 0;
		int j = 0;
		while ((j < 10) && (!anadido))
		{
			if (strcmp(tpartidas[j][0],"") == 0)
			{
				//printf("ENTRA 4\n");
				anadido = 1;
				sprintf(aux, "%d", j);
				strcpy(tpartidas[j][0], anfitrion);
				//printf("Anfitrion: %s\n", tpartidas[j][0]);
				sprintf(tpartidas[j][1], "%d", sock);
				//printf("Socket: %s\n", tpartidas[j][1]);
			}
			j++; //100%
		}
		
		if(anadido == 1) //CAMBIARLO CUANDO HAYA PARTIDAS INFINITAS.
		{
			printf("Anadido a la tabla\n");
			strcpy(host, anfitrion);
			return 0;
		}
		else
		{
			printf("Tabla llena\n");
			return -1;
		}
	}
	else
	{
		printf("Anfitrion no encontrado\n");
		return -2;
	}
}

void anadirInvitados(ListaConectados *lista, TablaPartidas *tpartidas, char frase[512], int posicion){
	int encontrado = 0;
	int i = 0;
	int socket;
	int cont = 2;
	char nombre[20];
	//printf("frase: %s\n", frase);
	char *p = strtok(frase, "/");
	p = strtok(NULL, "/");
	while (p != NULL)
	{
		strcpy(nombre, p);
		while((i < lista->num) && (!encontrado))
		{
			if (strcmp(nombre, lista->conectados[i].usuario) == 0)
			{
				encontrado = 1;
				socket = lista->conectados[i].socket;
			}
			i++;
		}
		if (encontrado)
		{
			strcpy(tpartidas[posicion][cont], nombre);
			//printf("Anfitrion: %s\n", tpartidas[posicion][cont-2]);
			sprintf(tpartidas[posicion][cont + 1], "%d", socket);
			//printf("Socket: %s\n", tpartidas[posicion][cont -1]);
			cont = cont + 2;
		}
		else
		{
			printf("%s no esta en conectados\n", nombre);
		}
		encontrado = 0;
		i = 0;
		p = strtok(NULL, "/");
	}
}

void obtenerSocket(TablaPartidas *tpartidas, int posicion, int j, char aux[10]){
	strcpy(aux, tpartidas[posicion][j]);
}

void respuestaInvitacion(ListaConectados *lista, TablaPartidas *tpartidas, char respuesta[512], char frase[512], char aux[10]){
	int numPartida;
	char res[10];
	char *p = strtok(frase, "/");
	p = strtok(NULL, "/");
	strcpy(aux, p);
	numPartida = atoi(p);
	p = strtok(NULL, "/");
	strcpy(res, p);
	if (strcmp(res, "si") == 0)
	{
		sprintf(respuesta, "8/%d,si,", numPartida);
	}
	
	else if (strcmp(res, "no") == 0)
	{
		sprintf(respuesta, "8/%d,no,", numPartida);
/*		for(int i = 0; i < 10; i++)*/
/*		{*/
/*			strcpy(tpartidas[numPartida][i], "");*/
/*		}*/
/*		for(int i = 0; i < 10; i++)*/
/*		{*/
/*			for(int j = 0; j < 10; j++)*/
/*			{*/
/*				printf("Fila %d Columna %d = %s\n", i, j, tpartidas[i][j]);*/
/*			}*/
/*		}*/
	}
}

void *AtenderCliente(void *socket){
	int sock_conn, ret;
	int *s;
	s = (int *) socket;
	sock_conn = *s;
	char peticion[512];
	char respuesta[512];
	char frase[512];
	char respuestaAnfitrion[512];
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
		strcpy(frase, peticion);
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
			end = 1;
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
		else if (codigo == 7)
		{
			char anfitrion[20];
			char aux[10];
			int posicion;
			pthread_mutex_lock( &mutex );
			int res = anadirAnfitrion(&lista, &tpartidas, sock_conn, anfitrion, aux);
			posicion = atoi(aux);
			pthread_mutex_unlock( &mutex);
			if (res == -1)
			{
				strcpy(respuestaAnfitrion, "7/Tabla de partidas llena\n");
				write (sock_conn, respuestaAnfitrion, strlen(respuestaAnfitrion));
			}
			else if (res == -2)
			{
				strcpy(respuestaAnfitrion, "7/Anfitrion no encontrado\n");
				write (sock_conn, respuestaAnfitrion, strlen(respuestaAnfitrion));
			}
			else
			{
				pthread_mutex_lock( &mutex );
				anadirInvitados(&lista, &tpartidas, frase, posicion);	
				pthread_mutex_unlock( &mutex);
				printf ("Posicion adri: %d\n", posicion);
				char invitacion[512];
				sprintf(invitacion, "7/%s,%d,\n", anfitrion, posicion);
				int j = 3;
				while(j < 10)
				{
					obtenerSocket(&tpartidas, posicion, j, aux);
					if(strcmp(aux,"") != 0)
					{
						printf ("Invitacion: %s\n", invitacion);
						int a = atoi(aux);
						write (a, invitacion, strlen(invitacion));
					}
					j = j + 2;
				}
			}
		}
		
		else if (codigo == 8)
		{
			char aux[10];
			int numPartida;
			pthread_mutex_lock( &mutex );
			respuestaInvitacion(&lista, &tpartidas, respuesta, frase, aux);
			numPartida = atoi(aux);
			int j = 1;
			while(j < 10)
			{
				obtenerSocket(&tpartidas, numPartida, j, aux);
				if(strcmp(aux,"") != 0)
				{
					printf("Respuesta: %s\n", respuesta);
					int a = atoi(aux);
					write (a, respuesta, strlen(respuesta));
				}
				j = j + 2;
			}
			pthread_mutex_unlock( &mutex);
			printf("BIEN\n");
		}
		
		if ((codigo != 0) && (codigo != 7) && (codigo != 8))
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

	serv_adr.sin_port = htons(7086);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	//La cola de peticiones pendientes no podra ser superior a 3
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	
	
	pthread_t thread;
	numSockets = 0;
	sockets = (int *)malloc(numSockets*sizeof(int));
	// Bucle para atender clientes
	for (;;){
		printf ("Escuchando\n");
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
