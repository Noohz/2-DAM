using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farmacia_version_2._0
{
    class ClaseTarjetaSanitaria
    {
       private String dni;
       private String nombre;
       private String email;
       private DateTime fechaNacimiento;
        private float totalCompras;

        public ClaseTarjetaSanitaria()
        {
        }

        public ClaseTarjetaSanitaria(string dni, string nombre, string email, DateTime fechaNacimiento, float totalCompras)
        {
            this.Dni = dni;
            this.Nombre = nombre;
            this.Email = email;
            this.FechaNacimiento = fechaNacimiento;
            this.TotalCompras = totalCompras;
        }

        public string Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Email { get => email; set => email = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public float TotalCompras { get => totalCompras; set => totalCompras = value; }
    }
}
