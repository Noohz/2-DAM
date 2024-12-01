using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using QRCoder;

namespace ConsejeriaQR
{
    /// <summary>
    /// Esta clase se encarga de la funcionalidad que permite al usuario importar articulos a la BBDD utilizando ficheros .CSV.
    /// </summary>
    internal class InterfazImportarFichero
    {
        String nombreImagen;
        ClaseConectar cnxiIF;

        private List<Control> listaControles;
        private List<Control> listaControlesDB;
        private List<Articulos> articulosFichero = new List<Articulos>();
        private List<ArticulosDGV> listaArticulosDGV = new List<ArticulosDGV>();

        public InterfazImportarFichero(ClaseConectar cnxGP)
        {
            this.cnxiIF = cnxGP;
        }

        /// <summary>
        /// Método que se encarga de generar el primer panel que contiene los Controls para añadir los artículos.
        /// </summary>
        /// <param name="width"> Width del panel padre usada para la colocación de los Controls. </param>
        /// <param name="height"> Height del panel padre usada para la colocación de los Controls. </param>
        /// <returns> El panel ya con los controls creados. </returns>
        public Panel GenerarPanelImportarFichero(int width, int height)
        {
            Image imgBotonFichero = Properties.Resources.folder;

            Panel panelArticulo = new Panel
            {
                Width = width - (width * 30 / 100),
                Height = height - (height * 45 / 100),
                BackColor = Color.White
            };
            panelArticulo.Location = new Point((width - panelArticulo.Width) / 2, 100);

            Label lblImagenArticulo = new Label
            {
                Text = "Imágen de los artículo",
                TextAlign = ContentAlignment.MiddleCenter,
                Width = 193,
                Height = 19,
                Location = new Point((int)(panelArticulo.Width * 0.15), 110),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };

            PictureBox pBImagenArticulo = new PictureBox
            {
                Width = 200,
                Height = 180,
                Location = new Point((int)(panelArticulo.Width * 0.5), 35),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            pBImagenArticulo.Click += PBImagenArticulo_Click;

            Label lblIndicadorImagen = new Label
            {
                Text = "Click en el cuadrado para introducir una imágen",
                TextAlign = ContentAlignment.MiddleCenter,
                Width = 269,
                Height = 14,
                Location = new Point((int)(panelArticulo.Width * 0.47), 220),
                Font = new Font("Arial", 8, FontStyle.Bold)
            };

            Label lblImportarArticulo = new Label
            {
                Text = "Selecciona la dirección del fichero .CSV",
                TextAlign = ContentAlignment.MiddleCenter,
                Width = 320,
                Height = 19,
                Location = new Point((int)(panelArticulo.Width * 0.15), 335),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };

            TextBox tBDirFichero = new TextBox
            {
                Width = 442,
                Height = 88,
                Location = new Point((int)(panelArticulo.Width * 0.43), 335),
                Enabled = false
            };

            Button btnInsertarFichero = new Button
            {
                Width = 40,
                Height = 23,
                Location = new Point((int)(panelArticulo.Width * 0.81), 333),
                BackgroundImageLayout = ImageLayout.Stretch,
                BackgroundImage = imgBotonFichero,

            };
            btnInsertarFichero.FlatAppearance.BorderSize = 1;
            btnInsertarFichero.Click += BtnInsertarFichero_Click;

            Button btnImportarFichero = new Button();
            btnImportarFichero.FlatAppearance.MouseDownBackColor = Color.FromKnownColor(KnownColor.ControlDark);
            btnImportarFichero.FlatAppearance.MouseOverBackColor = Color.FromKnownColor(KnownColor.ControlDark);
            btnImportarFichero.FlatAppearance.BorderSize = 1;
            btnImportarFichero.FlatStyle = FlatStyle.Flat;
            btnImportarFichero.Font = new Font("Arial", 14, FontStyle.Bold);
            btnImportarFichero.Width = 221;
            btnImportarFichero.Height = 43;
            btnImportarFichero.Location = new Point((int)(panelArticulo.Width * 0.40), 490);
            btnImportarFichero.Text = "Importar fichero";
            btnImportarFichero.Click += BtnImportarFichero_Click;

            listaControles = new List<Control> { lblImagenArticulo, pBImagenArticulo, lblIndicadorImagen, lblImportarArticulo, tBDirFichero, btnInsertarFichero, btnImportarFichero };

            panelArticulo.Controls.AddRange(listaControles.ToArray());

            return panelArticulo;
        }

        /// <summary>
        /// Método que se encarga de generar el panel que contiene el DataGridView que permite visualizar los artículos actuales en la BBDD.
        /// </summary>
        /// <param name="width"> Width del panel padre usada para la colocación de los Controls. </param>
        /// <param name="height"> Height del panel padre usada para la colocación de los Controls. </param>
        /// <returns> El panel ya con los controls creados. </returns>
        public Panel GenerarPanelDatosArticulosBD(int width, int height)
        {
            Panel panelDatosBD = new Panel
            {
                Width = width - (width * 30 / 100),
                Height = height - (height * 70 / 100),
                BackColor = Color.White
            };
            panelDatosBD.Location = new Point((width - panelDatosBD.Width) / 2, 680);

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
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            };

            listaControlesDB = new List<Control> { lblTituloBD, dGVArticulos };

            panelDatosBD.Controls.AddRange(listaControlesDB.ToArray());

            listaArticulosDGV = cnxiIF.ObtenerArticulosDGV();
            dGVArticulos.DataSource = listaArticulosDGV;

            return panelDatosBD;
        }

        /// <summary>
        /// Evento que se encarga de realizar la llamada a la ClaseConectar para realizar la consulta SQL e insertar los artículos del fichero.
        /// </summary>
        /// <param name="sender"> Control que ha llamado al evento. </param>
        /// <param name="e"> Los argumentos del evento. </param>
        private void BtnImportarFichero_Click(object sender, EventArgs e)
        {
            PictureBox imgArticulo = (PictureBox)listaControles[1];
            DataGridView comboDGV = (DataGridView)listaControlesDB[1];

            if (articulosFichero.Count == 0)
            {
                MessageBox.Show("No hay datos para importar. Por favor, selecciona un archivo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                cnxiIF.InsertarArticuloFichero(articulosFichero);
                MessageBox.Show("Artículos importados correctamente en la base de datos.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                imgArticulo.Image = null;
                listaControles[4].Text = "";

                listaArticulosDGV = cnxiIF.ObtenerArticulosDGV();
                comboDGV.DataSource = null;
                comboDGV.DataSource = listaArticulosDGV;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al importar fichero: {ex.Message}");
            }
        }

        /// <summary>
        /// Evento que se encarga de cargar los datos del fichero .CSV y guardarlos en una lista par autilizarlos después.
        /// </summary>
        /// <param name="sender"> Control que ha llamado al evento. </param>
        /// <param name="e"> Los argumentos del evento. </param>
        private void BtnInsertarFichero_Click(object sender, EventArgs e)
        {
            articulosFichero.Clear();

            PictureBox imgArticulo = (PictureBox)listaControles[1];
            string claveQR;

            if (imgArticulo.Image != null)
            {
                FileStream fs = new FileStream(nombreImagen, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] imagenArticulo = br.ReadBytes((int)fs.Length);

                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Archivos CSV (*.csv)|*.csv",
                    Title = "Seleccionar archivo .CSV"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string dirArchivo = openFileDialog.FileName;

                    try
                    {
                        var linea = File.ReadAllLines(dirArchivo).Skip(1);

                        Random random = new Random();

                        foreach (var line in linea)
                        {
                            int numAleatorio = random.Next(100000000, 999999999 + 1);
                            char letraAleatoria = (char)random.Next('A', 'Z' + 1);
                            claveQR = numAleatorio.ToString() + letraAleatoria;

                            while (cnxiIF.ComprobarQRExistente(claveQR))
                            {
                                int nuevoNumAleatorio = random.Next(100000000, 999999999 + 1);
                                char nuevaLetraAleatoria = (char)random.Next('A', 'Z' + 1);
                                claveQR = nuevoNumAleatorio.ToString() + nuevaLetraAleatoria;
                            }

                            byte[] imagenQR = GenerarImagenQR(claveQR);

                            var datos = line.Split(',');

                            if (datos.Length >= 4)
                            {
                                string nombre = datos[0];
                                string descripcion = datos[1];
                                string codigo = datos[2];
                                string estado = datos[3];

                                bool mantenimiento = estado.Trim().Equals("Mantenimiento", StringComparison.OrdinalIgnoreCase) ? true : false;

                                Articulos articulo = new Articulos
                                {
                                    Nombre = nombre,
                                    Descripcion = descripcion,
                                    Codigo = codigo,
                                    ClaveQR = claveQR,
                                    ImagenQR = imagenQR,
                                    Imagen = imagenArticulo,
                                    Mantenimiento = mantenimiento
                                };

                                articulosFichero.Add(articulo);
                            }
                        }

                        listaControles[4].Text = dirArchivo;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al importar datos: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona antes la imágen de los artículos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Método que genera una imágen QR a partir del código QR generado que recibe por parámetros.
        /// </summary>
        /// <param name="claveQR"> Código que se ha generado antes de la llamada al método y asegurado de que es único. </param>
        /// <returns> ms => Que contiene la imágen ya convertida para almacenarla en la BBDD para el artículo. </returns>
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

        private void PBImagenArticulo_Click(object sender, EventArgs e)
        {
            PictureBox pbX = (PictureBox)sender;

            OpenFileDialog opf = new OpenFileDialog
            {
                Filter = "Imágenes | *.jpg; *.png"
            };
            nombreImagen = opf.FileName;

            if (opf.ShowDialog() == DialogResult.OK)
            {
                nombreImagen = opf.FileName;
                pbX.Image = Image.FromFile(nombreImagen);
            }
        }
    }
}
