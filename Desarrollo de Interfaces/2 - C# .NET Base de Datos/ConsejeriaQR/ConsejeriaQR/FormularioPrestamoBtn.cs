﻿using System;
using System.IO;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    public partial class FormularioPrestamoBtn : Form
    {
        int segundos = 0;
        ClaseConectar cnxFPB;
        Articulos datosArticulo;

        public FormularioPrestamoBtn(object tag, ClaseConectar cnxIPA)
        {
            InitializeComponent();
            this.Text = "Panel prestar artículo";

            cnxFPB = cnxIPA;

            datosArticulo = (Articulos)tag;

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
            cnxFPB.ActualizarArticulo(datosArticulo, 1);
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
                    FormularioConfirmaciónPrestamo fCP = new FormularioConfirmaciónPrestamo(cnxFPB, datosArticulo);
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
