namespace Clase2.Formularios
{
    partial class fmInformePrestamo
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
            this.components = new System.ComponentModel.Container();
            this.lblPrestamoEstudiante = new System.Windows.Forms.Label();
            this.txtCarnet = new System.Windows.Forms.TextBox();
            this.lblCarnet = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.bdBibliotecaDataSet1 = new Clase2.bdBibliotecaDataSet1();
            this.Entregado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FechadeEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Autor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgEstudiantes = new System.Windows.Forms.DataGridView();
            this.bdBibliotecaDataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bdBibliotecaDataSet2 = new Clase2.bdBibliotecaDataSet2();
            this.lblFecha = new System.Windows.Forms.Label();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.panelBusqueda = new System.Windows.Forms.Panel();
            this.panelDatos = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnVencidos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bdBibliotecaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstudiantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdBibliotecaDataSet2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdBibliotecaDataSet2)).BeginInit();
            this.panelTitulo.SuspendLayout();
            this.panelBusqueda.SuspendLayout();
            this.panelDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPrestamoEstudiante
            // 
            this.lblPrestamoEstudiante.AutoSize = true;
            this.lblPrestamoEstudiante.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblPrestamoEstudiante.ForeColor = System.Drawing.Color.White;
            this.lblPrestamoEstudiante.Location = new System.Drawing.Point(20, 19);
            this.lblPrestamoEstudiante.Name = "lblPrestamoEstudiante";
            this.lblPrestamoEstudiante.Size = new System.Drawing.Size(414, 46);
            this.lblPrestamoEstudiante.TabIndex = 0;
            this.lblPrestamoEstudiante.Text = "PRÉSTAMOS BIBLIOTECA";
            // 
            // txtCarnet
            // 
            this.txtCarnet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCarnet.Location = new System.Drawing.Point(134, 20);
            this.txtCarnet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCarnet.Name = "txtCarnet";
            this.txtCarnet.Size = new System.Drawing.Size(180, 30);
            this.txtCarnet.TabIndex = 2;
            this.txtCarnet.TextChanged += new System.EventHandler(this.txtCarnet_TextChanged);
            this.txtCarnet.Leave += new System.EventHandler(this.txtCarnet_Leave);
            // 
            // lblCarnet
            // 
            this.lblCarnet.AutoSize = true;
            this.lblCarnet.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCarnet.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblCarnet.Location = new System.Drawing.Point(20, 20);
            this.lblCarnet.Name = "lblCarnet";
            this.lblCarnet.Size = new System.Drawing.Size(76, 25);
            this.lblCarnet.TabIndex = 3;
            this.lblCarnet.Text = "Carnet:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNombre.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblNombre.Location = new System.Drawing.Point(350, 20);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(89, 25);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.Location = new System.Drawing.Point(445, 20);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(240, 30);
            this.txtNombre.TabIndex = 5;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // bdBibliotecaDataSet1
            // 
            this.bdBibliotecaDataSet1.DataSetName = "bdBibliotecaDataSet1";
            this.bdBibliotecaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Entregado
            // 
            this.Entregado.HeaderText = "Entregado";
            this.Entregado.MinimumWidth = 6;
            this.Entregado.Name = "Entregado";
            this.Entregado.Width = 125;
            // 
            // FechadeEntrega
            // 
            this.FechadeEntrega.HeaderText = "Fecha de Entrega";
            this.FechadeEntrega.MinimumWidth = 6;
            this.FechadeEntrega.Name = "FechadeEntrega";
            this.FechadeEntrega.Width = 140;
            // 
            // Autor
            // 
            this.Autor.HeaderText = "Autor";
            this.Autor.MinimumWidth = 6;
            this.Autor.Name = "Autor";
            this.Autor.Width = 205;
            // 
            // Titulo
            // 
            this.Titulo.HeaderText = "Titulo";
            this.Titulo.MinimumWidth = 6;
            this.Titulo.Name = "Titulo";
            this.Titulo.Width = 220;
            // 
            // ISBN
            // 
            this.ISBN.HeaderText = "ISBN";
            this.ISBN.MinimumWidth = 6;
            this.ISBN.Name = "ISBN";
            this.ISBN.Width = 100;
            // 
            // dtgEstudiantes
            // 
            this.dtgEstudiantes.AutoGenerateColumns = false;
            this.dtgEstudiantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEstudiantes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ISBN,
            this.Titulo,
            this.Autor,
            this.FechadeEntrega,
            this.Entregado});
            this.dtgEstudiantes.DataSource = this.bdBibliotecaDataSet2BindingSource;
            this.dtgEstudiantes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgEstudiantes.Location = new System.Drawing.Point(0, 0);
            this.dtgEstudiantes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgEstudiantes.Name = "dtgEstudiantes";
            this.dtgEstudiantes.RowHeadersWidth = 51;
            this.dtgEstudiantes.RowTemplate.Height = 24;
            this.dtgEstudiantes.Size = new System.Drawing.Size(920, 340);
            this.dtgEstudiantes.TabIndex = 1;
            this.dtgEstudiantes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgLibro_CellContentClick);
            this.dtgEstudiantes.Leave += new System.EventHandler(this.dtgLibro_Leave);
            // 
            // bdBibliotecaDataSet2BindingSource
            // 
            this.bdBibliotecaDataSet2BindingSource.DataSource = this.bdBibliotecaDataSet2;
            this.bdBibliotecaDataSet2BindingSource.Position = 0;
            // 
            // bdBibliotecaDataSet2
            // 
            this.bdBibliotecaDataSet2.DataSetName = "bdBibliotecaDataSet2";
            this.bdBibliotecaDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(717, 33);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(109, 23);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "00/00/0000";
            this.lblFecha.Click += new System.EventHandler(this.lblFecha_Click);
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.MediumPurple;
            this.panelTitulo.Controls.Add(this.lblPrestamoEstudiante);
            this.panelTitulo.Controls.Add(this.lblFecha);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(944, 80);
            this.panelTitulo.TabIndex = 7;
            // 
            // panelBusqueda
            // 
            this.panelBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBusqueda.BackColor = System.Drawing.Color.Lavender;
            this.panelBusqueda.Controls.Add(this.btnVencidos);
            this.panelBusqueda.Controls.Add(this.btnExportar);
            this.panelBusqueda.Controls.Add(this.lblCarnet);
            this.panelBusqueda.Controls.Add(this.txtCarnet);
            this.panelBusqueda.Controls.Add(this.lblNombre);
            this.panelBusqueda.Controls.Add(this.txtNombre);
            this.panelBusqueda.Location = new System.Drawing.Point(12, 92);
            this.panelBusqueda.Name = "panelBusqueda";
            this.panelBusqueda.Size = new System.Drawing.Size(920, 100);
            this.panelBusqueda.TabIndex = 8;
            // 
            // panelDatos
            // 
            this.panelDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDatos.Controls.Add(this.dtgEstudiantes);
            this.panelDatos.Location = new System.Drawing.Point(12, 208);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Size = new System.Drawing.Size(920, 340);
            this.panelDatos.TabIndex = 9;
            // 
            // btnExportar
            // 
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnExportar.Location = new System.Drawing.Point(737, 15);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(142, 40);
            this.btnExportar.TabIndex = 6;
            this.btnExportar.Text = "EXPORTAR";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnVencidos
            // 
            this.btnVencidos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnVencidos.Location = new System.Drawing.Point(737, 60);
            this.btnVencidos.Name = "btnVencidos";
            this.btnVencidos.Size = new System.Drawing.Size(142, 40);
            this.btnVencidos.TabIndex = 7;
            this.btnVencidos.Text = "VENCIDOS";
            this.btnVencidos.UseVisualStyleBackColor = true;
            this.btnVencidos.Click += new System.EventHandler(this.btnVencidos_Click);
            // 
            // fmInformePrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(944, 562);
            this.Controls.Add(this.panelDatos);
            this.Controls.Add(this.panelBusqueda);
            this.Controls.Add(this.panelTitulo);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "fmInformePrestamo";
            this.Text = "Gestión de Préstamos";
            this.Load += new System.EventHandler(this.fmInformePrestamo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bdBibliotecaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstudiantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdBibliotecaDataSet2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdBibliotecaDataSet2)).EndInit();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panelBusqueda.ResumeLayout(false);
            this.panelBusqueda.PerformLayout();
            this.panelDatos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPrestamoEstudiante;
        private System.Windows.Forms.TextBox txtCarnet;
        private System.Windows.Forms.Label lblCarnet;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private bdBibliotecaDataSet1 bdBibliotecaDataSet1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Entregado;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechadeEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn Autor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISBN;
        private System.Windows.Forms.DataGridView dtgEstudiantes;
        private System.Windows.Forms.BindingSource bdBibliotecaDataSet2BindingSource;
        private bdBibliotecaDataSet2 bdBibliotecaDataSet2;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Panel panelBusqueda;
        private System.Windows.Forms.Panel panelDatos;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnVencidos;
    }
}