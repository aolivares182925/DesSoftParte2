using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    class cDocente
    {
        #region Atributos
        private string aCodigo;
        private string aNombres;
        private string aApPaterno;
        private string aApMaterno;
        private string aEstado;
        #endregion

        #region Metodos
        // -------- CONSTRUCTOR ----------------
        public cDocente(string Codigo, string Nombres, string ApPaterno, string ApMaterno, 
            string Estado)
        {
            aCodigo = Codigo;
            aNombres = Nombres;
            aApPaterno = ApPaterno;
            aApMaterno = ApMaterno;
            aEstado = Estado;
        }
        // ------------ PROPIEDADES ---------------
        public string Codigo{ get { return aCodigo; } set { aCodigo = value; } }
        public string Nombres { get { return aNombres; }  set{ aNombres = value; } } 
        public string ApPaterno { get { return aApPaterno; } set { aApPaterno = value;  } }
        public string ApMaterno { get { return aApMaterno; } set { aApMaterno = value;  } }
        public string Estado { get { return aEstado; } set { aEstado = value; } }
        #endregion
    }
}
