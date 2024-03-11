using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Dgv_Empleados_Frutas
{
    public partial class Form1 : Form
    {

        List<ClaseEmpleados> listaEmp = new List<ClaseEmpleados>();
        List<ClaseFrutas> listaFrutas = new List<ClaseFrutas>();
        ClaseConectar cnx = new ClaseConectar();
        String nombreFichero;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listaEmp = cnx.listarEmpleados();
            listaFrutas = cnx.listarFrutas();

            dgvEmpleados.DataSource = listaEmp;
            dgvFrutas.DataSource = listaFrutas;
        }

        private void dgvEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(listaEmp[fila].Imagen);
            MemoryStream ms = new MemoryStream(bytes);
            System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);


            btnImagenEmpleado.BackgroundImage = imagen;
        }

        private void dgvFrutas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;
            int cont = listaFrutas[fila].Id;

            MemoryStream ms = new MemoryStream(listaFrutas[fila].Imagen);
            System.Drawing.Image m = System.Drawing.Image.FromStream(ms);
            btnImagenFruta.BackgroundImage = m;

            textBox1.Text = listaFrutas[fila].Nombre;
            textBox2.Text = String.Format("{0:0.00}", listaFrutas[fila].Precio); // Para dar formato al precio y que solo salgan 2 decimales.

            DialogResult resultado = MessageBox.Show("¿Quieres eliminar el campo " + textBox1.Text + "?", "Proyecto Frutas", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                string n = cnx.quitarFruta(listaFrutas[fila].Id);

                if (n != "")
                {
                    MessageBox.Show(n);
                }
                else
                {
                    MessageBox.Show("Se ha borrado correctamente " + textBox1.Text);
                }

            }

            metodoRefrescar();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnx.poner();
            metodoRefrescar();
        }

        private void metodoRefrescar()
        {
            listaFrutas.Clear();
            btnImagenFruta.BackgroundImage = null;
            textBox1.Text = "";
            textBox2.Text = "";
            listaFrutas = cnx.listarFrutas();
            dgvFrutas.DataSource = null;
            dgvFrutas.DataSource = listaFrutas;
        }

        private void btnInsertarFruta_Click(object sender, EventArgs e)
        {


            FileStream fs = new FileStream(nombreFichero, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] bt = br.ReadBytes((int)fs.Length);
            cnx.insertarFruta(textBox1.Text, Convert.ToDouble(textBox2.Text), bt);
            metodoRefrescar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Imagenes | *.jpg; *.png";
            nombreFichero = opf.FileName;

            if (opf.ShowDialog() == DialogResult.OK)
            {
                nombreFichero = opf.FileName;
                pictureBox1.Image = Image.FromFile(nombreFichero);
                pictureBox1.BackgroundImage = Image.FromFile(nombreFichero);
            }

        }
    }
}
