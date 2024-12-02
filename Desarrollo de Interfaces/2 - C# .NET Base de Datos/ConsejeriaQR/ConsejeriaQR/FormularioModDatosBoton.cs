using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;

namespace ConsejeriaQR
{
    public partial class FormularioModDatosBoton : Form
    {
        ClaseConectar cnxFMDB;
        Articulos datosArticulo;

        public FormularioModDatosBoton(object tag, ClaseConectar cnxIMA)
        {
            InitializeComponent();
            this.Text = "Panel modificar artículo";

            cnxFMDB = cnxIMA;

            datosArticulo = (Articulos)tag;

            // Se utilizan los datos del artículo para cargar los Controls de la interfaz.
            MemoryStream ms = new System.IO.MemoryStream(datosArticulo.Imagen);
            System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
            pictureBoxImgArticulo.Image = imagen;

            lblInfoArticulo.Text = datosArticulo.Nombre + " | " + datosArticulo.Codigo;

            textBoxIDArticulo.Text = datosArticulo.Id.ToString();
            textBoxNombreArticulo.Text = datosArticulo.Nombre;
            textBoxDescripcionArticulo.Text = datosArticulo.Descripcion;
            textBoxCodigoArticulo.Text = datosArticulo.Codigo;
            textBoxClaveQRArticulo.Text = datosArticulo.ClaveQR;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificarArticulo_Click(object sender, EventArgs e)
        {
            if (textBoxNombreArticulo.Text != datosArticulo.Nombre || textBoxDescripcionArticulo.Text != datosArticulo.Descripcion ||
                textBoxCodigoArticulo.Text != datosArticulo.Codigo || textBoxClaveQRArticulo.Text != datosArticulo.ClaveQR)
            {
                // Obtiene los datos modificados
                string nombreArticuloMod = textBoxNombreArticulo.Text;
                string descripcionArticuloMod = textBoxDescripcionArticulo.Text;
                string codigoArticuloMod = textBoxCodigoArticulo.Text;
                string claveQRArticuloMod = textBoxClaveQRArticulo.Text;
                byte[] imagenQR = datosArticulo.ImagenQR;

                // Comprobar si se ha modificado el codigoQR
                if (textBoxClaveQRArticulo.Text != datosArticulo.ClaveQR)
                {
                    // Si se ha modificado hay que comprobarlo por si ya existiese en la BBDD
                    if (cnxFMDB.ComprobarQRExistente(textBoxClaveQRArticulo.Text))
                    {
                        MessageBox.Show("Error, el código QR introducido no está disponible para usarse...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        // En el caso de que no exista se generaría la nueva imágenQR con ese código.
                        claveQRArticuloMod = textBoxClaveQRArticulo.Text;
                        imagenQR = GenerarImagenQR(claveQRArticuloMod);
                    }
                }

                // Se llama al método que realizará el Update con los nuevos datos.
                if (cnxFMDB.ModificarArticulo(textBoxIDArticulo.Text, nombreArticuloMod, descripcionArticuloMod, codigoArticuloMod, claveQRArticuloMod, imagenQR) == 1)
                {
                    MessageBox.Show("Artículo modificado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error, no se ha podido actualizar el artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se ha realizado ningún cambio al artículo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private byte[] GenerarImagenQR(string claveQR)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(claveQR, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            MemoryStream ms = new MemoryStream();
            qrCodeImage.Save(ms, ImageFormat.Png);

            return ms.ToArray();
        }
    }
}
