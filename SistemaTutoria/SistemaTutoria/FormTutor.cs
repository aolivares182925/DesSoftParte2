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
    public partial class FormTutor : Form
    {
        string CodigoTutor;
        public FormTutor(string Nombre, string Apellido1, string Apellido2,string Codigo)
        {
            InitializeComponent();
            lblNombre.Text = Nombre;
            lblAPaterno.Text = Apellido1;
            lblAMaterno.Text = Apellido2;
            lblCodigo.Text = Codigo;

            CodigoTutor = Codigo;

            ConectarSQL conn = new ConectarSQL();

            DataTable dt = new DataTable();
            dt = conn.SelectTutorCodigo(CodigoTutor);

            lblContraseñaActual.Text = dt.Rows[0]["Contraseña"].ToString();

            refreshDataGridView();
        }

        #region mover ventana
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void FormTutor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion mover ventana

        public void refreshDataGridView()
        {
            ConectarSQL conn = new ConectarSQL();
            dgvPrincipal.DataSource = conn.SelectAlumnosDeTutor(CodigoTutor);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.Login1.Show();
            //for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            //{
            //    Application.OpenForms[i].Close();
            //}
        }

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (tbBuscar.Text != "")
            {
                dgvPrincipal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ConectarSQL conn = new ConectarSQL();
                dgvPrincipal.DataSource = conn.BuscarAlumnoDeTutor(cmbCategoria.Text.ToString(), tbBuscar.Text.ToString(),CodigoTutor);
            }
            else if (tbBuscar.Text == "")
            {
                refreshDataGridView();
            }
        }

        private void dgvPrincipal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvPrincipal.Columns[e.ColumnIndex].Name == "FichaTutoria")
            {
                //obtener el codigo del alumno
                string CodigoAlumno = dgvPrincipal.Rows[e.RowIndex].Cells["CodAlumno"].FormattedValue.ToString();

                FormFichaTutoria Ficha = new FormFichaTutoria(CodigoAlumno,CodigoTutor);
                

                Ficha.Show();
            }
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            if (panelContraseña.Visible)
            {
                panelContraseña.Visible = false;
                txtContraseñaN.Text = "";
                txtContraseñaN2.Text = "";

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
            

            
            if ((txtContraseñaN.Text != "") && (txtContraseñaN.Text == txtContraseñaN2.Text))
            {
                
                string ContraseñaNueva = txtContraseñaN.Text.ToString();
                DialogResult result = MessageBox.Show("¿Seguro que desea cambiar su contraseña?", 
                    "Cambiar Contraseña",MessageBoxButtons.YesNo);

                switch (result)
                {
                    case DialogResult.Yes:
                        try
                        {
                            ConectarSQL conn = new ConectarSQL();
                            conn.EditarContraseñaTutor(CodigoTutor, ContraseñaNueva);
                            MessageBox.Show("Contraseña actualizada");
                            lblContraseñaActual.Text = ContraseñaNueva;
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
                txtContraseñaN.Text = "";
                txtContraseñaN2.Text = "";
                picboxVerificar.Visible = false;

            }
        }
    }
}
