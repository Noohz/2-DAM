﻿using System;

namespace Rayuela
{
    internal class Faltasasistencia
    {
        private int Indice;
        private String IdentificadorAlumno;
        private String Fecha;
        private String Modulo;

        public Faltasasistencia()
        {

        }

        public Faltasasistencia(int indice, string identificadorAlumno, string fecha, string modulo)
        {
            Indice = indice;
            IdentificadorAlumno = identificadorAlumno;
            Fecha = fecha;
            Modulo = modulo;
        }

        public int Indice1 { get => Indice; set => Indice = value; }
        public string IdentificadorAlumno1 { get => IdentificadorAlumno; set => IdentificadorAlumno = value; }
        public string Fecha1 { get => Fecha; set => Fecha = value; }
        public string Modulo1 { get => Modulo; set => Modulo = value; }
    }
}
