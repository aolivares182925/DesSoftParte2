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
        public string Cod_Alumno;
        public string Cod_Tutor;
        public int Cod_Ficha;
        public FormFichaTutoria(string CodAlumno, string CodTutor, bool es_tutor)
        {
            Cod_Alumno = CodAlumno;
            Cod_Tutor = CodTutor;
            InitializeComponent();
            ConectarSQL conn = new ConectarSQL();
            DataTable Dt = conn.SelectAlumno(CodAlumno);
            tbCodigo.Text = Dt.Rows[0][0].ToString();
            tbApPaterno.Text = Dt.Rows[0][1].ToString();
            tbApMaterno.Text = Dt.Rows[0][2].ToString();
            tbNombres.Text = Dt.Rows[0][3].ToString();
            tbSituacion.Text = Dt.Rows[0][4].ToString();
            tbCodEscuela.Text = Dt.Rows[0][6].ToString();

            if (!es_tutor)
            {
                this.Size = new Size(700, 600);
                lblObservaciones1.Visible = false;
                txtObservaciones1.Visible = false;
                lblObservaciones2.Visible = false;
                txtObservaciones2.Visible = false;
                lblObservaciones3.Visible = false;
                txtObservaciones3.Visible = false;
                btnEditar1.Visible = false;
                btnEditar2.Visible = false;
                btnEditar3.Visible = false;
                btnGuardar1.Visible = false;
                btnGuardar2.Visible = false;
                btnGuardar3.Visible = false;
                p_sesion1.Height = 163;
                p_sesion2.Height = 163;
                p_sesion3.Height = 163;
                p_sesion1.Location = new Point(22, 13);
                p_sesion2.Location = new Point(22, 202);
                p_sesion3.Location = new Point(22, 391);
                //
                Bloquear(1);
                Bloquear(2);
                Bloquear(3);

            }

            Cod_Ficha = conn.Cod_Ficha_Tutoria(Cod_Alumno); 

            if (Cod_Ficha != 0)
            {
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

                                cbTipo1.SelectedIndex = Indice_Tipo(Dt_Sesion.Rows[i][2].ToString());
                                dtpFecha1.Text = Dt_Sesion.Rows[i][1].ToString();
                                txtDescripcion1.Text = Dt_Sesion.Rows[i][3].ToString();
                                txtReferencia1.Text = Dt_Sesion.Rows[i][4].ToString();
                                txtObservaciones1.Text = Dt_Sesion.Rows[i][5].ToString();
                                btnEditar1.Cursor = Cursors.Hand;
                                break;

                            case 2:
                                cbTipo2.SelectedIndex = Indice_Tipo(Dt_Sesion.Rows[i][2].ToString());
                                dtpFecha2.Text = Dt_Sesion.Rows[i][1].ToString();
                                txtDescripcion2.Text = Dt_Sesion.Rows[i][3].ToString();
                                txtReferencia2.Text = Dt_Sesion.Rows[i][4].ToString();
                                txtObservaciones2.Text = Dt_Sesion.Rows[i][5].ToString();
                                btnEditar2.Cursor = Cursors.Hand;
                                break;

                            case 3:
                                cbTipo3.SelectedIndex = Indice_Tipo(Dt_Sesion.Rows[i][2].ToString());
                                dtpFecha3.Text = Dt_Sesion.Rows[i][1].ToString();
                                txtDescripcion3.Text = Dt_Sesion.Rows[i][3].ToString();
                                txtReferencia3.Text = Dt_Sesion.Rows[i][4].ToString();
                                txtObservaciones3.Text = Dt_Sesion.Rows[i][5].ToString();
                                btnEditar3.Cursor = Cursors.Hand;
                                break;
                        }
                        Bloquear(Nro_sesion);
                    }
                }
            }
            else
            {
                conn.AgregarFicha(Cod_Tutor, Cod_Alumno);
                Cod_Ficha = conn.Cod_Ficha_Tutoria(Cod_Alumno);
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

        private void FormFichaTutoria_Load(object sender, EventArgs e)
        {
            
        }

        private void btnGuardar1_Click(object sender, EventArgs e)
        {
            Guardar(1);
        }

        private void btnEditar1_Click(object sender, EventArgs e)
        {
            Editar(1);
        }

        public void Editar(int Nro_Sesion)
        {
            switch (Nro_Sesion)
            {
                case 1:
                    if (Es_Editable(Nro_Sesion))
                    {
                        btnEditar1.Cursor = Cursors.Default;
                        cbTipo1.Enabled = true;
                        txtDescripcion1.Enabled = true;
                        txtReferencia1.Enabled = true;
                        txtObservaciones1.Enabled = true;
                        btnGuardar1.Cursor = Cursors.Hand;
                    }
                    break;

                case 2:
                    if (Es_Editable(Nro_Sesion))
                    {
                        btnEditar2.Cursor = Cursors.Default;
                        cbTipo2.Enabled = true;
                        txtDescripcion2.Enabled = true;
                        txtReferencia2.Enabled = true;
                        txtObservaciones2.Enabled = true;
                        btnGuardar2.Cursor = Cursors.Hand;
                    }
                    break;

                case 3:
                    if (Es_Editable(Nro_Sesion))
                    {
                        btnEditar3.Cursor = Cursors.Default;
                        cbTipo3.Enabled = true;
                        txtDescripcion3.Enabled = true;
                        txtReferencia3.Enabled = true;
                        txtObservaciones3.Enabled = true;
                        btnGuardar3.Cursor = Cursors.Hand;
                    }
                    break;
            }
        }

        public bool Es_Editable(int Nro_sesion)
        {
            bool Editable = false;
            switch (Nro_sesion)
            {
                case 1:
                    if(txtDescripcion1.Enabled == false || txtReferencia1.Enabled == false || txtObservaciones1.Enabled == false)
                    {
                        Editable = true;
                    }
                    break;
                case 2:
                    if (txtDescripcion2.Enabled == false || txtReferencia2.Enabled == false || txtObservaciones2.Enabled == false)
                    {
                        Editable = true;
                    }
                    break;
                case 3:
                    if (txtDescripcion3.Enabled == false || txtReferencia3.Enabled == false || txtObservaciones3.Enabled == false)
                        Editable = true;
                    break;
            }
            return Editable;
        }

        public void Guardar(int Nro_sesion)
        {
            string Descripcion = "";
            string Referencia = "";
            string Observaaciones = "";
            int Index = -1;

            if (!Es_Editable(Nro_sesion))
            {

                switch (Nro_sesion)
                {
                    case 1:

                        btnGuardar1.Cursor = Cursors.Default;
                        if (!Es_Vacio(Nro_sesion) && cbTipo1.SelectedIndex.ToString() != "-1")
                        {
                            Descripcion = txtDescripcion1.Text;
                            Referencia = txtReferencia1.Text;
                            Observaaciones = txtObservaciones1.Text;
                        }
                        Index = cbTipo1.SelectedIndex;
                        break;

                    case 2:

                        btnGuardar2.Cursor = Cursors.Default;
                        if (!Es_Vacio(Nro_sesion) && cbTipo2.SelectedIndex.ToString() != "-1")
                        {
                            Descripcion = txtDescripcion2.Text;
                            Referencia = txtReferencia2.Text;
                            Observaaciones = txtObservaciones2.Text;
                        }
                        Index = cbTipo2.SelectedIndex;
                        break;

                    case 3:

                        btnGuardar3.Cursor = Cursors.Default;
                        if (!Es_Vacio(Nro_sesion) && cbTipo3.SelectedIndex.ToString() != "-1")
                        {
                            Descripcion = txtDescripcion3.Text;
                            Referencia = txtReferencia3.Text;
                            Observaaciones = txtObservaciones3.Text;
                        }
                        Index = cbTipo3.SelectedIndex;
                        break;
                }

                if (Index == -1)
                    MessageBox.Show("Seleccione el Tipo de Tutoria de la sesion " + Nro_sesion.ToString());

                if (Descripcion != "")
                {
                    ConectarSQL conn = new ConectarSQL();
                    DataTable Dt_Sesion = conn.SelectFichaSesionAlumno(Cod_Alumno);
                    int Nro_Sesiones = Dt_Sesion.Rows.Count;
                    bool Editado = false;
                    string date = Fecha(Nro_sesion);
                    if (Nro_Sesiones != 0)
                    {
                        for (int i = 0; i < Nro_Sesiones; i++)
                        {
                            int Nro_sesion_E = Int32.Parse(Dt_Sesion.Rows[i][0].ToString());

                            if (Nro_sesion == Nro_sesion_E)
                            {
                                conn.EditarFichaSesion(Cod_Ficha, Nro_sesion, date, cbTipo1.Items[Index].ToString(),
                                    1, Descripcion, Referencia, Observaaciones);

                                MessageBox.Show("Sesion " + Nro_sesion + " editada correctamente");
                                Editado = true;
                                break;
                            }
                        }
                    }

                    if (!Editado)
                    {
                        conn.AgregarSesion(Cod_Ficha.ToString(), Nro_sesion.ToString(), date, cbTipo1.Items[Index].ToString(),
                                        1.ToString(), Descripcion, Referencia, Observaaciones);
                        MessageBox.Show("Sesion " + Nro_sesion + " añadida correctamente");
                    }

                    Bloquear(Nro_sesion);
                }
            }

        }

        public bool Es_Vacio(int Nro_sesion)
        {
            bool Vacio = false;

            switch(Nro_sesion)
            {
                case 1:
                    if (txtDescripcion1.Text.Trim() == "")
                        Vacio = true;
                    break;

                case 2:
                    if (txtDescripcion2.Text.Trim() == "")
                        Vacio = true;
                    break;

                case 3:
                    if (txtDescripcion3.Text.Trim() == "")
                        Vacio = true;
                    break;
            }
            if (Vacio == true)
                MessageBox.Show("Escriba en el campo descripcion de la sesion " + Nro_sesion.ToString());
            return Vacio;
        }

        public int Indice_Tipo (string tipo)
        {
            int Indice = -1;
            switch (tipo)
            {
                case "Academico":
                    Indice = 0;
                    break;
                case "Profesional":
                    Indice = 1;
                    break;
                case "Personal":
                    Indice = 2;
                    break;
            }
            return Indice;
        }

        public string Fecha(int Nro_sesion)
        {
            string date = "";
            switch (Nro_sesion)
            {
                case 1:
                    date = dtpFecha1.Text;
                    break;

                case 2:
                    date = dtpFecha2.Text;
                    break;

                case 3:
                    date = dtpFecha3.Text;
                    break;
            }
            return date;
        }

        public void Bloquear (int Nro_sesion)
        {
            switch(Nro_sesion)
            {
                case 1:
                    cbTipo1.Enabled = false;
                    dtpFecha1.Enabled = false;
                    txtDescripcion1.Enabled = false;
                    txtReferencia1.Enabled = false;
                    txtObservaciones1.Enabled = false;
                    btnEditar1.Cursor = Cursors.Hand;
                    break;

                case 2:
                    cbTipo2.Enabled = false;
                    dtpFecha2.Enabled = false;
                    txtDescripcion2.Enabled = false;
                    txtReferencia2.Enabled = false;
                    txtObservaciones2.Enabled = false;
                    btnEditar2.Cursor = Cursors.Hand;
                    break;

                case 3:
                    cbTipo3.Enabled = false;
                    dtpFecha3.Enabled = false;
                    txtDescripcion3.Enabled = false;
                    txtReferencia3.Enabled = false;
                    txtObservaciones3.Enabled = false;
                    btnEditar3.Cursor = Cursors.Hand;
                    break;
            }
        }
        private void btnEditar2_Click(object sender, EventArgs e)
        {
            Editar(2);
        }

        private void btnEditar3_Click(object sender, EventArgs e)
        {
            Editar(3);
        }

        private void btnGuardar2_Click(object sender, EventArgs e)
        {
            Guardar(2);
        }

        private void btnGuardar3_Click(object sender, EventArgs e)
        {
            Guardar(3);
        }
    }
}
