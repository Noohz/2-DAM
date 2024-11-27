using System;

namespace ConsejeriaQR
{
    /// <summary>
    /// Clase Articulos modificada para insertar los datos en el DataGridView de "Añadir artículos".
    /// </summary>
    internal class ArticulosDGV
    {
        private int id;
        private string nombre;
        private string descripcion;
        private string codigo;
        private bool activo;
        private bool mantenimiento;

        public ArticulosDGV()
        {
        }

        public ArticulosDGV(int id, string nombre, string descripcion, string codigo, bool activo, bool mantenimiento)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.codigo = codigo;
            this.activo = activo;
            this.mantenimiento = mantenimiento;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public bool Activo { get => activo; set => activo = value; }
        public bool Mantenimiento { get => mantenimiento; set => mantenimiento = value; }
    }
}
