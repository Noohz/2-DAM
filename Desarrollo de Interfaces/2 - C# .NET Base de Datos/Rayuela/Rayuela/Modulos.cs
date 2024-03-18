using System;

namespace Rayuela
{
    internal class Modulos
    {
        private String IdModulo;
        private String Ciclo;
        private int Curso;
        private String NombreCompleto;

        public Modulos()
        {

        }

        public Modulos(string idModulo, string ciclo, int curso, string nombreCompleto)
        {
            IdModulo = idModulo;
            Ciclo = ciclo;
            Curso = curso;
            NombreCompleto = nombreCompleto;
        }

        public string IdModulo1 { get => IdModulo; set => IdModulo = value; }
        public string Ciclo1 { get => Ciclo; set => Ciclo = value; }
        public int Curso1 { get => Curso; set => Curso = value; }
        public string NombreCompleto1 { get => NombreCompleto; set => NombreCompleto = value; }
    }
}
