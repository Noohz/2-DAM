using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego1_Abril25
{
    internal class ConectarBD
    {
        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader datos;

        List<Personaje> imagenesBuscadas = new List<Personaje>();
        List<Personaje> imagenManzana = new List<Personaje>();

        public ConectarBD()
        {
            conexion = new MySqlConnection();
            conexion.ConnectionString = "server=localhost;Database=freedbtech_dam2020;Uid=root;pwd='';old guids=true";
        }

        internal List<Personaje> cargarImagenes()
        {
            conexion.Open();

            String cadenaSql = "SELECT * FROM simpson";
            comando = new MySqlCommand(cadenaSql, conexion);

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                Personaje p = new Personaje();
                p.Id = (int)datos["id"];
                p.Nombre = (string)datos["nombre"];
                p.Imagen = (byte[])datos["imagen"];

                imagenesBuscadas.Add(p);
            }

            conexion.Close();

            return imagenesBuscadas;
        }

        internal List<Personaje> obtenerImgManzana()
        {
            conexion.Open();

            string nombre = "Manzana";

            String cadenaSql = "SELECT * FROM simpson WHERE nombre = ?nomb";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?nomb", nombre);

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                Personaje p = new Personaje();
                p.Id = (int)datos["id"];
                p.Nombre = (string)datos["nombre"];
                p.Imagen = (byte[])datos["imagen"];

                imagenManzana.Add(p);
            }

            conexion.Close();

            return imagenManzana;
        }
    }
}
