using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Aerolineas
{
    public partial class Administracion : Form
    {
        ClaseConectar cnx = new ClaseConectar();

        List<ModeloAvion> idAviones = new List<ModeloAvion>();
        List<Aeropuertos> datosAeropuertos = new List<Aeropuertos>();

        public Administracion()
        {
            InitializeComponent();
            this.Text = "Panel de Administración";
            idAviones = cnx.obtenerIdsAviones();
            datosAeropuertos = cnx.obtenerDatosAeropuertos();
        }

        private void btnCrearModeloAvion_Click(object sender, EventArgs e)
        {
            gBOpcionCrearModeloAvion.Visible = true;
            gBOpcionCrearNuevaRuta.Visible = false;
        }

        private void btnAñadirModeloAvion_Click(object sender, EventArgs e)
        {
            if (tBIdAvion.Text != "" && tBModelo.Text != "")
            {
                if (numericUpDownBussines.Value != 0 || numericUpDownPrimera.Value != 0 || numericUpDownTuristas.Value != 0)
                {
                    int codigo = cnx.crearModeloAvion(tBIdAvion.Text, tBModelo.Text, (int)numericUpDownBussines.Value, (int)numericUpDownPrimera.Value, (int)numericUpDownTuristas.Value);

                    if (codigo == 1)
                    {
                        MessageBox.Show("Modelo creado con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tBIdAvion.Clear();
                        tBModelo.Clear();
                        numericUpDownBussines.Value = 0;
                        numericUpDownPrimera.Value = 0;
                        numericUpDownTuristas.Value = 0;
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error al crear el modelo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error, no se puede crear un modelo sin indicar al menos 1 asiento en alguna categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error, los campos IdAvion y Modelo deben estar completos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrearRuta_Click(object sender, EventArgs e)
        {
            gBOpcionCrearModeloAvion.Visible = false;
            gBOpcionCrearNuevaRuta.Visible = true;

            foreach (var ids in idAviones)
            {
                cbIdAvionCNR.Items.Add(ids.IdAvion);
            }

            foreach (var aeropuertos in datosAeropuertos)
            {
                cBRuta1CNR.Items.Add(aeropuertos.Id);
                cBRuta2CNR.Items.Add(aeropuertos.Id);
            }
        }

        private void btnCrearNuevaRutaCNR_Click(object sender, EventArgs e)
        {
            dateTPFechaCNR.Format = DateTimePickerFormat.Custom;
            dateTPFechaCNR.CustomFormat = "yyyy-MM-dd";

            if (cbIdAvionCNR.SelectedIndex != -1)
            {
                if (cBRuta1CNR.SelectedIndex != -1 && cBRuta2CNR.SelectedIndex != -1)
                {
                    if (numericUpDownPrecioBussinessCNR.Value != 0 && numericUpDownPrecioPrimeraCNR.Value != 0 && numericUpDownPrecioTuristaCNR.Value != 0)
                    {
                        int ultimoIdVuelo = cnx.obtenerUltimoIdVuelo();
                        string ruta = cBRuta1CNR.Text + "-" + cBRuta2CNR.Text;
                        int codigo = cnx.crearNuevaRuta(ultimoIdVuelo + 1, ruta, tBFechaSalidaTotalCNR.Text, (int)numericUpDownPrecioBussinessCNR.Value, (int)numericUpDownPrecioPrimeraCNR.Value, (int)numericUpDownPrecioTuristaCNR.Value, cbIdAvionCNR.Text);

                        if (codigo == 1)
                        {
                            MessageBox.Show("Ruta creada correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cbIdAvionCNR.SelectedIndex = -1;
                            cBRuta1CNR.SelectedIndex = -1;
                            cBRuta2CNR.SelectedIndex = -1;
                            numHoras.Value = 0;
                            numMin.Value = 0;
                            tBFechaSalidaTotalCNR.Clear();
                            numericUpDownPrecioBussinessCNR.Value = 0;
                            numericUpDownPrecioPrimeraCNR.Value = 0;
                            numericUpDownPrecioTuristaCNR.Value = 0;
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error al intentar crear la ruta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } else
                    {
                        MessageBox.Show("Error, debes introducir un precio para las butacas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error, debes de seleccionar la ruta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error, debes seleccionar un módelo de avión válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTPFechaCNR_ValueChanged(object sender, EventArgs e)
        {
            String resultadoDTP_sesion = dateTPFechaCNR.Value.ToString("yyyy-MM-dd-");

            if (dateTPFechaCNR.Value >= DateTime.Now)
            {
                tBFechaSalidaTotalCNR.Text = resultadoDTP_sesion;
                numHoras.Enabled = true;
                numMin.Enabled = true;
            }
            else
            {
                MessageBox.Show("Fecha no válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numHoras_ValueChanged(object sender, EventArgs e)
        {
            String cadenaDateTime = tBFechaSalidaTotalCNR.Text;
            String nuevaCadena = cadenaDateTime.Substring(0, 11);
            nuevaCadena += numHoras.Value + ":" + numMin.Value;
            tBFechaSalidaTotalCNR.Text = nuevaCadena;
        }

        private void numMin_ValueChanged(object sender, EventArgs e)
        {
            String cadenaDateTime = tBFechaSalidaTotalCNR.Text;
            String nuevaCadena = cadenaDateTime.Substring(0, 11);
            nuevaCadena += numHoras.Value + ":" + numMin.Value;
            tBFechaSalidaTotalCNR.Text = nuevaCadena;
        }

        private void cBRuta1CNR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBRuta1CNR.SelectedIndex != -1)
            {
                if (cBRuta1CNR.Text.Equals(cBRuta2CNR.Text))
                {
                    MessageBox.Show("Error, no puedes seleccionar la misma ruta para salida y destino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cBRuta1CNR.SelectedIndex = -1;
                }
            }            
        }

        private void cBRuta2CNR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBRuta2CNR.SelectedIndex != -1)
            {
                if (cBRuta2CNR.Text.Equals(cBRuta1CNR.Text))
                {
                    MessageBox.Show("Error, no puedes seleccionar la misma ruta para salida y destino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cBRuta2CNR.SelectedIndex = -1;
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
