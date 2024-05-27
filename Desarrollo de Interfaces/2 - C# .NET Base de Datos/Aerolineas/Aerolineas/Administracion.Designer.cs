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
            this.gBOpcionCrearModeloAvion = new System.Windows.Forms.GroupBox();
            this.numericUpDownTuristas = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPrimera = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBussines = new System.Windows.Forms.NumericUpDown();
            this.btnAñadirModeloAvion = new System.Windows.Forms.Button();
            this.btnCrearRuta = new System.Windows.Forms.Button();
            this.gBOpcionCrearNuevaRuta = new System.Windows.Forms.GroupBox();
            this.cBRuta2CNR = new System.Windows.Forms.ComboBox();
            this.cBRuta1CNR = new System.Windows.Forms.ComboBox();
            this.cbIdAvionCNR = new System.Windows.Forms.ComboBox();
            this.numericUpDownPrecioTuristaCNR = new System.Windows.Forms.NumericUpDown();
            this.lblTPrecioTuristaCNR = new System.Windows.Forms.Label();
            this.numericUpDownPrecioPrimeraCNR = new System.Windows.Forms.NumericUpDown();
            this.lblTPrecioPrimeraCNR = new System.Windows.Forms.Label();
            this.btnCrearNuevaRutaCNR = new System.Windows.Forms.Button();
            this.numericUpDownPrecioBussinessCNR = new System.Windows.Forms.NumericUpDown();
            this.lblTPrecioBussinesCNR = new System.Windows.Forms.Label();
            this.lbFCNR = new System.Windows.Forms.Label();
            this.lblMinutos = new System.Windows.Forms.Label();
            this.lblHoras = new System.Windows.Forms.Label();
            this.tBFechaSalidaTotalCNR = new System.Windows.Forms.TextBox();
            this.numMin = new System.Windows.Forms.NumericUpDown();
            this.numHoras = new System.Windows.Forms.NumericUpDown();
            this.lblTFechaSalidaCNR = new System.Windows.Forms.Label();
            this.dateTPFechaCNR = new System.Windows.Forms.DateTimePicker();
            this.lblTRutaCNR = new System.Windows.Forms.Label();
            this.lblTIdVueloCNR = new System.Windows.Forms.Label();
            this.gBOpcionModificarAvion = new System.Windows.Forms.GroupBox();
            this.tBMAFTurista = new System.Windows.Forms.TextBox();
            this.lblMAFTurista = new System.Windows.Forms.Label();
            this.tBMAFPrimera = new System.Windows.Forms.TextBox();
            this.lblMAFPrimera = new System.Windows.Forms.Label();
            this.tBMAFBussines = new System.Windows.Forms.TextBox();
            this.lblMAFBussines = new System.Windows.Forms.Label();
            this.tBMAModelo = new System.Windows.Forms.TextBox();
            this.lblMAModelo = new System.Windows.Forms.Label();
            this.cBMAIdAvion = new System.Windows.Forms.ComboBox();
            this.btnModAvion = new System.Windows.Forms.Button();
            this.lblMAIdAvion = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnModificarAvion = new System.Windows.Forms.Button();
            this.gBOpcionCrearModeloAvion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTuristas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrimera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBussines)).BeginInit();
            this.gBOpcionCrearNuevaRuta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrecioTuristaCNR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrecioPrimeraCNR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrecioBussinessCNR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHoras)).BeginInit();
            this.gBOpcionModificarAvion.SuspendLayout();
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
            // gBOpcionCrearModeloAvion
            // 
            this.gBOpcionCrearModeloAvion.Controls.Add(this.numericUpDownTuristas);
            this.gBOpcionCrearModeloAvion.Controls.Add(this.numericUpDownPrimera);
            this.gBOpcionCrearModeloAvion.Controls.Add(this.numericUpDownBussines);
            this.gBOpcionCrearModeloAvion.Controls.Add(this.btnAñadirModeloAvion);
            this.gBOpcionCrearModeloAvion.Controls.Add(this.lblTModelo);
            this.gBOpcionCrearModeloAvion.Controls.Add(this.tBModelo);
            this.gBOpcionCrearModeloAvion.Controls.Add(this.lblTFTuristas);
            this.gBOpcionCrearModeloAvion.Controls.Add(this.lblTIdAvion);
            this.gBOpcionCrearModeloAvion.Controls.Add(this.tBIdAvion);
            this.gBOpcionCrearModeloAvion.Controls.Add(this.lblTFPrimera);
            this.gBOpcionCrearModeloAvion.Controls.Add(this.lblTFBussines);
            this.gBOpcionCrearModeloAvion.Location = new System.Drawing.Point(267, 34);
            this.gBOpcionCrearModeloAvion.Name = "gBOpcionCrearModeloAvion";
            this.gBOpcionCrearModeloAvion.Size = new System.Drawing.Size(547, 374);
            this.gBOpcionCrearModeloAvion.TabIndex = 17;
            this.gBOpcionCrearModeloAvion.TabStop = false;
            this.gBOpcionCrearModeloAvion.Visible = false;
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
            // btnCrearRuta
            // 
            this.btnCrearRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearRuta.Location = new System.Drawing.Point(12, 91);
            this.btnCrearRuta.Name = "btnCrearRuta";
            this.btnCrearRuta.Size = new System.Drawing.Size(226, 36);
            this.btnCrearRuta.TabIndex = 18;
            this.btnCrearRuta.Text = "Crear nueva ruta";
            this.btnCrearRuta.UseVisualStyleBackColor = true;
            this.btnCrearRuta.Click += new System.EventHandler(this.btnCrearRuta_Click);
            // 
            // gBOpcionCrearNuevaRuta
            // 
            this.gBOpcionCrearNuevaRuta.Controls.Add(this.cBRuta2CNR);
            this.gBOpcionCrearNuevaRuta.Controls.Add(this.cBRuta1CNR);
            this.gBOpcionCrearNuevaRuta.Controls.Add(this.cbIdAvionCNR);
            this.gBOpcionCrearNuevaRuta.Controls.Add(this.numericUpDownPrecioTuristaCNR);
            this.gBOpcionCrearNuevaRuta.Controls.Add(this.lblTPrecioTuristaCNR);
            this.gBOpcionCrearNuevaRuta.Controls.Add(this.numericUpDownPrecioPrimeraCNR);
            this.gBOpcionCrearNuevaRuta.Controls.Add(this.lblTPrecioPrimeraCNR);
            this.gBOpcionCrearNuevaRuta.Controls.Add(this.btnCrearNuevaRutaCNR);
            this.gBOpcionCrearNuevaRuta.Controls.Add(this.numericUpDownPrecioBussinessCNR);
            this.gBOpcionCrearNuevaRuta.Controls.Add(this.lblTPrecioBussinesCNR);
            this.gBOpcionCrearNuevaRuta.Controls.Add(this.lbFCNR);
            this.gBOpcionCrearNuevaRuta.Controls.Add(this.lblMinutos);
            this.gBOpcionCrearNuevaRuta.Controls.Add(this.lblHoras);
            this.gBOpcionCrearNuevaRuta.Controls.Add(this.tBFechaSalidaTotalCNR);
            this.gBOpcionCrearNuevaRuta.Controls.Add(this.numMin);
            this.gBOpcionCrearNuevaRuta.Controls.Add(this.numHoras);
            this.gBOpcionCrearNuevaRuta.Controls.Add(this.lblTFechaSalidaCNR);
            this.gBOpcionCrearNuevaRuta.Controls.Add(this.dateTPFechaCNR);
            this.gBOpcionCrearNuevaRuta.Controls.Add(this.lblTRutaCNR);
            this.gBOpcionCrearNuevaRuta.Controls.Add(this.lblTIdVueloCNR);
            this.gBOpcionCrearNuevaRuta.Location = new System.Drawing.Point(267, 34);
            this.gBOpcionCrearNuevaRuta.Name = "gBOpcionCrearNuevaRuta";
            this.gBOpcionCrearNuevaRuta.Size = new System.Drawing.Size(547, 463);
            this.gBOpcionCrearNuevaRuta.TabIndex = 22;
            this.gBOpcionCrearNuevaRuta.TabStop = false;
            this.gBOpcionCrearNuevaRuta.Visible = false;
            // 
            // cBRuta2CNR
            // 
            this.cBRuta2CNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBRuta2CNR.FormattingEnabled = true;
            this.cBRuta2CNR.Location = new System.Drawing.Point(418, 53);
            this.cBRuta2CNR.Name = "cBRuta2CNR";
            this.cBRuta2CNR.Size = new System.Drawing.Size(119, 39);
            this.cBRuta2CNR.TabIndex = 39;
            this.cBRuta2CNR.SelectedIndexChanged += new System.EventHandler(this.cBRuta2CNR_SelectedIndexChanged);
            // 
            // cBRuta1CNR
            // 
            this.cBRuta1CNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBRuta1CNR.FormattingEnabled = true;
            this.cBRuta1CNR.Location = new System.Drawing.Point(287, 53);
            this.cBRuta1CNR.Name = "cBRuta1CNR";
            this.cBRuta1CNR.Size = new System.Drawing.Size(119, 39);
            this.cBRuta1CNR.TabIndex = 38;
            this.cBRuta1CNR.SelectedIndexChanged += new System.EventHandler(this.cBRuta1CNR_SelectedIndexChanged);
            // 
            // cbIdAvionCNR
            // 
            this.cbIdAvionCNR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdAvionCNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIdAvionCNR.FormattingEnabled = true;
            this.cbIdAvionCNR.Location = new System.Drawing.Point(19, 54);
            this.cbIdAvionCNR.Name = "cbIdAvionCNR";
            this.cbIdAvionCNR.Size = new System.Drawing.Size(254, 39);
            this.cbIdAvionCNR.TabIndex = 37;
            // 
            // numericUpDownPrecioTuristaCNR
            // 
            this.numericUpDownPrecioTuristaCNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPrecioTuristaCNR.Location = new System.Drawing.Point(147, 359);
            this.numericUpDownPrecioTuristaCNR.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDownPrecioTuristaCNR.Name = "numericUpDownPrecioTuristaCNR";
            this.numericUpDownPrecioTuristaCNR.Size = new System.Drawing.Size(254, 31);
            this.numericUpDownPrecioTuristaCNR.TabIndex = 36;
            // 
            // lblTPrecioTuristaCNR
            // 
            this.lblTPrecioTuristaCNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTPrecioTuristaCNR.Location = new System.Drawing.Point(147, 321);
            this.lblTPrecioTuristaCNR.Name = "lblTPrecioTuristaCNR";
            this.lblTPrecioTuristaCNR.Size = new System.Drawing.Size(254, 35);
            this.lblTPrecioTuristaCNR.TabIndex = 35;
            this.lblTPrecioTuristaCNR.Text = "Precio Turista";
            this.lblTPrecioTuristaCNR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDownPrecioPrimeraCNR
            // 
            this.numericUpDownPrecioPrimeraCNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPrecioPrimeraCNR.Location = new System.Drawing.Point(283, 284);
            this.numericUpDownPrecioPrimeraCNR.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDownPrecioPrimeraCNR.Name = "numericUpDownPrecioPrimeraCNR";
            this.numericUpDownPrecioPrimeraCNR.Size = new System.Drawing.Size(254, 31);
            this.numericUpDownPrecioPrimeraCNR.TabIndex = 34;
            // 
            // lblTPrecioPrimeraCNR
            // 
            this.lblTPrecioPrimeraCNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTPrecioPrimeraCNR.Location = new System.Drawing.Point(282, 243);
            this.lblTPrecioPrimeraCNR.Name = "lblTPrecioPrimeraCNR";
            this.lblTPrecioPrimeraCNR.Size = new System.Drawing.Size(254, 35);
            this.lblTPrecioPrimeraCNR.TabIndex = 33;
            this.lblTPrecioPrimeraCNR.Text = "Precio Primera";
            this.lblTPrecioPrimeraCNR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCrearNuevaRutaCNR
            // 
            this.btnCrearNuevaRutaCNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearNuevaRutaCNR.Location = new System.Drawing.Point(162, 414);
            this.btnCrearNuevaRutaCNR.Name = "btnCrearNuevaRutaCNR";
            this.btnCrearNuevaRutaCNR.Size = new System.Drawing.Size(226, 36);
            this.btnCrearNuevaRutaCNR.TabIndex = 18;
            this.btnCrearNuevaRutaCNR.Text = "Crear";
            this.btnCrearNuevaRutaCNR.UseVisualStyleBackColor = true;
            this.btnCrearNuevaRutaCNR.Click += new System.EventHandler(this.btnCrearNuevaRutaCNR_Click);
            // 
            // numericUpDownPrecioBussinessCNR
            // 
            this.numericUpDownPrecioBussinessCNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPrecioBussinessCNR.Location = new System.Drawing.Point(14, 284);
            this.numericUpDownPrecioBussinessCNR.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDownPrecioBussinessCNR.Name = "numericUpDownPrecioBussinessCNR";
            this.numericUpDownPrecioBussinessCNR.Size = new System.Drawing.Size(254, 31);
            this.numericUpDownPrecioBussinessCNR.TabIndex = 32;
            // 
            // lblTPrecioBussinesCNR
            // 
            this.lblTPrecioBussinesCNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTPrecioBussinesCNR.Location = new System.Drawing.Point(14, 246);
            this.lblTPrecioBussinesCNR.Name = "lblTPrecioBussinesCNR";
            this.lblTPrecioBussinesCNR.Size = new System.Drawing.Size(254, 35);
            this.lblTPrecioBussinesCNR.TabIndex = 31;
            this.lblTPrecioBussinesCNR.Text = "Precio Bussines";
            this.lblTPrecioBussinesCNR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbFCNR
            // 
            this.lbFCNR.AutoSize = true;
            this.lbFCNR.Location = new System.Drawing.Point(116, 140);
            this.lbFCNR.Name = "lbFCNR";
            this.lbFCNR.Size = new System.Drawing.Size(37, 13);
            this.lbFCNR.TabIndex = 30;
            this.lbFCNR.Text = "Fecha";
            // 
            // lblMinutos
            // 
            this.lblMinutos.AutoSize = true;
            this.lblMinutos.Location = new System.Drawing.Point(436, 137);
            this.lblMinutos.Name = "lblMinutos";
            this.lblMinutos.Size = new System.Drawing.Size(44, 13);
            this.lblMinutos.TabIndex = 29;
            this.lblMinutos.Text = "Minutos";
            // 
            // lblHoras
            // 
            this.lblHoras.AutoSize = true;
            this.lblHoras.Location = new System.Drawing.Point(328, 140);
            this.lblHoras.Name = "lblHoras";
            this.lblHoras.Size = new System.Drawing.Size(30, 13);
            this.lblHoras.TabIndex = 28;
            this.lblHoras.Text = "Hora";
            // 
            // tBFechaSalidaTotalCNR
            // 
            this.tBFechaSalidaTotalCNR.Enabled = false;
            this.tBFechaSalidaTotalCNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBFechaSalidaTotalCNR.Location = new System.Drawing.Point(100, 197);
            this.tBFechaSalidaTotalCNR.Name = "tBFechaSalidaTotalCNR";
            this.tBFechaSalidaTotalCNR.Size = new System.Drawing.Size(337, 29);
            this.tBFechaSalidaTotalCNR.TabIndex = 27;
            // 
            // numMin
            // 
            this.numMin.Enabled = false;
            this.numMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMin.Location = new System.Drawing.Point(416, 153);
            this.numMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numMin.Name = "numMin";
            this.numMin.Size = new System.Drawing.Size(88, 29);
            this.numMin.TabIndex = 26;
            this.numMin.ValueChanged += new System.EventHandler(this.numMin_ValueChanged);
            // 
            // numHoras
            // 
            this.numHoras.Enabled = false;
            this.numHoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHoras.Location = new System.Drawing.Point(300, 153);
            this.numHoras.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numHoras.Name = "numHoras";
            this.numHoras.Size = new System.Drawing.Size(88, 29);
            this.numHoras.TabIndex = 25;
            this.numHoras.ValueChanged += new System.EventHandler(this.numHoras_ValueChanged);
            // 
            // lblTFechaSalidaCNR
            // 
            this.lblTFechaSalidaCNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTFechaSalidaCNR.Location = new System.Drawing.Point(191, 105);
            this.lblTFechaSalidaCNR.Name = "lblTFechaSalidaCNR";
            this.lblTFechaSalidaCNR.Size = new System.Drawing.Size(160, 35);
            this.lblTFechaSalidaCNR.TabIndex = 24;
            this.lblTFechaSalidaCNR.Text = "Fecha Salida";
            this.lblTFechaSalidaCNR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTPFechaCNR
            // 
            this.dateTPFechaCNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTPFechaCNR.Location = new System.Drawing.Point(19, 155);
            this.dateTPFechaCNR.Name = "dateTPFechaCNR";
            this.dateTPFechaCNR.Size = new System.Drawing.Size(249, 29);
            this.dateTPFechaCNR.TabIndex = 23;
            this.dateTPFechaCNR.ValueChanged += new System.EventHandler(this.dateTPFechaCNR_ValueChanged);
            // 
            // lblTRutaCNR
            // 
            this.lblTRutaCNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTRutaCNR.Location = new System.Drawing.Point(332, 16);
            this.lblTRutaCNR.Name = "lblTRutaCNR";
            this.lblTRutaCNR.Size = new System.Drawing.Size(160, 35);
            this.lblTRutaCNR.TabIndex = 9;
            this.lblTRutaCNR.Text = "Ruta";
            this.lblTRutaCNR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTIdVueloCNR
            // 
            this.lblTIdVueloCNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIdVueloCNR.Location = new System.Drawing.Point(64, 16);
            this.lblTIdVueloCNR.Name = "lblTIdVueloCNR";
            this.lblTIdVueloCNR.Size = new System.Drawing.Size(160, 35);
            this.lblTIdVueloCNR.TabIndex = 7;
            this.lblTIdVueloCNR.Text = "IdAvion";
            this.lblTIdVueloCNR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gBOpcionModificarAvion
            // 
            this.gBOpcionModificarAvion.Controls.Add(this.tBMAFTurista);
            this.gBOpcionModificarAvion.Controls.Add(this.lblMAFTurista);
            this.gBOpcionModificarAvion.Controls.Add(this.tBMAFPrimera);
            this.gBOpcionModificarAvion.Controls.Add(this.lblMAFPrimera);
            this.gBOpcionModificarAvion.Controls.Add(this.tBMAFBussines);
            this.gBOpcionModificarAvion.Controls.Add(this.lblMAFBussines);
            this.gBOpcionModificarAvion.Controls.Add(this.tBMAModelo);
            this.gBOpcionModificarAvion.Controls.Add(this.lblMAModelo);
            this.gBOpcionModificarAvion.Controls.Add(this.cBMAIdAvion);
            this.gBOpcionModificarAvion.Controls.Add(this.btnModAvion);
            this.gBOpcionModificarAvion.Controls.Add(this.lblMAIdAvion);
            this.gBOpcionModificarAvion.Location = new System.Drawing.Point(267, 34);
            this.gBOpcionModificarAvion.Name = "gBOpcionModificarAvion";
            this.gBOpcionModificarAvion.Size = new System.Drawing.Size(547, 390);
            this.gBOpcionModificarAvion.TabIndex = 40;
            this.gBOpcionModificarAvion.TabStop = false;
            this.gBOpcionModificarAvion.Visible = false;
            // 
            // tBMAFTurista
            // 
            this.tBMAFTurista.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBMAFTurista.Location = new System.Drawing.Point(174, 284);
            this.tBMAFTurista.Name = "tBMAFTurista";
            this.tBMAFTurista.Size = new System.Drawing.Size(199, 38);
            this.tBMAFTurista.TabIndex = 45;
            // 
            // lblMAFTurista
            // 
            this.lblMAFTurista.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAFTurista.Location = new System.Drawing.Point(174, 246);
            this.lblMAFTurista.Name = "lblMAFTurista";
            this.lblMAFTurista.Size = new System.Drawing.Size(199, 35);
            this.lblMAFTurista.TabIndex = 44;
            this.lblMAFTurista.Text = "Filas turista";
            this.lblMAFTurista.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBMAFPrimera
            // 
            this.tBMAFPrimera.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBMAFPrimera.Location = new System.Drawing.Point(320, 175);
            this.tBMAFPrimera.Name = "tBMAFPrimera";
            this.tBMAFPrimera.Size = new System.Drawing.Size(199, 38);
            this.tBMAFPrimera.TabIndex = 43;
            // 
            // lblMAFPrimera
            // 
            this.lblMAFPrimera.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAFPrimera.Location = new System.Drawing.Point(320, 137);
            this.lblMAFPrimera.Name = "lblMAFPrimera";
            this.lblMAFPrimera.Size = new System.Drawing.Size(199, 35);
            this.lblMAFPrimera.TabIndex = 42;
            this.lblMAFPrimera.Text = "Filas primera";
            this.lblMAFPrimera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBMAFBussines
            // 
            this.tBMAFBussines.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBMAFBussines.Location = new System.Drawing.Point(40, 175);
            this.tBMAFBussines.Name = "tBMAFBussines";
            this.tBMAFBussines.Size = new System.Drawing.Size(199, 38);
            this.tBMAFBussines.TabIndex = 41;
            // 
            // lblMAFBussines
            // 
            this.lblMAFBussines.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAFBussines.Location = new System.Drawing.Point(40, 137);
            this.lblMAFBussines.Name = "lblMAFBussines";
            this.lblMAFBussines.Size = new System.Drawing.Size(199, 35);
            this.lblMAFBussines.TabIndex = 40;
            this.lblMAFBussines.Text = "Filas bussines";
            this.lblMAFBussines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBMAModelo
            // 
            this.tBMAModelo.Enabled = false;
            this.tBMAModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBMAModelo.Location = new System.Drawing.Point(320, 53);
            this.tBMAModelo.Name = "tBMAModelo";
            this.tBMAModelo.Size = new System.Drawing.Size(199, 38);
            this.tBMAModelo.TabIndex = 39;
            // 
            // lblMAModelo
            // 
            this.lblMAModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAModelo.Location = new System.Drawing.Point(344, 15);
            this.lblMAModelo.Name = "lblMAModelo";
            this.lblMAModelo.Size = new System.Drawing.Size(160, 35);
            this.lblMAModelo.TabIndex = 38;
            this.lblMAModelo.Text = "Modelo";
            this.lblMAModelo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cBMAIdAvion
            // 
            this.cBMAIdAvion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBMAIdAvion.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBMAIdAvion.FormattingEnabled = true;
            this.cBMAIdAvion.Location = new System.Drawing.Point(19, 54);
            this.cBMAIdAvion.Name = "cBMAIdAvion";
            this.cBMAIdAvion.Size = new System.Drawing.Size(254, 39);
            this.cBMAIdAvion.TabIndex = 37;
            this.cBMAIdAvion.SelectedIndexChanged += new System.EventHandler(this.cBMAIdAvion_SelectedIndexChanged);
            // 
            // btnModAvion
            // 
            this.btnModAvion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModAvion.Location = new System.Drawing.Point(162, 347);
            this.btnModAvion.Name = "btnModAvion";
            this.btnModAvion.Size = new System.Drawing.Size(226, 36);
            this.btnModAvion.TabIndex = 18;
            this.btnModAvion.Text = "Modificar";
            this.btnModAvion.UseVisualStyleBackColor = true;
            this.btnModAvion.Visible = false;
            this.btnModAvion.Click += new System.EventHandler(this.btnModAvion_Click);
            // 
            // lblMAIdAvion
            // 
            this.lblMAIdAvion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAIdAvion.Location = new System.Drawing.Point(64, 16);
            this.lblMAIdAvion.Name = "lblMAIdAvion";
            this.lblMAIdAvion.Size = new System.Drawing.Size(160, 35);
            this.lblMAIdAvion.TabIndex = 7;
            this.lblMAIdAvion.Text = "IdAvion";
            this.lblMAIdAvion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(65, 468);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(108, 29);
            this.btnCerrar.TabIndex = 23;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnModificarAvion
            // 
            this.btnModificarAvion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarAvion.Location = new System.Drawing.Point(12, 148);
            this.btnModificarAvion.Name = "btnModificarAvion";
            this.btnModificarAvion.Size = new System.Drawing.Size(226, 36);
            this.btnModificarAvion.TabIndex = 24;
            this.btnModificarAvion.Text = "Modificar avión";
            this.btnModificarAvion.UseVisualStyleBackColor = true;
            this.btnModificarAvion.Click += new System.EventHandler(this.btnModificarAvion_Click);
            // 
            // Administracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.ClientSize = new System.Drawing.Size(826, 509);
            this.Controls.Add(this.gBOpcionModificarAvion);
            this.Controls.Add(this.btnModificarAvion);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.gBOpcionCrearNuevaRuta);
            this.Controls.Add(this.btnCrearRuta);
            this.Controls.Add(this.gBOpcionCrearModeloAvion);
            this.Controls.Add(this.btnCrearModeloAvion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Administracion";
            this.Text = " ";
            this.gBOpcionCrearModeloAvion.ResumeLayout(false);
            this.gBOpcionCrearModeloAvion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTuristas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrimera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBussines)).EndInit();
            this.gBOpcionCrearNuevaRuta.ResumeLayout(false);
            this.gBOpcionCrearNuevaRuta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrecioTuristaCNR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrecioPrimeraCNR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrecioBussinessCNR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHoras)).EndInit();
            this.gBOpcionModificarAvion.ResumeLayout(false);
            this.gBOpcionModificarAvion.PerformLayout();
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
        private System.Windows.Forms.GroupBox gBOpcionCrearModeloAvion;
        private System.Windows.Forms.Button btnAñadirModeloAvion;
        private System.Windows.Forms.NumericUpDown numericUpDownTuristas;
        private System.Windows.Forms.NumericUpDown numericUpDownPrimera;
        private System.Windows.Forms.NumericUpDown numericUpDownBussines;
        private System.Windows.Forms.Button btnCrearRuta;
        private System.Windows.Forms.GroupBox gBOpcionCrearNuevaRuta;
        private System.Windows.Forms.Button btnCrearNuevaRutaCNR;
        private System.Windows.Forms.Label lblTRutaCNR;
        private System.Windows.Forms.Label lblTIdVueloCNR;
        private System.Windows.Forms.Label lblTFechaSalidaCNR;
        private System.Windows.Forms.DateTimePicker dateTPFechaCNR;
        private System.Windows.Forms.Label lblMinutos;
        private System.Windows.Forms.Label lblHoras;
        private System.Windows.Forms.TextBox tBFechaSalidaTotalCNR;
        private System.Windows.Forms.NumericUpDown numMin;
        private System.Windows.Forms.NumericUpDown numHoras;
        private System.Windows.Forms.Label lbFCNR;
        private System.Windows.Forms.NumericUpDown numericUpDownPrecioBussinessCNR;
        private System.Windows.Forms.Label lblTPrecioBussinesCNR;
        private System.Windows.Forms.NumericUpDown numericUpDownPrecioPrimeraCNR;
        private System.Windows.Forms.Label lblTPrecioPrimeraCNR;
        private System.Windows.Forms.NumericUpDown numericUpDownPrecioTuristaCNR;
        private System.Windows.Forms.Label lblTPrecioTuristaCNR;
        private System.Windows.Forms.ComboBox cbIdAvionCNR;
        private System.Windows.Forms.ComboBox cBRuta2CNR;
        private System.Windows.Forms.ComboBox cBRuta1CNR;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnModificarAvion;
        private System.Windows.Forms.GroupBox gBOpcionModificarAvion;
        private System.Windows.Forms.ComboBox cBMAIdAvion;
        private System.Windows.Forms.Button btnModAvion;
        private System.Windows.Forms.Label lblMAIdAvion;
        private System.Windows.Forms.Label lblMAModelo;
        private System.Windows.Forms.TextBox tBMAModelo;
        private System.Windows.Forms.TextBox tBMAFTurista;
        private System.Windows.Forms.Label lblMAFTurista;
        private System.Windows.Forms.TextBox tBMAFPrimera;
        private System.Windows.Forms.Label lblMAFPrimera;
        private System.Windows.Forms.TextBox tBMAFBussines;
        private System.Windows.Forms.Label lblMAFBussines;
    }
}