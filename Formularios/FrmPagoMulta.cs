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
    public partial class FrmPagoMulta : Form
    {
        private cConexion conexion = new cConexion();
        private SqlCommand comando = new SqlCommand();
        private SqlDataAdapter adaptador = new SqlDataAdapter();
        private DataTable tabla = new DataTable();

        public FrmPagoMulta()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            CargarMultasPendientes();
        }

        private void FrmPagoMulta_Load(object sender, EventArgs e)
        {
            CargarMultasPendientes();
        }

        // Método para cargar las multas pendientes en el DataGridView
        private void CargarMultasPendientes()
        {
            try
            {
                tabla.Clear();
                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "SELECT m.IdMulta, e.Nombre, e.Apellido, l.Titulo, m.FechaMulta, m.Monto, " +
                                    "m.Estado, m.Descripcion FROM Multas m " +
                                    "INNER JOIN Estudiantes e ON m.IdEstudiante = e.IdEstudiante " +
                                    "INNER JOIN Libros l ON m.IdLibro = l.IdLibro " +
                                    "WHERE m.Estado = 'Pendiente'";
                comando.CommandType = CommandType.Text;
                adaptador.SelectCommand = comando;
                adaptador.Fill(tabla);
                dgvMultas.DataSource = tabla;
                FormatearDataGridView();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar multas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para formatear el DataGridView y hacerlo más visible
        private void FormatearDataGridView()
        {
            dgvMultas.Columns["IdMulta"].HeaderText = "ID";
            dgvMultas.Columns["Nombre"].HeaderText = "Nombre";
            dgvMultas.Columns["Apellido"].HeaderText = "Apellido";
            dgvMultas.Columns["Titulo"].HeaderText = "Libro";
            dgvMultas.Columns["FechaMulta"].HeaderText = "Fecha";
            dgvMultas.Columns["Monto"].HeaderText = "Monto";
            dgvMultas.Columns["Estado"].HeaderText = "Estado";
            dgvMultas.Columns["Descripcion"].HeaderText = "Descripción";

            // Ajustar el ancho de las columnas
            dgvMultas.Columns["IdMulta"].Width = 50;
            dgvMultas.Columns["Nombre"].Width = 120;
            dgvMultas.Columns["Apellido"].Width = 120;
            dgvMultas.Columns["Titulo"].Width = 200;
            dgvMultas.Columns["FechaMulta"].Width = 80;
            dgvMultas.Columns["Monto"].Width = 80;
            dgvMultas.Columns["Estado"].Width = 80;
            dgvMultas.Columns["Descripcion"].Width = 200;

            // Establecer colores para mejorar visibilidad
            dgvMultas.EnableHeadersVisualStyles = false;
            dgvMultas.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dgvMultas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMultas.ColumnHeadersDefaultCellStyle.Font = new Font(dgvMultas.Font, FontStyle.Bold);
            dgvMultas.RowHeadersVisible = false;
            dgvMultas.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dgvMultas.DefaultCellStyle.SelectionBackColor = Color.RoyalBlue;
            dgvMultas.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvMultas.BorderStyle = BorderStyle.Fixed3D;
        }

        // Método para pagar una multa
        private void PagarMulta()
        {
            try
            {
                if (dgvMultas.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una multa para pagar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int idMulta = Convert.ToInt32(dgvMultas.CurrentRow.Cells["IdMulta"].Value);
                string estudiante = dgvMultas.CurrentRow.Cells["Nombre"].Value.ToString() + " " + 
                                  dgvMultas.CurrentRow.Cells["Apellido"].Value.ToString();
                decimal monto = Convert.ToDecimal(dgvMultas.CurrentRow.Cells["Monto"].Value);

                if (decimal.Parse(txtMontoPagado.Text) < monto)
                {
                    MessageBox.Show("El monto pagado debe ser igual o mayor al monto de la multa", "Aviso", 
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                comando.Connection = conexion.AbrirConexion();
                comando.CommandText = "UPDATE Multas SET Estado = 'Pagada', FechaPago = @FechaPago " +
                                    "WHERE IdMulta = @IdMulta";
                comando.CommandType = CommandType.Text;
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@FechaPago", DateTime.Now);
                comando.Parameters.AddWithValue("@IdMulta", idMulta);
                comando.ExecuteNonQuery();

                // Registrar el pago en la tabla de pagos
                comando.CommandText = "INSERT INTO Pagos (IdMulta, FechaPago, MontoPagado, Observaciones) " +
                                    "VALUES (@IdMulta, @FechaPago, @MontoPagado, @Observaciones)";
                comando.Parameters.AddWithValue("@MontoPagado", decimal.Parse(txtMontoPagado.Text));
                comando.Parameters.AddWithValue("@Observaciones", txtObservaciones.Text);
                comando.ExecuteNonQuery();

                MessageBox.Show($"Multa de {estudiante} pagada con éxito", "Pago realizado", 
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarMultasPendientes();
                conexion.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al pagar multa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtEstudiante.Text = "";
            txtLibro.Text = "";
            txtMonto.Text = "";
            txtMontoPagado.Text = "";
            txtObservaciones.Text = "";
        }

        private void dgvMultas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMultas.CurrentRow != null)
            {
                txtEstudiante.Text = dgvMultas.CurrentRow.Cells["Nombre"].Value.ToString() + " " +
                                    dgvMultas.CurrentRow.Cells["Apellido"].Value.ToString();
                txtLibro.Text = dgvMultas.CurrentRow.Cells["Titulo"].Value.ToString();
                txtMonto.Text = dgvMultas.CurrentRow.Cells["Monto"].Value.ToString();
                txtMontoPagado.Text = dgvMultas.CurrentRow.Cells["Monto"].Value.ToString();
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            decimal montoPagado;
            if (string.IsNullOrEmpty(txtMontoPagado.Text) || !decimal.TryParse(txtMontoPagado.Text, out montoPagado))
            {
                MessageBox.Show("Ingrese un monto válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PagarMulta();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMontoPagado_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números, punto decimal y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
} 