using System;

namespace Dgv_Empleados_Frutas
{
    internal class ClaseFrutas
    {

        int id;
        String nombre;
        double precio;
        byte[] imagen;
        int activo;

        public ClaseFrutas()
        {
        }

        public ClaseFrutas(int id, string nombre, double precio, byte[] imagen, int activo)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Precio = precio;
            this.Imagen = imagen;
            this.Activo = activo;
        }


        public int Id { get => Id1; set => Id1 = value; }
        public string Nombre { get => Nombre1; set => Nombre1 = value; }
        public double Precio { get => Precio1; set => Precio1 = value; }
        public byte[] Imagen { get => Imagen1; set => Imagen1 = value; }
        public int Id1 { get => id; set => id = value; }
        public string Nombre1 { get => nombre; set => nombre = value; }
        public double Precio1 { get => precio; set => precio = value; }
        public byte[] Imagen1 { get => imagen; set => imagen = value; }
        public int Activo { get => activo; set => activo = value; }
    }
}
