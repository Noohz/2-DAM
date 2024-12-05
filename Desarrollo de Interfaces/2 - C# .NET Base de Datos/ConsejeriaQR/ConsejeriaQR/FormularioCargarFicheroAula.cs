using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using QRCoder;

namespace ConsejeriaQR
{
    public partial class FormularioCargarFicheroAula : Form
    {
        private static Random random = new Random();

        ClaseConectar cnxFCF;
        string nombreAula;

        private List<ArticulosAula> articulosFicheroAula = new List<ArticulosAula>();

        public FormularioCargarFicheroAula(string aulaSeleccionada, ClaseConectar cnxFGI)
        {
            InitializeComponent();

            this.Text = "Cargar fichero .CSV para " + aulaSeleccionada;

            cnxFCF = cnxFGI;
            nombreAula = aulaSeleccionada;
        }

        /// <summary>
        /// Maneja el evento de clic en el botón para seleccionar un archivo CSV.
        /// Limpia la lista de artículos y llama al proceso para obtener y procesar el archivo CSV seleccionado.
        /// </summary>
        private void btnSeleccionarFichero_Click(object sender, EventArgs e)
        {
            articulosFicheroAula.Clear();

            string dirArchivo = ObtenerRutaArchivoCSV();
            if (string.IsNullOrEmpty(dirArchivo))
            {
                return;
            }

            ProcesarArchivoCSV(dirArchivo);
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

                tBDirArchivo.Text = dirArchivo;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al importar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Genera una clave QR única, asegurando que no exista ni en la base de datos ni en los artículos a importar.
        /// </summary>
        /// <returns>Una clave QR generada aleatoriamente.</returns>
        private string GenerarClaveQRUnica()
        {
            string claveQR;

            do
            {
                int numAleatorio = random.Next(100000000, 999999999 + 1);
                char letraAleatoria = (char)random.Next('A', 'Z' + 1);
                claveQR = numAleatorio.ToString() + letraAleatoria;

            } while (cnxFCF.ComprobarQRExistenteAula(claveQR) || articulosFicheroAula.Any(a => a.CodigoQR == claveQR));

            return claveQR;
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

                if (datos.Length < 4)
                {
                    MessageBox.Show($"Datos incompletos en la línea {numeroLinea}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string tipoArticulo = datos[0];
                int cantidad = int.Parse(datos[1]);
                string modelo = datos[2];
                string caracteristica = datos[3];
                string estado = datos[4];

                ArticulosAula articulo = new ArticulosAula
                {
                    Aula = nombreAula,
                    TipoArticulo = tipoArticulo,
                    Cantidad = cantidad,
                    Modelo = modelo,
                    Caracteristicas = caracteristica,
                    Estado = estado,
                    CodigoQR = claveQR,
                    ImagenQR = GenerarImagenQR(claveQR)
                };

                articulosFicheroAula.Add(articulo);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error procesando la línea {numeroLinea}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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

        /// <summary>
        /// Maneja el evento de clic en el botón para importar los artículos cargados desde el archivo CSV a la base de datos.
        /// Verifica que haya artículos en la lista y, si es así, llama al método para insertar los datos en la base de datos.
        /// </summary>
        private void btnImportarFichero_Click(object sender, EventArgs e)
        {
            if (articulosFicheroAula.Count == 0)
            {
                MessageBox.Show("No hay datos para importar. Por favor, selecciona un archivo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                cnxFCF.InsertarFicheroAula(articulosFicheroAula);
                MessageBox.Show("Artículos importados correctamente en la base de datos.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tBDirArchivo.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error al intentar importar el fichero:\n {ex.Message}");
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de salida, cerrando el formulario actual.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
