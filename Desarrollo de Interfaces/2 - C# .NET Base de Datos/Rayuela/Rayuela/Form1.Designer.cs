namespace Rayuela
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
            this.tabControlCiclo = new System.Windows.Forms.TabControl();
            this.btnCrearAlumno = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabControlCiclo
            // 
            this.tabControlCiclo.Location = new System.Drawing.Point(13, 13);
            this.tabControlCiclo.Name = "tabControlCiclo";
            this.tabControlCiclo.SelectedIndex = 0;
            this.tabControlCiclo.Size = new System.Drawing.Size(660, 425);
            this.tabControlCiclo.TabIndex = 0;
            // 
            // btnCrearAlumno
            // 
            this.btnCrearAlumno.Location = new System.Drawing.Point(12, 448);
            this.btnCrearAlumno.Name = "btnCrearAlumno";
            this.btnCrearAlumno.Size = new System.Drawing.Size(80, 23);
            this.btnCrearAlumno.TabIndex = 1;
            this.btnCrearAlumno.Text = "Crear Alumno";
            this.btnCrearAlumno.UseVisualStyleBackColor = true;
            this.btnCrearAlumno.Click += new System.EventHandler(this.btnCrearAlumno_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 483);
            this.Controls.Add(this.btnCrearAlumno);
            this.Controls.Add(this.tabControlCiclo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlCiclo;
        private System.Windows.Forms.Button btnCrearAlumno;
    }
}

