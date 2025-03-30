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

namespace Clase2
{
    public partial class frmEstudiante : Form
    {
        cConexion cn;//Crear objeto de cConexion
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;
        int i, contador, boton;
        
        public frmEstudiante()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            ConfigurarDiseno();
            
            cn = new cConexion();//instanciar el objeto
            cmd = new SqlCommand("Select * from tblEstudiante", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }
        
        private void ConfigurarDiseno()
        {
            // Configuración de colores y estilos
            this.BackColor = Color.White;
            
            // Panel de título
            panelTitulo.BackColor = Color.MediumPurple;
            lblTituloForm.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTituloForm.ForeColor = Color.White;
            
            // Panel de botones
            panelBotones.BackColor = Color.Lavender;
            
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
            ConfigurarEtiqueta(lblCarnet);
            ConfigurarEtiqueta(lblNombre);
            ConfigurarEtiqueta(lblEmail);
            ConfigurarEtiqueta(lblPrograma);
            
            // Configurar cajas de texto
            ConfigurarCajaTexto(txtCarnet);
            ConfigurarCajaTexto(txtNombre);
            ConfigurarCajaTexto(txtEmail);
            ConfigurarCajaTexto(txtPrograma);
            
            // Deshabilitar campos al inicio
            deshabilita();
            
            // Ajustar panel de datos
            panelDatos.BackColor = Color.WhiteSmoke;
            panelDatos.BorderStyle = BorderStyle.FixedSingle;
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
            btn.BackColor = Color.SlateBlue;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btn.ForeColor = Color.White;
            btn.Cursor = Cursors.Hand;
        }
        
        private void ConfigurarEtiqueta(Label lbl)
        {
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lbl.ForeColor = Color.DarkSlateBlue;
        }
        
        private void ConfigurarCajaTexto(TextBox txt)
        {
            txt.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Color.White;
        }

        void llenar(DataTable dt, int i)
        {
            txtCarnet.Text = dt.Rows[i][0].ToString();
            txtNombre.Text = dt.Rows[i][1].ToString();
            txtEmail.Text = dt.Rows[i][2].ToString();
            txtPrograma.Text = dt.Rows[i][3].ToString();
            contador = dt.Rows.Count;
        }

        void limpiar()
        {
            txtCarnet.Clear();
            txtNombre.Clear();
            txtPrograma.Clear();
            txtEmail.Clear();
        }

        void habilita()
        {
            txtCarnet.Enabled = true;
            txtNombre.Enabled = true;
            txtPrograma.Enabled = true;
            txtEmail.Enabled = true;
        }

        void deshabilita()
        {
            txtCarnet.Enabled = false;
            txtNombre.Enabled = false;
            txtPrograma.Enabled = false;
            txtEmail.Enabled = false;
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            i = 0;
            llenar(dt, i);
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            i = contador - 1;
            llenar(dt, i);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            i--;
            if (i < 0)
            {
                MessageBox.Show("Llegaste al primer registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                i = 0;
            }
            llenar(dt, i);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            i++;
            if (i == contador)
            {
                MessageBox.Show("Último Registro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                i--;
            }
            llenar(dt, i);
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            boton = 1;
            limpiar();
            habilita();
            txtCarnet.Focus();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            limpiar();
            boton = 2;
            txtCarnet.Enabled = true;
            txtCarnet.Focus();
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            boton = 3;
            limpiar();
            habilita();
            txtCarnet.Focus();
        }

        private void btnRetiro_Click(object sender, EventArgs e)
        {
            boton = 4;
            limpiar();
            txtCarnet.Enabled = true;
            txtCarnet.Focus();
        }

        private void txtCarnet_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCarnet.Text))
            {
                cmd = new SqlCommand("select * from tblEstudiante where carnet='" + txtCarnet.Text + "'", cn.AbrirConexion());
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                if (boton == 1) // Ingreso
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("El estudiante ya existe en la base de datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCarnet.Clear();
                        txtCarnet.Focus();
                    }
                }
                else if (boton == 2 || boton == 3) // Consulta o modificación
                {
                    if (dt.Rows.Count > 0)
                    {
                        llenar(dt, 0);
                        if (boton == 3) // Si es modificación, habilitar campos
                        {
                            txtNombre.Enabled = true;
                            txtEmail.Enabled = true;
                            txtPrograma.Enabled = true;
                            txtNombre.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El estudiante no existe en la base de datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCarnet.Clear();
                        txtCarnet.Focus();
                    }
                }
                else if (boton == 4) // Retiro/Eliminación
                {
                    if (dt.Rows.Count > 0)
                    {
                        llenar(dt, 0);
                        if (MessageBox.Show("¿Está seguro que desea eliminar este estudiante?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                SqlCommand cm = new SqlCommand("delete from tblEstudiante where carnet = '" + txtCarnet.Text + "'", cn.AbrirConexion());
                                cm.ExecuteNonQuery();
                                MessageBox.Show("Estudiante eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                limpiar();
                                
                                // Actualizar la tabla
                                cmd = new SqlCommand("Select * from tblEstudiante", cn.AbrirConexion());
                                da = new SqlDataAdapter(cmd);
                                dt = new DataTable();
                                da.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    i = 0;
                                    llenar(dt, i);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al eliminar el estudiante: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El estudiante no existe en la base de datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCarnet.Clear();
                        txtCarnet.Focus();
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (boton == 1)
                {
                    if (ValidarCampos())
                    {
                        cmd = new SqlCommand("insert into tblEstudiante values('" + txtCarnet.Text + "','" + txtNombre.Text + "','" + txtEmail.Text + "','" + txtPrograma.Text + "')", cn.AbrirConexion());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Estudiante guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                        deshabilita();
                        
                        // Actualizar la tabla
                        cmd = new SqlCommand("Select * from tblEstudiante", cn.AbrirConexion());
                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        i = dt.Rows.Count - 1;
                        llenar(dt, i);
                    }
                }
                else if (boton == 3)
                {
                    if (ValidarCampos())
                    {
                        cmd = new SqlCommand("update tblEstudiante set nombre='" + txtNombre.Text + "', e_mail='" + txtEmail.Text + "', programa='" + txtPrograma.Text + "' where carnet='" + txtCarnet.Text + "'", cn.AbrirConexion());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Estudiante actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                        deshabilita();
                        
                        // Actualizar la tabla
                        cmd = new SqlCommand("Select * from tblEstudiante", cn.AbrirConexion());
                        da = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        da.Fill(dt);
                        llenar(dt, i);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la operación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtCarnet.Text))
            {
                MessageBox.Show("El carnet no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCarnet.Focus();
                return false;
            }
            
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El nombre no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
            
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("El email no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            
            return true;
        }

        private void frmEstudiante_Load(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                llenar(dt, i);
            }
        }

        // Eliminar métodos de eventos que no hacen nada
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
    }
}
