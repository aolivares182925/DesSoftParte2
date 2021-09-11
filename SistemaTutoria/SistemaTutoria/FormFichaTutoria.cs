using Negocios;
using System;
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
    public partial class FormFichaTutoria : Form
    {
        public FormFichaTutoria(string CodAlumno, string CodTutor)
        {
            InitializeComponent();
            ConectarSQL conn = new ConectarSQL();
            DataTable Dt = conn.SelectAlumno(CodAlumno);
            tbCodigo.Text = Dt.Rows[0][0].ToString();
            tbApPaterno.Text = Dt.Rows[0][1].ToString();
            tbApMaterno.Text = Dt.Rows[0][2].ToString();
            tbNombres.Text = Dt.Rows[0][3].ToString();
            tbSituacion.Text = Dt.Rows[0][4].ToString();
            tbCodEscuela.Text = Dt.Rows[0][6].ToString();

            DataTable Dt_Sesion = conn.SelectFichaSesionAlumno(CodAlumno);
            int Nro_Sesiones = Dt_Sesion.Rows.Count;
            if (Nro_Sesiones != 0)
            {
                for (int i = 0; i < Nro_Sesiones; i++)
                {
                    int Nro_sesion = Int32.Parse(Dt_Sesion.Rows[i][0].ToString());

                    switch (Nro_sesion)
                    {
                        case 1:
                            cbTipo1.SelectedItem = Dt_Sesion.Rows[i][3].ToString();
                            txtDescripcion1.Text = Dt_Sesion.Rows[i][3].ToString();
                            txtReferencia1.Text = Dt_Sesion.Rows[i][3].ToString();
                            txtObservaciones1.Text = Dt_Sesion.Rows[i][3].ToString();
                            txtDescripcion1.Enabled = false;
                            txtReferencia1.Enabled = false;
                            txtObservaciones1.Enabled = false;
                            break;

                        case 2:
                            txtDescripcion2.Text = Dt_Sesion.Rows[i][3].ToString();
                            txtReferencia2.Text = Dt_Sesion.Rows[i][3].ToString();
                            txtObservaciones2.Text = Dt_Sesion.Rows[i][3].ToString();
                            txtDescripcion2.Enabled = false;
                            txtReferencia2.Enabled = false;
                            txtObservaciones2.Enabled = false;
                            break;

                        case 3:
                            txtDescripcion3.Text = Dt_Sesion.Rows[i][3].ToString();
                            txtReferencia3.Text = Dt_Sesion.Rows[i][3].ToString();
                            txtObservaciones3.Text = Dt_Sesion.Rows[i][3].ToString();
                            txtDescripcion3.Enabled = false;
                            txtReferencia3.Enabled = false;
                            txtObservaciones3.Enabled = false;
                            break;
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();
       
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #region mover ventana
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            panel1_MouseDown(sender, e);
        }

        #endregion mover ventana
    }
}
