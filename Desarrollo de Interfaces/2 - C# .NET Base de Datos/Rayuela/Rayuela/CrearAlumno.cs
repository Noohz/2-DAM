using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rayuela
{
    public partial class CrearAlumno : Form
    {
        Clase_Conectar cnx = new Clase_Conectar();
        String nombreImagen;

        public CrearAlumno()
        {
            InitializeComponent();
            this.Text = "Crear un nuevo alumno";

            //cnx.crearAlumno(tBIdentificador.Text, tBNombreCompleto.Text, tBEmail.Text, tBCiclo.Text, tBCurso.Text);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            nombreImagen = obtenerRutaImagen();
        }

        private string obtenerRutaImagen()
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Archivos de imagen | *.jpg; *.jpeg; *.png;";
            nombreImagen = opf.FileName;

            string ruta = "";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new System.Drawing.Bitmap(opf.FileName);

                ruta = opf.FileName;
            }

            return ruta;
        }

        private void btnCrearUsr_Click(object sender, EventArgs e)
        {
            cnx.crearUsuario(tBIdentificador.Text, tBNombreCompleto.Text, tBEmail.Text, tBCiclo.Text, tBCurso.Text, nombreImagen);
        }
    }
}
