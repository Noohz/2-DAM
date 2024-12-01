using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    public partial class FormularioGestionPrestamos : Form
    {
        ClaseConectar cnxGP;
        List<Usuarios> datosUsuarioLogeado;

        public FormularioGestionPrestamos(List<Usuarios> datosUsuario, ClaseConectar cnxC)
        {
            InitializeComponent();
            this.Text = "Panel de Gestión de Préstamos";

            boton_desplegableAniadirArticulos.IsMainMenu = true;
            boton_desplegableAniadirArticulos.PrimaryColor = Color.FromArgb(85, 113, 73);

            datosUsuarioLogeado = datosUsuario;

            lblNombreUsuario.Text = datosUsuarioLogeado[0].Nombre;
            cnxGP = cnxC;

            ComprobarDepartamento(datosUsuario);
        }

        private void BtnAniadirArticulo_Click(object sender, EventArgs e)
        {           
            boton_desplegableAniadirArticulos.Show(btnAniadirArticulo, btnAniadirArticulo.Width, 0);
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

        private void BtnArticulosPrestados_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();

            InterfazArticulosPrestados iAP = new InterfazArticulosPrestados(cnxGP, datosUsuarioLogeado);
            Panel panelArticuloPrestado = iAP.GenerarPanelArticulosPrestados(panel3.Width, panel3.Height);
            panel3.Controls.Add(panelArticuloPrestado);

        }

        private void BtnArticulosMantenimiento_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();

            InterfarArticulosMantenimiento iAM = new InterfarArticulosMantenimiento(cnxGP);
            Panel panelArticulosMantenimiento = iAM.GenerarPanelArticulosMantenimiento(panel3.Width, panel3.Height);
            panel3.Controls.Add(panelArticulosMantenimiento);
        }

        private void ComprobarDepartamento(List<Usuarios> datosUsuario)
        {
            switch (datosUsuario[0].Departamento)
            {
                case "Administrador":
                    HabilitarBotonesAdministrador();
                    break;

                case "Conserje":
                    HabilitarBotonesConserje();
                    break;

                case "Profesor":
                    HabilitarBotonesProfesor();
                    break;
            }
        }        

        private void HabilitarBotonesAdministrador()
        {
            btnAniadirArticulo.Enabled = true;
            btnEliminarArticulo.Enabled = true;
            btnModificarArticulo.Enabled = true;
        }

        private void HabilitarBotonesConserje()
        {
            btnPrestarArticulo.Enabled = true;
            btnArticulosMantenimiento.Enabled = true;
        }

        private void HabilitarBotonesProfesor()
        {
            btnArticulosPrestados.Enabled = true;
        }

        private void BtnVolverGestionPrestamos_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void AniadirArtículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();

            InterfazAniadirArticulos iAA = new InterfazAniadirArticulos(cnxGP);
            Panel panelAniadirArticulo = iAA.GenerarPanelAniadirArticulos(panel3.Width, panel3.Height);
            Panel panelDatosBD = iAA.GenerarPanelDatosArticulosBD(panel3.Width, panel3.Height);

            List<Control> paneles = new List<Control> { panelAniadirArticulo, panelDatosBD };

            panel3.Controls.AddRange(paneles.ToArray());
        }

        private void CargarFicherosConDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();

            InterfazImportarFichero iIF = new InterfazImportarFichero(cnxGP);
            Panel panelImportarFichero = iIF.GenerarPanelImportarFichero(panel3.Width, panel3.Height);
            Panel panelDatosBD = iIF.GenerarPanelDatosArticulosBD(panel3.Width, panel3.Height);

            List<Control> paneles = new List<Control> { panelImportarFichero, panelDatosBD };
            panel3.Controls.AddRange(paneles.ToArray());
        }
    }
}