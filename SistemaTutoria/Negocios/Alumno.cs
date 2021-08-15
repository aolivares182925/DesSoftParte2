using System;
using System.Collections.Generic;
using System.Text;

namespace Negocios
{
    public class Alumno
    {

        public string aCodAlumno;
        public string aAPaterno;
        public string aAMaterno;
        public string aNombres;
        public string aSituacion;
        public string aCodTutor;
        public string aCodEscuela;

        public cDocente(string CodAlumno, string APaterno, string AMaterno, string Nombres,string Situacion,string CodTutor,string CodEscuela)
        
        {
            aCodAlumno=CodAlumno;
            aAPaterno = APaterno;
            aAMaterno = AMaterno;
            aNombres = Nombres;
            aSituacion = Situacion;
            aCodTutor = CodTutor;
            aCodEscuela = CodEscuela;
        }
        public string CodAlumno { get { return aCodAlumno; } set { aCodAlumno = value; } }
        public string APaterno { get { return aAPaterno; } set { aAPaterno = value; } }
        public string AMaterno { get { return aAMaterno; } set { aAMaterno = value; } }
        public string Nombres { get { return aNombres; } set { aNombres = value; } }
        public string Situacion { get { return aSituacion; } set { aSituacion = value; } }
        public string CodTutor { get { return aCodTutor; } set { aCodTutor = value; } }
        public string CodEscuela { get { return aCodEscuela; } set { aCodEscuela = value; } }
    }
}
