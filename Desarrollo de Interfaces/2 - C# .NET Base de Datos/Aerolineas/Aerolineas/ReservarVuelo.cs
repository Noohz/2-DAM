using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using QRCoder;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Diagnostics;

namespace Aerolineas
{
    public partial class ReservarVuelo : Form
    {
        ClaseConectar cnx = new ClaseConectar();

        List<Horariosaviones> listaHorarios = new List<Horariosaviones>(); // Lista que contiene los horarios de los aviones.
        List<Horariosaviones> listaHorariosActivos = new List<Horariosaviones>(); // Lista que contiene los horarios activos de los aviones.
        List<ModeloAvion> butacasAvion = new List<ModeloAvion>(); // Lista que contiene la cantidad de butacas de cada tipo.
        List<String> listaReservas = new List<string>(); // Lista que contiene las butacas que se han hecho click.
        List<Billeteavion> listaFacturacion = new List<Billeteavion>(); // Lista que contiene las bútacas vendidas.
        List<Usuariosavion> datosUsuario = new List<Usuariosavion>(); // Lista que contiene los datos del usuario activo.
        List<Aeropuertos> datosAeropuertos = new List<Aeropuertos>(); // Lista que coaantiene los datos de los aeropuertos.

        string usuarioActivo; // Variable que contiene el usuario de la sesión activo.
        TableLayoutPanel tlp;
        int puntosFidelidad;

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
                if (horarios.FechaSalida >= DateTime.Now)
                {
                    comboBoxVuelos.Items.Add(horarios.IdVuelo + " " + horarios.Ruta + " " + horarios.FechaSalida);
                    listaHorariosActivos.Add(horarios);
                }
            }

            calcularPuntosFidelidadUsuario(listaHorarios);

            datosAeropuertos = cnx.obtenerDatosAeropuertos();

            foreach (var rutas in datosAeropuertos)
            {
                cBRuta1CNR.Items.Add(rutas.Id);
                cBRuta2CNR.Items.Add(rutas.Id);
            }
        }

        private void calcularPuntosFidelidadUsuario(List<Horariosaviones> listaHorarios)
        {
            List<int> idVuelosAnteriores = new List<int>(); // Lista que contiene la id de los vuelos que ya han salido.
            int billetesComprados = 0;

            foreach (var horarios in listaHorarios)
            {
                if (horarios.FechaSalida < DateTime.Now)
                {
                    idVuelosAnteriores.Add(horarios.IdVuelo);
                }
            }

            foreach (var ids in idVuelosAnteriores)
            {
                billetesComprados = cnx.obtenerBilletesComprados(ids, usuarioActivo);
                puntosFidelidad += billetesComprados;
            }

            lblPuntosFidelidad.Text = puntosFidelidad.ToString();
        }

        private void btnCerrarReserva_Click(object sender, EventArgs e)
        {
            int seleccion = 0;
            int idVuelo = 0;

            if (comboBoxVuelos.SelectedIndex != -1)
            {
                seleccion = comboBoxVuelos.SelectedIndex;
                idVuelo = listaHorarios[seleccion].IdVuelo;

                foreach (Control ctrl in tlp.Controls)
                {
                    for (int i = 0; i < listaReservas.Count; i++)
                    {
                        if (ctrl.Tag.ToString().Equals(listaReservas[i]))
                        {
                            String idAsiento = ctrl.Tag.ToString();
                            idAsiento = idAsiento.Replace("B_", "").Replace("Pr_", "").Replace("T_", "");
                            cnx.cancelarButacaTemporal(idVuelo, idAsiento, usuarioActivo);
                        }
                    }
                }
            }

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

            listaFacturacion = cnx.obtenerButacasOcupadas(listaHorariosActivos[seleccion].IdVuelo);

            // Guardo en una lista el resultado de la consulta pasandole el ID del avión para que me devuelva los datos del avión.
            butacasAvion = cnx.obtenerButacasAvion(listaHorariosActivos[seleccion].IdAvion);
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

            int seleccion = comboBoxVuelos.SelectedIndex;
            int idVuelo = listaHorarios[seleccion].IdVuelo;

            String idAsiento = btnX.Tag.ToString();
            idAsiento = idAsiento.Replace("B_", "").Replace("Pr_", "").Replace("T_", "");

            if (listaReservas.Count < 5)
            {
                DateTime fechaActual = DateTime.Now; // Almaceno en la variable la fecha actual para usarla en el descuento.
                DateTime fechaSalida = DateTime.Parse(lblFechaSalida.Text); // Casteo la fecha de salida a datetime para luego poder restarlo.

                int precioTotal = int.Parse(lblPrecioTotal.Text);

                if (btnX.BackColor == Color.Green || btnX.BackColor == Color.Yellow || btnX.BackColor == Color.Orange)
                {
                    btnX.BackColor = Color.Pink;
                    listaReservas.Add(btnX.Tag.ToString());

                    if (cnx.comprobarButacaReservadaTemporal(idVuelo, idAsiento))
                    {
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

                        MessageBox.Show("Error, la butaca seleccionada está reservada por otro usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        cnx.reservarButacaTemporal(idVuelo, idAsiento, usuarioActivo);
                        timerButacaReservada.Start();

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
                    cnx.cancelarButacaTemporal(idVuelo, idAsiento, usuarioActivo);
                    timerButacaReservada.Stop();
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
            }
            else
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

                    // Crear QR
                    Random random = new Random();
                    int numAleatorio = random.Next(100000000, 999999999 + 1);
                    char letraAleatoria = (char)random.Next('A', 'Z' + 1);
                    claveQR = numAleatorio.ToString() + letraAleatoria;

                    while (cnx.comprobarQRExistente(claveQR)) {
                        // Si está repetido en la bd se genera otro código.
                        int nuevoNumAleatorio = random.Next(100000000, 999999999 + 1);
                        char nuevaLetraAleatoria = (char)random.Next('A', 'Z' + 1);
                        claveQR = nuevoNumAleatorio.ToString() + nuevaLetraAleatoria;
                    }

                    int codigo = cnx.insertarFacturacion(idVuelo, idAsiento, usuarioActivo, DateTime.Now, lblPrecioTotalDTO.Text, claveQR);

                    if (codigo == 1)
                    {
                        compraExitosa = true;

                        foreach (Control ctrl in tlp.Controls)
                        {
                            if (ctrl.Tag.ToString().Equals(listaReservas[i]))
                            {
                                String asientoReservado = ctrl.Tag.ToString();
                                asientoReservado = asientoReservado.Replace("B_", "").Replace("Pr_", "").Replace("T_", "");
                                cnx.cancelarButacaTemporal(idVuelo, asientoReservado, usuarioActivo);
                            }
                        }                        
                        generarCodigoQR(claveQR);
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

        // PENDIENTE => Rayuela
        // Que el método devuelva el pdf y que ese pdf contenga el qr que se le envía al correo.
        private String generarPdf()
        {
            // Descargamos la imágen.
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(nA.Foto1);
            MemoryStream ms = new MemoryStream(bytes);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

            // La convertimos de System.Drawing a iTextSharp para poder utilizarla en el pdf.
            iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(img, System.Drawing.Imaging.ImageFormat.Jpeg);

            String nombrePDF = "";
            String fecha = DateTime.Now.ToString("dd-MM-yyyy");
            String asunto = "";
            bool pdfCreado = false;

            if (dGV.Name.Equals("dGVCalif"))
            {
                nombrePDF = "Calificaciones " + fecha;
                asunto = "Calificaciones";

            }
            else if (dGV.Name.Equals("dGVAsis"))
            {
                nombrePDF = "Faltas de Asistencia " + fecha;
                asunto = "Faltas de Asistencia";
            }

            PdfPTable pdfTable = new PdfPTable(dGV.ColumnCount);

            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;

            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;

            pdfTable.DefaultCell.BorderWidth = 1;

            foreach (DataGridViewColumn column in dGV.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            foreach (DataGridViewRow row in dGV.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    try
                    {
                        pdfTable.AddCell(cell.Value.ToString());
                    }
                    catch { }
                }
            }

            string folderPath = @"C:\AerolineasQR";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (FileStream stream = new FileStream(folderPath + "" + nombrePDF + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                pdfDoc.Add(png);

                pdfDoc.Add(new Paragraph("Nombre: " + nA.Nombre1));
                pdfDoc.Add(new Paragraph("Correo: " + nA.Mail1));
                pdfDoc.Add(new Paragraph("Identificador: " + nA.Identificador1));
                pdfDoc.Add(new Paragraph("Curso: " + nA.Curso1 + " " + nA.Ciclo1));
                pdfDoc.Add(new Paragraph("\n"));

                pdfDoc.Add(new Paragraph(asunto, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD)) { Alignment = Element.ALIGN_CENTER });
                pdfDoc.Add(new Paragraph("\n"));

                pdfDoc.Add(pdfTable);

                pdfDoc.Close();
                stream.Close();

                pdfCreado = true;
            }

            String ruta = folderPath + "" + nombrePDF + ".pdf";

            if (pdfCreado == true)
            {
                MessageBox.Show("PDF con el nombre: " + nombrePDF + " creado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Process p1 = new Process();
                p1.StartInfo.FileName = ruta;
                p1.Start();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error a la hora de crear el Pdf.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ruta;
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
            int seleccion = comboBoxVuelos.SelectedIndex;
            int idVuelo = listaHorarios[seleccion].IdVuelo;

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

                        String idAsiento = ctrl.Tag.ToString();
                        idAsiento = idAsiento.Replace("B_", "").Replace("Pr_", "").Replace("T_", "");
                        cnx.cancelarButacaTemporal(idVuelo, idAsiento, usuarioActivo);
                    }
                }
            }

            listaReservas.Clear();
            timerButacaReservada.Stop();

            MessageBox.Show("Atención: Llevas más de 30 segundos ausente. Tus butacas ya no están reservadas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dateTimePickerFechaSalidaVuelo_ValueChanged(object sender, EventArgs e)
        {
            if (cBRuta1CNR.SelectedIndex != -1 && cBRuta2CNR.SelectedIndex != -1)
            {
                string ruta = cBRuta1CNR.Text + "-" + cBRuta2CNR.Text;
                String fechaBuscada = dateTimePickerFechaSalidaVuelo.Value.ToString("yyyy-MM-dd");
                int cont = 0;

                foreach (var datos in listaHorariosActivos)
                {
                    if (ruta == datos.Ruta && fechaBuscada == datos.FechaSalida.ToString("yyyy-MM-dd"))
                    {
                        comboBoxVuelos.SelectedIndex = cont;
                    }
                    cont++;
                }
            }            
        }
    }
}
