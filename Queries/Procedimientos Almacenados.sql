use master
go
use Tutoria
go

create proc ModificarAlumno
@CodAlumno varchar(15),
@APaterno varchar(50),
@AMaterno varchar(50),
@Nombres varchar(30),
@Situacion varchar(50),
@CodTutor char(3),
@CodEscuela varchar(5),
@Activo int
as
update Alumno set CodAlumno = @CodAlumno, 
					APaterno = @APaterno,
					AMaterno = @AMaterno,
					Nombres = @Nombres,
					Situacion = @Situacion,
					CodTutor = @CodTutor,
					CodEscuela = @CodEscuela,
					Activo = @Activo
where CodAlumno = @CodAlumno
go

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
go

---
create proc ModificarContraseñaTutor
@CodTutor char(3),
@Contraseña varchar(20)
as
update Tutor set Contraseña = convert (varbinary,@Contraseña)
where Codtutor = @CodTutor
go

---
create proc ModificarFichaSesion
@CodFichaTutoria	int,
@NroSesion			int,
@FechaHora			date ,
@Tipo				varchar(30),
@Completado			int,
@Descripcion		varchar(400), 
@Referencia			varchar(400), 
@Observaciones		varchar(400)
as
update FichaSesion set CodFichaTutoria = @CodFichaTutoria, 
					NroSesion = @NroSesion,
					FechaHora = @FechaHora,
					Tipo = @Tipo,
					Completado = @Completado,
					Descripcion = @Descripcion,
					Referencia = @Referencia,
					Observaciones = @Observaciones
where CodFichaTutoria = @CodFichaTutoria and NroSesion = @NroSesion
go
--- cambiar contraseña administrador
create proc ModificarContraseñaAdministrador
@Usuario char(6),
@Contraseña varchar(20)
as
update Administrador set Contraseña = convert (varbinary,@Contraseña)
where Usuario = @Usuario
go
