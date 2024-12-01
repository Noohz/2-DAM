namespace ConsejeriaQR
{
    /// <summary>
    /// Clase relacionada con la tabla Usuarios de la BBDD
    /// </summary>
    public class Usuarios
    {
        private int id;
        private string nombre;
        private string departamento;
        private string salt;
        private string hash;

        public Usuarios()
        {
        }

        public Usuarios(int id, string nombre, string departamento, string salt, string hash)
        {
            this.id = id;
            this.nombre = nombre;
            this.departamento = departamento;
            this.salt = salt;
            this.hash = hash;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Departamento { get => departamento; set => departamento = value; }
        public string Salt { get => salt; set => salt = value; }
        public string Hash { get => hash; set => hash = value; }
    }
}
