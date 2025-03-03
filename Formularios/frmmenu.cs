using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase2.Formularios
{
    public partial class frmmenu : Form
    {
        private Form activeForm = null;
        public frmmenu()
        {
            InitializeComponent();
            inicial();
        }
        //metodo para hacer invisible los paneles hijos

        void inicial ()
        {
            pnlEstudiante.Visible = false;  
            pnlLibro.Visible = false;   
        }

        //Oculta los submenus dependiendo de donde este visible

        void ocultarSubmenu()
        {
            if (pnlEstudiante.Visible == true)
                pnlEstudiante.Visible = false;
            if (pnlLibro.Visible == true)
                pnlLibro.Visible = false;
        }

        // Llamando al submenu

        void mostarSubmenu(Panel submenu)
        {
            ocultarSubmenu();
            submenu.Visible = true;
        }

        //Abre el panel dependiendo del padre
        private void AbrirenPanel(Form frmHijo)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = frmHijo;
            frmHijo.TopLevel = false;
            frmHijo.FormBorderStyle = FormBorderStyle.None;
            frmHijo.Dock = DockStyle.Fill;
            pnlCentral.Controls.Add(frmHijo);
            pnlCentral.Tag = frmHijo;
            frmHijo.BringToFront();
            frmHijo.Show();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEstudiante_Click(object sender, EventArgs e)
        {
            mostarSubmenu(pnlEstudiante);
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new frmEstudiante());
            ocultarSubmenu();
        }

        private void btnIngresol_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new frmLibro());
            ocultarSubmenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mostarSubmenu(pnlLibro);
        }

        private void btnPrestamo_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new frmPrestamo());
            ocultarSubmenu();
        }

        private void btnIngresol_Click_1(object sender, EventArgs e)
        {
            AbrirenPanel(new frmLibro());
            ocultarSubmenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new frmPrestamo());
        }
    }
}
