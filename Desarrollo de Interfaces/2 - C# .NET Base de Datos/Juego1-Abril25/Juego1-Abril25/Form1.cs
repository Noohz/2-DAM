using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Juego1_Abril25
{
    public partial class Form1 : Form
    {
        ConectarBD cnx = new ConectarBD();

        Random numAleatorio = new Random();
        int tiempoO = 10;
        int tiempoJ = 10;
        int puntuacion = 0;

        int imgBuscada;

        List<String> niveles = new List<String>() { "10", "20", "30" };
        List<Personaje> imgSimpsons = new List<Personaje>();
        List<Personaje> imgManzana = new List<Personaje>();

        public Form1()
        {
            InitializeComponent();
            this.Text = "Juego 1";
            fLPJuego.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cBNiveles.Items.AddRange(niveles.ToArray());
        }

        private void Boton_Click(object sender, EventArgs e)
        {
            cBNiveles.Focus();

            Button btnx = (Button)sender;

            int imgClickada = (int)btnx.Tag;
                 
            if (imgBuscada == imgClickada)
            {
                if (cBNiveles.SelectedIndex == 0)
                {                    
                    puntuacion += 10;
                    lblPuntuacion.Text = puntuacion.ToString();
                }
                else if (cBNiveles.SelectedIndex == 1)
                {
                    puntuacion += 20;
                    lblPuntuacion.Text = puntuacion.ToString();
                }
                else if (cBNiveles.SelectedIndex == 2)
                {
                    puntuacion += 30;
                    lblPuntuacion.Text = puntuacion.ToString();
                }
            }
            else
            {
                if (cBNiveles.SelectedIndex == 0)
                {
                    puntuacion -= 10;
                    lblPuntuacion.Text = puntuacion.ToString();
                }
                else if (cBNiveles.SelectedIndex == 1)
                {
                    puntuacion -= 20;
                    lblPuntuacion.Text = puntuacion.ToString();
                }
                else if (cBNiveles.SelectedIndex == 2)
                {
                    puntuacion -= 30;
                    lblPuntuacion.Text = puntuacion.ToString();
                }
            }
            btnx.Enabled = false;
        }

        // Pendiente img manzana.
        private void timerObservar_Tick(object sender, EventArgs e)
        {
            fLPJuego.Enabled = false;
            lblTJuego.Text = tiempoO.ToString();

            lblTObservar.Text = "¡Visualizando!";
            tiempoO--;

            if (tiempoO <= 0)
            {
                timerJugar.Enabled = true;
                tiempoO = 10;

                imgManzana = cnx.obtenerImgManzana();

                for (int i = 0; i < fLPJuego.Controls.Count; i++)
                {
                    MemoryStream ms = new System.IO.MemoryStream(imgManzana[0].Imagen);
                    System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
                    fLPJuego.Controls[i].BackgroundImage = imagen;
                    btnImagenBuscada.BackgroundImageLayout = ImageLayout.Stretch;                    
                }

                timerObservar.Enabled = false;
            }
        }

        private void timerJugar_Tick(object sender, EventArgs e)
        {
            fLPJuego.Enabled = true;
            lblTObservar.Text = "¡Jugando!";

            lblTJuego.Text = tiempoJ.ToString();
            tiempoJ--;

            if (tiempoJ < 0)
            {
                timerJugar.Enabled = false;
                fLPJuego.Enabled = false;
                lblTObservar.Text = "¡Fín!";
                tiempoJ = 10;
            }
        }

        private void cBNiveles_SelectedIndexChanged(object sender, EventArgs e)
        {
            timerObservar.Enabled = false;
            tiempoO = 10;
            lblTJuego.Text = tiempoO.ToString();
            cargarJuego();
        }

        private void cargarJuego()
        {
            fLPJuego.Controls.Clear();

            int numeroImagen = numAleatorio.Next(1, 15);
            imgBuscada = numeroImagen;
            Console.WriteLine("imagen buscada " + numeroImagen.ToString());

            imgSimpsons = cnx.cargarImagenes(); // Lista que contiene los datos de la tabla simpsons.          

            // Convertir de Blob > Interface para la imágen que tiene que buscar el jugador.
            MemoryStream ms = new System.IO.MemoryStream(imgSimpsons[numeroImagen].Imagen);
            System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
            btnImagenBuscada.BackgroundImage = imagen;
            btnImagenBuscada.BackgroundImageLayout = ImageLayout.Stretch;

            if (cBNiveles.SelectedIndex == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    Button boton = new Button();

                    int imgBoton = numAleatorio.Next(1, 15);

                    boton.Width = 90;
                    boton.Height = 80;

                    MemoryStream ms1 = new System.IO.MemoryStream(imgSimpsons[imgBoton].Imagen);
                    System.Drawing.Image imagen1 = System.Drawing.Image.FromStream(ms1);
                    boton.BackgroundImage = imagen1;
                    boton.BackgroundImageLayout = ImageLayout.Stretch;

                    boton.Tag = imgBoton;
                    boton.Click += Boton_Click;

                    Console.WriteLine("Boton " + imgBoton.ToString());
                    fLPJuego.Controls.Add(boton);
                }
            }
            else if (cBNiveles.SelectedIndex == 1)
            {
                for (int i = 0; i < 20; i++)
                {
                    Button boton = new Button();

                    int imgBoton = numAleatorio.Next(1, 15);

                    boton.Width = 90;
                    boton.Height = 80;

                    MemoryStream ms1 = new System.IO.MemoryStream(imgSimpsons[imgBoton].Imagen);
                    System.Drawing.Image imagen1 = System.Drawing.Image.FromStream(ms1);
                    boton.BackgroundImage = imagen1;
                    boton.BackgroundImageLayout = ImageLayout.Stretch;

                    boton.Tag = imgBoton;
                    boton.Click += Boton_Click;

                    fLPJuego.Controls.Add(boton);
                }
            }
            else if (cBNiveles.SelectedIndex == 2)
            {
                for (int i = 0; i < 30; i++)
                {
                    Button boton = new Button();

                    int imgBoton = numAleatorio.Next(1, 15);

                    boton.Width = 90;
                    boton.Height = 80;

                    MemoryStream ms1 = new System.IO.MemoryStream(imgSimpsons[imgBoton].Imagen);
                    System.Drawing.Image imagen1 = System.Drawing.Image.FromStream(ms1);
                    boton.BackgroundImage = imagen1;
                    boton.BackgroundImageLayout = ImageLayout.Stretch;

                    boton.Tag = imgBoton;
                    boton.Click += Boton_Click;

                    fLPJuego.Controls.Add(boton);
                }
            }
            timerObservar.Enabled = true;
        }
             
        private void cBNiveles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Space)
            {

                if (cBNiveles.SelectedIndex == 0)
                {
                    puntuacion -= 10;
                    lblPuntuacion.Text = puntuacion.ToString();

                    timerJugar.Enabled = false;
                    tiempoO = 10;
                    tiempoJ = 10;
                    lblTJuego.Text = tiempoO.ToString();
                }
                else if (cBNiveles.SelectedIndex == 1)
                {
                    puntuacion -= 20;
                    lblPuntuacion.Text = puntuacion.ToString();

                    timerJugar.Enabled = false;
                    tiempoO = 10;
                    tiempoJ = 10;
                    lblTJuego.Text = tiempoO.ToString();
                }
                else if (cBNiveles.SelectedIndex == 2)
                {
                    puntuacion -= 30;
                    lblPuntuacion.Text = puntuacion.ToString();

                    timerJugar.Enabled = false;
                    tiempoO = 10;
                    tiempoJ = 10;
                    lblTJuego.Text = tiempoO.ToString();
                }
                cargarJuego();
            }
            else if (e.KeyCode == Keys.F12)
            {
                puntuacion = 0;
                lblPuntuacion.Text = puntuacion.ToString();

                tiempoO = 10;
                tiempoJ = 10;
                lblTJuego.Text = tiempoO.ToString();

                timerJugar.Enabled = false;
                timerObservar.Enabled = false;

                fLPJuego.Controls.Clear();
                btnImagenBuscada.BackgroundImage = null;
            }
        }
    }
}
