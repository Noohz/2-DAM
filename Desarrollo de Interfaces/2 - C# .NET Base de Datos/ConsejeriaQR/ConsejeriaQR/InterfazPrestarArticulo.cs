using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    internal class InterfazPrestarArticulo
    {
        ClaseConectar cnxIPA;
        List<Control> listaControles;
        List<Articulos> listaNombreArticulos = new List<Articulos>();
        List<Articulos> listaArticulos = new List<Articulos>();

        public InterfazPrestarArticulo(ClaseConectar cnxGP)
        {
            cnxIPA = cnxGP;
        }

        /// <summary>
        /// Método que generará el Panel con los Controls que almacenarán los artículos.
        /// </summary>
        /// <param name="width"> Width del Panel padre que se utiliza para calcular las dimensiones del nuevo Panel. </param>
        /// <param name="height"> Height del Panel padre que se utiliza para calcular las dimensiones del nuevo Panel. </param>
        /// <returns> panelArticulo => El nuevo panel ya creado. </returns>
        internal Panel GenerarPanelPrestarArticulos(int width, int height)
        {
            listaNombreArticulos = cnxIPA.ObtenerNombreArticulos();

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
                Text = "Selecciona el nombre del artículo =>"
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

        /// <summary>
        /// Evento que se encarga de mostrar los artículos de la tabla "articulos" de la BBDD que coincidan con el texto seleccionado del comboBox.
        /// </summary>
        /// <param name="sender"> Esto es el Control que ha llamado al evento. </param>
        /// <param name="e"> Los argumentos del evento. </param>
        private void ComboBoxArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbX = (ComboBox)sender;
            FlowLayoutPanel fLPArticulo = (FlowLayoutPanel)listaControles[2];

            listaArticulos = cnxIPA.ObtenerArticulos();
            fLPArticulo.Controls.Clear();

            if (listaArticulos.Count != 0)
            {
                foreach (var articulo in listaArticulos)
                {
                    if (articulo.Nombre.Equals(cbX.Text) && articulo.Mantenimiento != true)
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
                MessageBox.Show("Actualmente no hay ningún artículo disponible para prestar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Evento que abrirá un nuevo Form para que el usuario decida si prestar el artículo o no.
        /// </summary>
        /// <param name="sender"> Esto es el Control que ha llamado al evento. </param>
        /// <param name="e"> Los argumentos del evento. </param>
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btnX = (Button)sender;

            cnxIPA.ActualizarArticulo((Articulos)btnX.Tag, 0);

            FormularioPrestamoBtn fPBtn = new FormularioPrestamoBtn(btnX.Tag, cnxIPA);
            fPBtn.FormClosed += FDBtn_FormClosed;
            fPBtn.ShowDialog();
        }

        private void FDBtn_FormClosed(object sender, FormClosedEventArgs e)
        {
            ComboBoxArticulo_SelectedIndexChanged(listaControles[1], EventArgs.Empty);
        }
    }
}
