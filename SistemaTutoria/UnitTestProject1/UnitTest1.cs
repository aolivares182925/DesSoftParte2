using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using Datos;
using System.Collections.Generic;
using System.Windows;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
          //prueba unitaria para el ingreso de un usuario con su respectiva clave.
            //arange 
            string usuario = "Admin1";
            string clave = "contrasenia1";
            //haciendo una referencia
            Negocios.ConectarSQL n = new Negocios.ConectarSQL();
            DataTable dt = new DataTable();// n.BuscarAdministrador(usuario,clave)
            int resultadoesperado = 1;// el resultado que se espera
            //Act(empezamos con la prueba
            int i = n.BuscarAdministrador(usuario,clave).Rows.Count;
            //assert
            Assert.AreEqual(i, resultadoesperado);
        }
        [TestMethod]
        public void TestMethod2()
        {
            //prueba unitaria para el ingreso de un usuario con su respectiva clave, pero dicho usuario 
            //existe pero la contrasenia es incorrecta
            //arange 
            string usuario = "Admin2";
            string clave = "contrasenia1";
            //haciendo una referencia
            Negocios.ConectarSQL n = new Negocios.ConectarSQL();
            DataTable dt = new DataTable();// n.BuscarAdministrador(usuario,clave)
            int resultadoesperado = 0;
            //Act
            int i = n.BuscarAdministrador(usuario, clave).Rows.Count;
            //assert
            Assert.AreEqual(i, resultadoesperado);
        }
        [TestMethod]
        public void TestMethod3()
        {
            //prueba unitaria para el ingreso de un usuario que no existe
            //arange 
            string usuario = "Admin3";
            string clave = "contrasenia";
            //haciendo una referencia
            Negocios.ConectarSQL n = new Negocios.ConectarSQL();
            int resultadoesperado = 0;
            //Act
            int i = n.BuscarAdministrador(usuario, clave).Rows.Count;
            //assert
            Assert.AreEqual(i, resultadoesperado);
        }

        [TestMethod]
        public void TestMethod4()
        {
            //prueba unitaria para el ingreso una cadena vacia en usuario, pero con una clave
            //arange 
            string usuario = "";
            string clave = "contrasenia";
            //haciendo una referencia
            Negocios.ConectarSQL n = new Negocios.ConectarSQL();
            int resultadoesperado = 0;
            //Act
            int i = n.BuscarAdministrador(usuario, clave).Rows.Count;
            //assert
            Assert.AreEqual(i, resultadoesperado);
        }

        [TestMethod]
        public void TestMethod5()
        {
            //prueba unitaria para el ingreso de un usuario que si existe, pero que no ingreso
            //clave
            //arange 
            string usuario = "Admin1 ";
            string clave = " ";
            //haciendo una referencia
            Negocios.ConectarSQL n = new Negocios.ConectarSQL();
            int resultadoesperado = 0;
            //Act
            int i = n.BuscarAdministrador(usuario, clave).Rows.Count;
            //assert
            Assert.AreEqual(i, resultadoesperado);
        }

        [TestMethod]
        public void TestMethod6()
        {
            //prueba unitaria para el ingreso de cadenas vacias tanto en usuario como clave
            //arange 
            string usuario = "  ";
            string clave = "  ";
            //haciendo una referencia
            Negocios.ConectarSQL n = new Negocios.ConectarSQL();
            int resultadoesperado = 0;
            //Act
            int i = n.BuscarAdministrador(usuario, clave).Rows.Count;
            //assert
            Assert.AreEqual(i, resultadoesperado);
        }

    }
}

