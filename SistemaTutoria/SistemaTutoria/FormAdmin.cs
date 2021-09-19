using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocios;
 
namespace SistemaTutoria
{
    public partial class FormAdmin : Form
    {
        string UsuarioAdmin;
        public FormAdmin(string Nombre, string Apellido1, string Apellido2, string Usuario)
        {
            InitializeComponent();
            lNombre.Text = Nombre;
            lApellido1.Text = Apellido1;
            lApellido2.Text = Apellido2;
            UsuarioAdmin = Usuario;

            ConectarSQL conn = new ConectarSQL();

            DataTable dt = new DataTable();
            dt = conn.SelectAdministradorCodigo(Usuario);
            //showTutores();
        }

        #region mover ventana
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Crud_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion mover ventana

        #region Metodos
        private void defaulButtonstBackColor()
        {
            btnMenuAlumnos.BackColor = Color.FromArgb(104, 13, 15);
            btnMenuTutores.BackColor = Color.FromArgb(104, 13, 15);
        }
        public void showTutores()
        {
            if (!panel.Controls.Contains(TutoresUserControl.Instance))
                panel.Controls.Add(TutoresUserControl.Instance);
            TutoresUserControl.Instance.BringToFront();
            defaulButtonstBackColor();
            btnMenuTutores.BackColor = Color.FromArgb(255, 255, 255);
        }
        public void showAlumnos()
        {
            if (!panel.Controls.Contains(AlumnosUserControl.Instance))
                panel.Controls.Add(AlumnosUserControl.Instance);
            AlumnosUserControl.Instance.BringToFront();
            defaulButtonstBackColor();
            btnMenuAlumnos.BackColor = Color.FromArgb(255, 255, 255);
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.Login1.Show();
            //for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            //{
            //    Application.OpenForms[i].Close();
            //}
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void btnMenuTutores_Click(object sender, EventArgs e)
        {
            showTutores();
        }

        private void btnMenuAlumnos_Click(object sender, EventArgs e)
        {
            showAlumnos();
        }

        private void Crud_Load(object sender, EventArgs e)
        {

        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            if (panelContraseña.Visible)
            {
                panelContraseña.Visible = false;
                txtContraseñaN.Text = "";
                txtContraseñaN2.Text = "";
                txtContraseñaActual.Text = "";

                picboxVerificar.Visible = false;
            }
            else
            {
                panelContraseña.Visible = true;
            }
        }
        private void btnOjo_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnOjo.Image = global::SistemaTutoria.Properties.Resources.icons8_visible_24_blanco;
            txtContraseñaN.UseSystemPasswordChar = false;
            txtContraseñaN2.UseSystemPasswordChar = false;
        }

        private void btnOjo_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnOjo.Image = global::SistemaTutoria.Properties.Resources.icons8_ojo_cerrado_24_blanco;
            txtContraseñaN.UseSystemPasswordChar = true;
            txtContraseñaN2.UseSystemPasswordChar = true;

        }

        private void txtContraseñaN2_TextChanged(object sender, EventArgs e)
        {
            picboxVerificar.Visible = true;
            if (txtContraseñaN.Text == txtContraseñaN2.Text)
            {
                picboxVerificar.Image = global::SistemaTutoria.Properties.Resources.icons8_check_64;
            }
            else
            {
                picboxVerificar.Image = global::SistemaTutoria.Properties.Resources.icons8_xbox_x_32;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //Crear coneccion con la base de datos
            
        }
        private void btnOjo2_MouseDown(object sender, MouseEventArgs e)
        {
            this.btnOjo2.Image = global::SistemaTutoria.Properties.Resources.icons8_visible_24_blanco;
            txtContraseñaActual.UseSystemPasswordChar = false;
            txtContraseñaActual.UseSystemPasswordChar = false;
        }

        private void btnOjo2_MouseUp(object sender, MouseEventArgs e)
        {
            this.btnOjo2.Image = global::SistemaTutoria.Properties.Resources.icons8_ojo_cerrado_24_blanco;
            txtContraseñaActual.UseSystemPasswordChar = true;
            txtContraseñaActual.UseSystemPasswordChar = true;
        }

        private void picboxVerificar_Click(object sender, EventArgs e)
        {

        }

        private void txtContraseñaN2_TextChanged_1(object sender, EventArgs e)
        {
            picboxVerificar.Visible = true;
            if (txtContraseñaN.Text == txtContraseñaN2.Text)
            {
                picboxVerificar.Image = global::SistemaTutoria.Properties.Resources.icons8_check_64;
            }
            else
            {
                picboxVerificar.Image = global::SistemaTutoria.Properties.Resources.icons8_xbox_x_32;
            }
        }

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            ConectarSQL conn = new ConectarSQL();

            DataTable dt = new DataTable();
            dt = conn.SelectAdministradorCodigo(UsuarioAdmin);

            string PassWord = dt.Rows[0]["Contraseña"].ToString();

            if ((txtContraseñaActual.Text == PassWord) && (txtContraseñaN.Text != "") && (txtContraseñaN.Text == txtContraseñaN2.Text))
            {

                string ContraseñaNueva = txtContraseñaN.Text.ToString();
                DialogResult result = MessageBox.Show("¿Seguro que desea cambiar su contraseña?",
                    "Cambiar Contraseña", MessageBoxButtons.YesNo);

                switch (result)
                {
                    case DialogResult.Yes:
                        try
                        {

                            conn.EditarContraseñaAdministrador(UsuarioAdmin, ContraseñaNueva);
                            MessageBox.Show("Contraseña actualizada");
                            //lblContraseñaActual.Text = ContraseñaNueva;
                        }
                        catch
                        {
                            MessageBox.Show("No es posible actualizar la contraseña");
                        }
                        break;

                    case DialogResult.No:
                        break;
                }
                panelContraseña.Visible = false;
                txtContraseñaActual.Text = "";
                txtContraseñaN.Text = "";
                txtContraseñaN2.Text = "";
                picboxVerificar.Visible = false;

            }
            else
            {
                MessageBox.Show("Contraseña actual erronea o Contraseña nueva invalida");
            }
        }
    }
}
