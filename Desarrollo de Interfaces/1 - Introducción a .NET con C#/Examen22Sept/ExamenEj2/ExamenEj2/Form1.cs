using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExamenEj2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 6; i++)
            {
                comboBox2.Items.Add(i);
            }

            comboBox1.Items.Add("ComboBox");
            comboBox1.Items.Add("TextBox");
            comboBox1.Items.Add("Label");
            comboBox1.Items.Add("Button");


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            flp1.Controls.Clear();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nElementos = Convert.ToInt32(comboBox2.Text);

            if (comboBox1.SelectedIndex == 0)
            {
                flp1.Controls.Clear();

                for (int i = 0; i < nElementos; i++)
                {
                    ComboBox cb1 = new ComboBox();

                    flp1.Controls.Add(cb1);
                }

            }
            else if (comboBox1.SelectedIndex == 1)
            {

                flp1.Controls.Clear();

                for (int i = 0; i < nElementos; i++)
                {
                    TextBox tb1 = new TextBox();

                    flp1.Controls.Add(tb1);
                }

            }
            else if (comboBox1.SelectedIndex == 2)
            {

                flp1.Controls.Clear();

                for (int i = 0; i < nElementos; i++)
                {
                    Label lb1 = new Label();
                    lb1.Text = "Label" + i;

                    flp1.Controls.Add(lb1);
                }

            }
            else if (comboBox1.SelectedIndex == 3)
            {

                flp1.Controls.Clear();

                for (int i = 0; i < nElementos; i++)
                {
                    Button btn1 = new Button();
                    btn1.BackColor = Color.Red;

                    flp1.Controls.Add(btn1);
                }

            }
        }
    }
}
