using System;
using System.Windows.Forms;

namespace Prueba3
{
    public partial class Form1 : Form
    {
        Random Aleatorio = new Random();

        int numero;
        int numeroIntentos = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            numero = Convert.ToInt16(textBox1.Text);
            timer1.Enabled = true;
            //textBox1.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            lblRandom.Text = "";
            lblContador.Text = "";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            numeroIntentos++;
            int numero2 = Aleatorio.Next(1, 100);
            label2.Text = Convert.ToString(numero2);
            lblCR.Text = Convert.ToString(numeroIntentos);

            if (numero == numero2)
            {
                timer1.Enabled = false;
            }
        }

        private void lblContador_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Todo lo que no sea un número se rechaza.
            if (!char.IsDigit(e.KeyChar))
            {
                // Rechazar tecla.
                e.Handled = true;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && Convert.ToInt16(textBox1.Text) < 100)
            {
                btnBuscar.Enabled = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                DialogResult resultado = MessageBox.Show("¿Quiere salir", "Proyecto3", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void lblRandom_Click(object sender, EventArgs e)
        {

        }
    }
}
