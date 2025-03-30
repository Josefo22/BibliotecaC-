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
using Microsoft.VisualBasic;
using Clase2.Clases;

namespace Clase2.Formularios
{
    public partial class FrmAutor : Form
    {
        cConexion cn;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;
        int i = 0, contador = 0, boton = 0;

        public FrmAutor()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            ConfigurarDiseno();
            
            cn = new cConexion();
            cargarAutores();
        }
        
        private void ConfigurarDiseno()
        {
            // Configuración de colores y estilos
            this.BackColor = Color.White;
            
            // Panel de título
            panelTitulo.BackColor = Color.Teal;
            lblTitulo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            
            // Panel de botones
            panelBotones.BackColor = Color.AliceBlue;
            
            // Configuración de los botones principales
            ConfigurarBoton(btnIngreso, Color.RoyalBlue);
            ConfigurarBoton(btnConsulta, Color.SeaGreen);
            ConfigurarBoton(btnModifica, Color.DarkOrange);
            ConfigurarBoton(btnRetiro, Color.Crimson);
            ConfigurarBoton(btnGuardar, Color.ForestGreen);
            
            // Configuración de botones de navegación
            ConfigurarBotonNavegacion(btnPrimero);
            ConfigurarBotonNavegacion(btnAnterior);
            ConfigurarBotonNavegacion(btnSiguiente);
            ConfigurarBotonNavegacion(btnUltimo);
            
            // Configuración de etiquetas
            ConfigurarEtiqueta(label2); // Cédula
            ConfigurarEtiqueta(label3); // Nombre
            ConfigurarEtiqueta(label5); // Email
            ConfigurarEtiqueta(label4); // Fecha nacimiento
            
            // Configurar cajas de texto
            ConfigurarCajaTexto(txtCedula);
            ConfigurarCajaTexto(txtNombre);
            ConfigurarCajaTexto(txtEmail);
            ConfigurarCajaTexto(txtnacimiento);
            
            // Deshabilitar campos al inicio
            deshabilita();
            
            // Ajustar panel de datos
            panelDatos.BackColor = Color.WhiteSmoke;
            panelDatos.BorderStyle = BorderStyle.FixedSingle;
            
            // Panel de navegación
            panelNavegacion.BackColor = Color.LightCyan;
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
        
        private void ConfigurarBotonNavegacion(Button btn)
        {
            btn.BackColor = Color.Teal;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.Cursor = Cursors.Hand;
        }
        
        private void ConfigurarEtiqueta(Label lbl)
        {
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lbl.ForeColor = Color.DarkSlateGray;
        }
        
        private void ConfigurarCajaTexto(TextBox txt)
        {
            txt.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Color.White;
        }

        void cargarAutores()
        {
            try
            {
                cmd = new SqlCommand("SELECT * FROM TblAutor", cn.AbrirConexion());
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                contador = dt.Rows.Count;
                if (contador > 0)
                {
                    llenar(dt, 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar autores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void llenar(DataTable dt, int i)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    txtCedula.Text = dt.Rows[i][0].ToString();
                    txtNombre.Text = dt.Rows[i][1].ToString(); 

                    if (dt.Rows[i][2] != DBNull.Value)
                    {
                        DateTime fecha = Convert.ToDateTime(dt.Rows[i][2]);
                        txtnacimiento.Text = fecha.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        txtnacimiento.Text = string.Empty;
                    }

                    txtEmail.Text = dt.Rows[i][3].ToString(); 
                    contador = dt.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void limpiar()
        {
            txtCedula.Clear();
            txtNombre.Clear();
            txtnacimiento.Clear();
            txtEmail.Clear();
        }

        void habilita()
        {
            txtCedula.Enabled = true;
            txtNombre.Enabled = true;
            txtnacimiento.Enabled = true;
            txtEmail.Enabled = true;
        }

        void deshabilita()
        {
            txtCedula.Enabled = false;
            txtNombre.Enabled = false;
            txtnacimiento.Enabled = false;
            txtEmail.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void txtCedula_TextChanged(object sender, EventArgs e) { }
        private void txtNombre_TextChanged(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void txtnacimiento_TextChanged(object sender, EventArgs e) { }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            i = 0;
            if (contador > 0)
            {
                llenar(dt, i);
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            i = contador - 1;
            if (i >= 0)
            {
                llenar(dt, i);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            i--;
            if (i < 0)
            {
                MessageBox.Show("Llegaste al primer registro", "Navegación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                i = 0;
            }
            llenar(dt, i);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            i++;
            if (i >= contador)
            {
                MessageBox.Show("Último Registro", "Navegación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                i = contador - 1;
            }
            llenar(dt, i);
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                boton = 1;
                limpiar();
                habilita();
                txtCedula.Focus();

                MessageBox.Show("Por favor, ingrese los datos del nuevo autor y presione Guardar",
                    "Ingreso de Autor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al preparar ingreso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                boton = 2;
                limpiar();
                deshabilita();
                txtCedula.Enabled = true;
                txtCedula.Focus();

                MessageBox.Show("Ingrese la cédula del autor a consultar",
                    "Consulta de Autor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al preparar consulta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar();
                boton = 3;

                // pedir cédula al usuario
                string cedula = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la cédula del autor a modificar:", "Modificación de Autor", "");

                if (string.IsNullOrEmpty(cedula))
                    return;

                txtCedula.Text = cedula;

                // cnsultar autor actual
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM TblAutor WHERE Cedula = @Cedula", cn.AbrirConexion()))
                {
                    cmd.Parameters.AddWithValue("@Cedula", cedula);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dtResult = new DataTable();
                    da.Fill(dtResult);

                    if (dtResult.Rows.Count > 0)
                    {
                        habilita();
                        txtCedula.Enabled = false; 

                        txtNombre.Text = dtResult.Rows[0]["nombreAutor"].ToString();

                        if (dtResult.Rows[0]["Fechanacimiento"] != DBNull.Value)
                        {
                            DateTime fecha = Convert.ToDateTime(dtResult.Rows[0]["Fechanacimiento"]);
                            txtnacimiento.Text = fecha.ToString("yyyy-MM-dd");
                        }

                        txtEmail.Text = dtResult.Rows[0]["email"].ToString();

                        MessageBox.Show("Modifique los datos y presione Guardar",
                            "Modificación de Autor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún autor con cédula: " + cedula,
                            "Autor No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al preparar modificación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRetiro_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar();
                deshabilita();
                boton = 4;

                // Peticion cdula
                string cedula = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la cédula del autor a eliminar:", "Eliminación de Autor", "");

                if (string.IsNullOrEmpty(cedula))
                    return;

                txtCedula.Text = cedula;
                txtCedula.Enabled = false;

                // Consultar autor a eliminar
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM TblAutor WHERE Cedula = @Cedula", cn.AbrirConexion()))
                {
                    cmd.Parameters.AddWithValue("@Cedula", cedula);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dtResult = new DataTable();
                    da.Fill(dtResult);

                    if (dtResult.Rows.Count > 0)
                    {
                        // Mostrar datos del autor
                        txtNombre.Text = dtResult.Rows[0]["nombreAutor"].ToString();

                        if (dtResult.Rows[0]["Fechanacimiento"] != DBNull.Value)
                        {
                            DateTime fecha = Convert.ToDateTime(dtResult.Rows[0]["Fechanacimiento"]);
                            txtnacimiento.Text = fecha.ToString("yyyy-MM-dd");
                        }

                        txtEmail.Text = dtResult.Rows[0]["email"].ToString();

                        // verificar autor libros asociados
                        using (SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM tblLibro WHERE autor = @Cedula", cn.AbrirConexion()))
                        {
                            cmdCheck.Parameters.AddWithValue("@Cedula", cedula);
                            int librosAsociados = (int)cmdCheck.ExecuteScalar();

                            if (librosAsociados > 0)
                            {
                                MessageBox.Show("No se puede eliminar el autor porque tiene libros asociados.",
                                    "Eliminación Restringida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        // confirmar eliminación
                        if (MessageBox.Show("¿Está seguro que desea eliminar este autor?\n\nNombre: " + dtResult.Rows[0]["nombreAutor"].ToString(),
                            "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            // eliminación
                            using (SqlCommand cmdDelete = new SqlCommand("DELETE FROM TblAutor WHERE Cedula = @Cedula", cn.AbrirConexion()))
                            {
                                cmdDelete.Parameters.AddWithValue("@Cedula", cedula);
                                int rowsAffected = cmdDelete.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Autor eliminado correctamente", "Eliminación Exitosa",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cargarAutores();
                                    limpiar();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo eliminar el autor", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún autor con cédula: " + cedula,
                            "Autor No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        limpiar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar autor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCedula_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCedula.Text))
                    return;

                cmd = new SqlCommand("SELECT * FROM TblAutor WHERE Cedula = @Cedula", cn.AbrirConexion());
                cmd.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                da = new SqlDataAdapter(cmd);
                DataTable tempDt = new DataTable();
                da.Fill(tempDt);

                if (boton == 1) // Ingreso
                {
                    if (tempDt.Rows.Count > 0)
                    {
                        MessageBox.Show("El autor ya existe", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCedula.Focus();
                        txtCedula.SelectAll();
                    }
                }
                else if (boton == 2 || boton == 3) // Consulta
                {
                    if (tempDt.Rows.Count > 0)
                    {
                        // habilitamos los campos
                        if (boton == 3)
                        {
                            habilita();
                            txtCedula.Enabled = false; // Id no cambia
                        }

                        txtNombre.Text = tempDt.Rows[0]["nombreAutor"].ToString();

                        if (tempDt.Rows[0]["Fechanacimiento"] != DBNull.Value)
                        {
                            DateTime fecha = Convert.ToDateTime(tempDt.Rows[0]["Fechanacimiento"]);
                            txtnacimiento.Text = fecha.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            txtnacimiento.Text = string.Empty;
                        }

                        txtEmail.Text = tempDt.Rows[0]["email"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("El autor no existe", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCedula.Focus();
                        txtCedula.SelectAll();
                    }
                }
                else if (boton == 4) // Eliminar
                {
                    if (tempDt.Rows.Count > 0)
                    {
                        txtNombre.Text = tempDt.Rows[0]["nombreAutor"].ToString();

                        if (tempDt.Rows[0]["Fechanacimiento"] != DBNull.Value)
                        {
                            DateTime fecha = Convert.ToDateTime(tempDt.Rows[0]["Fechanacimiento"]);
                            txtnacimiento.Text = fecha.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            txtnacimiento.Text = string.Empty;
                        }

                        txtEmail.Text = tempDt.Rows[0]["email"].ToString();

                        // Verificar autor libros duplicados
                        using (SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM tblLibro WHERE autor = @Cedula", cn.AbrirConexion()))
                        {
                            cmdCheck.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                            int librosAsociados = (int)cmdCheck.ExecuteScalar();

                            if (librosAsociados > 0)
                            {
                                MessageBox.Show("No se puede eliminar el autor porque tiene libros asociados.",
                                    "Eliminación Restringida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        if (MessageBox.Show("¿Desea borrar el autor?", "Confirmar eliminación",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cmd = new SqlCommand("DELETE FROM TblAutor WHERE Cedula = @Cedula", cn.AbrirConexion());
                            cmd.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Autor eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cargarAutores();
                            limpiar();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El autor no existe", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCedula.Focus();
                        txtCedula.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar autor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar datosM
                if (string.IsNullOrEmpty(txtCedula.Text) || string.IsNullOrEmpty(txtNombre.Text))
                {
                    MessageBox.Show("Debe ingresar al menos Cédula y Nombre", "Datos incompletos",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validacion fecha
                DateTime fechaNac;
                bool fechaValida = true;

                if (!string.IsNullOrEmpty(txtnacimiento.Text))
                {
                    try
                    {
                        fechaNac = DateTime.Parse(txtnacimiento.Text);
                    }
                    catch
                    {
                        fechaValida = false;
                        MessageBox.Show("El formato de fecha no es válido. Use YYYY-MM-DD", "Error en fecha",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (boton == 1) // Ingreso
                {
                    // Verificar si ya existe
                    using (SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM TblAutor WHERE Cedula = @Cedula", cn.AbrirConexion()))
                    {
                        cmdCheck.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                        int existe = (int)cmdCheck.ExecuteScalar();

                        if (existe > 0)
                        {
                            MessageBox.Show("Ya existe un autor con esta cédula", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insertar
                    string sql = "INSERT INTO TblAutor (Cedula, nombreAutor, Fechanacimiento, email) VALUES (@Cedula, @Nombre, @Fecha, @Email)";
                    using (SqlCommand cmdInsert = new SqlCommand(sql, cn.AbrirConexion()))
                    {
                        cmdInsert.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                        cmdInsert.Parameters.AddWithValue("@Nombre", txtNombre.Text);

                        if (string.IsNullOrEmpty(txtnacimiento.Text))
                        {
                            cmdInsert.Parameters.AddWithValue("@Fecha", DBNull.Value);
                        }
                        else
                        {
                            cmdInsert.Parameters.AddWithValue("@Fecha", DateTime.Parse(txtnacimiento.Text));
                        }

                        cmdInsert.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(txtEmail.Text) ? DBNull.Value : (object)txtEmail.Text);

                        cmdInsert.ExecuteNonQuery();
                        MessageBox.Show("Autor creado correctamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarAutores();
                        deshabilita();
                        limpiar();
                    }
                }
                else if (boton == 3) // Modificación
                {
                    // Actualizar
                    string sql = "UPDATE TblAutor SET nombreAutor = @Nombre, Fechanacimiento = @Fecha, email = @Email WHERE Cedula = @Cedula";
                    using (SqlCommand cmdUpdate = new SqlCommand(sql, cn.AbrirConexion()))
                    {
                        cmdUpdate.Parameters.AddWithValue("@Cedula", txtCedula.Text);
                        cmdUpdate.Parameters.AddWithValue("@Nombre", txtNombre.Text);

                        if (string.IsNullOrEmpty(txtnacimiento.Text))
                        {
                            cmdUpdate.Parameters.AddWithValue("@Fecha", DBNull.Value);
                        }
                        else
                        {
                            cmdUpdate.Parameters.AddWithValue("@Fecha", DateTime.Parse(txtnacimiento.Text));
                        }

                        cmdUpdate.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(txtEmail.Text) ? DBNull.Value : (object)txtEmail.Text);

                        int rowsAffected = cmdUpdate.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Autor modificado correctamente", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cargarAutores();
                            deshabilita();
                            limpiar();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el autor para modificar", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el autor: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmAutor_Load(object sender, EventArgs e)
        {
            deshabilita();
        }
    }
}