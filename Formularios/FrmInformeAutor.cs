using Clase2.Clases;
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

namespace Clase2.Formularios
{
    public partial class FrmInformeAutor : Form
    {
        cConexion cn;// crear objeto de cConexion
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        public FrmInformeAutor()
        {
            InitializeComponent();
            cn = new cConexion();
            
            // Configuración del formulario
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            ConfigurarDiseno();
        }
        
        private void ConfigurarDiseno()
        {
            // Configuración básica del formulario
            this.BackColor = Color.White;
            
            // Panel de título
            panelTitulo.BackColor = Color.Teal;
            lblListadoEstudiantes.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblListadoEstudiantes.ForeColor = Color.White;
            lblFecha.ForeColor = Color.White;
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            
            // Panel de búsqueda
            panelBusqueda.BackColor = Color.LightCyan;
            panelBusqueda.BorderStyle = BorderStyle.FixedSingle;
            
            // Configuración de etiquetas
            ConfigurarEtiqueta(lblBuscar);
            
            // Configuración de textboxes
            ConfigurarCajaTexto(txtBuscar);
            
            // Configuración de botones
            ConfigurarBoton(btnExportar, Color.ForestGreen);
            
            // Panel de datos
            panelDatos.BackColor = Color.WhiteSmoke;
            panelDatos.BorderStyle = BorderStyle.FixedSingle;
            
            // Configuración del DataGridView
            ConfigurarDataGridView(dtgAutores);
        }
        
        private void ConfigurarEtiqueta(Label lbl)
        {
            lbl.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            lbl.ForeColor = Color.DarkSlateGray;
        }
        
        private void ConfigurarCajaTexto(TextBox txt)
        {
            txt.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Color.White;
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
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 35;
            dgv.RowTemplate.Height = 30;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(209, 231, 230);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
        }

        private void FrmInformeAutor_Load(object sender, EventArgs e)
        {
            llenar();
        }

        void llenar()
        {
            try
            {
                // Create command and fetch data
                cmd = new SqlCommand("select * from TblAutor", cn.AbrirConexion());
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                // Check if we have data
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay autores registrados en la base de datos.");
                    return;
                }

                // Option 1: Use DataSource (simplest approach)
                dtgAutores.DataSource = dt;

                // Format column headers if needed
                dtgAutores.Columns[0].HeaderText = "Cédula";
                dtgAutores.Columns[1].HeaderText = "Nombre";
                dtgAutores.Columns[2].HeaderText = "Fecha Nacimiento";
                dtgAutores.Columns[3].HeaderText = "Email";

                // Format date column
                dtgAutores.Columns[2].DefaultCellStyle.Format = "yyyy-MM-dd";

                // Auto-size columns for better appearance
                dtgAutores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void lblListadoEstudiantes_Click(object sender, EventArgs e)
        {
        }

        private void dtgAutores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Buscar autores según el texto ingresado
            BuscarAutores(txtBuscar.Text);
        }
        
        private void BuscarAutores(string filtro)
        {
            try
            {
                if (dt != null)
                {
                    // Crear vista filtrada
                    DataView dv = dt.DefaultView;
                    dv.RowFilter = string.Format("Cedula LIKE '%{0}%' OR nombreAutor LIKE '%{0}%'", 
                        filtro.Replace("'", "''"));
                    
                    // Asignar la vista filtrada al DataGridView
                    dtgAutores.DataSource = dv.ToTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar autores: " + ex.Message);
            }
        }
        
        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDatosAExcel(dtgAutores);
        }
        
        private void ExportarDatosAExcel(DataGridView dgv)
        {
            if (dgv != null && dgv.Rows.Count > 0)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Archivos Excel (*.xlsx)|*.xlsx";
                saveDialog.Title = "Guardar Listado de Autores";
                saveDialog.FileName = "Listado_Autores_" + DateTime.Now.ToString("yyyyMMdd");

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
    }
}