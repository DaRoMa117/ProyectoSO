#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <ctype.h>
#include <mysql.h>

int main(int argc, char *argv[])
{
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[512];
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
	// escucharemos en el port 9050
	serv_adr.sin_port = htons(9010);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	//La cola de peticiones pendientes no podra ser superior a 3
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	//BASE DE DATOS
	MYSQL *conn;
	int err;
	// Estructura especial para almacenar resultados de consultas
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	int id;
	char usuario[20];
	char contrasena[20];
	char consulta [512];
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
	
	// Atenderemos todas las petiticiones
	int i;
	for(;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		//sock_conn es el socket que usaremos para este cliente
		
		//Bucle para consultar las peticiones del cliente
		int end = 0;
		while (end == 0)
		{		
			// Ahora recibimos su nombre, que dejamos en buff
			ret=read(sock_conn,peticion, sizeof(peticion));
			printf ("Recibido\n");
			
			// Tenemos que añadirle la marca de fin de string 
			// para que no escriba lo que hay despues en el buffer
			peticion[ret]='\0';
			
			//Escribimos el nombre en la consola
			
			printf ("Peticion: %s\n",peticion);
			
			char *p = strtok( peticion, "/");
			int codigo =  atoi (p);
						
			if (codigo == 0)
				end = 1;
			else if (codigo == 1){// Registro del usuario
				p = strtok( NULL, "/");
				strcpy (usuario, p);
				p = strtok( NULL, "/");
				strcpy (contrasena, p);
				int idd;
				strcpy (consulta, "SELECT JUGADOR.ID FROM JUGADOR ORDER BY ID DESC");
				err=mysql_query (conn, consulta);
				if (err!=0) {
					sprintf (respuesta, "Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				if (row == NULL)
					strcpy (respuesta, "No se han obtenido datos en la consulta\n");
				else
					idd = atoi(row[0]) + 1;
				
				sprintf (consulta, "SELECT JUGADOR.USUARIO FROM JUGADOR WHERE JUGADOR.USUARIO = '%s'", usuario);
				err=mysql_query (conn, consulta);
				if (err!=0) {
					sprintf (respuesta, "Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				if (row == NULL){
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
			else if (codigo == 2){ // login del usuario
				p = strtok( NULL, "/");
				strcpy (usuario, p);
				p = strtok( NULL, "/");
				strcpy (contrasena, p);
				sprintf (consulta, "SELECT JUGADOR.CONTRASENA FROM JUGADOR WHERE JUGADOR.USUARIO = '%s'", usuario);
				err=mysql_query (conn, consulta);
				if (err!=0) {
					sprintf (respuesta, "Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				resultado = mysql_store_result (conn);
				row = mysql_fetch_row (resultado);
				if (row == NULL)
					sprintf(respuesta, "%s: no existe", usuario);
				else{
					if (strcmp(contrasena,row[0]) == 0)
						sprintf(respuesta, "%s: login realizado correctamente", usuario);
					else
						sprintf(respuesta, "%s: contraseña incorrecta", usuario);
				}
			}
			else if (codigo == 3){
				strcpy(consulta,"SELECT DISTINCT JUGADOR.USUARIO FROM (JUGADOR, PUENTE, PARTIDA) WHERE PARTIDA.DURACION > 60 AND PARTIDA.ID = PUENTE.ID_P AND PUENTE.ID_J = JUGADOR.ID"); 
				err=mysql_query (conn, consulta);
				if (err!=0) {
					sprintf (respuesta, "Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
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
			else if (codigo == 4){
				p = strtok( NULL, "/");
				strcpy (usuario, p);
				sprintf (consulta, "SELECT PARTIDA.ID FROM (JUGADOR, PARTIDA, PUENTE) WHERE JUGADOR.USUARIO = '%s' AND JUGADOR.ID = PUENTE.ID_J AND PUENTE.ID_P = PARTIDA.ID AND PARTIDA.RESULTADO = 'DERROTA'", usuario);
				err=mysql_query (conn, consulta); 
				if (err!=0) {
					sprintf (respuesta, "Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				//recogemos el resultado de la consulta 
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
			else{
				p = strtok( NULL, "/");
				strcpy (contrasena, p);
				sprintf (consulta,"SELECT FECHAYHORA FROM (JUGADOR, PARTIDA, PUENTE) WHERE JUGADOR.CONTRASENA = '%s' AND PARTIDA.ID = PUENTE.ID_P AND PUENTE.ID_J = JUGADOR.ID", contrasena);
				err=mysql_query (conn, consulta);
				if (err!=0) {
					sprintf (respuesta, "Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				//recogemos el resultado de la consulta
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
			
			if (codigo != 0)
			{
				printf ("%s\n", respuesta);
				// Y lo enviamos
				write (sock_conn,respuesta, strlen(respuesta));
			}
		}
		// Se acabo el servicio para este cliente
		close(sock_conn); 
	}
	mysql_close (conn);
	exit(0);
}
