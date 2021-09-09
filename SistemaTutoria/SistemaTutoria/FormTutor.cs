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
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                Application.OpenForms[i].Close();
            }
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
    }
}
