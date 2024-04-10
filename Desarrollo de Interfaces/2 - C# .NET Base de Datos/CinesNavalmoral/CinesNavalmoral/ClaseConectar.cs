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
        List<ClaseCartelera> listaSesiones = new List<ClaseCartelera>();

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

        // Método para listar las sesiones que tiene la película a buscar.
        internal List<ClaseCartelera> cargarSesionesPelicula(string titulo)
        {
            List<ClaseCartelera> listaSesionsActuales = new List<ClaseCartelera>();

            conexion.Open();

            String cadenaSql = "select * from cartelera where titulo = ?tit";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?tit", titulo);

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                ClaseCartelera cc = new ClaseCartelera();
                cc.Sesion = (string)datos["sesion"];
                cc.Sala = (int)datos["sala"];

                listaSesiones.Add(cc);
            }

            for (int i = 0; i < listaSesiones.Count; i++)
            {               
                string fecha = listaSesiones[i].Sesion;

                if (DateTime.Parse(fecha) > DateTime.Now)
                {
                    listaSesionsActuales.Add(listaSesiones[i]);
                }
            }

            conexion.Close();

            return listaSesionsActuales;
        }
    }
}
