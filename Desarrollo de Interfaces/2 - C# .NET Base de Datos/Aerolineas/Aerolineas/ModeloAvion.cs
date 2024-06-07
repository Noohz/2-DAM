using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolineas
{
    internal class ModeloAvion
    {
        private string idAvion;
        private string modelo;
        private int fBussines;
        private int fTurista;
        private byte[] imagen;

        public ModeloAvion()
        {
        }

        public ModeloAvion(string idAvion, string modelo, int fBussines, int fTurista, byte[] imagen)
        {
            this.idAvion = idAvion;
            this.modelo = modelo;
            this.fBussines = fBussines;
            this.fTurista = fTurista;
            this.imagen = imagen;
        }

        public string IdAvion { get => idAvion; set => idAvion = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public int FBussines { get => fBussines; set => fBussines = value; }
        public int FTurista { get => fTurista; set => fTurista = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
    }
}
