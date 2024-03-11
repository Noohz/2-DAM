using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Examen6Octubre
{
    public partial class Form1 : Form
    {
        List<ClaseFruta> listaFrutas = new List<ClaseFruta>();
        ClaseConectar cnx = new ClaseConectar();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            btnCargar.Visible = false;
            btnPagar.Visible = true;
            labelPrecioTotal.Visible = true;
            dgvCesta.Visible = true;
            flowLayoutPanel1.Visible = true;
            listaFrutas = cnx.listarFrutas();


            for (int i = 0; i < listaFrutas.Count; i++)
            {

                Button btnX = new Button();
                btnX.Width = 110;
                btnX.Height = 75;
                btnX.Click += BtnX_Click;
                btnX.Text = listaFrutas[i].Nombre;
                btnX.BackgroundImageLayout = ImageLayout.Zoom;
                btnX.Tag = listaFrutas[i];
                flowLayoutPanel1.Controls.Add(btnX);

                WebClient wc = new WebClient();
                MemoryStream ms = new MemoryStream(listaFrutas[i].Imagen);
                System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
                btnX.BackgroundImage = imagen;

                TextBox tbX = new TextBox();
                tbX.Width = 26;
                tbX.Height = 20;
                tbX.Text = listaFrutas[i].Precio.ToString();
                tbX.Enabled = false;
                flowLayoutPanel1.Controls.Add(tbX);
            }

        }

        private void BtnX_Click(object sender, EventArgs e)
        {
            Button btnX = (Button)sender;



        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            labelPrecioTotal.Text = "0";
            dgvCesta.Rows.Clear();
        }
    }
}
