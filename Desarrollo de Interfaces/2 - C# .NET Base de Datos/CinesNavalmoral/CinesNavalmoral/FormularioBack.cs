using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CinesNavalmoral
{
    public partial class FormularioBack : Form
    {
        ClaseConectar cnx = new ClaseConectar();
        String nombreImagen;

        // HAY QUE CAMBIAR EL TEXTBOX DE LA SESIÓN A UN COMBOBOX QUE OBTENGA EL NÚMERO DE SALAS DE UNA CONSULTA A LA BASE DE DATOS. (Select idSala).
        // VALIDAR EL TEXTBOX DE LA FECHA PARA QUE SE ASEMEJE A LA BASE DE DATOS, USANDO UN DATETIMEPICKER.
        // VALIDAR QUE NO SE PUEDA SUBIR UNA PELICULA SIN CARTEL.
        // TODOS LOS CAMPOS TIENEN QUE SER OBLIGATORIOS..

        public FormularioBack()
        {
            InitializeComponent();
        }

        private void btnProgramarSesion_Click(object sender, EventArgs e)
        {
            if (cnx.comprobarSalaHoraLibre(tbSesion.Text, Convert.ToInt16(tBSala.Text)))
            {
                /*crear fichero binario a partir del fichero físico*/
                FileStream fs = new FileStream(nombreImagen, FileMode.Open, FileAccess.Read);
                /*se prepara la secuencia de datos o caracteres que se van a leer*/
                BinaryReader br = new BinaryReader(fs);
                /*Lee el número especificado de bytes de la secuencia actual en una matriz de bytes y hace avanzar la posición actual en función del número de bytes leídos.*/
                byte[] bloque = br.ReadBytes((int)fs.Length);

                if (cnx.programarNuevaSesion(tBTitulo.Text, tbSesion.Text, Convert.ToInt16(tBSala.Text), bloque) == 1)
                {
                    MessageBox.Show("Pelicula añadida.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
