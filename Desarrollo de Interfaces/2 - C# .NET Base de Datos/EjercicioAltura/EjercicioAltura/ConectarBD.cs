using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace EjercicioAltura
{
    internal class ConectarBD
    {

        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader datos;
        List<ClaseAltura> datosAltura = new List<ClaseAltura>();

        public ConectarBD()
        {
            conexion = new MySqlConnection { ConnectionString = "server=localhost; Database=dam2024; user=root; pwd=''" };

        }

        public List<ClaseAltura> DatosAltura()
        {

            conexion.Open();

            String cadenaSql = "select * from alturas";
            comando = new MySqlCommand(cadenaSql, conexion);
            datos = comando.ExecuteReader();


            while (datos.Read())
            {
                ClaseAltura cA = new ClaseAltura();

                cA.Provincia = Convert.ToString(datos["Provincia"]);
                cA.SituacionAltMax = Convert.ToString(datos["SituacionAltMax"]);
                cA.AlturaMaxima = Convert.ToInt16(datos["AlturaMaxima"]);
                cA.SituacionAltMin = Convert.ToString(datos["SituacionAltMin"]);
                cA.AlturaMinima = Convert.ToInt16(datos["AlturaMinima"]);

                datosAltura.Add(cA);
            }

            conexion.Close();

            return datosAltura;
        }

        internal void insertarDatosAltura(String provincia, String situacionAltMax, int alturaMaxima, String situacionAltMin, int alturaMinima)
        {
            conexion.Open();

            String cadenaSql = "insert into alturas (Provincia, SituacionAltMax, AlturaMaxima, SituacionAltMin, AlturaMinima) values (?pro, ?sAmax, ?aMax, ?sAmin, ?aMin)";

            comando = new MySqlCommand(cadenaSql, conexion);

            comando.Parameters.AddWithValue("?pro", provincia);
            comando.Parameters.AddWithValue("?sAmax", situacionAltMax);
            comando.Parameters.AddWithValue("?aMax", alturaMaxima);
            comando.Parameters.AddWithValue("?sAmin", situacionAltMin);
            comando.Parameters.AddWithValue("?aMin", alturaMinima);

            comando.ExecuteNonQuery();
            conexion.Close();
        }

    }
}
