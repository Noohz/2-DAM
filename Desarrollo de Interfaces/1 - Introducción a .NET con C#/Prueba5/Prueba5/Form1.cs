using System;
using System.Windows.Forms;

namespace Prueba5
{
    public partial class Form1 : Form
    {
        Random Aleatorio = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void lblRandom_Click(object sender, EventArgs e)
        {
            // Añade un número aleatorio a los labels que están dentro del groupbox
            foreach (Control ctrl in groupBox1.Controls)
            {
                ctrl.Text = Convert.ToString(Aleatorio.Next(1, 50));
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Creamos el evento.
            Label lblx = (Label)sender;
            MessageBox.Show("Soy " + lblx.Text);
        }
    }
}
