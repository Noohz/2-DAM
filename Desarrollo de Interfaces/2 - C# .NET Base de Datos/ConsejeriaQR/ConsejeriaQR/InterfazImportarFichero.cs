using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QRCoder;

namespace ConsejeriaQR
{
    /// <summary>
    /// Esta clase se encarga de la funcionalidad que permite al usuario importar articulos a la BBDD utilizando ficheros .CSV.
    /// </summary>
    internal class InterfazImportarFichero
    {
        ClaseConectar cnxiIF;
        private static string RUTA_CARPEA_IMAGEN = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "FotosPrestamo");

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
                Height = height - (height * 65 / 100),
                BackColor = Color.White
            };
            panelArticulo.Location = new Point((width - panelArticulo.Width) / 2, 100);

            Label lblTitulo = new Label
            {
                Text = "Importar datos mediante .CSV",
                TextAlign = ContentAlignment.MiddleCenter,
                Width = 350,
                Height = 40,
                Location = new Point((int)(panelArticulo.Width * 0.35), 80),
                Font = new Font("Arial", 16, FontStyle.Bold)
            };

            Label lblImportarArticulo = new Label
            {
                Text = "Selecciona la dirección del fichero .CSV",
                TextAlign = ContentAlignment.MiddleCenter,
                Width = 320,
                Height = 19,
                Location = new Point((int)(panelArticulo.Width * 0.15), 220),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };

            TextBox tBDirFichero = new TextBox
            {
                Width = 442,
                Height = 88,
                Location = new Point((int)(panelArticulo.Width * 0.43), 220),
                Enabled = false
            };

            Button btnInsertarFichero = new Button
            {
                Width = 40,
                Height = 23,
                Location = new Point((int)(panelArticulo.Width * 0.81), 220),
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
            btnImportarFichero.Location = new Point((int)(panelArticulo.Width * 0.40), 300);
            btnImportarFichero.Text = "Importar fichero";
            btnImportarFichero.Click += BtnImportarFichero_Click;

            listaControles = new List<Control> { lblTitulo, lblImportarArticulo, tBDirFichero, btnInsertarFichero, btnImportarFichero };

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
                Height = height - (height * 50 / 100),
                BackColor = Color.White
            };
            panelDatosBD.Location = new Point((width - panelDatosBD.Width) / 2, 470);

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
            DataGridView comboDGV = (DataGridView)listaControlesDB[1];

            if (articulosFichero.Count == 0)
            {
                MessageBox.Show("No hay datos para importar. Por favor, selecciona un archivo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                cnxiIF.InsertarArticuloFichero(articulosFichero);
                MessageBox.Show("Artículos importados correctamente en la base de datos.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                listaControles[2].Text = "";

                listaArticulosDGV = cnxiIF.ObtenerArticulosDGV();
                comboDGV.DataSource = null;
                comboDGV.DataSource = listaArticulosDGV;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error al intentar importar el fichero:\n {ex.Message}");
            }
        }

        /// <summary>
        /// Evento para insertar un fichero CSV y procesar sus datos.
        /// </summary>
        private void BtnInsertarFichero_Click(object sender, EventArgs e)
        {
            articulosFichero.Clear();

            // Validar que la carpeta de imágenes existe o crearla
            if (!ValidarCarpetaImagenes())
            {
                return;
            }

            // Abrir diálogo para seleccionar archivo CSV
            string dirArchivo = ObtenerRutaArchivoCSV();
            if (string.IsNullOrEmpty(dirArchivo))
                return;

            // Procesar el archivo seleccionado
            ProcesarArchivoCSV(dirArchivo);
        }

        /// <summary>
        /// Verifica la existencia de la carpeta de imágenes o la crea si no existe.
        /// </summary>
        /// <returns> True si la carpeta existe o ha sido creada correctamente, False en caso de error. </returns>
        private bool ValidarCarpetaImagenes()
        {
            if (!Directory.Exists(RUTA_CARPEA_IMAGEN))
            {
                try
                {
                    Directory.CreateDirectory(RUTA_CARPEA_IMAGEN);
                    MessageBox.Show($"La carpeta 'FotosPrestamo' no existía y ha sido creada en: {RUTA_CARPEA_IMAGEN}. " +
                                    "Por favor, asegúrate de tener las imágenes necesarias en esa carpeta antes de intentar insertar los datos de un fichero.",
                                    "Carpeta no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al crear la carpeta:\n\n {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Muestra un cuadro de diálogo para seleccionar un archivo CSV.
        /// </summary>
        /// <returns> La ruta del archivo seleccionado o null si se cancela la selección. </returns>
        private string ObtenerRutaArchivoCSV()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos CSV (*.csv)|*.csv",
                Title = "Seleccionar archivo .CSV"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            else
            {
                MessageBox.Show("Por favor, selecciona antes el archivo .CSV.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Procesa las líneas del archivo CSV y genera una lista de artículos.
        /// </summary>
        /// <param name="dirArchivo"> Ruta completa del archivo CSV. </param>
        private void ProcesarArchivoCSV(string dirArchivo)
        {
            try
            {
                var lineas = File.ReadAllLines(dirArchivo).Skip(1); // Un skip para que se salte la primera línea del .CSV que es la cabecera
                int numeroLinea = 2;

                foreach (var linea in lineas)
                {
                    string claveQR = GenerarClaveQRUnica();
                    if (ProcesarLineaCSV(linea, claveQR, numeroLinea))
                    {
                        numeroLinea++;
                    }
                }

                listaControles[2].Text = dirArchivo;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al importar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Procesa una línea específica del archivo CSV.
        /// </summary>
        /// <param name="linea"> Texto de la línea a procesar. </param>
        /// <param name="claveQR"> Clave QR generada para el artículo. </param>
        /// <param name="numeroLinea"> Número de la línea en el archivo para referencia en caso de error. </param>
        /// <returns> True si la línea fue procesada correctamente, False si ocurrió un error. </returns>
        private bool ProcesarLineaCSV(string linea, string claveQR, int numeroLinea)
        {
            try
            {
                var datos = linea.Split(',');

                if (datos.Length < 6)
                {
                    MessageBox.Show($"Datos incompletos en la línea {numeroLinea}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string nombre = datos[0];
                string categoria = datos[1];
                string descripcion = datos[2];
                string codigo = datos[3];
                string estado = datos[4];
                string nombreImagen = datos[5].Trim();

                string rutaImagenCompleta = Path.Combine(RUTA_CARPEA_IMAGEN, nombreImagen);
                byte[] imagenArticulo = CargarImagenArticulo(rutaImagenCompleta, numeroLinea);
                if (imagenArticulo == null)
                {
                    return false;
                }                    

                bool mantenimiento = estado.Equals("Mantenimiento", StringComparison.OrdinalIgnoreCase);

                Articulos articulo = new Articulos
                {
                    Nombre = nombre,
                    Categoria = categoria,
                    Descripcion = descripcion,
                    Codigo = codigo,
                    ClaveQR = claveQR,
                    ImagenQR = GenerarImagenQR(claveQR),
                    Imagen = imagenArticulo,
                    Mantenimiento = mantenimiento
                };

                articulosFichero.Add(articulo);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error procesando la línea {numeroLinea}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Genera una clave QR única.
        /// </summary>
        /// <returns> Una clave QR generada aleatoriamente. </returns>
        private string GenerarClaveQRUnica()
        {
            Random random = new Random();
            string claveQR;

            do
            {
                int numAleatorio = random.Next(100000000, 999999999 + 1);
                char letraAleatoria = (char)random.Next('A', 'Z' + 1);
                claveQR = numAleatorio.ToString() + letraAleatoria;
            } while (cnxiIF.ComprobarQRExistente(claveQR));

            return claveQR;
        }

        /// <summary>
        /// Carga una imagen desde el sistema de archivos.
        /// </summary>
        /// <param name="rutaImagen"> Ruta completa de la imagen. </param>
        /// <param name="numeroLinea"> Número de línea para referencia en caso de error. </param>
        /// <returns> byte[] con el contenido de la imagen o null si ocurre un error. </returns>
        private byte[] CargarImagenArticulo(string rutaImagen, int numeroLinea)
        {
            if (File.Exists(rutaImagen))
            {
                return File.ReadAllBytes(rutaImagen);
            }
            else
            {
                MessageBox.Show($"No se encontró la imagen: {rutaImagen} (Línea {numeroLinea})", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
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
    }
}
