using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.Drawing;

namespace Rayuela
{
    public partial class InformacionAlumno : Form
    {
        Clase_Conectar cnx = new Clase_Conectar();
        List<Calificaciones> calificaciones = new List<Calificaciones>();
        List<Faltasasistencia> faltasasistencias = new List<Faltasasistencia>();

        public InformacionAlumno(Alumno nA)
        {
            InitializeComponent();

            this.Text = "Calificaciones / Asistencia de " + nA.Nombre1;

            calificaciones = cnx.listarCalificaciones(nA.Identificador1);
            dGVCalif.DataSource = calificaciones;

            faltasasistencias = cnx.listarFaltas(nA.Identificador1);
            dGVAsis.DataSource = faltasasistencias;

            btnPdfMailCalif.Tag = nA;
            btnPdfMailCalif.Click += btnPdfMailCalif_Click;

            btnPdfMailAsis.Tag = nA;
            btnPdfMailAsis.Click += BtnPdfMailAsis_Click;
        }             

        private void btnCerrar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnPdfMailCalif_Click(object sender, System.EventArgs e)
        {
            Button btnx = (Button)sender;
            Alumno nA = (Alumno)btnx.Tag;

            mandarMail(generarPdf(dGVCalif, nA), nA.Mail1, nA.Nombre1); // Esto llama al método mandarMail. Le pasamos el método generarPad con el DGV que queremos exportar.
                                                                        // El método generarPdf devuelve una ruta con la dirección y el nombre del fichero.
                                                                        // Al pasarlo por parámetro al método mandarMail usa esa ruta para poder enviar el archivo.
        }

        private void BtnPdfMailAsis_Click(object sender, EventArgs e)
        {
            Button btnx = (Button)sender;
            Alumno nA = (Alumno)btnx.Tag;

            mandarMail(generarPdf(dGVAsis, nA), nA.Mail1, nA.Nombre1);
        }

        private String generarPdf(DataGridView dGV, Alumno nA)
        {
            // Descargamos la imágen.
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(nA.Foto1);
            MemoryStream ms = new MemoryStream(bytes);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

            // La convertimos de System.Drawing a iTextSharp para poder utilizarla en el pdf.
            iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(img, System.Drawing.Imaging.ImageFormat.Jpeg);

            String nombrePDF = "";
            String fecha = DateTime.Now.ToString("yyyyMMddHHmmss");
            String asunto = "";
            bool pdfCreado = false;

            if (dGV.Name.Equals("dGVCalif"))
            {
                nombrePDF = "Calificaciones " + fecha;
                asunto = "Calificaciones";

            }
            else if (dGV.Name.Equals("dGVAsis"))
            {
                nombrePDF = "Faltas de Asistencia " + fecha;
                asunto = "Faltas de Asistencia";
            }

            PdfPTable pdfTable = new PdfPTable(dGV.ColumnCount);

            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;

            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;

            pdfTable.DefaultCell.BorderWidth = 1;

            foreach (DataGridViewColumn column in dGV.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            foreach (DataGridViewRow row in dGV.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    try
                    {
                        pdfTable.AddCell(cell.Value.ToString());
                    }
                    catch { }
                }
            }

            string folderPath = "C:\\rayuelaPDF\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (FileStream stream = new FileStream(folderPath + "" + nombrePDF + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                pdfDoc.Add(png);

                pdfDoc.Add(new Paragraph("Nombre: " + nA.Nombre1));
                pdfDoc.Add(new Paragraph("Correo: " + nA.Mail1));
                pdfDoc.Add(new Paragraph("Identificador: " + nA.Identificador1));
                pdfDoc.Add(new Paragraph("Curso: " + nA.Curso1 + " " + nA.Ciclo1));
                pdfDoc.Add(new Paragraph("\n"));

                pdfDoc.Add(new Paragraph(asunto, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD)) { Alignment = Element.ALIGN_CENTER });
                pdfDoc.Add(new Paragraph("\n"));

                pdfDoc.Add(pdfTable);

                pdfDoc.Close();
                stream.Close();

                pdfCreado = true;
            }

            String ruta = folderPath + "" + nombrePDF + ".pdf";

            if (pdfCreado == true)
            {
                MessageBox.Show("PDF con el nombre: " + nombrePDF + " creado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Process p1 = new Process();
                p1.StartInfo.FileName = ruta;
                p1.Start();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error a la hora de crear el Pdf.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           

            return ruta;
        }

        private void mandarMail(String archivo, String mail, String nombreAlum)
        {
            try
            {
                string email = "aramoss27@educarex.es";
                string password = "porcnrrbaahrromt";

                var loginInfo = new NetworkCredential(email, password);

                var msg = new MailMessage();

                var smtpClient = new SmtpClient("smtp.gmail.com", 25);

                msg.From = new MailAddress("aramoss27@educarex.es");

                msg.To.Add(new MailAddress(mail));

                if (archivo.Contains("Calificaciones"))
                {
                    msg.Subject = "Calificaciones del alumno: " + nombreAlum;
                } else if (archivo.Contains("Faltas de Asistencia"))
                {
                    msg.Subject = "Faltas de Asistencia del alumno: " + nombreAlum;
                }                

                msg.Body = "Se adjunta el PDF con la información correspondiente.";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(archivo);
                msg.Attachments.Add(attachment);
                msg.IsBodyHtml = true;

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = loginInfo;
                                
                smtpClient.Send(msg);
                                
                smtpClient.Dispose();

                MessageBox.Show("Correo enviado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception) { MessageBox.Show("Ha ocurrido un error a la hora de enviar el correo"); }

        }
    }
}
