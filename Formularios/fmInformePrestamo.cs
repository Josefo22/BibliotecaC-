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
    public partial class fmInformePrestamo: Form
    {
        cConexion cn;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;

        public fmInformePrestamo()
        {
            InitializeComponent();
            cn = new cConexion();
        }

        private void dtgEstudiantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgLibro_Leave(object sender, EventArgs e)
        {

        }

        private void txtCarnet_Leave(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT l.ISBN, l.titulo, l.autor,d.FechaEntrega FROM tblPrestamo = d.IdPrestamo INNER JOIN tblLibro l ON d.ISBN = l.ISBN WHERE p.carnet = '" + txtCarnet.Text + "'", cn.AbrirConexion());

            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No tiene prestamos");
            }
            else
            {
                dtgLibro.Rows.Add(dt.Rows.Count);
                for (int i = 0;i < dt.Rows.Count; i++)
                {
                    dtgLibro.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                    dtgLibro.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                    dtgLibro.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();
                    dtgLibro.Rows[i].Cells[3].Value = dt.Rows[i][3].ToString();
                }
            }
        }

        private void fmInformePrestamo_Load(object sender, EventArgs e)
        {

        }

        private void txtCarnet_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
