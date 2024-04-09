using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CinesNavalmoral
{
    public partial class Form1 : Form
    {
        ClaseConectar cnx = new ClaseConectar();

        List<ClaseCartelera> listaPeliculas = new List<ClaseCartelera>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listaPeliculas = cnx.listarCarteles(); // Obtiene la lista de las películas (Titulo e Imágen).
            cargarCarteles(listaPeliculas);
        }

        // Método para cargar la cartelera de películas en el TableLayoutPanel generado programmatically en el Panel que está en el diseño.
        private void cargarCarteles(List<ClaseCartelera> listaPeliculas)
        {
            int nPeliculas = listaPeliculas.Count;
            int cuadratura = (int)Math.Ceiling(Math.Sqrt(nPeliculas)); // Esto devuelve el resultado mayor de la raiz cuadrada del número de películas.

            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.AutoSize = true;
            tlp.RowCount = cuadratura;
            tlp.ColumnCount = cuadratura;
            panelPrincipal.Controls.Add(tlp);

            for (int p = 0; p < listaPeliculas.Count; p++)
            {
                FlowLayoutPanel flowPeliculas = new FlowLayoutPanel();
                flowPeliculas.AutoSize = true;
                flowPeliculas.FlowDirection = FlowDirection.TopDown;
                flowPeliculas.Padding = new Padding(27);

                // Propiedades del button.
                Button botonX = new Button();
                botonX.Width = 90;
                botonX.Height = 90;

                // Cargar el objeto en la propiedad Tag.
                botonX.Tag = listaPeliculas[p];

                // Cargar el evento.
                botonX.Click += BotonX_Click;

                // Propiedades del label.
                Label lblTitulo = new Label();

                // Cargar el texto del título.
                lblTitulo.Text = listaPeliculas[p].Titulo;
                lblTitulo.AutoSize = true;

                flowPeliculas.Controls.Add(botonX);
                flowPeliculas.Controls.Add(lblTitulo);
                tlp.Controls.Add(flowPeliculas);

                // Cargar la imágen.
                MemoryStream ms = new MemoryStream(listaPeliculas[p].Cartel);
                botonX.BackgroundImage = Image.FromStream(ms);
                botonX.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void BotonX_Click(object sender, EventArgs e)
        {
            Button btnX = (Button)sender;
            ClaseCartelera cc = (ClaseCartelera)btnX.Tag;

            FormularioSesion fs = new FormularioSesion(cc);
            fs.ShowDialog();
        }
    }
}
