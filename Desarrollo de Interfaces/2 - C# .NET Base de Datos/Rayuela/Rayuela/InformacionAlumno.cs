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
    public partial class InformacionAlumno : Form
    {
        Clase_Conectar cnx = new Clase_Conectar();
        List<Calificaciones> calificaciones = new List<Calificaciones>();
        List<Faltasasistencia> faltasasistencias = new List<Faltasasistencia>();

        public InformacionAlumno(Alumno nA)
        {
            InitializeComponent();

            this.Text = "Calificaciones / Asistencia de " + nA.Nombre1;

            calificaciones = cnx.listarCalificaciones(nA.Identificador1, nA.Ciclo1, nA.Curso1);
            dGVCalif.DataSource = calificaciones;

            faltasasistencias = cnx.listarFaltas(nA.Identificador1);
            dGVAsis.DataSource = faltasasistencias;
        }
    }
}
