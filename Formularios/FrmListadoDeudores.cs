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
using Clase2.Clases;

namespace Clase2.Formularios
{
    public partial class FrmListadoDeudores : Form
    {
        private cConexion conexion = new cConexion();
        private SqlCommand comando = new SqlCommand();
        private SqlDataAdapter adaptador = new SqlDataAdapter();
        private DataTable tabla = new DataTable();

        public FrmListadoDeudores()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            ConfigurarControles();
        }

        private void ConfigurarControles()
        {
            // Panel de título con aspecto visual mejorado
            panelTitulo.BackColor = Color.RoyalBlue;
            lblTitulo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;

            // Panel de botones con aspecto visual mejorado
            panelBotones.BackColor = Color.LightSteelBlue;
            
            // Aplicar estilo a los botones
            btnExportar.BackColor = Color.ForestGreen;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.FlatAppearance.BorderSize = 0;
            btnExportar.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnExportar.ForeColor = Color.White;
            
            btnFiltrar.BackColor = Color.DodgerBlue;
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.FlatAppearance.BorderSize = 0;
            btnFiltrar.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnFiltrar.ForeColor = Color.White;
            
            btnSalir.BackColor = Color.Firebrick;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnSalir.ForeColor = Color.White;
            
            // Estilo del DataGridView
            FormatearDataGridView();
            
            // Configuración de controles de filtro
            groupBoxFiltros.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            
            // Configurar DateTimePickers
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            
            // Establecer fecha de inicio a 30 días atrás y fin a hoy
            dtpFechaInicio.Value = DateTime.Now.AddDays(-30);
            dtpFechaFin.Value = DateTime.Now;
            
            // Checkbox
            chkSoloActivos.Checked = true;
        }

        private void FormatearDataGridView()
        {
            // Establecer colores para mejorar visibilidad
            dgvDeudores.EnableHeadersVisualStyles = false;
            dgvDeudores.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dgvDeudores.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDeudores.ColumnHeadersDefaultCellStyle.Font = new Font(dgvDeudores.Font, FontStyle.Bold);
            dgvDeudores.RowHeadersVisible = false;
            dgvDeudores.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgvDeudores.DefaultCellStyle.SelectionBackColor = Color.RoyalBlue;
            dgvDeudores.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDeudores.BorderStyle = BorderStyle.Fixed3D;
            dgvDeudores.BackgroundColor = Color.WhiteSmoke;
            dgvDeudores.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvDeudores.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvDeudores.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvDeudores.ColumnHeadersHeight = 35;
            
            // Establecer propiedades del DataGridView
            dgvDeudores.ReadOnly = true;
            dgvDeudores.AllowUserToAddRows = false;
            dgvDeudores.AllowUserToDeleteRows = false;
            dgvDeudores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void FrmListadoDeudores_Load(object sender, EventArgs e)
        {
            CargarDeudores();
        }

        private void CargarDeudores()
        {
            try
            {
                tabla.Clear();
                comando.Connection = conexion.AbrirConexion();
                string consulta = @"SELECT e.IdEstudiante, e.Carnet, e.Nombre, e.Apellido, p.NroPrestamo, 
                                   l.ISBN, l.Titulo, p.FechaPrestamo, dp.FechaEntrega, 
                                   DATEDIFF(day, dp.FechaEntrega, GETDATE()) AS DiasAtraso,
                                   CAST(DATEDIFF(day, dp.FechaEntrega, GETDATE()) * 5 AS decimal(10,2)) AS MontoDeuda
                                   FROM tblEstudiante e
                                   INNER JOIN tblPrestamo p ON e.Carnet = p.Carnet
                                   INNER JOIN tblDetallePrestamo dp ON p.NroPrestamo = dp.NroPrestamo
                                   INNER JOIN tblLibro l ON dp.ISBN = l.ISBN
                                   WHERE dp.Entregado = 0 AND GETDATE() > dp.FechaEntrega";
                
                if (chkSoloActivos.Checked)
                {
                    consulta += " AND e.Estado = 1";
                }
                
                if (dtpFechaInicio.Value <= dtpFechaFin.Value)
                {
                    consulta += " AND p.FechaPrestamo BETWEEN @fechaInicio AND @fechaFin";
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@fechaInicio", dtpFechaInicio.Value.ToString("yyyy-MM-dd"));
                    comando.Parameters.AddWithValue("@fechaFin", dtpFechaFin.Value.ToString("yyyy-MM-dd"));
                }
                
                consulta += " ORDER BY DiasAtraso DESC";
                
                comando.CommandText = consulta;
                comando.CommandType = CommandType.Text;
                adaptador.SelectCommand = comando;
                adaptador.Fill(tabla);
                
                dgvDeudores.DataSource = tabla;
                
                // Formatear columnas del DataGridView
                FormateaColumnas();
                
                // Actualizar estadísticas
                ActualizarEstadisticas();
                
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los deudores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormateaColumnas()
        {
            if (dgvDeudores.Columns.Count > 0)
            {
                dgvDeudores.Columns["IdEstudiante"].Visible = false;
                
                dgvDeudores.Columns["Carnet"].HeaderText = "Carnet";
                dgvDeudores.Columns["Carnet"].Width = 80;
                
                dgvDeudores.Columns["Nombre"].HeaderText = "Nombre";
                dgvDeudores.Columns["Nombre"].Width = 120;
                
                dgvDeudores.Columns["Apellido"].HeaderText = "Apellido";
                dgvDeudores.Columns["Apellido"].Width = 120;
                
                dgvDeudores.Columns["NroPrestamo"].HeaderText = "# Préstamo";
                dgvDeudores.Columns["NroPrestamo"].Width = 90;
                
                dgvDeudores.Columns["ISBN"].HeaderText = "ISBN";
                dgvDeudores.Columns["ISBN"].Width = 100;
                
                dgvDeudores.Columns["Titulo"].HeaderText = "Título";
                dgvDeudores.Columns["Titulo"].Width = 200;
                
                dgvDeudores.Columns["FechaPrestamo"].HeaderText = "Fecha Préstamo";
                dgvDeudores.Columns["FechaPrestamo"].Width = 110;
                dgvDeudores.Columns["FechaPrestamo"].DefaultCellStyle.Format = "dd/MM/yyyy";
                
                dgvDeudores.Columns["FechaEntrega"].HeaderText = "Fecha Entrega";
                dgvDeudores.Columns["FechaEntrega"].Width = 110;
                dgvDeudores.Columns["FechaEntrega"].DefaultCellStyle.Format = "dd/MM/yyyy";
                
                dgvDeudores.Columns["DiasAtraso"].HeaderText = "Días Atraso";
                dgvDeudores.Columns["DiasAtraso"].Width = 90;
                dgvDeudores.Columns["DiasAtraso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
                dgvDeudores.Columns["MontoDeuda"].HeaderText = "Deuda ($)";
                dgvDeudores.Columns["MontoDeuda"].Width = 90;
                dgvDeudores.Columns["MontoDeuda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDeudores.Columns["MontoDeuda"].DefaultCellStyle.Format = "N2";
                
                // Colorear filas según días de atraso
                foreach (DataGridViewRow row in dgvDeudores.Rows)
                {
                    int diasAtraso = Convert.ToInt32(row.Cells["DiasAtraso"].Value);
                    if (diasAtraso > 30)
                    {
                        row.DefaultCellStyle.BackColor = Color.MistyRose;
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                    else if (diasAtraso > 15)
                    {
                        row.DefaultCellStyle.BackColor = Color.PeachPuff;
                    }
                }
            }
        }

        private void ActualizarEstadisticas()
        {
            if (dgvDeudores.Rows.Count > 0)
            {
                int totalDeudores = tabla.AsEnumerable()
                                        .Select(r => r.Field<int>("IdEstudiante"))
                                        .Distinct()
                                        .Count();
                
                int totalLibros = tabla.Rows.Count;
                
                decimal totalDeuda = tabla.AsEnumerable()
                                         .Sum(r => r.Field<decimal>("MontoDeuda"));
                
                lblTotalDeudores.Text = totalDeudores.ToString();
                lblTotalLibros.Text = totalLibros.ToString();
                lblTotalDeuda.Text = totalDeuda.ToString("C2");
            }
            else
            {
                lblTotalDeudores.Text = "0";
                lblTotalLibros.Text = "0";
                lblTotalDeuda.Text = "$0.00";
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarDeudores();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDeudores.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivo CSV (*.csv)|*.csv";
                saveFileDialog.Title = "Guardar Reporte de Deudores";
                saveFileDialog.FileName = "Reporte_Deudores_" + DateTime.Now.ToString("yyyyMMdd");

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();
                    
                    // Encabezados
                    string[] encabezados = new string[dgvDeudores.Columns.Count];
                    for (int i = 0; i < dgvDeudores.Columns.Count; i++)
                    {
                        encabezados[i] = dgvDeudores.Columns[i].HeaderText;
                    }
                    sb.AppendLine(string.Join(",", encabezados));
                    
                    // Datos
                    foreach (DataGridViewRow row in dgvDeudores.Rows)
                    {
                        string[] campos = new string[dgvDeudores.Columns.Count];
                        for (int i = 0; i < dgvDeudores.Columns.Count; i++)
                        {
                            if (row.Cells[i].Value != null)
                            {
                                campos[i] = row.Cells[i].Value.ToString().Replace(",", ";");
                            }
                            else
                            {
                                campos[i] = "";
                            }
                        }
                        sb.AppendLine(string.Join(",", campos));
                    }
                    
                    System.IO.File.WriteAllText(saveFileDialog.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Reporte exportado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha final", 
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFechaInicio.Value = dtpFechaFin.Value.AddDays(-30);
            }
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaFin.Value < dtpFechaInicio.Value)
            {
                MessageBox.Show("La fecha final no puede ser anterior a la fecha de inicio", 
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFechaFin.Value = DateTime.Now;
            }
        }
    }
} 