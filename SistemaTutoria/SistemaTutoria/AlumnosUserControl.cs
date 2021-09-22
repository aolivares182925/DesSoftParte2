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
    public partial class AlumnosUserControl : UserControl
    {
        private static AlumnosUserControl _instance;
        public static AlumnosUserControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AlumnosUserControl();
                }
                return _instance;
            }
        }
        public AlumnosUserControl()
        {
            InitializeComponent();
            Form1_Load();
            refreshDataGridView();

        }
        #region Metodos
        public void refreshDataGridView()
        {
            ConectarSQL conn = new ConectarSQL();
            dgvPrincipal.DataSource = conn.SelectAlumnos();
        }

        public void Clear()
        {
            tbCodigo.Text = "";
            tbNombres.Text = "";
            tbApPaterno.Text = "";
            tbApMaterno.Text = "";
            tbCodEscuela.Text = "";
            tbCodTutor.Text = "";
            tbBuscar.Text = "";
            cbRiesgo.Checked = false;
        }
        #endregion
        private void dgvPrincipal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvPrincipal.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                // Codigo para eliminar elemento
                //
                string Codigo = dgvPrincipal.Rows[e.RowIndex].Cells["CodAlumno"].FormattedValue.ToString();
                DialogResult result = MessageBox.Show("Seguro que desea Eliminar Alumno de codigo:" + Codigo + "?", "Eliminar Alumno", MessageBoxButtons.YesNo);

                switch (result)
                {
                    case DialogResult.Yes:
                        try
                        {

                            ConectarSQL conn = new ConectarSQL();
                            conn.EliminarAlumno(Codigo);
                            MessageBox.Show("Eliminado");
                        }
                        catch
                        {
                            MessageBox.Show("No es posible eliminar el Alumno");
                        }

                        break;
                    case DialogResult.No:
                        break;
                }
                //MessageBox.Show("Eliminado");
                refreshDataGridView();
            }
            else if (e.ColumnIndex >= 0 && dgvPrincipal.Columns[e.ColumnIndex].Name == "Editar")
            {
                dgvPrincipal.CurrentRow.Selected = true;
                tbCodigo.Text = dgvPrincipal.Rows[e.RowIndex].Cells["CodAlumno"].FormattedValue.ToString();
                tbNombres.Text = dgvPrincipal.Rows[e.RowIndex].Cells["Nombres"].FormattedValue.ToString();
                tbApPaterno.Text = dgvPrincipal.Rows[e.RowIndex].Cells["APaterno"].FormattedValue.ToString();
                tbApMaterno.Text = dgvPrincipal.Rows[e.RowIndex].Cells["AMaterno"].FormattedValue.ToString();
                tbCodEscuela.Text = dgvPrincipal.Rows[e.RowIndex].Cells["CodEscuela"].FormattedValue.ToString();
                tbCodTutor.Text = dgvPrincipal.Rows[e.RowIndex].Cells["CodTutor"].FormattedValue.ToString();

                if (dgvPrincipal.Rows[e.RowIndex].Cells["Situacion"].FormattedValue.ToString() == "Riesgo")
                {
                    cbRiesgo.Checked = true;
                }
                else
                {
                    cbRiesgo.Checked = false;
                }
                if (Int32.Parse(dgvPrincipal.Rows[e.RowIndex].Cells["Activo"].FormattedValue.ToString()) == 1)
                {
                    chboxActivo.Checked = true;
                }
                else
                {
                    chboxActivo.Checked = false;
                }
                btnAgregar.Text = "EDITAR";
                btnCancelar.Visible = true;
                tbCodigo.Enabled = false;

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (btnAgregar.Text == "AGREGAR")
            {
                try
                {
                    bool agregado;
                    string Situacion;
                    int Activo;

                    ConectarSQL C = new ConectarSQL();
                    if (cbRiesgo.Checked == true)
                    {
                        Situacion = "Riesgo";
                    }
                    else
                    {
                        Situacion = "No Riesgo";
                    }
                    if (chboxActivo.Checked == true)
                    {
                        Activo = 1;
                    }
                    else
                    {
                        Activo = 0;
                    }
                    agregado = C.AgregarAlumnoSiPosible(tbCodigo.Text, tbApPaterno.Text, tbApMaterno.Text, tbNombres.Text, Situacion,
                                        tbCodTutor.Text, tbCodEscuela.Text, Activo);
                    if (agregado)
                    {
                        MessageBox.Show("Agregado Correctamente");
                    }

                }
                catch
                {
                    MessageBox.Show("Datos incorrectos o existentes");
                }
                Clear();

            }
            else
            {
                try
                {
                    ConectarSQL conn = new ConectarSQL();
                    string Situacion;
                    int Activo;
                    string CodTutor;

                    if (cbRiesgo.Checked == true)
                    {
                        Situacion = "Riesgo";
                    }
                    else
                    {
                        Situacion = "No Riesgo";
                    }
                    if (chboxActivo.Checked == true)
                    {
                        Activo = 1;
                    }
                    else
                    {
                        Activo = 0;
                    }
                    if (tbCodTutor.Text == "")
                    {
                        CodTutor = "NNN";
                    }
                    else
                    {
                        CodTutor = tbCodTutor.Text;
                    }
                    conn.EditarAlumno(tbCodigo.Text, tbApPaterno.Text, tbApMaterno.Text, tbNombres.Text, Situacion,
                        CodTutor, tbCodEscuela.Text, Activo);

                    MessageBox.Show("Fila editada correctamente");
                    btnCancelar.Visible = false;
                    btnAgregar.Text = "AGREGAR";
                    tbCodigo.Enabled = true;
                    Clear();

                }
                catch
                {
                    MessageBox.Show("Datos incorrectos o existentes");
                }
            }

            refreshDataGridView();
        }

        private void btnBuscar_Click(object sender, EventArgs e )
        {
            /* código aquí
             * 
            */
            refreshDataGridView();
        }

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (tbBuscar.Text != "" )
            {
                dgvPrincipal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ConectarSQL conn = new ConectarSQL();
                dgvPrincipal.DataSource = conn.BuscarAlumno(cmbCategoria.Text.ToString(), tbBuscar.Text.ToString());
            }
            else if (tbBuscar.Text == "")
            {
                refreshDataGridView();
            }
        }

        private void cmbCategoria_TextChanged(object sender, EventArgs e)
        {
            refreshDataGridView();
            tbBuscar.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Clear();
            btnAgregar.Text = "AGREGAR";
            btnCancelar.Visible = false;
            refreshDataGridView();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chboxActivo_CheckedChanged(object sender, EventArgs e)
        {
            if (chboxActivo.Checked)
            {
                tbCodTutor.Enabled = true;
            }
            else
            {
                tbCodTutor.Text = "";
                tbCodTutor.Enabled = false;
            }
        }


        private void Form1_Load()
        {
            ConectarSQL conn = new ConectarSQL();
            DataTable tabla = conn.SelectTutores();


            cmbNomTutor.DataSource = tabla;
            cmbNomTutor.ValueMember = "CodTutor";
            cmbNomTutor.ValueMember = "APaterno";
            cmbNomTutor.ValueMember = "AMaterno";
            cmbNomTutor.DisplayMember = "Nombres";

            tbCodTutor.DataSource = tabla;
            tbCodTutor.ValueMember = "Nombres";
            tbCodTutor.DisplayMember = "CodTutor";

            cmbApPatTutor.DataSource = tabla;
            cmbApPatTutor.ValueMember = "Nombres";
            cmbApPatTutor.DisplayMember = "APaterno";

            cmbApMatTutor.DataSource = tabla;
            cmbApMatTutor.ValueMember = "Nombres";
            cmbApMatTutor.DisplayMember = "AMaterno";



            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in tabla.Rows)
            {
                coleccion.Add(Convert.ToString(row["Nombres"]));
                coleccion.Add(Convert.ToString(row["APaterno"]));
                coleccion.Add(Convert.ToString(row["AMaterno"]));

            }






            cmbNomTutor.AutoCompleteCustomSource = coleccion;
            cmbNomTutor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbNomTutor.AutoCompleteSource = AutoCompleteSource.CustomSource;

            tbCodTutor.AutoCompleteCustomSource = coleccion;
            tbCodTutor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbCodTutor.AutoCompleteSource = AutoCompleteSource.CustomSource;

            tbApPaterno.AutoCompleteCustomSource = coleccion;
            tbApPaterno.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbApPaterno.AutoCompleteSource = AutoCompleteSource.CustomSource;

            tbApMaterno.AutoCompleteCustomSource = coleccion;
            tbApMaterno.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbApMaterno.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }
        private void tbCodTutor_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbCodTutor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}