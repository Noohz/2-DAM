using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinesNavalmoral
{
    public class ClaseCartelera
    {
        private int indice;
        private string titulo;
        private string sesion;
        private int sala;
        private byte[] cartel;

        public ClaseCartelera()
        {

        }

        public ClaseCartelera(int indice, string titulo, string sesion, int sala, byte[] cartel)
        {
            this.indice = indice;
            this.titulo = titulo;
            this.sesion = sesion;
            this.sala = sala;
            this.cartel = cartel;
        }

        public int Indice { get => indice; set => indice = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Sesion { get => sesion; set => sesion = value; }
        public int Sala { get => sala; set => sala = value; }
        public byte[] Cartel { get => cartel; set => cartel = value; }
    }


}
