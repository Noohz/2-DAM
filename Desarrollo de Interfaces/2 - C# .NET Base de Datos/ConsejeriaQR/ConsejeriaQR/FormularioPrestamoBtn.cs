using System;
using System.IO;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    public partial class FormularioPrestamoBtn : Form
    {
        int segundos = 0;
        ClaseConectar cnxFPB;
        articulos datosArticulo;

        public FormularioPrestamoBtn(object tag, ClaseConectar cnxIPA)
        {
            InitializeComponent();

            cnxFPB = cnxIPA;

            datosArticulo = (articulos)tag;

            MemoryStream ms = new System.IO.MemoryStream(datosArticulo.Imagen);
            System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
            pictureBoxImgArticulo.Image = imagen;

            lblInfoArticulo.Text = datosArticulo.Nombre + " | " + datosArticulo.Codigo;

            MemoryStream mst = new System.IO.MemoryStream(datosArticulo.ImagenQR);
            System.Drawing.Image imagenQR = System.Drawing.Image.FromStream(mst);
            pictureBoxImagenQR.Image = imagenQR;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxCodigoQR_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCodigoQR.Text.Length > 0)
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
