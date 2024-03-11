
namespace Prueba2
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
            this.components = new System.ComponentModel.Container();
            this.btnEmpezar = new System.Windows.Forms.Button();
            this.lstMenor = new System.Windows.Forms.ListBox();
            this.btnPausar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lstMayor = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblRandom = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEmpezar
            // 
            this.btnEmpezar.Location = new System.Drawing.Point(258, 95);
            this.btnEmpezar.Name = "btnEmpezar";
            this.btnEmpezar.Size = new System.Drawing.Size(75, 23);
            this.btnEmpezar.TabIndex = 0;
            this.btnEmpezar.Text = "Empezar";
            this.btnEmpezar.UseVisualStyleBackColor = true;
            this.btnEmpezar.Click += new System.EventHandler(this.btnEmpezar_Click);
            // 
            // lstMenor
            // 
            this.lstMenor.FormattingEnabled = true;
            this.lstMenor.Location = new System.Drawing.Point(214, 173);
            this.lstMenor.Name = "lstMenor";
            this.lstMenor.Size = new System.Drawing.Size(120, 147);
            this.lstMenor.TabIndex = 1;
            this.lstMenor.SelectedIndexChanged += new System.EventHandler(this.lstMenor_SelectedIndexChanged);
            // 
            // btnPausar
            // 
            this.btnPausar.Location = new System.Drawing.Point(357, 95);
            this.btnPausar.Name = "btnPausar";
            this.btnPausar.Size = new System.Drawing.Size(75, 23);
            this.btnPausar.TabIndex = 2;
            this.btnPausar.Text = "Pausar";
            this.btnPausar.UseVisualStyleBackColor = true;
            this.btnPausar.Click += new System.EventHandler(this.btnPausar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(456, 95);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lstMayor
            // 
            this.lstMayor.FormattingEnabled = true;
            this.lstMayor.Location = new System.Drawing.Point(457, 173);
            this.lstMayor.Name = "lstMayor";
            this.lstMayor.Size = new System.Drawing.Size(120, 147);
            this.lstMayor.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblRandom
            // 
            this.lblRandom.AutoSize = true;
            this.lblRandom.Location = new System.Drawing.Point(394, 150);
            this.lblRandom.Name = "lblRandom";
            this.lblRandom.Size = new System.Drawing.Size(0, 13);
            this.lblRandom.TabIndex = 5;
            this.lblRandom.Click += new System.EventHandler(this.lblRandom_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblRandom);
            this.Controls.Add(this.lstMayor);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnPausar);
            this.Controls.Add(this.lstMenor);
            this.Controls.Add(this.btnEmpezar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEmpezar;
        private System.Windows.Forms.ListBox lstMenor;
        private System.Windows.Forms.Button btnPausar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ListBox lstMayor;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblRandom;
    }
}

