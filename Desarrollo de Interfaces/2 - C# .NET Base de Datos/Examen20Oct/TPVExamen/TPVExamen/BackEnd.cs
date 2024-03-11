using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.VisualBasic;

namespace TPVExamen
{
    public partial class BackEnd : Form
    {
        claseConectarBD conexion = new claseConectarBD();
        List<claseFrutas> listaFrutas = new List<claseFrutas>();
        String nombreImagen;
        System.Drawing.Image imagenSeleccionada;

        public BackEnd()
        {
            InitializeComponent();
        }

        private void BackEnd_Load(object sender, EventArgs e)
        {
            int nivel = claseConectarBD.nivelEmpleado;
            string nombreEmpleado = claseConectarBD.nombEmpleado;

            if (nivel == 1)
            {
                buttonDarAlta.Visible = true;
                buttonNuevaTienda.Visible = true;
                buttonSeleccionarTienda.Visible = true;
                buttonAñadirStock.Visible = true;
            }
            else if (nivel == 2)
            {
                buttonSeleccionarTienda.Visible = true;
                buttonAñadirStock.Visible = true;

                buttonAltaIndependiente.Visible = true;
                buttonBajaIndependiente.Visible = true;
                buttonModificarIndependiente.Visible = true;
                buttonListarIndependiente.Visible = true;
            }

            if (nombreEmpleado.Equals("admin"))
            {
                buttonCrearTiendaADM.Visible = true;
                buttonCerrarTiendaADM.Visible = true;
                buttonPedidoManual.Visible = true;
            }
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Form1 tpv = new Form1();
            tpv.ShowDialog();
            this.Close();
        }

        private void buttonCrearTiendaADM_Click(object sender, EventArgs e)
        {
            string msg = Interaction.InputBox("Indica el nombre de la tabla frutas (Puede ser un numero o un texto):", "Crear tienda");

            if (!string.IsNullOrEmpty(msg))
            {
                conexion.crearTienda(msg);
                MessageBox.Show("La tabla se ha creado correctamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Has introducido un caracter no valido para el nombre de la tabla", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCerrarTiendaADM_Click(object sender, EventArgs e)
        {
            string msg = Interaction.InputBox("Indica el número de la tabla frutas:", "Cerrar tienda");

            if (!string.IsNullOrEmpty(msg))
            {
                conexion.cerrarTienda(msg);
                MessageBox.Show("La tabla se ha cerrado correctamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Has introducido un caracter no valido para el nombre de la tabla", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAltaIndependiente_Click(object sender, EventArgs e)
        {
            flpFrutas.Controls.Clear(); // Limpia el flpFrutas para que no se dupliquen los botones si se volviese a la opción de añadir stock
            flpFrutas.Visible = false; // Oculta el flpFrutas.
            btnAniadir.Visible = true;
            btnGuardarCambios.Visible = false;

            if (buttonBajaIndependiente.Enabled == false)
            {
                buttonBajaIndependiente.Enabled = true;
            }

            if (buttonModificarIndependiente.Enabled == false)
            {
                buttonModificarIndependiente.Enabled = true;
            }

            pbImagenCargada.Image = null;

            gbInsertar.Visible = true; // Muestra el groupBox que le permite al usuario introducir un producto.
        }

        private void btnAniadir_Click(object sender, EventArgs e)
        {
            string msg = Interaction.InputBox("Indica el nombre de la tabla a la que insertar un producto a la tabla frutas (Puede ser un numero o un texto):", "Añadir producto");

            if (!string.IsNullOrEmpty(msg))
            {
                FileStream fs = new FileStream(nombreImagen, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] bloque = br.ReadBytes((int)fs.Length);


                int id = Convert.ToInt16(txtId.Text);
                string nombre = txtNombre.Text;
                string precio = txtPrecio.Text;
                byte[] imagen = bloque;
                string procedencia = txtProcedencia.Text;
                string stock = txtStock.Text;
                string stockMinimo = txtStockMin.Text;

                conexion.insertarFruta(id, nombre, precio, imagen, procedencia, stock, stockMinimo, msg);

                MessageBox.Show("Se ha añadido correctamente el producto.", "Operación Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Has introducido un caracter no valido para el nombre de la tabla", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Imagenes | *.jpg; *.png";
            nombreImagen = opf.FileName;

            if (opf.ShowDialog() == DialogResult.OK)
            {
                nombreImagen = opf.FileName;
                pbImagenCargada.Image = System.Drawing.Image.FromFile(nombreImagen);
                pbImagenCargada.BackgroundImage = System.Drawing.Image.FromFile(nombreImagen);
            }
        }

        private void buttonBajaIndependiente_Click(object sender, EventArgs e)
        {
            flpFrutas.Controls.Clear();
            listaFrutas.Clear(); // Limpia la lista para que no se repitan cuando se vuelva a pulsar el boton.
            gbInsertar.Visible = false; // Oculta el groupBox que permite añadir / modificar un producto.
            buttonBajaIndependiente.Enabled = false; // Deshabilita el botón para que no se pueda volver a interactuar con él y que se generen otra vez los botones.

            listaFrutas = conexion.listarFrutas();
            flpFrutas.Visible = true;

            foreach (claseFrutas cf in listaFrutas)
            {
                Button btn = new Button();
                btn.Name = cf.Nombre;

                btn.Width = 70;
                btn.Height = 80;
                btn.Tag = cf.Id;

                btn.Click += new EventHandler(ButtonBajaIndEvento_Click);

                MemoryStream ms = new System.IO.MemoryStream(cf.Imagen);
                System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.BackgroundImage = imagen;

                flpFrutas.Controls.Add(btn);

            }
        }

        private void ButtonBajaIndEvento_Click(object sender, EventArgs e)
        {
            buttonBajaIndependiente.Enabled = true;

            string msg = Interaction.InputBox("Indica el nombre de la tabla a la que insertar un producto a la tabla frutas (Puede ser un numero o un texto):", "Añadir producto");

            if (sender is Button boton)
            {
                DialogResult msg2 = MessageBox.Show("¿Deseas eliminar la fruta seleccionada: " + boton.Name + "?", "Eliminar Fruta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (msg2 == DialogResult.Yes)
                {
                    int id = (int)boton.Tag;

                    conexion.darBajaIndependiente(id, msg);

                    MessageBox.Show("La fruta ha sido eliminada.", "Operación Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonModificarIndependiente_Click(object sender, EventArgs e)
        {
            flpFrutas.Controls.Clear();
            listaFrutas.Clear(); // Limpia la lista para que no se repitan cuando se vuelva a pulsar el boton.
            gbInsertar.Visible = false; // Oculta el groupBox que permite añadir / modificar un producto.
            buttonModificarIndependiente.Enabled = false; // Deshabilita el botón para que no se pueda volver a interactuar con él y que se generen otra vez los botones.
            btnGuardarCambios.Visible = true; // Habilita el botón Guardar Cambios.

            listaFrutas = conexion.listarFrutas();
            flpFrutas.Visible = true;

            if (buttonBajaIndependiente.Enabled == false)
            {
                buttonBajaIndependiente.Enabled = true;
            }

            foreach (claseFrutas cf in listaFrutas)
            {
                Button btn = new Button();
                btn.Name = cf.Nombre;

                btn.Width = 70;
                btn.Height = 80;
                btn.Tag = cf.Id;

                btn.Click += new EventHandler(ButtonModificarIndEvento_Click);

                MemoryStream ms = new System.IO.MemoryStream(cf.Imagen);
                System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.BackgroundImage = imagen;

                flpFrutas.Controls.Add(btn);

            }
        }

        private void ButtonModificarIndEvento_Click(object sender, EventArgs e)
        {
            buttonModificarIndependiente.Enabled = true;

            if (sender is Button boton)
            {
                int idFruta = (int)boton.Tag;

                MemoryStream ms = new MemoryStream();
                boton.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                imagenSeleccionada = System.Drawing.Image.FromStream(ms);

                pbImagenCargada.Image = imagenSeleccionada;

                flpFrutas.Visible = false;
                gbInsertar.Visible = true;
                btnAniadir.Visible = false;
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {

            string msg2 = Interaction.InputBox("Indica el nombre de la tabla a la que insertar un producto a la tabla frutas (Puede ser un numero o un texto):", "Añadir producto");

            if (string.IsNullOrEmpty(txtId.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtPrecio.Text) || string.IsNullOrEmpty(txtStock.Text) || string.IsNullOrEmpty(txtProcedencia.Text) || string.IsNullOrEmpty(txtStockMin.Text))
            {
                MessageBox.Show("No puede haber ningún campo si introducir.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (imagenSeleccionada != null)
            {

                MemoryStream ms = new MemoryStream();
                imagenSeleccionada.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imagen = ms.ToArray();

                string id = txtId.Text;
                string nombre = txtNombre.Text;
                string precio = txtPrecio.Text;
                string stock = txtStock.Text;
                string procedencia = txtProcedencia.Text;
                string stockMin = txtStockMin.Text;

                conexion.modificarFrutaIndependiente(id, nombre, precio, imagen, stock, procedencia, stockMin, msg2);

                MessageBox.Show("Se ha modificado correctamente el producto.", "Operación Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtId.Text = "";
                txtNombre.Text = "";
                txtPrecio.Text = "";
                txtStock.Text = "";
                txtProcedencia.Text = "";
                txtStockMin.Text = "";
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una imagen antes de guardar los cambios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonListarIndependiente_Click(object sender, EventArgs e)
        {

            flpFrutas.Controls.Clear();
            listaFrutas.Clear(); // Limpia la lista para que no se repitan cuando se vuelva a pulsar el boton.
            gbInsertar.Visible = false; // Oculta el groupBox que permite añadir / modificar un producto.
            buttonModificarIndependiente.Enabled = false; // Deshabilita el botón para que no se pueda volver a interactuar con él y que se generen otra vez los botones.
            btnGuardarCambios.Visible = false; // Deshabilita el botón Guardar Cambios.
            flpFrutas.Visible = false;

            if (buttonBajaIndependiente.Enabled == false)
            {
                buttonBajaIndependiente.Enabled = true;
            }

            if (buttonModificarIndependiente.Enabled == false)
            {
                buttonModificarIndependiente.Enabled = true;
            }


            dgv1.Visible = true;
            listaFrutas = conexion.listarFrutas();
            dgv1.DataSource = listaFrutas;
        }

        private void buttonPedidoManual_Click(object sender, EventArgs e)
        {
            string msg = Interaction.InputBox("Indica el nombre de la tabla frutas a mostrar:", "Mostrar Tabla");

            flpFrutas.Controls.Clear();
            listaFrutas.Clear(); // Limpia la lista para que no se repitan cuando se vuelva a pulsar el boton.
            gbInsertar.Visible = false; // Oculta el groupBox que permite añadir / modificar un producto.
            buttonModificarIndependiente.Enabled = false; // Deshabilita el botón para que no se pueda volver a interactuar con él y que se generen otra vez los botones.
            btnGuardarCambios.Visible = false; // Deshabilita el botón Guardar Cambios.
            flpFrutas.Visible = false;

            if (buttonBajaIndependiente.Enabled == false)
            {
                buttonBajaIndependiente.Enabled = true;
            }

            if (buttonModificarIndependiente.Enabled == false)
            {
                buttonModificarIndependiente.Enabled = true;
            }

            buttonGenerarInformePManual.Visible = true;
            dgv1.Visible = true;
            List<claseFrutas> frutasStockBajoStockMinimo = conexion.stockBajoMinimo(msg);
            dgv1.DataSource = frutasStockBajoStockMinimo;
        }

        private void buttonGenerarInformePManual_Click(object sender, EventArgs e)
        {
            string cantidad = Interaction.InputBox("Indica la cantidad de frutas a pedir:", "Realizar pedidos");
            string proveedor = Interaction.InputBox("Indica el nombre del proveedor:", "Realizar pedido");

            if (!string.IsNullOrEmpty(cantidad) && !string.IsNullOrEmpty(proveedor))
            {
                string correoProveedor = conexion.correoProveedor(proveedor);

                mandarMail(imprimirTicket(), correoProveedor);
                MessageBox.Show("Se ha completado el pedido.", "Operación Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonGenerarInformePManual.Visible = false;
            }
        }

        private String imprimirTicket()
        {
            PdfPTable pdfTable = new PdfPTable(dgv1.ColumnCount); // Crea un pdf con los datos de la dataGridView

            // Separación del texto, ancho de la tabla, alineación y el ancho del borde.
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 1;

            // Encabezado de las columnas.
            foreach (DataGridViewColumn column in dgv1.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            // Contenido de las filas.
            foreach (DataGridViewRow row in dgv1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    try
                    {
                        pdfTable.AddCell(cell.Value.ToString());

                    }
                    catch
                    {

                    }
                }
            }

            // Etiqueta con el total a pagar.
            PdfPCell celdaVacia = new PdfPCell(new Phrase(""));
            pdfTable.AddCell(celdaVacia);
            pdfTable.AddCell(celdaVacia);
            pdfTable.AddCell(celdaVacia);
            string folderPath = "C:\\ticketAitor\\";

            // Si no existe el directorio se crea.
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Para colocar la fecha actual de impresión.
            DateTime dt = DateTime.Now;
            String s = dt.ToString("yyyyMMddHHmmss");
            String cadenaFinal = folderPath + "ticket" + s + ".pdf";

            // Crear el documento o fichero físico.
            using (FileStream stream = new FileStream(folderPath + "ticket" + s + ".pdf", FileMode.Create))
            {
                // Dimensiones del documento.
                Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                // Incluir una imagen, indicar la ruta.
                String patimagen = Path.Combine(Application.StartupPath, "logo.png");

                // Integrar la imagen con dimensiones en el pdfdoc.
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(patimagen);
                img.ScaleAbsolute(210, 70);
                img.ScalePercent(50);
                pdfDoc.Add(img);

                // Texto informativo.
                pdfDoc.Add(new Paragraph("Frutería Aitor"));
                pdfDoc.Add(new Paragraph("CIF: A1234567B"));
                pdfDoc.Add(new Paragraph("c/ Joaquín Alcalde s/n"));
                pdfDoc.Add(new Paragraph("10300, Navalmoral de la Mata"));
                pdfDoc.Add(new Paragraph("Cáceres"));
                pdfDoc.Add(new Paragraph("\n\n"));
                pdfDoc.Add(new Paragraph("Necesito un re-stock de las siguientes frutas:"));

                // Integrar la tabla creada en la parte superior
                pdfDoc.Add(pdfTable);
                pdfDoc.Add(new Paragraph("\n\n"));

                // Más información.
                pdfDoc.Add(new Paragraph("Fecha y Hora Compra: " + DateTime.Now.ToString("dd-MM-yy, HH:mm:ss")));
                pdfDoc.Close();
            }

            // Proceso de Windows para levantar en pantalla el pdf.
            Process pc = new Process();
            pc.StartInfo.FileName = cadenaFinal;
            pc.Start();

            return cadenaFinal;
        }

        private void mandarMail(String archivo, String mail)
        {
            try
            {
                //correo saliente y pwd
                string email = "aramoss27@educarex.es";
                string password = "yxkjvpygfnvyizjq";
                //activar las credenciales
                var loginInfo = new NetworkCredential(email, password);
                //construir el mensaje
                var msg = new MailMessage();
                //protocolo smtp
                var smtpClient = new SmtpClient("smtp.gmail.com", 25);
                //correo saliente
                msg.From = new MailAddress("aramoss27@educarex.es");
                //correo destinatario
                msg.To.Add(new MailAddress(mail));
                //asunto
                msg.Subject = "Compra en Frutería Vero";
                //cuerpo del mensaje
                msg.Body = "Gracias por su compra.";
                //adjuntar fichero
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(archivo);
                msg.Attachments.Add(attachment);
                msg.IsBodyHtml = true;
                //activar protocolos de segunridad
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = loginInfo;
                //enviar el mensaje
                smtpClient.Send(msg);
                //limpiar el canal de salida
                smtpClient.Dispose();
                MessageBox.Show("Mensaje enviado");
            }
            catch (Exception) { MessageBox.Show("mensaje no enviado"); }

        }
    }
}
