using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clase2.Clases;

namespace Clase2.Formularios
{
    public partial class frmInformeEstudiante: Form
    {
        cConexion cn;// crear objeto de cConexion
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;
        int contador;
        
        public frmInformeEstudiante()
        {
            InitializeComponent();
            
            // Configuración del formulario
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            
            cn = new cConexion();
            cmd = new SqlCommand(" select * from tblEstudiante", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            contador = dt.Rows.Count;
            
            ConfigurarDiseno();
        }
        
        private void ConfigurarDiseno()
        {
            // Configuración básica del formulario
            this.BackColor = Color.White;
            
            // Panel de título
            panelTitulo.BackColor = Color.RoyalBlue;
            lblListadoEstudiantes.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblListadoEstudiantes.ForeColor = Color.White;
            lblFecha.ForeColor = Color.White;
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            
            // Panel de búsqueda
            panelBusqueda.BackColor = Color.AliceBlue;
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
            ConfigurarDataGridView(dtgEstudiante);
        }
        
        private void ConfigurarEtiqueta(Label lbl)
        {
            lbl.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            lbl.ForeColor = Color.DarkSlateBlue;
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
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 35;
            dgv.RowTemplate.Height = 30;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 230, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
        }

        private void frmInformeEstudiante_Load(object sender, EventArgs e)
        {
            llenar();
        }
        
        void llenar()
        {
            dtgEstudiante.Rows.Clear();
            dtgEstudiante.Rows.Add(contador - 1);
            for (int i = 0; i < contador; i++)
            {
                dtgEstudiante.Rows[i].Cells[0].Value = dt.Rows[i][0];
                dtgEstudiante.Rows[i].Cells[1].Value = dt.Rows[i][1];
                dtgEstudiante.Rows[i].Cells[2].Value = dt.Rows[i][3];
                dtgEstudiante.Rows[i].Cells[3].Value = dt.Rows[i][2];
            }
        }
        
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarEstudiantes(txtBuscar.Text);
        }
        
        private void BuscarEstudiantes(string filtro)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filtro))
                {
                    llenar();
                    return;
                }
                
                dtgEstudiante.Rows.Clear();
                
                // Contar registros que coinciden con el filtro
                int coincidencias = 0;
                for (int i = 0; i < contador; i++)
                {
                    string carnet = dt.Rows[i][0].ToString().ToLower();
                    string nombre = dt.Rows[i][1].ToString().ToLower();
                    
                    if (carnet.Contains(filtro.ToLower()) || nombre.Contains(filtro.ToLower()))
                    {
                        coincidencias++;
                    }
                }
                
                if (coincidencias == 0)
                {
                    return;
                }
                
                dtgEstudiante.Rows.Add(coincidencias - 1);
                
                // Llenar con los registros filtrados
                int fila = 0;
                for (int i = 0; i < contador; i++)
                {
                    string carnet = dt.Rows[i][0].ToString().ToLower();
                    string nombre = dt.Rows[i][1].ToString().ToLower();
                    
                    if (carnet.Contains(filtro.ToLower()) || nombre.Contains(filtro.ToLower()))
                    {
                        dtgEstudiante.Rows[fila].Cells[0].Value = dt.Rows[i][0];
                        dtgEstudiante.Rows[fila].Cells[1].Value = dt.Rows[i][1];
                        dtgEstudiante.Rows[fila].Cells[2].Value = dt.Rows[i][3];
                        dtgEstudiante.Rows[fila].Cells[3].Value = dt.Rows[i][2];
                        fila++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar estudiantes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarDatosAExcel();
        }
        
        private void ExportarDatosAExcel()
        {
            if (dtgEstudiante.Rows.Count > 0)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Archivos Excel (*.xlsx)|*.xlsx";
                saveDialog.Title = "Guardar Listado de Estudiantes";
                saveDialog.FileName = "Listado_Estudiantes_" + DateTime.Now.ToString("yyyyMMdd");

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
