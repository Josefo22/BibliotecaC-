using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using Clase2.Clases;

namespace Clase2.Formularios
{
    public partial class fmInformePrestamo : Form
    {
        private cConexion cn;

        public fmInformePrestamo()
        {
            InitializeComponent();
            int DiasMora, multa = 0;
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            SqlDataAdapter adapter = new SqlDataAdapter();
            cn = new cConexion();
            
            // Configurar el diseño moderno
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
            panelTitulo.BackColor = Color.MediumPurple;
            lblPrestamoEstudiante.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblPrestamoEstudiante.ForeColor = Color.White;
            
            // Panel de búsqueda
            panelBusqueda.BackColor = Color.Lavender;
            panelBusqueda.BorderStyle = BorderStyle.FixedSingle;
            
            // Panel de datos
            panelDatos.BackColor = Color.WhiteSmoke;
            panelDatos.BorderStyle = BorderStyle.FixedSingle;
            
            // Configuración de etiquetas
            ConfigurarEtiqueta(lblCarnet);
            ConfigurarEtiqueta(lblNombre);
            ConfigurarEtiqueta(lblFecha);
            
            // Configuración de textboxes
            ConfigurarCajaTexto(txtCarnet);
            ConfigurarCajaTexto(txtNombre);
            
            // Configuración del DataGridView
            ConfigurarDataGridView(dtgEstudiantes);
            
            // Configuración de botones
            ConfigurarBoton(btnExportar, Color.ForestGreen);
            ConfigurarBoton(btnVencidos, Color.Crimson);
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
        
        private void ConfigurarDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumPurple;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 35;
            dgv.RowTemplate.Height = 30;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(233, 236, 250);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
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

        public class cConexion
        {
            private string connectionString;

            public cConexion()
            {
                // Set a default connection string here
                connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ASUS\\Desktop\\InCode\\Clase2POO\\Clase2\\bdBiblioteca.mdf;Integrated Security=True;Connect Timeout=30";
                // Or load it from configuration
            }

            public SqlConnection AbrirConexion()
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
        }

        private void fmInformePrestamo_Load(object sender, EventArgs e)
        {
            // Cargar la lista de estudiantes al iniciar el formulario
            CargarEstudiantes();
        }

        #region Métodos de Estudiantes
        private void CargarEstudiantes()
        {
            try
            {
                string query = "SELECT carnet, nombre FROM tblEstudiante";
                using (SqlConnection connection = cn.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dtgEstudiantes.DataSource = dt;
                    ConfigurarColumnasEstudiantes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estudiantes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasEstudiantes()
        {
            try
            {
                // Configurar el DataGridView de estudiantes
                if (dtgEstudiantes.Columns.Count > 0)
                {
                    if (dtgEstudiantes.Columns.Contains("carnet"))
                        dtgEstudiantes.Columns["carnet"].HeaderText = "Carnet";
                    if (dtgEstudiantes.Columns.Contains("nombre"))
                        dtgEstudiantes.Columns["nombre"].HeaderText = "Nombre";
                    dtgEstudiantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dtgEstudiantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al configurar columnas de estudiantes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarEstudiantesPorCarnet(string carnetParcial)
        {
            try
            {
                string query = "SELECT carnet, nombre FROM tblEstudiante WHERE carnet LIKE @carnet";
                using (SqlConnection connection = cn.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@carnet", "%" + carnetParcial + "%");
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dtgEstudiantes.DataSource = dt;
                        ConfigurarColumnasEstudiantes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar estudiantes: " + ex.Message,
                    "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarEstudiantesPorNombre(string nombreParcial)
        {
            try
            {
                string query = "SELECT carnet, nombre FROM tblEstudiante WHERE nombre LIKE @nombre";
                using (SqlConnection connection = cn.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@nombre", "%" + nombreParcial + "%");
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dtgEstudiantes.DataSource = dt;
                        ConfigurarColumnasEstudiantes();

                        if (dt.Rows.Count == 0)
                        {
                            // Mostrar notificación discreta
                            MessageBox.Show("No se encontraron estudiantes con ese nombre.",
                                "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar estudiantes por nombre: " + ex.Message,
                    "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgEstudiantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgEstudiantes.Rows[e.RowIndex];
                string carnet = row.Cells["carnet"].Value.ToString();
                string nombre = row.Cells["nombre"].Value.ToString();

                txtCarnet.Text = carnet;

                // Cargar los libros del estudiante seleccionado
                CargarLibrosPorEstudiante(carnet, nombre);
            }
        }
        #endregion

        #region Métodos de Libros
        private void CargarLibrosPorCarnet(string carnet)
        {
            string query = @"SELECT l.ISBN, l.titulo, l.autor, d.FechaEntrega
                          FROM tblPrestamo p
                          INNER JOIN tblDetallePrestamo d ON p.IdPrestamo = d.IdPrestamo
                          INNER JOIN tblLibro l ON d.ISBN = l.ISBN
                          WHERE p.carnet = @carnet";
            try
            {
                using (SqlConnection connection = cn.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@carnet", carnet);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Limpiar la tabla antes de asignar nuevos datos
                        dtgEstudiantes.DataSource = null;
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No tiene préstamos.",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            dtgEstudiantes.DataSource = dt;
                            ConfigurarColumnasLibro();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar los préstamos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarLibrosPorEstudiante(string carnet, string nombre)
        {
            try
            {
                string query = @"SELECT l.ISBN, l.titulo, l.autor, d.FechaEntrega,
                            CASE WHEN d.FechaDevolucion IS NOT NULL THEN 'Sí' ELSE 'No' END AS Entregado
                            FROM tblPrestamo p 
                            INNER JOIN tblDetallePrestamo d ON p.IdPrestamo = d.IdPrestamo
                            INNER JOIN tblLibro l ON d.ISBN = l.ISBN
                            WHERE p.carnet = @carnet";

                using (SqlConnection connection = cn.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@carnet", carnet);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Limpiar y actualizar el DataGridView
                        dtgEstudiantes.DataSource = dt;

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show($"El estudiante {nombre} (Carnet: {carnet}) no tiene préstamos activos.",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            ConfigurarColumnasLibro();

                            // Mostrar resumen de préstamos
                            MessageBox.Show($"Se encontraron {dt.Rows.Count} préstamos para el estudiante {nombre}.",
                                "Préstamos Encontrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los préstamos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasLibro()
        {
            try
            {
                // Configurar el DataGridView de libros
                if (dtgEstudiantes.Columns.Count > 0)
                {
                    if (dtgEstudiantes.Columns.Contains("ISBN"))
                        dtgEstudiantes.Columns["ISBN"].HeaderText = "ISBN";
                    if (dtgEstudiantes.Columns.Contains("titulo"))
                        dtgEstudiantes.Columns["titulo"].HeaderText = "Título";
                    if (dtgEstudiantes.Columns.Contains("autor"))
                        dtgEstudiantes.Columns["autor"].HeaderText = "Autor";
                    if (dtgEstudiantes.Columns.Contains("FechaEntrega"))
                        dtgEstudiantes.Columns["FechaEntrega"].HeaderText = "Fecha de Entrega";
                    if (dtgEstudiantes.Columns.Contains("Entregado"))
                        dtgEstudiantes.Columns["Entregado"].HeaderText = "Entregado";

                    dtgEstudiantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dtgEstudiantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al configurar columnas de libros: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgLibro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgEstudiantes.Rows[e.RowIndex];

                // Verificar si estamos mostrando la lista de libros (tienen la columna ISBN)
                if (dtgEstudiantes.Columns.Contains("ISBN"))
                {
                    string isbn = row.Cells["ISBN"].Value.ToString();
                    string titulo = row.Cells["titulo"].Value.ToString();
                    string autor = row.Cells["autor"].Value.ToString();

                    // Verificar si la fecha de entrega existe y no es nula
                    DateTime fechaEntrega = DateTime.Now;
                    bool fechaValida = false;

                    if (dtgEstudiantes.Columns.Contains("FechaEntrega") &&
                        row.Cells["FechaEntrega"].Value != null &&
                        row.Cells["FechaEntrega"].Value != DBNull.Value)
                    {
                        fechaEntrega = Convert.ToDateTime(row.Cells["FechaEntrega"].Value);
                        fechaValida = true;
                    }

                    // Mostrar información detallada del libro seleccionado
                    string mensaje = $"Libro seleccionado:\nISBN: {isbn}\nTítulo: {titulo}\nAutor: {autor}";

                    // Verificar si el préstamo está vencido
                    if (fechaValida)
                    {
                        mensaje += $"\nFecha de Entrega: {fechaEntrega.ToString("dd/MM/yyyy")}";

                        if (fechaEntrega < DateTime.Now)
                        {
                            int diasMora = (int)(DateTime.Now - fechaEntrega).TotalDays;
                            int multa = diasMora * 5; // Suponiendo 5 unidades monetarias por día de mora

                            mensaje += $"\n\n¡ALERTA! El préstamo está vencido por {diasMora} días.";
                            mensaje += $"\nMulta estimada: ${multa}";

                            MessageBox.Show(mensaje, "Préstamo Vencido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            int diasRestantes = (int)(fechaEntrega - DateTime.Now).TotalDays;
                            mensaje += $"\n\nDías restantes para la entrega: {diasRestantes}";

                            MessageBox.Show(mensaje, "Información del Préstamo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Información del Libro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Opcional: Preguntar si desea marcar como entregado
                    if (fechaValida && dtgEstudiantes.Columns.Contains("Entregado"))
                    {
                        DialogResult result = MessageBox.Show("¿Desea marcar este libro como entregado?",
                            "Entrega de Libro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // Aquí iría el código para marcar el libro como entregado
                            // Esto se implementaría con una actualización a la base de datos
                            ActualizarEstadoLibro(isbn);
                        }
                    }
                }
            }
        }

        private void ActualizarEstadoLibro(string isbn)
        {
            try
            {
                // Obtener el ID del préstamo actual
                string queryPrestamo = @"SELECT d.IdDetallePrestamo
                               FROM tblDetallePrestamo d
                               INNER JOIN tblPrestamo p ON d.IdPrestamo = p.IdPrestamo
                               WHERE d.ISBN = @isbn AND d.FechaDevolucion IS NULL";

                int idDetallePrestamo = -1;

                using (SqlConnection connection = cn.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(queryPrestamo, connection))
                {
                    cmd.Parameters.AddWithValue("@isbn", isbn);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        idDetallePrestamo = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró un préstamo activo para este libro.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Actualizar la fecha de devolución
                string queryActualizar = @"UPDATE tblDetallePrestamo
                                 SET FechaDevolucion = @fechaDevolucion
                                 WHERE IdDetallePrestamo = @idDetallePrestamo";

                using (SqlConnection connection = cn.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(queryActualizar, connection))
                {
                    cmd.Parameters.AddWithValue("@fechaDevolucion", DateTime.Now);
                    cmd.Parameters.AddWithValue("@idDetallePrestamo", idDetallePrestamo);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("El libro ha sido marcado como entregado correctamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refrescar la lista de préstamos del estudiante actual
                        if (!string.IsNullOrEmpty(txtCarnet.Text))
                        {
                            string nombre = ""; // Intentar obtener el nombre del estudiante
                            try
                            {
                                string queryNombre = "SELECT nombre FROM tblEstudiante WHERE carnet = @carnet";
                                using (SqlConnection conn = cn.AbrirConexion())
                                using (SqlCommand cmdNombre = new SqlCommand(queryNombre, conn))
                                {
                                    cmdNombre.Parameters.AddWithValue("@carnet", txtCarnet.Text);
                                    object nombreResult = cmdNombre.ExecuteScalar();
                                    if (nombreResult != null && nombreResult != DBNull.Value)
                                    {
                                        nombre = nombreResult.ToString();
                                    }
                                }
                            }
                            catch { /* Ignorar errores al obtener el nombre */ }

                            // Refrescar la lista de préstamos
                            CargarLibrosPorEstudiante(txtCarnet.Text, nombre);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el estado del libro.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el estado del libro: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgLibro_Leave(object sender, EventArgs e)
        {
            // Verificar si hay alguna fila seleccionada
            if (dtgEstudiantes.CurrentRow != null && dtgEstudiantes.CurrentRow.Index >= 0)
            {
                // Aquí se puede implementar alguna acción al dejar la selección de un libro
                // Por ejemplo, mostrar detalles adicionales en otros controles
            }
        }

        private void txtCarnet_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCarnet.Text))
            {
                MessageBox.Show("Ingrese un número de carnet válido.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Intentar obtener el nombre del estudiante
            string nombre = "";
            try
            {
                string queryNombre = "SELECT nombre FROM tblEstudiante WHERE carnet = @carnet";
                using (SqlConnection conn = cn.AbrirConexion())
                using (SqlCommand cmdNombre = new SqlCommand(queryNombre, conn))
                {
                    cmdNombre.Parameters.AddWithValue("@carnet", txtCarnet.Text.Trim());
                    object nombreResult = cmdNombre.ExecuteScalar();
                    if (nombreResult != null && nombreResult != DBNull.Value)
                    {
                        nombre = nombreResult.ToString();
                        // Opcional: Mostrar el nombre en un control TextBox si existe
                        if (txtNombre != null)
                        {
                            txtNombre.Text = nombre;
                        }
                    }
                }
            }
            catch { /* Ignorar errores al obtener el nombre */ }

            CargarLibrosPorEstudiante(txtCarnet.Text.Trim(), nombre);
        }

        private void txtCarnet_TextChanged(object sender, EventArgs e)
        {
            // Si se desea implementar búsqueda en tiempo real
            // podría activarse la búsqueda después de un número específico de caracteres
            if (txtCarnet.Text.Length >= 3)
            {
                // Opcional: buscar estudiantes que coincidan con el carnet ingresado
                BuscarEstudiantesPorCarnet(txtCarnet.Text);
            }
            else if (txtCarnet.Text.Length == 0)
            {
                // Si se borra el contenido, cargar todos los estudiantes nuevamente
                CargarEstudiantes();
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            // Implementar búsqueda por nombre
            if (txtNombre.Text.Length >= 2)
            {
                // Buscar estudiantes que coincidan con el nombre ingresado
                BuscarEstudiantesPorNombre(txtNombre.Text);
            }
            else if (txtNombre.Text.Length == 0)
            {
                // Si se borró el contenido, cargar todos los estudiantes nuevamente
                CargarEstudiantes();
            }
        }

        private void lblFecha_Click(object sender, EventArgs e)
        {
            // Opcional: Mostrar un calendario para seleccionar una fecha
            // o actualizar la fecha actual
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        // Método para generar un reporte de préstamos vencidos
        public void GenerarReporteVencidos()
        {
            try
            {
                string query = @"SELECT e.carnet, e.nombre, l.ISBN, l.titulo, l.autor, 
                      d.FechaEntrega, DATEDIFF(day, d.FechaEntrega, GETDATE()) as DiasVencidos,
                      DATEDIFF(day, d.FechaEntrega, GETDATE()) * 5 as MultaEstimada
                      FROM tblPrestamo p
                      INNER JOIN tblEstudiante e ON p.carnet = e.carnet
                      INNER JOIN tblDetallePrestamo d ON p.IdPrestamo = d.IdPrestamo
                      INNER JOIN tblLibro l ON d.ISBN = l.ISBN
                      WHERE d.FechaEntrega < GETDATE() AND d.FechaDevolucion IS NULL
                      ORDER BY DiasVencidos DESC";

                using (SqlConnection connection = cn.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Aquí se podría mostrar el reporte en un nuevo formulario
                    // o exportarlo a un archivo Excel, PDF, etc.

                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show($"Se encontraron {dt.Rows.Count} préstamos vencidos.\n" +
                            $"Utilice la función de exportación para guardar el reporte.",
                            "Reporte de Vencimientos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Opcional: Mostrar los datos en un DataGridView específico para reportes
                        // dtgReporteVencidos.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron préstamos vencidos actualmente.",
                            "Reporte de Vencimientos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte de préstamos vencidos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para exportar datos a Excel (simulado)
        public void ExportarDatosAExcel(DataGridView dgv)
        {
            if (dgv != null && dgv.Rows.Count > 0)
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Archivos Excel (*.xlsx)|*.xlsx";
                saveDialog.Title = "Guardar Reporte Excel";
                saveDialog.FileName = "Reporte_Biblioteca_" + DateTime.Now.ToString("yyyyMMdd");

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
        #endregion // Métodos de Libros

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay datos para exportar
                if (dtgEstudiantes.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Exportar a Excel", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Llamar al método para exportar
                ExportarDatosAExcel(dtgEstudiantes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar datos: " + ex.Message, 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVencidos_Click(object sender, EventArgs e)
        {
            try
            {
                // Generar el reporte de préstamos vencidos
                GenerarReporteVencidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte de vencidos: " + ex.Message, 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}