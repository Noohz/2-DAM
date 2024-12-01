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
            this.btnConfirmarPrestamo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tBNombreProfesor = new System.Windows.Forms.TextBox();
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
            this.label2.Location = new System.Drawing.Point(12, 71);
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
            this.calendarioFechaDevolucion.Location = new System.Drawing.Point(290, 61);
            this.calendarioFechaDevolucion.MinimumSize = new System.Drawing.Size(4, 35);
            this.calendarioFechaDevolucion.Name = "calendarioFechaDevolucion";
            this.calendarioFechaDevolucion.Size = new System.Drawing.Size(256, 35);
            this.calendarioFechaDevolucion.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(103)))), ((int)(((byte)(73)))));
            this.calendarioFechaDevolucion.TabIndex = 12;
            this.calendarioFechaDevolucion.TabStop = false;
            this.calendarioFechaDevolucion.TextColor = System.Drawing.Color.White;
            // 
            // btnConfirmarPrestamo
            // 
            this.btnConfirmarPrestamo.BackColor = System.Drawing.SystemColors.Control;
            this.btnConfirmarPrestamo.FlatAppearance.BorderSize = 0;
            this.btnConfirmarPrestamo.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnConfirmarPrestamo.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnConfirmarPrestamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarPrestamo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarPrestamo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnConfirmarPrestamo.Location = new System.Drawing.Point(148, 157);
            this.btnConfirmarPrestamo.Name = "btnConfirmarPrestamo";
            this.btnConfirmarPrestamo.Size = new System.Drawing.Size(274, 30);
            this.btnConfirmarPrestamo.TabIndex = 1;
            this.btnConfirmarPrestamo.Text = "Confirmar";
            this.btnConfirmarPrestamo.UseVisualStyleBackColor = false;
            this.btnConfirmarPrestamo.Click += new System.EventHandler(this.BtnConfirmarPrestamo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(322, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Nombre del profesor que recibe el prestamo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBNombreProfesor
            // 
            this.tBNombreProfesor.Location = new System.Drawing.Point(341, 115);
            this.tBNombreProfesor.Name = "tBNombreProfesor";
            this.tBNombreProfesor.Size = new System.Drawing.Size(205, 20);
            this.tBNombreProfesor.TabIndex = 14;
            // 
            // FormularioConfirmaciónPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(103)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(550, 205);
            this.Controls.Add(this.tBNombreProfesor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConfirmarPrestamo);
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
        private System.Windows.Forms.Button btnConfirmarPrestamo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBNombreProfesor;
    }
}