using System;
using Negocios;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaTutoria
{
    public partial class Agregar_SemestreUserControl : UserControl
    {
        private static Agregar_SemestreUserControl _instance;

        string SemestreActual; 
        public static Agregar_SemestreUserControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Agregar_SemestreUserControl();
                }
                return _instance;
            }
        }
        public Agregar_SemestreUserControl()
        {
            ConectarSQL conn = new ConectarSQL();
            
            DataTable Semestres = conn.SemestreActual();
            int Nr = Semestres.Rows.Count;
            SemestreActual = Semestres.Rows[Nr - 1][0].ToString();
            InitializeComponent();
            txtSemestreActual.Text = SemestreActual;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text.Trim() == "") || (textBox1.Text.Length > 7) || (textBox1.Text.Length < 6))
            {
                MessageBox.Show(" Ingrese el Semestre con el formato indicado.");
            }
            else
            {
                bool existe = false;

                ConectarSQL conn = new ConectarSQL();
                DataTable Semestres = conn.SemestreActual();
                int Nr = Semestres.Rows.Count;
                for (int i = 0; i < Nr; i++)
                {
                    if (SemestreActual == Semestres.Rows[i][0].ToString())
                        existe = true;
                    break;
                }
                if ((SemestreActual == textBox1.Text) || (!existe))
                {
                    MessageBox.Show("El semestre ya existe , ingrese Semestre valido");
                }
                else
                {
                    SemestreActual = textBox1.Text;
                    DataTable Alumnos = conn.SelectTodosAlumnosParaTutor();
                    int Nro_Alumnos = Alumnos.Rows.Count;
                    string CodAlumno;
                    string CodTutor;
                    for (int i = 0; i < Nro_Alumnos; i++)
                    {
                        CodAlumno = Alumnos.Rows[i][0].ToString();
                        CodTutor = Alumnos.Rows[i][5].ToString();
                        conn.AgregarFicha(CodTutor, CodAlumno, SemestreActual);
                    }

                    MessageBox.Show("Semestre agregado correctamente.");
                }
                
            }
           
        }
    }
}
