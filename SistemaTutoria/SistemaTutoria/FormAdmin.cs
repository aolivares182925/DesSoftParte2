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
        public FormAdmin(string Nombre, string Apellido1, string Apellido2)
        {
            InitializeComponent();
            lNombre.Text = Nombre;
            lApellido1.Text = Apellido1;
            lApellido2.Text = Apellido2;
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
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                Application.OpenForms[i].Close();
            }
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
    }
}
