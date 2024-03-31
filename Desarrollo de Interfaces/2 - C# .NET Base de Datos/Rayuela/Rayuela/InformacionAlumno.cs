using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

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

            calificaciones = cnx.listarCalificaciones(nA.Identificador1, nA.Ciclo1, nA.Curso1);
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

            mandarMail(generarPdf(dGVCalif), nA.Mail1, nA.Nombre1);
        }

        private void BtnPdfMailAsis_Click(object sender, EventArgs e)
        {
            Button btnx = (Button)sender;
            Alumno nA = (Alumno)btnx.Tag;

            mandarMail(generarPdf(dGVAsis), nA.Mail1, nA.Nombre1);
        }

        private String generarPdf(DataGridView dGV)
        {
            String nombrePDF = "";
            String fecha = DateTime.Now.ToString("yyyyMMddHHmmss");
            bool pdfCreado = false;

            if (dGV.Name.Equals("dGVCalif"))
            {
                nombrePDF = "Calificaciones " + fecha;

            }
            else if (dGV.Name.Equals("dGVAsis"))
            {
                nombrePDF = "Faltas de Asistencia " + fecha;
            }

            PdfPTable pdfTable = new PdfPTable(dGV.ColumnCount);

            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 30;

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
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
                pdfCreado = true;
            }

            if (pdfCreado == true)
            {
                MessageBox.Show("PDF con el nombre: " + nombrePDF + " creado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error a la hora de crear el Pdf.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            String ruta = folderPath + "" + nombrePDF + ".pdf";

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
