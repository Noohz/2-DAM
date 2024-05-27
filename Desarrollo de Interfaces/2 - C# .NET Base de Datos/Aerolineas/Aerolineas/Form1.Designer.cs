namespace Aerolineas
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnCerrarLogeo = new System.Windows.Forms.Button();
            this.btnAcceder = new System.Windows.Forms.Button();
            this.tBContraseniaLogin = new System.Windows.Forms.TextBox();
            this.lblTContrasenia = new System.Windows.Forms.Label();
            this.tBUsuario = new System.Windows.Forms.TextBox();
            this.lblTUsuario = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCerrarRegistro = new System.Windows.Forms.Button();
            this.btnRegistro = new System.Windows.Forms.Button();
            this.tBEmailRegistro = new System.Windows.Forms.TextBox();
            this.lblTEmailRegistro = new System.Windows.Forms.Label();
            this.tBContraseniaRegistro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tBUsuarioRegistro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(664, 371);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DarkSalmon;
            this.tabPage1.Controls.Add(this.btnCerrarLogeo);
            this.tabPage1.Controls.Add(this.btnAcceder);
            this.tabPage1.Controls.Add(this.tBContraseniaLogin);
            this.tabPage1.Controls.Add(this.lblTContrasenia);
            this.tabPage1.Controls.Add(this.tBUsuario);
            this.tabPage1.Controls.Add(this.lblTUsuario);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(656, 345);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Iniciar Sesión";
            // 
            // btnCerrarLogeo
            // 
            this.btnCerrarLogeo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarLogeo.Location = new System.Drawing.Point(353, 270);
            this.btnCerrarLogeo.Name = "btnCerrarLogeo";
            this.btnCerrarLogeo.Size = new System.Drawing.Size(117, 36);
            this.btnCerrarLogeo.TabIndex = 6;
            this.btnCerrarLogeo.Text = "Cerrar";
            this.btnCerrarLogeo.UseVisualStyleBackColor = true;
            this.btnCerrarLogeo.Click += new System.EventHandler(this.btnCerrarLogeo_Click);
            // 
            // btnAcceder
            // 
            this.btnAcceder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcceder.Location = new System.Drawing.Point(175, 270);
            this.btnAcceder.Name = "btnAcceder";
            this.btnAcceder.Size = new System.Drawing.Size(117, 36);
            this.btnAcceder.TabIndex = 5;
            this.btnAcceder.Text = "Acceder";
            this.btnAcceder.UseVisualStyleBackColor = true;
            this.btnAcceder.Click += new System.EventHandler(this.btnAcceder_Click);
            // 
            // tBContraseniaLogin
            // 
            this.tBContraseniaLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBContraseniaLogin.Location = new System.Drawing.Point(248, 153);
            this.tBContraseniaLogin.Name = "tBContraseniaLogin";
            this.tBContraseniaLogin.PasswordChar = '*';
            this.tBContraseniaLogin.Size = new System.Drawing.Size(372, 38);
            this.tBContraseniaLogin.TabIndex = 4;
            this.tBContraseniaLogin.UseSystemPasswordChar = true;
            this.tBContraseniaLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBContraseniaLogin_KeyDown);
            // 
            // lblTContrasenia
            // 
            this.lblTContrasenia.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTContrasenia.Location = new System.Drawing.Point(29, 156);
            this.lblTContrasenia.Name = "lblTContrasenia";
            this.lblTContrasenia.Size = new System.Drawing.Size(220, 35);
            this.lblTContrasenia.TabIndex = 3;
            this.lblTContrasenia.Text = "Contraseña";
            this.lblTContrasenia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBUsuario
            // 
            this.tBUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBUsuario.Location = new System.Drawing.Point(248, 43);
            this.tBUsuario.Name = "tBUsuario";
            this.tBUsuario.Size = new System.Drawing.Size(372, 38);
            this.tBUsuario.TabIndex = 2;
            // 
            // lblTUsuario
            // 
            this.lblTUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTUsuario.Location = new System.Drawing.Point(22, 46);
            this.lblTUsuario.Name = "lblTUsuario";
            this.lblTUsuario.Size = new System.Drawing.Size(220, 35);
            this.lblTUsuario.TabIndex = 0;
            this.lblTUsuario.Text = "Usuario";
            this.lblTUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DarkSalmon;
            this.tabPage2.Controls.Add(this.btnCerrarRegistro);
            this.tabPage2.Controls.Add(this.btnRegistro);
            this.tabPage2.Controls.Add(this.tBEmailRegistro);
            this.tabPage2.Controls.Add(this.lblTEmailRegistro);
            this.tabPage2.Controls.Add(this.tBContraseniaRegistro);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.tBUsuarioRegistro);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(656, 345);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Registrar Usuario";
            // 
            // btnCerrarRegistro
            // 
            this.btnCerrarRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarRegistro.Location = new System.Drawing.Point(353, 270);
            this.btnCerrarRegistro.Name = "btnCerrarRegistro";
            this.btnCerrarRegistro.Size = new System.Drawing.Size(117, 36);
            this.btnCerrarRegistro.TabIndex = 18;
            this.btnCerrarRegistro.Text = "Cerrar";
            this.btnCerrarRegistro.UseVisualStyleBackColor = true;
            this.btnCerrarRegistro.Click += new System.EventHandler(this.btnCerrarRegistro_Click);
            // 
            // btnRegistro
            // 
            this.btnRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistro.Location = new System.Drawing.Point(175, 270);
            this.btnRegistro.Name = "btnRegistro";
            this.btnRegistro.Size = new System.Drawing.Size(117, 36);
            this.btnRegistro.TabIndex = 17;
            this.btnRegistro.Text = "Registrar";
            this.btnRegistro.UseVisualStyleBackColor = true;
            this.btnRegistro.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // tBEmailRegistro
            // 
            this.tBEmailRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.tBEmailRegistro.Location = new System.Drawing.Point(252, 171);
            this.tBEmailRegistro.Name = "tBEmailRegistro";
            this.tBEmailRegistro.Size = new System.Drawing.Size(372, 38);
            this.tBEmailRegistro.TabIndex = 16;
            this.tBEmailRegistro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBEmailRegistro_KeyDown);
            // 
            // lblTEmailRegistro
            // 
            this.lblTEmailRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.lblTEmailRegistro.Location = new System.Drawing.Point(68, 171);
            this.lblTEmailRegistro.Name = "lblTEmailRegistro";
            this.lblTEmailRegistro.Size = new System.Drawing.Size(144, 35);
            this.lblTEmailRegistro.TabIndex = 15;
            this.lblTEmailRegistro.Text = "Email";
            this.lblTEmailRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBContraseniaRegistro
            // 
            this.tBContraseniaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBContraseniaRegistro.Location = new System.Drawing.Point(252, 105);
            this.tBContraseniaRegistro.Name = "tBContraseniaRegistro";
            this.tBContraseniaRegistro.PasswordChar = '*';
            this.tBContraseniaRegistro.Size = new System.Drawing.Size(372, 38);
            this.tBContraseniaRegistro.TabIndex = 10;
            this.tBContraseniaRegistro.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 35);
            this.label1.TabIndex = 9;
            this.label1.Text = "Contraseña";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBUsuarioRegistro
            // 
            this.tBUsuarioRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBUsuarioRegistro.Location = new System.Drawing.Point(252, 41);
            this.tBUsuarioRegistro.Name = "tBUsuarioRegistro";
            this.tBUsuarioRegistro.Size = new System.Drawing.Size(372, 38);
            this.tBUsuarioRegistro.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 35);
            this.label2.TabIndex = 7;
            this.label2.Text = "Usuario";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(687, 379);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblTUsuario;
        private System.Windows.Forms.TextBox tBContraseniaLogin;
        private System.Windows.Forms.Label lblTContrasenia;
        private System.Windows.Forms.TextBox tBUsuario;
        private System.Windows.Forms.Button btnCerrarLogeo;
        private System.Windows.Forms.Button btnAcceder;
        private System.Windows.Forms.TextBox tBContraseniaRegistro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBUsuarioRegistro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBEmailRegistro;
        private System.Windows.Forms.Label lblTEmailRegistro;
        private System.Windows.Forms.Button btnCerrarRegistro;
        private System.Windows.Forms.Button btnRegistro;
    }
}

