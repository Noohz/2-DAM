using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinesNavalmoral
{
    public partial class FormularioSesion : Form
    {
        public FormularioSesion(ClaseCartelera cc)
        {
            InitializeComponent();
            this.Text = cc.Titulo;
            label1.Text = cc.Titulo;

            MemoryStream ms = new MemoryStream(cc.Cartel);
            pictureBox1.BackgroundImage = Image.FromStream(ms);
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
