﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinesNavalmoral
{
    internal class ClaseConectar
    {
        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader datos;

        List<ClaseCartelera> listaCartelera = new List<ClaseCartelera>();
        List<ClaseCartelera> listaSesiones = new List<ClaseCartelera>();
        List<ClaseFacturacionCine> listaFacturacion = new List<ClaseFacturacionCine>();
        List<ClaseSalaCine> listaFilasColumnas = new List<ClaseSalaCine>();

        public ClaseConectar()
        {
            conexion = new MySqlConnection();
            conexion.ConnectionString = "server=localhost;Database=cinesa;Uid=root;pwd='';old guids=true";
        }

        // Método para obtener las carteleras usando DISTINCT para que no aparezcan repetidas.
        public List<ClaseCartelera> listarCarteles()
        {
            DateTime fecha = DateTime.Now;

            conexion.Open();

            String cadenaSql = "select distinct (titulo), cartel from cartelera where sesion > ?sesi";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?sesi", fecha);

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
            List<ClaseCartelera> listaSesionesActuales = new List<ClaseCartelera>();

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
                string fecha = listaSesiones[i].Sesion; // En fecha guardamos la sesión actual que se está recorriendo.

                if (DateTime.Parse(fecha) > DateTime.Now) // Si la conversión de la fecha a DateTime es mayor que la hora actual se le añade a la Lista de sesiones actuales.
                {
                    listaSesionesActuales.Add(listaSesiones[i]); // listaSesionesActuales almacena solo las sesiones que sean mayores a la hora justa a la que se ejecuta el programa.
                                                                 // Por lo que las sesiones antiguas no se mostrarán.
                }
            }

            conexion.Close();

            return listaSesionesActuales;
        }

        // Método para contar cuantas butacas hay.
        internal int[] TotalButacas(string sala)
        {
            int[] totalButacas = { 0, 0 };

            conexion.Open();

            String cadenaSql = "select * from salacine where idSala = ?sala";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?sala", Convert.ToInt16(sala));

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                int filas = (int)datos["filas"];
                int columnas = (int)datos["columnas"];

                totalButacas[0] = filas;
                totalButacas[1] = columnas;
            }

            conexion.Close();

            return totalButacas;
        }

        // Método para contar las butacas que están ocupadas.
        internal List<ClaseFacturacionCine> ButacasOcupadas(string sala, string sesion)
        {
            conexion.Open();

            String cadenaSql = "select * from facturacioncine where idSala = ?idSala and sesion = ?sesi";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?idSala", sala);
            comando.Parameters.AddWithValue("?sesi", sesion);

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                ClaseFacturacionCine cFC = new ClaseFacturacionCine();
                cFC.Id = (int)datos["id"];
                cFC.IdSala = (int)datos["idSala"];
                cFC.Fila = (int)datos["fila"];
                cFC.Columna = (int)datos["columna"];
                cFC.Sesion = (string)datos["sesion"];
                cFC.Ocupado = (int)datos["ocupado"];

                listaFacturacion.Add(cFC);
            }

            conexion.Close();

            return listaFacturacion;
        }

        internal int InsertarFacturacion(int idSala, int fila, int columna, string sesion)
        {
            conexion.Open();

            string cadenaSql = "insert into facturacioncine values (null, ?idSala, ?fila, ?columna, ?sesion, 0)";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?idSala", idSala);
            comando.Parameters.AddWithValue("?fila", fila);
            comando.Parameters.AddWithValue("?columna", columna);
            comando.Parameters.AddWithValue("?sesion", sesion);

            int codigo = comando.ExecuteNonQuery();

            conexion.Close();          

            return codigo;
        }

        internal void ocuparButaca()
        {
            String cadenaSql = "update facturacioncine set ocupado = 1 where ";
        }
    }
}