namespace ConsejeriaQR
{
    partial class FormularioGestionPrestamos
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
            this.lblGestionPrestamoTitulo = new System.Windows.Forms.Label();
            this.btnVolverGestionPrestamos = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrestarArticulo = new System.Windows.Forms.Button();
            this.btnEliminarArticulo = new System.Windows.Forms.Button();
            this.btnAniadirArticulo = new System.Windows.Forms.Button();
            this.pBLoginIcono = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBLoginIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblGestionPrestamoTitulo);
            this.panel1.Controls.Add(this.btnVolverGestionPrestamos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1339, 45);
            this.panel1.TabIndex = 0;
            // 
            // lblGestionPrestamoTitulo
            // 
            this.lblGestionPrestamoTitulo.AutoSize = true;
            this.lblGestionPrestamoTitulo.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblGestionPrestamoTitulo.Location = new System.Drawing.Point(12, 9);
            this.lblGestionPrestamoTitulo.Name = "lblGestionPrestamoTitulo";
            this.lblGestionPrestamoTitulo.Size = new System.Drawing.Size(234, 24);
            this.lblGestionPrestamoTitulo.TabIndex = 2;
            this.lblGestionPrestamoTitulo.Text = "Gestión de Préstamos";
            // 
            // btnVolverGestionPrestamos
            // 
            this.btnVolverGestionPrestamos.BackColor = System.Drawing.Color.Firebrick;
            this.btnVolverGestionPrestamos.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnVolverGestionPrestamos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolverGestionPrestamos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolverGestionPrestamos.ForeColor = System.Drawing.Color.White;
            this.btnVolverGestionPrestamos.Location = new System.Drawing.Point(1283, 12);
            this.btnVolverGestionPrestamos.Name = "btnVolverGestionPrestamos";
            this.btnVolverGestionPrestamos.Size = new System.Drawing.Size(44, 23);
            this.btnVolverGestionPrestamos.TabIndex = 12;
            this.btnVolverGestionPrestamos.Text = "->";
            this.btnVolverGestionPrestamos.UseVisualStyleBackColor = false;
            this.btnVolverGestionPrestamos.Click += new System.EventHandler(this.btnVolverGestionPrestamos_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.panel2.Controls.Add(this.lblNombreUsuario);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnPrestarArticulo);
            this.panel2.Controls.Add(this.btnEliminarArticulo);
            this.panel2.Controls.Add(this.btnAniadirArticulo);
            this.panel2.Controls.Add(this.pBLoginIcono);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 717);
            this.panel2.TabIndex = 1;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.Location = new System.Drawing.Point(68, 169);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(95, 19);
            this.lblNombreUsuario.TabIndex = 14;
            this.lblNombreUsuario.Text = "*USUARIO*";
            this.lblNombreUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "Bienvenido";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrestarArticulo
            // 
            this.btnPrestarArticulo.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrestarArticulo.Enabled = false;
            this.btnPrestarArticulo.FlatAppearance.BorderSize = 0;
            this.btnPrestarArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnPrestarArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnPrestarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrestarArticulo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrestarArticulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrestarArticulo.Location = new System.Drawing.Point(12, 369);
            this.btnPrestarArticulo.Name = "btnPrestarArticulo";
            this.btnPrestarArticulo.Size = new System.Drawing.Size(221, 43);
            this.btnPrestarArticulo.TabIndex = 8;
            this.btnPrestarArticulo.Text = "Prestar artículos";
            this.btnPrestarArticulo.UseVisualStyleBackColor = false;
            // 
            // btnEliminarArticulo
            // 
            this.btnEliminarArticulo.BackColor = System.Drawing.SystemColors.Control;
            this.btnEliminarArticulo.Enabled = false;
            this.btnEliminarArticulo.FlatAppearance.BorderSize = 0;
            this.btnEliminarArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnEliminarArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnEliminarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarArticulo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarArticulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEliminarArticulo.Location = new System.Drawing.Point(12, 306);
            this.btnEliminarArticulo.Name = "btnEliminarArticulo";
            this.btnEliminarArticulo.Size = new System.Drawing.Size(221, 43);
            this.btnEliminarArticulo.TabIndex = 7;
            this.btnEliminarArticulo.Text = "Eliminar artículos";
            this.btnEliminarArticulo.UseVisualStyleBackColor = false;
            this.btnEliminarArticulo.Click += new System.EventHandler(this.btnEliminarArticulo_Click);
            // 
            // btnAniadirArticulo
            // 
            this.btnAniadirArticulo.BackColor = System.Drawing.SystemColors.Control;
            this.btnAniadirArticulo.FlatAppearance.BorderSize = 0;
            this.btnAniadirArticulo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnAniadirArticulo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnAniadirArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAniadirArticulo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAniadirArticulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAniadirArticulo.Location = new System.Drawing.Point(12, 241);
            this.btnAniadirArticulo.Name = "btnAniadirArticulo";
            this.btnAniadirArticulo.Size = new System.Drawing.Size(221, 43);
            this.btnAniadirArticulo.TabIndex = 6;
            this.btnAniadirArticulo.Text = "Añadir artículos";
            this.btnAniadirArticulo.UseVisualStyleBackColor = false;
            this.btnAniadirArticulo.Click += new System.EventHandler(this.btnAniadirArticulo_Click);
            // 
            // pBLoginIcono
            // 
            this.pBLoginIcono.Image = global::ConsejeriaQR.Properties.Resources.GestionPrestamos;
            this.pBLoginIcono.Location = new System.Drawing.Point(76, 44);
            this.pBLoginIcono.Name = "pBLoginIcono";
            this.pBLoginIcono.Size = new System.Drawing.Size(80, 80);
            this.pBLoginIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBLoginIcono.TabIndex = 5;
            this.pBLoginIcono.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(103)))), ((int)(((byte)(73)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(248, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1091, 717);
            this.panel3.TabIndex = 2;
            // 
            // FormularioGestionPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 762);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormularioGestionPrestamos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormularioGestionPrestamos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBLoginIcono)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVolverGestionPrestamos;
        private System.Windows.Forms.Label lblGestionPrestamoTitulo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pBLoginIcono;
        private System.Windows.Forms.Button btnAniadirArticulo;
        private System.Windows.Forms.Button btnEliminarArticulo;
        private System.Windows.Forms.Button btnPrestarArticulo;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
    }
}