namespace Aerolineas
{
    partial class PerfilUsuario
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
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnModCorreo = new System.Windows.Forms.Button();
            this.btnModCrontrasenia = new System.Windows.Forms.Button();
            this.gBOpcionesMail = new System.Windows.Forms.GroupBox();
            this.btnCerrarModEmail = new System.Windows.Forms.Button();
            this.btnModificarMail = new System.Windows.Forms.Button();
            this.lblTNewEmail = new System.Windows.Forms.Label();
            this.tBNewEmail = new System.Windows.Forms.TextBox();
            this.lblTOldEmail = new System.Windows.Forms.Label();
            this.tBOldEmail = new System.Windows.Forms.TextBox();
            this.gBOpcionesPwd = new System.Windows.Forms.GroupBox();
            this.btnCerrarPwd = new System.Windows.Forms.Button();
            this.btnModificarPwd = new System.Windows.Forms.Button();
            this.lblTNewPwd = new System.Windows.Forms.Label();
            this.tBNewPwd = new System.Windows.Forms.TextBox();
            this.lblTOldPwd = new System.Windows.Forms.Label();
            this.tBOldPwd = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.gBOpcionesMail.SuspendLayout();
            this.gBOpcionesPwd.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.Location = new System.Drawing.Point(279, 9);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(235, 25);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.Text = "*Bienvenido Usuario*";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(217, 45);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(361, 25);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "¿Que operación deseas realizar?";
            // 
            // btnModCorreo
            // 
            this.btnModCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModCorreo.Location = new System.Drawing.Point(145, 82);
            this.btnModCorreo.Name = "btnModCorreo";
            this.btnModCorreo.Size = new System.Drawing.Size(195, 36);
            this.btnModCorreo.TabIndex = 6;
            this.btnModCorreo.Text = "Modificar correo";
            this.btnModCorreo.UseVisualStyleBackColor = true;
            this.btnModCorreo.Click += new System.EventHandler(this.btnModCorreo_Click);
            // 
            // btnModCrontrasenia
            // 
            this.btnModCrontrasenia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModCrontrasenia.Location = new System.Drawing.Point(446, 82);
            this.btnModCrontrasenia.Name = "btnModCrontrasenia";
            this.btnModCrontrasenia.Size = new System.Drawing.Size(195, 36);
            this.btnModCrontrasenia.TabIndex = 7;
            this.btnModCrontrasenia.Text = "Modificar contraseña";
            this.btnModCrontrasenia.UseVisualStyleBackColor = true;
            this.btnModCrontrasenia.Click += new System.EventHandler(this.btnModCrontrasenia_Click);
            // 
            // gBOpcionesMail
            // 
            this.gBOpcionesMail.Controls.Add(this.btnCerrarModEmail);
            this.gBOpcionesMail.Controls.Add(this.btnModificarMail);
            this.gBOpcionesMail.Controls.Add(this.lblTNewEmail);
            this.gBOpcionesMail.Controls.Add(this.tBNewEmail);
            this.gBOpcionesMail.Controls.Add(this.lblTOldEmail);
            this.gBOpcionesMail.Controls.Add(this.tBOldEmail);
            this.gBOpcionesMail.Location = new System.Drawing.Point(12, 124);
            this.gBOpcionesMail.Name = "gBOpcionesMail";
            this.gBOpcionesMail.Size = new System.Drawing.Size(776, 314);
            this.gBOpcionesMail.TabIndex = 8;
            this.gBOpcionesMail.TabStop = false;
            this.gBOpcionesMail.Visible = false;
            // 
            // btnCerrarModEmail
            // 
            this.btnCerrarModEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarModEmail.Location = new System.Drawing.Point(434, 272);
            this.btnCerrarModEmail.Name = "btnCerrarModEmail";
            this.btnCerrarModEmail.Size = new System.Drawing.Size(195, 36);
            this.btnCerrarModEmail.TabIndex = 13;
            this.btnCerrarModEmail.Text = "Cerrar";
            this.btnCerrarModEmail.UseVisualStyleBackColor = true;
            this.btnCerrarModEmail.Click += new System.EventHandler(this.btnCerrarModEmail_Click);
            // 
            // btnModificarMail
            // 
            this.btnModificarMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarMail.Location = new System.Drawing.Point(133, 272);
            this.btnModificarMail.Name = "btnModificarMail";
            this.btnModificarMail.Size = new System.Drawing.Size(195, 36);
            this.btnModificarMail.TabIndex = 9;
            this.btnModificarMail.Text = "Modificar";
            this.btnModificarMail.UseVisualStyleBackColor = true;
            this.btnModificarMail.Click += new System.EventHandler(this.btnModificarMail_Click);
            // 
            // lblTNewEmail
            // 
            this.lblTNewEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTNewEmail.Location = new System.Drawing.Point(454, 16);
            this.lblTNewEmail.Name = "lblTNewEmail";
            this.lblTNewEmail.Size = new System.Drawing.Size(160, 35);
            this.lblTNewEmail.TabIndex = 11;
            this.lblTNewEmail.Text = "Email nuevo";
            this.lblTNewEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBNewEmail
            // 
            this.tBNewEmail.Enabled = false;
            this.tBNewEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBNewEmail.Location = new System.Drawing.Point(404, 54);
            this.tBNewEmail.Name = "tBNewEmail";
            this.tBNewEmail.Size = new System.Drawing.Size(254, 38);
            this.tBNewEmail.TabIndex = 12;
            // 
            // lblTOldEmail
            // 
            this.lblTOldEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTOldEmail.Location = new System.Drawing.Point(153, 16);
            this.lblTOldEmail.Name = "lblTOldEmail";
            this.lblTOldEmail.Size = new System.Drawing.Size(160, 35);
            this.lblTOldEmail.TabIndex = 9;
            this.lblTOldEmail.Text = "Email antiguo";
            this.lblTOldEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBOldEmail
            // 
            this.tBOldEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBOldEmail.Location = new System.Drawing.Point(103, 54);
            this.tBOldEmail.Name = "tBOldEmail";
            this.tBOldEmail.Size = new System.Drawing.Size(254, 38);
            this.tBOldEmail.TabIndex = 10;
            this.tBOldEmail.TextChanged += new System.EventHandler(this.tBOldEmail_TextChanged);
            // 
            // gBOpcionesPwd
            // 
            this.gBOpcionesPwd.Controls.Add(this.btnCerrarPwd);
            this.gBOpcionesPwd.Controls.Add(this.btnModificarPwd);
            this.gBOpcionesPwd.Controls.Add(this.lblTNewPwd);
            this.gBOpcionesPwd.Controls.Add(this.tBNewPwd);
            this.gBOpcionesPwd.Controls.Add(this.lblTOldPwd);
            this.gBOpcionesPwd.Controls.Add(this.tBOldPwd);
            this.gBOpcionesPwd.Location = new System.Drawing.Point(12, 124);
            this.gBOpcionesPwd.Name = "gBOpcionesPwd";
            this.gBOpcionesPwd.Size = new System.Drawing.Size(776, 314);
            this.gBOpcionesPwd.TabIndex = 9;
            this.gBOpcionesPwd.TabStop = false;
            this.gBOpcionesPwd.Visible = false;
            // 
            // btnCerrarPwd
            // 
            this.btnCerrarPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarPwd.Location = new System.Drawing.Point(434, 272);
            this.btnCerrarPwd.Name = "btnCerrarPwd";
            this.btnCerrarPwd.Size = new System.Drawing.Size(195, 36);
            this.btnCerrarPwd.TabIndex = 13;
            this.btnCerrarPwd.Text = "Cerrar";
            this.btnCerrarPwd.UseVisualStyleBackColor = true;
            this.btnCerrarPwd.Click += new System.EventHandler(this.btnCerrarPwd_Click);
            // 
            // btnModificarPwd
            // 
            this.btnModificarPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarPwd.Location = new System.Drawing.Point(133, 272);
            this.btnModificarPwd.Name = "btnModificarPwd";
            this.btnModificarPwd.Size = new System.Drawing.Size(195, 36);
            this.btnModificarPwd.TabIndex = 9;
            this.btnModificarPwd.Text = "Modificar";
            this.btnModificarPwd.UseVisualStyleBackColor = true;
            this.btnModificarPwd.Click += new System.EventHandler(this.btnModificarPwd_Click);
            // 
            // lblTNewPwd
            // 
            this.lblTNewPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTNewPwd.Location = new System.Drawing.Point(404, 16);
            this.lblTNewPwd.Name = "lblTNewPwd";
            this.lblTNewPwd.Size = new System.Drawing.Size(254, 35);
            this.lblTNewPwd.TabIndex = 11;
            this.lblTNewPwd.Text = "Contraseña nueva";
            this.lblTNewPwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBNewPwd
            // 
            this.tBNewPwd.Enabled = false;
            this.tBNewPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBNewPwd.Location = new System.Drawing.Point(404, 54);
            this.tBNewPwd.Name = "tBNewPwd";
            this.tBNewPwd.PasswordChar = '*';
            this.tBNewPwd.Size = new System.Drawing.Size(254, 38);
            this.tBNewPwd.TabIndex = 12;
            this.tBNewPwd.UseSystemPasswordChar = true;
            // 
            // lblTOldPwd
            // 
            this.lblTOldPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTOldPwd.Location = new System.Drawing.Point(103, 16);
            this.lblTOldPwd.Name = "lblTOldPwd";
            this.lblTOldPwd.Size = new System.Drawing.Size(254, 35);
            this.lblTOldPwd.TabIndex = 9;
            this.lblTOldPwd.Text = "Contraseña antigua";
            this.lblTOldPwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBOldPwd
            // 
            this.tBOldPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBOldPwd.Location = new System.Drawing.Point(103, 54);
            this.tBOldPwd.Name = "tBOldPwd";
            this.tBOldPwd.PasswordChar = '*';
            this.tBOldPwd.Size = new System.Drawing.Size(254, 38);
            this.tBOldPwd.TabIndex = 10;
            this.tBOldPwd.UseSystemPasswordChar = true;
            this.tBOldPwd.TextChanged += new System.EventHandler(this.tBOldPwd_TextChanged);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(296, 451);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(195, 36);
            this.btnCerrar.TabIndex = 14;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // PerfilUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.ClientSize = new System.Drawing.Size(800, 499);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.gBOpcionesPwd);
            this.Controls.Add(this.gBOpcionesMail);
            this.Controls.Add(this.btnModCrontrasenia);
            this.Controls.Add(this.btnModCorreo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblBienvenida);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PerfilUsuario";
            this.Text = "PerfilUsuario";
            this.gBOpcionesMail.ResumeLayout(false);
            this.gBOpcionesMail.PerformLayout();
            this.gBOpcionesPwd.ResumeLayout(false);
            this.gBOpcionesPwd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnModCorreo;
        private System.Windows.Forms.Button btnModCrontrasenia;
        private System.Windows.Forms.GroupBox gBOpcionesMail;
        private System.Windows.Forms.Label lblTOldEmail;
        private System.Windows.Forms.TextBox tBOldEmail;
        private System.Windows.Forms.Button btnModificarMail;
        private System.Windows.Forms.Label lblTNewEmail;
        private System.Windows.Forms.TextBox tBNewEmail;
        private System.Windows.Forms.Button btnCerrarModEmail;
        private System.Windows.Forms.GroupBox gBOpcionesPwd;
        private System.Windows.Forms.Button btnCerrarPwd;
        private System.Windows.Forms.Button btnModificarPwd;
        private System.Windows.Forms.Label lblTNewPwd;
        private System.Windows.Forms.TextBox tBNewPwd;
        private System.Windows.Forms.Label lblTOldPwd;
        private System.Windows.Forms.TextBox tBOldPwd;
        private System.Windows.Forms.Button btnCerrar;
    }
}