using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    internal class InterfazEliminarArticulos
    {
        ClaseConectar cnxIEA;
        List<Control> listaControles;
        List<articulos> listaNombreArticulos = new List<articulos>();
        List<articulos> listaArticulos = new List<articulos>();

        public InterfazEliminarArticulos(ClaseConectar cnxGP)
        {
            cnxIEA = cnxGP;
        }

        internal Panel generarPanelEliminarArticulos(int width, int height)
        {
            listaNombreArticulos = cnxIEA.obtenerNombreArticulos();            

            // Todo esto se generará de forma programmatically.
            // Panel que contendrá los Controls para introducir los datos del artículo.
            Panel panelArticulo = new Panel();
            panelArticulo.Width = width - (width * 20 / 100);
            panelArticulo.Height = height - (height * 20 / 100);
            panelArticulo.BackColor = Color.White;
            panelArticulo.Location = new Point((width - panelArticulo.Width) / 2, (height - panelArticulo.Height) / 2);

            Label lblTextoBusqueda = new Label();            
            lblTextoBusqueda.Font = new Font("Arial", 15, FontStyle.Bold);
            lblTextoBusqueda.Width = 348;
            lblTextoBusqueda.Height = 24;
            lblTextoBusqueda.Location = new Point((int)(panelArticulo.Width * 0.10), 38);
            lblTextoBusqueda.Text = "Selecciona el artículo a buscar =>";

            // ComboBox para que el usuario pueda elegir las opciones mediante los nombres que hay en la tabla Articulos > nombres.
            ComboBox comboBoxArticulo = new ComboBox();            
            comboBoxArticulo.Width = 296;
            comboBoxArticulo.Height = 27;
            comboBoxArticulo.Font = new Font("Arial", 12, FontStyle.Bold);
            comboBoxArticulo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxArticulo.Location = new Point((int)(panelArticulo.Width - comboBoxArticulo.Width - (panelArticulo.Width * 0.10)), 35);            
            comboBoxArticulo.SelectedIndexChanged += ComboBoxArticulo_SelectedIndexChanged;

            foreach (var articulo in listaNombreArticulos)
            {
                comboBoxArticulo.Items.Add(articulo.Nombre);
            }

            // Un FlowLayoutPanel donde aparecerán los artículos con el nombre seleccionado en el comboBox.
            FlowLayoutPanel fLPArticulos = new FlowLayoutPanel();
            fLPArticulos.Width = (int)(panelArticulo.Width * 0.81);
            fLPArticulos.Height = (int)(panelArticulo.Height * 0.7);
            fLPArticulos.Location = new Point((int)(panelArticulo.Width * 0.10), 114);
            fLPArticulos.BorderStyle = BorderStyle.FixedSingle;
            fLPArticulos.BackColor = Color.Silver;
            fLPArticulos.AutoScroll = true;            

            listaControles = new List<Control> { lblTextoBusqueda, comboBoxArticulo, fLPArticulos };
            panelArticulo.Controls.AddRange(listaControles.ToArray());

            return panelArticulo;
        }

        private void ComboBoxArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbX = (ComboBox)sender;
            FlowLayoutPanel fLPArticulo = (FlowLayoutPanel)listaControles[2];

            listaArticulos = cnxIEA.obtenerArticulos();
            fLPArticulo.Controls.Clear();

            foreach (var articulo in listaArticulos)
            {
                if (articulo.Nombre.Equals(cbX.Text))
                {
                    Button btn = new Button();
                    btn.Name = articulo.Codigo;

                    btn.Width = 95;
                    btn.Height = 95;
                    btn.Margin = new Padding(13, 5, 0, 5);
                    btn.Text = articulo.Codigo;
                    btn.TextAlign = ContentAlignment.BottomCenter;
                    btn.Font = new Font("Arial", 9, FontStyle.Bold);

                    MemoryStream ms = new System.IO.MemoryStream(articulo.Imagen);
                    System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
                    System.Drawing.Image imagenRedimensionada = new System.Drawing.Bitmap(imagen, new System.Drawing.Size(70, 70));
                    btn.Image = imagenRedimensionada;
                    btn.ImageAlign = ContentAlignment.TopCenter;

                    fLPArticulo.Controls.Add(btn);
                }                
            }
        }
    }
}
