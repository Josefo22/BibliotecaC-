namespace Clase2.Formularios
{
    partial class fmInformePrestamo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPrestamoEstudiante = new System.Windows.Forms.Label();
            this.dtgLibro = new System.Windows.Forms.DataGridView();
            this.ISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Autor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechadeEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entregado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtCarnet = new System.Windows.Forms.TextBox();
            this.lblCarnet = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgLibro)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPrestamoEstudiante
            // 
            this.lblPrestamoEstudiante.AutoSize = true;
            this.lblPrestamoEstudiante.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrestamoEstudiante.Location = new System.Drawing.Point(214, 32);
            this.lblPrestamoEstudiante.Name = "lblPrestamoEstudiante";
            this.lblPrestamoEstudiante.Size = new System.Drawing.Size(365, 37);
            this.lblPrestamoEstudiante.TabIndex = 0;
            this.lblPrestamoEstudiante.Text = "Préstamo por Estudiante";
            // 
            // dtgLibro
            // 
            this.dtgLibro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgLibro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ISBN,
            this.Titulo,
            this.Autor,
            this.FechadeEntrega,
            this.Entregado});
            this.dtgLibro.Location = new System.Drawing.Point(39, 185);
            this.dtgLibro.Name = "dtgLibro";
            this.dtgLibro.RowHeadersWidth = 51;
            this.dtgLibro.RowTemplate.Height = 24;
            this.dtgLibro.Size = new System.Drawing.Size(728, 249);
            this.dtgLibro.TabIndex = 1;
            this.dtgLibro.Leave += new System.EventHandler(this.dtgLibro_Leave);
            // 
            // ISBN
            // 
            this.ISBN.HeaderText = "ISBN";
            this.ISBN.MinimumWidth = 6;
            this.ISBN.Name = "ISBN";
            this.ISBN.Width = 70;
            // 
            // Titulo
            // 
            this.Titulo.HeaderText = "Titulo";
            this.Titulo.MinimumWidth = 6;
            this.Titulo.Name = "Titulo";
            this.Titulo.Width = 220;
            // 
            // Autor
            // 
            this.Autor.HeaderText = "Autor";
            this.Autor.MinimumWidth = 6;
            this.Autor.Name = "Autor";
            this.Autor.Width = 205;
            // 
            // FechadeEntrega
            // 
            this.FechadeEntrega.HeaderText = "Fecha de Entrega";
            this.FechadeEntrega.MinimumWidth = 6;
            this.FechadeEntrega.Name = "FechadeEntrega";
            this.FechadeEntrega.Width = 140;
            // 
            // Entregado
            // 
            this.Entregado.HeaderText = "Entregado";
            this.Entregado.MinimumWidth = 6;
            this.Entregado.Name = "Entregado";
            this.Entregado.Width = 125;
            // 
            // txtCarnet
            // 
            this.txtCarnet.Location = new System.Drawing.Point(143, 102);
            this.txtCarnet.Name = "txtCarnet";
            this.txtCarnet.Size = new System.Drawing.Size(234, 22);
            this.txtCarnet.TabIndex = 2;
            this.txtCarnet.TextChanged += new System.EventHandler(this.txtCarnet_TextChanged);
            this.txtCarnet.Leave += new System.EventHandler(this.txtCarnet_Leave);
            // 
            // lblCarnet
            // 
            this.lblCarnet.AutoSize = true;
            this.lblCarnet.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarnet.Location = new System.Drawing.Point(34, 95);
            this.lblCarnet.Name = "lblCarnet";
            this.lblCarnet.Size = new System.Drawing.Size(78, 27);
            this.lblCarnet.TabIndex = 3;
            this.lblCarnet.Text = "Carnet";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(434, 99);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(95, 27);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(559, 100);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(188, 22);
            this.txtNombre.TabIndex = 5;
            // 
            // fmInformePrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCarnet);
            this.Controls.Add(this.txtCarnet);
            this.Controls.Add(this.dtgLibro);
            this.Controls.Add(this.lblPrestamoEstudiante);
            this.Name = "fmInformePrestamo";
            this.Text = "fmInformePrestamo";
            this.Load += new System.EventHandler(this.fmInformePrestamo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgLibro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPrestamoEstudiante;
        private System.Windows.Forms.DataGridView dtgLibro;
        private System.Windows.Forms.TextBox txtCarnet;
        private System.Windows.Forms.Label lblCarnet;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Autor;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechadeEntrega;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Entregado;
    }
}