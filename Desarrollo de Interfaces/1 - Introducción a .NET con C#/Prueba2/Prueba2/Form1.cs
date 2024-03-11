using System;
using System.Windows.Forms;

namespace Prueba2
{
    public partial class Form1 : Form
    {
        Random aleatorio = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int numeroAleatorio = aleatorio.Next(10);
            lblRandom.Text = Convert.ToString(numeroAleatorio);

            if (numeroAleatorio >= 5)
            {
                lstMayor.Items.Add(numeroAleatorio);
            }
            else
            {

                lstMenor.Items.Add(numeroAleatorio);
            }
        }
        private void btnEmpezar_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void lblRandom_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPausar_Click(object sender, EventArgs e)
        {
            if (btnPausar.Text == "Pausar")
            {
                btnPausar.Text = "Reanudar";
                timer1.Enabled = false;
            }
            else
            {
                btnPausar.Text = "Pausar";
                timer1.Enabled = true;
            }
        }

        private void lstMenor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
