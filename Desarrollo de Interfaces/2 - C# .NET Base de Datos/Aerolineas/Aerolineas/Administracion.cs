using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Aerolineas
{
    public partial class Administracion : Form
    {
        ClaseConectar cnx = new ClaseConectar();

        List<ModeloAvion> idAviones = new List<ModeloAvion>();
        List<Aeropuertos> datosAeropuertos = new List<Aeropuertos>();
        List<ModeloAvion> datosModeloAvion = new List<ModeloAvion>();

        String nombreImagen;

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
            gBOpcionModificarAvion.Visible = false;
            gBOpcionCrearNuevaRuta.Visible = false;
        }

        private void btnAñadirModeloAvion_Click(object sender, EventArgs e)
        {
            if (tBIdAvion.Text != "" && tBModelo.Text != "")
            {
                if (numericUpDownBussines.Value != 0 || numericUpDownTuristas.Value != 0 || pBImgModeloAvion != null)
                {
                    FileStream fs = new FileStream(nombreImagen, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    byte[] bloque = br.ReadBytes((int)fs.Length);

                    int codigo = cnx.crearModeloAvion(tBIdAvion.Text, tBModelo.Text, (int)numericUpDownBussines.Value, (int)numericUpDownTuristas.Value, bloque);

                    if (codigo == 1)
                    {
                        MessageBox.Show("Modelo creado con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tBIdAvion.Clear();
                        tBModelo.Clear();
                        numericUpDownBussines.Value = 0;
                        numericUpDownTuristas.Value = 0;
                        pBImgModeloAvion = null;
                        nombreImagen = "";
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
            gBOpcionModificarAvion.Visible = false;
            gBOpcionCrearNuevaRuta.Visible = true;

            cbIdAvionCNR.Items.Clear();
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
                    if (numericUpDownPrecioBussinessCNR.Value != 0 && numericUpDownMinutosVuelo.Value != 0 && numericUpDownPrecioTuristaCNR.Value != 0)
                    {
                        int ultimoIdVuelo = cnx.obtenerUltimoIdVuelo();
                        string ruta = cBRuta1CNR.Text + "-" + cBRuta2CNR.Text;
                        int codigo = cnx.crearNuevaRuta(ultimoIdVuelo + 1, ruta, tBFechaSalidaTotalCNR.Text, (int)numericUpDownPrecioBussinessCNR.Value, (int)numericUpDownMinutosVuelo.Value, (int)numericUpDownPrecioTuristaCNR.Value, cbIdAvionCNR.Text);

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
                            numericUpDownMinutosVuelo.Value = 0;
                            numericUpDownPrecioTuristaCNR.Value = 0;
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error al intentar crear la ruta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
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

        private void btnModificarAvion_Click(object sender, EventArgs e)
        {
            gBOpcionCrearModeloAvion.Visible = false;
            gBOpcionCrearNuevaRuta.Visible = false;
            gBOpcionModificarAvion.Visible = true;

            cBMAIdAvion.Items.Clear();
            foreach (var ids in idAviones)
            {
                cBMAIdAvion.Items.Add(ids.IdAvion);
            }
        }

        private void cBMAIdAvion_SelectedIndexChanged(object sender, EventArgs e)
        {
            datosModeloAvion.Clear();

            datosModeloAvion = cnx.obtenerButacasAvion(cBMAIdAvion.Text);
            tBMAModelo.Text = datosModeloAvion[0].Modelo;
            tBMAFBussines.Text = datosModeloAvion[0].FBussines.ToString();
            tBMAFTurista.Text = datosModeloAvion[0].FTurista.ToString();

            MemoryStream ms = new MemoryStream(datosModeloAvion[0].Imagen);
            pBImgModificarAvion.BackgroundImage = System.Drawing.Image.FromStream(ms);
            pBImgModificarAvion.BackgroundImageLayout = ImageLayout.Stretch;

            btnModAvion.Visible = true;
        }

        private void btnModAvion_Click(object sender, EventArgs e)
        {
            if (tBMAFBussines.Text != "" && pBImgModificarAvion != null && tBMAFTurista.Text != "")
            {
                FileStream fs = new FileStream(nombreImagen, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] bloque = br.ReadBytes((int)fs.Length);

                int codigo = cnx.modificarAvion(cBMAIdAvion.Text, tBMAFBussines.Text, tBMAFTurista.Text, bloque);

                if (codigo == 1)
                {
                    MessageBox.Show("Se ha modificado el avión correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al modificar el avión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Error, debes completar todos los campos...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pBImgModeloAvion_Click(object sender, EventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog(); 
            op1.Filter = "imagenes|*.jpg;*.png";
            if (op1.ShowDialog() == DialogResult.OK)
            {
                nombreImagen = op1.FileName;
                pBImgModeloAvion.Image = Image.FromFile(nombreImagen);
            }
        }

        private void pBImgModificarAvion_Click(object sender, EventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog();
            op1.Filter = "imagenes|*.jpg;*.png";
            if (op1.ShowDialog() == DialogResult.OK)
            {
                nombreImagen = op1.FileName;
                pBImgModeloAvion.Image = Image.FromFile(nombreImagen);
            }
        }
    }
}
