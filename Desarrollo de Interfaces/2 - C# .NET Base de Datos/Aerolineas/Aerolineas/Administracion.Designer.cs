namespace Aerolineas
{
    partial class Administracion
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
            this.btnCrearModeloAvion = new System.Windows.Forms.Button();
            this.lblTIdAvion = new System.Windows.Forms.Label();
            this.tBIdAvion = new System.Windows.Forms.TextBox();
            this.lblTModelo = new System.Windows.Forms.Label();
            this.tBModelo = new System.Windows.Forms.TextBox();
            this.lblTFBussines = new System.Windows.Forms.Label();
            this.lblTFPrimera = new System.Windows.Forms.Label();
            this.lblTFTuristas = new System.Windows.Forms.Label();
            this.gBTexto = new System.Windows.Forms.GroupBox();
            this.numericUpDownTuristas = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPrimera = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBussines = new System.Windows.Forms.NumericUpDown();
            this.btnAñadirModeloAvion = new System.Windows.Forms.Button();
            this.gBTexto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTuristas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrimera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBussines)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCrearModeloAvion
            // 
            this.btnCrearModeloAvion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearModeloAvion.Location = new System.Drawing.Point(12, 34);
            this.btnCrearModeloAvion.Name = "btnCrearModeloAvion";
            this.btnCrearModeloAvion.Size = new System.Drawing.Size(226, 36);
            this.btnCrearModeloAvion.TabIndex = 6;
            this.btnCrearModeloAvion.Text = "Crear modelo avión";
            this.btnCrearModeloAvion.UseVisualStyleBackColor = true;
            this.btnCrearModeloAvion.Click += new System.EventHandler(this.btnCrearModeloAvion_Click);
            // 
            // lblTIdAvion
            // 
            this.lblTIdAvion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIdAvion.Location = new System.Drawing.Point(64, 16);
            this.lblTIdAvion.Name = "lblTIdAvion";
            this.lblTIdAvion.Size = new System.Drawing.Size(160, 35);
            this.lblTIdAvion.TabIndex = 7;
            this.lblTIdAvion.Text = "IdAvion";
            this.lblTIdAvion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBIdAvion
            // 
            this.tBIdAvion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBIdAvion.Location = new System.Drawing.Point(14, 54);
            this.tBIdAvion.Name = "tBIdAvion";
            this.tBIdAvion.Size = new System.Drawing.Size(254, 38);
            this.tBIdAvion.TabIndex = 8;
            // 
            // lblTModelo
            // 
            this.lblTModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTModelo.Location = new System.Drawing.Point(332, 16);
            this.lblTModelo.Name = "lblTModelo";
            this.lblTModelo.Size = new System.Drawing.Size(160, 35);
            this.lblTModelo.TabIndex = 9;
            this.lblTModelo.Text = "Modelo";
            this.lblTModelo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBModelo
            // 
            this.tBModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBModelo.Location = new System.Drawing.Point(282, 54);
            this.tBModelo.Name = "tBModelo";
            this.tBModelo.Size = new System.Drawing.Size(254, 38);
            this.tBModelo.TabIndex = 10;
            // 
            // lblTFBussines
            // 
            this.lblTFBussines.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTFBussines.Location = new System.Drawing.Point(14, 115);
            this.lblTFBussines.Name = "lblTFBussines";
            this.lblTFBussines.Size = new System.Drawing.Size(254, 35);
            this.lblTFBussines.TabIndex = 11;
            this.lblTFBussines.Text = "Nº Asientos bussines";
            this.lblTFBussines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTFPrimera
            // 
            this.lblTFPrimera.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTFPrimera.Location = new System.Drawing.Point(282, 115);
            this.lblTFPrimera.Name = "lblTFPrimera";
            this.lblTFPrimera.Size = new System.Drawing.Size(254, 35);
            this.lblTFPrimera.TabIndex = 13;
            this.lblTFPrimera.Text = "Nº Asientos primera";
            this.lblTFPrimera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTFTuristas
            // 
            this.lblTFTuristas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTFTuristas.Location = new System.Drawing.Point(147, 205);
            this.lblTFTuristas.Name = "lblTFTuristas";
            this.lblTFTuristas.Size = new System.Drawing.Size(254, 35);
            this.lblTFTuristas.TabIndex = 15;
            this.lblTFTuristas.Text = "Nº Asientos turistas";
            this.lblTFTuristas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gBTexto
            // 
            this.gBTexto.Controls.Add(this.numericUpDownTuristas);
            this.gBTexto.Controls.Add(this.numericUpDownPrimera);
            this.gBTexto.Controls.Add(this.numericUpDownBussines);
            this.gBTexto.Controls.Add(this.btnAñadirModeloAvion);
            this.gBTexto.Controls.Add(this.lblTModelo);
            this.gBTexto.Controls.Add(this.tBModelo);
            this.gBTexto.Controls.Add(this.lblTFTuristas);
            this.gBTexto.Controls.Add(this.lblTIdAvion);
            this.gBTexto.Controls.Add(this.tBIdAvion);
            this.gBTexto.Controls.Add(this.lblTFPrimera);
            this.gBTexto.Controls.Add(this.lblTFBussines);
            this.gBTexto.Location = new System.Drawing.Point(267, 34);
            this.gBTexto.Name = "gBTexto";
            this.gBTexto.Size = new System.Drawing.Size(547, 374);
            this.gBTexto.TabIndex = 17;
            this.gBTexto.TabStop = false;
            this.gBTexto.Visible = false;
            // 
            // numericUpDownTuristas
            // 
            this.numericUpDownTuristas.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownTuristas.Location = new System.Drawing.Point(147, 243);
            this.numericUpDownTuristas.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDownTuristas.Name = "numericUpDownTuristas";
            this.numericUpDownTuristas.Size = new System.Drawing.Size(254, 38);
            this.numericUpDownTuristas.TabIndex = 21;
            // 
            // numericUpDownPrimera
            // 
            this.numericUpDownPrimera.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPrimera.Location = new System.Drawing.Point(282, 153);
            this.numericUpDownPrimera.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDownPrimera.Name = "numericUpDownPrimera";
            this.numericUpDownPrimera.Size = new System.Drawing.Size(254, 38);
            this.numericUpDownPrimera.TabIndex = 20;
            // 
            // numericUpDownBussines
            // 
            this.numericUpDownBussines.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownBussines.Location = new System.Drawing.Point(14, 153);
            this.numericUpDownBussines.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDownBussines.Name = "numericUpDownBussines";
            this.numericUpDownBussines.Size = new System.Drawing.Size(254, 38);
            this.numericUpDownBussines.TabIndex = 19;
            // 
            // btnAñadirModeloAvion
            // 
            this.btnAñadirModeloAvion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadirModeloAvion.Location = new System.Drawing.Point(162, 318);
            this.btnAñadirModeloAvion.Name = "btnAñadirModeloAvion";
            this.btnAñadirModeloAvion.Size = new System.Drawing.Size(226, 36);
            this.btnAñadirModeloAvion.TabIndex = 18;
            this.btnAñadirModeloAvion.Text = "Crear";
            this.btnAñadirModeloAvion.UseVisualStyleBackColor = true;
            this.btnAñadirModeloAvion.Click += new System.EventHandler(this.btnAñadirModeloAvion_Click);
            // 
            // Administracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.ClientSize = new System.Drawing.Size(826, 450);
            this.Controls.Add(this.gBTexto);
            this.Controls.Add(this.btnCrearModeloAvion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Administracion";
            this.Text = " ";
            this.gBTexto.ResumeLayout(false);
            this.gBTexto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTuristas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrimera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBussines)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCrearModeloAvion;
        private System.Windows.Forms.Label lblTIdAvion;
        private System.Windows.Forms.TextBox tBIdAvion;
        private System.Windows.Forms.Label lblTModelo;
        private System.Windows.Forms.TextBox tBModelo;
        private System.Windows.Forms.Label lblTFBussines;
        private System.Windows.Forms.Label lblTFPrimera;
        private System.Windows.Forms.Label lblTFTuristas;
        private System.Windows.Forms.GroupBox gBTexto;
        private System.Windows.Forms.Button btnAñadirModeloAvion;
        private System.Windows.Forms.NumericUpDown numericUpDownTuristas;
        private System.Windows.Forms.NumericUpDown numericUpDownPrimera;
        private System.Windows.Forms.NumericUpDown numericUpDownBussines;
    }
}