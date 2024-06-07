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
        List<String> listaPDFs = new List<string>();
        List<Horariosaviones> listaHorariosDescuento = new List<Horariosaviones>();

        string usuarioActivo; // Variable que contiene el usuario de la sesión activo.
        string emailCliente;
        TableLayoutPanel tlp;
        int puntosFidelidad;
        string imgLogotipo = "./img/Iberia-logo.jpg";
        bool oferton = false;
        DateTime fechaSalida;
        bool compraExitosa = false;
        int cont = 1;

        public ReservarVuelo(List<Usuariosavion> listaUsuario)
        {
            InitializeComponent();
            this.Text = "Reservar Vuelo";
            datosUsuario = listaUsuario;
            lblBienvenida.Text = "Bienvenido/a: " + datosUsuario[0].Nombre;
            usuarioActivo = datosUsuario[0].Nombre;
            lblBienvenidaMail.Text = "Correo: " + datosUsuario[0].Mail;
            emailCliente = datosUsuario[0].Mail;

            MemoryStream ms = new MemoryStream(datosUsuario[0].Imagen);
            pBImgUser.BackgroundImage = System.Drawing.Image.FromStream(ms);
            pBImgUser.BackgroundImageLayout = ImageLayout.Stretch;


            listaPDFs.Clear();

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

            listaHorariosDescuento = cnx.obtenerSesionAvionesDescuento();
            foreach (var horario in listaHorariosDescuento)
            {
                lBDescuentos.Items.Add(horario.IdVuelo + "-" + horario.Ruta + "-" + horario.FechaSalida.ToString("dd-MM-yyyy"));
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
            listaPDFs.Clear();
            usuarioActivo = "";
            this.Close();
        }

        private void comboBoxVuelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSeguimientoVuelo.Visible = false;
            listaReservas.Clear();
            lblPrecioTotal.Text = "0";
            lblPrecioTotalDTO.Text = "0";
            gBDatosTicket.Visible = true;

            // Obtener el item seleccionado del comboBox.
            ComboBox cB = (ComboBox)sender;
            int seleccion = cB.SelectedIndex;

            listaFacturacion.Clear();

            // Uso el item para establecer las cantidades relacionadas con los datos del comboBox.
            lblPrecioTurista.Text = listaHorariosActivos[seleccion].PrecioTurista.ToString();
            lblPrecioBussines.Text = listaHorariosActivos[seleccion].PrecioBussines.ToString();
            lblIdAvion.Text = listaHorariosActivos[seleccion].IdAvion.ToString();
            lblFechaSalida.Text = listaHorariosActivos[seleccion].FechaSalida.ToString();
            fechaSalida = DateTime.Parse(listaHorariosActivos[seleccion].FechaSalida.ToString("yyyy-MM-dd"));
            lblTrayecto.Text = listaHorariosActivos[seleccion].Ruta.ToString();
            lblDuracion.Text = listaHorariosActivos[seleccion].MinutosVuelo.ToString();

            // Configuración del FlowLayoutPanel y los botones.
            butacasAvion.Clear();

            listaFacturacion = cnx.obtenerButacasOcupadas(listaHorariosActivos[seleccion].IdVuelo);
            lblAsientosVendidos.Text = listaFacturacion.Count.ToString();

            // Guardo en una lista el resultado de la consulta pasandole el ID del avión para que me devuelva los datos del avión.
            butacasAvion = cnx.obtenerButacasAvion(listaHorariosActivos[seleccion].IdAvion);
            MemoryStream ms = new MemoryStream(butacasAvion[0].Imagen);
            pBModeloAvion.BackgroundImage = System.Drawing.Image.FromStream(ms);
            pBModeloAvion.BackgroundImageLayout = ImageLayout.Stretch;

            string ruta = lblTrayecto.Text;
            string[] datos = ruta.Split('-');
            string salida = datos[0];
            string destino = datos[1];

            foreach (Aeropuertos s in datosAeropuertos)
            {
                if (s.Id.Equals(salida))
                {
                    MemoryStream imgSalida = new MemoryStream(s.Imagen);
                    pBImgSalida.BackgroundImage = System.Drawing.Image.FromStream(imgSalida);
                    pBImgSalida.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else if (s.Id.Equals(destino))
                {
                    MemoryStream imgDestino = new MemoryStream(s.Imagen);
                    pBImgDestino.BackgroundImage = System.Drawing.Image.FromStream(imgDestino);
                    pBImgDestino.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }

            // Guardo en una variable el contenido de cada butaca para usarlo a la hora de crear el TableLayoutPanel.
            int butacasBussines = butacasAvion[0].FBussines * 6;
            lblAsientosBussines.Text = butacasBussines.ToString();
            lblFilasBussines.Text = butacasAvion[0].FBussines.ToString();
            int butacasTurista = butacasAvion[0].FTurista * 6;
            lblAsientosTurista.Text = butacasTurista.ToString();
            lblFilasTuristas.Text = butacasAvion[0].FTurista.ToString();
            int totalButacas = butacasBussines + butacasTurista;
            lblAsientosTotales.Text = totalButacas.ToString();

            DateTime fechaActual = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));

            int dias = (fechaSalida - fechaActual).Days;

            if (dias <= 3)
            {
                btnSeguimientoVuelo.Visible = true;
            }
        }

        private void calcularPrecioFinal()
        {
            DateTime fechaActual = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));

            int dias = (fechaSalida - fechaActual).Days;

            for (int i = 0; i < dias; i++)
            {
                double pDto = double.Parse(lblPrecioTotal.Text) * 0.01;
                double pTotalDto = double.Parse(lblPrecioTotal.Text) - pDto;

                lblPrecioTotalDTO.Text = pTotalDto.ToString();
            }
        }

        private void btnComprarVuelo_Click(object sender, EventArgs e)
        {
            timerButacaReservada.Stop();
            string claveQR = "";
            string mensaje = "¿Deseas realizar la compra de " + cBCantidad.Text + " butacas de la clase " + cBCategoria.Text + "?";
            DialogResult confirmacion = DialogResult.No;
            int cantidadAsientos = int.Parse(cBCantidad.Text);

            if (cBCantidad.SelectedIndex != -1 && cBCategoria.SelectedIndex != -1)
            {
                confirmacion = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                MessageBox.Show("Error, debes de seleccionar el número de asientos y su categoría...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (confirmacion == DialogResult.Yes)
            {
                int asientosVendidos = int.Parse(lblAsientosVendidos.Text);
                if ((cantidadAsientos + asientosVendidos) > int.Parse(lblAsientosTotales.Text))
                {
                    MessageBox.Show("Error, no hay suficientes asientos libres para realizar la compra...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int seleccion = comboBoxVuelos.SelectedIndex;
                    int idVuelo = listaHorariosActivos[seleccion].IdVuelo;
                    

                    for (int i = 0; i < cantidadAsientos; i++)
                    {
                        // Crear QR
                        Random random = new Random();
                        int numAleatorio = random.Next(100000000, 999999999 + 1);
                        char letraAleatoria = (char)random.Next('A', 'Z' + 1);
                        claveQR = numAleatorio.ToString() + letraAleatoria;

                        while (cnx.comprobarQRExistente(claveQR))
                        {
                            // Si está repetido en la bd se genera otro código.
                            int nuevoNumAleatorio = random.Next(100000000, 999999999 + 1);
                            char nuevaLetraAleatoria = (char)random.Next('A', 'Z' + 1);
                            claveQR = nuevoNumAleatorio.ToString() + nuevaLetraAleatoria;
                        }
                        calcularPrecioFinal();

                        if (oferton)
                        {
                            double pDto = double.Parse(lblPrecioTotal.Text) * 0.50;
                            lblPrecioTotalDTO.Text = pDto.ToString();
                        }
                        String idAsiento = claveQR.ToString();
                        int codigo = cnx.insertarFacturacion(idVuelo, idAsiento, usuarioActivo, DateTime.Now, lblPrecioTotalDTO.Text, claveQR);

                        if (codigo == 1)
                        {
                            compraExitosa = true;
                        }

                        if (compraExitosa) {
                            generarPdf(generarCodigoQR(claveQR), claveQR);
                        }
                    }

                    if (compraExitosa)
                    {
                        MessageBox.Show("Compra realizada con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mandarMail(listaPDFs, emailCliente);
                    }
                    else
                    {
                        MessageBox.Show("Error, no se ha podido realizar la compra...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    listaPDFs.Clear();
                    listaReservas.Clear();
                    compraExitosa = false;
                }
            }
            else
            {
                MessageBox.Show("Operación cancelada", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private Bitmap generarCodigoQR(string claveQR)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(claveQR, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            string folderPath = @"C:\AerolineasQR";

            // Crear la carpeta si no existe
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = Path.Combine(folderPath, claveQR + ".png");
            qrCodeImage.Save(fileName, ImageFormat.Png);

            return qrCodeImage;
        }

        private void mandarMail(List<string> listaPDFs, string emailCliente)
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
                msg.IsBodyHtml = true;

                foreach (var pdf in listaPDFs)
                {
                    System.Net.Mail.Attachment attachmentPDF = new System.Net.Mail.Attachment(pdf);
                    msg.Attachments.Add(attachmentPDF);
                }

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

        private void generarPdf(Bitmap codigoQR, string claveQR)
        {
            // LOGOTIPO EMPRESA
            FileStream fs = new FileStream(this.imgLogotipo, FileMode.Open, FileAccess.Read);
            iTextSharp.text.Image imgLogotipo = iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromStream(fs), System.Drawing.Imaging.ImageFormat.Jpeg);
            imgLogotipo.ScaleToFit(300, 300);
            imgLogotipo.Alignment = Element.ALIGN_CENTER;

            // IMAGEN QR
            iTextSharp.text.Image qrImage = iTextSharp.text.Image.GetInstance(codigoQR, ImageFormat.Png);
            qrImage.ScaleToFit(150, 150);
            qrImage.Alignment = Element.ALIGN_CENTER;

            // IMAGEN USUARIO
            MemoryStream ms = new MemoryStream(datosUsuario[0].Imagen);
            System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
            iTextSharp.text.Image usrImg = iTextSharp.text.Image.GetInstance(imagen, ImageFormat.Png);
            usrImg.ScaleToFit(150, 150);

            string rutaVuelo = lblTrayecto.Text;
            string[] datos = rutaVuelo.Split('-');
            string salida = datos[0];
            string destino = datos[1];
            iTextSharp.text.Image salidaImg = null;
            iTextSharp.text.Image destinoImg = null;

            foreach (Aeropuertos s in datosAeropuertos)
            {
                if (s.Id.Equals(salida))
                {
                    // IMAGEN SALIDA
                    MemoryStream ms1 = new MemoryStream(s.Imagen);
                    System.Drawing.Image imagenSalida = System.Drawing.Image.FromStream(ms1);
                    salidaImg = iTextSharp.text.Image.GetInstance(imagenSalida, ImageFormat.Png);
                    salidaImg.ScaleToFit(100, 100);
                }
                else if (s.Id.Equals(destino))
                {
                    // IMAGEN DESTINO
                    MemoryStream ms2 = new MemoryStream(s.Imagen);
                    System.Drawing.Image imagenDestino = System.Drawing.Image.FromStream(ms2);
                    destinoImg = iTextSharp.text.Image.GetInstance(imagenDestino, ImageFormat.Png);
                    destinoImg.ScaleToFit(100, 100);
                }
            }

            String nombrePDF = "CodigoQR "+ cont + " " + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
            String asunto = "Código QR";

            string folderPath = @"C:\AerolineasPDF";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (FileStream stream = new FileStream(Path.Combine(folderPath, nombrePDF + ".pdf"), FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                pdfDoc.Add(imgLogotipo);

                pdfDoc.Add(usrImg);
                pdfDoc.Add(new Paragraph(lblBienvenida.Text));
                pdfDoc.Add(new Paragraph("Le adjuntamos el código QR para su próximo embarque."));
                pdfDoc.Add(new Paragraph("\n"));
                pdfDoc.Add(new Paragraph("La fecha de salida programada para su vuelo es: " + fechaSalida.ToString("yyyy-MM-dd")));
                pdfDoc.Add(new Paragraph("El importe ha pagar es de: " + lblPrecioTotalDTO.Text + " con una ruta " + lblTrayecto.Text));
                pdfDoc.Add(new Paragraph("\n"));

                pdfDoc.Add(new Paragraph("Salida: " + salida));
                pdfDoc.Add(salidaImg);
                pdfDoc.Add(new Paragraph("Destino: " + destino));
                pdfDoc.Add(destinoImg);

                pdfDoc.Add(new Paragraph(asunto, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD)) { Alignment = Element.ALIGN_CENTER });
                pdfDoc.Add(qrImage);
                pdfDoc.Add(new Paragraph(claveQR) { Alignment = Element.ALIGN_CENTER });

                pdfDoc.Close();
                stream.Close();
            }

            String ruta = folderPath + "\\" + nombrePDF + ".pdf";
            listaPDFs.Add(ruta);
            cont++;
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            PerfilUsuario pS = new PerfilUsuario(datosUsuario);
            DialogResult modificar = pS.ShowDialog();

            if (modificar == DialogResult.OK)
            {
                datosUsuario = cnx.iniciarSesion(datosUsuario[0].Nombre, datosUsuario[0].Clave);
                lblBienvenidaMail.Text = "Correo: " + datosUsuario[0].Mail;

                MemoryStream ms = new MemoryStream(datosUsuario[0].Imagen);
                pBImgUser.BackgroundImage = System.Drawing.Image.FromStream(ms);
                pBImgUser.BackgroundImageLayout = ImageLayout.Stretch;
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

        private void lBDescuentos_MouseClick(object sender, MouseEventArgs e)
        {
            string s = lBDescuentos.SelectedItem.ToString();

            string[] datos = s.Split('-');

            string idVuelo = datos[0].Trim();
            string rutaS = datos[1].Trim();
            string rutaD = datos[2].Trim();
            string rutaCompleta = datos[1] + "-" + datos[2];
            string dia = datos[3].Trim();
            string mes = datos[4].Trim();
            string anio = datos[5].Trim();
            string fechaSalida = datos[5] + "-" + datos[4] + "-" + datos[3];

            int cont = 0;

            foreach (var horarios in listaHorariosActivos)
            {
                if (idVuelo == horarios.IdVuelo.ToString() && rutaCompleta == horarios.Ruta && fechaSalida == horarios.FechaSalida.ToString("yyyy-MM-dd"))
                {
                    comboBoxVuelos.SelectedIndex = cont;
                    oferton = true;
                }
                cont++;
            }
        }

        private void btnSeguimientoVuelo_Click(object sender, EventArgs e)
        {
            Embarque embarcar = new Embarque(cnx, listaFacturacion, listaHorariosActivos);
            embarcar.ShowDialog();
        }
    }
}
