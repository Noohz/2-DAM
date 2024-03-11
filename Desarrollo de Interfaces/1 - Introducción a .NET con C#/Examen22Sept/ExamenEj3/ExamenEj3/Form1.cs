using System;
using System.Windows.Forms;

namespace ExamenEj3
{
    public partial class Form1 : Form
    {
        int puntuacion = 0;

        Random aleatorio = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {

            flowLayoutPanel1.Controls.Clear();

            timer1.Enabled = true;

            for (int i = 0; i < 25; i++)
            {

                int numeroAleatorio = aleatorio.Next(1, 25);

                Button btn = new Button();
                btn.AutoSize = true;
                btn.Text = numeroAleatorio.ToString();
                btn.Tag = i;

                btn.Click += Btn_Click;

                flowLayoutPanel1.Controls.Add(btn);
            }

            int numeroAleatorioTimer = aleatorio.Next(1, 25);
            lblNumeroBuscado.Text = numeroAleatorioTimer.ToString();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            timer1.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            for (int i = 0; i < 25; i++)
            {

                int numeroAleatorio = aleatorio.Next(1, 25);

                Button btn = new Button();
                btn.AutoSize = true;
                btn.Text = numeroAleatorio.ToString();
                btn.Tag = i;

                btn.Click += Btn_Click;

                flowLayoutPanel1.Controls.Add(btn);
            }

            int numeroAleatorioTimer = aleatorio.Next(1, 25);
            lblNumeroBuscado.Text = numeroAleatorioTimer.ToString();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int numeroBoton = int.Parse(btn.Text);
            int numeroLabel = int.Parse(lblNumeroBuscado.Text);

            btn.Enabled = false;

            if (numeroBoton == numeroLabel)
            {
                puntuacion++;

                lblPuntos.Text = puntuacion.ToString();
            } else
            {
                puntuacion--;

                lblPuntos.Text = puntuacion.ToString();
            }
        }

    }
}
