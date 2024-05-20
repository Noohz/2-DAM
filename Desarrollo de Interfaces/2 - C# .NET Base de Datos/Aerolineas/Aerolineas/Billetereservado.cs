using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolineas
{
    internal class Billetereservado
    {
        private int idVuelo;
        private string idAsiento;
        private string comprador;

        public Billetereservado()
        {
        }

        public Billetereservado(int idVuelo, string idAsiento, string comprador)
        {
            this.idVuelo = idVuelo;
            this.idAsiento = idAsiento;
            this.comprador = comprador;
        }

        public int IdVuelo { get => idVuelo; set => idVuelo = value; }
        public string IdAsiento { get => idAsiento; set => idAsiento = value; }
        public string Comprador { get => comprador; set => comprador = value; }
    }
}
