using System;

namespace ConsejeriaQR
{
    /// <summary>
    /// Clase relacionada con la tabla Prestamos de la BBDD
    /// </summary>
    internal class Prestamos
    {
        private int id;
        private int idArticulo;
        private string nombreArticulo;
        private string nombreProfesor;
        private string codigo;
        private DateTime fechaPrestamo;
        private DateTime fechaDevolucion;
        private byte[] imagen;

        public Prestamos()
        {
        }

        public Prestamos(int id, int idArticulo, string nombreArticulo, string nombreProfesor, string codigo, DateTime fechaPrestamo, DateTime fechaDevolucion, byte[] imagen)
        {
            this.id = id;
            this.idArticulo = idArticulo;
            this.nombreArticulo = nombreArticulo;
            this.nombreProfesor = nombreProfesor;
            this.codigo = codigo;
            this.fechaPrestamo = fechaPrestamo;
            this.fechaDevolucion = fechaDevolucion;
            this.imagen = imagen;
        }

        public int Id { get => id; set => id = value; }
        public int IdArticulo { get => idArticulo; set => idArticulo = value; }
        public string NombreArticulo { get => nombreArticulo; set => nombreArticulo = value; }
        public string NombreProfesor { get => nombreProfesor; set => nombreProfesor = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public DateTime FechaPrestamo { get => fechaPrestamo; set => fechaPrestamo = value; }
        public DateTime FechaDevolucion { get => fechaDevolucion; set => fechaDevolucion = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
    }
}
