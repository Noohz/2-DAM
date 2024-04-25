using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Juego1_Abril25
{
    public partial class Form1 : Form
    {
        Random numAleatorio = new Random();
        int tiempoObservacion = 5;
        int tiempoJugar = 10;
        int puntuacion = 0;

        int[] imgBuscada = new int[1];

        public Form1()
        {
            InitializeComponent();
            this.Text = "Juego 1";
            fLPJuego.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int numeroImagen = numAleatorio.Next(1, 19);

            btnImagenBuscada.BackgroundImage = Image.FromFile(@"imagenes\" + numeroImagen + ".JPG");
            btnImagenBuscada.BackgroundImageLayout = ImageLayout.Stretch;
            imgBuscada[0] = numeroImagen;

            for (int i = 0; i < 30; i++)
            {
                Button boton = new Button();

                int imgBoton = numAleatorio.Next(1, 19);

                boton.Width = 100;
                boton.Height = 80;
                boton.BackgroundImage = Image.FromFile(@"imagenes\" + imgBoton + ".JPG");
                boton.BackgroundImageLayout = ImageLayout.Stretch;
                boton.Tag = imgBoton;
                boton.Click += Boton_Click;

                fLPJuego.Controls.Add(boton);
            }
        }

        private void Boton_Click(object sender, EventArgs e)
        {
            Button btnx = (Button)sender;

            int imagen = (int)btnx.Tag;

            if (imgBuscada[0] == imagen)
            {
                puntuacion++;
                lblPuntuacion.Text = puntuacion.ToString();
            }
            else
            {
                puntuacion--;
                lblPuntuacion.Text = puntuacion.ToString();
            }
        }

        private void timerObservar_Tick(object sender, EventArgs e)
        {
            fLPJuego.Enabled = false;
            tiempoJugar = 10;
            lblTJuego.Text = tiempoJugar.ToString();

            lblTObservar.Text = tiempoObservacion.ToString();
            tiempoObservacion--;

            if (tiempoObservacion <= 0)
            {
                timerJugar.Enabled = true;
                timerObservar.Enabled = false;
            }
        }

        private void timerJugar_Tick(object sender, EventArgs e)
        {
            fLPJuego.Enabled = true;
            tiempoObservacion = 5;
            lblTObservar.Text = tiempoObservacion.ToString();

            lblTJuego.Text = tiempoJugar.ToString();
            tiempoJugar--;

            if (tiempoJugar <= 0)
            {
                timerJugar.Enabled = false;
                timerObservar.Enabled = true;
            }
        }
    }
}
