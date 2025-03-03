using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clase2.Clases;

namespace Clase2.Formularios
{
    public partial class frmInformeEstudiante: Form
    {
        cConexion cn;// crear objeto de cConexion
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;
        int contador;
        public frmInformeEstudiante()
        {
            InitializeComponent();
            cn = new cConexion();
            cmd = new SqlCommand(" select * from tblEstudiante", cn.AbrirConexion());
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            contador = dt.Rows.Count;
        }

        private void frmInformeEstudiante_Load(object sender, EventArgs e)
        {
            llenar();

           
        }
        void llenar()
        {
            dtgEstudiante.Rows.Add(contador - 1);
            for (int i = 0; i<contador;i++)
            {
                dtgEstudiante.Rows[i].Cells[0].Value = dt.Rows[i][0];
                dtgEstudiante.Rows[i].Cells[1].Value = dt.Rows[i][1];
                dtgEstudiante.Rows[i].Cells[2].Value = dt.Rows[i][3];
                dtgEstudiante.Rows[i].Cells[3].Value = dt.Rows[i][2];
            }
        }
    }
}
