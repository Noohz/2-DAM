using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace TPV
{
    public partial class backEnd : Form
    {
        claseAccesoBD conexion = new claseAccesoBD();
        List<claseFruta> listaFrutas = new List<claseFruta>();
        List<String> productosBajoMinimo = new List<String>();
        String nombreImagen;
        Image imagenSeleccionada;

        public backEnd()
        {
            InitializeComponent();

        }
        private void backEnd_Load(object sender, EventArgs e)
        {
            btnStock.Enabled = true;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            TPV tpv = new TPV();
            tpv.ShowDialog();
            this.Hide();
        }

        private void btnStock_Click(object sender, EventArgs e) // Boton Añadir Stock
        {
            flpFrutas.Controls.Clear();
            listaFrutas.Clear(); // Limpia la lista para que no se repitan cuando se vuelva a pulsar el boton.
            gbInsertar.Visible = false; // Oculta el groupBox que permite añadir / modificar un producto.
            btnStock.Enabled = false; // Deshabilita el botón para que no se pueda volver a interactuar con él y que se generen otra vez los botones.
            btnAniadir.Visible = true; // Muestra el botón de Añadir en vez de el botón de Guardar Cambios.

            listaFrutas = conexion.listarFrutas();
            flpFrutas.Visible = true;

            if (btnModificar.Enabled == false)
            {
                btnModificar.Enabled = true;
            }

            if (btnEliminarFruta.Enabled == false)
            {
                btnEliminarFruta.Enabled = true;
            }

            foreach (claseFruta cf in listaFrutas)
            {
                Button btn = new Button();
                btn.Name = cf.Nombre;

                btn.Width = 70;
                btn.Height = 80;
                btn.Tag = cf.Id;

                btn.Click += new EventHandler(BotonStock_Click);

                MemoryStream ms = new System.IO.MemoryStream(cf.Imagen);
                System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.BackgroundImage = imagen;

                flpFrutas.Controls.Add(btn);

            }
        }

        private void BotonStock_Click(object sender, EventArgs e)
        {
            if (sender is Button boton)
            {
                int idFruta = (int)boton.Tag;

                // Muestra un inputBox para que el usuario introduzca el stock que desea añadir.
                string añadirStock = Interaction.InputBox("Stock a añadir:", "Añadir Stock");

                try
                {
                    int stockNuevo = Convert.ToInt32(añadirStock);
                    conexion.insertarStock(stockNuevo, idFruta);
                    listaFrutas = conexion.listarFrutas();

                    MessageBox.Show("Se ha añadido el stock correctamente.", "Operación Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (FormatException)
                {
                    MessageBox.Show("La cantidad ingresada no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnInsertarFruta_Click(object sender, EventArgs e) // Boton Insertar Fruta
        {
            flpFrutas.Controls.Clear(); // Limpia el flpFrutas para que no se dupliquen los botones si se volviese a la opción de añadir stock
            flpFrutas.Visible = false; // Oculta el flpFrutas.
            btnAniadir.Visible = true;
            btnGuardarCambios.Visible = false;

            pbImagenCargada.Image = null;

            if (btnStock.Enabled == false)
            {
                btnStock.Enabled = true;
            }
            
            if (btnModificar.Enabled == false)
            {
                btnModificar.Enabled = true;
            }

            if (btnEliminarFruta.Enabled == false)
            {
                btnEliminarFruta.Enabled = true;
            }

            gbInsertar.Visible = true; // Muestra el groupBox que le permite al usuario introducir un producto.
        }

        private void btnAniadir_Click(object sender, EventArgs e)
        {

            FileStream fs = new FileStream(nombreImagen, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] bloque = br.ReadBytes((int)fs.Length);


            int id = Convert.ToInt16(txtId.Text);
            string nombre = txtNombre.Text;
            string precio = txtPrecio.Text;
            byte[] imagen = bloque;
            string stock = txtStock.Text;

            conexion.insertarFruta(id, nombre, precio, imagen, stock);

            MessageBox.Show("Se ha añadido correctamente el producto.", "Operación Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Imagenes | *.jpg; *.png";
            nombreImagen = opf.FileName;

            if (opf.ShowDialog() == DialogResult.OK)
            {
                nombreImagen = opf.FileName;
                pbImagenCargada.Image = Image.FromFile(nombreImagen);
                pbImagenCargada.BackgroundImage = Image.FromFile(nombreImagen);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e) // Boton Modificar
        {
            flpFrutas.Controls.Clear();
            listaFrutas.Clear(); // Limpia la lista para que no se repitan cuando se vuelva a pulsar el boton.
            gbInsertar.Visible = false; // Oculta el groupBox que permite añadir / modificar un producto.
            btnModificar.Enabled = false; // Deshabilita el botón para que no se pueda volver a interactuar con él y que se generen otra vez los botones.
            btnGuardarCambios.Visible = true; // Habilita el botón Guardar Cambios.

            listaFrutas = conexion.listarFrutas();
            flpFrutas.Visible = true;

            if (btnStock.Enabled == false)
            {
                btnStock.Enabled = true;
            }

            if (btnEliminarFruta.Enabled == false)
            {
                btnEliminarFruta.Enabled = true;
            }

            foreach (claseFruta cf in listaFrutas)
            {
                Button btn = new Button();
                btn.Name = cf.Nombre;

                btn.Width = 70;
                btn.Height = 80;
                btn.Tag = cf.Id;

                btn.Click += new EventHandler(BotonStock_Click2);

                MemoryStream ms = new System.IO.MemoryStream(cf.Imagen);
                System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.BackgroundImage = imagen;

                flpFrutas.Controls.Add(btn);

            }

        }

        private void BotonStock_Click2(object sender, EventArgs e)
        {
            btnModificar.Enabled = true;

            if (sender is Button boton)
            {
                int idFruta = (int)boton.Tag;
                // Almacena la imagen del botón seleccionado en la variable imagenSeleccionada
                MemoryStream ms = new MemoryStream();
                boton.BackgroundImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                imagenSeleccionada = Image.FromStream(ms);

                pbImagenCargada.Image = imagenSeleccionada;

                flpFrutas.Visible = false;
                gbInsertar.Visible = true;
                btnAniadir.Visible = false;            
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (imagenSeleccionada != null)
            {
                // Convierte la imagen a un arreglo de bytes
                MemoryStream ms = new MemoryStream();
                imagenSeleccionada.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imagen = ms.ToArray();

                string id = txtId.Text;
                string nombre = txtNombre.Text;
                string precio = txtPrecio.Text;
                string stock = txtStock.Text;

                conexion.modificarFruta(id, nombre, precio, imagen, stock);

                MessageBox.Show("Se ha modificado correctamente el producto.", "Operación Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Por favor, seleccione una imagen antes de guardar los cambios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarFruta_Click(object sender, EventArgs e) // Boton Eliminar
        {

            flpFrutas.Controls.Clear();
            listaFrutas.Clear(); // Limpia la lista para que no se repitan cuando se vuelva a pulsar el boton.
            gbInsertar.Visible = false; // Oculta el groupBox que permite añadir / modificar un producto.
            btnEliminarFruta.Enabled = false; // Deshabilita el botón para que no se pueda volver a interactuar con él y que se generen otra vez los botones.

            listaFrutas = conexion.listarFrutas();
            flpFrutas.Visible = true;


            if (btnStock.Enabled == false)
            {
                btnStock.Enabled = true;
            }

            if (btnModificar.Enabled == false)
            {
                btnModificar.Enabled = true;
            }


            foreach (claseFruta cf in listaFrutas)
            {
                Button btn = new Button();
                btn.Name = cf.Nombre;

                btn.Width = 70;
                btn.Height = 80;
                btn.Tag = cf.Id;

                btn.Click += new EventHandler(BotonStock_Click3);

                MemoryStream ms = new System.IO.MemoryStream(cf.Imagen);
                System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.BackgroundImage = imagen;

                flpFrutas.Controls.Add(btn);

            }
        }

        private void BotonStock_Click3(object sender, EventArgs e)
        {
            btnEliminarFruta.Enabled = true;

            if (sender is Button boton)
            {
                DialogResult msg = MessageBox.Show("¿Deseas eliminar la fruta seleccionada: " +boton.Name+ "?", "Eliminar Fruta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (msg == DialogResult.Yes)
                {
                    int id = (int)boton.Tag;

                    conexion.eliminarFruta(id);

                    MessageBox.Show("La fruta ha sido eliminada.", "Operación Realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }   
}
