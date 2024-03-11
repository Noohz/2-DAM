namespace GestorSQL
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
            this.buttonServidor = new System.Windows.Forms.Button();
            this.buttonBD = new System.Windows.Forms.Button();
            this.buttonUSR = new System.Windows.Forms.Button();
            this.buttonPWD = new System.Windows.Forms.Button();
            this.buttonConsultaSQL = new System.Windows.Forms.Button();
            this.buttonSalir = new System.Windows.Forms.Button();
            this.textBoxServidor = new System.Windows.Forms.TextBox();
            this.textBoxBD = new System.Windows.Forms.TextBox();
            this.textBoxUSR = new System.Windows.Forms.TextBox();
            this.textBoxPWD = new System.Windows.Forms.TextBox();
            this.buttonComprobarConexion = new System.Windows.Forms.Button();
            this.textBoxConsultaSql = new System.Windows.Forms.TextBox();
            this.labelConsultaSQL = new System.Windows.Forms.Label();
            this.groupBoxDatosDB = new System.Windows.Forms.GroupBox();
            this.listViewNombreCampos = new System.Windows.Forms.ListView();
            this.listViewTablas = new System.Windows.Forms.ListView();
            this.listViewDB = new System.Windows.Forms.ListView();
            this.buttonEjecutar = new System.Windows.Forms.Button();
            this.labelBD = new System.Windows.Forms.Label();
            this.labelNombreCampos = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonMostrarTodasBD = new System.Windows.Forms.Button();
            this.buttonVerUnaBD = new System.Windows.Forms.Button();
            this.listView3 = new System.Windows.Forms.ListView();
            this.buttonExportarBD = new System.Windows.Forms.Button();
            this.buttonImportarBD = new System.Windows.Forms.Button();
            this.labelTablas = new System.Windows.Forms.Label();
            this.groupBoxDatosDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonServidor
            // 
            this.buttonServidor.Location = new System.Drawing.Point(12, 12);
            this.buttonServidor.Name = "buttonServidor";
            this.buttonServidor.Size = new System.Drawing.Size(105, 101);
            this.buttonServidor.TabIndex = 0;
            this.buttonServidor.Text = "Servidor";
            this.buttonServidor.UseVisualStyleBackColor = true;
            this.buttonServidor.Click += new System.EventHandler(this.buttonServidor_Click);
            // 
            // buttonBD
            // 
            this.buttonBD.Location = new System.Drawing.Point(146, 12);
            this.buttonBD.Name = "buttonBD";
            this.buttonBD.Size = new System.Drawing.Size(105, 101);
            this.buttonBD.TabIndex = 1;
            this.buttonBD.Text = "Base de Datos";
            this.buttonBD.UseVisualStyleBackColor = true;
            this.buttonBD.Click += new System.EventHandler(this.buttonBD_Click);
            // 
            // buttonUSR
            // 
            this.buttonUSR.Location = new System.Drawing.Point(276, 12);
            this.buttonUSR.Name = "buttonUSR";
            this.buttonUSR.Size = new System.Drawing.Size(105, 101);
            this.buttonUSR.TabIndex = 2;
            this.buttonUSR.Text = "Usuario";
            this.buttonUSR.UseVisualStyleBackColor = true;
            this.buttonUSR.Click += new System.EventHandler(this.buttonUSR_Click);
            // 
            // buttonPWD
            // 
            this.buttonPWD.Location = new System.Drawing.Point(406, 12);
            this.buttonPWD.Name = "buttonPWD";
            this.buttonPWD.Size = new System.Drawing.Size(105, 101);
            this.buttonPWD.TabIndex = 3;
            this.buttonPWD.Text = "Contraseña";
            this.buttonPWD.UseVisualStyleBackColor = true;
            this.buttonPWD.Click += new System.EventHandler(this.buttonPWD_Click);
            // 
            // buttonConsultaSQL
            // 
            this.buttonConsultaSQL.Enabled = false;
            this.buttonConsultaSQL.Location = new System.Drawing.Point(538, 12);
            this.buttonConsultaSQL.Name = "buttonConsultaSQL";
            this.buttonConsultaSQL.Size = new System.Drawing.Size(105, 101);
            this.buttonConsultaSQL.TabIndex = 4;
            this.buttonConsultaSQL.Text = "Consulta SQL";
            this.buttonConsultaSQL.UseVisualStyleBackColor = true;
            this.buttonConsultaSQL.Click += new System.EventHandler(this.buttonConsultaSQL_Click);
            // 
            // buttonSalir
            // 
            this.buttonSalir.Location = new System.Drawing.Point(671, 12);
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(105, 101);
            this.buttonSalir.TabIndex = 5;
            this.buttonSalir.Text = "Salir";
            this.buttonSalir.UseVisualStyleBackColor = true;
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // textBoxServidor
            // 
            this.textBoxServidor.Enabled = false;
            this.textBoxServidor.Location = new System.Drawing.Point(13, 119);
            this.textBoxServidor.Name = "textBoxServidor";
            this.textBoxServidor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxServidor.Size = new System.Drawing.Size(104, 20);
            this.textBoxServidor.TabIndex = 6;
            // 
            // textBoxBD
            // 
            this.textBoxBD.Enabled = false;
            this.textBoxBD.Location = new System.Drawing.Point(146, 119);
            this.textBoxBD.Name = "textBoxBD";
            this.textBoxBD.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxBD.Size = new System.Drawing.Size(104, 20);
            this.textBoxBD.TabIndex = 7;
            // 
            // textBoxUSR
            // 
            this.textBoxUSR.Enabled = false;
            this.textBoxUSR.Location = new System.Drawing.Point(276, 119);
            this.textBoxUSR.Name = "textBoxUSR";
            this.textBoxUSR.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxUSR.Size = new System.Drawing.Size(104, 20);
            this.textBoxUSR.TabIndex = 8;
            // 
            // textBoxPWD
            // 
            this.textBoxPWD.Enabled = false;
            this.textBoxPWD.Location = new System.Drawing.Point(407, 119);
            this.textBoxPWD.Name = "textBoxPWD";
            this.textBoxPWD.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxPWD.Size = new System.Drawing.Size(104, 20);
            this.textBoxPWD.TabIndex = 9;
            // 
            // buttonComprobarConexion
            // 
            this.buttonComprobarConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonComprobarConexion.Location = new System.Drawing.Point(538, 116);
            this.buttonComprobarConexion.Name = "buttonComprobarConexion";
            this.buttonComprobarConexion.Size = new System.Drawing.Size(238, 24);
            this.buttonComprobarConexion.TabIndex = 10;
            this.buttonComprobarConexion.Text = "Comprobar conexión a la BD";
            this.buttonComprobarConexion.UseVisualStyleBackColor = true;
            this.buttonComprobarConexion.Click += new System.EventHandler(this.buttonRealizarConexion_Click);
            // 
            // textBoxConsultaSql
            // 
            this.textBoxConsultaSql.Enabled = false;
            this.textBoxConsultaSql.Location = new System.Drawing.Point(73, 178);
            this.textBoxConsultaSql.Name = "textBoxConsultaSql";
            this.textBoxConsultaSql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxConsultaSql.Size = new System.Drawing.Size(509, 20);
            this.textBoxConsultaSql.TabIndex = 11;
            this.textBoxConsultaSql.Visible = false;
            // 
            // labelConsultaSQL
            // 
            this.labelConsultaSQL.AutoSize = true;
            this.labelConsultaSQL.Enabled = false;
            this.labelConsultaSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConsultaSQL.Location = new System.Drawing.Point(272, 155);
            this.labelConsultaSQL.Name = "labelConsultaSQL";
            this.labelConsultaSQL.Size = new System.Drawing.Size(120, 20);
            this.labelConsultaSQL.TabIndex = 12;
            this.labelConsultaSQL.Text = "Consulta SQL";
            this.labelConsultaSQL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelConsultaSQL.Visible = false;
            // 
            // groupBoxDatosDB
            // 
            this.groupBoxDatosDB.Controls.Add(this.listViewNombreCampos);
            this.groupBoxDatosDB.Controls.Add(this.listViewTablas);
            this.groupBoxDatosDB.Controls.Add(this.listViewDB);
            this.groupBoxDatosDB.Location = new System.Drawing.Point(671, 156);
            this.groupBoxDatosDB.Name = "groupBoxDatosDB";
            this.groupBoxDatosDB.Size = new System.Drawing.Size(515, 283);
            this.groupBoxDatosDB.TabIndex = 13;
            this.groupBoxDatosDB.TabStop = false;
            // 
            // listViewNombreCampos
            // 
            this.listViewNombreCampos.HideSelection = false;
            this.listViewNombreCampos.Location = new System.Drawing.Point(348, 10);
            this.listViewNombreCampos.Name = "listViewNombreCampos";
            this.listViewNombreCampos.Size = new System.Drawing.Size(161, 267);
            this.listViewNombreCampos.TabIndex = 2;
            this.listViewNombreCampos.UseCompatibleStateImageBehavior = false;
            this.listViewNombreCampos.View = System.Windows.Forms.View.List;
            // 
            // listViewTablas
            // 
            this.listViewTablas.HideSelection = false;
            this.listViewTablas.Location = new System.Drawing.Point(178, 10);
            this.listViewTablas.Name = "listViewTablas";
            this.listViewTablas.Size = new System.Drawing.Size(161, 267);
            this.listViewTablas.TabIndex = 1;
            this.listViewTablas.UseCompatibleStateImageBehavior = false;
            this.listViewTablas.View = System.Windows.Forms.View.List;
            // 
            // listViewDB
            // 
            this.listViewDB.HideSelection = false;
            this.listViewDB.Location = new System.Drawing.Point(6, 10);
            this.listViewDB.Name = "listViewDB";
            this.listViewDB.Size = new System.Drawing.Size(161, 267);
            this.listViewDB.TabIndex = 0;
            this.listViewDB.UseCompatibleStateImageBehavior = false;
            this.listViewDB.View = System.Windows.Forms.View.List;
            this.listViewDB.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewDB_ItemSelectionChanged);
            // 
            // buttonEjecutar
            // 
            this.buttonEjecutar.Enabled = false;
            this.buttonEjecutar.Location = new System.Drawing.Point(248, 209);
            this.buttonEjecutar.Name = "buttonEjecutar";
            this.buttonEjecutar.Size = new System.Drawing.Size(166, 67);
            this.buttonEjecutar.TabIndex = 14;
            this.buttonEjecutar.Text = "Ejecutar";
            this.buttonEjecutar.UseVisualStyleBackColor = true;
            this.buttonEjecutar.Visible = false;
            this.buttonEjecutar.Click += new System.EventHandler(this.buttonMostrar_Click);
            // 
            // labelBD
            // 
            this.labelBD.AutoSize = true;
            this.labelBD.Location = new System.Drawing.Point(744, 150);
            this.labelBD.Name = "labelBD";
            this.labelBD.Size = new System.Drawing.Size(22, 13);
            this.labelBD.TabIndex = 2;
            this.labelBD.Text = "BD";
            // 
            // labelNombreCampos
            // 
            this.labelNombreCampos.AutoSize = true;
            this.labelNombreCampos.Location = new System.Drawing.Point(1061, 148);
            this.labelNombreCampos.Name = "labelNombreCampos";
            this.labelNombreCampos.Size = new System.Drawing.Size(84, 13);
            this.labelNombreCampos.TabIndex = 15;
            this.labelNombreCampos.Text = "Nombre campos";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(690, 439);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(482, 127);
            this.dataGridView1.TabIndex = 16;
            // 
            // buttonMostrarTodasBD
            // 
            this.buttonMostrarTodasBD.Enabled = false;
            this.buttonMostrarTodasBD.Location = new System.Drawing.Point(923, 12);
            this.buttonMostrarTodasBD.Name = "buttonMostrarTodasBD";
            this.buttonMostrarTodasBD.Size = new System.Drawing.Size(105, 101);
            this.buttonMostrarTodasBD.TabIndex = 17;
            this.buttonMostrarTodasBD.Text = "Mostrar todas las BD";
            this.buttonMostrarTodasBD.UseVisualStyleBackColor = true;
            // 
            // buttonVerUnaBD
            // 
            this.buttonVerUnaBD.Enabled = false;
            this.buttonVerUnaBD.Location = new System.Drawing.Point(802, 12);
            this.buttonVerUnaBD.Name = "buttonVerUnaBD";
            this.buttonVerUnaBD.Size = new System.Drawing.Size(105, 101);
            this.buttonVerUnaBD.TabIndex = 18;
            this.buttonVerUnaBD.Text = "Ver una BD";
            this.buttonVerUnaBD.UseVisualStyleBackColor = true;
            // 
            // listView3
            // 
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(1049, 12);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(131, 127);
            this.listView3.TabIndex = 19;
            this.listView3.UseCompatibleStateImageBehavior = false;
            // 
            // buttonExportarBD
            // 
            this.buttonExportarBD.Location = new System.Drawing.Point(146, 323);
            this.buttonExportarBD.Name = "buttonExportarBD";
            this.buttonExportarBD.Size = new System.Drawing.Size(177, 77);
            this.buttonExportarBD.TabIndex = 20;
            this.buttonExportarBD.Text = "Exportar BD";
            this.buttonExportarBD.UseVisualStyleBackColor = true;
            this.buttonExportarBD.Visible = false;
            this.buttonExportarBD.Click += new System.EventHandler(this.buttonExportarBD_Click);
            // 
            // buttonImportarBD
            // 
            this.buttonImportarBD.Location = new System.Drawing.Point(334, 323);
            this.buttonImportarBD.Name = "buttonImportarBD";
            this.buttonImportarBD.Size = new System.Drawing.Size(177, 77);
            this.buttonImportarBD.TabIndex = 21;
            this.buttonImportarBD.Text = "Importar BD";
            this.buttonImportarBD.UseVisualStyleBackColor = true;
            this.buttonImportarBD.Visible = false;
            this.buttonImportarBD.Click += new System.EventHandler(this.buttonImportarBD_Click);
            // 
            // labelTablas
            // 
            this.labelTablas.AutoSize = true;
            this.labelTablas.Location = new System.Drawing.Point(909, 149);
            this.labelTablas.Name = "labelTablas";
            this.labelTablas.Size = new System.Drawing.Size(39, 13);
            this.labelTablas.TabIndex = 22;
            this.labelTablas.Text = "Tablas";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(1198, 573);
            this.Controls.Add(this.labelTablas);
            this.Controls.Add(this.buttonImportarBD);
            this.Controls.Add(this.buttonExportarBD);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.buttonVerUnaBD);
            this.Controls.Add(this.buttonMostrarTodasBD);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelNombreCampos);
            this.Controls.Add(this.labelBD);
            this.Controls.Add(this.buttonEjecutar);
            this.Controls.Add(this.groupBoxDatosDB);
            this.Controls.Add(this.labelConsultaSQL);
            this.Controls.Add(this.textBoxConsultaSql);
            this.Controls.Add(this.buttonComprobarConexion);
            this.Controls.Add(this.textBoxPWD);
            this.Controls.Add(this.textBoxUSR);
            this.Controls.Add(this.textBoxBD);
            this.Controls.Add(this.textBoxServidor);
            this.Controls.Add(this.buttonSalir);
            this.Controls.Add(this.buttonConsultaSQL);
            this.Controls.Add(this.buttonPWD);
            this.Controls.Add(this.buttonUSR);
            this.Controls.Add(this.buttonBD);
            this.Controls.Add(this.buttonServidor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBoxDatosDB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonServidor;
        private System.Windows.Forms.Button buttonBD;
        private System.Windows.Forms.Button buttonUSR;
        private System.Windows.Forms.Button buttonPWD;
        private System.Windows.Forms.Button buttonConsultaSQL;
        private System.Windows.Forms.Button buttonSalir;
        private System.Windows.Forms.TextBox textBoxBD;
        private System.Windows.Forms.TextBox textBoxUSR;
        private System.Windows.Forms.TextBox textBoxPWD;
        private System.Windows.Forms.TextBox textBoxServidor;
        private System.Windows.Forms.Button buttonComprobarConexion;
        private System.Windows.Forms.TextBox textBoxConsultaSql;
        private System.Windows.Forms.Label labelConsultaSQL;
        private System.Windows.Forms.GroupBox groupBoxDatosDB;
        private System.Windows.Forms.Button buttonEjecutar;
        private System.Windows.Forms.ListView listViewDB;
        private System.Windows.Forms.ListView listViewTablas;
        private System.Windows.Forms.Label labelBD;
        private System.Windows.Forms.Label labelNombreCampos;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonMostrarTodasBD;
        private System.Windows.Forms.Button buttonVerUnaBD;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ListView listViewNombreCampos;
        private System.Windows.Forms.Button buttonExportarBD;
        private System.Windows.Forms.Button buttonImportarBD;
        private System.Windows.Forms.Label labelTablas;
    }
}

