namespace Rayuela
{
    partial class InformacionAlumno
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
            this.btnPdfMailCalif = new System.Windows.Forms.Button();
            this.btnPdfMailAsis = new System.Windows.Forms.Button();
            this.lblAsistencia = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dGVCalif = new System.Windows.Forms.DataGridView();
            this.dGVAsis = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dGVCalif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVAsis)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(340, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Calificaciones";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPdfMailCalif
            // 
            this.btnPdfMailCalif.Location = new System.Drawing.Point(229, 200);
            this.btnPdfMailCalif.Name = "btnPdfMailCalif";
            this.btnPdfMailCalif.Size = new System.Drawing.Size(393, 23);
            this.btnPdfMailCalif.TabIndex = 2;
            this.btnPdfMailCalif.Text = "PDF + MAIL";
            this.btnPdfMailCalif.UseVisualStyleBackColor = true;
            // 
            // btnPdfMailAsis
            // 
            this.btnPdfMailAsis.Location = new System.Drawing.Point(229, 429);
            this.btnPdfMailAsis.Name = "btnPdfMailAsis";
            this.btnPdfMailAsis.Size = new System.Drawing.Size(393, 23);
            this.btnPdfMailAsis.TabIndex = 5;
            this.btnPdfMailAsis.Text = "PDF + MAIL";
            this.btnPdfMailAsis.UseVisualStyleBackColor = true;
            // 
            // lblAsistencia
            // 
            this.lblAsistencia.AutoSize = true;
            this.lblAsistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAsistencia.Location = new System.Drawing.Point(368, 239);
            this.lblAsistencia.Name = "lblAsistencia";
            this.lblAsistencia.Size = new System.Drawing.Size(121, 25);
            this.lblAsistencia.TabIndex = 4;
            this.lblAsistencia.Text = "Asistencia";
            this.lblAsistencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(229, 458);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(393, 23);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // dGVCalif
            // 
            this.dGVCalif.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVCalif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVCalif.Enabled = false;
            this.dGVCalif.Location = new System.Drawing.Point(13, 39);
            this.dGVCalif.Name = "dGVCalif";
            this.dGVCalif.Size = new System.Drawing.Size(775, 150);
            this.dGVCalif.TabIndex = 7;
            // 
            // dGVAsis
            // 
            this.dGVAsis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVAsis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVAsis.Enabled = false;
            this.dGVAsis.Location = new System.Drawing.Point(13, 268);
            this.dGVAsis.Name = "dGVAsis";
            this.dGVAsis.Size = new System.Drawing.Size(775, 150);
            this.dGVAsis.TabIndex = 8;
            // 
            // InformacionAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 484);
            this.Controls.Add(this.dGVAsis);
            this.Controls.Add(this.dGVCalif);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnPdfMailAsis);
            this.Controls.Add(this.lblAsistencia);
            this.Controls.Add(this.btnPdfMailCalif);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InformacionAlumno";
            this.Text = "InformacionAlumno";
            ((System.ComponentModel.ISupportInitialize)(this.dGVCalif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVAsis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPdfMailCalif;
        private System.Windows.Forms.Button btnPdfMailAsis;
        private System.Windows.Forms.Label lblAsistencia;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dGVCalif;
        private System.Windows.Forms.DataGridView dGVAsis;
    }
}