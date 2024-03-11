using System;

namespace TPVExamen
{
    internal class claseFrutas
    {
        int id;
        String nombre;
        float precio;
        byte[] imagen;
        String procedencia;
        double stock;
        int activo;

        public claseFrutas()
        {
        }

        public claseFrutas(int id, string nombre, float precio, byte[] imagen, string procedencia, double stock, int activo)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Precio = precio;
            this.Imagen = imagen;
            this.Procedencia = procedencia;
            this.Stock = stock;
            this.Activo = activo;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public float Precio { get => precio; set => precio = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
        public string Procedencia { get => procedencia; set => procedencia = value; }
        public double Stock { get => stock; set => stock = value; }
        public int Activo { get => activo; set => activo = value; }
    }

}
