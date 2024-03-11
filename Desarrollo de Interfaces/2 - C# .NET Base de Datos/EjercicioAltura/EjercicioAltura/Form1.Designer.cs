namespace EjercicioAltura
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnIntroducirDatos = new System.Windows.Forms.Button();
            this.textBoxProvincia = new System.Windows.Forms.TextBox();
            this.textBoxSituacionAltMax = new System.Windows.Forms.TextBox();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.lblSituacionAltMax = new System.Windows.Forms.Label();
            this.textBoxAlturaMaxima = new System.Windows.Forms.TextBox();
            this.lblAlturaMaxima = new System.Windows.Forms.Label();
            this.textBoxSituacionAltMin = new System.Windows.Forms.TextBox();
            this.lblSituacionAltMin = new System.Windows.Forms.Label();
            this.textBoxAlturaMinima = new System.Windows.Forms.TextBox();
            this.lblAlturaMinima = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 148);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(775, 290);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnIntroducirDatos
            // 
            this.btnIntroducirDatos.Location = new System.Drawing.Point(54, 91);
            this.btnIntroducirDatos.Name = "btnIntroducirDatos";
            this.btnIntroducirDatos.Size = new System.Drawing.Size(689, 41);
            this.btnIntroducirDatos.TabIndex = 1;
            this.btnIntroducirDatos.Text = "Introducir Datos";
            this.btnIntroducirDatos.UseVisualStyleBackColor = true;
            this.btnIntroducirDatos.Click += new System.EventHandler(this.btnIntroducirDatos_Click);
            // 
            // textBoxProvincia
            // 
            this.textBoxProvincia.Location = new System.Drawing.Point(54, 54);
            this.textBoxProvincia.Name = "textBoxProvincia";
            this.textBoxProvincia.Size = new System.Drawing.Size(133, 20);
            this.textBoxProvincia.TabIndex = 2;
            // 
            // textBoxSituacionAltMax
            // 
            this.textBoxSituacionAltMax.Location = new System.Drawing.Point(193, 54);
            this.textBoxSituacionAltMax.Name = "textBoxSituacionAltMax";
            this.textBoxSituacionAltMax.Size = new System.Drawing.Size(133, 20);
            this.textBoxSituacionAltMax.TabIndex = 3;
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProvincia.Location = new System.Drawing.Point(89, 35);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(63, 16);
            this.lblProvincia.TabIndex = 4;
            this.lblProvincia.Text = "Provincia";
            // 
            // lblSituacionAltMax
            // 
            this.lblSituacionAltMax.AutoSize = true;
            this.lblSituacionAltMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSituacionAltMax.Location = new System.Drawing.Point(210, 35);
            this.lblSituacionAltMax.Name = "lblSituacionAltMax";
            this.lblSituacionAltMax.Size = new System.Drawing.Size(102, 16);
            this.lblSituacionAltMax.TabIndex = 5;
            this.lblSituacionAltMax.Text = "SituacionAltMax";
            // 
            // textBoxAlturaMaxima
            // 
            this.textBoxAlturaMaxima.Location = new System.Drawing.Point(332, 54);
            this.textBoxAlturaMaxima.Name = "textBoxAlturaMaxima";
            this.textBoxAlturaMaxima.Size = new System.Drawing.Size(133, 20);
            this.textBoxAlturaMaxima.TabIndex = 6;
            // 
            // lblAlturaMaxima
            // 
            this.lblAlturaMaxima.AutoSize = true;
            this.lblAlturaMaxima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlturaMaxima.Location = new System.Drawing.Point(356, 35);
            this.lblAlturaMaxima.Name = "lblAlturaMaxima";
            this.lblAlturaMaxima.Size = new System.Drawing.Size(88, 16);
            this.lblAlturaMaxima.TabIndex = 7;
            this.lblAlturaMaxima.Text = "AlturaMaxima";
            // 
            // textBoxSituacionAltMin
            // 
            this.textBoxSituacionAltMin.Location = new System.Drawing.Point(471, 54);
            this.textBoxSituacionAltMin.Name = "textBoxSituacionAltMin";
            this.textBoxSituacionAltMin.Size = new System.Drawing.Size(133, 20);
            this.textBoxSituacionAltMin.TabIndex = 8;
            // 
            // lblSituacionAltMin
            // 
            this.lblSituacionAltMin.AutoSize = true;
            this.lblSituacionAltMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSituacionAltMin.Location = new System.Drawing.Point(492, 35);
            this.lblSituacionAltMin.Name = "lblSituacionAltMin";
            this.lblSituacionAltMin.Size = new System.Drawing.Size(98, 16);
            this.lblSituacionAltMin.TabIndex = 9;
            this.lblSituacionAltMin.Text = "SituacionAltMin";
            // 
            // textBoxAlturaMinima
            // 
            this.textBoxAlturaMinima.Location = new System.Drawing.Point(610, 54);
            this.textBoxAlturaMinima.Name = "textBoxAlturaMinima";
            this.textBoxAlturaMinima.Size = new System.Drawing.Size(133, 20);
            this.textBoxAlturaMinima.TabIndex = 10;
            // 
            // lblAlturaMinima
            // 
            this.lblAlturaMinima.AutoSize = true;
            this.lblAlturaMinima.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlturaMinima.Location = new System.Drawing.Point(629, 35);
            this.lblAlturaMinima.Name = "lblAlturaMinima";
            this.lblAlturaMinima.Size = new System.Drawing.Size(84, 16);
            this.lblAlturaMinima.TabIndex = 11;
            this.lblAlturaMinima.Text = "AlturaMinima";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblAlturaMinima);
            this.Controls.Add(this.textBoxAlturaMinima);
            this.Controls.Add(this.lblSituacionAltMin);
            this.Controls.Add(this.textBoxSituacionAltMin);
            this.Controls.Add(this.lblAlturaMaxima);
            this.Controls.Add(this.textBoxAlturaMaxima);
            this.Controls.Add(this.lblSituacionAltMax);
            this.Controls.Add(this.lblProvincia);
            this.Controls.Add(this.textBoxSituacionAltMax);
            this.Controls.Add(this.textBoxProvincia);
            this.Controls.Add(this.btnIntroducirDatos);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnIntroducirDatos;
        private System.Windows.Forms.TextBox textBoxProvincia;
        private System.Windows.Forms.TextBox textBoxSituacionAltMax;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.Label lblSituacionAltMax;
        private System.Windows.Forms.TextBox textBoxAlturaMaxima;
        private System.Windows.Forms.Label lblAlturaMaxima;
        private System.Windows.Forms.TextBox textBoxSituacionAltMin;
        private System.Windows.Forms.Label lblSituacionAltMin;
        private System.Windows.Forms.TextBox textBoxAlturaMinima;
        private System.Windows.Forms.Label lblAlturaMinima;
    }
}

