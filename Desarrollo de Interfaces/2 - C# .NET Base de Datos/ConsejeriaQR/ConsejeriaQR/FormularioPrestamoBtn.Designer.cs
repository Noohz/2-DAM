namespace ConsejeriaQR
{
    partial class FormularioPrestamoBtn
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxImgArticulo = new System.Windows.Forms.PictureBox();
            this.lblInfoArticulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxImagenQR = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.textBoxCodigoQR = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImgArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagenQR)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(1, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 10);
            this.panel1.TabIndex = 8;
            // 
            // pictureBoxImgArticulo
            // 
            this.pictureBoxImgArticulo.BackColor = System.Drawing.Color.White;
            this.pictureBoxImgArticulo.Location = new System.Drawing.Point(208, 38);
            this.pictureBoxImgArticulo.Name = "pictureBoxImgArticulo";
            this.pictureBoxImgArticulo.Size = new System.Drawing.Size(122, 90);
            this.pictureBoxImgArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImgArticulo.TabIndex = 7;
            this.pictureBoxImgArticulo.TabStop = false;
            // 
            // lblInfoArticulo
            // 
            this.lblInfoArticulo.AutoSize = true;
            this.lblInfoArticulo.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblInfoArticulo.Location = new System.Drawing.Point(111, 143);
            this.lblInfoArticulo.Name = "lblInfoArticulo";
            this.lblInfoArticulo.Size = new System.Drawing.Size(315, 24);
            this.lblInfoArticulo.TabIndex = 6;
            this.lblInfoArticulo.Text = "*Nombre del articulo + codigo*";
            this.lblInfoArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(9, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(532, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Escanea el código QR para prestar el artículo actual";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxImagenQR
            // 
            this.pictureBoxImagenQR.Location = new System.Drawing.Point(145, 234);
            this.pictureBoxImagenQR.Name = "pictureBoxImagenQR";
            this.pictureBoxImagenQR.Size = new System.Drawing.Size(250, 178);
            this.pictureBoxImagenQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImagenQR.TabIndex = 10;
            this.pictureBoxImagenQR.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(115, 483);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(311, 30);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // textBoxCodigoQR
            // 
            this.textBoxCodigoQR.Location = new System.Drawing.Point(176, 427);
            this.textBoxCodigoQR.Name = "textBoxCodigoQR";
            this.textBoxCodigoQR.Size = new System.Drawing.Size(188, 20);
            this.textBoxCodigoQR.TabIndex = 16;
            this.textBoxCodigoQR.TextChanged += new System.EventHandler(this.TextBoxCodigoQR_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // FormularioPrestamoBtn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(103)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(547, 533);
            this.Controls.Add(this.textBoxCodigoQR);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pictureBoxImagenQR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxImgArticulo);
            this.Controls.Add(this.lblInfoArticulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormularioPrestamoBtn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormularioPrestamoBtn";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImgArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagenQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxImgArticulo;
        private System.Windows.Forms.Label lblInfoArticulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxImagenQR;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox textBoxCodigoQR;
        private System.Windows.Forms.Timer timer1;
    }
}