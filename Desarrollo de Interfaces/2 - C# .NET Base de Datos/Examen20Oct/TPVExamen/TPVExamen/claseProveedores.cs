namespace TPVExamen
{
    internal class claseProveedores
    {
        string cifProveedor;
        string nombre;
        string mail;
        string especialidad;

        public claseProveedores()
        {
        }

        public claseProveedores(string cifProveedor, string nombre, string mail, string especialidad)
        {
            this.CifProveedor = cifProveedor;
            this.Nombre = nombre;
            this.Mail = mail;
            this.Especialidad = especialidad;
        }

        public string CifProveedor { get => cifProveedor; set => cifProveedor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }
    }
}
