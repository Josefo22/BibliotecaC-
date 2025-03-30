namespace Clase2.Formularios
{
    partial class frmInformeEstudiante
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgEstudiante = new System.Windows.Forms.DataGridView();
            this.Carnet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Programa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E_mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblListadoEstudiantes = new System.Windows.Forms.Label();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.panelBusqueda = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.panelDatos = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstudiante)).BeginInit();
            this.panelTitulo.SuspendLayout();
            this.panelBusqueda.SuspendLayout();
            this.panelDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgEstudiante
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgEstudiante.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgEstudiante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEstudiante.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Carnet,
            this.Nombre,
            this.Programa,
            this.E_mail});
            this.dtgEstudiante.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgEstudiante.Location = new System.Drawing.Point(0, 0);
            this.dtgEstudiante.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgEstudiante.Name = "dtgEstudiante";
            this.dtgEstudiante.RowHeadersWidth = 51;
            this.dtgEstudiante.RowTemplate.Height = 24;
            this.dtgEstudiante.Size = new System.Drawing.Size(850, 320);
            this.dtgEstudiante.TabIndex = 1;
            // 
            // Carnet
            // 
            this.Carnet.HeaderText = "Carnet";
            this.Carnet.MinimumWidth = 6;
            this.Carnet.Name = "Carnet";
            this.Carnet.Width = 125;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 250;
            // 
            // Programa
            // 
            this.Programa.HeaderText = "Programa";
            this.Programa.MinimumWidth = 6;
            this.Programa.Name = "Programa";
            this.Programa.Width = 125;
            // 
            // E_mail
            // 
            this.E_mail.HeaderText = "Email";
            this.E_mail.MinimumWidth = 6;
            this.E_mail.Name = "E_mail";
            this.E_mail.Width = 250;
            // 
            // lblListadoEstudiantes
            // 
            this.lblListadoEstudiantes.AutoSize = true;
            this.lblListadoEstudiantes.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblListadoEstudiantes.ForeColor = System.Drawing.Color.White;
            this.lblListadoEstudiantes.Location = new System.Drawing.Point(20, 15);
            this.lblListadoEstudiantes.Name = "lblListadoEstudiantes";
            this.lblListadoEstudiantes.Size = new System.Drawing.Size(481, 46);
            this.lblListadoEstudiantes.TabIndex = 2;
            this.lblListadoEstudiantes.Text = "LISTADO DE ESTUDIANTES";
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.RoyalBlue;
            this.panelTitulo.Controls.Add(this.lblFecha);
            this.panelTitulo.Controls.Add(this.lblListadoEstudiantes);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(900, 70);
            this.panelTitulo.TabIndex = 3;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(734, 25);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(109, 23);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "00/00/0000";
            // 
            // panelBusqueda
            // 
            this.panelBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBusqueda.BackColor = System.Drawing.Color.AliceBlue;
            this.panelBusqueda.Controls.Add(this.btnExportar);
            this.panelBusqueda.Controls.Add(this.txtBuscar);
            this.panelBusqueda.Controls.Add(this.lblBuscar);
            this.panelBusqueda.Location = new System.Drawing.Point(25, 82);
            this.panelBusqueda.Name = "panelBusqueda";
            this.panelBusqueda.Size = new System.Drawing.Size(850, 70);
            this.panelBusqueda.TabIndex = 4;
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnExportar.Location = new System.Drawing.Point(668, 15);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(160, 40);
            this.btnExportar.TabIndex = 2;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscar.Location = new System.Drawing.Point(130, 20);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(450, 30);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblBuscar.Location = new System.Drawing.Point(20, 22);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(76, 25);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar:";
            // 
            // panelDatos
            // 
            this.panelDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDatos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelDatos.Controls.Add(this.dtgEstudiante);
            this.panelDatos.Location = new System.Drawing.Point(25, 168);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Size = new System.Drawing.Size(850, 320);
            this.panelDatos.TabIndex = 5;
            // 
            // frmInformeEstudiante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.panelDatos);
            this.Controls.Add(this.panelBusqueda);
            this.Controls.Add(this.panelTitulo);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmInformeEstudiante";
            this.Text = "Listado de Estudiantes";
            this.Load += new System.EventHandler(this.frmInformeEstudiante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstudiante)).EndInit();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panelBusqueda.ResumeLayout(false);
            this.panelBusqueda.PerformLayout();
            this.panelDatos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgEstudiante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Carnet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Programa;
        private System.Windows.Forms.DataGridViewTextBoxColumn E_mail;
        private System.Windows.Forms.Label lblListadoEstudiantes;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel panelBusqueda;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Panel panelDatos;
    }
}