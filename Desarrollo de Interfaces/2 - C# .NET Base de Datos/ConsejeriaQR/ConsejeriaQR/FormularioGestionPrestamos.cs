using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    public partial class FormularioGestionPrestamos : Form
    {
        ClaseConectar cnxGP;

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
            Panel panelArticulo = iAA.generarPanelAniadirArticulos(panel3.Width, panel3.Height);
            Panel panelDatosBD = iAA.generarPanelDatosArticulosBD(panel3.Width, panel3.Height);

            List<Control> paneles = new List<Control> { panelArticulo, panelDatosBD };

            panel3.Controls.AddRange(paneles.ToArray());
        }

        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();

            InterfazEliminarArticulos iEA = new InterfazEliminarArticulos(cnxGP);
            Panel panelArticulo = iEA.generarPanelEliminarArticulos(panel3.Width, panel3.Height);
            panel3.Controls.Add(panelArticulo);
        }
    }
}