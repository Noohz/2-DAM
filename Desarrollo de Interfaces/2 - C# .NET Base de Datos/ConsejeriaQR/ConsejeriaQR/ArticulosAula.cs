namespace ConsejeriaQR
{
    /// <summary>
    /// Clase relacionada con la tabla ArticulosAula de la BBDD
    /// </summary>
    public class ArticulosAula
    {
        private int id;
        private string aula;
        private string tipoArticulo;
        private int cantidad;
        private string modelo;
        private string caracteristicas;
        private string estado;
        private string codigoQR;
        private byte[] imagenQR;

        public ArticulosAula()
        {
        }

        public ArticulosAula(int id, string aula, string tipoArticulo, int cantidad, string modelo, string caracteristicas, string estado, string codigoQR, byte[] imagenQR)
        {
            this.id = id;
            this.aula = aula;
            this.tipoArticulo = tipoArticulo;
            this.cantidad = cantidad;
            this.modelo = modelo;
            this.caracteristicas = caracteristicas;
            this.estado = estado;
            this.codigoQR = codigoQR;
            this.imagenQR = imagenQR;
        }

        public int Id { get => id; set => id = value; }
        public string Aula { get => aula; set => aula = value; }
        public string TipoArticulo { get => tipoArticulo; set => tipoArticulo = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Caracteristicas { get => caracteristicas; set => caracteristicas = value; }
        public string Estado { get => estado; set => estado = value; }
        public string CodigoQR { get => codigoQR; set => codigoQR = value; }
        public byte[] ImagenQR { get => imagenQR; set => imagenQR = value; }
    }
}
