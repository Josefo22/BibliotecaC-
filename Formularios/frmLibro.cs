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
            cn = new cConexion();//instanciar el objeto
            cmd = new SqlCommand("Select * from tblLibro", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtPrograma_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAutor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCarnet_TextChanged(object sender, EventArgs e)
        {

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
            
                i = 0;
                if (i == -1)
                {
                    MessageBox.Show("Llegaste al primer registro");
                    i++;
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
                MessageBox.Show("Ultimo Registro");
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
            if (boton == 1)
            {
                cmd = new SqlCommand("insert into tblLibro values('" + txtISNB.Text + "','" + txtTitulo.Text + "','" + txtAutor.Text + "','" + txtAño.Text + "','" + txtEditorial.Text + "')", cn.AbrirConexion());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Estudiante creado");
            }

            if (boton == 3)
            {
                cmd = new SqlCommand("update tblLibro set Titulo='" + txtTitulo.Text + "', año='" + txtAño.Text + "',Autor='" + txtAutor.Text + "')", cn.AbrirConexion());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Libro modificado");

            }
        }

        private void txtISNB_Leave(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from tblLibro where ISNB='" + txtISNB.Text + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);


            if (boton == 1)//ingreso
            {
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("El Libro ya existe");
                }
            }


            if (boton == 2 || boton == 3)//consulta
            {
                if (dt.Rows.Count > 0)
                {
                    llenar(dt, 0);
                }
                else
                {
                    MessageBox.Show("El Libro no existe");
                }

            }

            if (boton == 4)
            {
                if (dt.Rows.Count > 0)
                {
                    llenar(dt, 0);
                    if (MessageBox.Show("Desea borrar el libro?", "Peligro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlCommand cm = new SqlCommand("delete from tblLibro where ISNB = '" + txtISNB.Text + "'", cn.AbrirConexion());
                        cm.ExecuteNonQuery();
                    }
                }
            }
        }
    

        private void frmLibro_Load(object sender, EventArgs e)
        {
            llenar(dt, i);
        }

        private void lblAño_Click(object sender, EventArgs e)
        {

        }
    }
}
