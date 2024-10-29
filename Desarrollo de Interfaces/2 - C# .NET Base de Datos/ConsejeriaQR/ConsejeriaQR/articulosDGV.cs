using System;

namespace ConsejeriaQR
{
    internal class articulosDGV
    {
        private int id;
        private string nombre;
        private string descripcion;
        private string codigo;
        private bool activo;

        public articulosDGV()
        {
        }

        public articulosDGV(int id, string nombre, string descripcion, string codigo, bool activo)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.codigo = codigo;
            this.activo = activo;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public bool Activo { get => activo; set => activo = value; }
    }
}
