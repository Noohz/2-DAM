namespace ExamenRec
{
    partial class InformacioUsuario
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.textBoxIdentificador = new System.Windows.Forms.TextBox();
            this.btnInformar = new System.Windows.Forms.Button();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxCurso = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.pictureBoxAlumno = new System.Windows.Forms.PictureBox();
            this.comboBoxModulo = new System.Windows.Forms.ComboBox();
            this.comboBoxNota = new System.Windows.Forms.ComboBox();
            this.btnAsistencia = new System.Windows.Forms.Button();
            this.btnPuntuar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlumno)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(12, 346);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(290, 21);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // textBoxIdentificador
            // 
            this.textBoxIdentificador.Enabled = false;
            this.textBoxIdentificador.Location = new System.Drawing.Point(12, 13);
            this.textBoxIdentificador.Name = "textBoxIdentificador";
            this.textBoxIdentificador.Size = new System.Drawing.Size(209, 20);
            this.textBoxIdentificador.TabIndex = 1;
            // 
            // btnInformar
            // 
            this.btnInformar.Location = new System.Drawing.Point(227, 12);
            this.btnInformar.Name = "btnInformar";
            this.btnInformar.Size = new System.Drawing.Size(75, 23);
            this.btnInformar.TabIndex = 2;
            this.btnInformar.Text = "Informar";
            this.btnInformar.UseVisualStyleBackColor = true;
            this.btnInformar.Click += new System.EventHandler(this.btnInformar_Click);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Enabled = false;
            this.textBoxNombre.Location = new System.Drawing.Point(12, 40);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(290, 20);
            this.textBoxNombre.TabIndex = 3;
            // 
            // textBoxCurso
            // 
            this.textBoxCurso.Enabled = false;
            this.textBoxCurso.Location = new System.Drawing.Point(12, 66);
            this.textBoxCurso.Name = "textBoxCurso";
            this.textBoxCurso.Size = new System.Drawing.Size(100, 20);
            this.textBoxCurso.TabIndex = 4;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Enabled = false;
            this.textBoxEmail.Location = new System.Drawing.Point(118, 66);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(184, 20);
            this.textBoxEmail.TabIndex = 5;
            // 
            // pictureBoxAlumno
            // 
            this.pictureBoxAlumno.Location = new System.Drawing.Point(29, 92);
            this.pictureBoxAlumno.Name = "pictureBoxAlumno";
            this.pictureBoxAlumno.Size = new System.Drawing.Size(262, 147);
            this.pictureBoxAlumno.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAlumno.TabIndex = 6;
            this.pictureBoxAlumno.TabStop = false;
            // 
            // comboBoxModulo
            // 
            this.comboBoxModulo.FormattingEnabled = true;
            this.comboBoxModulo.Items.AddRange(new object[] {
            "AO",
            "BD",
            "BDR",
            "DI",
            "DIW",
            "DW",
            "DWEC",
            "DWES",
            "ED",
            "FP",
            "ME",
            "PDM",
            "RL",
            "SEG",
            "SGE",
            "SSOO"});
            this.comboBoxModulo.Location = new System.Drawing.Point(13, 261);
            this.comboBoxModulo.Name = "comboBoxModulo";
            this.comboBoxModulo.Size = new System.Drawing.Size(208, 21);
            this.comboBoxModulo.TabIndex = 7;
            // 
            // comboBoxNota
            // 
            this.comboBoxNota.FormattingEnabled = true;
            this.comboBoxNota.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBoxNota.Location = new System.Drawing.Point(13, 303);
            this.comboBoxNota.Name = "comboBoxNota";
            this.comboBoxNota.Size = new System.Drawing.Size(208, 21);
            this.comboBoxNota.TabIndex = 8;
            // 
            // btnAsistencia
            // 
            this.btnAsistencia.Location = new System.Drawing.Point(227, 259);
            this.btnAsistencia.Name = "btnAsistencia";
            this.btnAsistencia.Size = new System.Drawing.Size(75, 23);
            this.btnAsistencia.TabIndex = 9;
            this.btnAsistencia.Text = "No Asiste";
            this.btnAsistencia.UseVisualStyleBackColor = true;
            this.btnAsistencia.Click += new System.EventHandler(this.btnAsistencia_Click);
            // 
            // btnPuntuar
            // 
            this.btnPuntuar.Location = new System.Drawing.Point(227, 301);
            this.btnPuntuar.Name = "btnPuntuar";
            this.btnPuntuar.Size = new System.Drawing.Size(75, 23);
            this.btnPuntuar.TabIndex = 10;
            this.btnPuntuar.Text = "Puntuar";
            this.btnPuntuar.UseVisualStyleBackColor = true;
            this.btnPuntuar.Click += new System.EventHandler(this.btnPuntuar_Click);
            // 
            // InformacioUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 379);
            this.Controls.Add(this.btnPuntuar);
            this.Controls.Add(this.btnAsistencia);
            this.Controls.Add(this.comboBoxNota);
            this.Controls.Add(this.comboBoxModulo);
            this.Controls.Add(this.pictureBoxAlumno);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxCurso);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.btnInformar);
            this.Controls.Add(this.textBoxIdentificador);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InformacioUsuario";
            this.Text = "InformacioUsuario";
            this.Load += new System.EventHandler(this.InformacioUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlumno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TextBox textBoxIdentificador;
        private System.Windows.Forms.Button btnInformar;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxCurso;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.PictureBox pictureBoxAlumno;
        private System.Windows.Forms.ComboBox comboBoxModulo;
        private System.Windows.Forms.ComboBox comboBoxNota;
        private System.Windows.Forms.Button btnAsistencia;
        private System.Windows.Forms.Button btnPuntuar;
    }
}