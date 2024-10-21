using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    public partial class FormularioGestionPrestamos : Form
    {
        ClaseConectar cnxGP;
        String nombreImagen;

        List<Control> listaControles;

        public FormularioGestionPrestamos(List<usuarios> datosUsuario, ClaseConectar cnxC)
        {
            InitializeComponent();
            this.Text = "Panel de Gestión de Préstamos";

            lblNombreUsuario.Text = datosUsuario[0].Nombre;
            cnxGP = cnxC;
        }

        private void btnVolverGestionPrestamos_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnAniadirArticulo_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();

            InterfazAniadirArticulos iAA = new InterfazAniadirArticulos(cnxGP);
            Panel panelArticulo = iAA.generarPanelArticulos();

            panel3.Controls.Add(panelArticulo);
        }

        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            // Que aparezca un comboBox que utilice los nombres de la bd articulos y que aparezcan en un table / flow laout panel
        }
    }
}