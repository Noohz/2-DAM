using System;
using System.Collections.Generic;
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

            cargarAulas(listaCursos, listaAlumnos);
        }

        // Método para cargar en el TabControl y su configuración.
        private void cargarAulas(List<Cursos> listaCursos, List<Alumno> listaAlumnos)
        {
            int nCursos = listaCursos.Count;

            for (int i = 0; i < nCursos; i++) // Este for se encargará de crear los TabPages.
            {
                // Cargar las pestañas del curso.
                TabPage tpCurso = new TabPage(listaCursos[i].IdCurso1);
                List<Alumno> listaAlumnosCurso = new List<Alumno>();
                listaAlumnosCurso = cnx.listarAlumnosXCurso(listaCursos[i].Ciclo1, listaCursos[i].Curso1);

                // Añadir el tabPage al contenedor padre.
                tabControlCiclo.Controls.Add(tpCurso);

                // Cargo los alumnos para cada curso.
                TableLayoutPanel tlp = new TableLayoutPanel();
                tlp.ColumnCount = 5;

                // Montar los alumnos por cursos.
                for (int j = 0; j < listaAlumnosCurso.Count; j++)
                {
                    FlowLayoutPanel flp = new FlowLayoutPanel();


                    tlp.Controls.Add(flp);
                }

                // Añadir el tlp al contenedor padre.
                tpCurso.Controls.Add(tlp);
            }
        }

    }
}
