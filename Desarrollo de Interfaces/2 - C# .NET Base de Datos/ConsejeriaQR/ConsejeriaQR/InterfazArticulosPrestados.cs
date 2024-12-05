using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    /// <summary>
    /// Clase encargada de la generación de la interfaz y la funcionalidad de consultar los artículos prestados por X profesor.
    /// </summary>
    internal class InterfazArticulosPrestados
    {
        ClaseConectar cnxIAP;
        List<Control> listaControles;
        List<Articulos> listaCategoriaArticulos = new List<Articulos>();
        List<Prestamos> listaArticulosPrestados = new List<Prestamos>();
        List<Usuarios> datosUser;

        public InterfazArticulosPrestados(ClaseConectar cnxGP, List<Usuarios> datosUsuarioLogeado)
        {
            this.cnxIAP = cnxGP;
            this.datosUser = datosUsuarioLogeado;
        }

        internal Panel GenerarPanelArticulosPrestados(int width, int height)
        {
            listaCategoriaArticulos = cnxIAP.ObtenerCategoriaArticulos();

            // Panel que contendrá los Controls para introducir los datos del artículo.
            Panel panelArticulo = new Panel
            {
                Width = width - (width * 20 / 100),
                Height = height - (height * 20 / 100),
                BackColor = Color.White
            };
            panelArticulo.Location = new Point((width - panelArticulo.Width) / 2, (height - panelArticulo.Height) / 2);

            Label lblTextoBusqueda = new Label
            {
                Font = new Font("Arial", 15, FontStyle.Bold),
                Width = 348,
                Height = 24,
                Location = new Point((int)(panelArticulo.Width * 0.10), 38),
                Text = "Selecciona la categoría del artículo =>"
            };

            // ComboBox para que el usuario pueda elegir las opciones mediante los nombres que hay en la tabla Articulos > nombres.
            ComboBox comboBoxArticulo = new ComboBox
            {
                Width = 296,
                Height = 27,
                Font = new Font("Arial", 12, FontStyle.Bold),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboBoxArticulo.Location = new Point((int)(panelArticulo.Width - comboBoxArticulo.Width - (panelArticulo.Width * 0.10)), 35);
            comboBoxArticulo.SelectedIndexChanged += ComboBoxArticulo_SelectedIndexChanged;

            foreach (var categoria in listaCategoriaArticulos)
            {
                comboBoxArticulo.Items.Add(categoria.Categoria);
            }

            // Un FlowLayoutPanel donde aparecerán los artículos con el nombre seleccionado en el comboBox.
            FlowLayoutPanel fLPArticulos = new FlowLayoutPanel
            {
                Width = (int)(panelArticulo.Width * 0.81),
                Height = (int)(panelArticulo.Height * 0.7),
                Location = new Point((int)(panelArticulo.Width * 0.10), 114),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.Silver,
                AutoScroll = true
            };

            listaControles = new List<Control> { lblTextoBusqueda, comboBoxArticulo, fLPArticulos };
            panelArticulo.Controls.AddRange(listaControles.ToArray());

            return panelArticulo;
        }

        /// <summary>
        /// Evento que se activa cuando se selecciona un nuevo artículo en el ComboBox y actualiza el FlowLayoutPanel con los botones de los artículos correspondientes.
        /// </summary>
        private void ComboBoxArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox == null)
            {
                return;
            }

            FlowLayoutPanel flowLayoutPanel = listaControles[2] as FlowLayoutPanel;
            if (flowLayoutPanel == null)
            {
                return;
            }

            // Obtener la lista de artículos prestados para el usuario.
            var articulosPrestados = cnxIAP.ObtenerArticulosPrestados(datosUser);

            flowLayoutPanel.Controls.Clear();

            // Se filtran los artículos de articulosPrestados donde a que es el artículo coincide con el nombre del artículo.
            foreach (var articulo in articulosPrestados.Where(a => a.Categoria.Equals(comboBox.Text)))
            {
                Button articuloButton = CrearBotonArticulo(articulo);
                flowLayoutPanel.Controls.Add(articuloButton);
            }
        }

        /// <summary>
        /// Crea un botón para representar un artículo en la interfaz.
        /// </summary>
        /// <param name="articulo"> El objeto de artículo a representar. </param>
        /// <returns> Un botón configurado para el artículo. </returns>
        private Button CrearBotonArticulo(Prestamos articulo)
        {
            Button boton = new Button
            {
                Name = articulo.Codigo,
                Width = 95,
                Height = 95,
                Margin = new Padding(13, 5, 0, 5),
                Text = articulo.Codigo,
                TextAlign = ContentAlignment.BottomCenter,
                Font = new Font("Arial", 9, FontStyle.Bold),
                Tag = articulo
            };

            using (MemoryStream ms = new MemoryStream(articulo.Imagen))
            {
                Image imagenOriginal = Image.FromStream(ms);
                boton.Image = new Bitmap(imagenOriginal, new Size(70, 70));
            }

            boton.ImageAlign = ContentAlignment.TopCenter;

            boton.Click += Btn_Click;

            return boton;
        }

        /// <summary>
        /// Maneja el evento de clic de un botón de artículo. Permite devolver el artículo seleccionado.
        /// </summary>
        private void Btn_Click(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            if (boton == null)
            {
                return;
            }

            Prestamos articulo = boton.Tag as Prestamos;
            if (articulo == null)
            {
                return;
            }

            // Mensaje para que el usuario confirme si quiere devolver el artículo o no.
            if (MessageBox.Show($"¿Deseas devolver el artículo '{articulo.NombreArticulo}' con código '{articulo.Codigo}'?", "Confirmar devolución",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
            {
                return;
            }

            // Mensaje para que el usuario confirme si el artículo tiene algún problema técnico y deba ser enviado a mantenimiento.
            int enMantenimiento = MessageBox.Show("¿El artículo tiene algún problema técnico?", "Confirmar devolución",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? 1 : 0;

            if (cnxIAP.DevolverArticulo(articulo, activo: 1, enMantenimiento) == 1)
            {
                // Actualiza la lista de los artículos por si han ocurrido cambios.
                ComboBoxArticulo_SelectedIndexChanged(listaControles[1], EventArgs.Empty);
                MessageBox.Show("Se ha devuelto el artículo correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al intentar devolver el artículo, por favor, vuelve a intentarlo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
