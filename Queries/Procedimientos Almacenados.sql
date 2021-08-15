
use BD_Tutoria
go

create proc ModificarAlumno
@CodAlumno varchar(15),
@APaterno varchar(50),
@AMaterno varchar(50),
@Nombres varchar(30),
@Situacion varchar(50),
@CodTutor char(3),
@CodEscuela varchar(5)
as
update Alumno set CodAlumno = @CodAlumno, 
					APaterno = @APaterno,
					AMaterno = @AMaterno,
					Nombres = @Nombres,
					Situacion = @Situacion,
					CodTutor = @CodTutor,
					CodEscuela = @CodEscuela
where CodAlumno = @CodAlumno


---
create proc ModificarTutor
@CodTutor char(3),
@APaterno varchar(50),
@AMaterno varchar(50),
@Nombres varchar(30),
@Estado varchar(40)
as
update Tutor set CodTutor = @CodTutor, 
					APaterno = @APaterno,
					AMaterno = @AMaterno,
					Nombres = @Nombres,
					Estado = @Estado
where Codtutor = @CodTutor