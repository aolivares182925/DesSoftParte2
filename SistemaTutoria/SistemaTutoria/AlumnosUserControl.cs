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

                    ConectarSQL C = new ConectarSQL();
                    if (cbRiesgo.Checked == true)
                    {
                        Situacion = "Riesgo";
                    }
                    else
                    {
                        Situacion = "No Riesgo";
                    }
                    agregado = C.AgregarAlumnoSiPosible(tbCodigo.Text, tbApPaterno.Text, tbApMaterno.Text, tbNombres.Text, Situacion,
                                        tbCodTutor.Text, tbCodEscuela.Text);
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
                    if (cbRiesgo.Checked == true)
                    {
                        Situacion = "Riesgo";
                    }
                    else
                    {
                        Situacion = "No Riesgo";
                    }
                    conn.EditarAlumno(tbCodigo.Text, tbApPaterno.Text, tbApMaterno.Text, tbNombres.Text, Situacion,
                        tbCodTutor.Text, tbCodEscuela.Text);

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            /* codigo aqui
             * 
            */
            refreshDataGridView();
        }

        private void tbBuscar_TextChanged(object sender, EventArgs e)
        {
            if (tbBuscar.Text != "")
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
    }
}
