
namespace Farmacia_version_2._0
{
    partial class FormularioPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioPrincipal));
            this.etiquetaBuscarId = new System.Windows.Forms.Label();
            this.EtiquetaBuscarNombre = new System.Windows.Forms.Label();
            this.txtCodigoBarra = new System.Windows.Forms.TextBox();
            this.txtBuscarNombre = new System.Windows.Forms.TextBox();
            this.btnGestion = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.lbTotalPagar = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.dtgCestaCompra = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.numericUpDownFilas = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownColumnas = new System.Windows.Forms.NumericUpDown();
            this.lbStockActual = new System.Windows.Forms.Label();
            this.lbStockMin = new System.Windows.Forms.Label();
            this.lbPrecio = new System.Windows.Forms.Label();
            this.lbNombre = new System.Windows.Forms.Label();
            this.tabControl_Med = new System.Windows.Forms.TabControl();
            this.grbFuncionalidad = new System.Windows.Forms.GroupBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.grbAccesorio = new System.Windows.Forms.GroupBox();
            this.etiquetaStockActual = new System.Windows.Forms.Label();
            this.etiquetaStockMin = new System.Windows.Forms.Label();
            this.etiquetaPrecio = new System.Windows.Forms.Label();
            this.etiquetaNombre = new System.Windows.Forms.Label();
            this.grbAcceso = new System.Windows.Forms.GroupBox();
            this.etiquetaPwd = new System.Windows.Forms.Label();
            this.etiquetaDni = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtdni = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCestaCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFilas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumnas)).BeginInit();
            this.grbFuncionalidad.SuspendLayout();
            this.grbAccesorio.SuspendLayout();
            this.grbAcceso.SuspendLayout();
            this.SuspendLayout();
            // 
            // etiquetaBuscarId
            // 
            this.etiquetaBuscarId.AutoSize = true;
            this.etiquetaBuscarId.Location = new System.Drawing.Point(464, 15);
            this.etiquetaBuscarId.Name = "etiquetaBuscarId";
            this.etiquetaBuscarId.Size = new System.Drawing.Size(69, 13);
            this.etiquetaBuscarId.TabIndex = 62;
            this.etiquetaBuscarId.Text = "Buscar por id";
            // 
            // EtiquetaBuscarNombre
            // 
            this.EtiquetaBuscarNombre.AutoSize = true;
            this.EtiquetaBuscarNombre.Location = new System.Drawing.Point(464, 54);
            this.EtiquetaBuscarNombre.Name = "EtiquetaBuscarNombre";
            this.EtiquetaBuscarNombre.Size = new System.Drawing.Size(96, 13);
            this.EtiquetaBuscarNombre.TabIndex = 61;
            this.EtiquetaBuscarNombre.Text = "Buscar por nombre";
            // 
            // txtCodigoBarra
            // 
            this.txtCodigoBarra.Location = new System.Drawing.Point(458, 31);
            this.txtCodigoBarra.Name = "txtCodigoBarra";
            this.txtCodigoBarra.Size = new System.Drawing.Size(119, 20);
            this.txtCodigoBarra.TabIndex = 55;
            this.txtCodigoBarra.TextChanged += new System.EventHandler(this.txtCodigoBarra_TextChanged);
            // 
            // txtBuscarNombre
            // 
            this.txtBuscarNombre.Location = new System.Drawing.Point(458, 69);
            this.txtBuscarNombre.Name = "txtBuscarNombre";
            this.txtBuscarNombre.Size = new System.Drawing.Size(119, 20);
            this.txtBuscarNombre.TabIndex = 54;
            this.txtBuscarNombre.TextChanged += new System.EventHandler(this.txtBuscarNombre_TextChanged);
            // 
            // btnGestion
            // 
            this.btnGestion.Location = new System.Drawing.Point(23, 231);
            this.btnGestion.Name = "btnGestion";
            this.btnGestion.Size = new System.Drawing.Size(75, 46);
            this.btnGestion.TabIndex = 53;
            this.btnGestion.Text = "Gestión";
            this.btnGestion.UseVisualStyleBackColor = true;
            this.btnGestion.Visible = false;
            this.btnGestion.Click += new System.EventHandler(this.btnGestion_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(23, 187);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 38);
            this.btnSalir.TabIndex = 52;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(23, 135);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(75, 46);
            this.btnCerrarSesion.TabIndex = 51;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // lbTotalPagar
            // 
            this.lbTotalPagar.AutoSize = true;
            this.lbTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalPagar.Location = new System.Drawing.Point(6, 22);
            this.lbTotalPagar.Name = "lbTotalPagar";
            this.lbTotalPagar.Size = new System.Drawing.Size(60, 25);
            this.lbTotalPagar.TabIndex = 48;
            this.lbTotalPagar.Text = "Total";
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(23, 83);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(75, 46);
            this.btnPagar.TabIndex = 47;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // dtgCestaCompra
            // 
            this.dtgCestaCompra.AllowUserToAddRows = false;
            this.dtgCestaCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCestaCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Precio});
            this.dtgCestaCompra.Enabled = false;
            this.dtgCestaCompra.Location = new System.Drawing.Point(12, 12);
            this.dtgCestaCompra.Name = "dtgCestaCompra";
            this.dtgCestaCompra.ReadOnly = true;
            this.dtgCestaCompra.RowHeadersVisible = false;
            this.dtgCestaCompra.RowHeadersWidth = 10;
            this.dtgCestaCompra.Size = new System.Drawing.Size(176, 328);
            this.dtgCestaCompra.TabIndex = 46;
            this.dtgCestaCompra.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCestaCompra_CellContentDoubleClick);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 75;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 50;
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.Location = new System.Drawing.Point(23, 29);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(75, 48);
            this.btnNuevoCliente.TabIndex = 45;
            this.btnNuevoCliente.Text = "Nuevo Cliente";
            this.btnNuevoCliente.UseVisualStyleBackColor = true;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(618, 66);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(75, 23);
            this.btnRefrescar.TabIndex = 44;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // numericUpDownFilas
            // 
            this.numericUpDownFilas.Location = new System.Drawing.Point(632, 15);
            this.numericUpDownFilas.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownFilas.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownFilas.Name = "numericUpDownFilas";
            this.numericUpDownFilas.ReadOnly = true;
            this.numericUpDownFilas.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownFilas.TabIndex = 43;
            this.numericUpDownFilas.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownFilas.ValueChanged += new System.EventHandler(this.numericUpDownFilas_ValueChanged);
            // 
            // numericUpDownColumnas
            // 
            this.numericUpDownColumnas.Location = new System.Drawing.Point(632, 40);
            this.numericUpDownColumnas.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownColumnas.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownColumnas.Name = "numericUpDownColumnas";
            this.numericUpDownColumnas.ReadOnly = true;
            this.numericUpDownColumnas.Size = new System.Drawing.Size(47, 20);
            this.numericUpDownColumnas.TabIndex = 42;
            this.numericUpDownColumnas.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownColumnas.ValueChanged += new System.EventHandler(this.numericUpDownColumnas_ValueChanged);
            // 
            // lbStockActual
            // 
            this.lbStockActual.AutoSize = true;
            this.lbStockActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbStockActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStockActual.ForeColor = System.Drawing.Color.Red;
            this.lbStockActual.Location = new System.Drawing.Point(355, 55);
            this.lbStockActual.Name = "lbStockActual";
            this.lbStockActual.Size = new System.Drawing.Size(89, 20);
            this.lbStockActual.TabIndex = 41;
            this.lbStockActual.Text = "StockActual";
            // 
            // lbStockMin
            // 
            this.lbStockMin.AutoSize = true;
            this.lbStockMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbStockMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStockMin.ForeColor = System.Drawing.Color.Red;
            this.lbStockMin.Location = new System.Drawing.Point(355, 22);
            this.lbStockMin.Name = "lbStockMin";
            this.lbStockMin.Size = new System.Drawing.Size(73, 20);
            this.lbStockMin.TabIndex = 40;
            this.lbStockMin.Text = "StockMin";
            // 
            // lbPrecio
            // 
            this.lbPrecio.AutoSize = true;
            this.lbPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrecio.ForeColor = System.Drawing.Color.Red;
            this.lbPrecio.Location = new System.Drawing.Point(161, 55);
            this.lbPrecio.Name = "lbPrecio";
            this.lbPrecio.Size = new System.Drawing.Size(53, 20);
            this.lbPrecio.TabIndex = 39;
            this.lbPrecio.Text = "Precio";
            // 
            // lbNombre
            // 
            this.lbNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombre.ForeColor = System.Drawing.Color.Red;
            this.lbNombre.Location = new System.Drawing.Point(161, 21);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(97, 23);
            this.lbNombre.TabIndex = 38;
            this.lbNombre.Text = "Nombre";
            // 
            // tabControl_Med
            // 
            this.tabControl_Med.Enabled = false;
            this.tabControl_Med.Location = new System.Drawing.Point(194, 11);
            this.tabControl_Med.Name = "tabControl_Med";
            this.tabControl_Med.SelectedIndex = 0;
            this.tabControl_Med.ShowToolTips = true;
            this.tabControl_Med.Size = new System.Drawing.Size(592, 334);
            this.tabControl_Med.TabIndex = 37;
            this.tabControl_Med.SelectedIndexChanged += new System.EventHandler(this.tabControl_Med_SelectedIndexChanged);
            // 
            // grbFuncionalidad
            // 
            this.grbFuncionalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grbFuncionalidad.Controls.Add(this.lblUsuario);
            this.grbFuncionalidad.Controls.Add(this.btnNuevoCliente);
            this.grbFuncionalidad.Controls.Add(this.btnPagar);
            this.grbFuncionalidad.Controls.Add(this.btnGestion);
            this.grbFuncionalidad.Controls.Add(this.btnCerrarSesion);
            this.grbFuncionalidad.Controls.Add(this.btnSalir);
            this.grbFuncionalidad.Enabled = false;
            this.grbFuncionalidad.Location = new System.Drawing.Point(792, 20);
            this.grbFuncionalidad.Name = "grbFuncionalidad";
            this.grbFuncionalidad.Size = new System.Drawing.Size(127, 325);
            this.grbFuncionalidad.TabIndex = 65;
            this.grbFuncionalidad.TabStop = false;
            this.grbFuncionalidad.Text = "Funcionalidad";
            this.grbFuncionalidad.Enter += new System.EventHandler(this.grbFuncionalidad_Enter);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(6, 297);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(29, 13);
            this.lblUsuario.TabIndex = 54;
            this.lblUsuario.Text = "User";
            // 
            // grbAccesorio
            // 
            this.grbAccesorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grbAccesorio.Controls.Add(this.etiquetaStockActual);
            this.grbAccesorio.Controls.Add(this.etiquetaStockMin);
            this.grbAccesorio.Controls.Add(this.etiquetaPrecio);
            this.grbAccesorio.Controls.Add(this.etiquetaNombre);
            this.grbAccesorio.Controls.Add(this.txtBuscarNombre);
            this.grbAccesorio.Controls.Add(this.lbNombre);
            this.grbAccesorio.Controls.Add(this.lbPrecio);
            this.grbAccesorio.Controls.Add(this.lbStockMin);
            this.grbAccesorio.Controls.Add(this.etiquetaBuscarId);
            this.grbAccesorio.Controls.Add(this.lbStockActual);
            this.grbAccesorio.Controls.Add(this.EtiquetaBuscarNombre);
            this.grbAccesorio.Controls.Add(this.numericUpDownColumnas);
            this.grbAccesorio.Controls.Add(this.txtCodigoBarra);
            this.grbAccesorio.Controls.Add(this.numericUpDownFilas);
            this.grbAccesorio.Controls.Add(this.btnRefrescar);
            this.grbAccesorio.Controls.Add(this.lbTotalPagar);
            this.grbAccesorio.Enabled = false;
            this.grbAccesorio.Location = new System.Drawing.Point(12, 351);
            this.grbAccesorio.Name = "grbAccesorio";
            this.grbAccesorio.Size = new System.Drawing.Size(735, 95);
            this.grbAccesorio.TabIndex = 66;
            this.grbAccesorio.TabStop = false;
            this.grbAccesorio.Text = "Accesorio";
            // 
            // etiquetaStockActual
            // 
            this.etiquetaStockActual.AutoSize = true;
            this.etiquetaStockActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaStockActual.Location = new System.Drawing.Point(260, 57);
            this.etiquetaStockActual.Name = "etiquetaStockActual";
            this.etiquetaStockActual.Size = new System.Drawing.Size(95, 18);
            this.etiquetaStockActual.TabIndex = 68;
            this.etiquetaStockActual.Text = "StockActual: ";
            // 
            // etiquetaStockMin
            // 
            this.etiquetaStockMin.AutoSize = true;
            this.etiquetaStockMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaStockMin.Location = new System.Drawing.Point(262, 22);
            this.etiquetaStockMin.Name = "etiquetaStockMin";
            this.etiquetaStockMin.Size = new System.Drawing.Size(75, 18);
            this.etiquetaStockMin.TabIndex = 67;
            this.etiquetaStockMin.Text = "StockMin:";
            // 
            // etiquetaPrecio
            // 
            this.etiquetaPrecio.AutoSize = true;
            this.etiquetaPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaPrecio.Location = new System.Drawing.Point(100, 57);
            this.etiquetaPrecio.Name = "etiquetaPrecio";
            this.etiquetaPrecio.Size = new System.Drawing.Size(55, 18);
            this.etiquetaPrecio.TabIndex = 66;
            this.etiquetaPrecio.Text = "Precio:";
            // 
            // etiquetaNombre
            // 
            this.etiquetaNombre.AutoSize = true;
            this.etiquetaNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etiquetaNombre.Location = new System.Drawing.Point(92, 24);
            this.etiquetaNombre.Name = "etiquetaNombre";
            this.etiquetaNombre.Size = new System.Drawing.Size(66, 18);
            this.etiquetaNombre.TabIndex = 65;
            this.etiquetaNombre.Text = "Nombre:";
            // 
            // grbAcceso
            // 
            this.grbAcceso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grbAcceso.Controls.Add(this.etiquetaPwd);
            this.grbAcceso.Controls.Add(this.etiquetaDni);
            this.grbAcceso.Controls.Add(this.txtPwd);
            this.grbAcceso.Controls.Add(this.txtdni);
            this.grbAcceso.Location = new System.Drawing.Point(753, 360);
            this.grbAcceso.Name = "grbAcceso";
            this.grbAcceso.Size = new System.Drawing.Size(154, 86);
            this.grbAcceso.TabIndex = 1;
            this.grbAcceso.TabStop = false;
            this.grbAcceso.Text = "Acceso";
            // 
            // etiquetaPwd
            // 
            this.etiquetaPwd.AutoSize = true;
            this.etiquetaPwd.Location = new System.Drawing.Point(7, 62);
            this.etiquetaPwd.Name = "etiquetaPwd";
            this.etiquetaPwd.Size = new System.Drawing.Size(28, 13);
            this.etiquetaPwd.TabIndex = 68;
            this.etiquetaPwd.Text = "Pwd";
            // 
            // etiquetaDni
            // 
            this.etiquetaDni.AutoSize = true;
            this.etiquetaDni.Location = new System.Drawing.Point(7, 25);
            this.etiquetaDni.Name = "etiquetaDni";
            this.etiquetaDni.Size = new System.Drawing.Size(26, 13);
            this.etiquetaDni.TabIndex = 67;
            this.etiquetaDni.Text = "DNI";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(33, 57);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(115, 20);
            this.txtPwd.TabIndex = 66;
            this.txtPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPwd_KeyPress);
            // 
            // txtdni
            // 
            this.txtdni.Location = new System.Drawing.Point(33, 22);
            this.txtdni.Name = "txtdni";
            this.txtdni.Size = new System.Drawing.Size(115, 20);
            this.txtdni.TabIndex = 0;
            // 
            // FormularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 450);
            this.Controls.Add(this.grbAcceso);
            this.Controls.Add(this.grbAccesorio);
            this.Controls.Add(this.grbFuncionalidad);
            this.Controls.Add(this.dtgCestaCompra);
            this.Controls.Add(this.tabControl_Med);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormularioPrincipal";
            this.Text = "Farmacia. TPV";
            this.Load += new System.EventHandler(this.FormularioPrincipal_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormularioPrincipal_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dtgCestaCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFilas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumnas)).EndInit();
            this.grbFuncionalidad.ResumeLayout(false);
            this.grbFuncionalidad.PerformLayout();
            this.grbAccesorio.ResumeLayout(false);
            this.grbAccesorio.PerformLayout();
            this.grbAcceso.ResumeLayout(false);
            this.grbAcceso.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label etiquetaBuscarId;
        private System.Windows.Forms.Label EtiquetaBuscarNombre;
        private System.Windows.Forms.TextBox txtCodigoBarra;
        private System.Windows.Forms.TextBox txtBuscarNombre;
        private System.Windows.Forms.Button btnGestion;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label lbTotalPagar;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.DataGridView dtgCestaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.Button btnNuevoCliente;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.NumericUpDown numericUpDownFilas;
        private System.Windows.Forms.NumericUpDown numericUpDownColumnas;
        private System.Windows.Forms.Label lbStockActual;
        private System.Windows.Forms.Label lbStockMin;
        private System.Windows.Forms.Label lbPrecio;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.TabControl tabControl_Med;
        private System.Windows.Forms.GroupBox grbFuncionalidad;
        private System.Windows.Forms.GroupBox grbAccesorio;
        private System.Windows.Forms.Label etiquetaStockActual;
        private System.Windows.Forms.Label etiquetaStockMin;
        private System.Windows.Forms.Label etiquetaPrecio;
        private System.Windows.Forms.Label etiquetaNombre;
        private System.Windows.Forms.GroupBox grbAcceso;
        private System.Windows.Forms.Label etiquetaPwd;
        private System.Windows.Forms.Label etiquetaDni;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtdni;
        private System.Windows.Forms.Label lblUsuario;
    }
}

