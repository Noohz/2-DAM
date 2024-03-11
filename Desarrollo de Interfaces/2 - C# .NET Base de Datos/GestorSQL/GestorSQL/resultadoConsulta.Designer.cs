namespace GestorSQL
{
    partial class resultadoConsulta
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
            this.textBoxConsultaR1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxConsultaR1
            // 
            this.textBoxConsultaR1.Location = new System.Drawing.Point(113, 12);
            this.textBoxConsultaR1.Multiline = true;
            this.textBoxConsultaR1.Name = "textBoxConsultaR1";
            this.textBoxConsultaR1.ReadOnly = true;
            this.textBoxConsultaR1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxConsultaR1.Size = new System.Drawing.Size(575, 426);
            this.textBoxConsultaR1.TabIndex = 3;
            // 
            // resultadoConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxConsultaR1);
            this.Name = "resultadoConsulta";
            this.Text = "Resultado Consulta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxConsultaR1;
    }
}