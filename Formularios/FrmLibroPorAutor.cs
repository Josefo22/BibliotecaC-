using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clase2.Clases;

namespace Clase2.Formularios
{
    public partial class FrmLibroPorAutor : Form
    {
        private cConexion cn;
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private DataTable dt;

        public FrmLibroPorAutor()
        {
            InitializeComponent();
            
            // Configuración del formulario
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            
            cn = new cConexion();
            
            ConfigurarDiseno();
        }
        
        private void ConfigurarDiseno()
        {
            // Configuración básica del formulario
            this.BackColor = Color.White;
            
            // Panel de título
            panelTitulo.BackColor = Color.DarkGreen;
            lblTitulo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblFecha.ForeColor = Color.White;
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            
            // Panel de búsqueda
            panelBusqueda.BackColor = Color.Honeydew;
            panelBusqueda.BorderStyle = BorderStyle.FixedSingle;
            
            // Configuración de etiquetas
            ConfigurarEtiqueta(lblAutor);
            ConfigurarEtiqueta(lblSeleccion);
            
            // Configuración de combobox
            ConfigurarComboBox(cmbAutores);
            
            // Configuración de botones
            ConfigurarBoton(btnBuscar, Color.ForestGreen);
            ConfigurarBoton(btnExportar, Color.RoyalBlue);
            
            // Panel de datos
            panelDatos.BackColor = Color.WhiteSmoke;
            panelDatos.BorderStyle = BorderStyle.FixedSingle;
            
            // Configuración del DataGridView
            ConfigurarDataGridView(dgvLibros);
            
            // Cargar autores en el ComboBox
            CargarAutores();
        }
        
        private void ConfigurarEtiqueta(Label lbl)
        {
            lbl.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            lbl.ForeColor = Color.DarkSlateGray;
        }
        
        private void ConfigurarComboBox(ComboBox cmb)
        {
            cmb.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb.BackColor = Color.White;
        }
        
        private void ConfigurarBoton(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.Cursor = Cursors.Hand;
        }
        
        private void ConfigurarDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGreen;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 35;
            dgv.RowTemplate.Height = 30;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 240, 220);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
        }
        
        private void CargarAutores()
        {
            try
            {
                cmd = new SqlCommand("SELECT Cedula, nombreAutor FROM TblAutor ORDER BY nombreAutor", cn.AbrirConexion());
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                
                if (dt.Rows.Count > 0)
                {
                    cmbAutores.DataSource = dt;
                    cmbAutores.DisplayMember = "nombreAutor";
                    cmbAutores.ValueMember = "Cedula";
                    cmbAutores.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los autores: " + ex.Message, 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbAutores.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione un autor", 
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            BuscarLibrosPorAutor(cmbAutores.SelectedValue.ToString());
        }
        
        private void BuscarLibrosPorAutor(string cedula)
        {
            try
            {
                string query = @"SELECT l.ISBN, l.titulo, l.autor, l.edicion, l.editorial, l.anio
                                FROM tblLibro l
                                INNER JOIN tblAutor a ON l.autor = a.nombreAutor
                                WHERE a.Cedula = @cedula
                                ORDER BY l.titulo";
                
                cmd = new SqlCommand(query, cn.AbrirConexion());
                cmd.Parameters.AddWithValue("@cedula", cedula);
                da = new SqlDataAdapter(cmd);
                DataTable dtLibros = new DataTable();
                da.Fill(dtLibros);
                
                dgvLibros.DataSource = dtLibros;
                
                if (dtLibros.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron libros para este autor", 
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblSeleccion.Text = "No hay libros disponibles";
                }
                else
                {
                    lblSeleccion.Text = $"Se encontraron {dtLibros.Rows.Count} libros para el autor {cmbAutores.Text}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar libros: " + ex.Message, 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDatosAExcel();
        }
        
        private void ExportarDatosAExcel()
        {
            DataTable dtExport = dgvLibros.DataSource as DataTable;
            
            if (dtExport != null && dtExport.Rows.Count > 0)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Archivos Excel (*.xlsx)|*.xlsx";
                saveDialog.Title = "Guardar Listado de Libros";
                saveDialog.FileName = "Libros_Por_Autor_" + DateTime.Now.ToString("yyyyMMdd");

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("La exportación a Excel será implementada en una versión futura.",
                        "Funcionalidad en Desarrollo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Aquí iría el código para la exportación a Excel
                    // Requiere la referencia a una biblioteca como EPPlus, ClosedXML, etc.
                }
            }
            else
            {
                MessageBox.Show("No hay datos para exportar.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void FrmLibroPorAutor_Load(object sender, EventArgs e)
        {
            lblSeleccion.Text = "Seleccione un autor para ver sus libros";
        }
    }
}
