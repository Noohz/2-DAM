using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolineas
{
    internal class Aeropuertos
    {
        private string id;
        private string ciudad;
        private string pais;
        private byte[] imagen;

        public Aeropuertos()
        {
        }

        public Aeropuertos(string id, string ciudad, string pais, byte[] imagen)
        {
            this.id = id;
            this.ciudad = ciudad;
            this.pais = pais;
            this.imagen = imagen;
        }

        public string Id { get => id; set => id = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Pais { get => pais; set => pais = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
    }
}
