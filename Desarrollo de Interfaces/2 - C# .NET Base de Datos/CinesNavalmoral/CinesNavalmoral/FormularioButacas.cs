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

        public FormularioButacas(string titulo, string sesion, string sala)
        {
            InitializeComponent();

            lblTitulo.Text = titulo;
            lblSala.Text += sala;
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
            int filas = 0;
            int columnas = 0;

            if (lblSala.Text.Equals("Sala => 1"))
            {
                filas = 10;
                columnas = 6;

            }
            else if (lblSala.Text.Equals("Sala => 2"))
            {
                filas = 15;
                columnas = 6;

            }
            else if (lblSala.Text.Equals("Sala => 3"))
            {
                filas = 7;
                columnas = 6;
            }

            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.AutoSize = true;
            tlp.RowCount = filas;
            tlp.ColumnCount = columnas;
            flPrincipal.Controls.Add(tlp);


        }
    }
}
