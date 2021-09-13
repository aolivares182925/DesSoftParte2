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
        public DataTable SelectAlumnosDeTutor(string CodTutor)
        {
            string consulta = "Select * from Alumno where CodTutor = " + CodTutor;
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
            string consulta = "select CodTutor, APaterno, AMaterno, Nombres, Estado from Tutor";
            return conn.Select(consulta);
        }
        public DataTable SelectTutorCodigo(string CodTutor)
        {
            string consulta = "select CodTutor, APaterno, AMaterno, Nombres, Estado,Contraseña = CAST(Contraseña as varchar(20)) from Tutor where CodTutor = '"+ 
                CodTutor + "'";
            return conn.Select(consulta);
        }
        public DataTable BuscarTutor(string categoria, string buscar)
        {
            string consulta = "select CodTutor, APaterno, AMaterno, Nombres, Estado from Tutor where " + categoria + " like '" + buscar + "%'";
            return conn.Select(consulta);
        }
        public DataTable BuscarAlumno(string categoria, string buscar)
        {
            string consulta = "select * from Alumno where " + categoria + " like '" + buscar + "%'";
            return conn.Select(consulta);
        }
        public DataTable BuscarAlumnoDeTutor(string categoria, string buscar,string CodTutor)
        {
            string consulta = "select * from Alumno where  CodTutor = '"+ CodTutor +"' and " + categoria + " like '" + buscar + "%'";
            return conn.Select(consulta);
        }
        public virtual int TestBuscarAlumno(string categoria, string buscar)
        {
            DataTable dt = BuscarAlumno(categoria, buscar);
            int R = dt.Rows.Count;
            return R;
        }

        public DataTable BuscarAdministrador(string usuario, string contra)
        {
            string consulta = "select * from Administrador where Usuario ='" + usuario +
                "'and Contraseña = convert(varbinary,'" + contra + "')";
            return conn.Select(consulta);
        }

        public DataTable BuscarTutorLogin(string usuario, string contra)
        {
            string consulta = "select * from Tutor where " +
                "CodTutor ='" + usuario + "'and Contraseña = convert(varbinary,'" + contra + "')";
            return conn.Select(consulta);
        }

        public DataTable SelectAlumno(string CodAlumno)
        {
            string consulta = "select * from Alumno where CodAlumno = '" + CodAlumno + "'";
            return conn.Select(consulta);
        }

        public DataTable SelectFichaSesionAlumno(string CodAlumno)
        {
            string consulta = "select NroSesion, FechaHora, Tipo, Descripcion," +
                "Referencia,Observaciones from FichaTutoria as FT inner join FichaSesion" +
                " as FS on(FT.CodFichaTutoria = FS.CodFichaTutoria) where CodAlumno = '" + CodAlumno + "'";
            return conn.Select(consulta);
        }

        public int Cod_Ficha_Tutoria(string CodAlumno)
        {
            string consulta = "select CodFichaTutoria from FichaTutoria where " + 
                "CodAlumno = '" + CodAlumno + "'";
            DataTable Dt = conn.Select(consulta);
            if (Dt.Rows.Count == 0)
                return 0;
            else
                return Int32.Parse(Dt.Rows[0][0].ToString());

        }

        public void AgregarFicha(string Cod_Tutor, string CodAlumno)
        {
            string consulta = "insert into FichaTutoria values ('" + Cod_Tutor + "','" + CodAlumno + "')";
            SqlCommand cmd = new SqlCommand(consulta, conn.GetConeccion());
            conn.GetConeccion().Open();
            cmd.ExecuteNonQuery();
            conn.GetConeccion().Close();
        }

        public void AgregarSesion(string CodFichaTutoria, string NroSesion, string date, string Tipo, string Completado,
            string Descripcion, string Referencia, string Observaciones)
        {
            string consulta = "insert into FichaSesion values (" + CodFichaTutoria + "," + NroSesion + ",'" + date + "','" + Tipo + "'," +
                Completado + ",'" + Descripcion + "','" + Referencia + "','" + Observaciones + "')";
            SqlCommand cmd = new SqlCommand(consulta, conn.GetConeccion());

            conn.GetConeccion().Open();
            cmd.ExecuteNonQuery();
            conn.GetConeccion().Close();
        }
        public void EditarFichaSesion(int CodFichaTutoria, int NroSesion, string FechaHora, string Tipo,
            int Completado,string Descripcion, string Referencia, string Observaciones)
        {

            SqlCommand cmd = new SqlCommand("ModificarFichaSesion", conn.GetConeccion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodFichaTutoria", CodFichaTutoria);
            cmd.Parameters.AddWithValue("@NroSesion", NroSesion);
            cmd.Parameters.AddWithValue("@FechaHora", FechaHora);
            cmd.Parameters.AddWithValue("@Tipo", Tipo);
            cmd.Parameters.AddWithValue("@Completado", Completado);
            cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
            cmd.Parameters.AddWithValue("@Referencia", Referencia);
            cmd.Parameters.AddWithValue("@Observaciones", Observaciones);

            conn.GetConeccion().Open();
            cmd.ExecuteNonQuery();
            conn.GetConeccion().Close();
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
        public void EditarContraseñaTutor(string CodTutor, string Contraseña)
        {
            SqlCommand cmd = new SqlCommand("ModificarContraseñaTutor", conn.GetConeccion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodTutor", CodTutor);
            cmd.Parameters.AddWithValue("@Contraseña", Contraseña);

            conn.GetConeccion().Open();
            cmd.ExecuteNonQuery();
            conn.GetConeccion().Close();
        }
    }
}
