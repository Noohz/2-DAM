using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CrudMedicamento
{
    public partial class Form1 : Form
    {

        String nombreImagen;

        ConectarBD cnx = new ConectarBD();
        List<ClaseMedicamento> listaM = new List<ClaseMedicamento>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listaM = cnx.listarMedicamentos();
            dataGridView1.DataSource = listaM;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FileStream fs = new FileStream(nombreImagen, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] bloque = br.ReadBytes((int)fs.Length);

            cnx.InsertarMedicamento(txtNombre.Text, Convert.ToDouble(txtPrecio.Text),
                Convert.ToInt16(txtStockActual.Text), Convert.ToInt16(txtStockMinimo.Text),
                bloque);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog();
            op1.Filter = "imagenes|*.jpg;*.png";
            if (op1.ShowDialog() == DialogResult.OK)
            {
                nombreImagen = op1.FileName; // Sacamos la ruta completa de la imágen.
                pctImagen.Image = Image.FromFile(nombreImagen);
                //cargarImagen = true;
            }
        }
    }
}
