using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CinesNavalmoral
{
    public partial class FormularioBack : Form
    {
        ClaseConectar cnx = new ClaseConectar();
        List<ClaseSalaCine> numSalas = new List<ClaseSalaCine>();

        String nombreImagen;
        public FormularioBack()
        {
            InitializeComponent();

            numSalas = cnx.obtenerIdSala();

            foreach (var sala in numSalas)
            {
                cBSala.Items.Add(sala.IdSala);
            }

            dateTPSesion.Format = DateTimePickerFormat.Custom;
            dateTPSesion.CustomFormat = "yyyy-MM-dd-hh:mm";
        }

        private void btnProgramarSesion_Click(object sender, EventArgs e)
        {
            if (tBTitulo != null && cBSala.SelectedIndex != -1)
            {
                if (cnx.comprobarSalaHoraLibre(dateTPSesion.Text, cBSala.SelectedIndex))
                {
                    if (nombreImagen != null)
                    {
                        /*crear fichero binario a partir del fichero físico*/
                        FileStream fs = new FileStream(nombreImagen, FileMode.Open, FileAccess.Read);
                        /*se prepara la secuencia de datos o caracteres que se van a leer*/
                        BinaryReader br = new BinaryReader(fs);
                        /*Lee el número especificado de bytes de la secuencia actual en una matriz de bytes y hace avanzar la posición actual en función del número de bytes leídos.*/
                        byte[] bloque = br.ReadBytes((int)fs.Length);

                        if (cnx.programarNuevaSesion(tBTitulo.Text, dateTPSesion.Text, cBSala.SelectedIndex, bloque) == 1)
                        {
                            MessageBox.Show("Pelicula añadida.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debes introducir una imágen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            } else
            {
                MessageBox.Show("Debes completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog();  /*cuadro de diálogo para cargar un fichero externo*/
            op1.Filter = "imagenes|*.jpg;*.png"; /* filtro de fichero imágenes*/
            if (op1.ShowDialog() == DialogResult.OK) /*si se acepta el ficero seleccionado*/
            {
                nombreImagen = op1.FileName;  /* nombre del fichero: Ruta completa+nombre*/
                pctImagen.Image = Image.FromFile(nombreImagen);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
