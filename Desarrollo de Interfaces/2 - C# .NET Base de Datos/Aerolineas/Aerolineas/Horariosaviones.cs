using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolineas
{
    public class Horariosaviones
    {
        private int idVuelo;
        private string ruta;
        private DateTime fechaSalida;
        private int precioBussines;
        private int precioTurista;
        private string idAvion;
        private int minutosVuelo;

        public Horariosaviones()
        {
        }

        public Horariosaviones(int idVuelo, string ruta, DateTime fechaSalida, int precioBussines, int precioTurista, string idAvion, int minutosVuelo)
        {
            this.idVuelo = idVuelo;
            this.ruta = ruta;
            this.fechaSalida = fechaSalida;
            this.precioBussines = precioBussines;
            this.precioTurista = precioTurista;
            this.idAvion = idAvion;
            this.minutosVuelo = minutosVuelo;
        }

        public int IdVuelo { get => idVuelo; set => idVuelo = value; }
        public string Ruta { get => ruta; set => ruta = value; }
        public DateTime FechaSalida { get => fechaSalida; set => fechaSalida = value; }
        public int PrecioBussines { get => precioBussines; set => precioBussines = value; }
        public int PrecioTurista { get => precioTurista; set => precioTurista = value; }
        public string IdAvion { get => idAvion; set => idAvion = value; }
        public int MinutosVuelo { get => minutosVuelo; set => minutosVuelo = value; }
    }
}
