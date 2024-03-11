using System;

namespace Examen6Octubre
{
    internal class ClaseFruta
    {

        int id;
        String nombre;
        float precio;
        byte[] imagen;
        String procedencia;
        int stock;

        public ClaseFruta()
        {
        }

        public ClaseFruta(int id, string nombre, float precio, byte[] imagen, string procedencia, int stock)
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
        public byte[] Imagen { get => imagen; set => imagen = value; }
        public string Procedencia { get => procedencia; set => procedencia = value; }
        public int Stock { get => stock; set => stock = value; }
    }
}
