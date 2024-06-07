using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Aerolineas
{
    public partial class Embarque : Form
    {
        int segundos = 0;
        ClaseConectar cnxE = null;
        List<Billeteavion> datosFacturacion = new List<Billeteavion>();
        List<Billeteavion> datosBillete = new List<Billeteavion>();
        List<Horariosaviones> datosHorariosAviones = new List<Horariosaviones>();

        public Embarque(ClaseConectar cnx, List<Billeteavion> listaFacturacion, List<Horariosaviones> listaHorariosActivos)
        {
            InitializeComponent();
            this.Text = "Ventana de embarque";
            cnxE = cnx;
            datosFacturacion = listaFacturacion;
            datosHorariosAviones = listaHorariosActivos;
        }

        private void tBQRAuto_TextChanged(object sender, EventArgs e)
        {
            if (tBQRAuto.Text.Length > 0)
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            segundos++;
            if (segundos == 3)
            {
                timer1.Enabled = false;
                segundos = 0;
                String codigoQR = tBQRAuto.Text;

                //int codigo = cnxE.OcuparButaca(codigoQR);
                datosBillete = cnxE.obtenerDatosAsiento(codigoQR);

                if (datosBillete != null)
                {
                    panelValidacion.BackColor = Color.Green;
                    panelValidacion.Visible = false;
                    tBInformacionVuelo.Visible = true;

                    foreach (var id in datosHorariosAviones)
                    {
                        if (datosBillete[0].IdVuelo == id.IdVuelo)
                        {
                            DateTime fechaSalida = DateTime.Parse(id.FechaSalida).ToString("yyyy-MM-dd");
                        }
                    }
                }
                else
                {
                    panelValidacion.BackColor = Color.Red;
                    MessageBox.Show("Ha ocurrido un error a la hora de procesar el código QR...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                tBQRAuto.Focus();
                tBQRAuto.Text = "";
                panelValidacion.BackColor = Color.White;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
