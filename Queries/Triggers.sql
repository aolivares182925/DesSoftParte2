--TABLA DE HISTORIAL
use Tutoria 
go

create table Historial
(
	NroOperacion		int identity,
	Editor				varchar(250),
	Fecha				datetime,
	Tabla				varchar(30),
	Operacion			varchar(50),
	TuplaAfectada		char(6)
)


--TRIGGERS
--ALUMNO
--insert alumno
create trigger trHistorialAlumnoInsert
on Alumno for insert
as
declare @cod char(6)
select @cod = CodAlumno from inserted
insert into Historial values(system_user, getdate(), 'Alumno', 'insert', @cod)

--delete alumno
create trigger trHistorialAlumnoDelete
on Alumno for delete
as
declare @cod char(6)
select @cod = CodAlumno from deleted
insert into Historial values(system_user, getdate(), 'Alumno', 'delete', @cod)

--update alumno
create trigger trHistorialAlumnoUpdate
on Alumno for update
as
declare @cod char(6)
select @cod = CodAlumno from inserted
insert into Historial values(system_user, getdate(), 'Alumno', 'update', @cod)

--TUTOR
--insert tutor
create trigger trHistorialTutorInsert
on Tutor for insert
as
declare @cod char(6)
select @cod = CodTutor from inserted
insert into Historial values(system_user, getdate(), 'Tutor', 'insert', @cod)

--delete tutor
create trigger trHistorialTutorDelete
on Tutor for delete
as
declare @cod char(6)
select @cod = CodTutor from deleted
insert into Historial values(system_user, getdate(), 'Tutor', 'delete', @cod)

--update tutor
create trigger trHistorialTutorUpdate
on Tutor for update
as
declare @cod char(6)
select @cod = CodTutor from INSERTED
insert into Historial values(system_user, getdate(), 'Tutor', 'update', @cod)

--FICHA TUTORIA
--insert ficha tutoria
create trigger trHistorialFichaTutInsert
on FichaTutoria for insert
as
declare @cod int
select @cod = CodFichaTutoria from inserted
insert into Historial values(system_user, getdate(), 'FichaTutoria', 'insert', @cod)

--delete ficha tutoria
create trigger trHistorialFichaTutDelete
on FichaTutoria for delete
as
declare @cod int
select @cod = CodFichaTutoria from deleted
insert into Historial values(system_user, getdate(), 'FichaTutoria', 'delete', @cod)

--update ficha tutoria
create trigger trHistorialFichaTutUpdate
on FichaTutoria for update
as
declare @cod int
select @cod = CodFichaTutoria from INSERTED
insert into Historial values(system_user, getdate(), 'FichaTutoria', 'update', @cod)

--FICHA SESIÓN
--insert ficha sesion
create trigger trHistorialFichaSesInsert
on FichaSesion for insert
as
declare @cod int
select @cod = CodFichaTutoria from inserted
insert into Historial values(system_user, getdate(), 'FichaSesion', 'insert', @cod)

--delete ficha sesion
create trigger trHistorialFichaSesDelete
on FichaSesion for delete
as
declare @cod int
select @cod = CodFichaTutoria from deleted
insert into Historial values(system_user, getdate(), 'FichaSesion', 'delete', @cod)

--update ficha sesion
create trigger trHistorialFichaSesUpdate
on FichaSesion for update
as
declare @cod int
select @cod = CodFichaTutoria from INSERTED
insert into Historial values(system_user, getdate(), 'FichaSesion', 'update', @cod)