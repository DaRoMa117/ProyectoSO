DROP DATABASE IF EXISTS miBBDD;
CREATE DATABASE miBBDD;

USE miBBDD;

CREATE TABLE JUGADOR (
	ID INT NOT NULL,
	USUARIO VARCHAR(20) NOT NULL,
	CONTRASENA VARCHAR(20) NOT NULL,
	PRIMARY KEY (ID)
)ENGINE=InnoDb;

CREATE TABLE PARTIDA (
	ID INT NOT NULL,
	FECHAYHORA VARCHAR(60) NOT NULL, /* DIA/MES/AÑO HORA:MINUTO */
	DURACION INT NOT NULL, /* En minutos */
	RESULTADO VARCHAR(60) NOT NULL, /* VICTORIA O DERROTA */
	PRIMARY KEY (ID)
)ENGINE=InnoDb;

CREATE TABLE PUENTE (
	ID_J INT NOT NULL,
	ID_P INT NOT NULL,
	NUMVICTORIAS INT NOT NULL,
	NUMDERROTAS INT NOT NULL,
	FOREIGN KEY (ID_J) REFERENCES JUGADOR(ID),
	FOREIGN KEY (ID_P) REFERENCES PARTIDA(ID)
)ENGINE=InnoDb;

INSERT INTO JUGADOR VALUES (1, 'Daniel', '123456789D');
INSERT INTO JUGADOR VALUES (2, 'Adria', '987654321A');
INSERT INTO JUGADOR VALUES (3, 'Andrea', '134679258N');
INSERT INTO JUGADOR VALUES (4, 'Monica', '753918246M');

INSERT INTO PARTIDA VALUES (1, '25/02/2020 17:56', 50, 'DERROTA');
INSERT INTO PARTIDA VALUES (2, '2/03/2020 10:30', 130, 'VICTORIA');
INSERT INTO PARTIDA VALUES (3, '17/03/2020 12:00', 20, 'DERROTA');
INSERT INTO PARTIDA VALUES (4, '17/03/2020 14:20', 80, 'VICTORIA');

INSERT INTO PUENTE VALUES (1, 1, 70, 5);
INSERT INTO PUENTE VALUES (1, 4, 70, 6);
INSERT INTO PUENTE VALUES (2, 2, 101, 12);
INSERT INTO PUENTE VALUES (2, 4, 102, 12);
INSERT INTO PUENTE VALUES (3, 1, 7, 205);
INSERT INTO PUENTE VALUES (3, 3, 7, 206);
INSERT INTO PUENTE VALUES (4, 2, 122, 3);
INSERT INTO PUENTE VALUES (4, 4, 123, 3);


