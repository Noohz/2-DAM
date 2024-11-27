using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsejeriaQR
{
    /// <summary>
    /// Clase relacionada con la tabla PrestamosHistorico de la BBDD
    /// </summary>
    internal class PrestamosHistorico
    {
        private int id;
        private int idArticulo;
        private string nombreArticulo;
        private string nombreProfesor;
        private string codigo;
        private DateTime fechaPrestamo;
        private DateTime fechaDevolucionInicial;
        private DateTime fechaDevolucionFinal;
        private byte[] imagen;

        public PrestamosHistorico()
        {
        }

        public PrestamosHistorico(int id, int idArticulo, string nombreArticulo, string nombreProfesor, string codigo, DateTime fechaPrestamo, DateTime fechaDevolucionInicial, DateTime fechaDevolucionFinal, byte[] imagen)
        {
            this.id = id;
            this.idArticulo = idArticulo;
            this.nombreArticulo = nombreArticulo;
            this.nombreProfesor = nombreProfesor;
            this.codigo = codigo;
            this.fechaPrestamo = fechaPrestamo;
            this.fechaDevolucionInicial = fechaDevolucionInicial;
            this.fechaDevolucionFinal = fechaDevolucionFinal;
            this.imagen = imagen;
        }

        public int Id { get => id; set => id = value; }
        public int IdArticulo { get => idArticulo; set => idArticulo = value; }
        public string NombreArticulo { get => nombreArticulo; set => nombreArticulo = value; }
        public string NombreProfesor { get => nombreProfesor; set => nombreProfesor = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public DateTime FechaPrestamo { get => fechaPrestamo; set => fechaPrestamo = value; }
        public DateTime FechaDevolucionInicial { get => fechaDevolucionInicial; set => fechaDevolucionInicial = value; }
        public DateTime FechaDevolucionFinal { get => fechaDevolucionFinal; set => fechaDevolucionFinal = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
    }
}
