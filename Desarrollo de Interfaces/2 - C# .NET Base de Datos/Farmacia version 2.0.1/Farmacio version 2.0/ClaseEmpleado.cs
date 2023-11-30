using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia_version_2._0
{
    class ClaseEmpleado
    {
        private String dni;
        private String nombre;
        private String password;
        private int nivel;
        private float ventas;

        public ClaseEmpleado()
        {
        }

        public ClaseEmpleado(string dni, string nombre, string password, int nivel, float ventas)
        {
            this.Dni = dni;
            this.Nombre = nombre;
            this.Password = password;
            this.Nivel = nivel;
            this.Ventas = ventas;
        }

        public string Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Password { get => password; set => password = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public float Ventas { get => ventas; set => ventas = value; }
    }
}
