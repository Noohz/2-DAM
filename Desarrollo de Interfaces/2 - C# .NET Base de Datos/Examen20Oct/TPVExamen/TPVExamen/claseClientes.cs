using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPVExamen
{
    internal class claseClientes
    {
        string dni;
        string nombre;
        string mail;
        int puntos;

        public claseClientes()
        {
        }

        public claseClientes(string dni, string nombre, string mail, int puntos)
        {
            this.Dni = dni;
            this.Nombre = nombre;
            this.Mail = mail;
            this.Puntos = puntos;
        }

        public string Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Mail { get => mail; set => mail = value; }
        public int Puntos { get => puntos; set => puntos = value; }
    }
}
