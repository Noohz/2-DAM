using System;
using System.IO;
using System.Windows.Forms;

namespace ExamenRec
{
    public partial class InformacioUsuario : Form
    {
        ConectarBD cnx = new ConectarBD();

        internal InformacioUsuario(ClaseAlumno alumnoSeleccionado)
        {
            InitializeComponent();
            obtenerDatosAlumnos(alumnoSeleccionado);
        }

        private void InformacioUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnInformar_Click(object sender, EventArgs e)
        {
            FaltasAsistenciaAlumno fSA = new FaltasAsistenciaAlumno();
            fSA.ShowDialog();
            this.Hide();
        }

        internal void obtenerDatosAlumnos(ClaseAlumno alumnoSeleccionado)
        {
            ClaseAlumno cA = cnx.buscarUsuario(alumnoSeleccionado);
            textBoxIdentificador.Text = cA.Identificador;
            textBoxNombre.Text = cA.Nombre;
            textBoxCurso.Text = cA.Curso.ToString();
            textBoxEmail.Text = cA.Mail;

            MemoryStream ms = new MemoryStream(cA.Foto);
            System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms);
            pictureBoxAlumno.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxAlumno.BackgroundImage = imagen;
        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            Button btnx = (Button)sender;
            String nombreAlumno = textBoxNombre.Text;
            String idAlumno = textBoxIdentificador.Text;
            String modulo = (string)comboBoxModulo.SelectedItem;
            DateTime fechaActual = DateTime.Now;

            if (cnx.aniadirFalta(idAlumno, fechaActual, modulo))
            {
                MessageBox.Show("Se ha añadido la falta al usuario " + nombreAlumno + " correctamente");
            } else
            {
                MessageBox.Show("Ha ocurrido un error al insertar la falta al usuario: " + nombreAlumno);
            }
            
        }

        private void btnPuntuar_Click(object sender, EventArgs e)
        {
            Button btnx = (Button)sender;
            String nombreAlumno = textBoxNombre.Text;
            String idAlumno = textBoxIdentificador.Text;
            String modulo = (String)comboBoxModulo.SelectedItem;
            int puntos = (int) comboBoxNota.SelectedIndex;

            if (cnx.aniadirNota(idAlumno, modulo, puntos))
            {
                MessageBox.Show("Se ha añadido la nota " + puntos + " al usuario: " + nombreAlumno);
            } else
            {
                MessageBox.Show("Ha ocurrido un error al añadir la nota del usuario: " + nombreAlumno);
            }
        }
    }
}
