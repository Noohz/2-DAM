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
        List<articulosDGV> listaArticulosDGV = new List<articulosDGV>();
        List<String> listaNombreArticulos = new List<string> { "Llaves de aula", "Llaves de armarios de ordenadores", "Mandos de proyectores", "Lápiz tablet", "Cables de tablet" };

        public InterfazAniadirArticulos(ClaseConectar cnxGP)
        {
            cnxIA = cnxGP;
        }

        public Panel generarPanelAniadirArticulos(int width, int height)
        {
            // Todo esto se generará de forma programmatically.
            // Panel que contendrá los Controls para introducir los datos del artículo.
            Panel panelArticulo = new Panel();
            panelArticulo.Width = width - (width * 30 / 100);
            panelArticulo.Height = height - (height * 45 / 100);
            panelArticulo.BackColor = Color.White;
            panelArticulo.Location = new Point((width - panelArticulo.Width) / 2, 100);

            // Label simplemente para contener el texto.
            Label lblImagenArticulo = new Label();
            lblImagenArticulo.Text = "Imágen del artículo";
            lblImagenArticulo.TextAlign = ContentAlignment.MiddleCenter;            
            lblImagenArticulo.Width = 153;
            lblImagenArticulo.Height = 19;
            lblImagenArticulo.Location = new Point((int)(panelArticulo.Width * 0.15), 110);
            lblImagenArticulo.Font = new Font("Arial", 12, FontStyle.Bold);

            // PictureBox para que el usuario seleccione la imágen a añadir.
            PictureBox pBImagenArticulo = new PictureBox();
            pBImagenArticulo.Width = 200;
            pBImagenArticulo.Height = 180;
            pBImagenArticulo.Location = new Point((int)(panelArticulo.Width * 0.5), 35);
            pBImagenArticulo.BorderStyle = BorderStyle.FixedSingle;
            pBImagenArticulo.SizeMode = PictureBoxSizeMode.StretchImage;
            pBImagenArticulo.Click += PBImagenArticulo_Click;

            // Label simplemente para señalizar donde hay que hacer click...
            Label lblIndicadorImagen = new Label();
            lblIndicadorImagen.Text = "Click en el cuadrado para introducir una imágen";
            lblIndicadorImagen.TextAlign = ContentAlignment.MiddleCenter;            
            lblIndicadorImagen.Width = 269;
            lblIndicadorImagen.Height = 14;
            lblIndicadorImagen.Location = new Point((int)(panelArticulo.Width * 0.47), 220);
            lblIndicadorImagen.Font = new Font("Arial", 8, FontStyle.Bold);

            // Label para contener el texto..
            Label lblNombreArticulo = new Label();
            lblNombreArticulo.Text = "Nombre del artículo";
            lblNombreArticulo.TextAlign = ContentAlignment.MiddleCenter;            
            lblNombreArticulo.Width = 158;
            lblNombreArticulo.Height = 19;
            lblNombreArticulo.Location = new Point((int)(panelArticulo.Width * 0.15), 245);
            lblNombreArticulo.Font = new Font("Arial", 12, FontStyle.Bold);

            // TextBox en el que el usuario puede escribir el nombre del artículo.
            ComboBox cBNombre = new ComboBox();
            cBNombre.Width = 442;
            cBNombre.Height = 26;
            cBNombre.Location = new Point((int)(panelArticulo.Width * 0.40), 245);
            cBNombre.Items.AddRange(listaNombreArticulos.ToArray());
            cBNombre.DropDownStyle = ComboBoxStyle.DropDownList;

            // Label para contener el texto..
            Label lblDescripcionArticulo = new Label();
            lblDescripcionArticulo.Text = "Descripción del artículo";
            lblDescripcionArticulo.TextAlign = ContentAlignment.MiddleCenter;            
            lblDescripcionArticulo.Width = 189;
            lblDescripcionArticulo.Height = 19;
            lblDescripcionArticulo.Location = new Point((int)(panelArticulo.Width * 0.15), 335);
            lblDescripcionArticulo.Font = new Font("Arial", 12, FontStyle.Bold);

            // TextBox en el que el usuario puede escribir la descripción del artículo.
            TextBox tBDescripcion = new TextBox();
            tBDescripcion.Multiline = true;            
            tBDescripcion.Width = 442;
            tBDescripcion.Height = 88;
            tBDescripcion.Location = new Point((int)(panelArticulo.Width * 0.40), 300);

            // Último label para contener el texto..
            Label lblCodigoArticulo = new Label();
            lblCodigoArticulo.Text = "Código del artículo";
            lblCodigoArticulo.TextAlign = ContentAlignment.MiddleCenter;            
            lblCodigoArticulo.Width = 153;
            lblCodigoArticulo.Height = 19;
            lblCodigoArticulo.Location = new Point((int)(panelArticulo.Width * 0.15), 425);
            lblCodigoArticulo.Font = new Font("Arial", 12, FontStyle.Bold);

            // TextBox en el que el usuario puede escribir el codigo del artículo.
            TextBox tBCodigo = new TextBox();
            tBCodigo.Multiline = true;            
            tBCodigo.Width = 442;
            tBCodigo.Height = 26;
            tBCodigo.Location = new Point((int)(panelArticulo.Width * 0.40), 420);
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
            btnCrearArticulo.Width = 221;
            btnCrearArticulo.Height = 43;
            btnCrearArticulo.Location = new Point((int)(panelArticulo.Width * 0.40), 490);
            btnCrearArticulo.Text = "Crear artículo";

            listaControles = new List<Control> { lblImagenArticulo, pBImagenArticulo, lblIndicadorImagen, lblNombreArticulo, cBNombre, lblDescripcionArticulo, tBDescripcion, lblCodigoArticulo, tBCodigo, btnCrearArticulo };

            btnCrearArticulo.Click += (sender, e) => btnCrearArticulo_Click(cBNombre.Text, tBDescripcion.Text, tBCodigo.Text);

            panelArticulo.Controls.AddRange(listaControles.ToArray());

            return panelArticulo;
        }

        // Método que generará un Panel para almacenar un DataGridView que contendrá los artículos de la BD.
        internal Panel generarPanelDatosArticulosBD(int width, int height)
        {
            Panel panelDatosBD = new Panel();
            panelDatosBD.Width = width - (width * 30 / 100);
            panelDatosBD.Height = height - (height * 70 / 100);
            panelDatosBD.BackColor = Color.White;
            panelDatosBD.Location = new Point((width - panelDatosBD.Width) / 2, 680);

            Label lblTituloBD = new Label();
            lblTituloBD.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTituloBD.Text = "Artículos actuales registrados";
            lblTituloBD.AutoSize = true;
            lblTituloBD.Location = new Point((int)(panelDatosBD.Width * 0.4), 5);

            DataGridView dGVArticulos = new DataGridView();
            dGVArticulos.Width = (int)(panelDatosBD.Width * 0.95);
            dGVArticulos.Height = (int)(panelDatosBD.Height * 0.85);
            dGVArticulos.Location = new Point((int)(panelDatosBD.Width * 0.03), 40);
            dGVArticulos.EditMode = DataGridViewEditMode.EditProgrammatically;
            dGVArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dGVArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            listaControlesDB = new List<Control> { lblTituloBD, dGVArticulos };

            panelDatosBD.Controls.AddRange(listaControlesDB.ToArray());

            listaArticulosDGV = cnxIA.obtenerArticulosDGV();
            dGVArticulos.DataSource = listaArticulosDGV;

            return panelDatosBD;
        }

        // Evento que se encarga de la funcionalidad de convertir la imágen que ha seleccionado el usuario a bytes, de crear tanto el codigo como la imágen QR y de insertarlo en la BD.
        private void btnCrearArticulo_Click(string nombreArticulo, string descripcionArticulo, string codigoArticulo)
        {
            PictureBox pbImg = (PictureBox)listaControles[1];
            DataGridView comboDGV = (DataGridView)listaControlesDB[1];

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

                        listaArticulosDGV = cnxIA.obtenerArticulosDGV();
                        comboDGV.DataSource = null;
                        comboDGV.DataSource = listaArticulosDGV;

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
            }
        }        
    }
}
