using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace CrudMedicamento
{
    internal class ConectarBD
    {
        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader datos;
        List<ClaseMedicamento> listaMedicamentos = new List<ClaseMedicamento>();

        public ConectarBD()
        {
            conexion = new MySqlConnection();
            conexion.ConnectionString = "server=db4free.net; Database=dam2024; user=vituki; pwd=pilukina2024"; // Para conectarte de forma remota.
            // conexion.ConnectionString = "server=localhost; Database=dam2023; user=root; pwd=""; Para hacerlo de forma local.
        }

        public List<ClaseMedicamento> listarMedicamentos()
        {
            conexion.Open();

            String cadenaSql = "select * from medicamento where activo = 1";
            comando = new MySqlCommand(cadenaSql, conexion);
            datos = comando.ExecuteReader();

            while (datos.Read()) // Voy leyendo el array 
            {
                ClaseMedicamento m = new ClaseMedicamento();
                m.Indice = Convert.ToInt16(datos["indice"]);
                m.Nombre = Convert.ToString(datos["nombre"]);
                m.Precio = Convert.ToDouble(datos["precio"]);
                m.Imagen = (byte[])datos["imagen"];
                m.StockActual = Convert.ToInt16(datos["stockactual"]);
                m.StockMinimo = Convert.ToInt16(datos["stockminimo"]);
                m.Activo = Convert.ToInt16(datos["activo"]);
                listaMedicamentos.Add(m);
            }

            conexion.Close();

            return listaMedicamentos;
        }

        internal void InsertarMedicamento(string nombre, double precio, short stockActual, short stockMinimo, byte[] bloque)
        {
            conexion.Open();

            String cadenaSql = "insert into medicamento values (null, ?nom, ?pre, ?img, ?stA, ?stM, 1)";

            comando = new MySqlCommand(cadenaSql, conexion);

            comando.Parameters.Add("?nom", MySqlDbType.VarChar).Value = nombre;
            comando.Parameters.AddWithValue("?pre", precio);
            comando.Parameters.AddWithValue("?img", bloque);
            comando.Parameters.AddWithValue("?stA", stockActual);
            comando.Parameters.AddWithValue("?stM", stockMinimo);

            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
