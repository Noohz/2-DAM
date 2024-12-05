namespace ConsejeriaQR
{
    partial class FormularioCargarFicheroAula
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
            this.btnSeleccionarFichero = new System.Windows.Forms.Button();
            this.tBDirArchivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImportarFichero = new System.Windows.Forms.Button();
            this.lblTituloForm = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(103)))), ((int)(((byte)(73)))));
            this.panel1.Controls.Add(this.btnSeleccionarFichero);
            this.panel1.Controls.Add(this.tBDirArchivo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.btnImportarFichero);
            this.panel1.Controls.Add(this.lblTituloForm);
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 307);
            this.panel1.TabIndex = 1;
            // 
            // btnSeleccionarFichero
            // 
            this.btnSeleccionarFichero.BackgroundImage = global::ConsejeriaQR.Properties.Resources.folder;
            this.btnSeleccionarFichero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSeleccionarFichero.Location = new System.Drawing.Point(747, 98);
            this.btnSeleccionarFichero.Name = "btnSeleccionarFichero";
            this.btnSeleccionarFichero.Size = new System.Drawing.Size(40, 23);
            this.btnSeleccionarFichero.TabIndex = 0;
            this.btnSeleccionarFichero.UseVisualStyleBackColor = true;
            this.btnSeleccionarFichero.Click += new System.EventHandler(this.btnSeleccionarFichero_Click);
            // 
            // tBDirArchivo
            // 
            this.tBDirArchivo.Enabled = false;
            this.tBDirArchivo.Location = new System.Drawing.Point(380, 100);
            this.tBDirArchivo.Name = "tBDirArchivo";
            this.tBDirArchivo.Size = new System.Drawing.Size(361, 20);
            this.tBDirArchivo.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Selecciona la dirección del fichero .CSV";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Firebrick;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(472, 230);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(323, 43);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImportarFichero
            // 
            this.btnImportarFichero.AutoSize = true;
            this.btnImportarFichero.BackColor = System.Drawing.SystemColors.Control;
            this.btnImportarFichero.FlatAppearance.BorderSize = 0;
            this.btnImportarFichero.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnImportarFichero.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnImportarFichero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportarFichero.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportarFichero.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnImportarFichero.Location = new System.Drawing.Point(61, 230);
            this.btnImportarFichero.Name = "btnImportarFichero";
            this.btnImportarFichero.Size = new System.Drawing.Size(323, 43);
            this.btnImportarFichero.TabIndex = 1;
            this.btnImportarFichero.Text = "Importar fichero";
            this.btnImportarFichero.UseVisualStyleBackColor = false;
            this.btnImportarFichero.Click += new System.EventHandler(this.btnImportarFichero_Click);
            // 
            // lblTituloForm
            // 
            this.lblTituloForm.AutoSize = true;
            this.lblTituloForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloForm.Location = new System.Drawing.Point(211, 13);
            this.lblTituloForm.Name = "lblTituloForm";
            this.lblTituloForm.Size = new System.Drawing.Size(299, 25);
            this.lblTituloForm.TabIndex = 17;
            this.lblTituloForm.Text = "Insertar fichero .CSV para: ";
            // 
            // FormularioCargarFicheroAula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(866, 331);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormularioCargarFicheroAula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargar fichero .CSV";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnImportarFichero;
        private System.Windows.Forms.Label lblTituloForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBDirArchivo;
        private System.Windows.Forms.Button btnSeleccionarFichero;
    }
}