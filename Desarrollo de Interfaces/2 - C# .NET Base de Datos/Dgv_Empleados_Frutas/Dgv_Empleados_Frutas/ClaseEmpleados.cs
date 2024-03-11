using System;

namespace Dgv_Empleados_Frutas
{
    internal class ClaseEmpleados
    {

        String dni;
        String pwd;
        int nivel;
        String imagen;

        public ClaseEmpleados()
        {
        }

        public ClaseEmpleados(string dni, string pwd, int nivel, string imagen)
        {
            this.Dni = dni;
            this.Pwd = pwd;
            this.Nivel = nivel;
            this.Imagen = imagen;
        }

        public string Dni { get => dni; set => dni = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public string Imagen { get => imagen; set => imagen = value; }
    }
}
