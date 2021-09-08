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
    public partial class TutoresUserControl : UserControl
    {
        private static TutoresUserControl _instance;
        
        public static TutoresUserControl Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new TutoresUserControl();
                }
                return _instance;
            }
        }
        public TutoresUserControl()
        {
            InitializeComponent();
            refreshDataGridView();
        }
        #region Metodos
        public void refreshDataGridView()
        {
            ConectarSQL conn = new ConectarSQL();
            dgvPrincipal.DataSource = conn.SelectTutores();
        }
        public void Clear()
        {
            tbCodigo.Text = "";
            tbNombres.Text = "";
            tbApPaterno.Text = "";
            tbApMaterno.Text = "";
            cmbEstado.Text = "";
            tbAgregar.Text = "";
        }
        #endregion Metodos
        // ---------------------------------
        // --------------------- Eventos
        private void dgvPrincipal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvPrincipal.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                // Codigo para eliminar elemento
                //
                string Codigo = dgvPrincipal.Rows[e.RowIndex].Cells["CodTutor"].FormattedValue.ToString();
                DialogResult result = MessageBox.Show("Seguro que desea Eliminar Tutor de codigo:" + Codigo + "?", "Eliminar Tutor", MessageBoxButtons.YesNo);

                switch (result)
                {
                    case DialogResult.Yes:
                        try
                        {
                            ConectarSQL conn = new ConectarSQL();
                            conn.EliminarTutor(Codigo);
                            MessageBox.Show("Eliminado");
                        }
                        catch
                        {
                            MessageBox.Show("No es posible eliminar un tutor asignado a un alumno");
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
                tbCodigo.Text = dgvPrincipal.Rows[e.RowIndex].Cells["CodTutor"].FormattedValue.ToString();
                tbNombres.Text = dgvPrincipal.Rows[e.RowIndex].Cells["Nombres"].FormattedValue.ToString();
                tbApPaterno.Text = dgvPrincipal.Rows[e.RowIndex].Cells["APaterno"].FormattedValue.ToString();
                tbApMaterno.Text = dgvPrincipal.Rows[e.RowIndex].Cells["AMaterno"].FormattedValue.ToString();
                cmbEstado.Text = dgvPrincipal.Rows[e.RowIndex].Cells["Estado"].FormattedValue.ToString();


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
                    ConectarSQL conn = new ConectarSQL();
                    
                    conn.AgregarTutor(tbCodigo.Text, tbApPaterno.Text, tbApMaterno.Text, tbNombres.Text, cmbEstado.Text);
                    MessageBox.Show("Agregado Correctamente");
                    Clear();

                }
                catch
                {
                    MessageBox.Show("Datos incorrectos o existentes");
                }
            }
            else
            {
                try
                {
                    ConectarSQL conn = new ConectarSQL();
                    
                    conn.EditarTutor(tbCodigo.Text, tbApPaterno.Text, tbApMaterno.Text, tbNombres.Text, cmbEstado.Text);

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

        private void tbAgregar_TextChanged(object sender, EventArgs e)
        {
            if (tbAgregar.Text != "")
            {
                dgvPrincipal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ConectarSQL conn = new ConectarSQL();
                dgvPrincipal.DataSource = conn.BuscarTutor(cmbCategoria.Text.ToString(), tbAgregar.Text.ToString());
            }
            else if (tbAgregar.Text == "")
            {
                refreshDataGridView();
            }
        }

        private void cmbCategoria_TextChanged(object sender, EventArgs e)
        {
            refreshDataGridView();
            tbAgregar.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Clear();
            btnAgregar.Text = "AGREGAR";
            btnCancelar.Visible = false;
            refreshDataGridView();
        }

        private void TutoresUserControl_Load(object sender, EventArgs e)
        {

        }

        /*
        private void bConectar_Click(object sender, EventArgs e)
        {
        ConectarSQL c = new ConectarSQL();
        try
        {
        c.Conectar();
        MessageBox.Show("Conectado a la base de datos");
        }
        catch(Exception E)
        {
        MessageBox.Show($"Error al conectar a base de datos \n {E}");
        }
        }
        */
    }
}
