namespace ConsejeriaQR
{
    partial class FormularioInicioSesion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pBUsuarioIcono = new System.Windows.Forms.PictureBox();
            this.pBcontraseniaIcono = new System.Windows.Forms.PictureBox();
            this.pBLoginIcono = new System.Windows.Forms.PictureBox();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.tBcontrasenia = new System.Windows.Forms.TextBox();
            this.tBusuario = new System.Windows.Forms.TextBox();
            this.lblLoginTexto = new System.Windows.Forms.Label();
            this.btnCerrarLogin = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBUsuarioIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBcontraseniaIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBLoginIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pBUsuarioIcono);
            this.panel1.Controls.Add(this.pBcontraseniaIcono);
            this.panel1.Controls.Add(this.pBLoginIcono);
            this.panel1.Controls.Add(this.btnIniciarSesion);
            this.panel1.Controls.Add(this.tBcontrasenia);
            this.panel1.Controls.Add(this.tBusuario);
            this.panel1.Controls.Add(this.lblLoginTexto);
            this.panel1.Location = new System.Drawing.Point(122, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 353);
            this.panel1.TabIndex = 0;
            // 
            // pBUsuarioIcono
            // 
            this.pBUsuarioIcono.Image = global::ConsejeriaQR.Properties.Resources.user;
            this.pBUsuarioIcono.Location = new System.Drawing.Point(139, 156);
            this.pBUsuarioIcono.Name = "pBUsuarioIcono";
            this.pBUsuarioIcono.Size = new System.Drawing.Size(26, 26);
            this.pBUsuarioIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBUsuarioIcono.TabIndex = 11;
            this.pBUsuarioIcono.TabStop = false;
            // 
            // pBcontraseniaIcono
            // 
            this.pBcontraseniaIcono.Image = global::ConsejeriaQR.Properties.Resources.pass;
            this.pBcontraseniaIcono.Location = new System.Drawing.Point(139, 203);
            this.pBcontraseniaIcono.Name = "pBcontraseniaIcono";
            this.pBcontraseniaIcono.Size = new System.Drawing.Size(26, 26);
            this.pBcontraseniaIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBcontraseniaIcono.TabIndex = 6;
            this.pBcontraseniaIcono.TabStop = false;
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
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarSesion.ForeColor = System.Drawing.Color.White;
            this.btnIniciarSesion.Location = new System.Drawing.Point(139, 258);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(258, 43);
            this.btnIniciarSesion.TabIndex = 3;
            this.btnIniciarSesion.Text = "Acceder";
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btniniciarSesion_Click);
            // 
            // tBcontrasenia
            // 
            this.tBcontrasenia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBcontrasenia.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tBcontrasenia.Location = new System.Drawing.Point(177, 203);
            this.tBcontrasenia.Name = "tBcontrasenia";
            this.tBcontrasenia.Size = new System.Drawing.Size(220, 26);
            this.tBcontrasenia.TabIndex = 2;
            this.tBcontrasenia.Text = "Contraseña";
            this.tBcontrasenia.UseSystemPasswordChar = true;
            this.tBcontrasenia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBcontrasenia_KeyDown);
            // 
            // tBusuario
            // 
            this.tBusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBusuario.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tBusuario.Location = new System.Drawing.Point(177, 156);
            this.tBusuario.Name = "tBusuario";
            this.tBusuario.Size = new System.Drawing.Size(220, 26);
            this.tBusuario.TabIndex = 1;
            this.tBusuario.Text = "Nombre de usuario";
            // 
            // lblLoginTexto
            // 
            this.lblLoginTexto.AutoSize = true;
            this.lblLoginTexto.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginTexto.Location = new System.Drawing.Point(206, 116);
            this.lblLoginTexto.Name = "lblLoginTexto";
            this.lblLoginTexto.Size = new System.Drawing.Size(137, 24);
            this.lblLoginTexto.TabIndex = 0;
            this.lblLoginTexto.Text = "Inicia Sesión";
            // 
            // btnCerrarLogin
            // 
            this.btnCerrarLogin.BackColor = System.Drawing.Color.Firebrick;
            this.btnCerrarLogin.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCerrarLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarLogin.ForeColor = System.Drawing.Color.White;
            this.btnCerrarLogin.Location = new System.Drawing.Point(712, 12);
            this.btnCerrarLogin.Name = "btnCerrarLogin";
            this.btnCerrarLogin.Size = new System.Drawing.Size(44, 23);
            this.btnCerrarLogin.TabIndex = 0;
            this.btnCerrarLogin.Tag = "0";
            this.btnCerrarLogin.Text = "X";
            this.btnCerrarLogin.UseVisualStyleBackColor = false;
            this.btnCerrarLogin.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormularioInicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(768, 472);
            this.Controls.Add(this.btnCerrarLogin);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormularioInicioSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBUsuarioIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBcontraseniaIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBLoginIcono)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrarLogin;
        private System.Windows.Forms.Label lblLoginTexto;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.TextBox tBcontrasenia;
        private System.Windows.Forms.TextBox tBusuario;
        private System.Windows.Forms.PictureBox pBLoginIcono;
        private System.Windows.Forms.PictureBox pBcontraseniaIcono;
        private System.Windows.Forms.PictureBox pBUsuarioIcono;
    }
}

