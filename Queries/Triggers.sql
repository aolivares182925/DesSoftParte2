--TABLA DE HISTORIAL
use master
go
use Tutoria 
go

--TRIGGERS
--ALUMNO
--insert alumno
create trigger trHistorialAlumnoInsert
on Alumno for insert
as
declare @cod char(6)
select @cod = CodAlumno from inserted
insert into Historial values(system_user, getdate(), 'Alumno', 'insert', @cod)
go

--delete alumno
create trigger trHistorialAlumnoDelete
on Alumno for delete
as
declare @cod char(6)
select @cod = CodAlumno from deleted
insert into Historial values(system_user, getdate(), 'Alumno', 'delete', @cod)
go

--update alumno
create trigger trHistorialAlumnoUpdate
on Alumno for update
as
declare @cod char(6)
select @cod = CodAlumno from inserted
insert into Historial values(system_user, getdate(), 'Alumno', 'update', @cod)
go
--TUTOR
--insert tutor
create trigger trHistorialTutorInsert
on Tutor for insert
as
declare @cod char(6)
select @cod = CodTutor from inserted
insert into Historial values(system_user, getdate(), 'Tutor', 'insert', @cod)
go
--delete tutor
create trigger trHistorialTutorDelete
on Tutor for delete
as
declare @cod char(6)
select @cod = CodTutor from deleted
insert into Historial values(system_user, getdate(), 'Tutor', 'delete', @cod)
go
--drop trigger trHistorialTutorUpdate
--update tutor
create trigger trHistorialTutorUpdate
on Tutor for update
as
declare @cod char(6)
select @cod = CodTutor from INSERTED
insert into Historial values(system_user, getdate(), 'Tutor', 'update', @cod)
go
--FICHA TUTORIA
--insert ficha tutoria
create trigger trHistorialFichaTutInsert
on FichaTutoria for insert
as
declare @cod int
select @cod = CodFichaTutoria from inserted
insert into Historial values(system_user, getdate(), 'FichaTutoria', 'insert', @cod)
go
--delete ficha tutoria
create trigger trHistorialFichaTutDelete
on FichaTutoria for delete
as
declare @cod int
select @cod = CodFichaTutoria from deleted
insert into Historial values(system_user, getdate(), 'FichaTutoria', 'delete', @cod)
go
--update ficha tutoria
create trigger trHistorialFichaTutUpdate
on FichaTutoria for update
as
declare @cod int
select @cod = CodFichaTutoria from INSERTED
insert into Historial values(system_user, getdate(), 'FichaTutoria', 'update', @cod)
go
--FICHA SESIÓN
--insert ficha sesion
create trigger trHistorialFichaSesInsert
on FichaSesion for insert
as
declare @cod int
select @cod = CodFichaTutoria from inserted
insert into Historial values(system_user, getdate(), 'FichaSesion', 'insert', @cod)
go
--delete ficha sesion
create trigger trHistorialFichaSesDelete
on FichaSesion for delete
as
declare @cod int
select @cod = CodFichaTutoria from deleted
insert into Historial values(system_user, getdate(), 'FichaSesion', 'delete', @cod)
go
--update ficha sesion
create trigger trHistorialFichaSesUpdate
on FichaSesion for update
as
declare @cod int
select @cod = CodFichaTutoria from INSERTED
insert into Historial values(system_user, getdate(), 'FichaSesion', 'update', @cod)
go