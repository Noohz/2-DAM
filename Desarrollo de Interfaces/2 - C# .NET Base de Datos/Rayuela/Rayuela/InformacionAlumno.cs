using System;
using System.Collections.Generic;
using System.IO;
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
        }

        private void btnCerrar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnPdfMailCalif_Click(object sender, System.EventArgs e)
        {
            generarPdf(dGVCalif);
        }

        private void generarPdf(DataGridView dGV)
        {
            String nombrePDF = "";
            String fecha = DateTime.Now.ToString("yyyyMMddHHmmss");

            if (dGV.Name.Equals("dGVCalif"))
            {
                nombrePDF = "Calificaciones " + fecha;
            }

            PdfPTable pdfTable = new PdfPTable(dGV.ColumnCount);

            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 30;

            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

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

            using (FileStream stream = new FileStream(folderPath + "" + nombrePDF +".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
        }
    }
}
