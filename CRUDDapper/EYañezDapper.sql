--CREATE, ALTER, DROP, TRUNCATE 
-- DDL
--DELETE
--IDENTITY(1,1)

CREATE DATABASE EYañezDapper
GO
USE EYañezDapper
GO

CREATE TABLE Alumno
(
	IdAlumno INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL, 
	ApellidoPaterno VARCHAR(50) NOT NULL, 
	ApellidoMaterno VARCHAR(50) NOT NULL, 
	--Edad TINYINT --10000000, 
	FechaNacimiento DATE,
	Matricula VARCHAR(20),
	Sexo CHAR(2),
	Email VARCHAR(100)
)

--- INSERT, UPDATE, DELETE
--DML Lenguaje de manipulación de datos

INSERT INTO [Alumno]--TABLA 
           ([Nombre]
           ,[ApellidoPaterno]
           ,[ApellidoMaterno]
           ,[FechaNacimiento]
           ,[Matricula]
           ,[Sexo]
           ,[Email])--COLUMNAS 
     VALUES
           ('Arantza','Juan','Alfonso','1998/09/09','123456','F','ajuan@gmail.com')--DATOS
GO
-- SELECT 
SELECT * FROM Alumno
GO

--ELIMINAR
CREATE PROCEDURE AlumnoRemove
@IdAlumno INT
AS
	DELETE FROM [dbo].[Alumno]
		WHERE IdAlumno = @IdAlumno
GO

AlumnoRemove 5
GO

--ACTUALIZAR
CREATE PROCEDURE AlumnoUpdate
@IdAlumno INT,
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@FechaNacimiento VARCHAR(20),
@Matricula VARCHAR(20),
@Sexo CHAR(2),
@Email VARCHAR(100),
@IdSemestre TINYINT
AS
	UPDATE [dbo].[Alumno]
		SET [Nombre] = @Nombre
			,[ApellidoPaterno] = @ApellidoPaterno
			,[ApellidoMaterno] = @ApellidoMaterno
			,[FechaNacimiento] = @FechaNacimiento
			,[Matricula] = @Matricula
			,[Sexo] = @Sexo
			,[Email] = @Email
			,[IdSemestre] = @IdSemestre
				WHERE IdAlumno = @IdAlumno
GO

AlumnoUpdate 4,'Daniel','Valdez','Muñoz','01-01-1998','54848','M','dvaldez@gmail.com','1'
GO

--LEER
CREATE PROCEDURE AlumnoGetAll
AS
	SELECT [IdAlumno]
		  ,[Nombre]
		  ,[ApellidoPaterno]
		  ,[ApellidoMaterno]
		  ,[FechaNacimiento]
		  ,[Matricula]
		  ,[Sexo]
		  ,[Email]
	  FROM [Alumno]
GO

--BUSCAR POR ID
CREATE PROCEDURE AlumnoGetById
@IdAlumno INT
AS
	SELECT [IdAlumno]
		  ,[Nombre]
		  ,[ApellidoPaterno]
		  ,[ApellidoMaterno]
		  ,[FechaNacimiento]
		  ,[Matricula]
		  ,[Sexo]
		  ,[Email]
	  FROM [Alumno]
	  WHERE IdAlumno = @IdAlumno

GO

--AGREGAR
CREATE PROCEDURE AlumnoAdd
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@FechaNacimiento VARCHAR(20),
@Matricula VARCHAR(20),
@Sexo CHAR(2),
@Email VARCHAR(100)
AS
	INSERT INTO [Alumno]--TABLA 
           ([Nombre]
           ,[ApellidoPaterno]
           ,[ApellidoMaterno]
           ,[FechaNacimiento]
           ,[Matricula]
           ,[Sexo]
           ,[Email])--COLUMNAS 
     VALUES
           (@Nombre,
		   @ApellidoPaterno,
		   @ApellidoMaterno,
		   CONVERT(DATE,@FechaNacimiento,105),--dd--MM-yyyy
		   @Matricula,
		   @Sexo,
		   @Email)--DATOS
GO

AlumnoAdd 'Arantza','Juan','Alfonso','09-09-1998','123456','F','ajuan@gmail.com'

--NUEVA TABLA
CREATE TABLE Semestre
( 
		IdSemestre TINYINT PRIMARY KEY IDENTITY(1,1),
		Nombre VARCHAR(50)
)

		INSERT INTO Semestre (Nombre) VALUES ('Primero')
		INSERT INTO Semestre (Nombre) VALUES ('Segundo')
		INSERT INTO Semestre (Nombre) VALUES ('Tercero')


--DDL

ALTER TABLE Alumno 
ADD IdSemestre TINYINT FOREIGN KEY REFERENCES Semestre(IdSemestre)
GO

AlumnoGetAll

-- Crear tabla rol y tabla usuario

CREATE TABLE Rol
(
	IdRol TINYINT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50)
)

CREATE TABLE Usuario
(
	IdUsuario TINYINT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50)NOT NULL,
	ApellidoPaterno VARCHAR(50)NOT NULL,
	ApellidoMaterno VARCHAR(50)NOT NULL,
	Sexo CHAR(2),
	FechaNacimiento DATE,
	Correo VARCHAR(100),
	Password VARCHAR(50),
	UserName VARCHAR(50),
	IdRol TINYINT FOREIGN KEY REFERENCES Rol(IdRol)
)

INSERT INTO [Rol]--TABLA 
           ([Nombre])--COLUMNAS 
     VALUES
           ('Administrador'),('Usuario'),('Empleado')--DATOS
GO

INSERT INTO [Usuario]--TABLA 
           ([Nombre]
           ,[ApellidoPaterno]
           ,[ApellidoMaterno]
           ,[Sexo]
           ,[FechaNacimiento]
           ,[Correo]
           ,[Password]
		   ,[Username]
		   ,[IdRol])--COLUMNAS 
     VALUES
           ('Erick','Yañez','Aguilar','M','2000/06/06','erickaguilar2d@gmail.com','123456789','ErickAguilar','1'),
		   ('Grisel','Valencia','Aguilar','F','2003/01/08','griselb@gmail.com','1235478','GriselAguilar','3'),
		   ('Fernando','Perez','Nuñez','M','2000/02/11','fernandon@gmail.com','98564752','FernandoPerez','2')--DATOS
GO

CREATE PROCEDURE UsuarioGetAll
AS
	SELECT Usuario.[IdUsuario]
		  ,Usuario.[Nombre]
		  ,Usuario.[ApellidoPaterno]
		  ,Usuario.[ApellidoMaterno]
		  ,Usuario.[Sexo]
		  ,Usuario.[FechaNacimiento]
		  ,Usuario.[Correo]
		  ,Usuario.[Password]
		  ,Usuario.[Username]
		  ,Usuario.[Idrol]
	  FROM [Usuario]
	  INNER JOIN Rol ON Usuario.IdRol = Rol.IdRol
GO

UsuarioGetAll
GO

CREATE PROCEDURE UsuarioAdd
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@Sexo CHAR(2),
@FechaNacimiento VARCHAR(20),
@Correo VARCHAR(100),
@Password VARCHAR(50),
@UserName VARCHAR(50),
@IdRol TINYINT
AS
	INSERT INTO [Usuario]--TABLA 
           ([Nombre]
           ,[ApellidoPaterno]
           ,[ApellidoMaterno]
           ,[Sexo]
           ,[FechaNacimiento]
           ,[Correo]
           ,[Password]
		   ,[Username]
		   ,[IdRol])--COLUMNAS 
     VALUES
           (@Nombre,
		   @ApellidoPaterno,
		   @ApellidoMaterno,
		   @Sexo,
		   CONVERT(DATE,@FechaNacimiento,105),--dd--MM-yyyy
		   @Correo,
		   @Password,
		   @UserName,
		   @IdRol)--DATOS
GO

UsuarioAdd 'Marcos','Lopez','Vazquez','M','05-12-2000','marcoslop@gmail.com','11487','MarcosLopez','2'