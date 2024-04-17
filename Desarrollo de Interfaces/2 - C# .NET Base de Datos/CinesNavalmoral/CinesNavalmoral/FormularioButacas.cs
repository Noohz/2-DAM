using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace CinesNavalmoral
{
    public partial class FormularioButacas : Form
    {
        ClaseConectar cnx = new ClaseConectar();
        List<ClaseFacturacionCine> listaFacturacion = new List<ClaseFacturacionCine>();
        List<String> listaReservas = new List<string>();

        public FormularioButacas(string titulo, string sesion, string sala)
        {
            InitializeComponent();

            this.Text = "Película: " + titulo;

            lblTitulo.Text = titulo;
            lblNSala.Text = sala;
            lblSesion.Text = sesion;

            int[] arrayButacas = cnx.TotalButacas(sala);
            int totalButacas = arrayButacas[0] * arrayButacas[1];

            lblNTotalButacas.Text = totalButacas.ToString();

            // Lista con la información de los asientos ocupados.
            listaFacturacion = cnx.ButacasOcupadas(sala, sesion);

            int numButacasLibres = Convert.ToInt16(lblNTotalButacas.Text) - listaFacturacion.Count;
            lblNButacasLibres.Text = numButacasLibres.ToString();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormularioButacas_Load(object sender, EventArgs e)
        {
            cargarButacas(listaFacturacion);
        }

        private void cargarButacas(List<ClaseFacturacionCine> listaFacturacion)
        {
            int salaActual = Convert.ToInt16(lblNSala.Text);
            int[] arrayButacas = cnx.TotalButacas(lblNSala.Text);

            int totalButacas = arrayButacas[0] * arrayButacas[1];

            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.AutoSize = true;
            tlp.RowCount = arrayButacas[0];
            tlp.ColumnCount = arrayButacas[1];
            tlp.Padding = new Padding(100, 10, 0, 0);
            flPrincipal.Controls.Add(tlp);

            for (int filas = 0; filas < arrayButacas[0]; filas++)
            {
                for (int columnas = 0; columnas < arrayButacas[1]; columnas++)
                {
                    Button botonButaca = new Button();
                    botonButaca.Tag = filas + "," + columnas;
                    botonButaca.Width = 30;
                    botonButaca.Height = 20;
                    botonButaca.BackColor = Color.Green;
                    botonButaca.Margin = new Padding(5, 3, 25, 5);
                    botonButaca.Click += BotonButaca_Click;

                    // Añadir las butacas ocupadas.               
                    foreach (var facturacion in listaFacturacion)
                    {
                        if (facturacion.Fila == filas && facturacion.Columna == columnas)
                        {
                            botonButaca.BackColor = Color.Red;
                            botonButaca.Enabled = false;
                            break;
                        }
                    }

                    // Añadir el boton al TLP.
                    tlp.Controls.Add(botonButaca);
                }
            }
        }

        private void BotonButaca_Click(object sender, EventArgs e)
        {
            Button btnX = (Button)sender;

            if (btnX.BackColor == Color.Green)
            {
                btnX.BackColor = Color.Blue;
                btnPagar.Enabled = true;

                // Añadir a la lista de reserva el tag del botón seleccionado.
                // Por ejemplo Fila/Columna: 10,5
                listaReservas.Add(btnX.Tag.ToString());
            }
            else
            {
                btnX.BackColor = Color.Green;

                // Cuando el botón vuelva al color verde (Que el cliente ya no quiere esa butaca) se elimina del array.
                listaReservas.RemoveAt(listaReservas.IndexOf(btnX.Tag.ToString()));

                if (listaReservas.Count == 0)
                {
                    btnPagar.Enabled = false;
                }
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            string[] butaca = new string[2];
            string claveQR = "";

            string mensaje = "¿Deseas realizar la compra de las siguientes butacas?\n";

            foreach (string compra in listaReservas) // Un foreach para recorrer la lista de reservas.
            {
                butaca = compra.Split(','); // Un array para almacenar los datos que estaban separados por una coma. (ANTES: 0","1 >> AHORA: 0 , 1).

                string fila = butaca[0];
                string columna = butaca[1];
                mensaje += "Fila: " + fila + ", Columna: " + columna + "\n";
            }

            DialogResult confirmacion = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                foreach (string compra in listaReservas)
                {
                    butaca = compra.Split(',');

                    string fila = butaca[0];
                    string columna = butaca[1];

                    cnx.InsertarFacturacion(Convert.ToInt16(lblNSala.Text), Convert.ToInt16(butaca[0]), Convert.ToInt16(butaca[1]), lblSesion.Text);

                    claveQR = lblSesion.Text.Replace(":", "_") + fila + columna + lblNSala.Text;

                    generarCodigoQR(claveQR);
                }

                listaReservas.Clear();
                btnPagar.Enabled = false;
                this.Close();
            }
            else
            {
                MessageBox.Show("Operación cancelada", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void generarCodigoQR(string claveQR)
        {
            String emailCliente = "";

            // Generate the QR code
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(claveQR, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            // Specify the folder path to save the QR code image
            string folderPath = @"C:\CinesaQR";

            // Create the folder if it doesn't exist
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Save the QR code as a PNG image file inside the specified folder
            string fileName = Path.Combine(folderPath, claveQR + "_" + "QRCode.png");
            qrCodeImage.Save(fileName, ImageFormat.Png);

            DialogResult email = MessageBox.Show("¿Deseas recibir un correo con el código QR de tu entrada?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (email == DialogResult.Yes)
            {
                FormularioEmail fmE = new FormularioEmail(fileName);
                DialogResult correo = fmE.ShowDialog();

                if (correo == DialogResult.OK)
                {
                    emailCliente = fmE.textoTB;
                }

                mandarMail(fileName, emailCliente);
            }
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

                msg.Body = "Se adjunta el PDF con el codigo QR de tu entrada.";

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
                this.Close();
            }
            catch (Exception)
            {
                

            }
        }
    }
}
