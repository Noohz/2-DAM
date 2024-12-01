namespace ConsejeriaQR
{
    partial class FormularioRegistro
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cBDepartamento = new System.Windows.Forms.ComboBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.tBcontraseniaRegistro = new System.Windows.Forms.TextBox();
            this.pBcorreoUsuarioIcono = new System.Windows.Forms.PictureBox();
            this.pBcontraseniaIcono = new System.Windows.Forms.PictureBox();
            this.pBnombreUsuarioIcono = new System.Windows.Forms.PictureBox();
            this.pBLoginIcono = new System.Windows.Forms.PictureBox();
            this.tBnombreRegistro = new System.Windows.Forms.TextBox();
            this.lblLoginTexto = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBcorreoUsuarioIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBcontraseniaIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBnombreUsuarioIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBLoginIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.cBDepartamento);
            this.panel1.Controls.Add(this.btnRegistrar);
            this.panel1.Controls.Add(this.tBcontraseniaRegistro);
            this.panel1.Controls.Add(this.pBcorreoUsuarioIcono);
            this.panel1.Controls.Add(this.pBcontraseniaIcono);
            this.panel1.Controls.Add(this.pBnombreUsuarioIcono);
            this.panel1.Controls.Add(this.pBLoginIcono);
            this.panel1.Controls.Add(this.tBnombreRegistro);
            this.panel1.Controls.Add(this.lblLoginTexto);
            this.panel1.Location = new System.Drawing.Point(122, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 353);
            this.panel1.TabIndex = 1;
            // 
            // cBDepartamento
            // 
            this.cBDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cBDepartamento.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cBDepartamento.FormattingEnabled = true;
            this.cBDepartamento.Items.AddRange(new object[] {
            "Administrador",
            "Conserje",
            "Profesor"});
            this.cBDepartamento.Location = new System.Drawing.Point(177, 207);
            this.cBDepartamento.Name = "cBDepartamento";
            this.cBDepartamento.Size = new System.Drawing.Size(220, 28);
            this.cBDepartamento.TabIndex = 2;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(139, 292);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(258, 43);
            this.btnRegistrar.TabIndex = 4;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // tBcontraseniaRegistro
            // 
            this.tBcontraseniaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBcontraseniaRegistro.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tBcontraseniaRegistro.Location = new System.Drawing.Point(177, 250);
            this.tBcontraseniaRegistro.Name = "tBcontraseniaRegistro";
            this.tBcontraseniaRegistro.Size = new System.Drawing.Size(220, 26);
            this.tBcontraseniaRegistro.TabIndex = 3;
            this.tBcontraseniaRegistro.Text = "Contraseña";
            this.tBcontraseniaRegistro.UseSystemPasswordChar = true;
            // 
            // pBcorreoUsuarioIcono
            // 
            this.pBcorreoUsuarioIcono.Image = global::ConsejeriaQR.Properties.Resources.email;
            this.pBcorreoUsuarioIcono.Location = new System.Drawing.Point(139, 207);
            this.pBcorreoUsuarioIcono.Name = "pBcorreoUsuarioIcono";
            this.pBcorreoUsuarioIcono.Size = new System.Drawing.Size(26, 26);
            this.pBcorreoUsuarioIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBcorreoUsuarioIcono.TabIndex = 10;
            this.pBcorreoUsuarioIcono.TabStop = false;
            // 
            // pBcontraseniaIcono
            // 
            this.pBcontraseniaIcono.Image = global::ConsejeriaQR.Properties.Resources.pass;
            this.pBcontraseniaIcono.Location = new System.Drawing.Point(139, 250);
            this.pBcontraseniaIcono.Name = "pBcontraseniaIcono";
            this.pBcontraseniaIcono.Size = new System.Drawing.Size(26, 26);
            this.pBcontraseniaIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBcontraseniaIcono.TabIndex = 8;
            this.pBcontraseniaIcono.TabStop = false;
            // 
            // pBnombreUsuarioIcono
            // 
            this.pBnombreUsuarioIcono.Image = global::ConsejeriaQR.Properties.Resources.user;
            this.pBnombreUsuarioIcono.Location = new System.Drawing.Point(139, 156);
            this.pBnombreUsuarioIcono.Name = "pBnombreUsuarioIcono";
            this.pBnombreUsuarioIcono.Size = new System.Drawing.Size(26, 26);
            this.pBnombreUsuarioIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBnombreUsuarioIcono.TabIndex = 5;
            this.pBnombreUsuarioIcono.TabStop = false;
            // 
            // pBLoginIcono
            // 
            this.pBLoginIcono.Image = global::ConsejeriaQR.Properties.Resources.loginIcon;
            this.pBLoginIcono.Location = new System.Drawing.Point(231, 19);
            this.pBLoginIcono.Name = "pBLoginIcono";
            this.pBLoginIcono.Size = new System.Drawing.Size(80, 80);
            this.pBLoginIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBLoginIcono.TabIndex = 4;
            this.pBLoginIcono.TabStop = false;
            // 
            // tBnombreRegistro
            // 
            this.tBnombreRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBnombreRegistro.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tBnombreRegistro.Location = new System.Drawing.Point(177, 156);
            this.tBnombreRegistro.Name = "tBnombreRegistro";
            this.tBnombreRegistro.Size = new System.Drawing.Size(220, 26);
            this.tBnombreRegistro.TabIndex = 1;
            this.tBnombreRegistro.Text = "Nombre de usuario";
            // 
            // lblLoginTexto
            // 
            this.lblLoginTexto.AutoSize = true;
            this.lblLoginTexto.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginTexto.Location = new System.Drawing.Point(173, 118);
            this.lblLoginTexto.Name = "lblLoginTexto";
            this.lblLoginTexto.Size = new System.Drawing.Size(194, 24);
            this.lblLoginTexto.TabIndex = 0;
            this.lblLoginTexto.Text = "Registrar profesor";
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.Firebrick;
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(712, 12);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(44, 23);
            this.btnVolver.TabIndex = 0;
            this.btnVolver.Text = "->";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FormularioRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(768, 472);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormularioRegistro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormularioRegistro";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBcorreoUsuarioIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBcontraseniaIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBnombreUsuarioIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBLoginIcono)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pBnombreUsuarioIcono;
        private System.Windows.Forms.PictureBox pBLoginIcono;
        private System.Windows.Forms.TextBox tBnombreRegistro;
        private System.Windows.Forms.Label lblLoginTexto;
        private System.Windows.Forms.PictureBox pBcontraseniaIcono;
        private System.Windows.Forms.PictureBox pBcorreoUsuarioIcono;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.TextBox tBcontraseniaRegistro;
        private System.Windows.Forms.ComboBox cBDepartamento;
    }
}