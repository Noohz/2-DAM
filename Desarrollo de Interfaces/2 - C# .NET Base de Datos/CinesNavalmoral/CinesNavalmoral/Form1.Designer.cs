namespace CinesNavalmoral
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
            this.panelPrincipal = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.tBAdmin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.AutoScroll = true;
            this.panelPrincipal.BackColor = System.Drawing.Color.NavajoWhite;
            this.panelPrincipal.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelPrincipal.Location = new System.Drawing.Point(12, 25);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(738, 403);
            this.panelPrincipal.TabIndex = 0;
            this.panelPrincipal.WrapContents = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(214, 434);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(370, 35);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Enabled = false;
            this.btnAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmin.Location = new System.Drawing.Point(12, 485);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(125, 23);
            this.btnAdmin.TabIndex = 1;
            this.btnAdmin.Text = "Administración";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // tBAdmin
            // 
            this.tBAdmin.Location = new System.Drawing.Point(144, 487);
            this.tBAdmin.Name = "tBAdmin";
            this.tBAdmin.PasswordChar = '*';
            this.tBAdmin.Size = new System.Drawing.Size(181, 20);
            this.tBAdmin.TabIndex = 2;
            this.tBAdmin.TextChanged += new System.EventHandler(this.tBAdmin_TextChanged);
            this.tBAdmin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tBAdmin_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 513);
            this.Controls.Add(this.tBAdmin);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.panelPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelPrincipal;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.TextBox tBAdmin;
    }
}

