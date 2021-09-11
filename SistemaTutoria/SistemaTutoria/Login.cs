using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Negocios;

namespace SistemaTutoria
{
    public partial class Login : Form
    {
        bool F = true;
        #region mover ventana
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion mover ventana
        public Login()
        {
            InitializeComponent();
            bDocente.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {
            ConectarSQL conn = new ConectarSQL();
            
            if (F)
            {
                DataTable dt = conn.BuscarTutorLogin(tbUsuario.Text, tbContra.Text);
                if (dt.Rows.Count == 1)
                {
                    FormTutor C = new FormTutor(dt.Rows[0][3].ToString(),
                        dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(),dt.Rows[0][0].ToString());
                    this.Hide();
                    C.Show();
                    
                    //this.Show();
                    
                }
                else
                {
                    MessageBox.Show("No se encontro el usuario");
                }
                tbUsuario.Text = "  Usuario";
                tbContra.Text = "  Contraseña";
                tbContra.UseSystemPasswordChar = false;
            }
            else
            {
                DataTable dt = conn.BuscarAdministrador(tbUsuario.Text, tbContra.Text);
                if (dt.Rows.Count == 1)
                {
                    FormAdmin C = new FormAdmin(dt.Rows[0][3].ToString(),
                        dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString());
                    this.Hide();
                    C.Show();
                }
                else
                {
                    MessageBox.Show("No se encontro el usuario");
                }
                tbUsuario.Text = "  Usuario";
                tbContra.Text = "  Contraseña";
                tbContra.UseSystemPasswordChar = false;
            }


            

        }
        private void tbUsuario_Enter(object sender, EventArgs e)
        {
            if (tbUsuario.Text == "  Usuario")
            {
                tbUsuario.Text = "";
                tbUsuario.ForeColor = Color.FromArgb(29, 29, 29);
            }
        }

        private void tbUsuario_Leave(object sender, EventArgs e)
        {
            if (tbUsuario.Text == "")
            {
                tbUsuario.Text = "  Usuario";
                tbUsuario.ForeColor = Color.Gray;
            }
        }
        private void tbContra_Enter(object sender, EventArgs e)
        {
            if (tbContra.Text == "  Contraseña")
            {
                tbContra.Text = "";
                tbContra.UseSystemPasswordChar = true;
                tbContra.ForeColor = Color.FromArgb(29, 29, 29);
            }
        }

        private void tbContra_Leave(object sender, EventArgs e)
        {
            if (tbContra.Text == "")
            {
                tbContra.Text = "  Contraseña";
                tbContra.UseSystemPasswordChar = false;
                tbContra.ForeColor = Color.Gray;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void btnVisible_MouseDown(object sender, MouseEventArgs e)
        {

            this.btnVisible.Image = global::SistemaTutoria.Properties.Resources.icons8_visible_24;
            tbContra.UseSystemPasswordChar = false;
        }
        private void btnVisible_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnVisible.Image = global::SistemaTutoria.Properties.Resources.icons8_ojo_cerrado_24;
            if (tbContra.Text != "  Contraseña")
            {
                tbContra.UseSystemPasswordChar = true;
            }
        }


        private void bDocente_Click(object sender, EventArgs e)
        {
            F = true;

            lblCategoria.Text = "Ingresando como Docente";
            bDocente.BackColor = Color.FromArgb(255, 255, 255);
            bAdministrador.BackColor = Color.FromArgb(104, 13, 15);
        }

        private void bAdministrador_Click(object sender, EventArgs e)
        {
            F = false;
            lblCategoria.Text = "Ingresando como Administrador";
            bAdministrador.BackColor = Color.FromArgb(255, 255, 255);
            bDocente.BackColor = Color.FromArgb(104, 13, 15);
        }

        
    }
}
