using System;

namespace EjercicioAltura
{
    internal class ClaseAltura
    {

        String provincia;
        String situacionAltMax;
        int alturaMaxima;
        String situacionAltMin;
        int alturaMinima;

        public ClaseAltura()
        {
        }

        public ClaseAltura(string provincia, string situacionAltMax, int alturaMaxima, string situacionAltMin, int alturaMinima)
        {
            this.Provincia = provincia;
            this.SituacionAltMax = situacionAltMax;
            this.AlturaMaxima = alturaMaxima;
            this.SituacionAltMin = situacionAltMin;
            this.AlturaMinima = alturaMinima;
        }

        public string Provincia { get => provincia; set => provincia = value; }
        public string SituacionAltMax { get => situacionAltMax; set => situacionAltMax = value; }
        public int AlturaMaxima { get => alturaMaxima; set => alturaMaxima = value; }
        public string SituacionAltMin { get => situacionAltMin; set => situacionAltMin = value; }
        public int AlturaMinima { get => alturaMinima; set => alturaMinima = value; }
    }
}
