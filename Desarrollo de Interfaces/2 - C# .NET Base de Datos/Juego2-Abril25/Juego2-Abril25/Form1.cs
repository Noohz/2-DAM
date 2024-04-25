using System;
using System.Drawing;
using System.Windows.Forms;

namespace Juego2_Abril25
{
    public partial class Form1 : Form
    {
        Random numAleatorio = new Random();
        int puntos = 0;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Ejercicio 2";
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            puntos = 0;
            lblPuntos.Text = puntos.ToString();

            fLPJuego.Controls.Clear();
            timer1.Start();

            lblNumeroBuscado.Text = numAleatorio.Next(1, 25).ToString();

            for (int i = 0; i < 25; i++)
            {
                int nAleatorio = numAleatorio.Next(1, 25);

                Button boton = new Button();
                boton.Width = 55;
                boton.Height = 55;
                boton.TextAlign = ContentAlignment.MiddleCenter;
                boton.Text = nAleatorio.ToString();
                boton.Tag = nAleatorio;

                boton.Click += Boton_Click;

                fLPJuego.Controls.Add(boton);
            }
        }

        private void Boton_Click(object sender, EventArgs e)
        {
            Button btnx = (Button)sender;

            int numeroBoton = (int)btnx.Tag;
            int numeroCorrecto = Convert.ToInt16(lblNumeroBuscado.Text);

            if (numeroBoton == numeroCorrecto)
            {
                puntos++;
                lblPuntos.Text = puntos.ToString();
            }
            else if (numeroBoton != numeroCorrecto)
            {
                puntos--;
                lblPuntos.Text = puntos.ToString();
            }

            btnx.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            fLPJuego.Controls.Clear();

            lblNumeroBuscado.Text = numAleatorio.Next(1, 25).ToString();

            for (int i = 0; i < 25; i++)
            {
                int nAleatorio = numAleatorio.Next(1, 25);

                Button boton = new Button();
                boton.Width = 55;
                boton.Height = 55;
                boton.TextAlign = ContentAlignment.MiddleCenter;
                boton.Text = nAleatorio.ToString();
                boton.Tag = nAleatorio;

                boton.Click += Boton_Click;

                fLPJuego.Controls.Add(boton);
            }
        }
    }
}
