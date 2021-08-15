use Tutoria
go

--PROCEDIMIENTO PARA INSERTAR ,MODIFICAR Y ELIMINAT
CREATE PROCEDURE PRO_Alumno
    @CodAlumno		char(6),
	@APaterno		varchar(50)=NULL,
	@AMaterno		varchar(50)=NULL,
	@Nombres		varchar(30)=NULL,
	@Situacion		varchar(50)=NULL,
	@CodTutor		int =NULL,
	@CodEscuela		varchar(5)=NULL,
	@MODO CHAR(1)
AS
    IF @MODO='I'
	BEGIN
	    INSERT Alumno VALUES(@CodAlumno,@APaterno,@AMaterno,@Nombres,@Situacion,@CodTutor,@CodEscuela)
	END
	IF @MODO='U'
	BEGIN
	    UPDATE Alumno SET APaterno=@APaterno,AMaterno=@AMaterno,Nombres=@Nombres,Situacion=@Situacion,CodTutor=@CodTutor,CodEscuela=@CodEscuela WHERE CodAlumno=@CodAlumno
	END
	IF @MODO='D'
	BEGIN
	    DELETE FROM Alumno WHERE CodAlumno=@CodAlumno
	END;
	GO
	EXECUTE PRO_Alumno @MODO='I',@CodAlumno='',@APaterno='',@AMaterno='',@Nombres='',@Situacion='',@CodTutor='',@CodEscuela=''







