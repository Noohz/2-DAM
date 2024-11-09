namespace ConsejeriaQR
{
    partial class FormularioConfirmaciónPrestamo
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.calendarioFechaDevolucion = new ConsejeriaQR.Controls_Personalizados.Calendario_personalizado();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(144, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Confirmación de prestamo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Selecciona la fecha de devolución =>";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // calendarioFechaDevolucion
            // 
            this.calendarioFechaDevolucion.BorderColor = System.Drawing.Color.Black;
            this.calendarioFechaDevolucion.BorderSize = 1;
            this.calendarioFechaDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.calendarioFechaDevolucion.Location = new System.Drawing.Point(290, 97);
            this.calendarioFechaDevolucion.MinimumSize = new System.Drawing.Size(0, 35);
            this.calendarioFechaDevolucion.Name = "calendarioFechaDevolucion";
            this.calendarioFechaDevolucion.Size = new System.Drawing.Size(256, 35);
            this.calendarioFechaDevolucion.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(103)))), ((int)(((byte)(73)))));
            this.calendarioFechaDevolucion.TabIndex = 12;
            this.calendarioFechaDevolucion.TabStop = false;
            this.calendarioFechaDevolucion.TextColor = System.Drawing.Color.White;
            // 
            // FormularioConfirmaciónPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(103)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(550, 239);
            this.Controls.Add(this.calendarioFechaDevolucion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormularioConfirmaciónPrestamo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmación de Prestamo";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Controls_Personalizados.Calendario_personalizado calendarioFechaDevolucion;
    }
}