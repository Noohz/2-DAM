using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    /// <summary>
    /// Clase que representa el formulario para gestionar el inventario de un aula.
    /// Permite visualizar y modificar los artículos en el inventario del aula seleccionada.
    /// </summary>
    public partial class FormularioInventarioAula : Form
    {
        List<ArticulosAulaDGV> inventario = new List<ArticulosAulaDGV>();
        ClaseConectar cnxFIA;

        string aula;
        int idArticulo;

        public FormularioInventarioAula(string aulaSeleccionada, ClaseConectar cnxFGI)
        {
            InitializeComponent();

            this.Text = "Inventario del aula " + aulaSeleccionada;
            aula = aulaSeleccionada;
            cnxFIA = cnxFGI;

            cargarInventarioEnDGV();
        }

        /// <summary>
        /// Carga el inventario del aula en el DataGridView (dGVInventarioAula).
        /// Limpia la lista de artículos y obtiene los datos desde la base de datos.
        /// </summary>
        private void cargarInventarioEnDGV()
        {
            inventario.Clear();
            inventario = cnxFIA.CargarInventarioAula(aula);
            dGVInventarioAula.DataSource = null;
            dGVInventarioAula.DataSource = inventario;
        }

        /// <summary>
        /// Evento que se ejecuta cuando el usuario hace clic en una celda del DataGridView.
        /// Permite cargar los datos del artículo seleccionado en los controles del formulario.
        /// </summary>
        private void dGVInventarioAula_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idArticulo = (int)dGVInventarioAula.Rows[e.RowIndex].Cells["ID"].Value;
                tBAula.Text = dGVInventarioAula.Rows[e.RowIndex].Cells["Aula"].Value.ToString();
                string tipoArticulo = dGVInventarioAula.Rows[e.RowIndex].Cells["TipoArticulo"].Value.ToString();
                numericCantidad.Value = (int)dGVInventarioAula.Rows[e.RowIndex].Cells["Cantidad"].Value;
                tBModelo.Text = dGVInventarioAula.Rows[e.RowIndex].Cells["Modelo"].Value.ToString();
                tBCaracteristicas.Text = dGVInventarioAula.Rows[e.RowIndex].Cells["Caracteristicas"].Value.ToString();
                string estado = dGVInventarioAula.Rows[e.RowIndex].Cells["Estado"].Value.ToString();

                int index = comboTipoArticulo.FindStringExact(tipoArticulo);
                if (index != -1)
                {
                    comboTipoArticulo.SelectedIndex = index;
                }

                int index2 = comboEstado.FindStringExact(estado);
                if (index2 != -1)
                {
                    comboEstado.SelectedIndex = index2;
                }
            }

            btnModificarDatos.Enabled = true;
        }

        /// <summary>
        /// Evento que se ejecuta cuando el usuario hace clic en el botón de modificar datos.
        /// Realiza la validación de los datos y actualiza el artículo en la base de datos.
        /// </summary>
        private void btnModificarDatos_Click(object sender, EventArgs e)
        {
            if (comboTipoArticulo.SelectedIndex == -1 || comboEstado.SelectedIndex == -1 || string.IsNullOrEmpty(tBCaracteristicas.Text))
            {
                MessageBox.Show("Asegúrate de haber completado los campos 'Tipo Artículo', 'Estado' y 'Características'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cnxFIA.ModificarArticuloAula(idArticulo, tBAula.Text, comboTipoArticulo.Text, numericCantidad.Value, tBModelo.Text, tBCaracteristicas.Text, comboEstado.Text) == 1)
            {
                MessageBox.Show("El artículo se ha actualizado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                comboTipoArticulo.SelectedIndex = -1;
                numericCantidad.Value = 1;
                tBModelo.Clear();
                comboEstado.SelectedIndex = -1;
                tBCaracteristicas.Clear();
                btnModificarDatos.Enabled = false;

                cargarInventarioEnDGV();
            }
            else
            {
                MessageBox.Show("Hubo un error al insertar el artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se ejecuta cuando el usuario hace clic en el botón de cerrar formulario.
        /// Cierra el formulario actual.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
