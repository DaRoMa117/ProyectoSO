DROP DATABASE IF EXISTS T7_BBDD;
CREATE DATABASE T7_BBDD;

USE T7_BBDD;

CREATE TABLE JUGADOR (
	ID INT NOT NULL,
	USUARIO VARCHAR(20) NOT NULL,
	CONTRASENA VARCHAR(20) NOT NULL,
	NUMVICTORIAS INT NOT NULL,
	NUMDERROTAS INT NOT NULL,
	PRIMARY KEY (ID)
)ENGINE=InnoDb;

CREATE TABLE PARTIDA (
	ID INT NOT NULL,
	FECHA VARCHAR(20) NOT NULL,
	HORA VARCHAR(20) NOT NULL, 
	MIEMBROS VARCHAR(512) NOT NULL,
	RESULTADO VARCHAR(60) NOT NULL, 
	PRIMARY KEY (ID)
)ENGINE=InnoDb;

CREATE TABLE PUENTE (
	ID_J INT NOT NULL,
	ID_P INT NOT NULL,
	FOREIGN KEY (ID_J) REFERENCES JUGADOR(ID),
	FOREIGN KEY (ID_P) REFERENCES PARTIDA(ID)
)ENGINE=InnoDb;

INSERT INTO JUGADOR VALUES (1, 'Daniel', '123456789D', '70', '1');
INSERT INTO JUGADOR VALUES (2, 'Adria', '987654321A', '69', '720');
INSERT INTO JUGADOR VALUES (3, 'Andrea', '134679258N', '100', '5');
INSERT INTO JUGADOR VALUES (4, 'Monica', '753918246M', '250', '3');

INSERT INTO PARTIDA VALUES (1, '25/02/2020' , '17:56', 'Daniel-Andrea', 'DERROTA');
INSERT INTO PARTIDA VALUES (2, '2/03/2020', '10:30', 'Adria-Monica', 'VICTORIA');
INSERT INTO PARTIDA VALUES (3, '17/03/2020', '12:00', 'Adria-Andrea', 'DERROTA');
INSERT INTO PARTIDA VALUES (4, '17/03/2020', '14:20', 'Daniel-Adria-Monica', 'VICTORIA');

INSERT INTO PUENTE VALUES (1, 1);
INSERT INTO PUENTE VALUES (1, 4);
INSERT INTO PUENTE VALUES (2, 2);
INSERT INTO PUENTE VALUES (2, 3);
INSERT INTO PUENTE VALUES (2, 4);
INSERT INTO PUENTE VALUES (3, 1);
INSERT INTO PUENTE VALUES (3, 3);
INSERT INTO PUENTE VALUES (4, 2);
INSERT INTO PUENTE VALUES (4, 4);



