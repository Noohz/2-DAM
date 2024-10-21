namespace ConsejeriaQR
{
    internal class articulos
    {
        private int id;
        private string nombre;
        private string descripcion;
        private string codigo;
        private byte[] imagenQR;
        private byte[] imagen;

        public articulos()
        {
        }

        public articulos(int id, string nombre, string descripcion, string codigo, byte[] imagenQR, byte[] imagen)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.codigo = codigo;
            this.imagenQR = imagenQR;
            this.imagen = imagen;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public byte[] ImagenQR { get => imagenQR; set => imagenQR = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
    }
}
