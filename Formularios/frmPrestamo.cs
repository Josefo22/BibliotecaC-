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
    public partial class frmPrestamo : Form
    {
        cConexion cn;
        SqlDataAdapter da;
        SqlCommand cmd, comd;
        DataTable dt;
        int contador;

        public frmPrestamo()
        {
            InitializeComponent();
            cn = new cConexion();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            FormatearDataGridView();
            ConfigurarControles();
            NroPrestamo();
        }

        private void ConfigurarControles()
        {
            // Panel de título con aspecto visual mejorado
            panelTitulo.BackColor = Color.RoyalBlue;
            lblPrestamo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblPrestamo.ForeColor = Color.White;

            // Panel de botones con aspecto visual mejorado
            panelBotones.BackColor = Color.LightSteelBlue;
            
            // Aplicar estilo a los botones
            btnGuardar.BackColor = Color.ForestGreen;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            
            btnNuevo.BackColor = Color.DodgerBlue;
            btnNuevo.FlatStyle = FlatStyle.Flat;
            btnNuevo.FlatAppearance.BorderSize = 0;
            btnNuevo.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            
            btnBorrarLibro.BackColor = Color.Firebrick;
            btnBorrarLibro.FlatStyle = FlatStyle.Flat;
            btnBorrarLibro.FlatAppearance.BorderSize = 0;
            btnBorrarLibro.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnBorrarLibro.ForeColor = Color.White;
            
            btnSeleccionarLibro.BackColor = Color.DarkOrange;
            btnSeleccionarLibro.FlatStyle = FlatStyle.Flat;
            btnSeleccionarLibro.FlatAppearance.BorderSize = 0;
            btnSeleccionarLibro.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnSeleccionarLibro.ForeColor = Color.White;
            
            // Configurar campos de texto
            txtCarnet.BorderStyle = BorderStyle.FixedSingle;
            txtCarnet.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtNombre.ReadOnly = true;
            
            // Configurar etiquetas
            lblCarnet.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            lblNombre.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            
            // Configurar panel de información
            panel1.BackColor = Color.AliceBlue;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            
            // Configurar fecha
            dttFechaPrestamo.Format = DateTimePickerFormat.Short;
            dttFechaPrestamo.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            
            // Información del préstamo
            groupBoxInfo.BackColor = Color.White;
            groupBoxInfo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        void NroPrestamo()
        {
            try
            {
                cmd = new SqlCommand("select * from tblPrestamo", cn.AbrirConexion());
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    contador = dt.Rows.Count + 1;
                    lblNroPrestamo.Text = contador.ToString();
                }
                else
                {
                    lblNroPrestamo.Text = "1";
                }
                cn.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener número de préstamo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearDataGridView()
        {
            // Establecer colores para mejorar visibilidad
            dtgPrestamo.EnableHeadersVisualStyles = false;
            dtgPrestamo.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dtgPrestamo.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dtgPrestamo.ColumnHeadersDefaultCellStyle.Font = new Font(dtgPrestamo.Font, FontStyle.Bold);
            dtgPrestamo.RowHeadersVisible = false;
            dtgPrestamo.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            dtgPrestamo.DefaultCellStyle.SelectionBackColor = Color.RoyalBlue;
            dtgPrestamo.DefaultCellStyle.SelectionForeColor = Color.White;
            dtgPrestamo.BorderStyle = BorderStyle.Fixed3D;
            dtgPrestamo.BackgroundColor = Color.WhiteSmoke;
            dtgPrestamo.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dtgPrestamo.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dtgPrestamo.CellBorderStyle = DataGridViewCellBorderStyle.Single;
        }

        // Método para manejar el botón de selección de libros
        private void btnSeleccionarLibro_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear formulario para mostrar libros disponibles
                Form frmLibros = new Form();
                frmLibros.Text = "Seleccionar Libro";
                frmLibros.Size = new Size(700, 500);
                frmLibros.StartPosition = FormStartPosition.CenterParent;
                frmLibros.BackColor = Color.White;
                frmLibros.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmLibros.MaximizeBox = false;
                frmLibros.MinimizeBox = false;

                // Crear panel de título para el formulario
                Panel pnlTitulo = new Panel();
                pnlTitulo.Dock = DockStyle.Top;
                pnlTitulo.BackColor = Color.RoyalBlue;
                pnlTitulo.Height = 60;
                
                Label lblTitulo = new Label();
                lblTitulo.Text = "SELECCIÓN DE LIBROS";
                lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                lblTitulo.ForeColor = Color.White;
                lblTitulo.AutoSize = true;
                lblTitulo.Location = new Point(20, 15);
                
                pnlTitulo.Controls.Add(lblTitulo);
                frmLibros.Controls.Add(pnlTitulo);

                // Crear DataGridView para mostrar libros
                DataGridView dgvLibros = new DataGridView();
                dgvLibros.Location = new Point(20, 80);
                dgvLibros.Size = new Size(650, 320);
                dgvLibros.AllowUserToAddRows = false;
                dgvLibros.ReadOnly = true;
                dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvLibros.BackgroundColor = Color.WhiteSmoke;
                dgvLibros.BorderStyle = BorderStyle.Fixed3D;
                dgvLibros.RowHeadersVisible = false;
                dgvLibros.AllowUserToResizeRows = false;
                dgvLibros.AllowUserToResizeColumns = false;
                dgvLibros.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
                dgvLibros.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvLibros.ColumnHeadersDefaultCellStyle.Font = new Font(dgvLibros.Font, FontStyle.Bold);
                dgvLibros.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
                dgvLibros.EnableHeadersVisualStyles = false;
                
                frmLibros.Controls.Add(dgvLibros);

                // Crear panel de botones
                Panel pnlBotones = new Panel();
                pnlBotones.Dock = DockStyle.Bottom;
                pnlBotones.BackColor = Color.LightSteelBlue;
                pnlBotones.Height = 60;
                
                Button btnSeleccionar = new Button();
                btnSeleccionar.Text = "SELECCIONAR";
                btnSeleccionar.DialogResult = DialogResult.OK;
                btnSeleccionar.BackColor = Color.ForestGreen;
                btnSeleccionar.ForeColor = Color.White;
                btnSeleccionar.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                btnSeleccionar.FlatStyle = FlatStyle.Flat;
                btnSeleccionar.FlatAppearance.BorderSize = 0;
                btnSeleccionar.Size = new Size(150, 40);
                btnSeleccionar.Location = new Point(520, 10);
                
                Button btnCancelar = new Button();
                btnCancelar.Text = "CANCELAR";
                btnCancelar.DialogResult = DialogResult.Cancel;
                btnCancelar.BackColor = Color.Firebrick;
                btnCancelar.ForeColor = Color.White;
                btnCancelar.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                btnCancelar.FlatStyle = FlatStyle.Flat;
                btnCancelar.FlatAppearance.BorderSize = 0;
                btnCancelar.Size = new Size(150, 40);
                btnCancelar.Location = new Point(350, 10);
                
                pnlBotones.Controls.Add(btnSeleccionar);
                pnlBotones.Controls.Add(btnCancelar);
                frmLibros.Controls.Add(pnlBotones);

                // Obtener libros disponibles
                cmd = new SqlCommand("SELECT ISBN, titulo, cantidad FROM tblLibro WHERE cantidad > " +
                    "(SELECT COUNT(*) FROM tblDetallePrestamo WHERE ISBN = tblLibro.ISBN AND Entregado = 0)", cn.AbrirConexion());
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                dgvLibros.DataSource = dt;
                cn.CerrarConexion();

                if (frmLibros.ShowDialog() == DialogResult.OK && dgvLibros.SelectedRows.Count > 0)
                {
                    DateTime fechaSeleccionada = dttFechaPrestamo.Value;
                    DateTime nuevaFecha = fechaSeleccionada.AddDays(15);

                    int rowIdx = dtgPrestamo.Rows.Add();
                    dtgPrestamo.Rows[rowIdx].Cells[0].Value = dgvLibros.SelectedRows[0].Cells["ISBN"].Value.ToString();
                    dtgPrestamo.Rows[rowIdx].Cells[1].Value = dgvLibros.SelectedRows[0].Cells["titulo"].Value.ToString();
                    dtgPrestamo.Rows[rowIdx].Cells[2].Value = nuevaFecha.ToString("dd/MM/yyyy");
                    dtgPrestamo.Rows[rowIdx].Cells[3].Value = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar libro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgPrestamo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgPrestamo.Columns[e.ColumnIndex].Name == "ISBN")
            {
                try
                {
                    DateTime fechaSeleccionada = dttFechaPrestamo.Value;
                    DateTime nuevaFecha = fechaSeleccionada.AddDays(15);

                    cmd = new SqlCommand("SELECT titulo, cantidad FROM tblLibro WHERE ISBN = @isbn", cn.AbrirConexion());
                    cmd.Parameters.AddWithValue("@isbn", dtgPrestamo.Rows[e.RowIndex].Cells[0].Value);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    cn.CerrarConexion();

                    if (dt.Rows.Count > 0)
                    {
                        int cant = Convert.ToInt32(dt.Rows[0]["cantidad"]);
                        dtgPrestamo.Rows[e.RowIndex].Cells[1].Value = dt.Rows[0][0];
                        dtgPrestamo.Rows[e.RowIndex].Cells[2].Value = nuevaFecha.ToString("dd/MM/yyyy");

                        comd = new SqlCommand("SELECT COUNT(*) FROM tblDetallePrestamo WHERE ISBN = @isbn AND devuelto = 0", cn.AbrirConexion());
                        comd.Parameters.AddWithValue("@isbn", dtgPrestamo.Rows[e.RowIndex].Cells[0].Value);
                        int cantidadPrestamos = Convert.ToInt32(comd.ExecuteScalar());
                        cn.CerrarConexion();

                        if (cantidadPrestamos >= cant)
                        {
                            MessageBox.Show("No puedes hacer el préstamo, el título no está disponible", "Aviso", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dtgPrestamo.Rows[e.RowIndex].Cells[3].Value = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El ISBN ingresado no existe en la base de datos", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dtgPrestamo.SelectedRows.Count > 0)
            {
                int posicionFila = dtgPrestamo.SelectedRows[0].Index;
                dtgPrestamo.Rows.RemoveAt(posicionFila);
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna fila", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCarnet.Text))
                {
                    MessageBox.Show("Debe ingresar el carnet del estudiante", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtgPrestamo.Rows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar al menos un libro para préstamo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Begin transaction to ensure all data is saved correctly
                SqlConnection conn = cn.AbrirConexion();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    cmd = new SqlCommand("INSERT INTO tblPrestamo VALUES(@carnet, @fecha)", conn, transaction);
                    cmd.Parameters.AddWithValue("@carnet", txtCarnet.Text);
                    cmd.Parameters.AddWithValue("@fecha", dttFechaPrestamo.Value.ToString("yyyy-MM-dd"));
                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < dtgPrestamo.Rows.Count; i++)
                    {
                        if (dtgPrestamo.Rows[i].Cells[0].Value != null)
                        {
                            comd = new SqlCommand("INSERT INTO tblDetallePrestamo VALUES(@nroPrestamo, @isbn, @fechaEntrega, 0, 0)", conn, transaction);
                            comd.Parameters.AddWithValue("@nroPrestamo", lblNroPrestamo.Text);
                            comd.Parameters.AddWithValue("@isbn", dtgPrestamo.Rows[i].Cells[0].Value.ToString());
                            comd.Parameters.AddWithValue("@fechaEntrega", Convert.ToDateTime(dtgPrestamo.Rows[i].Cells[2].Value));
                            comd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Préstamo guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGuardar.Enabled = false;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error al guardar el préstamo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cn.CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCarnet_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCarnet.Text))
            {
                try
                {
                    cmd = new SqlCommand("SELECT * FROM tblEstudiante WHERE carnet = @carnet", cn.AbrirConexion());
                    cmd.Parameters.AddWithValue("@carnet", txtCarnet.Text);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    cn.CerrarConexion();

                    if (dt.Rows.Count > 0)
                    {
                        txtNombre.Text = dt.Rows[0][1].ToString();
                        btnGuardar.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("El estudiante no existe en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCarnet.Clear();
                        txtNombre.Clear();
                        txtCarnet.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar estudiante: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            txtCarnet.Clear();
            txtNombre.Clear();
            dtgPrestamo.Rows.Clear();
            NroPrestamo(); // Update loan number
            txtCarnet.Focus();
        }

        private void frmPrestamo_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
        }
    }
}