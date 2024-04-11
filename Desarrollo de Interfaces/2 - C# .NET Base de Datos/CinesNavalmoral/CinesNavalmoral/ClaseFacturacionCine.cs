using System;

namespace CinesNavalmoral
{
    internal class ClaseFacturacionCine
    {
        int id;
        int idSala;
        int fila;
        int columna;
        String sesion;
        int ocupado;

        public ClaseFacturacionCine()
        {
        }

        public ClaseFacturacionCine(int id, int idSala, int fila, int columna, string sesion, int ocupado)
        {
            this.id = id;
            this.idSala = idSala;
            this.fila = fila;
            this.columna = columna;
            this.sesion = sesion;
            this.ocupado = ocupado;
        }

        public int Id { get => id; set => id = value; }
        public int IdSala { get => idSala; set => idSala = value; }
        public int Fila { get => fila; set => fila = value; }
        public int Columna { get => columna; set => columna = value; }
        public string Sesion { get => sesion; set => sesion = value; }
        public int Ocupado { get => ocupado; set => ocupado = value; }
    }
}
