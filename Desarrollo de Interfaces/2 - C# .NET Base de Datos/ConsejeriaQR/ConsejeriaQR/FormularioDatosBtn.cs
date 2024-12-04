using System;
using System.IO;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    // Esta clase de encarga de mostrar la información del articulo que ha seleccionado y de eliminarlo si el usuario lo desea.

    public partial class FormularioDatosBtn : Form
    {
        ClaseConectar cnxFDB;
        Articulos datosArticulo;

        public FormularioDatosBtn(object tag, ClaseConectar cnxIEA, char accesoDatos)
        {
            InitializeComponent();
            this.Text = "Panel eliminar artículo";

            cnxFDB = cnxIEA;

            datosArticulo = (Articulos)tag;

            MemoryStream ms = new System.IO.MemoryStream(datosArticulo.Imagen);
            System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
            pictureBoxImgArticulo.Image = imagen;

            lblInfoArticulo.Text = datosArticulo.Nombre + " | " + datosArticulo.Codigo;

            textBoxIDArticulo.Text = datosArticulo.Id.ToString();
            textBoxNombreArticulo.Text = datosArticulo.Nombre;
            textBoxDescripcionArticulo.Text = datosArticulo.Descripcion;
            textBoxCodigoArticulo.Text = datosArticulo.Codigo;
            textBoxClaveQRArticulo.Text = datosArticulo.ClaveQR;

            MemoryStream mst = new System.IO.MemoryStream(datosArticulo.ImagenQR);
            System.Drawing.Image imagenQR = System.Drawing.Image.FromStream(mst);
            pictureBoxImagenQR.Image = imagenQR;

            if (accesoDatos.Equals('V'))
            {
                btnEliminarArticulo.Enabled = false;
                btnEliminarArticulo.Visible = false;
                btnCancelar.Size = new System.Drawing.Size(443, 43);
                btnCancelar.Location = new System.Drawing.Point(52, 667);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            // Llamar a la consulta para que cambie activo a 0.
            if (cnxFDB.EliminarArticulo(datosArticulo) == 1)
            {
                MessageBox.Show("Artículo eliminado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else
            {
                MessageBox.Show("Ha ocurrido un error a la hora de eliminar el artículo...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
