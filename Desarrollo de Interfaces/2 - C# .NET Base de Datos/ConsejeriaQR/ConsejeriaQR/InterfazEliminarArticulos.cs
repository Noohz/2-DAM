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

        internal Panel generarPanelEliminarArticulos()
        {
            listaNombreArticulos = cnxIEA.obtenerNombreArticulos();            

            // Todo esto se generará de forma programmatically.
            // Panel que contendrá los Controls para introducir los datos del artículo.
            Panel panelArticulo = new Panel();
            panelArticulo.Location = new Point(149, 105);
            panelArticulo.Width = 775;
            panelArticulo.Height = 496;
            panelArticulo.BackColor = Color.White;

            Label lblTextoBusqueda = new Label();
            lblTextoBusqueda.Location = new Point(56, 38);
            lblTextoBusqueda.Font = new Font("Arial", 15, FontStyle.Bold);
            lblTextoBusqueda.Width = 348;
            lblTextoBusqueda.Height = 24;
            lblTextoBusqueda.Text = "Selecciona el artículo a buscar =>";

            // ComboBox para que el usuario pueda elegir las opciones mediante los nombres que hay en la tabla Articulos > nombres.
            ComboBox comboBoxArticulo = new ComboBox();
            comboBoxArticulo.Location = new Point(424, 35);
            comboBoxArticulo.Width = 296;
            comboBoxArticulo.Height = 27;
            comboBoxArticulo.Font = new Font("Arial", 12, FontStyle.Bold);
            comboBoxArticulo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxArticulo.SelectedIndexChanged += ComboBoxArticulo_SelectedIndexChanged;

            foreach (var articulo in listaNombreArticulos)
            {
                comboBoxArticulo.Items.Add(articulo.Nombre);
            }

            // Un FlowLayoutPanel donde aparecerán los artículos con el nombre seleccionado en el comboBox.
            FlowLayoutPanel fLPArticulos = new FlowLayoutPanel();
            fLPArticulos.Location = new Point(60, 114);
            fLPArticulos.Width = 660;
            fLPArticulos.Height = 342;
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

            listaArticulos = cnxIEA.obtenerArticulos(cbX.Text);
            fLPArticulo.Controls.Clear();

            foreach (var articulo in listaArticulos)
            {
                Button btn = new Button();
                btn.Name = articulo.Codigo;

                btn.Width = 95;
                btn.Height = 95;
                btn.Margin = new Padding(13, 5, 0, 5);

                MemoryStream ms = new System.IO.MemoryStream(articulo.Imagen);
                System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
                System.Drawing.Image imagenRedimensionada = new System.Drawing.Bitmap(imagen, new System.Drawing.Size(45, 45));
                btn.Image = imagenRedimensionada;
                btn.ImageAlign = ContentAlignment.TopCenter;

                fLPArticulo.Controls.Add(btn);
            }
        }
    }
}
