using System;

namespace Rayuela
{
    internal class Alumno
    {
        private String Identificador;
        private String Nombre;
        private String Mail;
        private String Ciclo;
        private int Curso;
        private String Foto;
        private int Activo;

        public Alumno()
        {

        }

        public Alumno(string identificador, string nombre, string mail, string ciclo, int curso, string foto, int activo)
        {
            Identificador = identificador;
            Nombre = nombre;
            Mail = mail;
            Ciclo = ciclo;
            Curso = curso;
            Foto = foto;
            Activo = activo;
        }
        public string Identificador1 { get => Identificador; set => Identificador = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Mail1 { get => Mail; set => Mail = value; }
        public string Ciclo1 { get => Ciclo; set => Ciclo = value; }
        public int Curso1 { get => Curso; set => Curso = value; }
        public string Foto1 { get => Foto; set => Foto = value; }
        public int Activo1 { get => Activo; set => Activo = value; }
    }
}
