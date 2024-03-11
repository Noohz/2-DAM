using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RepasoTodo
{
    public partial class Form1 : Form
    {
        Random aleatorio = new Random();
        Color[] colores = { Color.Blue, Color.Red, Color.Green };
        String[] nombreCiclistas = { "MOu", "Samuel", "David", "Aitor", "Hamza" };
        int[] vector = new int[20];
        int segundos = 30;
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 30; i++)
            {
                comboBox1.Items.Add(i);
            }
            comboBox1.SelectedItem = 1;
            comboBox2.Items.Add("Ciclistas");
            comboBox2.Items.Add("Números");
            comboBox2.Items.Add("Imágenes");
            comboBox2.Items.Add("Colores");

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            flp.Controls.Clear();
            int numeroElementos = Convert.ToInt16(comboBox1.Text);
            for (int i = 0; i < numeroElementos; i++)
            {
                Button btnX = new Button();
                btnX.AutoSize = true;
                ContenidoBoton(btnX);
                btnX.Click += BtnX_Click;
                btnX.Tag = i;
                flp.Controls.Add(btnX);
            }
        }

        private void ContenidoBoton(Button btnX)
        {
            switch (comboBox2.Text)
            {
                case "Ciclistas":
                    int numero = aleatorio.Next(0, nombreCiclistas.Count());
                    btnX.Text = nombreCiclistas[numero];
                    btnX.BackColor = Color.Green;
                    break;

                case "Números":
                    btnX.Text = aleatorio.Next(1, 1000).ToString();
                    btnX.Tag = btnX.Text;
                    break;

                case "Imágenes":
                    int numeroImagen = aleatorio.Next(0, vector.Length);
                    String ruta = ".\\imagenes\\" + numeroImagen + ".jpg";
                    btnX.AutoSize = true;

                    btnX.BackgroundImageLayout = ImageLayout.Stretch;
                    btnX.Tag = numeroImagen;
                    btnX.Image = Image.FromFile(ruta);
                    break;
                case "Colores":
                    int nColores = aleatorio.Next(0, colores.Length);
                    btnX.Text = Convert.ToString(colores[nColores].Name);
                    btnX.Tag = btnX.Text;
                    btnX.BackColor = colores[nColores];
                    break;

            }
        }

        private void BtnX_Click(object sender, EventArgs e)
        {
            Button btnX = (Button)sender;
            if (btnX.Text == null)
            {
                MessageBox.Show("Soy " + btnX.Tag);
            }
            else
            {
                MessageBox.Show("Soy " + btnX.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] vector2 = new int[20];
            for (int i = 0; i < 20; i++)
            {
                vector2[i] = -1;
            }

            for (int i = 0; i < 20; i++)
            {
                Button btnX = new Button();
                int numeroA = aleatorio.Next(0, 20);
                while (vector2.Contains(numeroA))
                {
                    numeroA = aleatorio.Next(0, 20);

                }
                vector2[i] = numeroA;
                btnX.Width = 100;
                btnX.Height = 90;
                btnX.BackgroundImage = Image.FromFile(".\\imagenes\\" + vector2[i] + ".jpg");
                flp.Controls.Add(btnX);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            flp.Controls.Clear();

            for (int i = 0; i < 20; i++)
            {
                Button btnX = new Button();
                int numeroA = aleatorio.Next(0, 20);

                btnX.Width = 100;
                btnX.Height = 90;
                btnX.BackgroundImage = Image.FromFile(".\\imagenes\\" + numeroA + ".jpg");
                flp.Controls.Add(btnX);
            }
            timer1.Enabled = true;
            pictureBox1.BackgroundImage = Image.FromFile(".\\imagenes\\" + aleatorio.Next(0, 20) + ".jpg");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (segundos % 5 == 0)
            {
                flp.Controls.Clear();
                for (int i = 0; i < 20; i++)
                {
                    Button btnX = new Button();
                    int numeroA = aleatorio.Next(0, 20);

                    btnX.Width = 100;
                    btnX.Height = 90;
                    btnX.BackgroundImage = Image.FromFile(".\\imagenes\\" + numeroA + ".jpg");
                    flp.Controls.Add(btnX);
                }
                pictureBox1.BackgroundImage = Image.FromFile(".\\imagenes\\" + aleatorio.Next(0, 20) + ".jpg");

            }
            segundos--;
            lblSegundos.Text = Convert.ToString(segundos);
            if (segundos == -1)
            {
                timer1.Stop();
                segundos = 30;
                lblSegundos.Text = "30";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("aaaaaaa");
        }
    }
}
