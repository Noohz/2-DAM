using System;

namespace CrudMedicamento
{
    internal class ClaseMedicamento
    {
        int indice;
        String nombre;
        double precio;
        byte[] imagen;
        int stockMinimo;
        int stockActual;
        int activo;

        public ClaseMedicamento()
        {

        }

        public ClaseMedicamento(int indice, string nombre, double precio, byte[] imagen, int stockMinimo, int stockActual, int activo)
        {
            this.Indice = indice;
            this.Nombre = nombre;
            this.Precio = precio;
            this.Imagen = imagen;
            this.StockMinimo = stockMinimo;
            this.StockActual = stockActual;
            this.Activo = activo;
        }

        public int Indice { get => indice; set => indice = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Precio { get => precio; set => precio = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
        public int StockMinimo { get => stockMinimo; set => stockMinimo = value; }
        public int StockActual { get => stockActual; set => stockActual = value; }
        public int Activo { get => activo; set => activo = value; }
    }
}
