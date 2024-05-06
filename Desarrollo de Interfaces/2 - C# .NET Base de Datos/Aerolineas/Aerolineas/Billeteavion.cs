using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolineas
{
    internal class Billeteavion
    {
        private int idVuelo;
        private string idAsiento;
        private string comprador;
        private DateTime fechaReserva;
        private int precioFinalBillete;
        private bool ocupado;

        public Billeteavion()
        {
        }

        public Billeteavion(int idVuelo, string idAsiento, string comprador, DateTime fechaReserva, int precioFinalBillete, bool ocupado)
        {
            this.idVuelo = idVuelo;
            this.idAsiento = idAsiento;
            this.comprador = comprador;
            this.fechaReserva = fechaReserva;
            this.precioFinalBillete = precioFinalBillete;
            this.ocupado = ocupado;
        }

        public int IdVuelo { get => idVuelo; set => idVuelo = value; }
        public string IdAsiento { get => idAsiento; set => idAsiento = value; }
        public string Comprador { get => comprador; set => comprador = value; }
        public DateTime FechaReserva { get => fechaReserva; set => fechaReserva = value; }
        public int PrecioFinalBillete { get => precioFinalBillete; set => precioFinalBillete = value; }
        public bool Ocupado { get => ocupado; set => ocupado = value; }
    }
}
