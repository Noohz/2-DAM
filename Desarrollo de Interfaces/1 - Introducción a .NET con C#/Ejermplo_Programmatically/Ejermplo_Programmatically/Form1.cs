using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ejermplo_Programmatically
{
    public partial class Form1 : Form
    {
        Random Aleatorio = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                comboBox1.Items.Add(i + 1);
            }

            for (int i = 0; i < 30; i++)
            {
                comboBox2.Items.Add(i + 1);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Reseteo del contenedor.
            groupBox1.Controls.Clear();
            // Averiguar cuantos botones quiere el usuario.
            int nElementos = Convert.ToInt16(comboBox1.Text);

            for (int i = 0; i < nElementos; i++)
            {
                int numeroAleatorio = Aleatorio.Next(100);

                // Creamos el botón dinámicamente.
                Button botonX = new Button();

                // Añadimos la posición del botón (x,y).
                botonX.Location = new Point(100*i, 0);

                // Contenido del botón.
                botonX.Text = Convert.ToString(100 * i);

                // Añadimos el color de fondo al botón.
                botonX.BackColor = Color.Red;

                // Añadimos la capacidad de evento individualizado.
                botonX.Click += BotonX_Click;

                // Siempre que se crea un objeto dinamicamente hay que añadirlo al contenedor.
                groupBox1.Controls.Add(botonX);
            }
        }

        private void BotonX_Click(object sender, EventArgs e)
        {
            Button botonX = (Button) sender;
            MessageBox.Show(botonX.Text);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            flowLayoutPanel1.Controls.Clear();
            // Averiguar cuantos botones quiere el usuario.
            int nElementos = Convert.ToInt16(comboBox2.Text);

            for (int i = 0; i < nElementos; i++)
            {
                int numeroAleatorio = Aleatorio.Next(100);

                // Creamos el botón dinámicamente.
                Button botonX = new Button();

                botonX.BackColor = Color.Green;

                // Número aleatorio
                botonX.Text = Convert.ToString(numeroAleatorio);

                // Generar evento
                botonX.Click += BotonX_Click;

                flowLayoutPanel1.Controls.Add(botonX);
            }
        }
    }
}
