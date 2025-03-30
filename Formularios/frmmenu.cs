using System;
using System.Drawing;
using System.Windows.Forms;

namespace Clase2.Formularios
{
    public partial class frmmenu : Form
    {
        private Form activeForm = null;

        public frmmenu()
        {
            InitializeComponent();
            ConfigurarDiseno();
            inicial();
        }

        // Método para configurar el diseño visual del menú
        private void ConfigurarDiseno()
        {
            // Configuración de la ventana principal
            this.Text = "SISTEMA DE BIBLIOTECA";
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            
            // Panel lateral (menú)
            pnlLateral.BackColor = Color.FromArgb(35, 50, 80);
            
            // Panel del logo
            pnlLogo.BackColor = Color.FromArgb(25, 42, 70);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            
            // Panel central
            pnlCentral.BackColor = Color.WhiteSmoke;
            
            // Estilo de botones principales
            ConfigurarBotonPrincipal(btnEstudiante, Color.RoyalBlue);
            ConfigurarBotonPrincipal(button2, Color.DarkOrange); // Botón Libro
            ConfigurarBotonPrincipal(BtnAutor, Color.ForestGreen);
            ConfigurarBotonPrincipal(btnPagoMulta, Color.Firebrick);
            ConfigurarBotonPrincipal(btnDeudores, Color.Purple);
            
            // Estilo de submenús
            pnlEstudiante.BackColor = Color.FromArgb(45, 60, 90);
            pnlLibro.BackColor = Color.FromArgb(45, 60, 90);
            PnlAutor.BackColor = Color.FromArgb(45, 60, 90);
            
            // Estilo de botones de submenú
            ConfigurarBotonesSubmenu(pnlEstudiante);
            ConfigurarBotonesSubmenu(pnlLibro);
            ConfigurarBotonesSubmenu(PnlAutor);
        }
        
        // Método para configurar el estilo de botones principales
        private void ConfigurarBotonPrincipal(Button btn, Color colorAccent)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(35, 50, 80);
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btn.Height = 50;
            btn.Image = null;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(10, 0, 0, 0);
            btn.FlatAppearance.MouseOverBackColor = colorAccent;
            btn.Cursor = Cursors.Hand;
        }
        
        // Método para configurar botones de submenú
        private void ConfigurarBotonesSubmenu(Panel submenu)
        {
            foreach (Control control in submenu.Controls)
            {
                if (control is Button)
                {
                    Button btn = (Button)control;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = Color.FromArgb(45, 60, 90);
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    btn.Height = 40;
                    btn.TextAlign = ContentAlignment.MiddleLeft;
                    btn.Padding = new Padding(20, 0, 0, 0);
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 85, 115);
                    btn.Cursor = Cursors.Hand;
                }
            }
        }

        // Method to initially hide submenus
        void inicial()
        {
            pnlEstudiante.Visible = false;
            pnlLibro.Visible = false;
            PnlAutor.Visible = false;
        }

        // Show specific submenu and hide others
        void mostarSubmenu(Panel submenu)
        {
            // First hide all submenus
            pnlEstudiante.Visible = false;
            pnlLibro.Visible = false;
            PnlAutor.Visible = false;

            // Then show the selected submenu
            submenu.Visible = true;
        }

        // Open form in central panel
        private void AbrirenPanel(Form frmHijo)
        {
            if (activeForm != null)
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

        // Existing click event handlers
        private void btnEstudiante_Click(object sender, EventArgs e)
        {
            mostarSubmenu(pnlEstudiante);
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new frmEstudiante());
            pnlEstudiante.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mostarSubmenu(pnlLibro);
        }

        private void btnIngresol_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new frmLibro());
            pnlLibro.Visible = false;
        }

        private void btnPrestamo_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new frmPrestamo());
            pnlEstudiante.Visible = false;
        }

        private void btnInformel_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new fmInformePrestamo());
            pnlLibro.Visible = false;
        }

        private void BtnAutor_Click(object sender, EventArgs e)
        {
            mostarSubmenu(PnlAutor);
        }

        private void BtnIngresoAutor_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new FrmInformeAutor());
            PnlAutor.Visible = false;
        }

        private void AutorIngreso_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new FrmLibroPorAutor());
            PnlAutor.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new frmInformeEstudiante());
            pnlEstudiante.Visible = false;
        }

        private void btnPagoMulta_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new FrmPagoMulta());
        }
        
        private void btnDeudores_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new FrmListadoDeudores());
        }

        private void frmmenu_Load(object sender, EventArgs e)
        {
            // Cargar imagen de logo o bienvenida
            MostrarPanelBienvenida();
        }
        
        private void MostrarPanelBienvenida()
        {
            // Crear panel de bienvenida
            Panel pnlBienvenida = new Panel();
            pnlBienvenida.Dock = DockStyle.Fill;
            pnlBienvenida.BackColor = Color.White;
            
            // Agregar etiqueta de título
            Label lblBienvenida = new Label();
            lblBienvenida.Text = "BIENVENIDO AL SISTEMA DE BIBLIOTECA";
            lblBienvenida.AutoSize = false;
            lblBienvenida.TextAlign = ContentAlignment.MiddleCenter;
            lblBienvenida.Dock = DockStyle.Top;
            lblBienvenida.Height = 100;
            lblBienvenida.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.RoyalBlue;
            
            // Agregar fecha y hora
            Label lblFecha = new Label();
            lblFecha.Text = DateTime.Now.ToString("D");
            lblFecha.AutoSize = false;
            lblFecha.TextAlign = ContentAlignment.MiddleCenter;
            lblFecha.Dock = DockStyle.Top;
            lblFecha.Height = 50;
            lblFecha.Font = new Font("Segoe UI", 14, FontStyle.Regular);
            lblFecha.ForeColor = Color.DarkSlateGray;
            
            // Agregar los controles al panel
            pnlBienvenida.Controls.Add(lblFecha);
            pnlBienvenida.Controls.Add(lblBienvenida);
            
            // Agregar panel al formulario
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = null;
            pnlCentral.Controls.Clear();
            pnlCentral.Controls.Add(pnlBienvenida);
        }
    }
}