﻿using System;

namespace ConsejeriaQR
{
    internal class articulos
    {
        private int id;
        private string nombre;
        private string descripcion;
        private string codigo;
        private string claveQR;
        private byte[] imagenQR;
        private byte[] imagen;
        private bool activo;

        public articulos()
        {
        }

        public articulos(int id, string nombre, string descripcion, string codigo, string claveQR, byte[] imagenQR, byte[] imagen, bool activo)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.codigo = codigo;
            this.claveQR = claveQR;
            this.imagenQR = imagenQR;
            this.imagen = imagen;
            this.activo = activo;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string ClaveQR { get => claveQR; set => claveQR = value; }
        public byte[] ImagenQR { get => imagenQR; set => imagenQR = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
        public bool Activo { get => activo; set => activo = value; }
    }
}
