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
        public FormTutor(string Nombre, string Apellido1, string Apellido2)
        {
            InitializeComponent();
            lNombre.Text = Nombre;
            lApellido1.Text = Apellido1;
            lApellido2.Text = Apellido2;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormTutor_Load(object sender, EventArgs e)
        {

        }
    }
}
