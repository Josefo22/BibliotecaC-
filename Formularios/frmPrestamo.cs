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
        cConexion cn;//crear objeto de cConexion
        SqlDataAdapter da;
        SqlCommand cmd, comd;
        DataTable dt;
        int contador;
        public frmPrestamo()
        {
            InitializeComponent();
            cn = new cConexion();
            NroPrestamo();
        }

        void NroPrestamo()
        {
            cmd = new SqlCommand("select * from tblPrestamo", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0 )
            {
                contador = dt.Rows.Count + 1;
                lblNroPrestamo.Text = contador.ToString();
            }
            else
            {
                lblNroPrestamo.Text = "1";
            }
        }
        private void dtgPrestamo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            DateTime fechaSeleccionada = dttFechaPrestamo.Value;
            DateTime nuevaFecha = fechaSeleccionada.AddDays(15);
            cmd = new SqlCommand("select titulo, cantidad from tblLibro where ISBN = '" + dtgPrestamo.Rows[e.RowIndex].Cells[0].Value + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            int cant = Convert.ToInt32(dt.Rows[0]["cantidad"]);
            if (dtgPrestamo.Columns[e.ColumnIndex].Name == "ISBN"  )

                try
                { 
                    dtgPrestamo.Rows[e.RowIndex].Cells[1].Value = dt.Rows[0][0];
                    dtgPrestamo.Rows[e.RowIndex].Cells[2].Value = nuevaFecha.ToString("dd/MM/yyyy");
                    comd = new SqlCommand("select count(*) from tblDetallePrestamo where ISBN ='" + dtgPrestamo.Rows[e.RowIndex].Cells[0].Value + "'", cn.AbrirConexion());
                    int cantidadPrestamos = Convert.ToInt32(comd.ExecuteScalar());
                    MessageBox.Show(cantidadPrestamos.ToString());
                    if (cantidadPrestamos >= cant)
                    {
                        MessageBox.Show("No puedes hacer el préstamo el titulo no esta disponible");
                        dtgPrestamo.Rows[e.RowIndex].Cells[3].Value = true;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Debe Ingresar Un ISNB Del Libro");
                }
   
                    
                    
                    
                    
                    
                    
                    
                    
                    }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dtgPrestamo.SelectedRows.Count > 0 ) //fila seleccionada?
            {
                int pisicionFila = dtgPrestamo.SelectedRows[0].Index;//obtiene el indice de la fila seleccionada
                dtgPrestamo.Rows.RemoveAt(pisicionFila);//Elimina la fila
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna fila", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into tblPrestamo values('" + txtCarnet.Text + "', '" + dttFechaPrestamo.Value.ToString("yyyy-MM-dd") + "')", cn.AbrirConexion());

            for(int i = 0;i<dtgPrestamo.Rows.Count;i++)
            {
                comd = new SqlCommand("insert into tblDellatePrestamo values('" + lblNroPrestamo.Text + "', '" + dtgPrestamo.Rows[i].Cells[0].Value + "','" + dtgPrestamo.Rows[i].Cells[2].Value + "', 0, 0)", cn.AbrirConexion());
                comd.ExecuteNonQuery();
            }
            cmd.ExecuteNonQuery();
            MessageBox.Show("Prestamo Guardado");
            btnGuardar.Enabled = false;
        }

        private void txtCarnet_Leave(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from tblEstudiante where carnet='" + txtCarnet.Text + "'", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0 )
            {
                txtNombre.Text = dt.Rows[0][1].ToString();
            }
            else
            {
                MessageBox.Show("Menso");
                txtCarnet.Clear();
                txtCarnet.Focus();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnNuevo.Enabled = true;
            txtCarnet.Clear();
            txtNombre.Clear();
            dtgPrestamo.Rows.Clear();
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