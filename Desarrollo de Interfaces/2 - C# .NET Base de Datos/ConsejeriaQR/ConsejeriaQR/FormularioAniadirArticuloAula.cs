using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using QRCoder;

namespace ConsejeriaQR
{
    public partial class FormularioAniadirArticuloAula : Form
    {
        ClaseConectar cnxFAAA;
        public FormularioAniadirArticuloAula(string aulaSeleccionada, ClaseConectar cnxFGI)
        {
            InitializeComponent();

            this.Text = "Añadir artículo en " + aulaSeleccionada;

            tBAula.Text = aulaSeleccionada;
            cnxFAAA = cnxFGI;
        }

        /// <summary>
        /// Evento que maneja la acción de cancelar la operación.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que maneja la inserción del artículo en el aula.
        /// </summary>
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (comboTipoArticulo.SelectedIndex == -1 || comboEstado.SelectedIndex == -1 || string.IsNullOrEmpty(tBCaracteristicas.Text))
            {
                MessageBox.Show("Asegúrate de haber completado los campos 'Tipo Artículo', 'Estado' y 'Características'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string claveQR = GenerarClaveQRUnica();
            byte[] imagenQR = GenerarCodigoQR(claveQR);

            if (cnxFAAA.InsertarArticuloAula(tBAula.Text, comboTipoArticulo.Text, numericCantidad.Value,tBModelo.Text, tBCaracteristicas.Text, comboEstado.Text, claveQR, imagenQR) == 1)
            {
                MessageBox.Show("El artículo se ha almacenado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                comboTipoArticulo.SelectedIndex = -1;
                numericCantidad.Value = 1;
                tBModelo.Clear();
                comboEstado.SelectedIndex = -1;
                tBCaracteristicas.Clear();
            }
            else
            {
                MessageBox.Show("Hubo un error al insertar el artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Genera una clave QR única verificando que no exista en la base de datos.
        /// </summary>
        /// <returns> Una clave QR única. </returns>
        private string GenerarClaveQRUnica()
        {
            Random random = new Random();
            string claveQR;

            do
            {
                int numAleatorio = random.Next(100000000, 999999999 + 1);
                char letraAleatoria = (char)random.Next('A', 'Z' + 1);
                claveQR = numAleatorio.ToString() + letraAleatoria;
            } while (cnxFAAA.ComprobarQRExistente(claveQR));

            return claveQR;
        }

        /// <summary>
        /// Genera un código QR en formato de bytes[] a partir de una clave QR.
        /// </summary>
        /// <param name="claveQR"> La clave QR para generar el código. </param>
        /// <returns> El código QR en formato de bytes[]. </returns>
        private byte[] GenerarCodigoQR(string claveQR)
        {
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCode qrCode = new QRCode(qrGenerator.CreateQrCode(claveQR, QRCodeGenerator.ECCLevel.Q)))
            using (Bitmap qrCodeImage = qrCode.GetGraphic(20))
            using (MemoryStream ms = new MemoryStream())
            {
                qrCodeImage.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
