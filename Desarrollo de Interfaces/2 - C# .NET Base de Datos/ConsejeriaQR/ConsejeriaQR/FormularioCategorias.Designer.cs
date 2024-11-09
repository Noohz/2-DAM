namespace ConsejeriaQR
{
    partial class FormularioCategorias
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
            this.btnCerrarCategorias = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRegistrarProfesor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCategoriaTexto = new System.Windows.Forms.Label();
            this.btnGestionPrestamos = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrarCategorias
            // 
            this.btnCerrarCategorias.BackColor = System.Drawing.Color.Firebrick;
            this.btnCerrarCategorias.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCerrarCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarCategorias.ForeColor = System.Drawing.Color.White;
            this.btnCerrarCategorias.Location = new System.Drawing.Point(712, 12);
            this.btnCerrarCategorias.Name = "btnCerrarCategorias";
            this.btnCerrarCategorias.Size = new System.Drawing.Size(44, 23);
            this.btnCerrarCategorias.TabIndex = 3;
            this.btnCerrarCategorias.TabStop = false;
            this.btnCerrarCategorias.Text = "X";
            this.btnCerrarCategorias.UseVisualStyleBackColor = false;
            this.btnCerrarCategorias.Click += new System.EventHandler(this.BtnCerrarCategorias_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnRegistrarProfesor);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblCategoriaTexto);
            this.panel1.Controls.Add(this.btnGestionPrestamos);
            this.panel1.Location = new System.Drawing.Point(131, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 353);
            this.panel1.TabIndex = 7;
            // 
            // btnRegistrarProfesor
            // 
            this.btnRegistrarProfesor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.btnRegistrarProfesor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarProfesor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarProfesor.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarProfesor.Location = new System.Drawing.Point(141, 289);
            this.btnRegistrarProfesor.Name = "btnRegistrarProfesor";
            this.btnRegistrarProfesor.Size = new System.Drawing.Size(250, 31);
            this.btnRegistrarProfesor.TabIndex = 2;
            this.btnRegistrarProfesor.Text = "Registrar profesor";
            this.btnRegistrarProfesor.UseVisualStyleBackColor = false;
            this.btnRegistrarProfesor.Visible = false;
            this.btnRegistrarProfesor.Click += new System.EventHandler(this.BtnRegistrarProfesor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(367, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "---";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(320, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 99);
            this.button2.TabIndex = 1;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gestión de Préstamos";
            // 
            // lblCategoriaTexto
            // 
            this.lblCategoriaTexto.AutoSize = true;
            this.lblCategoriaTexto.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblCategoriaTexto.Location = new System.Drawing.Point(87, 56);
            this.lblCategoriaTexto.Name = "lblCategoriaTexto";
            this.lblCategoriaTexto.Size = new System.Drawing.Size(348, 24);
            this.lblCategoriaTexto.TabIndex = 1;
            this.lblCategoriaTexto.Text = "Selecciona la categoría a acceder";
            // 
            // btnGestionPrestamos
            // 
            this.btnGestionPrestamos.BackgroundImage = global::ConsejeriaQR.Properties.Resources.GestionPrestamos;
            this.btnGestionPrestamos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGestionPrestamos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionPrestamos.Location = new System.Drawing.Point(91, 144);
            this.btnGestionPrestamos.Name = "btnGestionPrestamos";
            this.btnGestionPrestamos.Size = new System.Drawing.Size(115, 99);
            this.btnGestionPrestamos.TabIndex = 0;
            this.btnGestionPrestamos.UseVisualStyleBackColor = true;
            this.btnGestionPrestamos.Click += new System.EventHandler(this.BtnGestionPrestamos_Click);
            // 
            // FormularioCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(768, 472);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCerrarCategorias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormularioCategorias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormularioCategorias";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCerrarCategorias;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCategoriaTexto;
        private System.Windows.Forms.Button btnGestionPrestamos;
        private System.Windows.Forms.Button btnRegistrarProfesor;
    }
}