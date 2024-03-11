using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnPrueba1_Click(object sender, EventArgs e)
        {
            // Para generar números aleatorios utilizar clase Random.
            Random aleatorio = new Random();

            // Generar un número int aleatorio entre 1 y 1000.
            int numeroAleatorio = aleatorio.Next(1, 1000);

            // Mostrar en pantalla (string) hay que convertir.
            lblMuestra.Text = Convert.ToString(numeroAleatorio);

            for (int i = 0; i < 10; i++)
            {
                // listbox:array gráfico en vertical.
                numeroAleatorio++;
                lstListaNumeros.Items.Add(numeroAleatorio);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
