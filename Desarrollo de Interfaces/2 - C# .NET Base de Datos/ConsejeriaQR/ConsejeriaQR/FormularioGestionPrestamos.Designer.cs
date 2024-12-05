namespace ConsejeriaQR
{
    partial class FormularioGestionPrestamos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGestionPrestamoTitulo = new System.Windows.Forms.Label();
            this.btnVolverGestionPrestamos = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnModificarArticulo = new System.Windows.Forms.Button();
            this.btnArticulosMantenimiento = new System.Windows.Forms.Button();
            this.btnArticulosPrestados = new System.Windows.Forms.Button();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrestarArticulo = new System.Windows.Forms.Button();
            this.btnEliminarArticulo = new System.Windows.Forms.Button();
            this.btnAniadirArticulo = new System.Windows.Forms.Button();
            this.pBLoginIcono = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.boton_desplegableAniadirArticulos = new ConsejeriaQR.Controls_Personalizados.Boton_desplegable(this.components);
            this.aniadirArtículoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarFicherosConDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBLoginIcono)).BeginInit();
            this.boton_desplegableAniadirArticulos.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblGestionPrestamoTitulo);
            this.panel1.Controls.Add(this.btnVolverGestionPrestamos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 45);
            this.panel1.TabIndex = 0;
            // 
            // lblGestionPrestamoTitulo
            // 
            this.lblGestionPrestamoTitulo.AutoSize = true;
            this.lblGestionPrestamoTitulo.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblGestionPrestamoTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblGestionPrestamoTitulo.Name = "lblGestionPrestamoTitulo";
            this.lblGestionPrestamoTitulo.Size = new System.Drawing.Size(234, 24);
            this.lblGestionPrestamoTitulo.TabIndex = 2;
            this.lblGestionPrestamoTitulo.Text = "Gestión de Préstamos";
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.panel2.Controls.Add(this.btnModificarArticulo);
            this.panel2.Controls.Add(this.btnArticulosMantenimiento);
            this.panel2.Controls.Add(this.btnArticulosPrestados);
            this.panel2.Controls.Add(this.lblNombreUsuario);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnPrestarArticulo);
            this.panel2.Controls.Add(this.btnEliminarArticulo);
            this.panel2.Controls.Add(this.btnAniadirArticulo);
            this.panel2.Controls.Add(this.pBLoginIcono);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 979);
            this.panel2.TabIndex = 1;
            // 
            // btnModificarArticulo
            // 
            this.btnModificarArticulo.BackColor = System.Drawing.SystemColors.Control;
            this.btnModificarArticulo.Enabled = false;
            this.btnModificarArticulo.FlatAppearance.BorderSize = 0;
            this.btnModificarArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnModificarArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnModificarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarArticulo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarArticulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnModificarArticulo.Location = new System.Drawing.Point(12, 364);
            this.btnModificarArticulo.Name = "btnModificarArticulo";
            this.btnModificarArticulo.Size = new System.Drawing.Size(221, 43);
            this.btnModificarArticulo.TabIndex = 2;
            this.btnModificarArticulo.Text = "Modificar artículos";
            this.btnModificarArticulo.UseVisualStyleBackColor = false;
            this.btnModificarArticulo.Click += new System.EventHandler(this.btnModificarArticulo_Click);
            // 
            // btnArticulosMantenimiento
            // 
            this.btnArticulosMantenimiento.BackColor = System.Drawing.SystemColors.Control;
            this.btnArticulosMantenimiento.Enabled = false;
            this.btnArticulosMantenimiento.FlatAppearance.BorderSize = 0;
            this.btnArticulosMantenimiento.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnArticulosMantenimiento.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnArticulosMantenimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArticulosMantenimiento.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArticulosMantenimiento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnArticulosMantenimiento.Location = new System.Drawing.Point(12, 545);
            this.btnArticulosMantenimiento.Name = "btnArticulosMantenimiento";
            this.btnArticulosMantenimiento.Size = new System.Drawing.Size(221, 54);
            this.btnArticulosMantenimiento.TabIndex = 5;
            this.btnArticulosMantenimiento.Text = "Articulos en mantenimiento";
            this.btnArticulosMantenimiento.UseVisualStyleBackColor = false;
            this.btnArticulosMantenimiento.Click += new System.EventHandler(this.BtnArticulosMantenimiento_Click);
            // 
            // btnArticulosPrestados
            // 
            this.btnArticulosPrestados.BackColor = System.Drawing.SystemColors.Control;
            this.btnArticulosPrestados.Enabled = false;
            this.btnArticulosPrestados.FlatAppearance.BorderSize = 0;
            this.btnArticulosPrestados.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnArticulosPrestados.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnArticulosPrestados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArticulosPrestados.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArticulosPrestados.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnArticulosPrestados.Location = new System.Drawing.Point(12, 484);
            this.btnArticulosPrestados.Name = "btnArticulosPrestados";
            this.btnArticulosPrestados.Size = new System.Drawing.Size(221, 43);
            this.btnArticulosPrestados.TabIndex = 4;
            this.btnArticulosPrestados.Text = "Artículos prestados";
            this.btnArticulosPrestados.UseVisualStyleBackColor = false;
            this.btnArticulosPrestados.Click += new System.EventHandler(this.BtnArticulosPrestados_Click);
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.Location = new System.Drawing.Point(68, 169);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(95, 19);
            this.lblNombreUsuario.TabIndex = 14;
            this.lblNombreUsuario.Text = "*USUARIO*";
            this.lblNombreUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "Bienvenido";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrestarArticulo
            // 
            this.btnPrestarArticulo.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrestarArticulo.Enabled = false;
            this.btnPrestarArticulo.FlatAppearance.BorderSize = 0;
            this.btnPrestarArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnPrestarArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnPrestarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrestarArticulo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrestarArticulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrestarArticulo.Location = new System.Drawing.Point(12, 425);
            this.btnPrestarArticulo.Name = "btnPrestarArticulo";
            this.btnPrestarArticulo.Size = new System.Drawing.Size(221, 43);
            this.btnPrestarArticulo.TabIndex = 3;
            this.btnPrestarArticulo.Text = "Prestar artículos";
            this.btnPrestarArticulo.UseVisualStyleBackColor = false;
            this.btnPrestarArticulo.Click += new System.EventHandler(this.BtnPrestarArticulo_Click);
            // 
            // btnEliminarArticulo
            // 
            this.btnEliminarArticulo.BackColor = System.Drawing.SystemColors.Control;
            this.btnEliminarArticulo.Enabled = false;
            this.btnEliminarArticulo.FlatAppearance.BorderSize = 0;
            this.btnEliminarArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnEliminarArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnEliminarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarArticulo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarArticulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEliminarArticulo.Location = new System.Drawing.Point(12, 301);
            this.btnEliminarArticulo.Name = "btnEliminarArticulo";
            this.btnEliminarArticulo.Size = new System.Drawing.Size(221, 43);
            this.btnEliminarArticulo.TabIndex = 1;
            this.btnEliminarArticulo.Text = "Eliminar artículos";
            this.btnEliminarArticulo.UseVisualStyleBackColor = false;
            this.btnEliminarArticulo.Click += new System.EventHandler(this.BtnEliminarArticulo_Click);
            // 
            // btnAniadirArticulo
            // 
            this.btnAniadirArticulo.BackColor = System.Drawing.SystemColors.Control;
            this.btnAniadirArticulo.Enabled = false;
            this.btnAniadirArticulo.FlatAppearance.BorderSize = 0;
            this.btnAniadirArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnAniadirArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnAniadirArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAniadirArticulo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAniadirArticulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAniadirArticulo.Location = new System.Drawing.Point(12, 241);
            this.btnAniadirArticulo.Name = "btnAniadirArticulo";
            this.btnAniadirArticulo.Size = new System.Drawing.Size(221, 43);
            this.btnAniadirArticulo.TabIndex = 0;
            this.btnAniadirArticulo.Text = "Añadir artículos";
            this.btnAniadirArticulo.UseVisualStyleBackColor = false;
            this.btnAniadirArticulo.Click += new System.EventHandler(this.BtnAniadirArticulo_Click);
            // 
            // pBLoginIcono
            // 
            this.pBLoginIcono.Image = global::ConsejeriaQR.Properties.Resources.GestionPrestamos;
            this.pBLoginIcono.Location = new System.Drawing.Point(76, 44);
            this.pBLoginIcono.Name = "pBLoginIcono";
            this.pBLoginIcono.Size = new System.Drawing.Size(80, 80);
            this.pBLoginIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBLoginIcono.TabIndex = 5;
            this.pBLoginIcono.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(103)))), ((int)(((byte)(73)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(248, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1032, 979);
            this.panel3.TabIndex = 2;
            // 
            // boton_desplegableAniadirArticulos
            // 
            this.boton_desplegableAniadirArticulos.IsMainMenu = false;
            this.boton_desplegableAniadirArticulos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aniadirArtículoToolStripMenuItem,
            this.cargarFicherosConDatosToolStripMenuItem});
            this.boton_desplegableAniadirArticulos.MenuItemHeight = 25;
            this.boton_desplegableAniadirArticulos.MenuItemTextColor = System.Drawing.Color.Empty;
            this.boton_desplegableAniadirArticulos.Name = "boton_desplegableAñadirArticulos";
            this.boton_desplegableAniadirArticulos.PrimaryColor = System.Drawing.Color.Empty;
            this.boton_desplegableAniadirArticulos.Size = new System.Drawing.Size(205, 48);
            // 
            // aniadirArtículoToolStripMenuItem
            // 
            this.aniadirArtículoToolStripMenuItem.Name = "aniadirArtículoToolStripMenuItem";
            this.aniadirArtículoToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.aniadirArtículoToolStripMenuItem.Text = "Añadir artículo";
            this.aniadirArtículoToolStripMenuItem.Click += new System.EventHandler(this.AniadirArtículoToolStripMenuItem_Click);
            // 
            // cargarFicherosConDatosToolStripMenuItem
            // 
            this.cargarFicherosConDatosToolStripMenuItem.Name = "cargarFicherosConDatosToolStripMenuItem";
            this.cargarFicherosConDatosToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.cargarFicherosConDatosToolStripMenuItem.Text = "Cargar fichero con datos";
            this.cargarFicherosConDatosToolStripMenuItem.Click += new System.EventHandler(this.CargarFicherosConDatosToolStripMenuItem_Click);
            // 
            // FormularioGestionPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 1024);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormularioGestionPrestamos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormularioGestionPrestamos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBLoginIcono)).EndInit();
            this.boton_desplegableAniadirArticulos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVolverGestionPrestamos;
        private System.Windows.Forms.Label lblGestionPrestamoTitulo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pBLoginIcono;
        private System.Windows.Forms.Button btnAniadirArticulo;
        private System.Windows.Forms.Button btnEliminarArticulo;
        private System.Windows.Forms.Button btnPrestarArticulo;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnArticulosPrestados;
        private System.Windows.Forms.Button btnArticulosMantenimiento;
        private System.Windows.Forms.Button btnModificarArticulo;
        private Controls_Personalizados.Boton_desplegable boton_desplegableAniadirArticulos;
        private System.Windows.Forms.ToolStripMenuItem aniadirArtículoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarFicherosConDatosToolStripMenuItem;
    }
}