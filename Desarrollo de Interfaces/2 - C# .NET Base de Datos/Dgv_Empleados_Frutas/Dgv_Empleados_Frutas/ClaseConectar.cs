using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Dgv_Empleados_Frutas
{
    internal class ClaseConectar
    {

        List<ClaseEmpleados> listaEmpleados = new List<ClaseEmpleados>();
        List<ClaseFrutas> listaFrutas = new List<ClaseFrutas>();

        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader datos;

        public ClaseConectar()
        {
            conexion = new MySqlConnection { ConnectionString = "server=localhost; Database=dam2023; user=root; pwd=''" };
        }

        public List<ClaseEmpleados> listarEmpleados()
        {
            conexion.Open();

            String cadenaSql = "select * from empleados";
            comando = new MySqlCommand(cadenaSql, conexion);
            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                ClaseEmpleados emp = new ClaseEmpleados();
                emp.Dni = Convert.ToString(datos["dni"]);
                emp.Pwd = Convert.ToString(datos["password"]);
                emp.Nivel = Convert.ToInt16(datos["nivel"]);
                emp.Imagen = Convert.ToString(datos["imagen"]);

                listaEmpleados.Add(emp);

            }

            conexion.Close();

            return listaEmpleados;
        }


        public List<ClaseFrutas> listarFrutas()
        {

            conexion.Open();

            String cadenaSql = "select * from frutas where activo = 1";
            comando = new MySqlCommand(cadenaSql, conexion);
            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                ClaseFrutas f = new ClaseFrutas();
                f.Id = Convert.ToInt16(datos["id"]);
                f.Nombre = Convert.ToString(datos["nombre"]);
                f.Precio = Convert.ToDouble(datos["precio"]);
                f.Imagen = (byte[])(datos["imagen"]);
                f.Activo = Convert.ToInt16(datos["activo"]);

                listaFrutas.Add(f);

            }

            conexion.Close();

            return listaFrutas;
        }

        internal void insertarFruta(string name, double precio, byte[] imagen)
        {
            conexion.Open();

            String consulta = "INSERT INTO frutas VALUES (null, ?nom, ?pre, ?img)";
            comando = new MySqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("?nom", name);
            comando.Parameters.AddWithValue("?pre", precio);
            comando.Parameters.AddWithValue("?img", imagen);

            comando.ExecuteNonQuery();
            conexion.Close();
        }

        internal void poner()
        {
            conexion.Open();

            comando = new MySqlCommand("update frutas SET activo = 1", conexion);
            comando.ExecuteNonQuery();

            conexion.Close();
        }

        internal string quitarFruta(int id)
        {
            string con = "";

            try
            {
                conexion.Open();

                String consulta = "update frutas SET activo = 0 WHERE id = @id";
                comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("id", id);
                comando.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                con = e.Message;
            }
            conexion.Close();
            return con;
        }
    }
}
