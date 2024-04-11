using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            lblNSala.Text = arrayListSesiones[0].Sala.ToString();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listaSesiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormularioButacas fB = new FormularioButacas(lblTitulo.Text, listaSesiones.SelectedItem.ToString(), lblNSala.Text);
            fB.ShowDialog();
        }
    }
}