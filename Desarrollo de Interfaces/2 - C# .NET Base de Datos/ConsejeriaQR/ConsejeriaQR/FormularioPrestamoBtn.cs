using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    public partial class FormularioPrestamoBtn : Form
    {
        int segundos = 0;
        ClaseConectar cnxFPB;
        Articulos datosArticulo;
        List<Usuarios> usuario;

        public FormularioPrestamoBtn(object tag, ClaseConectar cnxIPA, List<Usuarios> datosUser)
        {
            InitializeComponent();
            this.Text = "Panel prestar artículo";

            cnxFPB = cnxIPA;

            datosArticulo = (Articulos)tag;
            usuario = datosUser;

            MemoryStream ms = new System.IO.MemoryStream(datosArticulo.Imagen);
            System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
            pictureBoxImgArticulo.Image = imagen;

            lblInfoArticulo.Text = datosArticulo.Nombre + " | " + datosArticulo.Codigo;

            MemoryStream mst = new System.IO.MemoryStream(datosArticulo.ImagenQR);
            System.Drawing.Image imagenQR = System.Drawing.Image.FromStream(mst);
            pictureBoxImagenQR.Image = imagenQR;

            textBoxCodigoQR.Focus();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBoxCodigoQR_TextChanged(object sender, EventArgs e)
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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            segundos++;

            if (segundos == 2)
            {
                timer1.Enabled = false;
                segundos = 0;

                if (cnxFPB.ComprobarQRExistente(textBoxCodigoQR.Text))
                {
                    cnxFPB.ActualizarArticulo(datosArticulo, 0);

                    FormularioConfirmaciónPrestamo fCP = new FormularioConfirmaciónPrestamo(cnxFPB, datosArticulo, usuario);
                    fCP.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error a la hora de procesar el código QR...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
