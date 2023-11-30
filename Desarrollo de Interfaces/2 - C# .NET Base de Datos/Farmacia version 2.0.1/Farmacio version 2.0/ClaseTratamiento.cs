using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia_version_2._0
{
    class ClaseTratamiento
    {
      private  int identificador;
      private  String dni;
      private  String medicamento;
      private int mes;
      private int recogido;

        public ClaseTratamiento()
        {
        }

        public ClaseTratamiento(int identificador, string dni, string medicamento, int mes, int recogido)
        {
            this.Identificador = identificador;
            this.Dni = dni;
            this.Medicamento = medicamento;
            this.Mes = mes;
            this.Recogido = recogido;
        }

        public int Identificador { get => identificador; set => identificador = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Medicamento { get => medicamento; set => medicamento = value; }
        public int Mes { get => mes; set => mes = value; }
        public int Recogido { get => recogido; set => recogido = value; }
    }
}
