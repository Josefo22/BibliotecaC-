namespace Clase2.Formularios
{
    partial class frmInformeEstudiante
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
            this.dtgEstudiante = new System.Windows.Forms.DataGridView();
            this.Carnet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Programa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E_mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblListadoEstudiantes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstudiante)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgEstudiante
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.dtgEstudiante.Location = new System.Drawing.Point(22, 138);
            this.dtgEstudiante.Name = "dtgEstudiante";
            this.dtgEstudiante.RowHeadersWidth = 51;
            this.dtgEstudiante.RowTemplate.Height = 24;
            this.dtgEstudiante.Size = new System.Drawing.Size(748, 284);
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
            this.E_mail.HeaderText = "E_mail";
            this.E_mail.MinimumWidth = 6;
            this.E_mail.Name = "E_mail";
            this.E_mail.Width = 250;
            // 
            // lblListadoEstudiantes
            // 
            this.lblListadoEstudiantes.AutoSize = true;
            this.lblListadoEstudiantes.Font = new System.Drawing.Font("Microsoft YaHei UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListadoEstudiantes.Location = new System.Drawing.Point(178, 56);
            this.lblListadoEstudiantes.Name = "lblListadoEstudiantes";
            this.lblListadoEstudiantes.Size = new System.Drawing.Size(439, 50);
            this.lblListadoEstudiantes.TabIndex = 2;
            this.lblListadoEstudiantes.Text = "Listado de Estudiantes";
            // 
            // frmInformeEstudiante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblListadoEstudiantes);
            this.Controls.Add(this.dtgEstudiante);
            this.Name = "frmInformeEstudiante";
            this.Text = "frmInformeEstudiante";
            this.Load += new System.EventHandler(this.frmInformeEstudiante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstudiante)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgEstudiante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Carnet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Programa;
        private System.Windows.Forms.DataGridViewTextBoxColumn E_mail;
        private System.Windows.Forms.Label lblListadoEstudiantes;
    }
}