using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Rayuela
{
    public partial class Form1 : Form
    {
        Clase_Conectar cnx = new Clase_Conectar(); // Instanciamos la clase cursos para poder utilizar sus métodos.

        List<Cursos> listaCursos = new List<Cursos>(); // La lista que va a contener los cursos.
        List<Alumno> listaAlumnos = new List<Alumno>(); // La lista que va a contener los alumnos.

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listaCursos = cnx.listarCursos(); // Aquí cargamos en la Lista los cursos.
            //listaAlumnos = cnx.listarAlumnos(); // Aquí cargamos en la lista los alumnos.

            cargarAulas(listaCursos);
        }

        // Método para cargar en el TabControl y su configuración.
        private void cargarAulas(List<Cursos> listaCursos)
        {
            int nCursos = listaCursos.Count;

            for (int i = 0; i < nCursos; i++) // Este for se encargará de crear los TabPages.
            {
                // Cargar las pestañas del curso.
                TabPage tpCurso = new TabPage(listaCursos[i].IdCurso1);

                // Listado de alumnos de ciclo: ASIR curso: 2.
                List<Alumno> listaAlumnosXCurso = new List<Alumno>();
                listaAlumnosXCurso = cnx.listarAlumnosXCurso(listaCursos[i].Ciclo1, listaCursos[i].Curso1);

                // Añadir el tabPage al contenedor padre.
                // TabControl es el único componente creado con el diseñador.
                tabControlCiclo.Controls.Add(tpCurso);

                // Cargo los alumnos para cada curso.
                TableLayoutPanel tlp = new TableLayoutPanel();
                tlp.AutoSize = true;
                tlp.ColumnCount = 5;

                // Montar los alumnos por cursos.
                for (int j = 0; j < listaAlumnosXCurso.Count; j++)
                {
                    FlowLayoutPanel flp = new FlowLayoutPanel();

                    // Diseño del flp.
                    flp.AutoSize = true;
                    flp.BackColor = Color.LightBlue;
                    flp.FlowDirection = FlowDirection.TopDown;

                    // Nombre.
                    Label lblNombre = new Label();
                    lblNombre.Text = listaAlumnosXCurso[j].Nombre1;
                    lblNombre.AutoSize = true;
                    flp.Controls.Add(lblNombre);

                    // Botón imágen
                    Button btnImagen = new Button();
                    btnImagen.Width = 75;
                    btnImagen.Height = 75;
                    btnImagen.Tag = listaAlumnosXCurso[j]; // En el tag del boton establecemos el contenido del usuario.
                    btnImagen.Click += BtnImagen_Click; // Generamos el evento onClick.
                    flp.Controls.Add(btnImagen); // Añadimos el botón en el flp.

                    // Descargar la imágen.
                    WebClient wc = new WebClient();
                    byte[] bytes = wc.DownloadData(listaAlumnosXCurso[j].Foto1); // Usando WebClient descargamos la imágen de los usuarios.

                    MemoryStream ms = new MemoryStream(bytes); // Creamos un MemoryStream que le pasamos el array de Byte que contiene la imágen.
                    Image img = Image.FromStream(ms); // Utiliza la dirección del MemoryStream para crear una imágen.

                    btnImagen.BackgroundImage = img;
                    btnImagen.BackgroundImageLayout = ImageLayout.Stretch;

                    tlp.Controls.Add(flp);
                }

                // Añadir el tlp al contenedor padre.
                tpCurso.Controls.Add(tlp);
            }
        }

        private void BtnImagen_Click(object sender, EventArgs e)
        {
            Button btnx = (Button)sender; // Utilizamos el sender para saber que boton se ha hecho click.
            Alumno cA = (Alumno)btnx.Tag; // Instanciamos a la clase Alumno y creamos un alumno con los datos que tenía el Tag del botón.

            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(cA.Foto1);

            MemoryStream ms = new MemoryStream(bytes);
            Image img = Image.FromStream(ms);

            DatosUsuario datosUsuario = new DatosUsuario(cA, img);

            datosUsuario.Show();
        }

        private void btnCrearAlumno_Click(object sender, EventArgs e)
        {
            DialogResult crearAlumno = MessageBox.Show("¿Quieres crear un nuevo alumno?", "Crear alumno", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (crearAlumno == DialogResult.Yes)
            {
                CrearAlumno crearAl = new CrearAlumno();
                crearAl.Show();
            }
        }
    }
}
