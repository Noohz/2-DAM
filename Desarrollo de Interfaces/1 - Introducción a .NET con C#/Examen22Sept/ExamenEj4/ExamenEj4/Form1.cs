using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExamenEj4
{
    public partial class Form1 : Form
    {

        Random aleatorio = new Random();
        int puntuacion = 0;
        public Form1()
        {
            InitializeComponent();

            MessageBox.Show("Aparecerán labels aleatorios por el formulario, si clickas en ellos ganaras un punto, si fallas perderas 1.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = aleatorio.Next(400);
            int y = aleatorio.Next(400);

            Label lb = new Label();
            lb.Height = 20;
            lb.Width = 50;
            lb.Location = new Point(x, y);
            lb.BackColor = Color.Red;
            lb.Click += Lb_Click;


            this.Controls.Add(lb);
        }

        private void Lb_Click(object sender, EventArgs e)
        {

            Label lb = (Label)sender;

            puntuacion++;

            lblPuntuacion.Text = puntuacion.ToString();

            lb.Visible = false;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            puntuacion--;

            lblPuntuacion.Text = puntuacion.ToString();
        }
    }
}
