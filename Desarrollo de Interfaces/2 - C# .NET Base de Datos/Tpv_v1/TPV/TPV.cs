using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.VisualBasic;

namespace TPV
{
    public partial class TPV : Form
    {
        claseAccesoBD conexion = new claseAccesoBD();
        List<claseFruta> listaFrutas = new List<claseFruta>();
        List<claseCesta> listaCesta = new List<claseCesta>();
        List<String> ProductosBajoMinimo = new List<String>();
        List<claseFruta> frutaEncontrada = new List<claseFruta>();

        int contadorProductos = 0;
        double total = 0;


        public TPV()
        {
            InitializeComponent();
        }

        private void TPV_Load(object sender, EventArgs e)
        {
            btnPagar.Enabled = false;

            gbInfo.Visible = false;
            listaFrutas = conexion.listarFrutas();

            foreach (claseFruta cf in listaFrutas)
            {
                Button btn = new Button();
                btn.Name = cf.Nombre;

                btn.Width = 120;
                btn.Height = 120;


                MemoryStream ms = new System.IO.MemoryStream(cf.Imagen);
                System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.BackgroundImage = imagen;

                btn.Click += Btn_Click;
                btn.MouseHover += Btn_MouseHover;

                flpFrutas.Controls.Add(btn);

            }

        }

        private void Btn_MouseHover(object sender, EventArgs e)
        {
            Button btnX = (Button)sender;

            gbInfo.Visible = true;
            pictureBoxInfo.Visible = true;

            foreach (claseFruta cf in listaFrutas) // Un foreach que recorra la listaFrutas
            {
                if (cf.Nombre == btnX.Name) // Si el nombre que hay en la listaFrutas coincide con el de botón se actualiza los datos del groupBox.
                {
                    lblNombre.Text = "Nombre: " + cf.Nombre;
                    lblPrecio.Text = cf.Precio.ToString();
                    lblExistencias.Text = cf.Stock.ToString();
                    pictureBoxInfo.BackgroundImageLayout = ImageLayout.Stretch;
                    pictureBoxInfo.BackgroundImage = btnX.BackgroundImage;
                }
            }

        }

        private void Btn_Click(object sender, EventArgs e) // Botones de frutas
        {
            Button btnx = (Button)sender;

            foreach (claseFruta cf in listaFrutas)
            {
                if (cf.Nombre == btnx.Name)
                {
                    if (cf.Stock <= 0)
                    {
                        MessageBox.Show("No hay existencias de este producto.");
                    }
                    else
                    {

                        MessageBox.Show("Has seleccionado " + cf.Nombre + ". Existencias: " + cf.Stock, "TPV Frutería Vero");
                        String peso = Interaction.InputBox("Introduce peso en kgs", "TPV Frutería Vero");

                        if (peso == "" || Convert.ToDouble(peso) <= 0)
                        {
                            MessageBox.Show("Cantidad errónea.");
                        }
                        else
                        {
                            contadorProductos++;
                            claseCesta producto = new claseCesta();
                            claseFruta cF = new claseFruta();
                            producto.Articulo = contadorProductos;
                            producto.Nombre = cf.Nombre;
                            producto.Peso = Convert.ToDouble(peso);
                            producto.PrecioUnitario = Math.Round(Convert.ToDouble(cf.Precio), 2);
                            producto.PrecioParcial = Math.Round(producto.Peso * producto.PrecioUnitario, 2);

                            total += producto.PrecioParcial;

                            lblTotal.Text = Convert.ToString(total);

                            listaCesta.Add(producto);
                            cf.Stock -= Convert.ToInt32(peso);

                            dgv1.DataSource = null;
                            dgv1.DataSource = listaCesta;
                        }
                    }
                }
            }
            gbInfo.Visible = false;
            pictureBoxInfo.Visible = false;
            btnPagar.Enabled = true;
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {

            mandarMail(imprimirTicket(), txtMail.Text);

            lblTotal.Text = "Total";
            txtMail.Text = "";
            dgv1.DataSource = null;

            conexion.modificarStock(listaCesta, listaFrutas);

        }

        private String imprimirTicket()
        {
            PdfPTable pdfTable = new PdfPTable(dgv1.ColumnCount); // Crea un pdf con los datos de la dataGridView

            // Separación del texto, ancho de la tabla, alineación y el ancho del borde.
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 80;
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
            PdfPCell cellTotal = new PdfPCell(new Phrase(lblTotal.Text));
            PdfPCell celdaVacia = new PdfPCell(new Phrase(""));
            pdfTable.AddCell(celdaVacia);
            pdfTable.AddCell(celdaVacia);
            pdfTable.AddCell(celdaVacia);
            pdfTable.AddCell("Total:");
            pdfTable.AddCell(cellTotal);
            string folderPath = "C:\\ticket\\";

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
                pdfDoc.Add(new Paragraph("Frutería Vero"));
                pdfDoc.Add(new Paragraph("CIF: A1234567B"));
                pdfDoc.Add(new Paragraph("c/ Joaquín Alcalde s/n"));
                pdfDoc.Add(new Paragraph("10300, Navalmoral de la Mata"));
                pdfDoc.Add(new Paragraph("Cáceres"));
                pdfDoc.Add(new Paragraph("\n\n"));

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
        private void btnEmpezar_Click(object sender, EventArgs e)
        {
            btnEmpezar.Visible = false;
            flpFrutas.Visible = true;
            btnPagar.Visible = true;
            lblTotal.Visible = true;
            dgv1.Visible = true;
            label1.Visible = true;
            txtMail.Visible = true;
            btnAdministrar.Visible = true;
            labelEuro.Visible = true;
            labelTotal.Visible = true;
            lblBusca.Visible = true;
            txtBuscar.Visible = true;
            gbInfo.Visible = false;
            pictureBoxInfo.Visible = false;
            pbAviso.Visible = true;
            labelBarCodeCliente.Visible = true;
            textBoxBarCodeCliente.Visible = true;
            labelBarCodeFruta.Visible = true;
            textBoxBarCodeFruta.Visible = true;
        }

        private void btnAdministrar_Click(object sender, EventArgs e)
        {
            Inicio ini = new Inicio();
            ini.ShowDialog();
            this.Hide();
        }

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            gbInfo.Visible = false;
            DialogResult confirmarEliminar = MessageBox.Show("¿Estás seguro de eliminar este producto?", "Frutería Vero", MessageBoxButtons.YesNo);
            if (confirmarEliminar == DialogResult.Yes)
            {
                int filaSeleccionada = dgv1.CurrentCell.RowIndex;
                double precioRestar = listaCesta.ElementAt(filaSeleccionada).PrecioParcial;

                claseCesta productoEliminado = listaCesta.ElementAt(filaSeleccionada); // Una variable para almacenar la fila de la fruta que se ha eliminado.

                listaCesta.RemoveAt(filaSeleccionada);

                dgv1.DataSource = null;
                dgv1.DataSource = listaCesta;
                total -= precioRestar;
                lblTotal.Text = Convert.ToString(total);

                foreach (claseFruta cf in listaFrutas) // Para que se actualice el stock que aparece en la información después de eliminarla de la cesta.
                {
                    if (cf.Nombre == productoEliminado.Nombre)
                    {
                        cf.Stock += (int)productoEliminado.Peso; // Esto suma el peso (Que es la cantidad que el usuario introduce al principio a la hora de comprar la fruta) al stock para que este vuelva a su original al eliminarlo de la cesta.
                    }
                }

                // Borrar todos los botones del flpFrutas y volverlos a generar para que muestre la información actualizada de nuevo.
                flpFrutas.Controls.Clear();
                foreach (claseFruta cf in listaFrutas)
                {
                    Button btn = new Button();
                    btn.Name = cf.Nombre;
                    btn.Width = 120;
                    btn.Height = 120;

                    MemoryStream ms = new System.IO.MemoryStream(cf.Imagen);
                    System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.BackgroundImage = imagen;
                    btn.Click += Btn_Click;
                    btn.MouseHover += Btn_MouseHover;

                    flpFrutas.Controls.Add(btn);
                }

            }

            if (dgv1.Rows.Count == 0)
            {
                btnPagar.Enabled = false;
            }

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<claseFruta> frutaBuscada = new List<claseFruta>();

            String busqueda = txtBuscar.Text.ToLower(); // Un string para almacenar el texto que se introduzca en el txtBuscar pero convertido a minusculas.

            // Recorre la listaFrutas y si las letras que se introduzcan en el txtBuscar coinciden con el nombre de la fruta se almacena en un nuevo list.
            foreach (claseFruta cf in listaFrutas)
            {
                if (cf.Nombre.ToLower().Contains(busqueda))
                {
                    frutaBuscada.Add(cf);
                }
            }


            flpFrutas.Controls.Clear();

            // Un foreach para que genere los botones de la misma forma que antes pero esta vez solo con los buscados.
            foreach (claseFruta cf in frutaBuscada)
            {
                Button btn = new Button();
                btn.Name = cf.Nombre;
                btn.Width = 120;
                btn.Height = 120;
                MemoryStream ms = new System.IO.MemoryStream(cf.Imagen);
                System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.BackgroundImage = imagen;
                btn.Click += Btn_Click;
                btn.MouseHover += Btn_MouseHover;
                flpFrutas.Controls.Add(btn);
            }

        }

        private void textBoxBarCodeCliente_TextChanged(object sender, EventArgs e)
        {
            string dniIngresado = textBoxBarCodeCliente.Text;

            string emailCliente = conexion.buscarPorDNI(dniIngresado);

            txtMail.Enabled = false;

            if (!string.IsNullOrEmpty(emailCliente)) // IsNullOrEmpty es como utilizar isEmpty() y != null.
            {
                txtMail.Text = emailCliente;
            }
            else
            {
                txtMail.Text = "";
            }
        }

        private void textBoxBarCodeFruta_TextChanged(object sender, EventArgs e)
        {

            string idFrutaIngresado = textBoxBarCodeFruta.Text;

            string nombreFruta = conexion.buscarPorBarCodeFruta(idFrutaIngresado);

            txtBuscar.Enabled = false;

            if (!string.IsNullOrEmpty(nombreFruta))
            {
                txtBuscar.Text = nombreFruta;
            }
            else
            {
                txtBuscar.Text = "";
            }
        }
    }
}

