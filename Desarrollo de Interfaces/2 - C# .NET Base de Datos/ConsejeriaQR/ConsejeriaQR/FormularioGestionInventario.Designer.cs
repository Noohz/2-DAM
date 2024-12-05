namespace ConsejeriaQR
{
    partial class FormularioGestionInventario
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
            this.components = new System.ComponentModel.Container();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelNocturnoPlantaBaja = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pBPlantaBajaNoche = new System.Windows.Forms.PictureBox();
            this.panelDiurnoPlantaAlta = new System.Windows.Forms.Panel();
            this.btnPlanoAnterior = new System.Windows.Forms.Button();
            this.pBPlantaAltaDia = new System.Windows.Forms.PictureBox();
            this.panelDiurnoPlantaBaja = new System.Windows.Forms.Panel();
            this.btnCambiarPlano = new System.Windows.Forms.Button();
            this.pBPlantaBajaDia = new System.Windows.Forms.PictureBox();
            this.btnAccederInterfaz = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelOpcionesAula = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnComprobarInventario = new System.Windows.Forms.Button();
            this.btnAniadirArticulo = new System.Windows.Forms.Button();
            this.lblAulaSeleccionada = new System.Windows.Forms.Label();
            this.pBLoginIcono = new System.Windows.Forms.PictureBox();
            this.btnVolverGestionPrestamos = new System.Windows.Forms.Button();
            this.lblGestionInventarioTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.boton_desplegablePlanos = new ConsejeriaQR.Controls_Personalizados.Boton_desplegable(this.components);
            this.diurnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nocturnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boton_desplegableAniadirArticulo = new ConsejeriaQR.Controls_Personalizados.Boton_desplegable(this.components);
            this.insertarArtículoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarFicheroCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3.SuspendLayout();
            this.panelNocturnoPlantaBaja.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBPlantaBajaNoche)).BeginInit();
            this.panelDiurnoPlantaAlta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBPlantaAltaDia)).BeginInit();
            this.panelDiurnoPlantaBaja.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBPlantaBajaDia)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelOpcionesAula.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBLoginIcono)).BeginInit();
            this.panel1.SuspendLayout();
            this.boton_desplegablePlanos.SuspendLayout();
            this.boton_desplegableAniadirArticulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(103)))), ((int)(((byte)(73)))));
            this.panel3.Controls.Add(this.panelNocturnoPlantaBaja);
            this.panel3.Controls.Add(this.panelDiurnoPlantaAlta);
            this.panel3.Controls.Add(this.panelDiurnoPlantaBaja);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1280, 707);
            this.panel3.TabIndex = 5;
            // 
            // panelNocturnoPlantaBaja
            // 
            this.panelNocturnoPlantaBaja.BackColor = System.Drawing.Color.White;
            this.panelNocturnoPlantaBaja.Controls.Add(this.button1);
            this.panelNocturnoPlantaBaja.Controls.Add(this.pBPlantaBajaNoche);
            this.panelNocturnoPlantaBaja.Location = new System.Drawing.Point(319, 89);
            this.panelNocturnoPlantaBaja.Name = "panelNocturnoPlantaBaja";
            this.panelNocturnoPlantaBaja.Size = new System.Drawing.Size(944, 594);
            this.panelNocturnoPlantaBaja.TabIndex = 8;
            this.panelNocturnoPlantaBaja.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(382, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(273, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Planta alta no disponible";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // pBPlantaBajaNoche
            // 
            this.pBPlantaBajaNoche.Image = global::ConsejeriaQR.Properties.Resources.PlantaBaja_Tarde;
            this.pBPlantaBajaNoche.Location = new System.Drawing.Point(44, 62);
            this.pBPlantaBajaNoche.Name = "pBPlantaBajaNoche";
            this.pBPlantaBajaNoche.Size = new System.Drawing.Size(861, 501);
            this.pBPlantaBajaNoche.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBPlantaBajaNoche.TabIndex = 0;
            this.pBPlantaBajaNoche.TabStop = false;
            // 
            // panelDiurnoPlantaAlta
            // 
            this.panelDiurnoPlantaAlta.BackColor = System.Drawing.Color.White;
            this.panelDiurnoPlantaAlta.Controls.Add(this.btnPlanoAnterior);
            this.panelDiurnoPlantaAlta.Controls.Add(this.pBPlantaAltaDia);
            this.panelDiurnoPlantaAlta.Location = new System.Drawing.Point(311, 89);
            this.panelDiurnoPlantaAlta.Name = "panelDiurnoPlantaAlta";
            this.panelDiurnoPlantaAlta.Size = new System.Drawing.Size(944, 594);
            this.panelDiurnoPlantaAlta.TabIndex = 7;
            this.panelDiurnoPlantaAlta.Visible = false;
            // 
            // btnPlanoAnterior
            // 
            this.btnPlanoAnterior.BackColor = System.Drawing.SystemColors.Control;
            this.btnPlanoAnterior.FlatAppearance.BorderSize = 0;
            this.btnPlanoAnterior.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnPlanoAnterior.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnPlanoAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlanoAnterior.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlanoAnterior.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPlanoAnterior.Location = new System.Drawing.Point(418, 14);
            this.btnPlanoAnterior.Name = "btnPlanoAnterior";
            this.btnPlanoAnterior.Size = new System.Drawing.Size(237, 30);
            this.btnPlanoAnterior.TabIndex = 6;
            this.btnPlanoAnterior.Text = "Mostrar planta baja";
            this.btnPlanoAnterior.UseVisualStyleBackColor = false;
            this.btnPlanoAnterior.Click += new System.EventHandler(this.btnPlanoAnterior_Click);
            // 
            // pBPlantaAltaDia
            // 
            this.pBPlantaAltaDia.Image = global::ConsejeriaQR.Properties.Resources.PlantaAlta_Dia;
            this.pBPlantaAltaDia.Location = new System.Drawing.Point(44, 62);
            this.pBPlantaAltaDia.Name = "pBPlantaAltaDia";
            this.pBPlantaAltaDia.Size = new System.Drawing.Size(861, 501);
            this.pBPlantaAltaDia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBPlantaAltaDia.TabIndex = 0;
            this.pBPlantaAltaDia.TabStop = false;
            // 
            // panelDiurnoPlantaBaja
            // 
            this.panelDiurnoPlantaBaja.BackColor = System.Drawing.Color.White;
            this.panelDiurnoPlantaBaja.Controls.Add(this.btnCambiarPlano);
            this.panelDiurnoPlantaBaja.Controls.Add(this.pBPlantaBajaDia);
            this.panelDiurnoPlantaBaja.Location = new System.Drawing.Point(303, 89);
            this.panelDiurnoPlantaBaja.Name = "panelDiurnoPlantaBaja";
            this.panelDiurnoPlantaBaja.Size = new System.Drawing.Size(944, 594);
            this.panelDiurnoPlantaBaja.TabIndex = 0;
            this.panelDiurnoPlantaBaja.Visible = false;
            // 
            // btnCambiarPlano
            // 
            this.btnCambiarPlano.BackColor = System.Drawing.SystemColors.Control;
            this.btnCambiarPlano.FlatAppearance.BorderSize = 0;
            this.btnCambiarPlano.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnCambiarPlano.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnCambiarPlano.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarPlano.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarPlano.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCambiarPlano.Location = new System.Drawing.Point(418, 14);
            this.btnCambiarPlano.Name = "btnCambiarPlano";
            this.btnCambiarPlano.Size = new System.Drawing.Size(237, 30);
            this.btnCambiarPlano.TabIndex = 6;
            this.btnCambiarPlano.Text = "Mostrar planta alta";
            this.btnCambiarPlano.UseVisualStyleBackColor = false;
            this.btnCambiarPlano.Click += new System.EventHandler(this.BtnCambiarPlano_Click);
            // 
            // pBPlantaBajaDia
            // 
            this.pBPlantaBajaDia.Image = global::ConsejeriaQR.Properties.Resources.PlantaBaja_Dia;
            this.pBPlantaBajaDia.Location = new System.Drawing.Point(44, 62);
            this.pBPlantaBajaDia.Name = "pBPlantaBajaDia";
            this.pBPlantaBajaDia.Size = new System.Drawing.Size(861, 501);
            this.pBPlantaBajaDia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBPlantaBajaDia.TabIndex = 0;
            this.pBPlantaBajaDia.TabStop = false;
            this.pBPlantaBajaDia.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pBPlantaBajaDia_MouseClick);
            // 
            // btnAccederInterfaz
            // 
            this.btnAccederInterfaz.BackColor = System.Drawing.SystemColors.Control;
            this.btnAccederInterfaz.FlatAppearance.BorderSize = 0;
            this.btnAccederInterfaz.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnAccederInterfaz.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnAccederInterfaz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccederInterfaz.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccederInterfaz.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAccederInterfaz.Location = new System.Drawing.Point(12, 241);
            this.btnAccederInterfaz.Name = "btnAccederInterfaz";
            this.btnAccederInterfaz.Size = new System.Drawing.Size(221, 43);
            this.btnAccederInterfaz.TabIndex = 0;
            this.btnAccederInterfaz.Text = "Mostrar plano";
            this.btnAccederInterfaz.UseVisualStyleBackColor = false;
            this.btnAccederInterfaz.Click += new System.EventHandler(this.BtnAccederInterfaz_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.panel2.Controls.Add(this.panelOpcionesAula);
            this.panel2.Controls.Add(this.btnAccederInterfaz);
            this.panel2.Controls.Add(this.pBLoginIcono);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 662);
            this.panel2.TabIndex = 4;
            // 
            // panelOpcionesAula
            // 
            this.panelOpcionesAula.BackColor = System.Drawing.Color.White;
            this.panelOpcionesAula.Controls.Add(this.label1);
            this.panelOpcionesAula.Controls.Add(this.btnComprobarInventario);
            this.panelOpcionesAula.Controls.Add(this.btnAniadirArticulo);
            this.panelOpcionesAula.Controls.Add(this.lblAulaSeleccionada);
            this.panelOpcionesAula.Location = new System.Drawing.Point(12, 329);
            this.panelOpcionesAula.Name = "panelOpcionesAula";
            this.panelOpcionesAula.Size = new System.Drawing.Size(226, 220);
            this.panelOpcionesAula.TabIndex = 2;
            this.panelOpcionesAula.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Opciones para el aula";
            // 
            // btnComprobarInventario
            // 
            this.btnComprobarInventario.AutoSize = true;
            this.btnComprobarInventario.BackColor = System.Drawing.SystemColors.Control;
            this.btnComprobarInventario.FlatAppearance.BorderSize = 0;
            this.btnComprobarInventario.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnComprobarInventario.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnComprobarInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComprobarInventario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprobarInventario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnComprobarInventario.Location = new System.Drawing.Point(17, 152);
            this.btnComprobarInventario.Name = "btnComprobarInventario";
            this.btnComprobarInventario.Size = new System.Drawing.Size(195, 43);
            this.btnComprobarInventario.TabIndex = 3;
            this.btnComprobarInventario.Text = "Comprobar inventario";
            this.btnComprobarInventario.UseVisualStyleBackColor = false;
            this.btnComprobarInventario.Click += new System.EventHandler(this.BtnComprobarInventario_Click);
            // 
            // btnAniadirArticulo
            // 
            this.btnAniadirArticulo.AutoSize = true;
            this.btnAniadirArticulo.BackColor = System.Drawing.SystemColors.Control;
            this.btnAniadirArticulo.Enabled = false;
            this.btnAniadirArticulo.FlatAppearance.BorderSize = 0;
            this.btnAniadirArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnAniadirArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnAniadirArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAniadirArticulo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAniadirArticulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAniadirArticulo.Location = new System.Drawing.Point(17, 84);
            this.btnAniadirArticulo.Name = "btnAniadirArticulo";
            this.btnAniadirArticulo.Size = new System.Drawing.Size(195, 43);
            this.btnAniadirArticulo.TabIndex = 1;
            this.btnAniadirArticulo.Text = "Añadir artículo";
            this.btnAniadirArticulo.UseVisualStyleBackColor = false;
            this.btnAniadirArticulo.Click += new System.EventHandler(this.BtnAniadirArticulo_Click);
            // 
            // lblAulaSeleccionada
            // 
            this.lblAulaSeleccionada.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAulaSeleccionada.Location = new System.Drawing.Point(18, 39);
            this.lblAulaSeleccionada.Name = "lblAulaSeleccionada";
            this.lblAulaSeleccionada.Size = new System.Drawing.Size(193, 20);
            this.lblAulaSeleccionada.TabIndex = 0;
            this.lblAulaSeleccionada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pBLoginIcono
            // 
            this.pBLoginIcono.Image = global::ConsejeriaQR.Properties.Resources.GestionInventario;
            this.pBLoginIcono.Location = new System.Drawing.Point(40, 29);
            this.pBLoginIcono.Name = "pBLoginIcono";
            this.pBLoginIcono.Size = new System.Drawing.Size(165, 129);
            this.pBLoginIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBLoginIcono.TabIndex = 5;
            this.pBLoginIcono.TabStop = false;
            // 
            // btnVolverGestionPrestamos
            // 
            this.btnVolverGestionPrestamos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVolverGestionPrestamos.BackColor = System.Drawing.Color.Firebrick;
            this.btnVolverGestionPrestamos.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVolverGestionPrestamos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolverGestionPrestamos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolverGestionPrestamos.ForeColor = System.Drawing.Color.White;
            this.btnVolverGestionPrestamos.Location = new System.Drawing.Point(1224, 12);
            this.btnVolverGestionPrestamos.Name = "btnVolverGestionPrestamos";
            this.btnVolverGestionPrestamos.Size = new System.Drawing.Size(44, 23);
            this.btnVolverGestionPrestamos.TabIndex = 12;
            this.btnVolverGestionPrestamos.TabStop = false;
            this.btnVolverGestionPrestamos.Text = "->";
            this.btnVolverGestionPrestamos.UseVisualStyleBackColor = false;
            this.btnVolverGestionPrestamos.Click += new System.EventHandler(this.BtnVolverGestionPrestamos_Click);
            // 
            // lblGestionInventarioTitulo
            // 
            this.lblGestionInventarioTitulo.AutoSize = true;
            this.lblGestionInventarioTitulo.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblGestionInventarioTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblGestionInventarioTitulo.Name = "lblGestionInventarioTitulo";
            this.lblGestionInventarioTitulo.Size = new System.Drawing.Size(226, 24);
            this.lblGestionInventarioTitulo.TabIndex = 2;
            this.lblGestionInventarioTitulo.Text = "Gestión de Inventario";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblGestionInventarioTitulo);
            this.panel1.Controls.Add(this.btnVolverGestionPrestamos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 45);
            this.panel1.TabIndex = 3;
            // 
            // boton_desplegablePlanos
            // 
            this.boton_desplegablePlanos.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.boton_desplegablePlanos.IsMainMenu = false;
            this.boton_desplegablePlanos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diurnoToolStripMenuItem,
            this.nocturnoToolStripMenuItem});
            this.boton_desplegablePlanos.MenuItemHeight = 25;
            this.boton_desplegablePlanos.MenuItemTextColor = System.Drawing.Color.Empty;
            this.boton_desplegablePlanos.Name = "boton_desplegablePlanos";
            this.boton_desplegablePlanos.PrimaryColor = System.Drawing.Color.Empty;
            this.boton_desplegablePlanos.Size = new System.Drawing.Size(126, 48);
            // 
            // diurnoToolStripMenuItem
            // 
            this.diurnoToolStripMenuItem.Name = "diurnoToolStripMenuItem";
            this.diurnoToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.diurnoToolStripMenuItem.Text = "Diurno";
            this.diurnoToolStripMenuItem.Click += new System.EventHandler(this.DiurnoToolStripMenuItem_Click);
            // 
            // nocturnoToolStripMenuItem
            // 
            this.nocturnoToolStripMenuItem.Name = "nocturnoToolStripMenuItem";
            this.nocturnoToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.nocturnoToolStripMenuItem.Text = "Nocturno";
            this.nocturnoToolStripMenuItem.Click += new System.EventHandler(this.nocturnoToolStripMenuItem_Click);
            // 
            // boton_desplegableAniadirArticulo
            // 
            this.boton_desplegableAniadirArticulo.IsMainMenu = false;
            this.boton_desplegableAniadirArticulo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertarArtículoToolStripMenuItem,
            this.cargarFicheroCSVToolStripMenuItem});
            this.boton_desplegableAniadirArticulo.MenuItemHeight = 25;
            this.boton_desplegableAniadirArticulo.MenuItemTextColor = System.Drawing.Color.Empty;
            this.boton_desplegableAniadirArticulo.Name = "boton_desplegableAniadirArticulo";
            this.boton_desplegableAniadirArticulo.PrimaryColor = System.Drawing.Color.Empty;
            this.boton_desplegableAniadirArticulo.Size = new System.Drawing.Size(177, 48);
            // 
            // insertarArtículoToolStripMenuItem
            // 
            this.insertarArtículoToolStripMenuItem.Name = "insertarArtículoToolStripMenuItem";
            this.insertarArtículoToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.insertarArtículoToolStripMenuItem.Text = "Insertar artículo";
            this.insertarArtículoToolStripMenuItem.Click += new System.EventHandler(this.InsertarArtículoToolStripMenuItem_Click);
            // 
            // cargarFicheroCSVToolStripMenuItem
            // 
            this.cargarFicheroCSVToolStripMenuItem.Name = "cargarFicheroCSVToolStripMenuItem";
            this.cargarFicheroCSVToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.cargarFicheroCSVToolStripMenuItem.Text = "Cargar fichero .CSV";
            this.cargarFicheroCSVToolStripMenuItem.Click += new System.EventHandler(this.CargarFicheroCSVToolStripMenuItem_Click);
            // 
            // FormularioGestionInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 707);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormularioGestionInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormularioGestionInventario";
            this.panel3.ResumeLayout(false);
            this.panelNocturnoPlantaBaja.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBPlantaBajaNoche)).EndInit();
            this.panelDiurnoPlantaAlta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBPlantaAltaDia)).EndInit();
            this.panelDiurnoPlantaBaja.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBPlantaBajaDia)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panelOpcionesAula.ResumeLayout(false);
            this.panelOpcionesAula.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBLoginIcono)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.boton_desplegablePlanos.ResumeLayout(false);
            this.boton_desplegableAniadirArticulo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pBLoginIcono;
        private System.Windows.Forms.Button btnAccederInterfaz;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnVolverGestionPrestamos;
        private System.Windows.Forms.Label lblGestionInventarioTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelDiurnoPlantaBaja;
        private System.Windows.Forms.PictureBox pBPlantaBajaDia;
        private Controls_Personalizados.Boton_desplegable boton_desplegablePlanos;
        private System.Windows.Forms.ToolStripMenuItem diurnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nocturnoToolStripMenuItem;
        private System.Windows.Forms.Button btnCambiarPlano;
        private Controls_Personalizados.Boton_desplegable boton_desplegableAniadirArticulo;
        private System.Windows.Forms.ToolStripMenuItem insertarArtículoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarFicheroCSVToolStripMenuItem;
        private System.Windows.Forms.Panel panelOpcionesAula;
        private System.Windows.Forms.Button btnComprobarInventario;
        private System.Windows.Forms.Button btnAniadirArticulo;
        private System.Windows.Forms.Label lblAulaSeleccionada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelDiurnoPlantaAlta;
        private System.Windows.Forms.Button btnPlanoAnterior;
        private System.Windows.Forms.PictureBox pBPlantaAltaDia;
        private System.Windows.Forms.Panel panelNocturnoPlantaBaja;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pBPlantaBajaNoche;
    }
}