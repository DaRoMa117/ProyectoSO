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

// Se define la estructura Conectado.
typedef struct {
	char usuario[20];
	int socket;
} Conectado;

// Se define la estructura ListaConectados, donde se guardan los usuarios conectados al servidor.
typedef struct {
	Conectado conectados [100];
	int num;
} ListaConectados;

// Se define una tabla TablaPartidas, donde se pueden acumular 20 partidas con 10 jugadores y una columna extra que guarda el numero de invitados.
typedef char TablaPartidas[20][21];

char consulta[512];
ListaConectados lista;
TablaPartidas tpartidas;
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
int *sockets;
int numSockets;
MYSQL *conn;
// Estructura especial para almacenar resultados de consultas.
MYSQL_RES *resultado;
MYSQL_ROW row;

// Se utiliza para cualquier consulta en la BBDDD.
void consultasBBDD (MYSQL *conn, char consulta[512], char respuesta[512]){
	int err;
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
}

// Se anyade el usuario y su socket a "ListaConectados".
// Devuelve 0 si se anyade correctamente y -1 si la lista esta llena.
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

// Se obtiene la posicion del usuario recibido.
// Devuelve la posicion si se encuentra en la lista y -1 si no se encuentra en la lista.
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

// Se elimina de el usuario que recibe de la lista "ListaConectados".
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

// Se obtiene la lista de conectados: 6/nombre1,nombre2,...,nombreN.
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

// Se registra el usuario recibido en la BBDD.
// Se devuelve una respuesta: 1/mensaje.
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
		sprintf(consulta, "INSERT INTO JUGADOR VALUES('%d','%s','%s', '0', '0')", idd, usuario, contrasena);
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

// Se da de baja al usuario recibido en la BBDD.
// Se devuelve una respuesta: 17/mensaje.
void bajaUsuario (MYSQL *conn, MYSQL_RES *resultado, MYSQL_ROW row, char usuario[20], char contrasena[20], char respuesta[512]){
	int idd;
	sprintf (consulta, "SELECT JUGADOR.ID FROM JUGADOR WHERE JUGADOR.USUARIO = '%s' AND JUGADOR.CONTRASENA = '%s'", usuario, contrasena);
	consultasBBDD (conn, consulta, respuesta);
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row != NULL){
		int err;
		idd = atoi(row[0]);
		sprintf(consulta, "DELETE FROM JUGADOR WHERE JUGADOR.ID = '%d' AND JUGADOR.USUARIO = '%s' AND JUGADOR.CONTRASENA = '%s'", idd, usuario, contrasena);
		err = mysql_query (conn, consulta);
		if (err!=0) {
			printf ("17/Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		else
			sprintf(respuesta, "17/%s: eliminado correctamente", usuario);
	}
	else{
		sprintf(respuesta, "17/%s: datos incorrectos", usuario);
	}
}

// Se guardan los datos de la partida una vez se ha terminado.
// No devuelve nada al cliente.
void guardarPartida (MYSQL *conn, MYSQL_RES *resultado, MYSQL_ROW row, char fecha[20], char hora[20], char miembros[512], char res[60], char respuesta[512]){
	char aux[512];
	strcpy(aux, miembros);
	char *p = strtok(miembros, "-");
	
	int idPartida;
	strcpy (consulta, "SELECT PARTIDA.ID FROM PARTIDA ORDER BY ID DESC");
	consultasBBDD (conn, consulta, respuesta);
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
		printf("No se han obtenido datos en la consulta\n");
	else
		idPartida = atoi(row[0]) + 1;
	
	sprintf (consulta, "INSERT INTO PARTIDA VALUES (%d, '%s' , '%s', '%s', '%s')", idPartida, fecha, hora, aux, res);
	consultasBBDD (conn, consulta, respuesta);
	
	while(p != NULL){
		int idJugador;
		sprintf (consulta, "SELECT JUGADOR.ID FROM JUGADOR WHERE JUGADOR.USUARIO = '%s'", p);
		consultasBBDD (conn, consulta, respuesta);
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		if (row == NULL)
			printf("No se han obtenido datos en la consulta\n");
		else{
			idJugador = atoi(row[0]);
			sprintf (consulta, "INSERT INTO PUENTE VALUES (%d, %d)", idJugador, idPartida);
			consultasBBDD (conn, consulta, respuesta);
		}
		
		if (strcmp(res, "VICTORIA") == 0)
		{
			int numVictorias = 0;
			sprintf (consulta, "SELECT JUGADOR.NUMVICTORIAS FROM JUGADOR WHERE JUGADOR.USUARIO = '%s'", p);
			consultasBBDD (conn, consulta, respuesta);
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			if (row == NULL)
				printf("No se han obtenido datos en la consulta\n");
			else{
				numVictorias = atoi(row[0]) + 1;
				sprintf (consulta, "UPDATE JUGADOR SET JUGADOR.NUMVICTORIAS = '%d' WHERE JUGADOR.USUARIO = '%s'", numVictorias, p);
				consultasBBDD (conn, consulta, respuesta);
			}
		}
		else
		{
			int numDerrotas = 0;
			int idj;
			sprintf (consulta, "SELECT JUGADOR.NUMDERROTAS FROM JUGADOR WHERE JUGADOR.USUARIO = '%s'", p);
			consultasBBDD (conn, consulta, respuesta);
			resultado = mysql_store_result (conn);
			row = mysql_fetch_row (resultado);
			if (row == NULL)
				printf("No se han obtenido datos en la consulta\n");
			else{
				numDerrotas = atoi(row[0]) + 1;
				sprintf (consulta, "UPDATE JUGADOR SET JUGADOR.NUMDERROTAS = '%d' WHERE JUGADOR.USUARIO = '%s'", numDerrotas, p);
				consultasBBDD (conn, consulta, respuesta);
			}
		}
		p = strtok(NULL, "-");
	}
}

// Se inicia sesion con el usuario recibido.
// Devuelve 0 si se ha iniciado correctamente.
// Devuelve -1 si el usuario ya esta conectado, si no se ha podidio anyadir o si la contrasenya es incorrecta.
// En cualquier de los casos se devuelve una respuesta: 2/mensaje.
int iniciarUsuario (MYSQL *conn, MYSQL_RES *resultado, MYSQL_ROW row, char usuario[20], char contrasena[20], char respuesta[512], ListaConectados *lista, int sock){
	sprintf (consulta, "SELECT JUGADOR.CONTRASENA FROM JUGADOR WHERE JUGADOR.USUARIO = '%s'", usuario);
	consultasBBDD (conn, consulta, respuesta);
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	int i;
	int encontrado = 0;
	if (row == NULL){
		sprintf(respuesta, "2/error1");
		return -1;
	}
	else{
		while ((i < lista->num) && (!encontrado))
		{
			if(strcmp(lista->conectados[i].usuario,usuario) == 0)
			{
				encontrado = 1;
				sprintf(respuesta, "2/error3");
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
				sprintf(respuesta, "2/error2");
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

// Se consulta el resultado de la partida anterior jugada por el usuario que hace la consulta.
// Se devuelve una respuesta: 3/resultado.
void consultaResultadoPartidaAnterior (MYSQL *conn, MYSQL_RES *resultado, MYSQL_ROW row, char usuario[20], char respuesta[512]){
	char anterior[20];
	sprintf(consulta,"SELECT PARTIDA.RESULTADO FROM (JUGADOR, PUENTE, PARTIDA) WHERE JUGADOR.USUARIO = '%s' AND JUGADOR.ID = PUENTE.ID_J AND PUENTE.ID_P = PARTIDA.ID", usuario); 
	consultasBBDD (conn, consulta, respuesta);
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);	
	if (row == NULL)
		strcpy (respuesta, "3/DESCONOCIDO/");
	else{
		strcpy(respuesta, "3/");
		while (row != NULL) {
			strcpy(anterior, row[0]);
			row = mysql_fetch_row (resultado);
		}
		sprintf(respuesta, "%s%s/ ", respuesta, anterior);
	}
}

// Se consulta el numero de victorias del usuario que hace la consulta.
// Se devuelve una respuesta: 4/victorias.
void consultaNumVictorias (MYSQL *conn, MYSQL_RES *resultado, MYSQL_ROW row, char usuario[20], char respuesta[512]){
	sprintf (consulta, "SELECT JUGADOR.NUMVICTORIAS FROM JUGADOR WHERE JUGADOR.USUARIO = '%s'", usuario);
	consultasBBDD (conn, consulta, respuesta);
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado); 
	if (row == NULL)
		strcpy (respuesta, "4/ERROR/");
	else
		sprintf (respuesta, "4/%s/", row[0]);
}

// Se consulta el numero de derrotas del usuario que hace la consulta.
// Se devuelve una respuesta: 5/derrotas.
void consultaNumDerrotas (MYSQL *conn, MYSQL_RES *resultado, MYSQL_ROW row, char usuario[20], char respuesta[512]){
	sprintf (consulta, "SELECT JUGADOR.NUMDERROTAS FROM JUGADOR WHERE JUGADOR.USUARIO = '%s'", usuario);
	consultasBBDD (conn, consulta, respuesta);
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado); 
	if (row == NULL)
		strcpy (respuesta, "5/ERROR/");
	else
		sprintf (respuesta, "5/%s/", row[0]);
}

// Se consulta la fecha y la hora de la ultima partida jugada por el usuario que hace la consulta.
// Se devuelve una respuesta: 19/fecha/hora.
void consultaFechaHora (MYSQL *conn, MYSQL_RES *resultado, MYSQL_ROW row, char usuario[20], char respuesta[512]){
	char anteriorFecha[20];
	char anteriorHora[20];
	sprintf (consulta, "SELECT PARTIDA.FECHA, PARTIDA.HORA FROM (JUGADOR, PARTIDA, PUENTE) WHERE JUGADOR.USUARIO = '%s' AND JUGADOR.ID = PUENTE.ID_J AND PUENTE.ID_P = PARTIDA.ID", usuario);
	consultasBBDD (conn, consulta, respuesta);
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado); 
	if (row == NULL)
		strcpy (respuesta, "19/ERROR,ERROR,");
	else{
		while (row != NULL) {
			strcpy(anteriorFecha, row[0]);
			strcpy(anteriorHora, row[1]);
			row = mysql_fetch_row (resultado);
		}
		sprintf (respuesta, "19/19,%s,%s,", anteriorFecha, anteriorHora);
	}
}

void dameMiembros (TablaPartidas *tpartidas, int numPartida, char respuesta[512]){
	int i = 0;
	sprintf(respuesta, "%s/", respuesta);
	for (i = 0; i <= 20; i = i + 2){
		if (strcmp(tpartidas[numPartida][i + 1],"") != 0)
		{
			sprintf(respuesta, "%s%s-", respuesta, tpartidas[numPartida][i]);
		}
	}
	sprintf(respuesta, "%s/", respuesta);
}

// Se anyade al anfitrion a "TablaPartidas".
// Devuelve 0 si se ha anyadido correctamente, -1 si la tabla esta llena o -2 si el usuario no se encuentra en la lista de conectados.
int anadirAnfitrion(ListaConectados *lista, TablaPartidas *tpartidas, int sock, char host[20], char aux[10]){
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
		int anadido = 0;
		int j = 0;
		while ((j < 20) && (!anadido))
		{
			if (strcmp(tpartidas[j][0],"") == 0)
			{
				anadido = 1;
				sprintf(aux, "%d", j);
				strcpy(tpartidas[j][0], anfitrion);
				sprintf(tpartidas[j][1], "%d", sock);
			}
			j++;
		}
		
		if(anadido == 1)
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

// Se anyade a los invitados a "TablaPartidas" y el numero de invitados total.
void anadirInvitados(ListaConectados *lista, TablaPartidas *tpartidas, char frase[512], int posicion){
	int encontrado = 0;
	int i = 0;
	int socket;
	int cont = 2;
	int numInvitados = 0;
	char nombre[20];
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
			numInvitados++;
			strcpy(tpartidas[posicion][cont], nombre);
			sprintf(tpartidas[posicion][cont + 1], "%d", socket);
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
	sprintf(tpartidas[posicion][cont], "%d", numInvitados);
}

// Se obtiene el socket de "TablaPartidas" del usuario j-1.
void obtenerSocket(TablaPartidas *tpartidas, int posicion, int j, char aux[10]){
	strcpy(aux, tpartidas[posicion][j]);
}

// Se obtiene la colummna donde se encuentra el total de los invitados.
// Devuelve la posicion de la columna deseada en "TablaPartidas".
int obtenerInvitados (TablaPartidas *tpartidas, int numPartida){
	int encontrado = 0;
	int i = 0;
	int columna;
	
	while((i <= 20) && (!encontrado))
	{
		if(strcmp(tpartidas[numPartida][i], "") == 0)
		{
			encontrado = 1;
			columna = (i - 1);
		}
		else
		   i++;
	}
	if(!encontrado)
	{
		columna = 20;
	}
	return columna;
}

// Se escribe la respuesta a la invitacion.
void respuestaInvitacion(ListaConectados *lista, TablaPartidas *tpartidas, char respuesta[512], char frase[512], char aux[10], char aux1[20]){
	int numPartida;
	char res[10];
	char *p = strtok(frase, "/");
	p = strtok(NULL, "/");
	strcpy(aux, p);
	numPartida = atoi(p);
	int num = obtenerInvitados(tpartidas, numPartida);
	p = strtok(NULL, "/");
	strcpy(res, p);
	if (strcmp(tpartidas[numPartida][num], "0") != 0)
	{
		if (strcmp(res, "si") == 0)
		{
			sprintf(respuesta, "8/%d,si,", numPartida);
			int a = (atoi(tpartidas[numPartida][num]) - 1);
			sprintf(tpartidas[numPartida][num], "%d", a);
		}
		
		else if (strcmp(res, "no") == 0)
		{
			sprintf(respuesta, "8/%d,no,", numPartida);
			strcpy(tpartidas[numPartida][num],"0");
		}
		strcpy(aux1,tpartidas[numPartida][num]);
	}
	else
		strcpy(aux1,"1");
}

// Se atienden las peticiones de los clientes.
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
	int sockAnfitrion;
	
	// Bucle para consultar las peticiones del cliente.
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
		if (codigo == 0){ // Se desconecta la conexion y se elimina al usuario de "ListaConectados".
			p = strtok( NULL, "/");
			strcpy (usuario, p);
			pthread_mutex_lock( &mutex );
			eliminaConectado (&lista, usuario);
			pthread_mutex_unlock( &mutex );
			char respuestaDesconectar[512];
			strcpy(respuestaDesconectar, "0/");
			write (sock_conn, respuestaDesconectar, strlen(respuestaDesconectar));
			end = 1;
		}
		else if (codigo == 1){ // Registro del usuario.
			p = strtok( NULL, "/");
			strcpy (usuario, p);
			p = strtok( NULL, "/");
			strcpy(contrasena, p);
			registrarUsuario(conn, resultado, row, usuario, contrasena, respuesta);
			end = 1;
		}
		else if (codigo == 2){ // Login del usuario.
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
		else if (codigo == 3){ // Consulta del resultado de la ultima partida jugada por el usuario.
			p = strtok( NULL, "/");
			strcpy (usuario, p);
			consultaResultadoPartidaAnterior(conn, resultado, row, usuario, respuesta);
		}
		else if (codigo == 4){ // Consulta el numero de victorias del usuario.
			p = strtok( NULL, "/");
			strcpy (usuario, p);
			consultaNumVictorias(conn, resultado, row, usuario, respuesta);	
		}
		else if (codigo == 5){ // Consulta el numero de derrotas del usuario.
			p = strtok( NULL, "/");
			strcpy (usuario, p);
			consultaNumDerrotas(conn, resultado, row, usuario, respuesta);
		}
		else if (codigo == 7){ // Se envian las invitaciones a los usuarios que ha invitado el anfitrion.
			char anfitrion[20];
			sockAnfitrion = sock_conn;
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
				printf ("Posicion: %d\n", posicion);
				char invitacion[512];
				sprintf(invitacion, "7/%s,%d,\n", anfitrion, posicion);
				int j = 3;
				while(j < 20)
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
				pthread_mutex_unlock( &mutex);
			}
		}
		
		else if (codigo == 8){ // Se reciben las respuestas de los invitados y se les envia a todos los enviados (incluido a uno mismo) y al anfitrion.
			char aux[10];
			char aux1[10];
			int numPartida;
			pthread_mutex_lock( &mutex );
			respuestaInvitacion(&lista, &tpartidas, respuesta, frase, aux, aux1);
			numPartida = atoi(aux);
			dameMiembros(&tpartidas, numPartida, respuesta);
			if (strcmp(aux1, "0") == 0)
			{
				int j = 1;
				while(j < 20)
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
			}
			pthread_mutex_unlock( &mutex);
		}
		
		else if (codigo == 9){ // Intercambio de mensajes entre los jugadores de las partidas (chat).
			char aux[10];
			p = strtok( NULL, "/");
			char numPantalla[5];
			strcpy(numPantalla, p);
			p = strtok( NULL, "/");
			int numPartida;
			numPartida = atoi(p);
			p = strtok( NULL, "/");
			char mensaje[512];
			strcpy(mensaje, p);
			p = strtok( NULL, "/");
			char pantalla[20];
			strcpy(pantalla, p);
			p = strtok( NULL, "/");
			char mensajeChat[512];
			strcpy (mensajeChat, "9/");
			if (p != NULL)
			{
				sprintf(mensajeChat, "%s%s,%s,%s,%s,", mensajeChat, numPantalla, mensaje, pantalla, p);
			}
			else
			{
				sprintf(mensajeChat, "%s%s,%s,%s,", mensajeChat, numPantalla, mensaje, pantalla);
			}
			pthread_mutex_lock( &mutex );
			int j = 1;
			while(j < 20)
			{
				obtenerSocket(&tpartidas, numPartida, j, aux);
				if(strcmp(aux,"") != 0)
				{
					printf("CHAT: %s\n", mensajeChat);
					int a = atoi(aux);
					write (a, mensajeChat, strlen(mensajeChat));
				}
				j = j + 2;
			}
			pthread_mutex_unlock( &mutex);
		}
		
		else if (codigo == 10){ // Enviar repuesta propuesta de la primera pantalla a todos los usuarios.
			char aux[10];
			p = strtok( NULL, "/");
			char numPantalla[5];
			strcpy(numPantalla, p);
			p = strtok( NULL, "/");
			int numPartida;
			numPartida = atoi(p);
			p = strtok( NULL, "/");
			char respuestaUno[512];
			strcpy (respuestaUno, "10/");
			sprintf(respuestaUno, "%s%s,%s,", respuestaUno, numPantalla, p);
			pthread_mutex_lock( &mutex );
			int j = 1;
			while(j < 20)
			{
				obtenerSocket(&tpartidas, numPartida, j, aux);
				if(strcmp(aux,"") != 0)
				{
					printf("RESPUESTA UNO: %s\n", respuestaUno);
					int a = atoi(aux);
					write (a, respuestaUno, strlen(respuestaUno));
				}
				j = j + 2;
			}
			pthread_mutex_unlock( &mutex);
		}
		
		else if (codigo == 11){ // Abrir manual a todos los clientes menos al que ha encontrado el boton.
			char aux[10];
			p = strtok( NULL, "/");
			char numPantalla[5];
			strcpy(numPantalla, p);
			p = strtok( NULL, "/");
			int numPartida;
			numPartida = atoi(p);
			char tipoPantallaDos[512];
			pthread_mutex_lock( &mutex );
			int j = 1;
			while(j < 20)
			{
				obtenerSocket(&tpartidas, numPartida, j, aux);
				if(strcmp(aux,"") != 0)
				{
					int a = atoi(aux);
					if (a != sock_conn)
					{
						strcpy (tipoPantallaDos, "11/");
						sprintf(tipoPantallaDos, "%s%s,%s,", tipoPantallaDos, numPantalla, "segundaManual");
						printf ("%s\n", tipoPantallaDos);
						write (a, tipoPantallaDos, strlen(tipoPantallaDos));
					}
					else
					{
						strcpy (tipoPantallaDos, "11/");
						sprintf(tipoPantallaDos, "%s%s,%s,", tipoPantallaDos, numPantalla, "segundaPrimera");
						printf ("%s\n", tipoPantallaDos);
						write (a, tipoPantallaDos, strlen(tipoPantallaDos));
					}
				}
				j = j + 2;
			}
			pthread_mutex_unlock( &mutex);
		}
		
		else if (codigo == 12){ // Enviar repuesta propuesta de la segunda pantalla a todos los usuarios.
			char aux[10];
			p = strtok( NULL, "/");
			char numPantalla[5];
			strcpy(numPantalla, p);
			p = strtok( NULL, "/");
			int numPartida;
			numPartida = atoi(p);
			p = strtok( NULL, "/");
			char posicion[5];
			strcpy(posicion, p);
			p = strtok( NULL, "/");
			char numPantallaDos[5];
			strcpy(numPantallaDos, p);
			p = strtok( NULL, "/");
			char respuestaDos[512];
			strcpy (respuestaDos, "12/");
			sprintf(respuestaDos, "%s%s,%s,%s,%s,", respuestaDos, numPantalla, posicion, numPantallaDos, p);
			pthread_mutex_lock( &mutex );
			int j = 1;
			while(j < 20)
			{
				obtenerSocket(&tpartidas, numPartida, j, aux);
				if(strcmp(aux,"") != 0)
				{
					printf("RESPUESTA DOS: %s\n", respuestaDos);
					int a = atoi(aux);
					write (a, respuestaDos, strlen(respuestaDos));
				}
				j = j + 2;
			}
			pthread_mutex_unlock( &mutex);
		}
		
		else if (codigo == 14){ // Enviar movimiento de las piezas del puzzle.
			char aux[10];
			p = strtok( NULL, "/");
			char numPantalla[5];
			strcpy(numPantalla, p);
			p = strtok( NULL, "/");
			int numPartida;
			numPartida = atoi(p);
			p = strtok( NULL, "/");
			char movimientoTres[512];
			strcpy (movimientoTres, "14/");
			sprintf(movimientoTres, "%s%s,%s,", movimientoTres, numPantalla, p);
			pthread_mutex_lock( &mutex );
			int j = 1;
			while(j < 20)
			{
				obtenerSocket(&tpartidas, numPartida, j, aux);
				if(strcmp(aux,"") != 0)
				{
					int a = atoi(aux);
					if (a != sock_conn)
					{
						printf("RESPUESTA TRES: %s\n", movimientoTres);
						write (a, movimientoTres, strlen(movimientoTres));
					}
				}
				j = j + 2;
			}
			pthread_mutex_unlock( &mutex);
		}
		
		else if (codigo == 15){ // Enviar repuesta propuesta de la tercera pantalla a todos los usuarios.
			char aux[10];
			p = strtok( NULL, "/");
			char numPantalla[5];
			strcpy(numPantalla, p);
			p = strtok( NULL, "/");
			int numPartida;
			numPartida = atoi(p);
			p = strtok( NULL, "/");
			char comprobacionTres[512];
			strcpy (comprobacionTres, "15/");
			sprintf(comprobacionTres, "%s%s,%s,", comprobacionTres, numPantalla, p);
			pthread_mutex_lock( &mutex );
			int j = 1;
			while(j < 20)
			{
				obtenerSocket(&tpartidas, numPartida, j, aux);
				if(strcmp(aux,"") != 0)
				{
					int a = atoi(aux);
					printf("RESPUESTA TRES: %s\n", comprobacionTres);
					write (a, comprobacionTres, strlen(comprobacionTres));
				}
				j = j + 2;
			}
			pthread_mutex_unlock( &mutex);
		}
		
		else if (codigo == 16){ // Enviar repuesta propuesta de la pantalla final a todos los usuarios.
			char aux[10];
			p = strtok( NULL, "/");
			char numPantalla[5];
			strcpy(numPantalla, p);
			p = strtok( NULL, "/");
			int numPartida;
			numPartida = atoi(p);
			p = strtok( NULL, "/");
			char propuesta[512];
			strcpy(propuesta, p);
			p = strtok( NULL, "/");
			char comprobacionFinal[512];
			strcpy (comprobacionFinal, "16/");
			sprintf(comprobacionFinal, "%s%s,%s,%s,", comprobacionFinal, numPantalla, propuesta, p);
			pthread_mutex_lock( &mutex );
			int j = 1;
			while(j < 20)
			{
				obtenerSocket(&tpartidas, numPartida, j, aux);
				if(strcmp(aux,"") != 0)
				{
					int a = atoi(aux);
					printf("RESPUESTA FINAL: %s\n", comprobacionFinal);
					write (a, comprobacionFinal, strlen(comprobacionFinal));
				}
				j = j + 2;
			}
			pthread_mutex_unlock( &mutex);
		}
		
		else if (codigo == 17){ // Se da de baja al jugador del que recibe usuario y contrasena.
			p = strtok( NULL, "/");
			strcpy (usuario, p);
			p = strtok( NULL, "/");
			strcpy(contrasena, p);
			bajaUsuario(conn, resultado, row, usuario, contrasena, respuesta);
			end = 1;
		}
		
		else if (codigo == 18){ // Se guarda la partida.
			p = strtok( NULL, ",");
			char fecha[20];
			strcpy (fecha, p);
			p = strtok( NULL, ",");
			char hora[20];
			strcpy (hora, p);
			p = strtok( NULL, ",");
			char miembros[512];
			strcpy (miembros, p);
			p = strtok( NULL, ",");
			char res[20];
			strcpy (res, p);
			if (sockAnfitrion == sock_conn)
			{
				guardarPartida(conn, resultado, row, fecha, hora, miembros, res, respuesta);
			}
		}
		
		else if (codigo == 19){ // Consulta la fecha y hora de la ultima partida jugada por el usuario.
			p = strtok( NULL, "/");
			strcpy (usuario, p);
			consultaFechaHora(conn, resultado, row, usuario, respuesta);
		}
	
		if ((codigo != 0) && (codigo != 7) && (codigo != 8) && (codigo != 9) && (codigo != 10) && (codigo != 11) && (codigo != 12) && (codigo != 14) && (codigo != 15) && (codigo != 16) && (codigo != 18)) // Se envia las respuesta en los casos 1,2,3,4,5, 6 y 17.
		{
			printf ("%s\n", respuesta);
			write (sock_conn, respuesta, strlen(respuesta));
		}
		
		if (((codigo == 0) || (codigo == 2)) && (lista.num != 0)){ // Notificacion de "ListaConectados" cada vez que haya una actualizacion en la lista y siempre que haya quede algun usuario conectado.
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
	// INICIALIZACIONES.
	lista.num = 0;
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	
	// Abrimos el socket de escucha.
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	
	memset(&serv_adr, 0, sizeof(serv_adr)); // Inicialitza a zero serv_addr.
	serv_adr.sin_family = AF_INET;
	
	// Asocia el socket a cualquiera de las IP de la maquina. 
	// htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);

	serv_adr.sin_port = htons(50069);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	// La cola de peticiones pendientes no podra ser superior a 3.
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	pthread_t thread;
	numSockets = 0;
	sockets = (int *)malloc(numSockets*sizeof(int)); // Socket creado como un vector dinamico.
	
	// Bucle para atender clientes.
	for (;;){
		printf ("Escuchando\n");
		
		// Creamos una conexion al servidor MYSQL.
		conn = mysql_init(NULL);
		if (conn==NULL) {
			printf ("Error al crear la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		// Inicializar la conexion.
		conn = mysql_real_connect (conn,"localhost","root", "mysql","T7_BBDD",0, NULL, 0); // Maquina propia.
		//conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T7_BBDD",0, NULL, 0); // Entorno de produccion. 
		
		if (conn==NULL) {
			printf ("Error al inicializar la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		
		// sock_conn es el socket que usaremos para este cliente.
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		sockets[numSockets] = sock_conn;
		
		// Crear thead y decirle lo que tiene que hacer.
		pthread_create (&thread, NULL, AtenderCliente,&sockets[numSockets]);
		numSockets++;
	}
	exit(0);
}
