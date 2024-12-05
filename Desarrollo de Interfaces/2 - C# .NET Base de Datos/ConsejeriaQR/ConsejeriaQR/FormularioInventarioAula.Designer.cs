namespace ConsejeriaQR
{
    partial class FormularioInventarioAula
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
            this.panelInventarioAula = new System.Windows.Forms.Panel();
            this.dGVInventarioAula = new System.Windows.Forms.DataGridView();
            this.comboEstado = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tBCaracteristicas = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tBModelo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericCantidad = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.comboTipoArticulo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tBAula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnModificarDatos = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelInventarioAula.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVInventarioAula)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInventarioAula
            // 
            this.panelInventarioAula.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInventarioAula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(103)))), ((int)(((byte)(73)))));
            this.panelInventarioAula.Controls.Add(this.button1);
            this.panelInventarioAula.Controls.Add(this.btnModificarDatos);
            this.panelInventarioAula.Controls.Add(this.comboEstado);
            this.panelInventarioAula.Controls.Add(this.label6);
            this.panelInventarioAula.Controls.Add(this.tBCaracteristicas);
            this.panelInventarioAula.Controls.Add(this.label5);
            this.panelInventarioAula.Controls.Add(this.tBModelo);
            this.panelInventarioAula.Controls.Add(this.label4);
            this.panelInventarioAula.Controls.Add(this.numericCantidad);
            this.panelInventarioAula.Controls.Add(this.label3);
            this.panelInventarioAula.Controls.Add(this.comboTipoArticulo);
            this.panelInventarioAula.Controls.Add(this.label2);
            this.panelInventarioAula.Controls.Add(this.tBAula);
            this.panelInventarioAula.Controls.Add(this.label1);
            this.panelInventarioAula.Controls.Add(this.dGVInventarioAula);
            this.panelInventarioAula.Location = new System.Drawing.Point(13, 12);
            this.panelInventarioAula.Name = "panelInventarioAula";
            this.panelInventarioAula.Size = new System.Drawing.Size(884, 605);
            this.panelInventarioAula.TabIndex = 0;
            // 
            // dGVInventarioAula
            // 
            this.dGVInventarioAula.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVInventarioAula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dGVInventarioAula.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dGVInventarioAula.Location = new System.Drawing.Point(3, 315);
            this.dGVInventarioAula.Name = "dGVInventarioAula";
            this.dGVInventarioAula.Size = new System.Drawing.Size(877, 287);
            this.dGVInventarioAula.TabIndex = 0;
            this.dGVInventarioAula.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVInventarioAula_CellClick);
            // 
            // comboEstado
            // 
            this.comboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEstado.FormattingEnabled = true;
            this.comboEstado.Items.AddRange(new object[] {
            "Nuevo",
            "En buen estado",
            "Mantenimiento"});
            this.comboEstado.Location = new System.Drawing.Point(540, 102);
            this.comboEstado.Name = "comboEstado";
            this.comboEstado.Size = new System.Drawing.Size(284, 21);
            this.comboEstado.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(68, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(290, 40);
            this.label6.TabIndex = 39;
            this.label6.Text = "Características ( Color del artículo, \r\ntemaño, especificaciónes... )\r\n";
            // 
            // tBCaracteristicas
            // 
            this.tBCaracteristicas.Location = new System.Drawing.Point(372, 163);
            this.tBCaracteristicas.Multiline = true;
            this.tBCaracteristicas.Name = "tBCaracteristicas";
            this.tBCaracteristicas.Size = new System.Drawing.Size(452, 70);
            this.tBCaracteristicas.TabIndex = 38;
            this.tBCaracteristicas.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(462, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 37;
            this.label5.Text = "Estado";
            // 
            // tBModelo
            // 
            this.tBModelo.Location = new System.Drawing.Point(139, 104);
            this.tBModelo.Name = "tBModelo";
            this.tBModelo.Size = new System.Drawing.Size(274, 20);
            this.tBModelo.TabIndex = 36;
            this.tBModelo.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Modelo";
            // 
            // numericCantidad
            // 
            this.numericCantidad.Location = new System.Drawing.Point(739, 24);
            this.numericCantidad.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericCantidad.Name = "numericCantidad";
            this.numericCantidad.Size = new System.Drawing.Size(85, 20);
            this.numericCantidad.TabIndex = 32;
            this.numericCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(649, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Cantidad";
            // 
            // comboTipoArticulo
            // 
            this.comboTipoArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoArticulo.FormattingEnabled = true;
            this.comboTipoArticulo.Items.AddRange(new object[] {
            "Mesa",
            "Silla",
            "Ordenador",
            "Proyector",
            "Panel Digital",
            "Armario de Portátiles",
            "Estantería",
            "Armario con Cerradura"});
            this.comboTipoArticulo.Location = new System.Drawing.Point(415, 24);
            this.comboTipoArticulo.Name = "comboTipoArticulo";
            this.comboTipoArticulo.Size = new System.Drawing.Size(212, 21);
            this.comboTipoArticulo.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(269, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "Tipo de artículo";
            // 
            // tBAula
            // 
            this.tBAula.Enabled = false;
            this.tBAula.Location = new System.Drawing.Point(129, 24);
            this.tBAula.Name = "tBAula";
            this.tBAula.Size = new System.Drawing.Size(116, 20);
            this.tBAula.TabIndex = 29;
            this.tBAula.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Aula";
            // 
            // btnModificarDatos
            // 
            this.btnModificarDatos.AutoSize = true;
            this.btnModificarDatos.BackColor = System.Drawing.SystemColors.Control;
            this.btnModificarDatos.Enabled = false;
            this.btnModificarDatos.FlatAppearance.BorderSize = 0;
            this.btnModificarDatos.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnModificarDatos.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnModificarDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarDatos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarDatos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnModificarDatos.Location = new System.Drawing.Point(129, 268);
            this.btnModificarDatos.Name = "btnModificarDatos";
            this.btnModificarDatos.Size = new System.Drawing.Size(276, 29);
            this.btnModificarDatos.TabIndex = 41;
            this.btnModificarDatos.Text = "Modificar artículo";
            this.btnModificarDatos.UseVisualStyleBackColor = false;
            this.btnModificarDatos.Click += new System.EventHandler(this.btnModificarDatos_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.Firebrick;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(427, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(276, 29);
            this.button1.TabIndex = 42;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormularioInventarioAula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(113)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(909, 629);
            this.Controls.Add(this.panelInventarioAula);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormularioInventarioAula";
            this.Text = "FormularioInventarioAula";
            this.panelInventarioAula.ResumeLayout(false);
            this.panelInventarioAula.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVInventarioAula)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelInventarioAula;
        private System.Windows.Forms.DataGridView dGVInventarioAula;
        private System.Windows.Forms.ComboBox comboEstado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBCaracteristicas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tBModelo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboTipoArticulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBAula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnModificarDatos;
        private System.Windows.Forms.Button button1;
    }
}