using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinesNavalmoral
{
    internal class ClaseSalaCine
    {
        int idSala;
        int filas;
        int columnas;

        public ClaseSalaCine()
        {

        }

        public ClaseSalaCine(int idSala, int filas, int columnas)
        {
            this.idSala = idSala;
            this.filas = filas;
            this.columnas = columnas;
        }

        public int IdSala { get => idSala; set => idSala = value; }
        public int Filas { get => filas; set => filas = value; }
        public int Columnas { get => columnas; set => columnas = value; }
    }
}
