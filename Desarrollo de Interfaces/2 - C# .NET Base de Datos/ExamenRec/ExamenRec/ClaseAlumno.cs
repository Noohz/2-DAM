using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenRec
{
    internal class ClaseAlumno
    {
        private String identificador, nombre, mail, ciclo;
        private int curso;
        private byte[] foto;

        public ClaseAlumno()
        {

        }

        public ClaseAlumno(string identificador, string nombre, string mail, string ciclo, int curso, byte[] foto)
        {
            this.identificador = identificador;
            this.nombre = nombre;
            this.mail = mail;
            this.ciclo = ciclo;
            this.curso = curso;
            this.foto = foto;
        }

        public string Identificador { get => identificador; set => identificador = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Ciclo { get => ciclo; set => ciclo = value; }
        public int Curso { get => curso; set => curso = value; }
        public byte[] Foto { get => foto; set => foto = value; }
    }
}
