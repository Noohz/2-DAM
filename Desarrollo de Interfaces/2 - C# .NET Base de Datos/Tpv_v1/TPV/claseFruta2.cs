using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPV
{
    class claseFruta2
    {
        int id;
        String nombre;
        float precio;
        String imagen;
        String procedencia;
        int stock;

        public claseFruta2() { }

        public claseFruta2(int id, string nombre, float precio,String imagen, string procedencia, int stock)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Precio = precio;
            this.Imagen = imagen;
            this.Procedencia = procedencia;
            this.Stock = stock;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public float Precio { get => precio; set => precio = value; }
        public String Imagen { get => imagen; set => imagen = value; }
        public string Procedencia { get => procedencia; set => procedencia = value; }
        public int Stock { get => stock; set => stock = value; }


    }
}
