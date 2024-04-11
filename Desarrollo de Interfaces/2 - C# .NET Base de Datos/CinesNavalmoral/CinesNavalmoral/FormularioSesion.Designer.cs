namespace CinesNavalmoral
{
    partial class FormularioSesion
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pBCartel = new System.Windows.Forms.PictureBox();
            this.lblSala = new System.Windows.Forms.Label();
            this.listaSesiones = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblNSala = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBCartel)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(28, 6);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(728, 42);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "*Titulo Pelicula*";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pBCartel
            // 
            this.pBCartel.Location = new System.Drawing.Point(543, 70);
            this.pBCartel.Name = "pBCartel";
            this.pBCartel.Size = new System.Drawing.Size(213, 345);
            this.pBCartel.TabIndex = 1;
            this.pBCartel.TabStop = false;
            // 
            // lblSala
            // 
            this.lblSala.AutoSize = true;
            this.lblSala.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSala.Location = new System.Drawing.Point(31, 321);
            this.lblSala.Name = "lblSala";
            this.lblSala.Size = new System.Drawing.Size(75, 20);
            this.lblSala.TabIndex = 3;
            this.lblSala.Text = "Sala => ";
            // 
            // listaSesiones
            // 
            this.listaSesiones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaSesiones.FormattingEnabled = true;
            this.listaSesiones.ItemHeight = 16;
            this.listaSesiones.Location = new System.Drawing.Point(47, 103);
            this.listaSesiones.Name = "listaSesiones";
            this.listaSesiones.Size = new System.Drawing.Size(212, 228);
            this.listaSesiones.TabIndex = 5;
            this.listaSesiones.SelectedIndexChanged += new System.EventHandler(this.listaSesiones_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel1.Controls.Add(this.lblNSala);
            this.panel1.Controls.Add(this.btnVolver);
            this.panel1.Controls.Add(this.lblSala);
            this.panel1.Controls.Add(this.pBCartel);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 426);
            this.panel1.TabIndex = 6;
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(9, 393);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblNSala
            // 
            this.lblNSala.AutoSize = true;
            this.lblNSala.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNSala.Location = new System.Drawing.Point(99, 322);
            this.lblNSala.Name = "lblNSala";
            this.lblNSala.Size = new System.Drawing.Size(33, 20);
            this.lblNSala.TabIndex = 4;
            this.lblNSala.Text = "*1*";
            // 
            // FormularioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listaSesiones);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormularioSesion";
            this.Text = "FormularioSesion";
            this.Load += new System.EventHandler(this.FormularioSesion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBCartel)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pBCartel;
        private System.Windows.Forms.Label lblSala;
        private System.Windows.Forms.ListBox listaSesiones;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblNSala;
    }
}