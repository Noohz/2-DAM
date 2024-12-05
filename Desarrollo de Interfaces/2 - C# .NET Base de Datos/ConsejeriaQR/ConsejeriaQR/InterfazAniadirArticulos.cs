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
        List<Control> listaControlesDB;
        List<ArticulosDGV> listaArticulosDGV = new List<ArticulosDGV>();
        List<string> categorias;

        public InterfazAniadirArticulos(ClaseConectar cnxGP, List<string> CATEGORIAS_PRESTAMO)
        {
            cnxIA = cnxGP;
            categorias = CATEGORIAS_PRESTAMO;
        }

        public Panel GenerarPanelAniadirArticulos(int width, int height)
        {
            // Panel que contendrá los Controls para introducir los datos del artículo.
            Panel panelArticulo = new Panel
            {
                Width = (int)(width * 0.85),
                Height = (int)(height * 0.56),
                BackColor = Color.White
            };
            panelArticulo.Location = new Point((width - panelArticulo.Width) / 2, 50);

            // Label simplemente para contener el texto.
            Label lblImagenArticulo = new Label
            {
                Text = "Imágen del artículo",
                TextAlign = ContentAlignment.MiddleCenter,
                Width = 153,
                Height = 19,
                Location = new Point((int)(panelArticulo.Width * 0.15), 110),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };

            // PictureBox para que el usuario seleccione la imágen a añadir.
            PictureBox pBImagenArticulo = new PictureBox
            {
                Width = 200,
                Height = 180,
                Location = new Point((int)(panelArticulo.Width * 0.5), 35),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            pBImagenArticulo.Click += PBImagenArticulo_Click;

            // Label simplemente para señalizar donde hay que hacer click...
            Label lblIndicadorImagen = new Label
            {
                Text = "Click en el cuadrado para introducir una imágen",
                TextAlign = ContentAlignment.MiddleCenter,
                Width = 269,
                Height = 14,
                Location = new Point((int)(panelArticulo.Width * 0.47), 220),
                Font = new Font("Arial", 8, FontStyle.Bold)
            };

            // Label para contener el texto..
            Label lblNombreArticulo = new Label
            {
                Text = "Nombre del artículo",
                TextAlign = ContentAlignment.MiddleCenter,
                Width = 158,
                Height = 19,
                Location = new Point((int)(panelArticulo.Width * 0.15), 245),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };

            // TextBox en el que el usuario puede escribir el nombre del artículo.
            TextBox tBNombre = new TextBox
            {
                Width = 442,
                Height = 26,
                Location = new Point((int)(panelArticulo.Width * 0.40), 245)
            };

            Label lblCategoríaArticulo = new Label
            {
                Text = "Categoría del artículo",
                TextAlign = ContentAlignment.MiddleCenter,
                Width = 178,
                Height = 19,
                Location = new Point((int)(panelArticulo.Width * 0.147), 285),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };

            ComboBox cBCategoria = new ComboBox
            {
                Width = 442,
                Height = 30,
                Location = new Point((int)(panelArticulo.Width * 0.40), 285),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Label para contener el texto..
            Label lblDescripcionArticulo = new Label
            {
                Text = "Descripción del artículo",
                TextAlign = ContentAlignment.MiddleCenter,
                Width = 189,
                Height = 19,
                Location = new Point((int)(panelArticulo.Width * 0.15), 355),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };

            // TextBox en el que el usuario puede escribir la descripción del artículo.
            TextBox tBDescripcion = new TextBox
            {
                Multiline = true,
                Width = 442,
                Height = 88,
                Location = new Point((int)(panelArticulo.Width * 0.40), 320)
            };

            // Último label para contener el texto..
            Label lblCodigoArticulo = new Label
            {
                Text = "Código del artículo",
                TextAlign = ContentAlignment.MiddleCenter,
                Width = 153,
                Height = 19,
                Location = new Point((int)(panelArticulo.Width * 0.15), 425),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };

            // TextBox en el que el usuario puede escribir el codigo del artículo.
            TextBox tBCodigo = new TextBox
            {
                Multiline = true,
                Width = 442,
                Height = 26,
                Location = new Point((int)(panelArticulo.Width * 0.40), 420),
                ForeColor = Color.FromKnownColor(KnownColor.GrayText),
                Text = "PJ: Llave_A1"
            };
            tBCodigo.Enter += TBCodigo_Enter;
            tBCodigo.Leave += TBCodigo_Leave;

            // Un botón que será el que tendrá el evento que llamará al método para insertar el artículo en la tabla.
            Button btnCrearArticulo = new Button();
            btnCrearArticulo.FlatAppearance.MouseDownBackColor = Color.FromKnownColor(KnownColor.ControlDark);
            btnCrearArticulo.FlatAppearance.MouseOverBackColor = Color.FromKnownColor(KnownColor.ControlDark);
            btnCrearArticulo.FlatAppearance.BorderSize = 1;
            btnCrearArticulo.FlatStyle = FlatStyle.Flat;
            btnCrearArticulo.Font = new Font("Arial", 14, FontStyle.Bold);
            btnCrearArticulo.Width = 221;
            btnCrearArticulo.Height = 43;
            btnCrearArticulo.Location = new Point((int)(panelArticulo.Width * 0.40), 490);
            btnCrearArticulo.Text = "Crear artículo";

            listaControles = new List<Control> { lblImagenArticulo, pBImagenArticulo, lblIndicadorImagen, lblNombreArticulo, tBNombre, 
                lblCategoríaArticulo, cBCategoria, lblDescripcionArticulo, tBDescripcion, lblCodigoArticulo, tBCodigo, btnCrearArticulo };

            foreach (var categoria in categorias)
            {
                cBCategoria.Items.Add(categoria);
            }

            btnCrearArticulo.Click += (sender, e) => BtnCrearArticulo_Click(tBNombre.Text, tBDescripcion.Text, tBCodigo.Text);

            panelArticulo.Controls.AddRange(listaControles.ToArray());

            return panelArticulo;
        }

        // Método que generará un Panel para almacenar un DataGridView que contendrá los artículos de la BD.
        public Panel GenerarPanelDatosArticulosBD(int width, int height)
        {
            Panel panelDatosBD = new Panel
            {
                Width = (int)(width * 0.85),
                Height = (int)(height * 0.35),
                BackColor = Color.White
            };
            panelDatosBD.Location = new Point((width - panelDatosBD.Width) / 2, 610);

            Label lblTituloBD = new Label
            {
                Font = new Font("Arial", 12, FontStyle.Bold),
                Text = "Artículos actuales registrados",
                AutoSize = true,
                Location = new Point((int)(panelDatosBD.Width * 0.4), 5)
            };

            DataGridView dGVArticulos = new DataGridView
            {
                Width = (int)(panelDatosBD.Width * 0.95),
                Height = (int)(panelDatosBD.Height * 0.85),
                Location = new Point((int)(panelDatosBD.Width * 0.03), 40),
                EditMode = DataGridViewEditMode.EditProgrammatically,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                Enabled = false
            };

            listaControlesDB = new List<Control> { lblTituloBD, dGVArticulos };

            panelDatosBD.Controls.AddRange(listaControlesDB.ToArray());

            listaArticulosDGV = cnxIA.ObtenerArticulosDGV();
            dGVArticulos.DataSource = listaArticulosDGV;

            return panelDatosBD;
        }

        /// <summary>
        /// Maneja la creación de un artículo, generando un código QR y almacenando la información en la base de datos.
        /// </summary>
        /// <param name="nombreArticulo"> El nombre del artículo. </param>
        /// <param name="descripcionArticulo"> La descripción del artículo. </param>
        /// <param name="codigoArticulo"> El código del artículo. </param>
        private void BtnCrearArticulo_Click(string nombreArticulo, string descripcionArticulo, string codigoArticulo)
        {
            PictureBox pbImg = (PictureBox)listaControles[1];
            ComboBox cBCategoria = (ComboBox)listaControles[6];
            DataGridView comboDGV = (DataGridView)listaControlesDB[1];

            if (pbImg.Image == null)
            {
                MostrarMensajeError("Debes seleccionar una imagen.");
                return;
            }

            if (string.IsNullOrWhiteSpace(nombreArticulo) || string.IsNullOrWhiteSpace(descripcionArticulo) 
                || string.IsNullOrWhiteSpace(codigoArticulo) || cBCategoria.SelectedIndex < 0)
            {
                MostrarMensajeError("Los campos 'Nombre del artículo', 'Descripción del artículo' y 'Código del artículo' deben estar completos.");
                return;
            }

            try
            {
                byte[] imagenArticulo = ConvertirImagenABytes(pbImg.Image);
                string claveQR = GenerarClaveQRUnica();
                byte[] imagenQR = GenerarCodigoQR(claveQR);

                int resultado = cnxIA.InsertarArticulo(nombreArticulo, cBCategoria.Text, descripcionArticulo, codigoArticulo, claveQR, imagenQR, imagenArticulo);

                if (resultado == 1)
                {
                    MostrarMensajeConfirmacion("El artículo se ha creado correctamente.");
                    LimpiarFormulario();
                    ActualizarListaArticulos(comboDGV);
                }
                else
                {
                    MostrarMensajeError("Ha ocurrido un error al insertar el artículo.");
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Ocurrió un error inesperado: {ex.Message}");
            }
        }

        /// <summary>
        /// Convierte una imagen de PictureBox en un byte[].
        /// </summary>
        /// <param name="imagen"> La imagen a convertir. </param>
        /// <returns> El byte[] que representa la imagen. </returns>
        private byte[] ConvertirImagenABytes(Image imagen)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imagen.Save(ms, ImageFormat.Png);
                return ms.ToArray();
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
            } while (cnxIA.ComprobarQRExistente(claveQR));

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

        /// <summary>
        /// Limpia el formulario después de crear el artículo.
        /// </summary>
        private void LimpiarFormulario()
        {
            PictureBox pbImg = (PictureBox)listaControles[1];
            ComboBox cBCategoria = (ComboBox)listaControles[6];

            pbImg.Image = null;
            listaControles[4].Text = "";
            cBCategoria.SelectedIndex = -1;
            listaControles[8].Text = "";
            listaControles[10].Text = "PJ: Llave_A1";
            listaControles[10].ForeColor = Color.FromKnownColor(KnownColor.GrayText);
        }

        /// <summary>
        /// Actualiza la lista de artículos mostrada en un DataGridView.
        /// </summary>
        /// <param name="comboDGV"> El DataGridView a actualizar. </param>
        private void ActualizarListaArticulos(DataGridView comboDGV)
        {
            comboDGV.DataSource = null;
            comboDGV.DataSource = cnxIA.ObtenerArticulosDGV();
        }

        /// <summary>
        /// Muestra un mensaje de error al usuario.
        /// </summary>
        /// <param name="mensaje"> El mensaje de error. </param>
        private void MostrarMensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Muestra un mensaje de confirmación al usuario.
        /// </summary>
        /// <param name="mensaje"> El mensaje de confirmación. </param>
        private void MostrarMensajeConfirmacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        /// <summary>
        /// Se encarga de almacenar la imágen que introduce el usuario
        /// </summary>
        private void PBImagenArticulo_Click(object sender, EventArgs e)
        {
            PictureBox pbX = (PictureBox)sender;

            OpenFileDialog opf = new OpenFileDialog
            {
                Filter = "Imágenes | *.jpg; *.png"
            };

            if (opf.ShowDialog() == DialogResult.OK)
            {
                nombreImagen = opf.FileName;
                pbX.Image = Image.FromFile(nombreImagen);
            }
        }
    }
}
