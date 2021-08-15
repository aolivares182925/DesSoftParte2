using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class ConexionSQL
    {
        SqlConnection conn = new SqlConnection("Data Source=tcp:serverproyectotutoria.database.windows.net;Initial Catalog=BD_Tutoria;User ID=admin1;Password=Grupo2DesarrolloSoftware");
        //SqlConnection conn = new SqlConnection("Data Source=LAPTOP-IUT020T4;Initial Catalog=Tutoria;Integrated Security=True");

        public DataTable Select(string consulta)
        {
            DataTable dt = new DataTable();
            conn.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conn);
            adaptador.Fill(dt);
            return dt;
        }
        public SqlConnection GetConeccion()
        {
            return conn;
        }

    }
}
