using System;
using System.Drawing;
using System.Windows.Forms;

namespace Prueba_Cargar_Imagenes
{
    public partial class Form1 : Form
    {

        Random aleatorio = new Random();

        string[] arrayCombo2 = new string[] { "Colores", "Imágenes", "Números", "Ciclistas" }; // Un array que almacena las opciones del comboBox2.
        string[] arrayCiclistasCombo2 = new string[] { "Evenopel", "Vinegard", "Van Aert", "Ayuso", "Soler", "Mas", "Roglic" }; // Un array que contiene el nombre de los ciclistas.

        public Form1()
        {
            InitializeComponent();
        }

        // Al iniciar la aplicación el form carga los 25 items dentro del comboBox1 y las 4 opciones del comboBox2.
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 25; i++)
            {
                comboBox1.Items.Add(i + 1);
            }

            for (int i = 0; i < 4; i++)
            {
                comboBox2.Items.Add(arrayCombo2[i]);
            }
        }

        // Al hacer click se generan 20 botones que contendrán las imágenes aleatorias.
        private void button1_Click(object sender, EventArgs e)
        {

            flowLayoutPanel1.Controls.Clear();

            // Bucle para crear los botones y añadirlo al FLP.
            for (int i = 0; i < 20; i++)
            {
                // Propiedades de los botones.
                Button b = new Button
                {
                    Height = 100,
                    Width = 100,
                };
                flowLayoutPanel1.Controls.Add(b);

                // Recorre el FLP.
                foreach (Control ctrl in flowLayoutPanel1.Controls)
                {
                    // Si el control que recibe ctrl es un botón se le añade una imágen aleatoria.
                    if (ctrl.GetType() == typeof(Button))
                    {
                        int imagen = aleatorio.Next(1, 20);

                        Button btnx = (Button)ctrl;
                        btnx.BackgroundImage = Image.FromFile(@"imagenes\" + imagen + ".JPG");

                        btnx.Tag = imagen;

                        btnx.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                }
            }
        }

        // Botón para terminar el programa.
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Al seleccionar una opción del comboBox2 realiza una taréa según el texto que tenga.
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Elimina los botones que existiesen del FLP.
            flowLayoutPanel1.Controls.Clear();

            // Averiguar cuantos botones quiere el usuario.
            int nElementos = Convert.ToInt16(comboBox1.Text);

            // Recorremos con un bucle la cantidad de veces que se indica con el comboBox1.
            for (int i = 0; i < nElementos; i++)
            {

                if (comboBox2.Text == "Colores")
                {
                    int colorAleatorio = aleatorio.Next(1, 4);

                    // Datos del botón.
                    Button btn = new Button
                    {
                        Height = 30,
                        Width = 70,
                    };

                    // Con un if realizamos X acción dependiendo del número aleatorio que salga.
                    if (colorAleatorio == 1)
                    {
                        btn.BackColor = Color.Red;
                        btn.Text = "Rojo";
                    }
                    else if (colorAleatorio == 2)
                    {
                        btn.BackColor = Color.Green;
                        btn.Text = "Verde";
                    }
                    else
                    {
                        btn.BackColor = Color.Blue;
                        btn.Text = "Azul";
                    }

                    flowLayoutPanel1.Controls.Add(btn);
                }
                else if (comboBox2.Text == "Imágenes")
                {

                    // Datos del botón.
                    Button btn = new Button
                    {
                        Height = 100,
                        Width = 100,
                    };

                    int imagenAleatoria = aleatorio.Next(1, 20);

                    btn.BackgroundImage = Image.FromFile(@"imagenes\" + imagenAleatoria + ".JPG");

                    btn.BackgroundImageLayout = ImageLayout.Zoom;

                    flowLayoutPanel1.Controls.Add(btn);

                }
                else if (comboBox2.Text == "Números")
                {
                    int numeroAleatorio = aleatorio.Next(1, 100);

                    // Datos del botón.
                    Button btn = new Button
                    {
                        Height = 30,
                        Width = 70,
                        BackColor = Color.Aquamarine,
                    };

                    btn.Text = numeroAleatorio.ToString();

                    flowLayoutPanel1.Controls.Add(btn);

                }
                else if (comboBox2.Text == "Ciclistas")
                {
                    int CiclistaAleatorio = aleatorio.Next(0, arrayCiclistasCombo2.Length); // Genera un número aleatorio entre 0 y la longitud del array (Que en este caso es 7).

                    // Datos del botón.
                    Button btn = new Button
                    {
                        Height = 30,
                        Width = 70,
                        BackColor = Color.Aquamarine,
                    };

                    btn.Text = arrayCiclistasCombo2[CiclistaAleatorio];

                    flowLayoutPanel1.Controls.Add(btn);
                }
            }
        }
    }
}