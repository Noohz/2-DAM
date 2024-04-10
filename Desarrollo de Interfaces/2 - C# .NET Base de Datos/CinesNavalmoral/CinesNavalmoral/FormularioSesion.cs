using System;
using System.Collections;
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
        ClaseConectar cnx = new ClaseConectar();

        List<ClaseCartelera> arrayListSesiones = new List<ClaseCartelera>();

        public FormularioSesion(ClaseCartelera cc)
        {
            InitializeComponent();
            this.Text = cc.Titulo;
            lblTitulo.Text = cc.Titulo;

            MemoryStream ms = new MemoryStream(cc.Cartel);
            pBCartel.BackgroundImage = Image.FromStream(ms);
            pBCartel.BackgroundImageLayout = ImageLayout.Stretch;

            arrayListSesiones = cnx.cargarSesionesPelicula(cc.Titulo);
        }

        private void FormularioSesion_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < arrayListSesiones.Count; i++)
            {
                listaSesiones.Items.Add(arrayListSesiones[i].Sesion);
            }
            lblSala.Text += arrayListSesiones[0].Sala.ToString();
        }
    }
}
