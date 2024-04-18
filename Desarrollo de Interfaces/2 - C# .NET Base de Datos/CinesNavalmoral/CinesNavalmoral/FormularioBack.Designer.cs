namespace CinesNavalmoral
{
    partial class FormularioBack
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
            this.tBTitulo = new System.Windows.Forms.TextBox();
            this.tbSesion = new System.Windows.Forms.TextBox();
            this.tBSala = new System.Windows.Forms.TextBox();
            this.btnProgramarSesion = new System.Windows.Forms.Button();
            this.lblPelicula = new System.Windows.Forms.Label();
            this.lblSesion = new System.Windows.Forms.Label();
            this.lblSala = new System.Windows.Forms.Label();
            this.pctImagen = new System.Windows.Forms.PictureBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pctImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // tBTitulo
            // 
            this.tBTitulo.Location = new System.Drawing.Point(12, 41);
            this.tBTitulo.Name = "tBTitulo";
            this.tBTitulo.Size = new System.Drawing.Size(189, 20);
            this.tBTitulo.TabIndex = 0;
            // 
            // tbSesion
            // 
            this.tbSesion.Location = new System.Drawing.Point(12, 91);
            this.tbSesion.Name = "tbSesion";
            this.tbSesion.Size = new System.Drawing.Size(189, 20);
            this.tbSesion.TabIndex = 1;
            // 
            // tBSala
            // 
            this.tBSala.Location = new System.Drawing.Point(12, 142);
            this.tBSala.Name = "tBSala";
            this.tBSala.Size = new System.Drawing.Size(76, 20);
            this.tBSala.TabIndex = 2;
            // 
            // btnProgramarSesion
            // 
            this.btnProgramarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProgramarSesion.Location = new System.Drawing.Point(12, 218);
            this.btnProgramarSesion.Name = "btnProgramarSesion";
            this.btnProgramarSesion.Size = new System.Drawing.Size(188, 28);
            this.btnProgramarSesion.TabIndex = 3;
            this.btnProgramarSesion.Text = "Programar sesión";
            this.btnProgramarSesion.UseVisualStyleBackColor = true;
            this.btnProgramarSesion.Click += new System.EventHandler(this.btnProgramarSesion_Click);
            // 
            // lblPelicula
            // 
            this.lblPelicula.AutoSize = true;
            this.lblPelicula.Location = new System.Drawing.Point(9, 25);
            this.lblPelicula.Name = "lblPelicula";
            this.lblPelicula.Size = new System.Drawing.Size(102, 13);
            this.lblPelicula.TabIndex = 4;
            this.lblPelicula.Text = "Título de la película";
            // 
            // lblSesion
            // 
            this.lblSesion.AutoSize = true;
            this.lblSesion.Location = new System.Drawing.Point(9, 75);
            this.lblSesion.Name = "lblSesion";
            this.lblSesion.Size = new System.Drawing.Size(39, 13);
            this.lblSesion.TabIndex = 5;
            this.lblSesion.Text = "Sesión";
            // 
            // lblSala
            // 
            this.lblSala.AutoSize = true;
            this.lblSala.Location = new System.Drawing.Point(9, 126);
            this.lblSala.Name = "lblSala";
            this.lblSala.Size = new System.Drawing.Size(28, 13);
            this.lblSala.TabIndex = 6;
            this.lblSala.Text = "Sala";
            // 
            // pctImagen
            // 
            this.pctImagen.BackColor = System.Drawing.Color.NavajoWhite;
            this.pctImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctImagen.Location = new System.Drawing.Point(309, 12);
            this.pctImagen.Name = "pctImagen";
            this.pctImagen.Size = new System.Drawing.Size(197, 234);
            this.pctImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctImagen.TabIndex = 7;
            this.pctImagen.TabStop = false;
            this.pctImagen.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(206, 218);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(83, 28);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(103, 139);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // FormularioBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 258);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.pctImagen);
            this.Controls.Add(this.lblSala);
            this.Controls.Add(this.lblSesion);
            this.Controls.Add(this.lblPelicula);
            this.Controls.Add(this.btnProgramarSesion);
            this.Controls.Add(this.tBSala);
            this.Controls.Add(this.tbSesion);
            this.Controls.Add(this.tBTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormularioBack";
            this.Text = "FormularioBack";
            ((System.ComponentModel.ISupportInitialize)(this.pctImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBTitulo;
        private System.Windows.Forms.TextBox tbSesion;
        private System.Windows.Forms.TextBox tBSala;
        private System.Windows.Forms.Button btnProgramarSesion;
        private System.Windows.Forms.Label lblPelicula;
        private System.Windows.Forms.Label lblSesion;
        private System.Windows.Forms.Label lblSala;
        private System.Windows.Forms.PictureBox pctImagen;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}