using System;

namespace TPV
{
    class claseCesta
    {
        int articulo;
        String nombre;
        double peso;
        double precioUnitario;
        double precioParcial;



        public claseCesta() { }


        public claseCesta(int articulo, string nombre, double peso, double precioUnitario, double precioParcial)
        {
            this.Articulo = articulo;
            this.Nombre = nombre;
            this.Peso = peso;
            this.PrecioUnitario = precioUnitario;
            this.PrecioParcial = precioParcial;
        }

        public int Articulo { get => articulo; set => articulo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Peso { get => peso; set => peso = value; }
        public double PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public double PrecioParcial { get => precioParcial; set => precioParcial = value; }
    }
}
