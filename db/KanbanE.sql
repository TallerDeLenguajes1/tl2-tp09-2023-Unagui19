--
-- Archivo generado con SQLiteStudio v3.4.4 el lun. oct. 30 19:55:13 2023
--
-- Codificaci�n de texto usada: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Tabla: Tablero
CREATE TABLE IF NOT EXISTS Tablero (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, id_usuario_propietario INTEGER REFERENCES Usuario (id_usuario) NOT NULL, nombre TEXT (100) NOT NULL, descripcion TEXT (200));
INSERT INTO Tablero (id, id_usuario_propietario, nombre, descripcion) VALUES (1, 1, 'tab1', 'es el 1');
INSERT INTO Tablero (id, id_usuario_propietario, nombre, descripcion) VALUES (2, 1, 'tabla2', 'esosos');

-- Tabla: Tarea
CREATE TABLE IF NOT EXISTS Tarea (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, id_tablero INTEGER REFERENCES Tablero (id) NOT NULL, nombre TEXT (100) NOT NULL, estado INTEGER NOT NULL, descripcion TEXT (200), color TEXT (100), id_usuario_asignado INTEGER);
INSERT INTO Tarea (id, id_tablero, nombre, estado, descripcion, color, id_usuario_asignado) VALUES (1, 1, 'tp8-F', 2, 'es que si', 'blanco', NULL);
INSERT INTO Tarea (id, id_tablero, nombre, estado, descripcion, color, id_usuario_asignado) VALUES (3, 1, 'cca', 2, 'hololo', 'azul', 1);

-- Tabla: Usuario
CREATE TABLE IF NOT EXISTS Usuario (id_usuario INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, nombre_de_usuario TEXT NOT NULL UNIQUE);
INSERT INTO Usuario (id_usuario, nombre_de_usuario) VALUES (1, 'franco');
INSERT INTO Usuario (id_usuario, nombre_de_usuario) VALUES (2, 'lourdes');
INSERT INTO Usuario (id_usuario, nombre_de_usuario) VALUES (3, 'emanuel');
INSERT INTO Usuario (id_usuario, nombre_de_usuario) VALUES (4, 'Emanuel');
INSERT INTO Usuario (id_usuario, nombre_de_usuario) VALUES (5, 'Simon');

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
