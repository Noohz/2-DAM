namespace Aerolineas
{
    partial class Embarque
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
            this.components = new System.ComponentModel.Container();
            this.lblEmbarqueBienvenida = new System.Windows.Forms.Label();
            this.panelValidacion = new System.Windows.Forms.Panel();
            this.tBQRAuto = new System.Windows.Forms.TextBox();
            this.lblCodEmbarque = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEmbarqueBienvenida
            // 
            this.lblEmbarqueBienvenida.AutoSize = true;
            this.lblEmbarqueBienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmbarqueBienvenida.Location = new System.Drawing.Point(117, 19);
            this.lblEmbarqueBienvenida.Name = "lblEmbarqueBienvenida";
            this.lblEmbarqueBienvenida.Size = new System.Drawing.Size(405, 25);
            this.lblEmbarqueBienvenida.TabIndex = 1;
            this.lblEmbarqueBienvenida.Text = "Bienvenido a la interfaz de embarque";
            // 
            // panelValidacion
            // 
            this.panelValidacion.BackColor = System.Drawing.SystemColors.Control;
            this.panelValidacion.Location = new System.Drawing.Point(215, 176);
            this.panelValidacion.Name = "panelValidacion";
            this.panelValidacion.Size = new System.Drawing.Size(225, 147);
            this.panelValidacion.TabIndex = 28;
            // 
            // tBQRAuto
            // 
            this.tBQRAuto.Location = new System.Drawing.Point(122, 137);
            this.tBQRAuto.Name = "tBQRAuto";
            this.tBQRAuto.Size = new System.Drawing.Size(400, 20);
            this.tBQRAuto.TabIndex = 27;
            this.tBQRAuto.TextChanged += new System.EventHandler(this.tBQRAuto_TextChanged);
            // 
            // lblCodEmbarque
            // 
            this.lblCodEmbarque.AutoSize = true;
            this.lblCodEmbarque.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodEmbarque.Location = new System.Drawing.Point(210, 93);
            this.lblCodEmbarque.Name = "lblCodEmbarque";
            this.lblCodEmbarque.Size = new System.Drawing.Size(230, 25);
            this.lblCodEmbarque.TabIndex = 29;
            this.lblCodEmbarque.Text = "Código de embarque";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(270, 329);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(108, 29);
            this.btnCerrar.TabIndex = 30;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // Embarque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.ClientSize = new System.Drawing.Size(651, 367);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblCodEmbarque);
            this.Controls.Add(this.panelValidacion);
            this.Controls.Add(this.tBQRAuto);
            this.Controls.Add(this.lblEmbarqueBienvenida);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Embarque";
            this.Text = "Embarque";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEmbarqueBienvenida;
        private System.Windows.Forms.Panel panelValidacion;
        private System.Windows.Forms.TextBox tBQRAuto;
        private System.Windows.Forms.Label lblCodEmbarque;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnCerrar;
    }
}