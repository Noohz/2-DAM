using System;

namespace TPV
{
    class claseFruta
    {
        int id;
        String nombre;
        float precio;
        byte[] imagen;
        double stock;
        int activo;

        public claseFruta() { }

        public claseFruta(int id, string nombre, float precio, byte[] imagen, string procedencia, int stock)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Precio = precio;
            this.Imagen = imagen;
            this.Stock = stock;
            this.Activo = Activo;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public float Precio { get => precio; set => precio = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
        public double Stock { get => stock; set => stock = value; }
        public int Activo { get => activo; set => activo = value; }
    }
}
