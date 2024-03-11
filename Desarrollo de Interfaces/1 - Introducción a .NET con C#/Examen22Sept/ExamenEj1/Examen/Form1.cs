using System;
using System.Windows.Forms;

namespace Examen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {

            while (groupBox1.Controls.Count > 0)
            {

                foreach (Control ctrl in groupBox1.Controls)
                {
                    if (ctrl.GetType() == typeof(Button))
                    {
                        flpBotones.Controls.Add(ctrl);
                        ctrl.Controls.Remove(ctrl);

                    }
                    else if (ctrl.GetType() == typeof(ComboBox))
                    {
                        flpComboBox.Controls.Add(ctrl);
                        ctrl.Controls.Remove(ctrl);

                    }
                    else if (ctrl.GetType() == typeof(TextBox))
                    {
                        flpTextBox.Controls.Add(ctrl);
                        ctrl.Controls.Remove(ctrl);

                    }
                    else if (ctrl.GetType() == typeof(Label))
                    {
                        flpLabels.Controls.Add(ctrl);
                        ctrl.Controls.Remove(ctrl);
                    }
                }

            }            
        }
    }
}
