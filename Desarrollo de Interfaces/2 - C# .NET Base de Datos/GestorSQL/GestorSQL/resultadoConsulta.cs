using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorSQL
{
    public partial class resultadoConsulta : Form
    {
        public resultadoConsulta()
        {
            InitializeComponent();
        }

        public void SetResultado(string resultado)
        {
            textBoxConsultaR1.Text = resultado;
        }
    }
}
