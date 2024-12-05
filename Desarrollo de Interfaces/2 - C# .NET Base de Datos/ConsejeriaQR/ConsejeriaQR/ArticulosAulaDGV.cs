namespace ConsejeriaQR
{
    public class ArticulosAulaDGV
    {
        private int id;
        private string aula;
        private string tipoArticulo;
        private int cantidad;
        private string modelo;
        private string caracteristicas;
        private string estado;

        public ArticulosAulaDGV()
        {
        }

        public ArticulosAulaDGV(int id, string aula, string tipoArticulo, int cantidad, string modelo, string caracteristicas, string estado)
        {
            this.id = id;
            this.aula = aula;
            this.tipoArticulo = tipoArticulo;
            this.cantidad = cantidad;
            this.modelo = modelo;
            this.caracteristicas = caracteristicas;
            this.estado = estado;
        }

        public int Id { get => id; set => id = value; }
        public string Aula { get => aula; set => aula = value; }
        public string TipoArticulo { get => tipoArticulo; set => tipoArticulo = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Caracteristicas { get => caracteristicas; set => caracteristicas = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
