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
            this.comboBSesiones = new System.Windows.Forms.ComboBox();
            this.lblSala = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listaSesiones = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pBCartel)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(41, 24);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(222, 31);
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
            // comboBSesiones
            // 
            this.comboBSesiones.FormattingEnabled = true;
            this.comboBSesiones.Location = new System.Drawing.Point(47, 83);
            this.comboBSesiones.Name = "comboBSesiones";
            this.comboBSesiones.Size = new System.Drawing.Size(121, 21);
            this.comboBSesiones.TabIndex = 2;
            // 
            // lblSala
            // 
            this.lblSala.AutoSize = true;
            this.lblSala.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSala.Location = new System.Drawing.Point(43, 283);
            this.lblSala.Name = "lblSala";
            this.lblSala.Size = new System.Drawing.Size(75, 20);
            this.lblSala.TabIndex = 3;
            this.lblSala.Text = "Sala => ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(215, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // listaSesiones
            // 
            this.listaSesiones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaSesiones.FormattingEnabled = true;
            this.listaSesiones.ItemHeight = 16;
            this.listaSesiones.Location = new System.Drawing.Point(47, 135);
            this.listaSesiones.Name = "listaSesiones";
            this.listaSesiones.Size = new System.Drawing.Size(212, 132);
            this.listaSesiones.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel1.Controls.Add(this.pBCartel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 426);
            this.panel1.TabIndex = 6;
            // 
            // FormularioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listaSesiones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSala);
            this.Controls.Add(this.comboBSesiones);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormularioSesion";
            this.Text = "FormularioSesion";
            this.Load += new System.EventHandler(this.FormularioSesion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBCartel)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pBCartel;
        private System.Windows.Forms.ComboBox comboBSesiones;
        private System.Windows.Forms.Label lblSala;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listaSesiones;
        private System.Windows.Forms.Panel panel1;
    }
}