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

        /// <summary>
        /// Evento que se encarga de mostrar un desplegable con las distintas opciones para añadir un producto.
        /// </summary>
        private void BtnAniadirArticulo_Click(object sender, EventArgs e)
        {           
            boton_desplegableAniadirArticulos.Show(btnAniadirArticulo, btnAniadirArticulo.Width, 0);
        }

        /// <summary>
        /// Evento que se encarga de llamar al Form "InterfazEliminarArticulos" para generar el panel que le permite al usuario seleccionar un artículo de la lista y eliminarlo.
        /// </summary>
        private void BtnEliminarArticulo_Click(object sender, EventArgs e)
        {
                panel3.Controls.Clear();

                InterfazEliminarArticulos iEA = new InterfazEliminarArticulos(cnxGP);
                Panel panelEliminarArticulo = iEA.GenerarPanelEliminarArticulos(panel3.Width, panel3.Height);
                panel3.Controls.Add(panelEliminarArticulo);            
        }

        /// <summary>
        /// Evento que se engarga de llamar al Form "InterfazPrestarArticulo" para que genere el panel que le permita al usuario seleccionar un artículo de la lista para realizar el prestamo.
        /// </summary>
        private void BtnPrestarArticulo_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();

            InterfazPrestarArticulo iPA = new InterfazPrestarArticulo(cnxGP);
            Panel panelPrestarArticulo = iPA.GenerarPanelPrestarArticulos(panel3.Width, panel3.Height);
            panel3.Controls.Add(panelPrestarArticulo);
        }

        /// <summary>
        /// Evento que se encarga de llamar al Form "InterfazArticulosPrestados" para generar el panel que permita al usuario visualizar sus artículos en prestamo.
        /// </summary>
        private void BtnArticulosPrestados_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();

            InterfazArticulosPrestados iAP = new InterfazArticulosPrestados(cnxGP, datosUsuarioLogeado);
            Panel panelArticuloPrestado = iAP.GenerarPanelArticulosPrestados(panel3.Width, panel3.Height);
            panel3.Controls.Add(panelArticuloPrestado);

        }

        /// <summary>
        /// Evento que se encarga de llamar al Form "InterfarArticulosMantenimiento" para generar el panel que le permita al usuario visualizar los artículos que estan en mantenimiento.
        /// </summary>
        private void BtnArticulosMantenimiento_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();

            InterfarArticulosMantenimiento iAM = new InterfarArticulosMantenimiento(cnxGP);
            Panel panelArticulosMantenimiento = iAM.GenerarPanelArticulosMantenimiento(panel3.Width, panel3.Height);
            panel3.Controls.Add(panelArticulosMantenimiento);
        }

        /// <summary>
        /// Método que se encarga de comparar si el departamento del usuario coincide con algúna de las opciones para habilitar los respectivos botones.
        /// </summary>
        /// <param name="datosUsuario"> Lista con los datos del usuario logeado. </param>
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

        /// <summary>
        /// Evento del boton desplegable que se encarga de llamar al Form "InterfazAniadirArticulos" para generar el panel que permite al usuario añadir un artículo a la BBDD.
        /// </summary>
        private void AniadirArtículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();

            InterfazAniadirArticulos iAA = new InterfazAniadirArticulos(cnxGP);
            Panel panelAniadirArticulo = iAA.GenerarPanelAniadirArticulos(panel3.Width, panel3.Height);
            Panel panelDatosBD = iAA.GenerarPanelDatosArticulosBD(panel3.Width, panel3.Height);

            List<Control> paneles = new List<Control> { panelAniadirArticulo, panelDatosBD };

            panel3.Controls.AddRange(paneles.ToArray());
        }

        /// <summary>
        /// Evento del boton desplegable que se encarga de llamar al Form "InterfazImportarFichero" para permitir que el usuario utilice un archivo .CSV para cargar los archivos en la BBDD.
        /// </summary>
        private void CargarFicherosConDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();

            InterfazImportarFichero iIF = new InterfazImportarFichero(cnxGP);
            Panel panelImportarFichero = iIF.GenerarPanelImportarFichero(panel3.Width, panel3.Height);
            Panel panelDatosBD = iIF.GenerarPanelDatosArticulosBD(panel3.Width, panel3.Height);

            List<Control> paneles = new List<Control> { panelImportarFichero, panelDatosBD };
            panel3.Controls.AddRange(paneles.ToArray());
        }

        /// <summary>
        /// Evento que se encarga de invocar al Form "InterfazModificarArticulo" para que se genere el Panel que permita al usuario elegir un artículo para la modificación de sus datos.
        /// </summary>
        private void btnModificarArticulo_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();

            InterfazModificarArticulo iMA = new InterfazModificarArticulo(cnxGP);
            Panel panelModificarArticulo = iMA.GenerarPanelModificarArticulos(panel3.Width, panel3.Height);

            panel3.Controls.Add(panelModificarArticulo);
        }
    }
}