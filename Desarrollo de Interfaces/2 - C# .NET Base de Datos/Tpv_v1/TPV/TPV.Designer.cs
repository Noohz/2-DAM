
namespace TPV
{
    partial class TPV
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
            this.flpFrutas = new System.Windows.Forms.FlowLayoutPanel();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.btnPagar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnEmpezar = new System.Windows.Forms.Button();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdministrar = new System.Windows.Forms.Button();
            this.labelEuro = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.pbAviso = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblExistencias = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBusca = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.pictureBoxInfo = new System.Windows.Forms.PictureBox();
            this.labelBarCodeCliente = new System.Windows.Forms.Label();
            this.textBoxBarCodeCliente = new System.Windows.Forms.TextBox();
            this.labelBarCodeFruta = new System.Windows.Forms.Label();
            this.textBoxBarCodeFruta = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAviso)).BeginInit();
            this.gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // flpFrutas
            // 
            this.flpFrutas.AutoScroll = true;
            this.flpFrutas.Location = new System.Drawing.Point(27, 41);
            this.flpFrutas.Name = "flpFrutas";
            this.flpFrutas.Size = new System.Drawing.Size(469, 419);
            this.flpFrutas.TabIndex = 0;
            this.flpFrutas.Visible = false;
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv1.Location = new System.Drawing.Point(545, 41);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersWidth = 51;
            this.dgv1.Size = new System.Drawing.Size(384, 150);
            this.dgv1.TabIndex = 2;
            this.dgv1.Visible = false;
            this.dgv1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellDoubleClick);
            // 
            // btnPagar
            // 
            this.btnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.Location = new System.Drawing.Point(821, 284);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(108, 54);
            this.btnPagar.TabIndex = 3;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Visible = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(816, 234);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(66, 31);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "total";
            this.lblTotal.Visible = false;
            // 
            // btnEmpezar
            // 
            this.btnEmpezar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpezar.Location = new System.Drawing.Point(405, 210);
            this.btnEmpezar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEmpezar.Name = "btnEmpezar";
            this.btnEmpezar.Size = new System.Drawing.Size(209, 80);
            this.btnEmpezar.TabIndex = 5;
            this.btnEmpezar.Text = "TPV ";
            this.btnEmpezar.UseVisualStyleBackColor = true;
            this.btnEmpezar.Click += new System.EventHandler(this.btnEmpezar_Click);
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(545, 246);
            this.txtMail.Margin = new System.Windows.Forms.Padding(2);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(242, 20);
            this.txtMail.TabIndex = 6;
            this.txtMail.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(545, 228);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Introduce mail del cliente";
            this.label1.Visible = false;
            // 
            // btnAdministrar
            // 
            this.btnAdministrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministrar.Location = new System.Drawing.Point(813, 436);
            this.btnAdministrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdministrar.Name = "btnAdministrar";
            this.btnAdministrar.Size = new System.Drawing.Size(108, 24);
            this.btnAdministrar.TabIndex = 8;
            this.btnAdministrar.Text = "Administración";
            this.btnAdministrar.UseVisualStyleBackColor = true;
            this.btnAdministrar.Visible = false;
            this.btnAdministrar.Click += new System.EventHandler(this.btnAdministrar_Click);
            // 
            // labelEuro
            // 
            this.labelEuro.AutoSize = true;
            this.labelEuro.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEuro.Location = new System.Drawing.Point(902, 234);
            this.labelEuro.Name = "labelEuro";
            this.labelEuro.Size = new System.Drawing.Size(29, 31);
            this.labelEuro.TabIndex = 9;
            this.labelEuro.Text = "€";
            this.labelEuro.Visible = false;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(818, 216);
            this.labelTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(44, 17);
            this.labelTotal.TabIndex = 10;
            this.labelTotal.Text = "Total:";
            this.labelTotal.Visible = false;
            // 
            // pbAviso
            // 
            this.pbAviso.Image = global::TPV.Properties.Resources.exclamacion;
            this.pbAviso.Location = new System.Drawing.Point(916, 436);
            this.pbAviso.Margin = new System.Windows.Forms.Padding(2);
            this.pbAviso.Name = "pbAviso";
            this.pbAviso.Size = new System.Drawing.Size(22, 24);
            this.pbAviso.TabIndex = 11;
            this.pbAviso.TabStop = false;
            this.pbAviso.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(4, 58);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 17);
            this.label11.TabIndex = 12;
            this.label11.Text = "Precio: ";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(4, 26);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 17);
            this.lblNombre.TabIndex = 13;
            this.lblNombre.Text = "Nombre";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(4, 84);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 17);
            this.label12.TabIndex = 14;
            this.label12.Text = "Existencias: ";
            // 
            // lblExistencias
            // 
            this.lblExistencias.AutoSize = true;
            this.lblExistencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExistencias.Location = new System.Drawing.Point(88, 84);
            this.lblExistencias.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExistencias.Name = "lblExistencias";
            this.lblExistencias.Size = new System.Drawing.Size(40, 17);
            this.lblExistencias.TabIndex = 15;
            this.lblExistencias.Text = "3000";
            this.lblExistencias.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(60, 58);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(36, 17);
            this.lblPrecio.TabIndex = 16;
            this.lblPrecio.Text = "2,35";
            this.lblPrecio.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gbInfo
            // 
            this.gbInfo.BackColor = System.Drawing.Color.Khaki;
            this.gbInfo.Controls.Add(this.label5);
            this.gbInfo.Controls.Add(this.label4);
            this.gbInfo.Controls.Add(this.label11);
            this.gbInfo.Controls.Add(this.lblPrecio);
            this.gbInfo.Controls.Add(this.lblNombre);
            this.gbInfo.Controls.Add(this.lblExistencias);
            this.gbInfo.Controls.Add(this.label12);
            this.gbInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbInfo.Location = new System.Drawing.Point(501, 349);
            this.gbInfo.Margin = new System.Windows.Forms.Padding(2);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Padding = new System.Windows.Forms.Padding(2);
            this.gbInfo.Size = new System.Drawing.Size(170, 111);
            this.gbInfo.TabIndex = 17;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Info";
            this.gbInfo.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(120, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Kg";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(93, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "€/Kg";
            // 
            // lblBusca
            // 
            this.lblBusca.AutoSize = true;
            this.lblBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusca.Location = new System.Drawing.Point(542, 305);
            this.lblBusca.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBusca.Name = "lblBusca";
            this.lblBusca.Size = new System.Drawing.Size(85, 17);
            this.lblBusca.TabIndex = 19;
            this.lblBusca.Text = "Buscar fruta";
            this.lblBusca.Visible = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(545, 323);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(242, 20);
            this.txtBuscar.TabIndex = 18;
            this.txtBuscar.Visible = false;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // pictureBoxInfo
            // 
            this.pictureBoxInfo.Location = new System.Drawing.Point(676, 358);
            this.pictureBoxInfo.Name = "pictureBoxInfo";
            this.pictureBoxInfo.Size = new System.Drawing.Size(79, 92);
            this.pictureBoxInfo.TabIndex = 20;
            this.pictureBoxInfo.TabStop = false;
            // 
            // labelBarCodeCliente
            // 
            this.labelBarCodeCliente.AutoSize = true;
            this.labelBarCodeCliente.Location = new System.Drawing.Point(530, 13);
            this.labelBarCodeCliente.Name = "labelBarCodeCliente";
            this.labelBarCodeCliente.Size = new System.Drawing.Size(83, 13);
            this.labelBarCodeCliente.TabIndex = 21;
            this.labelBarCodeCliente.Text = "BarCode Cliente";
            this.labelBarCodeCliente.Visible = false;
            // 
            // textBoxBarCodeCliente
            // 
            this.textBoxBarCodeCliente.Location = new System.Drawing.Point(619, 10);
            this.textBoxBarCodeCliente.Name = "textBoxBarCodeCliente";
            this.textBoxBarCodeCliente.Size = new System.Drawing.Size(100, 20);
            this.textBoxBarCodeCliente.TabIndex = 22;
            this.textBoxBarCodeCliente.Visible = false;
            this.textBoxBarCodeCliente.TextChanged += new System.EventHandler(this.textBoxBarCodeCliente_TextChanged);
            // 
            // labelBarCodeFruta
            // 
            this.labelBarCodeFruta.AutoSize = true;
            this.labelBarCodeFruta.Location = new System.Drawing.Point(749, 13);
            this.labelBarCodeFruta.Name = "labelBarCodeFruta";
            this.labelBarCodeFruta.Size = new System.Drawing.Size(75, 13);
            this.labelBarCodeFruta.TabIndex = 23;
            this.labelBarCodeFruta.Text = "BarCode Fruta";
            this.labelBarCodeFruta.Visible = false;
            // 
            // textBoxBarCodeFruta
            // 
            this.textBoxBarCodeFruta.Location = new System.Drawing.Point(838, 10);
            this.textBoxBarCodeFruta.Name = "textBoxBarCodeFruta";
            this.textBoxBarCodeFruta.Size = new System.Drawing.Size(100, 20);
            this.textBoxBarCodeFruta.TabIndex = 24;
            this.textBoxBarCodeFruta.Visible = false;
            this.textBoxBarCodeFruta.TextChanged += new System.EventHandler(this.textBoxBarCodeFruta_TextChanged);
            // 
            // TPV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(958, 477);
            this.Controls.Add(this.textBoxBarCodeFruta);
            this.Controls.Add(this.labelBarCodeFruta);
            this.Controls.Add(this.textBoxBarCodeCliente);
            this.Controls.Add(this.labelBarCodeCliente);
            this.Controls.Add(this.pictureBoxInfo);
            this.Controls.Add(this.lblBusca);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.pbAviso);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelEuro);
            this.Controls.Add(this.btnAdministrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.btnEmpezar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.flpFrutas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TPV";
            this.Text = "TPV";
            this.Load += new System.EventHandler(this.TPV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAviso)).EndInit();
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpFrutas;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnEmpezar;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdministrar;
        private System.Windows.Forms.Label labelEuro;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.PictureBox pbAviso;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblExistencias;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBusca;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.PictureBox pictureBoxInfo;
        private System.Windows.Forms.Label labelBarCodeCliente;
        private System.Windows.Forms.TextBox textBoxBarCodeCliente;
        private System.Windows.Forms.Label labelBarCodeFruta;
        private System.Windows.Forms.TextBox textBoxBarCodeFruta;
    }
}

