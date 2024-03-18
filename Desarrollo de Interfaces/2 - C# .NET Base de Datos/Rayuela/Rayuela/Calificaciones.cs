using System;

namespace Rayuela
{
    internal class Calificaciones
    {
        private int Indice;
        private String IdentificadorAlumno;
        private String Modulo;
        private int Puntos;


        public Calificaciones()
        {

        }

        public Calificaciones(int indice, string identificadorAlumno, string modulo, int puntos)
        {
            Indice = indice;
            IdentificadorAlumno = identificadorAlumno;
            Modulo = modulo;
            Puntos = puntos;
        }

        public int Indice1 { get => Indice; set => Indice = value; }
        public string IdentificadorAlumno1 { get => IdentificadorAlumno; set => IdentificadorAlumno = value; }
        public string Modulo1 { get => Modulo; set => Modulo = value; }
        public int Puntos1 { get => Puntos; set => Puntos = value; }
    }
}
