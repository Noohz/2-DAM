using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConectarBD
{

    public partial class Form2 : Form
    {
        internal ArrayList lista2 = new ArrayList();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach(String item in lista2){
                listBox1.Items.Add(item);
            }
        }
    }
}
