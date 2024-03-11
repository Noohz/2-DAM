
namespace TPV
{
    partial class backEnd
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
            this.btnStock = new System.Windows.Forms.Button();
            this.btnInsertarFruta = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblPral = new System.Windows.Forms.Label();
            this.flpFrutas = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblImagen = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.btnCargarImagen = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.btnAniadir = new System.Windows.Forms.Button();
            this.gbInsertar = new System.Windows.Forms.GroupBox();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.pbImagenCargada = new System.Windows.Forms.PictureBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnEliminarFruta = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnExclamacion = new System.Windows.Forms.Button();
            this.gbInsertar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenCargada)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStock
            // 
            this.btnStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.Location = new System.Drawing.Point(73, 32);
            this.btnStock.Margin = new System.Windows.Forms.Padding(2);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(107, 30);
            this.btnStock.TabIndex = 0;
            this.btnStock.Text = "Añadir Stock";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnInsertarFruta
            // 
            this.btnInsertarFruta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertarFruta.Location = new System.Drawing.Point(73, 73);
            this.btnInsertarFruta.Margin = new System.Windows.Forms.Padding(2);
            this.btnInsertarFruta.Name = "btnInsertarFruta";
            this.btnInsertarFruta.Size = new System.Drawing.Size(107, 30);
            this.btnInsertarFruta.TabIndex = 1;
            this.btnInsertarFruta.Text = "Insertar Fruta";
            this.btnInsertarFruta.UseVisualStyleBackColor = true;
            this.btnInsertarFruta.Click += new System.EventHandler(this.btnInsertarFruta_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(73, 197);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 30);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblPral
            // 
            this.lblPral.AutoSize = true;
            this.lblPral.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPral.Location = new System.Drawing.Point(304, 26);
            this.lblPral.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPral.Name = "lblPral";
            this.lblPral.Size = new System.Drawing.Size(0, 17);
            this.lblPral.TabIndex = 3;
            // 
            // flpFrutas
            // 
            this.flpFrutas.AutoScroll = true;
            this.flpFrutas.Location = new System.Drawing.Point(308, 27);
            this.flpFrutas.Margin = new System.Windows.Forms.Padding(2);
            this.flpFrutas.Name = "flpFrutas";
            this.flpFrutas.Size = new System.Drawing.Size(439, 215);
            this.flpFrutas.TabIndex = 4;
            this.flpFrutas.Visible = false;
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
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(108, 44);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(158, 23);
            this.txtNombre.TabIndex = 13;
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
            // txtStock
            // 
            this.txtStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.Location = new System.Drawing.Point(108, 135);
            this.txtStock.Margin = new System.Windows.Forms.Padding(2);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(158, 23);
            this.txtStock.TabIndex = 16;
            // 
            // btnAniadir
            // 
            this.btnAniadir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAniadir.Location = new System.Drawing.Point(20, 185);
            this.btnAniadir.Margin = new System.Windows.Forms.Padding(2);
            this.btnAniadir.Name = "btnAniadir";
            this.btnAniadir.Size = new System.Drawing.Size(335, 32);
            this.btnAniadir.TabIndex = 17;
            this.btnAniadir.Text = "Añadir";
            this.btnAniadir.UseVisualStyleBackColor = true;
            this.btnAniadir.Visible = false;
            this.btnAniadir.Click += new System.EventHandler(this.btnAniadir_Click);
            // 
            // gbInsertar
            // 
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
            this.gbInsertar.Location = new System.Drawing.Point(308, 10);
            this.gbInsertar.Margin = new System.Windows.Forms.Padding(2);
            this.gbInsertar.Name = "gbInsertar";
            this.gbInsertar.Padding = new System.Windows.Forms.Padding(2);
            this.gbInsertar.Size = new System.Drawing.Size(381, 232);
            this.gbInsertar.TabIndex = 18;
            this.gbInsertar.TabStop = false;
            this.gbInsertar.Visible = false;
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCambios.Location = new System.Drawing.Point(20, 185);
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
            // btnEliminarFruta
            // 
            this.btnEliminarFruta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarFruta.Location = new System.Drawing.Point(73, 157);
            this.btnEliminarFruta.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminarFruta.Name = "btnEliminarFruta";
            this.btnEliminarFruta.Size = new System.Drawing.Size(107, 30);
            this.btnEliminarFruta.TabIndex = 20;
            this.btnEliminarFruta.Text = "Eliminar Fruta";
            this.btnEliminarFruta.UseVisualStyleBackColor = true;
            this.btnEliminarFruta.Click += new System.EventHandler(this.btnEliminarFruta_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(73, 115);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(107, 30);
            this.btnModificar.TabIndex = 21;
            this.btnModificar.Text = "Modificar Fruta";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnExclamacion
            // 
            this.btnExclamacion.AutoSize = true;
            this.btnExclamacion.Location = new System.Drawing.Point(194, 32);
            this.btnExclamacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnExclamacion.Name = "btnExclamacion";
            this.btnExclamacion.Size = new System.Drawing.Size(28, 30);
            this.btnExclamacion.TabIndex = 22;
            this.btnExclamacion.UseVisualStyleBackColor = true;
            this.btnExclamacion.Visible = false;
            // 
            // backEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 266);
            this.Controls.Add(this.btnExclamacion);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminarFruta);
            this.Controls.Add(this.gbInsertar);
            this.Controls.Add(this.flpFrutas);
            this.Controls.Add(this.lblPral);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnInsertarFruta);
            this.Controls.Add(this.btnStock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "backEnd";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.backEnd_Load);
            this.gbInsertar.ResumeLayout(false);
            this.gbInsertar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenCargada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnInsertarFruta;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblPral;
        private System.Windows.Forms.FlowLayoutPanel flpFrutas;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblImagen;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Button btnCargarImagen;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Button btnAniadir;
        private System.Windows.Forms.GroupBox gbInsertar;
        private System.Windows.Forms.Button btnEliminarFruta;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnExclamacion;
        private System.Windows.Forms.PictureBox pbImagenCargada;
        private System.Windows.Forms.Button btnGuardarCambios;
    }
}