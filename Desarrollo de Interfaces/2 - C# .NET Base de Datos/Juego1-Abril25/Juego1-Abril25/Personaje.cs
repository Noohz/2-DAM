namespace Juego1_Abril25
{
    internal class Personaje
    {
        private int id;
        private string nombre;
        private byte[] imagen;

        public Personaje()
        {

        }

        public Personaje(int id, string nombre, byte[] imagen)
        {
            this.id = id;
            this.nombre = nombre;
            this.imagen = imagen;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
    }
}
