using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    internal class InterfazModificarArticulo
    {
        ClaseConectar cnxIMA;
        List<Control> listaControles;
        List<Articulos> listaCategoriaArticulos = new List<Articulos>();
        List<Articulos> listaArticulos = new List<Articulos>();
        private ClaseConectar cnxGP;

        public InterfazModificarArticulo(ClaseConectar cnxGP)
        {
            this.cnxIMA = cnxGP;
        }

        /// <summary>
        /// Método que generará el Panel con los Controls que almacenarán los artículos.
        /// </summary>
        /// <param name="width"> Width del Panel padre que se utiliza para calcular las dimensiones del nuevo Panel. </param>
        /// <param name="height"> Height del Panel padre que se utiliza para calcular las dimensiones del nuevo Panel. </param>
        /// <returns> panelArticulo => El nuevo panel ya creado. </returns>
        internal Panel GenerarPanelModificarArticulos(int width, int height)
        {
            listaArticulos.Clear();

            listaCategoriaArticulos = cnxIMA.ObtenerCategoriaArticulos();

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
                Text = "Selecciona el artículo a buscar =>"
            };

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
        /// Evento que se encarga de mostrar los artículos de la tabla "articulos" de la BBDD que coincidan con el texto seleccionado del comboBox.
        /// </summary>
        /// <param name="sender"> Esto es el Control que ha llamado al evento. </param>
        /// <param name="e"> Los argumentos del evento. </param>
        private void ComboBoxArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbX = (ComboBox)sender;
            FlowLayoutPanel fLPArticulo = (FlowLayoutPanel)listaControles[2];
            fLPArticulo.Controls.Clear();

            listaArticulos = cnxIMA.ObtenerArticulos();
            fLPArticulo.Controls.Clear();

            if (listaArticulos.Count != 0)
            {
                foreach (var articulo in listaArticulos)
                {
                    if (articulo.Categoria.Equals(cbX.Text) && articulo.Mantenimiento != true)
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
            else
            {
                MessageBox.Show("Actualmente no hay ningún artículo disponible para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Evento que se encarga de llamar al Form "FormularioModDatosBoton" para que el usuario pueda modificar los datos del artículo seleccionado.
        /// </summary>
        /// <param name="sender"> Esto es el Control que ha llamado al evento. </param>
        /// <param name="e"> Los argumentos del evento. </param>
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btnX = (Button)sender;

            FormularioModDatosBoton fMDB = new FormularioModDatosBoton(btnX.Tag, cnxIMA);
            fMDB.FormClosed += FDBtn_FormClosed;
            fMDB.ShowDialog();
        }

        private void FDBtn_FormClosed(object sender, FormClosedEventArgs e)
        {
            ComboBoxArticulo_SelectedIndexChanged(listaControles[1], EventArgs.Empty);
        }
    }
}
