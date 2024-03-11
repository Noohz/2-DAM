using System;
using System.Drawing;
using System.Windows.Forms;

namespace Prueba8
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int verde = 0;
            int rojo = 0;

            Button btnX = (Button)sender;
            int cont = flowLayoutPanel1.Controls.Count;

            if (btnX.BackColor.Name == "Red")
            {
                btnX.BackColor = Color.Green;
                btnX.Text = "Verde";
                btnX.Tag = "Verde";
            }
            else
            {
                btnX.BackColor = Color.Red;
                btnX.Text = "Rojo";
                btnX.Tag = "Rojo";
            }

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl.Text.Equals("Rojo"))
                {
                    rojo++;
                }

                if (ctrl.Text.Equals("Verde"))
                {
                    verde++;
                }
            }

            if (rojo == cont)
            {
                btnTodoRojo.BackColor = Color.Red;
            }

            if (verde == cont)
            {
                btnTodoVerde.BackColor = Color.Green;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTodoVerde_Click(object sender, EventArgs e)
        {

            timer1Verde.Enabled = true;


            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {

                if (ctrl.BackColor.Name != "Green")
                {
                    ctrl.BackColor = Color.Green;
                    ctrl.Text = "Verde";
                }
            }
        }

        private void btnTodoRojo_Click(object sender, EventArgs e)
        {
            timer2Rojo.Enabled = true;

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl.Text != ("Rojo"))
                {
                    ctrl.BackColor = Color.Red;
                    ctrl.Text = "Rojo";
                }
            }
        }

        private void timer1_Verde(object sender, EventArgs e)
        {
            int cVerde = 0;

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl.BackColor.Name == "Green")
                {
                    cVerde++;
                }
            }

            if (cVerde == flowLayoutPanel1.Controls.Count)
            {
                btnTodoVerde.BackColor = Color.Green;
            }
            else
            {
                btnTodoVerde.BackColor = Color.RoyalBlue;
            }
        }

        private void timer2Rojo_Tick(object sender, EventArgs e)
        {
            int cRojo = 0;

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl.BackColor.Name == "Red")
                {
                    cRojo++;
                }
            }

            if (cRojo == flowLayoutPanel1.Controls.Count)
            {
                btnTodoRojo.BackColor = Color.Red;
            }
            else
            {
                btnTodoRojo.BackColor = Color.RoyalBlue;
            }
        }
    }
}
