namespace Aerolineas
{
    partial class ReservarVuelo
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
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.btnCerrarReserva = new System.Windows.Forms.Button();
            this.btnComprarVuelo = new System.Windows.Forms.Button();
            this.groupBoxLeyenda = new System.Windows.Forms.GroupBox();
            this.buttonReservadoPriopio = new System.Windows.Forms.Button();
            this.buttonBilletesPropios = new System.Windows.Forms.Button();
            this.buttonSeleccionado = new System.Windows.Forms.Button();
            this.buttonTurista = new System.Windows.Forms.Button();
            this.buttonPrimera = new System.Windows.Forms.Button();
            this.buttonBussines = new System.Windows.Forms.Button();
            this.lblVuelos = new System.Windows.Forms.Label();
            this.comboBoxVuelos = new System.Windows.Forms.ComboBox();
            this.lblBienvenidaMail = new System.Windows.Forms.Label();
            this.lblTPrecioTurista = new System.Windows.Forms.Label();
            this.lblPrecioTurista = new System.Windows.Forms.Label();
            this.lblTPrecioPrimera = new System.Windows.Forms.Label();
            this.lblPrecioPrimera = new System.Windows.Forms.Label();
            this.lblPrecioBussines = new System.Windows.Forms.Label();
            this.lblTPrecioBussines = new System.Windows.Forms.Label();
            this.lblTrayecto = new System.Windows.Forms.Label();
            this.lblTTrayecto = new System.Windows.Forms.Label();
            this.lblFechaSalida = new System.Windows.Forms.Label();
            this.lblTFechaSalida = new System.Windows.Forms.Label();
            this.lblIdAvion = new System.Windows.Forms.Label();
            this.lblTIdAvion = new System.Windows.Forms.Label();
            this.gBDatosVuelos = new System.Windows.Forms.GroupBox();
            this.fLPrincipal = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTPrecioTotal = new System.Windows.Forms.Label();
            this.lblPrecioTotal = new System.Windows.Forms.Label();
            this.btnPerfil = new System.Windows.Forms.Button();
            this.lblPrecioTotalDTO = new System.Windows.Forms.Label();
            this.lblTPrecioTotalDTO = new System.Windows.Forms.Label();
            this.groupBoxLeyenda.SuspendLayout();
            this.gBDatosVuelos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.Location = new System.Drawing.Point(13, 13);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(235, 25);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "*Bienvenido Usuario*";
            // 
            // btnCerrarReserva
            // 
            this.btnCerrarReserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarReserva.Location = new System.Drawing.Point(472, 566);
            this.btnCerrarReserva.Name = "btnCerrarReserva";
            this.btnCerrarReserva.Size = new System.Drawing.Size(117, 36);
            this.btnCerrarReserva.TabIndex = 7;
            this.btnCerrarReserva.Text = "Cerrar";
            this.btnCerrarReserva.UseVisualStyleBackColor = true;
            this.btnCerrarReserva.Click += new System.EventHandler(this.btnCerrarReserva_Click);
            // 
            // btnComprarVuelo
            // 
            this.btnComprarVuelo.Enabled = false;
            this.btnComprarVuelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprarVuelo.Location = new System.Drawing.Point(194, 566);
            this.btnComprarVuelo.Name = "btnComprarVuelo";
            this.btnComprarVuelo.Size = new System.Drawing.Size(117, 36);
            this.btnComprarVuelo.TabIndex = 8;
            this.btnComprarVuelo.Text = "Comprar";
            this.btnComprarVuelo.UseVisualStyleBackColor = true;
            this.btnComprarVuelo.Click += new System.EventHandler(this.btnComprarVuelo_Click);
            // 
            // groupBoxLeyenda
            // 
            this.groupBoxLeyenda.Controls.Add(this.buttonReservadoPriopio);
            this.groupBoxLeyenda.Controls.Add(this.buttonBilletesPropios);
            this.groupBoxLeyenda.Controls.Add(this.buttonSeleccionado);
            this.groupBoxLeyenda.Controls.Add(this.buttonTurista);
            this.groupBoxLeyenda.Controls.Add(this.buttonPrimera);
            this.groupBoxLeyenda.Controls.Add(this.buttonBussines);
            this.groupBoxLeyenda.Enabled = false;
            this.groupBoxLeyenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxLeyenda.Location = new System.Drawing.Point(758, 405);
            this.groupBoxLeyenda.Name = "groupBoxLeyenda";
            this.groupBoxLeyenda.Size = new System.Drawing.Size(200, 197);
            this.groupBoxLeyenda.TabIndex = 9;
            this.groupBoxLeyenda.TabStop = false;
            this.groupBoxLeyenda.Text = "Leyenda";
            // 
            // buttonReservadoPriopio
            // 
            this.buttonReservadoPriopio.BackColor = System.Drawing.Color.Red;
            this.buttonReservadoPriopio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReservadoPriopio.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonReservadoPriopio.Location = new System.Drawing.Point(6, 164);
            this.buttonReservadoPriopio.Name = "buttonReservadoPriopio";
            this.buttonReservadoPriopio.Size = new System.Drawing.Size(188, 23);
            this.buttonReservadoPriopio.TabIndex = 5;
            this.buttonReservadoPriopio.Text = "Reservado Otros";
            this.buttonReservadoPriopio.UseVisualStyleBackColor = false;
            // 
            // buttonBilletesPropios
            // 
            this.buttonBilletesPropios.BackColor = System.Drawing.Color.Blue;
            this.buttonBilletesPropios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBilletesPropios.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonBilletesPropios.Location = new System.Drawing.Point(6, 135);
            this.buttonBilletesPropios.Name = "buttonBilletesPropios";
            this.buttonBilletesPropios.Size = new System.Drawing.Size(188, 23);
            this.buttonBilletesPropios.TabIndex = 4;
            this.buttonBilletesPropios.Text = "Billetes Propios";
            this.buttonBilletesPropios.UseVisualStyleBackColor = false;
            // 
            // buttonSeleccionado
            // 
            this.buttonSeleccionado.BackColor = System.Drawing.Color.Pink;
            this.buttonSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSeleccionado.Location = new System.Drawing.Point(6, 106);
            this.buttonSeleccionado.Name = "buttonSeleccionado";
            this.buttonSeleccionado.Size = new System.Drawing.Size(188, 23);
            this.buttonSeleccionado.TabIndex = 3;
            this.buttonSeleccionado.Text = "Seleccionado";
            this.buttonSeleccionado.UseVisualStyleBackColor = false;
            // 
            // buttonTurista
            // 
            this.buttonTurista.BackColor = System.Drawing.Color.Orange;
            this.buttonTurista.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTurista.Location = new System.Drawing.Point(6, 77);
            this.buttonTurista.Name = "buttonTurista";
            this.buttonTurista.Size = new System.Drawing.Size(188, 23);
            this.buttonTurista.TabIndex = 2;
            this.buttonTurista.Text = "Turista";
            this.buttonTurista.UseVisualStyleBackColor = false;
            // 
            // buttonPrimera
            // 
            this.buttonPrimera.BackColor = System.Drawing.Color.Yellow;
            this.buttonPrimera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrimera.Location = new System.Drawing.Point(6, 48);
            this.buttonPrimera.Name = "buttonPrimera";
            this.buttonPrimera.Size = new System.Drawing.Size(188, 23);
            this.buttonPrimera.TabIndex = 1;
            this.buttonPrimera.Text = "Primera";
            this.buttonPrimera.UseVisualStyleBackColor = false;
            // 
            // buttonBussines
            // 
            this.buttonBussines.BackColor = System.Drawing.Color.Green;
            this.buttonBussines.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBussines.Location = new System.Drawing.Point(6, 19);
            this.buttonBussines.Name = "buttonBussines";
            this.buttonBussines.Size = new System.Drawing.Size(188, 23);
            this.buttonBussines.TabIndex = 0;
            this.buttonBussines.Text = "Bussines";
            this.buttonBussines.UseVisualStyleBackColor = false;
            // 
            // lblVuelos
            // 
            this.lblVuelos.AutoSize = true;
            this.lblVuelos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVuelos.Location = new System.Drawing.Point(533, 15);
            this.lblVuelos.Name = "lblVuelos";
            this.lblVuelos.Size = new System.Drawing.Size(84, 25);
            this.lblVuelos.TabIndex = 10;
            this.lblVuelos.Text = "Vuelos";
            // 
            // comboBoxVuelos
            // 
            this.comboBoxVuelos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxVuelos.FormattingEnabled = true;
            this.comboBoxVuelos.Location = new System.Drawing.Point(623, 13);
            this.comboBoxVuelos.Name = "comboBoxVuelos";
            this.comboBoxVuelos.Size = new System.Drawing.Size(335, 32);
            this.comboBoxVuelos.TabIndex = 11;
            this.comboBoxVuelos.SelectedIndexChanged += new System.EventHandler(this.comboBoxVuelos_SelectedIndexChanged);
            // 
            // lblBienvenidaMail
            // 
            this.lblBienvenidaMail.AutoSize = true;
            this.lblBienvenidaMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenidaMail.Location = new System.Drawing.Point(13, 36);
            this.lblBienvenidaMail.Name = "lblBienvenidaMail";
            this.lblBienvenidaMail.Size = new System.Drawing.Size(189, 25);
            this.lblBienvenidaMail.TabIndex = 12;
            this.lblBienvenidaMail.Text = "*Correo Usuario*";
            // 
            // lblTPrecioTurista
            // 
            this.lblTPrecioTurista.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTPrecioTurista.Location = new System.Drawing.Point(243, 18);
            this.lblTPrecioTurista.Name = "lblTPrecioTurista";
            this.lblTPrecioTurista.Size = new System.Drawing.Size(166, 25);
            this.lblTPrecioTurista.TabIndex = 13;
            this.lblTPrecioTurista.Text = "Precio Turista";
            this.lblTPrecioTurista.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrecioTurista
            // 
            this.lblPrecioTurista.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioTurista.Location = new System.Drawing.Point(255, 45);
            this.lblPrecioTurista.Name = "lblPrecioTurista";
            this.lblPrecioTurista.Size = new System.Drawing.Size(154, 25);
            this.lblPrecioTurista.TabIndex = 14;
            this.lblPrecioTurista.Text = "*0*";
            this.lblPrecioTurista.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTPrecioPrimera
            // 
            this.lblTPrecioPrimera.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTPrecioPrimera.Location = new System.Drawing.Point(238, 77);
            this.lblTPrecioPrimera.Name = "lblTPrecioPrimera";
            this.lblTPrecioPrimera.Size = new System.Drawing.Size(176, 25);
            this.lblTPrecioPrimera.TabIndex = 15;
            this.lblTPrecioPrimera.Text = "Precio Primera";
            this.lblTPrecioPrimera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrecioPrimera
            // 
            this.lblPrecioPrimera.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioPrimera.Location = new System.Drawing.Point(250, 102);
            this.lblPrecioPrimera.Name = "lblPrecioPrimera";
            this.lblPrecioPrimera.Size = new System.Drawing.Size(164, 25);
            this.lblPrecioPrimera.TabIndex = 16;
            this.lblPrecioPrimera.Text = "*0*";
            this.lblPrecioPrimera.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrecioBussines
            // 
            this.lblPrecioBussines.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioBussines.Location = new System.Drawing.Point(250, 159);
            this.lblPrecioBussines.Name = "lblPrecioBussines";
            this.lblPrecioBussines.Size = new System.Drawing.Size(164, 25);
            this.lblPrecioBussines.TabIndex = 18;
            this.lblPrecioBussines.Text = "*0*";
            this.lblPrecioBussines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTPrecioBussines
            // 
            this.lblTPrecioBussines.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTPrecioBussines.Location = new System.Drawing.Point(245, 134);
            this.lblTPrecioBussines.Name = "lblTPrecioBussines";
            this.lblTPrecioBussines.Size = new System.Drawing.Size(169, 25);
            this.lblTPrecioBussines.TabIndex = 17;
            this.lblTPrecioBussines.Text = "Precio Bussines";
            this.lblTPrecioBussines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrayecto
            // 
            this.lblTrayecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrayecto.Location = new System.Drawing.Point(6, 159);
            this.lblTrayecto.Name = "lblTrayecto";
            this.lblTrayecto.Size = new System.Drawing.Size(159, 25);
            this.lblTrayecto.TabIndex = 24;
            this.lblTrayecto.Text = "*????*";
            this.lblTrayecto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTTrayecto
            // 
            this.lblTTrayecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTTrayecto.Location = new System.Drawing.Point(6, 134);
            this.lblTTrayecto.Name = "lblTTrayecto";
            this.lblTTrayecto.Size = new System.Drawing.Size(167, 25);
            this.lblTTrayecto.TabIndex = 23;
            this.lblTTrayecto.Text = "Trayecto";
            this.lblTTrayecto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFechaSalida
            // 
            this.lblFechaSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaSalida.Location = new System.Drawing.Point(6, 102);
            this.lblFechaSalida.Name = "lblFechaSalida";
            this.lblFechaSalida.Size = new System.Drawing.Size(159, 25);
            this.lblFechaSalida.TabIndex = 22;
            this.lblFechaSalida.Text = "*0*";
            this.lblFechaSalida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTFechaSalida
            // 
            this.lblTFechaSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTFechaSalida.Location = new System.Drawing.Point(6, 77);
            this.lblTFechaSalida.Name = "lblTFechaSalida";
            this.lblTFechaSalida.Size = new System.Drawing.Size(159, 25);
            this.lblTFechaSalida.TabIndex = 21;
            this.lblTFechaSalida.Text = "Fecha Salida";
            this.lblTFechaSalida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIdAvion
            // 
            this.lblIdAvion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdAvion.Location = new System.Drawing.Point(6, 45);
            this.lblIdAvion.Name = "lblIdAvion";
            this.lblIdAvion.Size = new System.Drawing.Size(159, 25);
            this.lblIdAvion.TabIndex = 20;
            this.lblIdAvion.Text = "*0*";
            this.lblIdAvion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTIdAvion
            // 
            this.lblTIdAvion.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIdAvion.Location = new System.Drawing.Point(6, 16);
            this.lblTIdAvion.Name = "lblTIdAvion";
            this.lblTIdAvion.Size = new System.Drawing.Size(159, 29);
            this.lblTIdAvion.TabIndex = 19;
            this.lblTIdAvion.Text = "Id Avión";
            this.lblTIdAvion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gBDatosVuelos
            // 
            this.gBDatosVuelos.Controls.Add(this.lblTIdAvion);
            this.gBDatosVuelos.Controls.Add(this.lblPrecioBussines);
            this.gBDatosVuelos.Controls.Add(this.lblTrayecto);
            this.gBDatosVuelos.Controls.Add(this.lblTPrecioBussines);
            this.gBDatosVuelos.Controls.Add(this.lblIdAvion);
            this.gBDatosVuelos.Controls.Add(this.lblPrecioPrimera);
            this.gBDatosVuelos.Controls.Add(this.lblTTrayecto);
            this.gBDatosVuelos.Controls.Add(this.lblTPrecioPrimera);
            this.gBDatosVuelos.Controls.Add(this.lblTFechaSalida);
            this.gBDatosVuelos.Controls.Add(this.lblPrecioTurista);
            this.gBDatosVuelos.Controls.Add(this.lblFechaSalida);
            this.gBDatosVuelos.Controls.Add(this.lblTPrecioTurista);
            this.gBDatosVuelos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBDatosVuelos.Location = new System.Drawing.Point(538, 96);
            this.gBDatosVuelos.Name = "gBDatosVuelos";
            this.gBDatosVuelos.Size = new System.Drawing.Size(420, 192);
            this.gBDatosVuelos.TabIndex = 25;
            this.gBDatosVuelos.TabStop = false;
            this.gBDatosVuelos.Text = "Datos del vuelo";
            // 
            // fLPrincipal
            // 
            this.fLPrincipal.AutoScroll = true;
            this.fLPrincipal.Location = new System.Drawing.Point(12, 105);
            this.fLPrincipal.Name = "fLPrincipal";
            this.fLPrincipal.Size = new System.Drawing.Size(520, 447);
            this.fLPrincipal.TabIndex = 26;
            // 
            // lblTPrecioTotal
            // 
            this.lblTPrecioTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTPrecioTotal.Location = new System.Drawing.Point(544, 327);
            this.lblTPrecioTotal.Name = "lblTPrecioTotal";
            this.lblTPrecioTotal.Size = new System.Drawing.Size(159, 29);
            this.lblTPrecioTotal.TabIndex = 25;
            this.lblTPrecioTotal.Text = "Precio total:";
            this.lblTPrecioTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPrecioTotal
            // 
            this.lblPrecioTotal.AutoSize = true;
            this.lblPrecioTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioTotal.Location = new System.Drawing.Point(696, 329);
            this.lblPrecioTotal.Name = "lblPrecioTotal";
            this.lblPrecioTotal.Size = new System.Drawing.Size(24, 25);
            this.lblPrecioTotal.TabIndex = 27;
            this.lblPrecioTotal.Text = "0";
            this.lblPrecioTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPerfil
            // 
            this.btnPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPerfil.Location = new System.Drawing.Point(18, 64);
            this.btnPerfil.Name = "btnPerfil";
            this.btnPerfil.Size = new System.Drawing.Size(85, 28);
            this.btnPerfil.TabIndex = 28;
            this.btnPerfil.Text = "Perfil";
            this.btnPerfil.UseVisualStyleBackColor = true;
            this.btnPerfil.Click += new System.EventHandler(this.btnPerfil_Click);
            // 
            // lblPrecioTotalDTO
            // 
            this.lblPrecioTotalDTO.AutoSize = true;
            this.lblPrecioTotalDTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecioTotalDTO.Location = new System.Drawing.Point(741, 360);
            this.lblPrecioTotalDTO.Name = "lblPrecioTotalDTO";
            this.lblPrecioTotalDTO.Size = new System.Drawing.Size(24, 25);
            this.lblPrecioTotalDTO.TabIndex = 30;
            this.lblPrecioTotalDTO.Text = "0";
            this.lblPrecioTotalDTO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTPrecioTotalDTO
            // 
            this.lblTPrecioTotalDTO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTPrecioTotalDTO.Location = new System.Drawing.Point(556, 356);
            this.lblTPrecioTotalDTO.Name = "lblTPrecioTotalDTO";
            this.lblTPrecioTotalDTO.Size = new System.Drawing.Size(188, 29);
            this.lblTPrecioTotalDTO.TabIndex = 29;
            this.lblTPrecioTotalDTO.Text = "Precio total (Dto):";
            this.lblTPrecioTotalDTO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReservarVuelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.ClientSize = new System.Drawing.Size(970, 614);
            this.Controls.Add(this.lblPrecioTotalDTO);
            this.Controls.Add(this.lblTPrecioTotalDTO);
            this.Controls.Add(this.btnPerfil);
            this.Controls.Add(this.lblPrecioTotal);
            this.Controls.Add(this.lblTPrecioTotal);
            this.Controls.Add(this.fLPrincipal);
            this.Controls.Add(this.gBDatosVuelos);
            this.Controls.Add(this.lblBienvenidaMail);
            this.Controls.Add(this.comboBoxVuelos);
            this.Controls.Add(this.lblVuelos);
            this.Controls.Add(this.groupBoxLeyenda);
            this.Controls.Add(this.btnComprarVuelo);
            this.Controls.Add(this.btnCerrarReserva);
            this.Controls.Add(this.lblBienvenida);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReservarVuelo";
            this.Text = "ReservarVuelo";
            this.groupBoxLeyenda.ResumeLayout(false);
            this.gBDatosVuelos.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Button btnCerrarReserva;
        private System.Windows.Forms.Button btnComprarVuelo;
        private System.Windows.Forms.GroupBox groupBoxLeyenda;
        private System.Windows.Forms.Button buttonReservadoPriopio;
        private System.Windows.Forms.Button buttonBilletesPropios;
        private System.Windows.Forms.Button buttonSeleccionado;
        private System.Windows.Forms.Button buttonTurista;
        private System.Windows.Forms.Button buttonPrimera;
        private System.Windows.Forms.Button buttonBussines;
        private System.Windows.Forms.Label lblVuelos;
        private System.Windows.Forms.ComboBox comboBoxVuelos;
        private System.Windows.Forms.Label lblBienvenidaMail;
        private System.Windows.Forms.Label lblTPrecioTurista;
        private System.Windows.Forms.Label lblPrecioTurista;
        private System.Windows.Forms.Label lblTPrecioPrimera;
        private System.Windows.Forms.Label lblPrecioPrimera;
        private System.Windows.Forms.Label lblPrecioBussines;
        private System.Windows.Forms.Label lblTPrecioBussines;
        private System.Windows.Forms.Label lblTrayecto;
        private System.Windows.Forms.Label lblTTrayecto;
        private System.Windows.Forms.Label lblFechaSalida;
        private System.Windows.Forms.Label lblTFechaSalida;
        private System.Windows.Forms.Label lblIdAvion;
        private System.Windows.Forms.Label lblTIdAvion;
        private System.Windows.Forms.GroupBox gBDatosVuelos;
        private System.Windows.Forms.FlowLayoutPanel fLPrincipal;
        private System.Windows.Forms.Label lblTPrecioTotal;
        private System.Windows.Forms.Label lblPrecioTotal;
        private System.Windows.Forms.Button btnPerfil;
        private System.Windows.Forms.Label lblPrecioTotalDTO;
        private System.Windows.Forms.Label lblTPrecioTotalDTO;
    }
}