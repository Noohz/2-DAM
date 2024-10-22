using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    internal class InterfazEliminarArticulos
    {
        ClaseConectar cnxIEA;
        List<Control> listaControles;
        List<articulos> listaArticulos = new List<articulos>();

        public InterfazEliminarArticulos(ClaseConectar cnxGP)
        {
            cnxIEA = cnxGP;
        }

        internal Panel generarPanelEliminarArticulos()
        {
            listaArticulos.Clear();
            listaArticulos = cnxIEA.obtenerArticulos();
            HashSet<String> nombreArticulo = new HashSet<String>(); //Un hashSet para almacenar los nombres sin que se repitan y evitarme otra consulta a la BD.

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

            foreach (var articulo in listaArticulos)
            {
                if (nombreArticulo.Add(articulo.Nombre))
                {
                    comboBoxArticulo.Items.Add(articulo.Nombre);
                }
            }

            // Un FlowLayoutPanel donde aparecerán los artículos con el nombre seleccionado en el comboBox.
            FlowLayoutPanel fLPArticulos = new FlowLayoutPanel();
            fLPArticulos.Location = new Point(60, 114);
            fLPArticulos.Width = 660;
            fLPArticulos.Height = 342;
            fLPArticulos.BorderStyle = BorderStyle.FixedSingle;
            fLPArticulos.BackColor = Color.Silver;

            listaControles = new List<Control> { lblTextoBusqueda, comboBoxArticulo, fLPArticulos };
            panelArticulo.Controls.AddRange(listaControles.ToArray());

            return panelArticulo;
        }

        private void ComboBoxArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cnx = (ComboBox)sender;

            foreach (var articulos in listaArticulos)
            {
                if (articulos.Nombre.Equals(cnx.Text))
                {

                }
            }
        }
    }
}
