using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinesNavalmoral
{
    internal class ClaseConectar
    {
        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader datos;

        List<ClaseCartelera> listaCartelera = new List<ClaseCartelera>();

        public ClaseConectar()
        {
            conexion = new MySqlConnection();
            conexion.ConnectionString = "server=localhost;Database=cinesa;Uid=root;pwd='';old guids=true";
        }

        // Método para obtener las carteleras usando DISTINCT para que no aparezcan repetidas.
        public List<ClaseCartelera> listarCarteles()
        {
            conexion.Open();

            String cadenaSql = "select distinct (titulo), cartel from cartelera";
            comando = new MySqlCommand(cadenaSql, conexion);

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                ClaseCartelera cc = new ClaseCartelera();
                cc.Titulo = (string)datos["titulo"];
                cc.Cartel = (byte[])datos["cartel"];

                listaCartelera.Add(cc);
            }

            conexion.Close();

            return listaCartelera;
        }
    }
}
