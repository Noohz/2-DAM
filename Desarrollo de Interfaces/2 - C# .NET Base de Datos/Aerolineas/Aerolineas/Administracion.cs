using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aerolineas
{
    public partial class Administracion : Form
    {
        ClaseConectar cnx = new ClaseConectar();

        public Administracion()
        {
            InitializeComponent();
            this.Text = "Panel de Administración";
        }

        private void btnCrearModeloAvion_Click(object sender, EventArgs e)
        {
            gBTexto.Visible = true;
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
                } else
                {
                    MessageBox.Show("Error, no se puede crear un modelo sin indicar al menos 1 asiento en alguna categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else
            {
                MessageBox.Show("Error, los campos IdAvion y Modelo deben estar completos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
