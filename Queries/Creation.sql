use master
go
----drop database Tutoria
create database Tutoria
go

use Tutoria
go

--Tabla de tutor
create table Tutor
(
	CodTutor		char(3),
	APaterno		varchar(50),
	AMaterno		varchar(50),
	Nombres			varchar(30),
	Estado			varchar(40) check (Estado in('Contratado','Nombrado')),
	primary key (CodTutor)
)

--Tabla de escuela profesional
create table EscuelaProfesional
(
	CodEscuela		varchar(5),
	Nombre			varchar(50),
	primary key(CodEscuela)
)

--Tabla de alumnos
create table Alumno
(
	CodAlumno		char(6),
	APaterno		varchar(50),
	AMaterno		varchar(50),
	Nombres			varchar(30),
	Situacion		varchar(50) check (Situacion in('Riesgo', 'No riesgo')),
	CodTutor		char(3),
	CodEscuela		varchar(5),
	primary key (CodAlumno),
	foreign key (CodTutor) references Tutor(CodTutor),
	foreign key ( CodEscuela) references EscuelaProfesional(CodEscuela)
)

--Tabla de Administrador
create table Administrador
(
	Usuario			varchar(6),
	APaterno		varchar(50),
	AMaterno		varchar(50),
	Nombre			varchar(30),
	Categoria		varchar(30),
	Contraseña		varbinary(20) 
)

--Ficha de tutoria
create table FichaTutoria
(
	CodTutor			char(3),
	CodAlumno			char(6),
	CodFichaTutoria		int identity (1,1),
	primary key (CodFichaTutoria),
	foreign key (CodTutor) references Tutor(CodTutor),
	foreign key ( CodAlumno) references Alumno(CodAlumno)
)

create table FichaSesion
(
	CodFichaTutoria		int,
	NroSesion			int,
	FechaHora			date ,
	Tipo				varchar(30),
	Completado			int,
	Descripcion			varchar(400), 
	Referencia			varchar(400), 
	Observaciones		varchar(400),
	foreign key(CodFichaTutoria) references FichaTutoria(CodFichaTutoria)

)


--Datos de administrador
insert into Administrador values('Admin1', 'Apellido1','Apellido1','Nombre1','administrador', convert (varbinary,'contrasenia1'))
insert into Administrador values('Admin2', 'Apellido2','Apellido2','Nombre2', 'administrador',convert (varbinary,'contrasenia2'))



--Usar esta consulta para ver las contraseñas
select * from Administrador







