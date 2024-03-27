using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Rayuela
{
    public partial class DatosUsuario : Form
    {
        Clase_Conectar cnx = new Clase_Conectar();

        List<String> notas = new List<String>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        List<Modulos> asignaturas = new List<Modulos>();

        public DatosUsuario(Alumno cA, Image img)
        {
            InitializeComponent();

            this.Text = cA.Nombre1;

            lblIdentificador.Text = cA.Identificador1;
            lblNombre.Text = cA.Nombre1;
            lblCiclo.Text = cA.Ciclo1;
            lblCurso.Text = cA.Curso1.ToString();
            lblCorreo.Text = cA.Mail1;

            pBImagen.Image = img;

            asignaturas = cnx.listadoModulosXCursosXCiclos(cA.Ciclo1, cA.Curso1);

            foreach (var asig in asignaturas)
            {
                cBAsignatura.Items.Add(asig.IdModulo1);
            }

            cBNota.Items.AddRange(notas.ToArray());

            btnInformar.Tag = cA;
            btnInformar.Click += BtnInformar_Click;

            btnNoAsiste.Tag = cA;
            btnNoAsiste.Click += BtnNoAsiste_Click;

            btnPuntuar.Tag = cA;
            btnPuntuar.Click += BtnPuntuar_Click;                   

            btnCerrar.Click += BtnCerrar_Click;
        }

        private void BtnPuntuar_Click(object sender, EventArgs e)
        {
            Button btnx = (Button)sender;
            Alumno nA = (Alumno)btnx.Tag;

            if (cBAsignatura.SelectedIndex == -1 | cBNota.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar la asignatura y la nota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                cnx.insertarCalificacion(nA.Identificador1, cBAsignatura.Text.ToString(), cBNota.Text.ToString());
                MessageBox.Show("Puntuación introducida correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }                    
        }

        private void BtnNoAsiste_Click(object sender, EventArgs e)
        {
            Button btnx = (Button)sender;
            Alumno nA = (Alumno)btnx.Tag;

            String fecha = DateTime.Now.ToString("yyyyMMddHHmmss");

            if (cBAsignatura.SelectedIndex == -1)
            {
                MessageBox.Show("Debes seleccionar la asignatura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cnx.insertarFalta(nA.Identificador1, cBAsignatura.Text.ToString(), fecha);
                MessageBox.Show("Falta de asistencia introducida correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnInformar_Click(object sender, EventArgs e)
        {
            Button btnx = (Button)sender;
            Alumno nA = (Alumno)btnx.Tag;

            InformacionAlumno informacionAlumno = new InformacionAlumno(nA);
            informacionAlumno.Show();
        }
    }
}
