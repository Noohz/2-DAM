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

        private void BtnVolverGestionPrestamos_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void BtnAniadirArticulo_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();

            InterfazAniadirArticulos iAA = new InterfazAniadirArticulos(cnxGP);
            Panel panelAniadirArticulo = iAA.GenerarPanelAniadirArticulos(panel3.Width, panel3.Height);
            Panel panelDatosBD = iAA.GenerarPanelDatosArticulosBD(panel3.Width, panel3.Height);

            List<Control> paneles = new List<Control> { panelAniadirArticulo, panelDatosBD };

            panel3.Controls.AddRange(paneles.ToArray());
        }

        private void BtnEliminarArticulo_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();

            InterfazEliminarArticulos iEA = new InterfazEliminarArticulos(cnxGP);
            Panel panelEliminarArticulo = iEA.GenerarPanelEliminarArticulos(panel3.Width, panel3.Height);
            panel3.Controls.Add(panelEliminarArticulo);
        }

        private void BtnPrestarArticulo_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();

            InterfazPrestarArticulo iPA = new InterfazPrestarArticulo(cnxGP);
            Panel panelPrestarArticulo = iPA.GenerarPanelPrestarArticulos(panel3.Width, panel3.Height);
            panel3.Controls.Add(panelPrestarArticulo);
        }
    }
}