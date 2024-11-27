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
    /// Esta clase se encarga de la generación del panel que contendrá el flowLayoutPanel donde aparecerán los artículos que estén marcados en Mantenimiento en la BBDD.
    /// </summary>
    internal class InterfarArticulosMantenimiento
    {
        ClaseConectar cnxIAM;
        List<Control> listaControles;
        List<Articulos> listadoArticulosEnMantenimiento;

        public InterfarArticulosMantenimiento(ClaseConectar cnxGP)
        {
            this.cnxIAM = cnxGP;
        }

        /// <summary>
        /// Método que generará el Panel con los Controls que almacenarán los artículos.
        /// </summary>
        /// <param name="width"> Width del Panel padre que se utiliza para calcular las dimensiones del nuevo Panel. </param>
        /// <param name="height"> Height del Panel padre que se utiliza para calcular las dimensiones del nuevo Panel. </param>
        /// <returns> panelArticulo => El nuevo panel ya creado. </returns>
        internal Panel GenerarPanelArticulosMantenimiento(int width, int height)
        {
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
                Width = 980,
                Height = 24,
                Location = new Point((int)(panelArticulo.Width * 0.13), 38),
                Text = "Mostrando a continuación todos los artículos que están en mantenimiento e indisponible al prestamo"
            };

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

            listaControles = new List<Control> { lblTextoBusqueda, fLPArticulos };
            panelArticulo.Controls.AddRange(listaControles.ToArray());

            cargarArticulosEnFlow();

            return panelArticulo;
        }

        private void cargarArticulosEnFlow()
        {
            FlowLayoutPanel fLPArticulo = (FlowLayoutPanel)listaControles[1];

            listadoArticulosEnMantenimiento = cnxIAM.ObtenerArticulosEnMantenimiento();

            if (listadoArticulosEnMantenimiento != null)
            {
                foreach (var articulo in listadoArticulosEnMantenimiento)
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

                    fLPArticulo.Controls.Add(btn);
                }
            }
            else
            {
                MessageBox.Show("Actualmente no hay ningún artículo en mantenimiento.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
