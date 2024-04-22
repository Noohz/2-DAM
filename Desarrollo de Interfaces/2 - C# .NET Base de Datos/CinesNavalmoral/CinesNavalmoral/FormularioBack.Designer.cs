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
            this.btnProgramarSesion = new System.Windows.Forms.Button();
            this.lblPelicula = new System.Windows.Forms.Label();
            this.lblSesion = new System.Windows.Forms.Label();
            this.lblSala = new System.Windows.Forms.Label();
            this.pctImagen = new System.Windows.Forms.PictureBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dateTPSesion = new System.Windows.Forms.DateTimePicker();
            this.cBSala = new System.Windows.Forms.ComboBox();
            this.numHoras = new System.Windows.Forms.NumericUpDown();
            this.numMin = new System.Windows.Forms.NumericUpDown();
            this.tBsesion = new System.Windows.Forms.TextBox();
            this.lblHoras = new System.Windows.Forms.Label();
            this.lblMinutos = new System.Windows.Forms.Label();
            this.btnCrearSala = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numFilas = new System.Windows.Forms.NumericUpDown();
            this.numColumnas = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pctImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHoras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFilas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColumnas)).BeginInit();
            this.SuspendLayout();
            // 
            // tBTitulo
            // 
            this.tBTitulo.Location = new System.Drawing.Point(12, 41);
            this.tBTitulo.Name = "tBTitulo";
            this.tBTitulo.Size = new System.Drawing.Size(189, 20);
            this.tBTitulo.TabIndex = 0;
            // 
            // btnProgramarSesion
            // 
            this.btnProgramarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProgramarSesion.Location = new System.Drawing.Point(12, 260);
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
            this.lblSala.Location = new System.Drawing.Point(9, 198);
            this.lblSala.Name = "lblSala";
            this.lblSala.Size = new System.Drawing.Size(28, 13);
            this.lblSala.TabIndex = 6;
            this.lblSala.Text = "Sala";
            // 
            // pctImagen
            // 
            this.pctImagen.BackColor = System.Drawing.Color.NavajoWhite;
            this.pctImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctImagen.Location = new System.Drawing.Point(313, 12);
            this.pctImagen.Name = "pctImagen";
            this.pctImagen.Size = new System.Drawing.Size(197, 276);
            this.pctImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctImagen.TabIndex = 7;
            this.pctImagen.TabStop = false;
            this.pctImagen.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(427, 395);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(83, 28);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dateTPSesion
            // 
            this.dateTPSesion.Location = new System.Drawing.Point(12, 91);
            this.dateTPSesion.Name = "dateTPSesion";
            this.dateTPSesion.Size = new System.Drawing.Size(189, 20);
            this.dateTPSesion.TabIndex = 9;
            this.dateTPSesion.ValueChanged += new System.EventHandler(this.dateTPSesion_ValueChanged);
            // 
            // cBSala
            // 
            this.cBSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBSala.FormattingEnabled = true;
            this.cBSala.Location = new System.Drawing.Point(12, 214);
            this.cBSala.Name = "cBSala";
            this.cBSala.Size = new System.Drawing.Size(99, 21);
            this.cBSala.TabIndex = 10;
            // 
            // numHoras
            // 
            this.numHoras.Enabled = false;
            this.numHoras.Location = new System.Drawing.Point(12, 135);
            this.numHoras.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numHoras.Name = "numHoras";
            this.numHoras.Size = new System.Drawing.Size(88, 20);
            this.numHoras.TabIndex = 11;
            this.numHoras.ValueChanged += new System.EventHandler(this.numHoras_ValueChanged);
            // 
            // numMin
            // 
            this.numMin.Enabled = false;
            this.numMin.Location = new System.Drawing.Point(112, 135);
            this.numMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numMin.Name = "numMin";
            this.numMin.Size = new System.Drawing.Size(88, 20);
            this.numMin.TabIndex = 12;
            this.numMin.ValueChanged += new System.EventHandler(this.numMin_ValueChanged);
            // 
            // tBsesion
            // 
            this.tBsesion.Enabled = false;
            this.tBsesion.Location = new System.Drawing.Point(12, 161);
            this.tBsesion.Name = "tBsesion";
            this.tBsesion.Size = new System.Drawing.Size(189, 20);
            this.tBsesion.TabIndex = 13;
            // 
            // lblHoras
            // 
            this.lblHoras.AutoSize = true;
            this.lblHoras.Location = new System.Drawing.Point(38, 119);
            this.lblHoras.Name = "lblHoras";
            this.lblHoras.Size = new System.Drawing.Size(30, 13);
            this.lblHoras.TabIndex = 14;
            this.lblHoras.Text = "Hora";
            // 
            // lblMinutos
            // 
            this.lblMinutos.AutoSize = true;
            this.lblMinutos.Location = new System.Drawing.Point(132, 119);
            this.lblMinutos.Name = "lblMinutos";
            this.lblMinutos.Size = new System.Drawing.Size(44, 13);
            this.lblMinutos.TabIndex = 15;
            this.lblMinutos.Text = "Minutos";
            // 
            // btnCrearSala
            // 
            this.btnCrearSala.Location = new System.Drawing.Point(12, 326);
            this.btnCrearSala.Name = "btnCrearSala";
            this.btnCrearSala.Size = new System.Drawing.Size(75, 23);
            this.btnCrearSala.TabIndex = 16;
            this.btnCrearSala.Text = "Crear Sala";
            this.btnCrearSala.UseVisualStyleBackColor = true;
            this.btnCrearSala.Click += new System.EventHandler(this.btnCrearSala_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Filas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Columnas";
            // 
            // numFilas
            // 
            this.numFilas.Location = new System.Drawing.Point(71, 364);
            this.numFilas.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numFilas.Name = "numFilas";
            this.numFilas.Size = new System.Drawing.Size(88, 20);
            this.numFilas.TabIndex = 19;
            // 
            // numColumnas
            // 
            this.numColumnas.Location = new System.Drawing.Point(71, 406);
            this.numColumnas.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numColumnas.Name = "numColumnas";
            this.numColumnas.Size = new System.Drawing.Size(88, 20);
            this.numColumnas.TabIndex = 20;
            // 
            // FormularioBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 435);
            this.Controls.Add(this.numColumnas);
            this.Controls.Add(this.numFilas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCrearSala);
            this.Controls.Add(this.lblMinutos);
            this.Controls.Add(this.lblHoras);
            this.Controls.Add(this.tBsesion);
            this.Controls.Add(this.numMin);
            this.Controls.Add(this.numHoras);
            this.Controls.Add(this.cBSala);
            this.Controls.Add(this.dateTPSesion);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.pctImagen);
            this.Controls.Add(this.lblSala);
            this.Controls.Add(this.lblSesion);
            this.Controls.Add(this.lblPelicula);
            this.Controls.Add(this.btnProgramarSesion);
            this.Controls.Add(this.tBTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormularioBack";
            this.Text = "FormularioBack";
            ((System.ComponentModel.ISupportInitialize)(this.pctImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHoras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFilas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numColumnas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tBTitulo;
        private System.Windows.Forms.Button btnProgramarSesion;
        private System.Windows.Forms.Label lblPelicula;
        private System.Windows.Forms.Label lblSesion;
        private System.Windows.Forms.Label lblSala;
        private System.Windows.Forms.PictureBox pctImagen;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DateTimePicker dateTPSesion;
        private System.Windows.Forms.ComboBox cBSala;
        private System.Windows.Forms.NumericUpDown numHoras;
        private System.Windows.Forms.NumericUpDown numMin;
        private System.Windows.Forms.TextBox tBsesion;
        private System.Windows.Forms.Label lblHoras;
        private System.Windows.Forms.Label lblMinutos;
        private System.Windows.Forms.Button btnCrearSala;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numFilas;
        private System.Windows.Forms.NumericUpDown numColumnas;
    }
}