namespace Examen6Octubre
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
            this.dgvCesta = new System.Windows.Forms.DataGridView();
            this.btnPagar = new System.Windows.Forms.Button();
            this.labelPrecioTotal = new System.Windows.Forms.Label();
            this.btnCargar = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCesta)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCesta
            // 
            this.dgvCesta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCesta.Location = new System.Drawing.Point(503, 12);
            this.dgvCesta.Name = "dgvCesta";
            this.dgvCesta.Size = new System.Drawing.Size(513, 333);
            this.dgvCesta.TabIndex = 0;
            this.dgvCesta.Visible = false;
            // 
            // btnPagar
            // 
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.Location = new System.Drawing.Point(509, 369);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(135, 61);
            this.btnPagar.TabIndex = 1;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Visible = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // labelPrecioTotal
            // 
            this.labelPrecioTotal.AutoSize = true;
            this.labelPrecioTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecioTotal.Location = new System.Drawing.Point(750, 382);
            this.labelPrecioTotal.Name = "labelPrecioTotal";
            this.labelPrecioTotal.Size = new System.Drawing.Size(29, 31);
            this.labelPrecioTotal.TabIndex = 2;
            this.labelPrecioTotal.Text = "0";
            this.labelPrecioTotal.Visible = false;
            // 
            // btnCargar
            // 
            this.btnCargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.Location = new System.Drawing.Point(930, 397);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(86, 41);
            this.btnCargar.TabIndex = 3;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(445, 426);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.labelPrecioTotal);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.dgvCesta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCesta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCesta;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Label labelPrecioTotal;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

