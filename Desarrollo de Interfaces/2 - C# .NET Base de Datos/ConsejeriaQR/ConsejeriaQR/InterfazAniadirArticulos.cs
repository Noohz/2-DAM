using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using QRCoder;

namespace ConsejeriaQR
{
    public class InterfazAniadirArticulos
    {
        String nombreImagen;
        ClaseConectar cnxIA;

        List<Control> listaControles;

        public InterfazAniadirArticulos(ClaseConectar cnxGP)
        {
            cnxIA = cnxGP;
        }

        public Panel generarPanelArticulos()
        {
            // Todo esto se generará de forma programmatically.
            // Panel que contendrá los Controls para introducir los datos del artículo.
            Panel panelArticulo = new Panel();
            panelArticulo.Location = new Point(149, 105);
            panelArticulo.Width = 775;
            panelArticulo.Height = 496;
            panelArticulo.BackColor = Color.White;

            // Label simplemente para contener el texto.
            Label lblImagenArticulo = new Label();
            lblImagenArticulo.Text = "Imágen del artículo";
            lblImagenArticulo.TextAlign = ContentAlignment.MiddleCenter;
            lblImagenArticulo.Location = new Point(91, 91);
            lblImagenArticulo.Width = 153;
            lblImagenArticulo.Height = 19;
            lblImagenArticulo.Font = new Font("Arial", 12, FontStyle.Bold);

            // PictureBox para que el usuario seleccione la imágen a añadir.
            PictureBox pBImagenArticulo = new PictureBox();
            pBImagenArticulo.Width = 140;
            pBImagenArticulo.Height = 93;
            pBImagenArticulo.Location = new Point(351, 35);
            pBImagenArticulo.BorderStyle = BorderStyle.FixedSingle;
            pBImagenArticulo.SizeMode = PictureBoxSizeMode.StretchImage;
            pBImagenArticulo.Click += PBImagenArticulo_Click;

            // Label simplemente para señalizar donde hay que hacer click...
            Label lblIndicadorImagen = new Label();
            lblIndicadorImagen.Text = "Click en el cuadrado para introducir una imágen";
            lblIndicadorImagen.TextAlign = ContentAlignment.MiddleCenter;
            lblIndicadorImagen.Location = new Point(292, 136);
            lblIndicadorImagen.Width = 269;
            lblIndicadorImagen.Height = 14;
            lblIndicadorImagen.Font = new Font("Arial", 8, FontStyle.Bold);

            // Label para contener el texto..
            Label lblNombreArticulo = new Label();
            lblNombreArticulo.Text = "Nombre del artículo";
            lblNombreArticulo.TextAlign = ContentAlignment.MiddleCenter;
            lblNombreArticulo.Location = new Point(91, 191);
            lblNombreArticulo.Width = 158;
            lblNombreArticulo.Height = 19;
            lblNombreArticulo.Font = new Font("Arial", 12, FontStyle.Bold);

            // TextBox en el que el usuario puede escribir el nombre del artículo.
            TextBox tBNombre = new TextBox();
            tBNombre.Multiline = true;
            tBNombre.Location = new Point(295, 191);
            tBNombre.Width = 442;
            tBNombre.Height = 26;

            // Label para contener el texto..
            Label lblDescripcionArticulo = new Label();
            lblDescripcionArticulo.Text = "Descripción del artículo";
            lblDescripcionArticulo.TextAlign = ContentAlignment.MiddleCenter;
            lblDescripcionArticulo.Location = new Point(91, 273);
            lblDescripcionArticulo.Width = 189;
            lblDescripcionArticulo.Height = 19;
            lblDescripcionArticulo.Font = new Font("Arial", 12, FontStyle.Bold);

            // TextBox en el que el usuario puede escribir la descripción del artículo.
            TextBox tBDescripcion = new TextBox();
            tBDescripcion.Multiline = true;
            tBDescripcion.Location = new Point(295, 243);
            tBDescripcion.Width = 442;
            tBDescripcion.Height = 88;

            // Último label para contener el texto..
            Label lblCodigoArticulo = new Label();
            lblCodigoArticulo.Text = "Código del artículo";
            lblCodigoArticulo.TextAlign = ContentAlignment.MiddleCenter;
            lblCodigoArticulo.Location = new Point(91, 363);
            lblCodigoArticulo.Width = 153;
            lblCodigoArticulo.Height = 19;
            lblCodigoArticulo.Font = new Font("Arial", 12, FontStyle.Bold);

            // TextBox en el que el usuario puede escribir el codigo del artículo.
            TextBox tBCodigo = new TextBox();
            tBCodigo.Multiline = true;
            tBCodigo.Location = new Point(295, 356);
            tBCodigo.Width = 442;
            tBCodigo.Height = 26;
            tBCodigo.ForeColor = Color.FromKnownColor(KnownColor.GrayText);
            tBCodigo.Text = "PJ: Llave_A1";
            tBCodigo.Enter += TBCodigo_Enter;
            tBCodigo.Leave += TBCodigo_Leave;

            // Un botón que será el que tendrá el evento que llamará al método para insertar el artículo en la tabla.
            Button btnCrearArticulo = new Button();
            btnCrearArticulo.FlatAppearance.MouseDownBackColor = Color.FromKnownColor(KnownColor.ControlDark);
            btnCrearArticulo.FlatAppearance.MouseOverBackColor = Color.FromKnownColor(KnownColor.ControlDark);
            btnCrearArticulo.FlatAppearance.BorderSize = 1;
            btnCrearArticulo.FlatStyle = FlatStyle.Flat;
            btnCrearArticulo.Font = new Font("Arial", 14, FontStyle.Bold);
            btnCrearArticulo.Location = new Point(305, 433);
            btnCrearArticulo.Width = 221;
            btnCrearArticulo.Height = 43;
            btnCrearArticulo.Text = "Crear artículo";

            listaControles = new List<Control> { lblImagenArticulo, pBImagenArticulo, lblIndicadorImagen, lblNombreArticulo, tBNombre, lblDescripcionArticulo, tBDescripcion, lblCodigoArticulo, tBCodigo, btnCrearArticulo };

            btnCrearArticulo.Click += (sender, e) => btnCrearArticulo_Click(tBNombre.Text, tBDescripcion.Text, tBCodigo.Text);

            panelArticulo.Controls.AddRange(listaControles.ToArray());

            return panelArticulo;
        }

        // Evento que se encarga de la funcionalidad de convertir la imágen que ha seleccionado el usuario a bytes, de crear tanto el codigo como la imágen QR y de insertarlo en la BD.
        private void btnCrearArticulo_Click(string nombreArticulo, string descripcionArticulo, string codigoArticulo)
        {
            PictureBox pbImg = (PictureBox)listaControles[1];

            if (pbImg.Image != null)
            {
                FileStream fs = new FileStream(nombreImagen, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] imagenArticulo = br.ReadBytes((int)fs.Length);

                if (!listaControles[4].Text.Equals("") || !listaControles[6].Text.Equals("") || !listaControles[8].Text.Equals("PJ: Llave_A1"))
                {
                    // Crear QR
                    Random random = new Random();
                    int numAleatorio = random.Next(100000000, 999999999 + 1);
                    char letraAleatoria = (char)random.Next('A', 'Z' + 1);
                    string claveQR = numAleatorio.ToString() + letraAleatoria;

                    while (cnxIA.comprobarQRExistente(claveQR))
                    {
                        // Si está repetido en la bd se genera otro código.
                        int nuevoNumAleatorio = random.Next(100000000, 999999999 + 1);
                        char nuevaLetraAleatoria = (char)random.Next('A', 'Z' + 1);
                        claveQR = nuevoNumAleatorio.ToString() + nuevaLetraAleatoria;
                    }

                    byte[] imagenQR = generarCodigoQR(claveQR);

                    if (cnxIA.insertarArticulo(nombreArticulo, descripcionArticulo, codigoArticulo, claveQR, imagenQR, imagenArticulo) == 1)
                    {
                        MessageBox.Show("El artículo se ha creado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pbImg.Image = null;
                        listaControles[4].Text = "";
                        listaControles[6].Text = "";
                        listaControles[8].Text = "PJ: Llave_A1";
                        listaControles[8].ForeColor = Color.FromKnownColor(KnownColor.GrayText);

                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error al insertar el artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Los campos 'Nombre del artículo', 'Descripción del artículo' y 'Código del artículo' deben estar completos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar una imágen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método que genera una imágen QR mediante la claveQR que se ha generdado al llamarlo.
        private byte[] generarCodigoQR(string claveQR)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(claveQR, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            MemoryStream ms = new MemoryStream();
            qrCodeImage.Save(ms, ImageFormat.Png);

            return ms.ToArray();
        }

        private void TBCodigo_Leave(object sender, EventArgs e)
        {
            TextBox tBX = (TextBox)sender;

            if (tBX.Text.Equals(""))
            {
                tBX.Text = "PJ: Llave_A1";
                tBX.ForeColor = Color.FromKnownColor(KnownColor.GrayText);
            }
        }

        private void TBCodigo_Enter(object sender, EventArgs e)
        {
            TextBox tBX = (TextBox)sender;
            tBX.Text = "";
            tBX.ForeColor = Color.FromKnownColor(KnownColor.WindowText);
        }

        // Evento que se encargará de almacenar la imágen que seleccione el usuario.
        private void PBImagenArticulo_Click(object sender, EventArgs e)
        {
            PictureBox pbX = (PictureBox)sender;

            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Imágenes | *.jpg; *.png";
            nombreImagen = opf.FileName;

            if (opf.ShowDialog() == DialogResult.OK)
            {
                nombreImagen = opf.FileName;
                pbX.Image = Image.FromFile(nombreImagen);
                pbX.BackgroundImage = Image.FromFile(nombreImagen);
            }
        }
    }
}
