using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    /// <summary>
    /// Formulario de gestión de inventario, que permite interactuar con los planos de aulas en una planta baja y alta.
    /// Los usuarios pueden seleccionar áreas en el plano, ver opciones de gestión de artículos, insertar artículos, y gestionar inventarios de aulas.
    /// </summary>
    public partial class FormularioGestionInventario : Form
    {
        ClaseConectar cnxFGI = new ClaseConectar();

        Dictionary<string, Rectangle> aulaAreasPlantaBajaDiurno;
        private string aulaSeleccionada = "";
        public FormularioGestionInventario(List<Usuarios> datosUsuario, ClaseConectar cnxC)
        {
            InitializeComponent();

            boton_desplegablePlanos.IsMainMenu = true;
            boton_desplegablePlanos.PrimaryColor = Color.FromArgb(85, 113, 73);

            panelOpcionesAula.Visible = false;

            aulaAreasPlantaBajaDiurno = new Dictionary<string, Rectangle>
            {                
                { "DAM 2", new Rectangle(440, 315, 47, 50) },
                { "DAW 2", new Rectangle(440, 247, 55, 45) },
            };

            if (datosUsuario[0].Departamento.Equals("Administrador"))
            {
                btnAniadirArticulo.Enabled = true;
            }

            //pBPlantaBajaDia.Paint += pBPlantaBajaDia_Paint; DESMARCAR ESTO Y EL EVENTO PARA COMPROBAR DONDE APARECEN LOS PUNTOS DE CADA AULA
        }

        /// <summary>
        /// Evento que se dispara cuando el usuario hace clic en el plano de la planta baja diurna.
        /// Detecta si el clic está dentro de un área de aula y muestra las opciones correspondientes.
        /// </summary>
        private void pBPlantaBajaDia_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var aula in aulaAreasPlantaBajaDiurno)
            {
                if (aula.Value.Contains(e.Location))
                {
                    aulaSeleccionada = aula.Key;
                    MostrarPanelOpciones(aulaSeleccionada);
                }
            }
        }

        /*private void pBPlantaBajaDia_Paint(object sender, PaintEventArgs e)
        {
            // Recorremos todas las áreas del diccionario y dibujamos un cuadrado rojo en cada una
            foreach (var aula in aulaAreasPlantaBajaDiurno)
            {
                var area = aula.Value;
                using (Pen redPen = new Pen(Color.Red, 2)) // Bolígrafo rojo con grosor de 2
                {
                    e.Graphics.DrawRectangle(redPen, area); // Dibuja cada rectángulo
                }
            }
        }*/

        /// <summary>
        /// Muestra el panel con las opciones disponibles para el aula seleccionada.
        /// </summary>
        private void MostrarPanelOpciones(string aulaSeleccionada)
        {
            panelOpcionesAula.Visible = true;

            lblAulaSeleccionada.Text = aulaSeleccionada;

            panelOpcionesAula.Controls.Add(lblAulaSeleccionada);
        }

        /// <summary>
        /// Evento para cerrar el formulario de gestión de inventarios.
        /// </summary>
        private void BtnVolverGestionPrestamos_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Muestra un menú desplegable con opciones para acceder a los planos.
        /// </summary>
        private void BtnAccederInterfaz_Click(object sender, EventArgs e)
        {
            boton_desplegablePlanos.Show(btnAccederInterfaz, btnAccederInterfaz.Width, 0);
        }

        /// <summary>
        /// Muestra la vista de la planta baja diurna en el formulario y oculta la planta alta.
        /// </summary>
        private void DiurnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelDiurnoPlantaBaja.Visible = true;
            panelDiurnoPlantaAlta.Visible = false;
            panelNocturnoPlantaBaja.Visible = false;
        }

        /// <summary>
        /// Muestra la vista nocturna de la planta baja y oculta otras vistas de planta.
        /// </summary>
        private void nocturnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelDiurnoPlantaBaja.Visible = false;
            panelDiurnoPlantaAlta.Visible = false;

            panelNocturnoPlantaBaja.Visible = true;
            panelOpcionesAula.Visible = false;
        }

        /// <summary>
        /// Abre el formulario para insertar un artículo en el aula seleccionada.
        /// </summary>
        private void InsertarArtículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormularioAniadirArticuloAula fAAA = new FormularioAniadirArticuloAula(aulaSeleccionada, cnxFGI);
            fAAA.Show();
        }

        /// <summary>
        /// Muestra un menú desplegable para añadir un artículo al aula seleccionada.
        /// </summary>
        private void BtnAniadirArticulo_Click(object sender, EventArgs e)
        {
            boton_desplegableAniadirArticulo.Show(btnAniadirArticulo, btnAniadirArticulo.Width, 0);
        }

        /// <summary>
        /// Abre el formulario para cargar un fichero CSV con artículos en el aula seleccionada.
        /// </summary>
        private void CargarFicheroCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormularioCargarFicheroAula fCF = new FormularioCargarFicheroAula(aulaSeleccionada, cnxFGI);
            fCF.Show();
        }

        /// <summary>
        /// Abre el formulario para comprobar el inventario del aula seleccionada.
        /// </summary>
        private void BtnComprobarInventario_Click(object sender, EventArgs e)
        {
            FormularioInventarioAula fIA = new FormularioInventarioAula(aulaSeleccionada, cnxFGI);
            fIA.Show();
        }

        /// <summary>
        /// Cambia la vista a la planta alta diurna y oculta la planta baja diurna.
        /// </summary>
        private void BtnCambiarPlano_Click(object sender, EventArgs e)
        {
            panelDiurnoPlantaAlta.Visible = true;
            panelDiurnoPlantaBaja.Visible = false;
            panelOpcionesAula.Visible = false;
        }

        /// <summary>
        /// Muestra la vista de la planta baja diurna y oculta la planta alta.
        /// </summary>
        private void btnPlanoAnterior_Click(object sender, EventArgs e)
        {
            panelDiurnoPlantaBaja.Visible = true;
            panelDiurnoPlantaAlta.Visible = false;
            panelOpcionesAula.Visible = false;
        }        
    }
}
