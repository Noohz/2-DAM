using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Examen6Octubre
{
    internal class ClaseConectar
    {

        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader datos;

        List<ClaseFruta> listaFrutas = new List<ClaseFruta>();

        public ClaseConectar()
        {
            conexion = new MySqlConnection { ConnectionString = "server=db4free.net; database=dam2020; user=camachin2020; pwd=pruden2020; OldGuids=True;" };
        }

        public List<ClaseFruta> listarFrutas()
        {
            conexion.Open();

            String cadenaSql = "select * from frutas";
            comando = new MySqlCommand(cadenaSql, conexion);
            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                ClaseFruta f = new ClaseFruta();
                f.Id = Convert.ToInt16(datos["id"]);
                f.Nombre = Convert.ToString(datos["nombre"]);
                f.Precio = (float)(datos["precio"]);
                f.Imagen = (byte[])(datos["imagen"]);
                f.Procedencia = Convert.ToString(datos["procedencia"]);
                f.Stock = Convert.ToInt16(datos["stock"]);

                listaFrutas.Add(f);

            }

            conexion.Close();

            return listaFrutas;
        }

    }
}
