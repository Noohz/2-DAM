using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba4
{
    public partial class Form1 : Form
    {

        int numero = 10;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            if (numero <= 0)
            {
                numero = 10;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {           

            lblCuentaAtras.Text = numero--.ToString();

            if (numero <= 10)
            {
                lblCuentaAtras.BackColor = Color.Yellow;
            }

            if (numero < 6)
            {
                lblCuentaAtras.BackColor = Color.LightBlue;
            }

            if (numero == 2)
            {
                lblCuentaAtras.BackColor = Color.Orange;
            }

            if (numero < 2)
            {
                lblCuentaAtras.BackColor = Color.Red;
            }

            if (numero < 0)
            {
                timer1.Stop();
                lblCuentaAtras.Text = "";
                lblCuentaAtras.BackColor = DefaultBackColor;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
