using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacio_version_2._0
{
    class ClaseFacturacion
    {
         private int indice;
        private String Dni;
        private String CadenaProd;
        private DateTime fecha;
        private float Total;

        public ClaseFacturacion()
        {
        }

        public ClaseFacturacion(int indice, string dni, string cadenaProd, DateTime fecha, float total)
        {
            this.Indice = indice;
            Dni1 = dni;
            CadenaProd1 = cadenaProd;
            this.Fecha = fecha;
            Total1 = total;
        }

        public int Indice { get => indice; set => indice = value; }
        public string Dni1 { get => Dni; set => Dni = value; }
        public string CadenaProd1 { get => CadenaProd; set => CadenaProd = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public float Total1 { get => Total; set => Total = value; }
    }
}
