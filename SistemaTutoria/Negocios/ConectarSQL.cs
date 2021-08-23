using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Datos;

namespace Negocios
{
    public class ConectarSQL
    {
        ConexionSQL conn = new ConexionSQL();
        public DataTable SelectAlumnos()
        {
            string consulta = "Select * from Alumno";
            return conn.Select(consulta);
        }
        public virtual int SeleccionAlumnos()
        {
            DataTable dt = SelectAlumnos();
            int A = dt.Rows.Count;
            return A;
        }
        public DataTable SelectTutores()
        {
            string consulta = "Select * from Tutor";
            return conn.Select(consulta);
        }
        public DataTable BuscarTutor(string categoria, string buscar)
        {
            string consulta = "select * from Tutor where " + categoria + " like '" + buscar + "%'";
            return conn.Select(consulta);
        }
        public DataTable BuscarAlumno(string categoria, string buscar)
        {
            string consulta = "select * from Alumno where " + categoria + " like '" + buscar + "%'";
            return conn.Select(consulta);
        }
        public virtual int TestBuscarAlumno(string categoria, string buscar)
        {
            DataTable dt = BuscarAlumno(categoria, buscar);
            int R = dt.Rows.Count;
            return R;
        }

        public DataTable BuscarAdministrador(string usuario, string contraseña)
        {
            string consulta = "select * from Administrador where Usuario ='" + usuario + "'and Contraseña ='" + contraseña + "'";
            return conn.Select(consulta);
        }
        public virtual int ContarSeleccionAdministrador(string usuario, string contraseña)
        {
            DataTable dt = BuscarAdministrador(usuario, contraseña);
            int R = dt.Rows.Count;
            return R;
        }
        public void EliminarAlumno(string CodAlumno)
        {
            string consulta = "DELETE FROM Alumno WHERE CodAlumno = @CodAlumno";

            SqlCommand cmd = new SqlCommand(consulta, conn.GetConeccion());
            conn.GetConeccion().Open();
            cmd.Parameters.AddWithValue("@CodAlumno", CodAlumno);
            cmd.ExecuteNonQuery();
            conn.GetConeccion().Close();
        }
        public virtual bool EliminarAlumnoCorrectamente(string CodAlumno)
        {
            bool correctamente = true;
            correctamente = (CodAlumno == "") ? false : true;
            if (correctamente)
            {
                EliminarAlumno(CodAlumno);
            }

            return correctamente;
        }

        public void AgregarAlumno(string CodAlumno, string APaterno, string AMaterno, string Nombres,
            string Situacion, string CodTutor, string CodEscuela)
        {
            string consulta = "insert into Alumno values ('" + CodAlumno + "','" + APaterno + "','" + AMaterno + "','" + Nombres + "','" +
                Situacion + "','" + CodTutor + "','" + CodEscuela + "')";
            SqlCommand cmd = new SqlCommand(consulta, conn.GetConeccion());

            conn.GetConeccion().Open();
            cmd.ExecuteNonQuery();
            conn.GetConeccion().Close();
        }
        public virtual bool AgregarAlumnoSiPosible(string CodAlumno, string APaterno, string AMaterno, string Nombres,
            string Situacion, string CodTutor, string CodEscuela)
        {
            bool posible = true;

            posible = (CodAlumno == "" || APaterno == "" || AMaterno == "" || Nombres == "" || Situacion == "" ||
                CodTutor == "" || CodEscuela == "") ? false :true;

            if (posible)
            {
                AgregarAlumno(CodAlumno, APaterno, AMaterno, Nombres,Situacion, CodTutor, CodEscuela);
            }
            
            return posible;
        }

        public void EditarAlumno(string CodAlumno, string APaterno, string AMaterno, string Nombres,
            string Situacion, string CodTutor, string CodEscuela)
        {

            SqlCommand cmd = new SqlCommand("ModificarAlumno", conn.GetConeccion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodAlumno", CodAlumno);
            cmd.Parameters.AddWithValue("@APaterno", APaterno);
            cmd.Parameters.AddWithValue("@AMaterno", AMaterno);
            cmd.Parameters.AddWithValue("@Nombres", Nombres);
            cmd.Parameters.AddWithValue("@Situacion", Situacion);
            cmd.Parameters.AddWithValue("@CodTutor", CodTutor);
            cmd.Parameters.AddWithValue("@CodEscuela", CodEscuela);

            conn.GetConeccion().Open();
            cmd.ExecuteNonQuery();
            conn.GetConeccion().Close();
        }

        public virtual bool EditarAlumnoSiEsPosible(string CodAlumno, string APaterno, string AMaterno, string Nombres,
            string Situacion, string CodTutor, string CodEscuela)
        {
            bool posible = true;

            posible = (CodAlumno == "" || APaterno == "" || AMaterno == "" || Nombres == "" || Situacion == "" ||
                CodTutor == "" || CodEscuela == "") ? false : true;

            if (posible)
            {
                EditarAlumno(CodAlumno, APaterno, AMaterno, Nombres, Situacion, CodTutor, CodEscuela);
            }

            return posible;
        }



        public void EliminarTutor(string CodTutor)
        {
            string consulta = "DELETE FROM Tutor WHERE CodTutor = @CodTutor";

            SqlCommand cmd = new SqlCommand(consulta, conn.GetConeccion());
            conn.GetConeccion().Open();
            cmd.Parameters.AddWithValue("@CodTutor", CodTutor);
            cmd.ExecuteNonQuery();
            conn.GetConeccion().Close();
        }

        public void AgregarTutor(string CodTutor, string APaterno, string AMaterno, string Nombres,string Estado)
        {
            string consulta = "insert into Tutor values ('" + CodTutor + "','" + APaterno + "','" + AMaterno + "','" + Nombres + "','" +
                Estado + "')";
            SqlCommand cmd = new SqlCommand(consulta, conn.GetConeccion());

            conn.GetConeccion().Open();
            cmd.ExecuteNonQuery();
            conn.GetConeccion().Close();
        }

        public void EditarTutor(string CodTutor, string APaterno, string AMaterno, string Nombres, string Estado)
        {

            SqlCommand cmd = new SqlCommand("ModificarTutor", conn.GetConeccion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodTutor", CodTutor);
            cmd.Parameters.AddWithValue("@APaterno", APaterno);
            cmd.Parameters.AddWithValue("@AMaterno", AMaterno);
            cmd.Parameters.AddWithValue("@Nombres", Nombres);
            cmd.Parameters.AddWithValue("@Estado", Estado);

            conn.GetConeccion().Open();
            cmd.ExecuteNonQuery();
            conn.GetConeccion().Close();
        }
    }
}
