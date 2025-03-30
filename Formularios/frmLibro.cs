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
    public partial class frmLibro : Form
    {
        cConexion cn;//Crear objeto de cConexion
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;
        int i, contador, boton;
  
        public frmLibro()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            ConfigurarDiseno();
            
            cn = new cConexion();//instanciar el objeto
            cmd = new SqlCommand("Select * from tblLibro", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
        }
        
        private void ConfigurarDiseno()
        {
            // Configuración de colores y estilos
            this.BackColor = Color.White;
            
            // Panel de título
            panelTitulo.BackColor = Color.RoyalBlue;
            lblTitulo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            
            // Panel de botones
            panelBotones.BackColor = Color.LightSteelBlue;
            
            // Configuración de los botones principales
            ConfigurarBoton(btnIngreso, Color.DodgerBlue);
            ConfigurarBoton(btnConsulta, Color.MediumSeaGreen);
            ConfigurarBoton(btnModifica, Color.DarkOrange);
            ConfigurarBoton(btnRetiro, Color.Firebrick);
            ConfigurarBoton(btnGuardar, Color.ForestGreen);
            
            // Configuración de botones de navegación
            ConfigurarBotonNavegacion(btnPrimero);
            ConfigurarBotonNavegacion(btnAnterior);
            ConfigurarBotonNavegacion(btnSiguiente);
            ConfigurarBotonNavegacion(btnUltimo);
            
            // Configuración de etiquetas
            ConfigurarEtiqueta(lblISNB);
            ConfigurarEtiqueta(lblTitulo);
            ConfigurarEtiqueta(lblAutor);
            ConfigurarEtiqueta(lblAño);
            ConfigurarEtiqueta(lblEditorial);
            
            // Configurar cajas de texto
            ConfigurarCajaTexto(txtISNB);
            ConfigurarCajaTexto(txtTitulo);
            ConfigurarCajaTexto(txtAutor);
            ConfigurarCajaTexto(txtAño);
            ConfigurarCajaTexto(txtEditorial);
            
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
            btn.BackColor = Color.SlateGray;
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
            txtISNB.Text = dt.Rows[i][0].ToString();
            txtTitulo.Text = dt.Rows[i][1].ToString();
            txtAutor.Text = dt.Rows[i][2].ToString();
            txtAño.Text = dt.Rows[i][3].ToString();
            txtEditorial.Text = dt.Rows[i][4].ToString();
            contador = dt.Rows.Count;
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            limpiar();
            boton = 2;
            txtISNB.Enabled = true;
            txtISNB.Focus();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            boton = 1;
            limpiar();
            habilita();
            txtISNB.Focus();
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            boton = 3;
            limpiar();
            habilita();
            txtISNB.Focus();
        }

        private void btnRetiro_Click(object sender, EventArgs e)
        {
            boton = 4;
            limpiar();
            txtISNB.Enabled = true;
            txtISNB.Focus();
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

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            i = contador - 1;
            llenar(dt, i);
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            i = 0;
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

        void limpiar()
        {
            txtISNB.Clear();
            txtTitulo.Clear();
            txtAutor.Clear();
            txtAño.Clear();
            txtEditorial.Clear();   
        }

        void habilita()
        {
            txtISNB.Enabled = true;
            txtTitulo.Enabled = true;
            txtAutor.Enabled = true;
            txtAño.Enabled = true;
            txtEditorial.Enabled = true;
        }

        void deshabilita()
        {
            txtISNB.Enabled = false;
            txtTitulo.Enabled = false;
            txtAutor.Enabled = false;
            txtAño.Enabled = false;
            txtEditorial.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (boton == 1)
                {
                    if (ValidarCampos())
                    {
                        cmd = new SqlCommand("insert into tblLibro values('" + txtISNB.Text + "','" + txtTitulo.Text + "','" + txtAutor.Text + "','" + txtAño.Text + "','" + txtEditorial.Text + "')", cn.AbrirConexion());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Libro guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                        deshabilita();
                        
                        // Actualizar la tabla
                        cmd = new SqlCommand("Select * from tblLibro", cn.AbrirConexion());
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
                        cmd = new SqlCommand("update tblLibro set Titulo='" + txtTitulo.Text + "', Autor='" + txtAutor.Text + "', año='" + txtAño.Text + "', Editorial='" + txtEditorial.Text + "' where ISNB='" + txtISNB.Text + "'", cn.AbrirConexion());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Libro actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                        deshabilita();
                        
                        // Actualizar la tabla
                        cmd = new SqlCommand("Select * from tblLibro", cn.AbrirConexion());
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
            if (string.IsNullOrEmpty(txtISNB.Text))
            {
                MessageBox.Show("El ISBN no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtISNB.Focus();
                return false;
            }
            
            if (string.IsNullOrEmpty(txtTitulo.Text))
            {
                MessageBox.Show("El título no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitulo.Focus();
                return false;
            }
            
            if (string.IsNullOrEmpty(txtAutor.Text))
            {
                MessageBox.Show("El autor no puede estar vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAutor.Focus();
                return false;
            }
            
            return true;
        }

        private void txtISNB_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtISNB.Text))
            {
                cmd = new SqlCommand("select * from tblLibro where ISNB='" + txtISNB.Text + "'", cn.AbrirConexion());
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                if (boton == 1) // Ingreso
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("El libro ya existe en la base de datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtISNB.Clear();
                        txtISNB.Focus();
                    }
                }
                else if (boton == 2 || boton == 3) // Consulta o modificación
                {
                    if (dt.Rows.Count > 0)
                    {
                        llenar(dt, 0);
                        if (boton == 3) // Si es modificación, habilitar campos
                        {
                            txtTitulo.Enabled = true;
                            txtAutor.Enabled = true;
                            txtAño.Enabled = true;
                            txtEditorial.Enabled = true;
                            txtTitulo.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El libro no existe en la base de datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtISNB.Clear();
                        txtISNB.Focus();
                    }
                }
                else if (boton == 4) // Retiro/Eliminación
                {
                    if (dt.Rows.Count > 0)
                    {
                        llenar(dt, 0);
                        if (MessageBox.Show("¿Está seguro que desea eliminar este libro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                SqlCommand cm = new SqlCommand("delete from tblLibro where ISNB = '" + txtISNB.Text + "'", cn.AbrirConexion());
                                cm.ExecuteNonQuery();
                                MessageBox.Show("Libro eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                limpiar();
                                
                                // Actualizar la tabla
                                cmd = new SqlCommand("Select * from tblLibro", cn.AbrirConexion());
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
                                MessageBox.Show("Error al eliminar el libro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("El libro no existe en la base de datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtISNB.Clear();
                        txtISNB.Focus();
                    }
                }
            }
        }

        private void frmLibro_Load(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                llenar(dt, i);
            }
        }

        // Eliminar métodos de eventos que no hacen nada
        private void lblAño_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void txtPrograma_TextChanged(object sender, EventArgs e) { }
        private void txtAutor_TextChanged(object sender, EventArgs e) { }
        private void txtNombre_TextChanged(object sender, EventArgs e) { }
        private void txtCarnet_TextChanged(object sender, EventArgs e) { }
    }
}
