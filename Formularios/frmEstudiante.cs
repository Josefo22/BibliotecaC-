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
            cn = new cConexion();//instanciar el objeto
            cmd = new SqlCommand("Select * from tblEstudiante", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
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

        private void label1_Click(object sender, EventArgs e)
        {

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
            i = 0;
            if (i == -1)
            {
                MessageBox.Show("Llegaste al primer registro");
                i++;
            }
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
            cmd = new SqlCommand("select * from tblEstudiante where carnet='" + txtCarnet.Text + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);


            if (boton == 1)//ingreso
            {
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("El estudiante ya existe");
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
                    MessageBox.Show("El estudiante no existe");
                }

            }

            if (boton == 4)
            {
                if (dt.Rows.Count > 0)
                {
                    llenar(dt, 0);
                    if (MessageBox.Show("Desea borrar el estudiante?", "Peligro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlCommand cm = new SqlCommand("delete from tblEstudiante where carnet = '" + txtCarnet.Text + "'", cn.AbrirConexion());
                        cm.ExecuteNonQuery();
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (boton == 1)
            {
                cmd = new SqlCommand("insert into tblEstudiante values('" + txtCarnet.Text + "'" + txtNombre.Text + txtEmail.Text + "','" + txtPrograma.Text + "')", cn.AbrirConexion());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Estudiante creado");
            }

            if (boton == 3 )
            {
                cmd = new SqlCommand("update tblEstudiante set nombre='" + txtNombre.Text + "', programa='" + txtPrograma.Text + "',e_mail='" + txtEmail.Text + "')", cn.AbrirConexion());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Estudiante modificado");

            }
        }




        private void frmEstudiante_Load(object sender, EventArgs e)
        {
            llenar(dt, i);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
