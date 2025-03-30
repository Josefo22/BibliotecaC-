namespace Clase2.Formularios
{
    partial class frmLibro
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblAutor = new System.Windows.Forms.Label();
            this.lblEditorial = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblISNB = new System.Windows.Forms.Label();
            this.txtEditorial = new System.Windows.Forms.TextBox();
            this.txtAutor = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.txtISNB = new System.Windows.Forms.TextBox();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.btnIngreso = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnRetiro = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnUltimo = new System.Windows.Forms.Button();
            this.btnPrimero = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblAño = new System.Windows.Forms.Label();
            this.txtAño = new System.Windows.Forms.TextBox();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.lblTituloForm = new System.Windows.Forms.Label();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.panelDatos = new System.Windows.Forms.Panel();
            this.panelNavegacion = new System.Windows.Forms.Panel();
            this.panelTitulo.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.panelDatos.SuspendLayout();
            this.panelNavegacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Location = new System.Drawing.Point(600, 16);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 45);
            this.btnGuardar.TabIndex = 35;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblAutor
            // 
            this.lblAutor.AutoSize = true;
            this.lblAutor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAutor.Location = new System.Drawing.Point(30, 122);
            this.lblAutor.Name = "lblAutor";
            this.lblAutor.Size = new System.Drawing.Size(61, 23);
            this.lblAutor.TabIndex = 34;
            this.lblAutor.Text = "Autor:";
            this.lblAutor.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblEditorial
            // 
            this.lblEditorial.AutoSize = true;
            this.lblEditorial.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEditorial.Location = new System.Drawing.Point(30, 212);
            this.lblEditorial.Name = "lblEditorial";
            this.lblEditorial.Size = new System.Drawing.Size(79, 23);
            this.lblEditorial.TabIndex = 33;
            this.lblEditorial.Text = "Editorial:";
            this.lblEditorial.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTitulo.Location = new System.Drawing.Point(30, 77);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(59, 23);
            this.lblTitulo.TabIndex = 32;
            this.lblTitulo.Text = "Título:";
            this.lblTitulo.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblISNB
            // 
            this.lblISNB.AutoSize = true;
            this.lblISNB.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblISNB.Location = new System.Drawing.Point(30, 32);
            this.lblISNB.Name = "lblISNB";
            this.lblISNB.Size = new System.Drawing.Size(52, 23);
            this.lblISNB.TabIndex = 31;
            this.lblISNB.Text = "ISBN:";
            this.lblISNB.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtEditorial
            // 
            this.txtEditorial.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEditorial.Location = new System.Drawing.Point(134, 212);
            this.txtEditorial.Name = "txtEditorial";
            this.txtEditorial.Size = new System.Drawing.Size(240, 30);
            this.txtEditorial.TabIndex = 30;
            this.txtEditorial.TextChanged += new System.EventHandler(this.txtPrograma_TextChanged);
            // 
            // txtAutor
            // 
            this.txtAutor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAutor.Location = new System.Drawing.Point(134, 122);
            this.txtAutor.Name = "txtAutor";
            this.txtAutor.Size = new System.Drawing.Size(240, 30);
            this.txtAutor.TabIndex = 29;
            this.txtAutor.TextChanged += new System.EventHandler(this.txtAutor_TextChanged);
            // 
            // txtTitulo
            // 
            this.txtTitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTitulo.Location = new System.Drawing.Point(134, 77);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(380, 30);
            this.txtTitulo.TabIndex = 28;
            this.txtTitulo.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // txtISNB
            // 
            this.txtISNB.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtISNB.Location = new System.Drawing.Point(134, 32);
            this.txtISNB.Name = "txtISNB";
            this.txtISNB.Size = new System.Drawing.Size(240, 30);
            this.txtISNB.TabIndex = 27;
            this.txtISNB.TextChanged += new System.EventHandler(this.txtCarnet_TextChanged);
            this.txtISNB.Leave += new System.EventHandler(this.txtISNB_Leave);
            // 
            // btnConsulta
            // 
            this.btnConsulta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnConsulta.Location = new System.Drawing.Point(170, 16);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(150, 45);
            this.btnConsulta.TabIndex = 26;
            this.btnConsulta.Text = "CONSULTA";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // btnIngreso
            // 
            this.btnIngreso.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnIngreso.Location = new System.Drawing.Point(12, 16);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(150, 45);
            this.btnIngreso.TabIndex = 25;
            this.btnIngreso.Text = "INGRESO";
            this.btnIngreso.UseVisualStyleBackColor = true;
            this.btnIngreso.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // btnModifica
            // 
            this.btnModifica.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnModifica.Location = new System.Drawing.Point(327, 16);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(150, 45);
            this.btnModifica.TabIndex = 24;
            this.btnModifica.Text = "MODIFICA";
            this.btnModifica.UseVisualStyleBackColor = true;
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // btnRetiro
            // 
            this.btnRetiro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRetiro.Location = new System.Drawing.Point(485, 16);
            this.btnRetiro.Name = "btnRetiro";
            this.btnRetiro.Size = new System.Drawing.Size(108, 45);
            this.btnRetiro.TabIndex = 23;
            this.btnRetiro.Text = "RETIRO";
            this.btnRetiro.UseVisualStyleBackColor = true;
            this.btnRetiro.Click += new System.EventHandler(this.btnRetiro_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAnterior.Location = new System.Drawing.Point(123, 16);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(100, 40);
            this.btnAnterior.TabIndex = 22;
            this.btnAnterior.Text = "<<";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnUltimo
            // 
            this.btnUltimo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUltimo.Location = new System.Drawing.Point(340, 16);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(100, 40);
            this.btnUltimo.TabIndex = 21;
            this.btnUltimo.Text = ">|";
            this.btnUltimo.UseVisualStyleBackColor = true;
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // btnPrimero
            // 
            this.btnPrimero.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnPrimero.Location = new System.Drawing.Point(16, 16);
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(100, 40);
            this.btnPrimero.TabIndex = 20;
            this.btnPrimero.Text = "|<";
            this.btnPrimero.UseVisualStyleBackColor = true;
            this.btnPrimero.Click += new System.EventHandler(this.btnPrimero_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSiguiente.Location = new System.Drawing.Point(230, 16);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(100, 40);
            this.btnSiguiente.TabIndex = 19;
            this.btnSiguiente.Text = ">>";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblAño
            // 
            this.lblAño.AutoSize = true;
            this.lblAño.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAño.Location = new System.Drawing.Point(30, 167);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(46, 23);
            this.lblAño.TabIndex = 37;
            this.lblAño.Text = "Año:";
            this.lblAño.Click += new System.EventHandler(this.lblAño_Click);
            // 
            // txtAño
            // 
            this.txtAño.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAño.Location = new System.Drawing.Point(134, 167);
            this.txtAño.Name = "txtAño";
            this.txtAño.Size = new System.Drawing.Size(120, 30);
            this.txtAño.TabIndex = 36;
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.RoyalBlue;
            this.panelTitulo.Controls.Add(this.lblTituloForm);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(984, 70);
            this.panelTitulo.TabIndex = 38;
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.AutoSize = true;
            this.lblTituloForm.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTituloForm.ForeColor = System.Drawing.Color.White;
            this.lblTituloForm.Location = new System.Drawing.Point(12, 18);
            this.lblTituloForm.Name = "lblTituloForm";
            this.lblTituloForm.Size = new System.Drawing.Size(333, 46);
            this.lblTituloForm.TabIndex = 0;
            this.lblTituloForm.Text = "GESTIÓN DE LIBROS";
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelBotones.Controls.Add(this.btnIngreso);
            this.panelBotones.Controls.Add(this.btnConsulta);
            this.panelBotones.Controls.Add(this.btnModifica);
            this.panelBotones.Controls.Add(this.btnRetiro);
            this.panelBotones.Controls.Add(this.btnGuardar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 460);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(984, 70);
            this.panelBotones.TabIndex = 39;
            // 
            // panelDatos
            // 
            this.panelDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDatos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelDatos.Controls.Add(this.lblISNB);
            this.panelDatos.Controls.Add(this.txtISNB);
            this.panelDatos.Controls.Add(this.lblAño);
            this.panelDatos.Controls.Add(this.lblTitulo);
            this.panelDatos.Controls.Add(this.txtAño);
            this.panelDatos.Controls.Add(this.txtTitulo);
            this.panelDatos.Controls.Add(this.lblAutor);
            this.panelDatos.Controls.Add(this.txtAutor);
            this.panelDatos.Controls.Add(this.lblEditorial);
            this.panelDatos.Controls.Add(this.txtEditorial);
            this.panelDatos.Location = new System.Drawing.Point(12, 151);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Size = new System.Drawing.Size(960, 271);
            this.panelDatos.TabIndex = 40;
            // 
            // panelNavegacion
            // 
            this.panelNavegacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelNavegacion.Controls.Add(this.btnPrimero);
            this.panelNavegacion.Controls.Add(this.btnSiguiente);
            this.panelNavegacion.Controls.Add(this.btnUltimo);
            this.panelNavegacion.Controls.Add(this.btnAnterior);
            this.panelNavegacion.Location = new System.Drawing.Point(502, 86);
            this.panelNavegacion.Name = "panelNavegacion";
            this.panelNavegacion.Size = new System.Drawing.Size(470, 70);
            this.panelNavegacion.TabIndex = 41;
            // 
            // frmLibro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 530);
            this.Controls.Add(this.panelNavegacion);
            this.Controls.Add(this.panelDatos);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelTitulo);
            this.Name = "frmLibro";
            this.Text = "Gestión de Libros";
            this.Load += new System.EventHandler(this.frmLibro_Load);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.panelDatos.ResumeLayout(false);
            this.panelDatos.PerformLayout();
            this.panelNavegacion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblAutor;
        private System.Windows.Forms.Label lblEditorial;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblISNB;
        private System.Windows.Forms.TextBox txtEditorial;
        private System.Windows.Forms.TextBox txtAutor;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.TextBox txtISNB;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.Button btnIngreso;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Button btnRetiro;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnUltimo;
        private System.Windows.Forms.Button btnPrimero;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label lblAño;
        private System.Windows.Forms.TextBox txtAño;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Panel panelDatos;
        private System.Windows.Forms.Panel panelNavegacion;
    }
}