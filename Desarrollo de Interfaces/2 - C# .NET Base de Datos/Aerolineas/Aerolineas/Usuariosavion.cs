using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolineas
{
    public class Usuariosavion
    {
        private String nombre;
        private String mail;
        private String clave;

        public Usuariosavion()
        {
        }

        public Usuariosavion(string nombre, string mail, string clave)
        {
            this.nombre = nombre;
            this.mail = mail;
            this.clave = clave;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Clave { get => clave; set => clave = value; }
    }
}
