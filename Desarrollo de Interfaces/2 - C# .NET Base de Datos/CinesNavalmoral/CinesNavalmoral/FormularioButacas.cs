using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinesNavalmoral
{
    public partial class FormularioButacas : Form
    {
        ClaseConectar cnx = new ClaseConectar();
        List<ClaseFacturacionCine> listaFacturacion = new List<ClaseFacturacionCine>();
        List<ClaseSalaCine> listaFilasColumnas = new List<ClaseSalaCine>();

        public FormularioButacas(string titulo, string sesion, string sala)
        {
            InitializeComponent();

            this.Text = "Película: " + titulo;

            lblTitulo.Text = titulo;
            lblNSala.Text = sala;
            lblSesion.Text = sesion;

            lblNTotalButacas.Text = cnx.TotalButacas(sala).ToString();

            listaFacturacion = cnx.ButacasOcupadas(sala, sesion);

            int numButacasLibres = Convert.ToInt16(lblNTotalButacas.Text) - listaFacturacion.Count;
            lblNButacasLibres.Text = numButacasLibres.ToString();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormularioButacas_Load(object sender, EventArgs e)
        {
            cargarButacas(listaFacturacion);
        }

        private void cargarButacas(List<ClaseFacturacionCine> listaFacturacion)
        {
            int salaActual = Convert.ToInt16(lblNSala.Text);

            int totalButacas = cnx.TotalButacas(salaActual.ToString());
            int filas = 0;
            int columnas = 0;

            listaFilasColumnas = cnx.obtenerFilasColumnas(salaActual);

            foreach (ClaseSalaCine cSC in listaFilasColumnas)
            {
                filas = cSC.Filas;
                columnas = cSC.Columnas;
            }

            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.AutoSize = true;
            tlp.RowCount = filas;
            tlp.ColumnCount = columnas;
            flPrincipal.Controls.Add(tlp);

            for (int i = 0; i < totalButacas; i++)
            {
                FlowLayoutPanel flowPeliculas = new FlowLayoutPanel();
                flowPeliculas.AutoSize = true;
                flowPeliculas.FlowDirection = FlowDirection.TopDown;
                flowPeliculas.Margin = new Padding(55, flowPeliculas.Margin.Top, flowPeliculas.Margin.Right, flowPeliculas.Margin.Bottom);

                // Propiedades del button.
                Button botonX = new Button();
                botonX.Width = 20;
                botonX.Height = 30;

                flowPeliculas.Controls.Add(botonX);
                tlp.Controls.Add(flowPeliculas);
            }

        }
    }
}
