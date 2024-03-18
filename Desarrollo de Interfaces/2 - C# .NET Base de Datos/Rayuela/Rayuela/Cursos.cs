using System;

namespace Rayuela
{
    internal class Cursos
    {
        private String IdCurso;
        private String NombreCompleto;
        private int Curso;
        private String Ciclo;

        public Cursos()
        {

        }

        public Cursos(string idCurso, string nombreCompleto, int curso, string ciclo)
        {
            IdCurso = idCurso;
            NombreCompleto = nombreCompleto;
            Curso = curso;
            Ciclo = ciclo;
        }

        public string IdCurso1 { get => IdCurso; set => IdCurso = value; }
        public string NombreCompleto1 { get => NombreCompleto; set => NombreCompleto = value; }
        public int Curso1 { get => Curso; set => Curso = value; }
        public string Ciclo1 { get => Ciclo; set => Ciclo = value; }
    }
}
