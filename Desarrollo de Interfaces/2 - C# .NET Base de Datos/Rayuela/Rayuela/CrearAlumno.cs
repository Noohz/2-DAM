using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Rayuela
{
    public partial class CrearAlumno : Form
    {
        Clase_Conectar cnx = new Clase_Conectar();
        String nombreImagen = "";

        public CrearAlumno()
        {
            InitializeComponent();
            this.Text = "Crear un nuevo alumno";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImagenArchivo_Click(object sender, EventArgs e)
        {
            nombreImagen = obtenerRutaImagen();
        }

        private void btnImagenUrl_Click(object sender, EventArgs e)
        {
            ImagenURL imgURL = new ImagenURL();
            DialogResult url = imgURL.ShowDialog();

            if (url == DialogResult.OK)
            {
                nombreImagen = imgURL.textoTB;
                pictureBox1.Load(nombreImagen);

            }
        }

        private string obtenerRutaImagen()
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Archivos de imagen | *.jpg; *.jpeg; *.png;";
            nombreImagen = opf.FileName;

            String ruta = "img/";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new System.Drawing.Bitmap(opf.FileName);

                ruta += Path.GetFileName(opf.FileName);
            }

            return ruta;
        }

        private void btnCrearUsr_Click(object sender, EventArgs e)
        {
            int codigo = cnx.crearUsuario(tBIdentificador.Text, tBNombreCompleto.Text, tBEmail.Text, tBCiclo.Text, tBCurso.Text, nombreImagen);

            if (codigo == 1)
            {
                MessageBox.Show("Usuario creado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al crear el alumno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        
    }
}
