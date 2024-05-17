﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using QRCoder;

namespace Aerolineas
{
    public partial class ReservarVuelo : Form
    {
        ClaseConectar cnx = new ClaseConectar();

        List<Horariosaviones> listaHorarios = new List<Horariosaviones>(); // Lista que contiene los horarios de los aviones.
        List<ModeloAvion> butacasAvion = new List<ModeloAvion>(); // Lista que contiene la cantidad de butacas de cada tipo.
        List<String> listaReservas = new List<string>(); // Lista que contiene las butacas que se han hecho click.
        List<Billeteavion> listaFacturacion = new List<Billeteavion>(); // Lista que contiene las bútacas vendidas.
        List<Usuariosavion> datosUsuario = new List<Usuariosavion>(); // Lista que contiene los datos del usuario activo.

        string usuarioActivo; // Variable que contiene el usuario de la sesión activo.
        TableLayoutPanel tlp;

        public ReservarVuelo(List<Usuariosavion> listaUsuario)
        {
            InitializeComponent();
            this.Text = "Reservar Vuelo";
            datosUsuario = listaUsuario;
            lblBienvenida.Text = "Bienvenido/a: " + datosUsuario[0].Nombre;
            usuarioActivo = datosUsuario[0].Nombre;
            lblBienvenidaMail.Text = "Correo: " + datosUsuario[0].Mail;

            listaHorarios = cnx.obtenerSesionAviones();
            listaFacturacion.Clear();

            foreach (var horarios in listaHorarios)
            {
                comboBoxVuelos.Items.Add(horarios.IdVuelo + " " + horarios.Ruta + " " + horarios.FechaSalida);
            }
        }

        private void btnCerrarReserva_Click(object sender, EventArgs e)
        {
            usuarioActivo = "";
            this.Close();
        }

        private void comboBoxVuelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaReservas.Clear();
            lblPrecioTotal.Text = "0";
            lblPrecioTotalDTO.Text = "0";

            // Obtener el item seleccionado del comboBox.
            ComboBox cB = (ComboBox)sender;
            int seleccion = cB.SelectedIndex;

            listaFacturacion.Clear();

            // Uso el item para establecer las cantidades relacionadas con los datos del comboBox.
            lblPrecioTurista.Text = listaHorarios[seleccion].PrecioTurista.ToString();
            lblPrecioPrimera.Text = listaHorarios[seleccion].PrecioPrimera.ToString();
            lblPrecioBussines.Text = listaHorarios[seleccion].PrecioBussines.ToString();
            lblIdAvion.Text = listaHorarios[seleccion].IdAvion.ToString();
            lblFechaSalida.Text = listaHorarios[seleccion].FechaSalida.ToString();
            lblTrayecto.Text = listaHorarios[seleccion].Ruta.ToString();

            // Configuración del FlowLayoutPanel y los botones.
            fLPrincipal.Controls.Clear();
            butacasAvion.Clear();

            listaFacturacion = cnx.obtenerButacasOcupadas(listaHorarios[seleccion].IdVuelo);

            // Guardo en una lista el resultado de la consulta pasandole el ID del avión para que me devuelva los datos del avión.
            butacasAvion = cnx.obtenerButacasAvion(listaHorarios[seleccion].IdAvion);
            // Guardo en una variable el contenido de cada butaca para usarlo a la hora de crear el TableLayoutPanel.
            int butacasBussines = butacasAvion[0].FBussines * 6;
            int butacasPrimera = butacasAvion[0].FPrimera * 6;
            int butacasTurista = butacasAvion[0].FTurista * 6;
            int totalButacas = butacasBussines + butacasPrimera + butacasTurista;
            int columna = 0;
            int fila = 0;
            int contador = 0;

            // Un tableLayoutPanel que contendrá los botones.
            tlp = new TableLayoutPanel();
            tlp.AutoSize = true;
            tlp.ColumnCount = 6;
            fLPrincipal.Controls.Add(tlp);

            for (int i = 0; i < totalButacas; i++)
            {
                Button boton = new Button();
                boton.AutoSize = true;

                // 3 if que se encargarán de comprobar en que posición está el botón para asignarle su Letra adecuada.
                if (columna == 0 || columna == 5)
                {
                    if (columna == 0)
                    {
                        boton.Text += "V_I";
                    }
                    else
                    {
                        boton.Text += "V_D";
                    }
                }
                if (columna == 1 || columna == 4)
                {
                    if (columna == 1)
                    {
                        boton.Text += "C_I";
                    }
                    else
                    {
                        boton.Text += "C_D";
                    }
                }
                if (columna == 2 || columna == 3)
                {
                    if (columna == 2)
                    {
                        boton.Text += "P_I";
                    }
                    else
                    {
                        boton.Text += "P_D";
                    }
                }

                // Otros 3 if que se encargan de concatenar al nombre del botón si es Bussines, Primera o turista.
                if (contador < butacasBussines)
                {
                    boton.BackColor = Color.Green;
                    boton.Name = boton.Text + "_" + fila;
                    boton.Text = "B" + "_" + boton.Text + "_" + fila;
                    contador++;
                }
                else if (contador < (butacasPrimera + butacasBussines))
                {
                    boton.BackColor = Color.Yellow;
                    boton.Name = boton.Text + "_" + fila;
                    boton.Text = "Pr" + "_" + boton.Text + "_" + fila;
                    contador++;
                }
                else
                {
                    boton.BackColor = Color.Orange;
                    boton.Name = boton.Text + "_" + fila;
                    boton.Text = "T" + "_" + boton.Text + "_" + fila;
                    contador++;
                }

                // En este punto el nombre del boton sería algo como: V/C/P_I/D_Fila
                boton.Tag = boton.Text;
                boton.Click += Boton_Click;

                columna++;
                if (columna == 6)
                {
                    columna = 0;
                    fila += 1;
                }

                foreach (var item in listaFacturacion)
                {
                    if (item.IdAsiento == boton.Name)
                    {
                        if (item.Comprador.Equals(datosUsuario[0].Nombre))
                        {
                            boton.BackColor = Color.Blue;

                        }
                        else
                        {
                            boton.BackColor = Color.Red;
                            boton.Enabled = false;
                        }
                    }
                }

                tlp.Controls.Add(boton);
            }
        }

        private void Boton_Click(object sender, EventArgs e)
        {
            Button btnX = (Button)sender;

            if (listaReservas.Count < 5)
            {
                DateTime fechaActual = DateTime.Now; // Almaceno en la variable la fecha actual para usarla en el descuento.
                DateTime fechaSalida = DateTime.Parse(lblFechaSalida.Text); // Casteo la fecha de salida a datetime para luego poder restarlo.

                int precioTotal = int.Parse(lblPrecioTotal.Text);

                if (btnX.BackColor == Color.Green || btnX.BackColor == Color.Yellow || btnX.BackColor == Color.Orange)
                {
                    btnX.BackColor = Color.Pink;
                    listaReservas.Add(btnX.Tag.ToString());

                    if (btnX.Text.StartsWith("B"))
                    {
                        precioTotal += int.Parse(lblPrecioBussines.Text);
                    }
                    else if (btnX.Text.StartsWith("P"))
                    {
                        precioTotal += int.Parse(lblPrecioPrimera.Text);
                    }
                    else
                    {
                        precioTotal += int.Parse(lblPrecioTurista.Text);
                    }

                    btnComprarVuelo.Enabled = true;
                }
                else if (btnX.BackColor == Color.Pink)
                {
                    if (btnX.Text.StartsWith("B"))
                    {
                        btnX.BackColor = Color.Green;
                        precioTotal -= int.Parse(lblPrecioBussines.Text);
                    }
                    else if (btnX.Text.StartsWith("P"))
                    {
                        btnX.BackColor = Color.Yellow;
                        precioTotal -= int.Parse(lblPrecioPrimera.Text);
                    }
                    else
                    {
                        btnX.BackColor = Color.Orange;
                        precioTotal -= int.Parse(lblPrecioTurista.Text);
                    }
                    listaReservas.RemoveAt(listaReservas.IndexOf(btnX.Tag.ToString()));
                }
                else if (btnX.BackColor == Color.Blue)
                {
                    DialogResult cancelarButaca = MessageBox.Show("¿Deseas cancelar tu reserva?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (cancelarButaca == DialogResult.Yes)
                    {
                        int diasHastaSalida = (fechaSalida - fechaActual).Days;

                        if (diasHastaSalida < 5)
                        {
                            MessageBox.Show("Lo sentimos, no puedes cancelar tu reserva debido a que quedan menos de 5 días para la salida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int seleccion = comboBoxVuelos.SelectedIndex;
                            int idVuelo = listaHorarios[seleccion].IdVuelo;

                            String idAsiento = btnX.Tag.ToString();
                            idAsiento = idAsiento.Replace("B_", "").Replace("Pr_", "").Replace("T_", "");
                            int codigo = cnx.cancelarReservaButaca(idVuelo, idAsiento, usuarioActivo);

                            if (codigo == 1)
                            {
                                MessageBox.Show("Se ha cancelado tu reserva correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (btnX.Text.StartsWith("B"))
                                {
                                    btnX.BackColor = Color.Green;
                                }
                                else if (btnX.Text.StartsWith("P"))
                                {
                                    btnX.BackColor = Color.Yellow;
                                }
                                else
                                {
                                    btnX.BackColor = Color.Orange;
                                }
                            }
                        }
                    }

                    if (listaReservas.Count == 0)
                    {
                        btnComprarVuelo.Enabled = false;
                    }

                    lblPrecioTotal.Text = precioTotal.ToString();

                    int dias = (fechaSalida - fechaActual).Days; // Resto ambas fechas usando .Days para que tenga en cuenta los días.

                    if (dias > 15)  // Decrementa un 20%
                    {
                        double pDto = double.Parse(lblPrecioTotal.Text) * 0.20;
                        double pTotalDto = double.Parse(lblPrecioTotal.Text) - pDto;

                        lblPrecioTotalDTO.Text = pTotalDto.ToString();
                    }
                    else if (dias >= 10 && dias <= 14) // Incrementa un 15%
                    {
                        double pDto = double.Parse(lblPrecioTotal.Text) * 0.15;
                        double pTotalDto = double.Parse(lblPrecioTotal.Text) + pDto;

                        lblPrecioTotalDTO.Text = pTotalDto.ToString();
                    }
                    else if (dias >= 2 && dias <= 9) // Incrementa un 20%
                    {
                        double pDto = double.Parse(lblPrecioTotal.Text) * 0.20;
                        double pTotalDto = double.Parse(lblPrecioTotal.Text) + pDto;

                        lblPrecioTotalDTO.Text = pTotalDto.ToString();
                    }
                    else if (dias == 1) // Decrementa un 50%
                    {
                        double pDto = double.Parse(lblPrecioTotal.Text) * 0.50;
                        double pTotalDto = double.Parse(lblPrecioTotal.Text) - pDto;

                        lblPrecioTotalDTO.Text = pTotalDto.ToString();
                    }

                    int butacasBussines = butacasAvion[0].FBussines * 6;
                    int butacasPrimera = butacasAvion[0].FPrimera * 6;
                    int butacasTurista = butacasAvion[0].FTurista * 6;
                    int totalButacas = butacasBussines + butacasPrimera + butacasTurista;
                    double cantidadVendida = ((double)listaFacturacion.Count / totalButacas) * 100;

                    if (cantidadVendida > 80) // Si se han vendido más del 80% de los billetes se incrementa un 50% el precio anterior.
                    {
                        double pDto = double.Parse(lblPrecioTotalDTO.Text) * 0.5;
                        double pFinal = double.Parse(lblPrecioTotalDTO.Text) + pDto;
                        lblPrecioTotalDTO.Text = pFinal.ToString();
                    }
                    else if (cantidadVendida >= 50 && cantidadVendida <= 80) // Si se han vendido entre el 50% y 80% de los billetes se incrementan un 20% 
                    {
                        double pDto = double.Parse(lblPrecioTotalDTO.Text) * 0.2;
                        double pFinal = double.Parse(lblPrecioTotalDTO.Text) + pDto;
                        lblPrecioTotalDTO.Text = pFinal.ToString();
                    }
                    else if (cantidadVendida < 10) // Si se han vendido menos del 10% el precio se decrementa un 10%
                    {
                        double pDto = double.Parse(lblPrecioTotalDTO.Text) * 0.1;
                        double pFinal = double.Parse(lblPrecioTotalDTO.Text) - pDto;
                        lblPrecioTotalDTO.Text = pFinal.ToString();
                    }
                }

                timerButacaReservada.Start();
            } else
            {
                MessageBox.Show("Error, no puedes reservas más de 5 butacas a la vez.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnComprarVuelo_Click(object sender, EventArgs e)
        {
            timerButacaReservada.Stop();
            string claveQR = "";
            string mensaje = "¿Deseas realizar la compra de las siguientes butacas?\n";

            for (int i = 0; i < listaReservas.Count; i++)
            {
                mensaje += listaReservas[i] + "\n";
            }

            DialogResult confirmacion = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                int seleccion = comboBoxVuelos.SelectedIndex;
                int idVuelo = listaHorarios[seleccion].IdVuelo;
                bool compraExitosa = false;
                String idAsiento = "";

                for (int i = 0; i < listaReservas.Count; i++)
                {
                    String nombreBoton = listaReservas[i];
                    idAsiento = nombreBoton.Replace("B_", "").Replace("Pr_", "").Replace("T_", "");

                    int codigo = cnx.insertarFacturacion(idVuelo, idAsiento, usuarioActivo, DateTime.Now, lblPrecioTotalDTO.Text);

                    if (codigo == 1)
                    {
                        compraExitosa = true;
                    }
                }

                if (compraExitosa)
                {
                    MessageBox.Show("Compra realizada con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    foreach (Control ctrl in tlp.Controls)
                    {
                        for (int i = 0; i < listaReservas.Count; i++)
                        {
                            if (ctrl.Tag.ToString().Equals(listaReservas[i]))
                            {
                                ctrl.BackColor = Color.Blue;
                            }
                        }
                    }

                    // Crear QR
                    Random random = new Random();
                    int numAleatorio = random.Next(1000000, 9999999 + 1);
                    char letraAleatoria = (char)random.Next('A', 'Z' + 1);
                    claveQR = idVuelo + "x" + idAsiento + "x" + numAleatorio.ToString() + letraAleatoria;
                    generarCodigoQR(claveQR);
                }
                else
                {
                    MessageBox.Show("Error, no se ha podido realizar la compra...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                listaReservas.Clear();
                btnComprarVuelo.Enabled = false;
            }
            else
            {
                MessageBox.Show("Operación cancelada", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void generarCodigoQR(string claveQR)
        {
            string emailCliente = lblBienvenidaMail.Text;

            // Generate the QR code
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(claveQR, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            // Specify the folder path to save the QR code image
            string folderPath = @"C:\AerolineasQR";

            // Create the folder if it doesn't exist
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Save the QR code as a PNG image file inside the specified folder
            string fileName = Path.Combine(folderPath, claveQR + ".png");
            qrCodeImage.Save(fileName, ImageFormat.Png);

            mandarMail(fileName, emailCliente);
        }

        private void mandarMail(string archivoQR, string emailCliente)
        {
            try
            {
                string email = "aramoss27@educarex.es";
                string password = "porcnrrbaahrromt";

                var loginInfo = new NetworkCredential(email, password);

                var msg = new MailMessage();

                var smtpClient = new SmtpClient("smtp.gmail.com", 25);

                msg.From = new MailAddress("aramoss27@educarex.es");

                msg.To.Add(new MailAddress(emailCliente));

                msg.Body = "Se adjunta el PDF con el codigo QR de tu butaca.";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(archivoQR);
                msg.Attachments.Add(attachment);
                msg.IsBodyHtml = true;

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = loginInfo;

                smtpClient.Send(msg);

                smtpClient.Dispose();

                MessageBox.Show("Correo enviado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
            }
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            PerfilUsuario pS = new PerfilUsuario(datosUsuario);
            DialogResult modificar = pS.ShowDialog();

            if (modificar == DialogResult.OK)
            {
                datosUsuario = cnx.iniciarSesion(datosUsuario[0].Nombre, datosUsuario[0].Clave);
                lblBienvenidaMail.Text = "Correo: " + datosUsuario[0].Mail;
            }
        }

        private void timerButacaReservada_Tick(object sender, EventArgs e)
        {
            foreach (Control ctrl in tlp.Controls)
            {
                for (int i = 0; i < listaReservas.Count; i++)
                {
                    if (ctrl.Tag.ToString().Equals(listaReservas[i]))
                    {
                        if (ctrl.Text.StartsWith("B"))
                        {
                            ctrl.BackColor = Color.Green;
                        }
                        else if (ctrl.Text.StartsWith("P"))
                        {
                            ctrl.BackColor = Color.Yellow;
                        }
                        else
                        {
                            ctrl.BackColor = Color.Orange;
                        }
                    }
                }
            }

            listaReservas.Clear();
            timerButacaReservada.Stop();

            MessageBox.Show("Atención: Llevas más de 10 minutos ausente. Tus butacas ya no están reservadas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
