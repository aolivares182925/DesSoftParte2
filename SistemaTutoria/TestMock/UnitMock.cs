using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Negocios;
using System.Data;

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
    }
}
