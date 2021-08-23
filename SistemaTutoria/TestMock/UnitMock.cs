using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Negocios;
using System.Data;
using SistemaTutoria;

namespace TestMock
{
    [TestClass]
    public class UnitMock
    {
        [TestMethod]
        public void TestMockIngresoLoginCorrecto()
        {

            Mock<ConectarSQL> Conectar = new Mock<ConectarSQL>();

            //variables
            string usuario = "Admin1";
            string clave = "contrasenia1";

            int Expected = 1;

            //Indicamos el resultado del objeto, Que retorne una fila
            Conectar.Setup(a => a.ContarSeleccionAdministrador(It.IsAny<string>(), It.IsAny<string>())).Returns(1);
            //Para obtener el resultado usamos .Object y lo almacenamos

            int actual = Conectar.Object.ContarSeleccionAdministrador(usuario, clave);
            //Funcion Assert verifica si los resultados son iguales
            Assert.AreEqual(actual, Expected);
        }

        [TestMethod]
        public void TestMockAgregarAlumnoCorrecto()
        {
            Mock<ConectarSQL> Alumno = new Mock<ConectarSQL>();

            //variables de prueba
            string CodAlumno = "666666";
            string Nombres = "SOYLA";
            string APaterno = "BACA";
            string AMaterno = "DEL CAMPO";
            string Situacion = "EN RIESGO";
            string CodTutor = "004";
            string CodEscuela = "IN";


            bool Expected = true;

            //Indicamos el resultado del objeto, Que retorne una fila
            Alumno.Setup(a => a.AgregarAlumnoSiPosible(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            //Alumno.Setup(a => a.Agregar(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), 
            //    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            //Para obtener el resultado usamos .Object y lo almacenamos

            bool actual = Alumno.Object.AgregarAlumnoSiPosible(CodAlumno, APaterno, AMaterno, Nombres, Situacion, CodTutor,
                CodEscuela);
            //Funcion Assert verifica si los resultados son iguales
            Assert.AreEqual(actual, Expected);

        }

        [TestMethod]
        public void TestMockAgregarAlumnoIncorrecto()
        {
            Mock<ConectarSQL> Alumno = new Mock<ConectarSQL>();

            //variables de prueba
            string CodAlumno = "666666";
            string Nombres = "SOYLA";
            string APaterno = ""; // variable faltante
            string AMaterno = "DEL CAMPO";
            string Situacion = "EN RIESGO";
            string CodTutor = "004";
            string CodEscuela = "IN";

            bool Expected = false;

            //Indicamos el resultado del objeto, Que retorne una fila
            Alumno.Setup(a => a.AgregarAlumnoSiPosible(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            //Alumno.Setup(a => a.Agregar(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), 
            //    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            //Para obtener el resultado usamos .Object y lo almacenamos

            bool actual = Alumno.Object.AgregarAlumnoSiPosible(CodAlumno, APaterno, AMaterno, Nombres, Situacion, CodTutor,
                CodEscuela);
            //Funcion Assert verifica si los resultados son iguales
            Assert.AreEqual(actual, Expected);
        }
        public void Test_Buscar_Alumno_Valido()
        {

            Mock<ConectarSQL> Conectar = new Mock<ConectarSQL>();
            //variables
            string categoria = "Codigo";
            string buscar = "182905";

            int Expected = 1;

            //Indicamos el resultado del objeto, Que retorne una fila
            Conectar.Setup(a => a.TestBuscarAlumno(It.IsAny<string>(), It.IsAny<string>())).Returns(1);
            //Para obtener el resultado usamos .Object y lo almacenamos

            int actual = Conectar.Object.TestBuscarAlumno(categoria, buscar);
            //Funcion Assert verifica si los resultados son iguales
            Assert.AreEqual(actual, Expected);
        }
        [TestMethod]
        public void Test_Buscar_Alumno_Invalido()
        {

            Mock<ConectarSQL> Conectar = new Mock<ConectarSQL>();
            //variables
            string categoria = "Codigo";
            string buscar = "jhon";

            int Expected = 0;

            //Indicamos el resultado del objeto, Que retorne una fila
            Conectar.Setup(a => a.TestBuscarAlumno(It.IsAny<string>(), It.IsAny<string>())).Returns(1);
            //Para obtener el resultado usamos .Object y lo almacenamos

            int actual = Conectar.Object.TestBuscarAlumno(categoria, buscar);
            //Funcion Assert verifica si los resultados son iguales
            Assert.AreEqual(actual, Expected);
        }
        [TestMethod]
        public void Test_Buscar_Alumno_Invalido1()
        {

            Mock<ConectarSQL> Conectar = new Mock<ConectarSQL>();
            //variables
            string categoria = "Codigo";
            string buscar = "";

            int Expected = 0;

            //Indicamos el resultado del objeto, Que retorne una fila
            Conectar.Setup(a => a.TestBuscarAlumno(It.IsAny<string>(), It.IsAny<string>())).Returns(1);
            //Para obtener el resultado usamos .Object y lo almacenamos

            int actual = Conectar.Object.TestBuscarAlumno(categoria, buscar);
            //Funcion Assert verifica si los resultados son iguales
            Assert.AreEqual(actual, Expected);
        }
        [TestMethod]
        public void TestMockSeleccionarAlumnos()
        {

            Mock<ConectarSQL> Conectar = new Mock<ConectarSQL>();

            //variable
            int Expected = 1;

            //Indicamos el resultado del objeto, Que retorne una fila
            Conectar.Setup(a => a.SeleccionAlumnos()).Returns(1);
            //Para obtener el resultado usamos .Object y lo almacenamos

            int actual = Conectar.Object.SeleccionAlumnos();
            //Funcion Assert verifica si los resultados son iguales
            Assert.AreEqual(actual, Expected);

        }

    }
}
