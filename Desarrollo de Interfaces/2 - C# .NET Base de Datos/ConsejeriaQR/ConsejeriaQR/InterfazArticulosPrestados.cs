using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        List<Articulos> listaNombreArticulos = new List<Articulos>();
        List<Prestamos> listaArticulosPrestados = new List<Prestamos>();
        List<Usuarios> datosUser;

        public InterfazArticulosPrestados(ClaseConectar cnxGP, List<Usuarios> datosUsuarioLogeado)
        {
            this.cnxIAP = cnxGP;
            this.datosUser = datosUsuarioLogeado;
        }

        internal Panel GenerarPanelArticulosPrestados(int width, int height)
        {
            listaNombreArticulos = cnxIAP.ObtenerNombreArticulos();

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

            foreach (var articulo in listaNombreArticulos)
            {
                comboBoxArticulo.Items.Add(articulo.Nombre);
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

        private void ComboBoxArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbX = (ComboBox)sender;
            FlowLayoutPanel fLPArticulo = (FlowLayoutPanel)listaControles[2];

            listaArticulosPrestados = cnxIAP.ObtenerArticulosPrestados(datosUser);
            fLPArticulo.Controls.Clear();

            foreach (var articulo in listaArticulosPrestados)
            {
                if (articulo.NombreArticulo.Equals(cbX.Text))
                {
                    Button btn = new Button
                    {
                        Name = articulo.Codigo,

                        Width = 95,
                        Height = 95,
                        Margin = new Padding(13, 5, 0, 5),
                        Text = articulo.Codigo,
                        TextAlign = ContentAlignment.BottomCenter,
                        Font = new Font("Arial", 9, FontStyle.Bold)
                    };

                    MemoryStream ms = new System.IO.MemoryStream(articulo.Imagen);
                    System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
                    System.Drawing.Image imagenRedimensionada = new System.Drawing.Bitmap(imagen, new System.Drawing.Size(70, 70));
                    btn.Image = imagenRedimensionada;
                    btn.ImageAlign = ContentAlignment.TopCenter;
                    btn.Tag = articulo;
                    btn.Click += Btn_Click;

                    fLPArticulo.Controls.Add(btn);
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btnX = (Button)sender;
            Prestamos datosArticulo = (Prestamos)btnX.Tag;

            int activo = 1;
            int mantenimiento = 0;

            if (MessageBox.Show("¿Deseas devolver el artículo " + datosArticulo.NombreArticulo + " y código " +datosArticulo.Codigo + "?", "Confirmar devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (MessageBox.Show("¿El artículo tiene algún problema técnico?", "Confirmar devolución", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    mantenimiento = 1;
                }

                if (cnxIAP.devolverArticulo(datosArticulo, activo, mantenimiento) == 1)
                {
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
}
