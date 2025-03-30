namespace Clase2.Formularios
{
    partial class frmPrestamo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblPrestamo = new System.Windows.Forms.Label();
            this.dttFechaPrestamo = new System.Windows.Forms.DateTimePicker();
            this.dtgPrestamo = new System.Windows.Forms.DataGridView();
            this.ISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prestado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtCarnet = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCarnet = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNroPrestamo = new System.Windows.Forms.Label();
            this.btnBorrarLibro = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnSeleccionarLibro = new System.Windows.Forms.Button();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrestamo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelTitulo.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPrestamo
            // 
            this.lblPrestamo.AutoSize = true;
            this.lblPrestamo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrestamo.ForeColor = System.Drawing.Color.White;
            this.lblPrestamo.Location = new System.Drawing.Point(12, 18);
            this.lblPrestamo.Name = "lblPrestamo";
            this.lblPrestamo.Size = new System.Drawing.Size(301, 37);
            this.lblPrestamo.TabIndex = 0;
            this.lblPrestamo.Text = "PRÉSTAMO DE LIBROS";
            // 
            // dttFechaPrestamo
            // 
            this.dttFechaPrestamo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dttFechaPrestamo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dttFechaPrestamo.Location = new System.Drawing.Point(546, 20);
            this.dttFechaPrestamo.Name = "dttFechaPrestamo";
            this.dttFechaPrestamo.Size = new System.Drawing.Size(160, 25);
            this.dttFechaPrestamo.TabIndex = 1;
            // 
            // dtgPrestamo
            // 
            this.dtgPrestamo.AllowUserToAddRows = false;
            this.dtgPrestamo.AllowUserToDeleteRows = false;
            this.dtgPrestamo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgPrestamo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPrestamo.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dtgPrestamo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgPrestamo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dtgPrestamo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgPrestamo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgPrestamo.ColumnHeadersHeight = 35;
            this.dtgPrestamo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ISBN,
            this.Titulo,
            this.FechaEntrega,
            this.Prestado});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgPrestamo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgPrestamo.EnableHeadersVisualStyles = false;
            this.dtgPrestamo.Location = new System.Drawing.Point(19, 244);
            this.dtgPrestamo.MultiSelect = false;
            this.dtgPrestamo.Name = "dtgPrestamo";
            this.dtgPrestamo.RowHeadersVisible = false;
            this.dtgPrestamo.RowHeadersWidth = 51;
            this.dtgPrestamo.RowTemplate.Height = 28;
            this.dtgPrestamo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgPrestamo.Size = new System.Drawing.Size(953, 301);
            this.dtgPrestamo.TabIndex = 2;
            this.dtgPrestamo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgPrestamo_CellEndEdit);
            // 
            // ISBN
            // 
            this.ISBN.HeaderText = "ISBN";
            this.ISBN.MinimumWidth = 6;
            this.ISBN.Name = "ISBN";
            // 
            // Titulo
            // 
            this.Titulo.HeaderText = "Titulo";
            this.Titulo.MinimumWidth = 6;
            this.Titulo.Name = "Titulo";
            // 
            // FechaEntrega
            // 
            this.FechaEntrega.HeaderText = "Fecha Entrega";
            this.FechaEntrega.MinimumWidth = 6;
            this.FechaEntrega.Name = "FechaEntrega";
            // 
            // Prestado
            // 
            this.Prestado.HeaderText = "Prestado";
            this.Prestado.MinimumWidth = 6;
            this.Prestado.Name = "Prestado";
            // 
            // txtCarnet
            // 
            this.txtCarnet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCarnet.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarnet.Location = new System.Drawing.Point(115, 29);
            this.txtCarnet.Name = "txtCarnet";
            this.txtCarnet.Size = new System.Drawing.Size(200, 25);
            this.txtCarnet.TabIndex = 3;
            this.txtCarnet.Leave += new System.EventHandler(this.txtCarnet_Leave);
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(115, 66);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(304, 25);
            this.txtNombre.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.lblCarnet);
            this.panel1.Location = new System.Drawing.Point(12, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(97, 71);
            this.panel1.TabIndex = 5;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(13, 37);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(64, 17);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblCarnet
            // 
            this.lblCarnet.AutoSize = true;
            this.lblCarnet.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarnet.Location = new System.Drawing.Point(13, 0);
            this.lblCarnet.Name = "lblCarnet";
            this.lblCarnet.Size = new System.Drawing.Size(53, 17);
            this.lblCarnet.TabIndex = 0;
            this.lblCarnet.Text = "Carnet:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(432, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fecha préstamo:";
            // 
            // lblNroPrestamo
            // 
            this.lblNroPrestamo.AutoSize = true;
            this.lblNroPrestamo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroPrestamo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblNroPrestamo.Location = new System.Drawing.Point(889, 38);
            this.lblNroPrestamo.Name = "lblNroPrestamo";
            this.lblNroPrestamo.Size = new System.Drawing.Size(19, 21);
            this.lblNroPrestamo.TabIndex = 7;
            this.lblNroPrestamo.Text = "0";
            // 
            // btnBorrarLibro
            // 
            this.btnBorrarLibro.BackColor = System.Drawing.Color.Firebrick;
            this.btnBorrarLibro.FlatAppearance.BorderSize = 0;
            this.btnBorrarLibro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarLibro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarLibro.ForeColor = System.Drawing.Color.White;
            this.btnBorrarLibro.Location = new System.Drawing.Point(691, 16);
            this.btnBorrarLibro.Name = "btnBorrarLibro";
            this.btnBorrarLibro.Size = new System.Drawing.Size(135, 40);
            this.btnBorrarLibro.TabIndex = 8;
            this.btnBorrarLibro.Text = "BORRAR";
            this.btnBorrarLibro.UseVisualStyleBackColor = false;
            this.btnBorrarLibro.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(19, 16);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(135, 40);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(175, 16);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(135, 40);
            this.btnNuevo.TabIndex = 10;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.RoyalBlue;
            this.panelTitulo.Controls.Add(this.lblPrestamo);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(984, 70);
            this.panelTitulo.TabIndex = 11;
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Controls.Add(this.btnNuevo);
            this.panelBotones.Controls.Add(this.btnBorrarLibro);
            this.panelBotones.Controls.Add(this.btnSeleccionarLibro);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 560);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(984, 70);
            this.panelBotones.TabIndex = 12;
            // 
            // btnSeleccionarLibro
            // 
            this.btnSeleccionarLibro.BackColor = System.Drawing.Color.DarkOrange;
            this.btnSeleccionarLibro.FlatAppearance.BorderSize = 0;
            this.btnSeleccionarLibro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarLibro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarLibro.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionarLibro.Location = new System.Drawing.Point(535, 16);
            this.btnSeleccionarLibro.Name = "btnSeleccionarLibro";
            this.btnSeleccionarLibro.Size = new System.Drawing.Size(135, 40);
            this.btnSeleccionarLibro.TabIndex = 11;
            this.btnSeleccionarLibro.Text = "BUSCAR";
            this.btnSeleccionarLibro.UseVisualStyleBackColor = false;
            this.btnSeleccionarLibro.Click += new System.EventHandler(this.btnSeleccionarLibro_Click);
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.BackColor = System.Drawing.Color.White;
            this.groupBoxInfo.Controls.Add(this.label2);
            this.groupBoxInfo.Controls.Add(this.panel1);
            this.groupBoxInfo.Controls.Add(this.lblNroPrestamo);
            this.groupBoxInfo.Controls.Add(this.txtCarnet);
            this.groupBoxInfo.Controls.Add(this.label1);
            this.groupBoxInfo.Controls.Add(this.txtNombre);
            this.groupBoxInfo.Controls.Add(this.dttFechaPrestamo);
            this.groupBoxInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxInfo.Location = new System.Drawing.Point(19, 88);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(953, 120);
            this.groupBoxInfo.TabIndex = 13;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "INFORMACIÓN DE PRÉSTAMO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(766, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nro. de préstamo:";
            // 
            // frmPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 630);
            this.Controls.Add(this.groupBoxInfo);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.dtgPrestamo);
            this.Name = "frmPrestamo";
            this.Text = "Préstamo de Libros";
            this.Load += new System.EventHandler(this.frmPrestamo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgPrestamo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPrestamo;
        private System.Windows.Forms.DateTimePicker dttFechaPrestamo;
        private System.Windows.Forms.DataGridView dtgPrestamo;
        private System.Windows.Forms.TextBox txtCarnet;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCarnet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNroPrestamo;
        private System.Windows.Forms.Button btnBorrarLibro;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEntrega;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Prestado;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnSeleccionarLibro;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Label label2;
    }
}