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
            NroPrestamo();

            // Add a new button to select books
            Button btnSeleccionarLibro = new Button();
            btnSeleccionarLibro.Text = "Buscar Libros";
            btnSeleccionarLibro.Location = new Point(btnBorrarLibro.Location.X - 110, btnBorrarLibro.Location.Y);
            btnSeleccionarLibro.Size = btnBorrarLibro.Size;
            btnSeleccionarLibro.Click += new EventHandler(btnSeleccionarLibro_Click);
            this.Controls.Add(btnSeleccionarLibro);
        }

        void NroPrestamo()
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
        }

        // New method to display book selection dialog
        private void btnSeleccionarLibro_Click(object sender, EventArgs e)
        {
            // Create form to show available books
            Form frmLibros = new Form();
            frmLibros.Text = "Seleccionar Libro";
            frmLibros.Size = new Size(600, 400);
            frmLibros.StartPosition = FormStartPosition.CenterParent;

            DataGridView dgvLibros = new DataGridView();
            dgvLibros.Dock = DockStyle.Fill;
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.ReadOnly = true;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            frmLibros.Controls.Add(dgvLibros);

            // Get available books from database
            cmd = new SqlCommand("SELECT ISBN, titulo, cantidad FROM tblLibro WHERE cantidad > " +
                "(SELECT COUNT(*) FROM tblDetallePrestamo WHERE ISBN = tblLibro.ISBN AND Entregado = 0)", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);

            dgvLibros.DataSource = dt;

            Button btnSeleccionar = new Button();
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.DialogResult = DialogResult.OK;
            btnSeleccionar.Dock = DockStyle.Bottom;
            frmLibros.Controls.Add(btnSeleccionar);

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

                    if (dt.Rows.Count > 0)
                    {
                        int cant = Convert.ToInt32(dt.Rows[0]["cantidad"]);
                        dtgPrestamo.Rows[e.RowIndex].Cells[1].Value = dt.Rows[0][0];
                        dtgPrestamo.Rows[e.RowIndex].Cells[2].Value = nuevaFecha.ToString("dd/MM/yyyy");

                        comd = new SqlCommand("SELECT COUNT(*) FROM tblDetallePrestamo WHERE ISBN = @isbn AND devuelto = 0", cn.AbrirConexion());
                        comd.Parameters.AddWithValue("@isbn", dtgPrestamo.Rows[e.RowIndex].Cells[0].Value);
                        int cantidadPrestamos = Convert.ToInt32(comd.ExecuteScalar());

                        if (cantidadPrestamos >= cant)
                        {
                            MessageBox.Show("No puedes hacer el préstamo, el título no está disponible");
                            dtgPrestamo.Rows[e.RowIndex].Cells[3].Value = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El ISBN ingresado no existe en la base de datos");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
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
                cmd = new SqlCommand("SELECT * FROM tblEstudiante WHERE carnet = @carnet", cn.AbrirConexion());
                cmd.Parameters.AddWithValue("@carnet", txtCarnet.Text);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

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

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}