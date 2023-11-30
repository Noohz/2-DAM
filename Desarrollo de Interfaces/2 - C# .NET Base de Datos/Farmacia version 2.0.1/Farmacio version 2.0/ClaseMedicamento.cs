using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia_version_2._0
{
    

        class ClaseMedicamento
        {
            private int indice, stockMin, stockAct;
            private String nombre;
            private double precio;
            private byte[] imagen;


            public ClaseMedicamento()
            {

            }

            public ClaseMedicamento(int indice, string nombre, double precio, byte[] imagen, int stockMin, int stockAct)
            {
                this.Indice = indice;
                this.StockMin = stockMin;
                this.StockAct = stockAct;
                this.Nombre = nombre;
                this.Precio = precio;
                this.Imagen = imagen;
            }

            public int Indice { get => indice; set => indice = value; }
            public int StockMin { get => stockMin; set => stockMin = value; }
            public int StockAct { get => stockAct; set => stockAct = value; }
            public string Nombre { get => nombre; set => nombre = value; }
            public double Precio { get => precio; set => precio = value; }
            public byte[] Imagen { get => imagen; set => imagen = value; }
        }
    }

