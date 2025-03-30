namespace Clase2.Formularios
{
    partial class FrmInformeAutor
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
            this.lblListadoEstudiantes = new System.Windows.Forms.Label();
            this.dtgAutores = new System.Windows.Forms.DataGridView();
            this.tblAutorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bdBibliotecaDataSet = new Clase2.bdBibliotecaDataSet();
            this.tblAutorTableAdapter = new Clase2.bdBibliotecaDataSetTableAdapters.TblAutorTableAdapter();
            this.cedulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreAutorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechanacimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewImageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.panelBusqueda = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.panelDatos = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAutores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAutorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdBibliotecaDataSet)).BeginInit();
            this.panelTitulo.SuspendLayout();
            this.panelBusqueda.SuspendLayout();
            this.panelDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblListadoEstudiantes
            // 
            this.lblListadoEstudiantes.AutoSize = true;
            this.lblListadoEstudiantes.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblListadoEstudiantes.ForeColor = System.Drawing.Color.White;
            this.lblListadoEstudiantes.Location = new System.Drawing.Point(20, 15);
            this.lblListadoEstudiantes.Name = "lblListadoEstudiantes";
            this.lblListadoEstudiantes.Size = new System.Drawing.Size(377, 46);
            this.lblListadoEstudiantes.TabIndex = 3;
            this.lblListadoEstudiantes.Text = "LISTADO DE AUTORES";
            this.lblListadoEstudiantes.Click += new System.EventHandler(this.lblListadoEstudiantes_Click);
            // 
            // dtgAutores
            // 
            this.dtgAutores.AutoGenerateColumns = false;
            this.dtgAutores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAutores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cedulaDataGridViewTextBoxColumn,
            this.nombreAutorDataGridViewTextBoxColumn,
            this.fechanacimientoDataGridViewTextBoxColumn,
            this.emailDataGridViewImageColumn});
            this.dtgAutores.DataSource = this.tblAutorBindingSource;
            this.dtgAutores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgAutores.Location = new System.Drawing.Point(0, 0);
            this.dtgAutores.Name = "dtgAutores";
            this.dtgAutores.RowHeadersWidth = 62;
            this.dtgAutores.RowTemplate.Height = 28;
            this.dtgAutores.Size = new System.Drawing.Size(850, 320);
            this.dtgAutores.TabIndex = 4;
            this.dtgAutores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgAutores_CellContentClick);
            // 
            // tblAutorBindingSource
            // 
            this.tblAutorBindingSource.DataMember = "TblAutor";
            this.tblAutorBindingSource.DataSource = this.bdBibliotecaDataSet;
            // 
            // bdBibliotecaDataSet
            // 
            this.bdBibliotecaDataSet.DataSetName = "bdBibliotecaDataSet";
            this.bdBibliotecaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblAutorTableAdapter
            // 
            this.tblAutorTableAdapter.ClearBeforeFill = true;
            // 
            // cedulaDataGridViewTextBoxColumn
            // 
            this.cedulaDataGridViewTextBoxColumn.DataPropertyName = "Cedula";
            this.cedulaDataGridViewTextBoxColumn.HeaderText = "Cédula";
            this.cedulaDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.cedulaDataGridViewTextBoxColumn.Name = "cedulaDataGridViewTextBoxColumn";
            this.cedulaDataGridViewTextBoxColumn.Width = 150;
            // 
            // nombreAutorDataGridViewTextBoxColumn
            // 
            this.nombreAutorDataGridViewTextBoxColumn.DataPropertyName = "nombreAutor";
            this.nombreAutorDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreAutorDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.nombreAutorDataGridViewTextBoxColumn.Name = "nombreAutorDataGridViewTextBoxColumn";
            this.nombreAutorDataGridViewTextBoxColumn.Width = 250;
            // 
            // fechanacimientoDataGridViewTextBoxColumn
            // 
            this.fechanacimientoDataGridViewTextBoxColumn.DataPropertyName = "Fechanacimiento";
            this.fechanacimientoDataGridViewTextBoxColumn.HeaderText = "Fecha de Nacimiento";
            this.fechanacimientoDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fechanacimientoDataGridViewTextBoxColumn.Name = "fechanacimientoDataGridViewTextBoxColumn";
            this.fechanacimientoDataGridViewTextBoxColumn.Width = 200;
            // 
            // emailDataGridViewImageColumn
            // 
            this.emailDataGridViewImageColumn.DataPropertyName = "email";
            this.emailDataGridViewImageColumn.HeaderText = "Email";
            this.emailDataGridViewImageColumn.MinimumWidth = 8;
            this.emailDataGridViewImageColumn.Name = "emailDataGridViewImageColumn";
            this.emailDataGridViewImageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.emailDataGridViewImageColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.emailDataGridViewImageColumn.Width = 250;
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.Teal;
            this.panelTitulo.Controls.Add(this.lblFecha);
            this.panelTitulo.Controls.Add(this.lblListadoEstudiantes);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(874, 70);
            this.panelTitulo.TabIndex = 5;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(734, 25);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(109, 23);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "00/00/0000";
            // 
            // panelBusqueda
            // 
            this.panelBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBusqueda.BackColor = System.Drawing.Color.LightCyan;
            this.panelBusqueda.Controls.Add(this.btnExportar);
            this.panelBusqueda.Controls.Add(this.txtBuscar);
            this.panelBusqueda.Controls.Add(this.lblBuscar);
            this.panelBusqueda.Location = new System.Drawing.Point(12, 82);
            this.panelBusqueda.Name = "panelBusqueda";
            this.panelBusqueda.Size = new System.Drawing.Size(850, 70);
            this.panelBusqueda.TabIndex = 6;
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
            this.panelDatos.Controls.Add(this.dtgAutores);
            this.panelDatos.Location = new System.Drawing.Point(12, 168);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Size = new System.Drawing.Size(850, 320);
            this.panelDatos.TabIndex = 7;
            // 
            // FrmInformeAutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(874, 500);
            this.Controls.Add(this.panelDatos);
            this.Controls.Add(this.panelBusqueda);
            this.Controls.Add(this.panelTitulo);
            this.Name = "FrmInformeAutor";
            this.Text = "Listado de Autores";
            this.Load += new System.EventHandler(this.FrmInformeAutor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAutores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblAutorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdBibliotecaDataSet)).EndInit();
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panelBusqueda.ResumeLayout(false);
            this.panelBusqueda.PerformLayout();
            this.panelDatos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblListadoEstudiantes;
        private System.Windows.Forms.DataGridView dtgAutores;
        private bdBibliotecaDataSet bdBibliotecaDataSet;
        private System.Windows.Forms.BindingSource tblAutorBindingSource;
        private bdBibliotecaDataSetTableAdapters.TblAutorTableAdapter tblAutorTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn cedulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreAutorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechanacimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewImageColumn;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel panelBusqueda;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Panel panelDatos;
    }
}