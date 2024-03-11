namespace TPVExamen
{
    partial class BackEnd
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
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.buttonDarAlta = new System.Windows.Forms.Button();
            this.buttonNuevaTienda = new System.Windows.Forms.Button();
            this.buttonSeleccionarTienda = new System.Windows.Forms.Button();
            this.buttonAñadirStock = new System.Windows.Forms.Button();
            this.buttonCrearTiendaADM = new System.Windows.Forms.Button();
            this.buttonCerrarTiendaADM = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAltaIndependiente = new System.Windows.Forms.Button();
            this.buttonModificarIndependiente = new System.Windows.Forms.Button();
            this.buttonBajaIndependiente = new System.Windows.Forms.Button();
            this.buttonListarIndependiente = new System.Windows.Forms.Button();
            this.gbInsertar = new System.Windows.Forms.GroupBox();
            this.txtStockMin = new System.Windows.Forms.TextBox();
            this.lblStockMin = new System.Windows.Forms.Label();
            this.txtProcedencia = new System.Windows.Forms.TextBox();
            this.lblProcedencia = new System.Windows.Forms.Label();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.pbImagenCargada = new System.Windows.Forms.PictureBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnAniadir = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblImagen = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.btnCargarImagen = new System.Windows.Forms.Button();
            this.flpFrutas = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonPedidoManual = new System.Windows.Forms.Button();
            this.buttonGenerarInformePManual = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.gbInsertar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenCargada)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(286, 5);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(475, 213);
            this.dgv1.TabIndex = 0;
            this.dgv1.Visible = false;
            // 
            // buttonDarAlta
            // 
            this.buttonDarAlta.Location = new System.Drawing.Point(13, 13);
            this.buttonDarAlta.Name = "buttonDarAlta";
            this.buttonDarAlta.Size = new System.Drawing.Size(125, 23);
            this.buttonDarAlta.TabIndex = 1;
            this.buttonDarAlta.Text = "Dar de alta ";
            this.buttonDarAlta.UseVisualStyleBackColor = true;
            this.buttonDarAlta.Visible = false;
            // 
            // buttonNuevaTienda
            // 
            this.buttonNuevaTienda.Location = new System.Drawing.Point(144, 13);
            this.buttonNuevaTienda.Name = "buttonNuevaTienda";
            this.buttonNuevaTienda.Size = new System.Drawing.Size(125, 23);
            this.buttonNuevaTienda.TabIndex = 2;
            this.buttonNuevaTienda.Text = "Nueva tienda";
            this.buttonNuevaTienda.UseVisualStyleBackColor = true;
            this.buttonNuevaTienda.Visible = false;
            // 
            // buttonSeleccionarTienda
            // 
            this.buttonSeleccionarTienda.Location = new System.Drawing.Point(12, 42);
            this.buttonSeleccionarTienda.Name = "buttonSeleccionarTienda";
            this.buttonSeleccionarTienda.Size = new System.Drawing.Size(125, 23);
            this.buttonSeleccionarTienda.TabIndex = 3;
            this.buttonSeleccionarTienda.Text = "Seleccionar Tienda";
            this.buttonSeleccionarTienda.UseVisualStyleBackColor = true;
            this.buttonSeleccionarTienda.Visible = false;
            // 
            // buttonAñadirStock
            // 
            this.buttonAñadirStock.Location = new System.Drawing.Point(143, 42);
            this.buttonAñadirStock.Name = "buttonAñadirStock";
            this.buttonAñadirStock.Size = new System.Drawing.Size(125, 23);
            this.buttonAñadirStock.TabIndex = 4;
            this.buttonAñadirStock.Text = "Añadir Stock";
            this.buttonAñadirStock.UseVisualStyleBackColor = true;
            this.buttonAñadirStock.Visible = false;
            // 
            // buttonCrearTiendaADM
            // 
            this.buttonCrearTiendaADM.Location = new System.Drawing.Point(76, 71);
            this.buttonCrearTiendaADM.Name = "buttonCrearTiendaADM";
            this.buttonCrearTiendaADM.Size = new System.Drawing.Size(125, 23);
            this.buttonCrearTiendaADM.TabIndex = 5;
            this.buttonCrearTiendaADM.Text = "Crear tienda (admin)";
            this.buttonCrearTiendaADM.UseVisualStyleBackColor = true;
            this.buttonCrearTiendaADM.Visible = false;
            this.buttonCrearTiendaADM.Click += new System.EventHandler(this.buttonCrearTiendaADM_Click);
            // 
            // buttonCerrarTiendaADM
            // 
            this.buttonCerrarTiendaADM.Location = new System.Drawing.Point(76, 100);
            this.buttonCerrarTiendaADM.Name = "buttonCerrarTiendaADM";
            this.buttonCerrarTiendaADM.Size = new System.Drawing.Size(125, 23);
            this.buttonCerrarTiendaADM.TabIndex = 6;
            this.buttonCerrarTiendaADM.Text = "Cerrar tienda (admin)";
            this.buttonCerrarTiendaADM.UseVisualStyleBackColor = true;
            this.buttonCerrarTiendaADM.Visible = false;
            this.buttonCerrarTiendaADM.Click += new System.EventHandler(this.buttonCerrarTiendaADM_Click);
            // 
            // buttonSalir
            // 
            this.buttonSalir.Location = new System.Drawing.Point(12, 470);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(75, 23);
            this.buttonSalir.TabIndex = 8;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Gestion Independiente";
            // 
            // buttonAltaIndependiente
            // 
            this.buttonAltaIndependiente.Location = new System.Drawing.Point(13, 204);
            this.buttonAltaIndependiente.Name = "buttonAltaIndependiente";
            this.buttonAltaIndependiente.Size = new System.Drawing.Size(124, 23);
            this.buttonAltaIndependiente.TabIndex = 11;
            this.buttonAltaIndependiente.Text = "Alta";
            this.buttonAltaIndependiente.UseVisualStyleBackColor = true;
            this.buttonAltaIndependiente.Visible = false;
            this.buttonAltaIndependiente.Click += new System.EventHandler(this.buttonAltaIndependiente_Click);
            // 
            // buttonModificarIndependiente
            // 
            this.buttonModificarIndependiente.Location = new System.Drawing.Point(13, 233);
            this.buttonModificarIndependiente.Name = "buttonModificarIndependiente";
            this.buttonModificarIndependiente.Size = new System.Drawing.Size(124, 23);
            this.buttonModificarIndependiente.TabIndex = 13;
            this.buttonModificarIndependiente.Text = "Modificar";
            this.buttonModificarIndependiente.UseVisualStyleBackColor = true;
            this.buttonModificarIndependiente.Visible = false;
            this.buttonModificarIndependiente.Click += new System.EventHandler(this.buttonModificarIndependiente_Click);
            // 
            // buttonBajaIndependiente
            // 
            this.buttonBajaIndependiente.Location = new System.Drawing.Point(144, 204);
            this.buttonBajaIndependiente.Name = "buttonBajaIndependiente";
            this.buttonBajaIndependiente.Size = new System.Drawing.Size(124, 23);
            this.buttonBajaIndependiente.TabIndex = 14;
            this.buttonBajaIndependiente.Text = "Baja";
            this.buttonBajaIndependiente.UseVisualStyleBackColor = true;
            this.buttonBajaIndependiente.Visible = false;
            this.buttonBajaIndependiente.Click += new System.EventHandler(this.buttonBajaIndependiente_Click);
            // 
            // buttonListarIndependiente
            // 
            this.buttonListarIndependiente.Location = new System.Drawing.Point(143, 233);
            this.buttonListarIndependiente.Name = "buttonListarIndependiente";
            this.buttonListarIndependiente.Size = new System.Drawing.Size(124, 23);
            this.buttonListarIndependiente.TabIndex = 15;
            this.buttonListarIndependiente.Text = "Listar";
            this.buttonListarIndependiente.UseVisualStyleBackColor = true;
            this.buttonListarIndependiente.Visible = false;
            this.buttonListarIndependiente.Click += new System.EventHandler(this.buttonListarIndependiente_Click);
            // 
            // gbInsertar
            // 
            this.gbInsertar.Controls.Add(this.txtStockMin);
            this.gbInsertar.Controls.Add(this.lblStockMin);
            this.gbInsertar.Controls.Add(this.txtProcedencia);
            this.gbInsertar.Controls.Add(this.lblProcedencia);
            this.gbInsertar.Controls.Add(this.btnGuardarCambios);
            this.gbInsertar.Controls.Add(this.pbImagenCargada);
            this.gbInsertar.Controls.Add(this.txtId);
            this.gbInsertar.Controls.Add(this.lblId);
            this.gbInsertar.Controls.Add(this.btnAniadir);
            this.gbInsertar.Controls.Add(this.lblNombre);
            this.gbInsertar.Controls.Add(this.txtStock);
            this.gbInsertar.Controls.Add(this.lblPrecio);
            this.gbInsertar.Controls.Add(this.lblImagen);
            this.gbInsertar.Controls.Add(this.txtPrecio);
            this.gbInsertar.Controls.Add(this.txtNombre);
            this.gbInsertar.Controls.Add(this.lblStock);
            this.gbInsertar.Controls.Add(this.btnCargarImagen);
            this.gbInsertar.Location = new System.Drawing.Point(766, 100);
            this.gbInsertar.Margin = new System.Windows.Forms.Padding(2);
            this.gbInsertar.Name = "gbInsertar";
            this.gbInsertar.Padding = new System.Windows.Forms.Padding(2);
            this.gbInsertar.Size = new System.Drawing.Size(381, 271);
            this.gbInsertar.TabIndex = 19;
            this.gbInsertar.TabStop = false;
            this.gbInsertar.Visible = false;
            // 
            // txtStockMin
            // 
            this.txtStockMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockMin.Location = new System.Drawing.Point(107, 203);
            this.txtStockMin.Margin = new System.Windows.Forms.Padding(2);
            this.txtStockMin.Name = "txtStockMin";
            this.txtStockMin.Size = new System.Drawing.Size(158, 23);
            this.txtStockMin.TabIndex = 26;
            // 
            // lblStockMin
            // 
            this.lblStockMin.AutoSize = true;
            this.lblStockMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockMin.Location = new System.Drawing.Point(8, 206);
            this.lblStockMin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStockMin.Name = "lblStockMin";
            this.lblStockMin.Size = new System.Drawing.Size(95, 17);
            this.lblStockMin.TabIndex = 25;
            this.lblStockMin.Text = "Stock Minimo:";
            // 
            // txtProcedencia
            // 
            this.txtProcedencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcedencia.Location = new System.Drawing.Point(107, 168);
            this.txtProcedencia.Margin = new System.Windows.Forms.Padding(2);
            this.txtProcedencia.Name = "txtProcedencia";
            this.txtProcedencia.Size = new System.Drawing.Size(158, 23);
            this.txtProcedencia.TabIndex = 24;
            // 
            // lblProcedencia
            // 
            this.lblProcedencia.AutoSize = true;
            this.lblProcedencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcedencia.Location = new System.Drawing.Point(8, 171);
            this.lblProcedencia.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProcedencia.Name = "lblProcedencia";
            this.lblProcedencia.Size = new System.Drawing.Size(91, 17);
            this.lblProcedencia.TabIndex = 23;
            this.lblProcedencia.Text = "Procedencia:";
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCambios.Location = new System.Drawing.Point(20, 235);
            this.btnGuardarCambios.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(335, 32);
            this.btnGuardarCambios.TabIndex = 22;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            this.btnGuardarCambios.Visible = false;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // pbImagenCargada
            // 
            this.pbImagenCargada.Location = new System.Drawing.Point(289, 90);
            this.pbImagenCargada.Margin = new System.Windows.Forms.Padding(2);
            this.pbImagenCargada.Name = "pbImagenCargada";
            this.pbImagenCargada.Size = new System.Drawing.Size(66, 56);
            this.pbImagenCargada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagenCargada.TabIndex = 21;
            this.pbImagenCargada.TabStop = false;
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(108, 16);
            this.txtId.Margin = new System.Windows.Forms.Padding(2);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(158, 23);
            this.txtId.TabIndex = 20;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(8, 16);
            this.lblId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(23, 17);
            this.lblId.TabIndex = 19;
            this.lblId.Text = "Id:";
            // 
            // btnAniadir
            // 
            this.btnAniadir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAniadir.Location = new System.Drawing.Point(20, 235);
            this.btnAniadir.Margin = new System.Windows.Forms.Padding(2);
            this.btnAniadir.Name = "btnAniadir";
            this.btnAniadir.Size = new System.Drawing.Size(335, 32);
            this.btnAniadir.TabIndex = 17;
            this.btnAniadir.Text = "Añadir";
            this.btnAniadir.UseVisualStyleBackColor = true;
            this.btnAniadir.Visible = false;
            this.btnAniadir.Click += new System.EventHandler(this.btnAniadir_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(8, 44);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(62, 17);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtStock
            // 
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.Location = new System.Drawing.Point(108, 135);
            this.txtStock.Margin = new System.Windows.Forms.Padding(2);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(158, 23);
            this.txtStock.TabIndex = 16;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(8, 77);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(52, 17);
            this.lblPrecio.TabIndex = 7;
            this.lblPrecio.Text = "Precio:";
            // 
            // lblImagen
            // 
            this.lblImagen.AutoSize = true;
            this.lblImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImagen.Location = new System.Drawing.Point(8, 106);
            this.lblImagen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImagen.Name = "lblImagen";
            this.lblImagen.Size = new System.Drawing.Size(58, 17);
            this.lblImagen.TabIndex = 8;
            this.lblImagen.Text = "Imagen:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(108, 72);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(158, 23);
            this.txtPrecio.TabIndex = 14;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(108, 44);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(158, 23);
            this.txtNombre.TabIndex = 13;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStock.Location = new System.Drawing.Point(8, 138);
            this.lblStock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(47, 17);
            this.lblStock.TabIndex = 10;
            this.lblStock.Text = "Stock:";
            // 
            // btnCargarImagen
            // 
            this.btnCargarImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarImagen.Location = new System.Drawing.Point(108, 101);
            this.btnCargarImagen.Margin = new System.Windows.Forms.Padding(2);
            this.btnCargarImagen.Name = "btnCargarImagen";
            this.btnCargarImagen.Size = new System.Drawing.Size(157, 28);
            this.btnCargarImagen.TabIndex = 11;
            this.btnCargarImagen.Text = "Cargar Imagen";
            this.btnCargarImagen.UseVisualStyleBackColor = true;
            this.btnCargarImagen.Click += new System.EventHandler(this.btnCargarImagen_Click);
            // 
            // flpFrutas
            // 
            this.flpFrutas.AutoScroll = true;
            this.flpFrutas.Location = new System.Drawing.Point(286, 222);
            this.flpFrutas.Margin = new System.Windows.Forms.Padding(2);
            this.flpFrutas.Name = "flpFrutas";
            this.flpFrutas.Size = new System.Drawing.Size(475, 271);
            this.flpFrutas.TabIndex = 20;
            this.flpFrutas.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(105, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Pedidos";
            // 
            // buttonPedidoManual
            // 
            this.buttonPedidoManual.Location = new System.Drawing.Point(13, 335);
            this.buttonPedidoManual.Name = "buttonPedidoManual";
            this.buttonPedidoManual.Size = new System.Drawing.Size(124, 23);
            this.buttonPedidoManual.TabIndex = 22;
            this.buttonPedidoManual.Text = "Pedido (Manual)";
            this.buttonPedidoManual.UseVisualStyleBackColor = true;
            this.buttonPedidoManual.Visible = false;
            this.buttonPedidoManual.Click += new System.EventHandler(this.buttonPedidoManual_Click);
            // 
            // buttonGenerarInformePManual
            // 
            this.buttonGenerarInformePManual.Location = new System.Drawing.Point(13, 364);
            this.buttonGenerarInformePManual.Name = "buttonGenerarInformePManual";
            this.buttonGenerarInformePManual.Size = new System.Drawing.Size(256, 23);
            this.buttonGenerarInformePManual.TabIndex = 23;
            this.buttonGenerarInformePManual.Text = "Generar informe pedido manual";
            this.buttonGenerarInformePManual.UseVisualStyleBackColor = true;
            this.buttonGenerarInformePManual.Visible = false;
            this.buttonGenerarInformePManual.Click += new System.EventHandler(this.buttonGenerarInformePManual_Click);
            // 
            // BackEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 505);
            this.Controls.Add(this.buttonGenerarInformePManual);
            this.Controls.Add(this.buttonPedidoManual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flpFrutas);
            this.Controls.Add(this.gbInsertar);
            this.Controls.Add(this.buttonListarIndependiente);
            this.Controls.Add(this.buttonBajaIndependiente);
            this.Controls.Add(this.buttonModificarIndependiente);
            this.Controls.Add(this.buttonAltaIndependiente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.buttonCerrarTiendaADM);
            this.Controls.Add(this.buttonCrearTiendaADM);
            this.Controls.Add(this.buttonAñadirStock);
            this.Controls.Add(this.buttonSeleccionarTienda);
            this.Controls.Add(this.buttonNuevaTienda);
            this.Controls.Add(this.buttonDarAlta);
            this.Controls.Add(this.dgv1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BackEnd";
            this.Text = "BackEnd";
            this.Load += new System.EventHandler(this.BackEnd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.gbInsertar.ResumeLayout(false);
            this.gbInsertar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenCargada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button buttonDarAlta;
        private System.Windows.Forms.Button buttonNuevaTienda;
        private System.Windows.Forms.Button buttonSeleccionarTienda;
        private System.Windows.Forms.Button buttonAñadirStock;
        private System.Windows.Forms.Button buttonCrearTiendaADM;
        private System.Windows.Forms.Button buttonCerrarTiendaADM;
        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAltaIndependiente;
        private System.Windows.Forms.Button buttonModificarIndependiente;
        private System.Windows.Forms.Button buttonBajaIndependiente;
        private System.Windows.Forms.Button buttonListarIndependiente;
        private System.Windows.Forms.GroupBox gbInsertar;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.PictureBox pbImagenCargada;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnAniadir;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblImagen;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Button btnCargarImagen;
        private System.Windows.Forms.TextBox txtProcedencia;
        private System.Windows.Forms.Label lblProcedencia;
        private System.Windows.Forms.TextBox txtStockMin;
        private System.Windows.Forms.Label lblStockMin;
        private System.Windows.Forms.FlowLayoutPanel flpFrutas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonPedidoManual;
        private System.Windows.Forms.Button buttonGenerarInformePManual;
    }
}