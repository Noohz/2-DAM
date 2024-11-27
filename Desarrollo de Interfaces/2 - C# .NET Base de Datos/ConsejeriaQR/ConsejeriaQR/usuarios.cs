namespace ConsejeriaQR
{
    /// <summary>
    /// Clase relacionada con la tabla Usuarios de la BBDD
    /// </summary>
    public class Usuarios
    {
        private int id;
        private string nombre;
        private string correo;
        private string salt;
        private string hash;

        public Usuarios()
        {
        }

        public Usuarios(int id, string nombre, string correo, string salt, string hash)
        {
            this.id = id;
            this.nombre = nombre;
            this.correo = correo;
            this.salt = salt;
            this.hash = hash;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Salt { get => salt; set => salt = value; }
        public string Hash { get => hash; set => hash = value; }
    }
}
