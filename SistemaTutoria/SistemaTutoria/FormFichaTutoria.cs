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
        public FormFichaTutoria(string Codigo, string Nombre, string Apellido1, string Apellido2, string E_Profesional, string Situacion)
        {
            InitializeComponent();
            tbCodigo.Text = Codigo;
            tbNombres.Text = Nombre;
            tbApPaterno.Text = Apellido1;
            tbApMaterno.Text = Apellido2;
            tbCodEscuela.Text = E_Profesional;
            tbSituacion.Text = Situacion;
        }

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
    }
}
