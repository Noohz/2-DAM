using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ExamenRec
{
    internal class ConectarBD
    {
        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader datos;
        List<ClaseAlumno> listaAlumnos = new List<ClaseAlumno>();

        public ConectarBD()
        {
            conexion = new MySqlConnection
            {
                ConnectionString = "Server=localhost;Database=rayuela;Uid=root;pwd=''"
            };
        }

        internal bool aniadirFalta(string idAlumno, DateTime fechaActual, string modulo)
        {
            conexion.Open();
            String CadenaSql = "insert into faltasasistencia values (?id, ?fechAct, ?mod)";
            comando = new MySqlCommand(CadenaSql, conexion);

            comando.Parameters.AddWithValue("?id", idAlumno);
            comando.Parameters.AddWithValue("?fechAct", fechaActual);
            comando.Parameters.AddWithValue("?mod", modulo);

            comando.ExecuteNonQuery();
            conexion.Close();

            return true;
        }

        internal bool aniadirNota(string idAlumno, string modulo, int puntos)
        {
            conexion.Open();

            String CadenaSql = "insert into calificaciones values (?id, ?mod, ?punt)";
            comando = new MySqlCommand(CadenaSql, conexion);

            comando.Parameters.AddWithValue("?id", idAlumno);
            comando.Parameters.AddWithValue("?mod", modulo);
            comando.Parameters.AddWithValue("?punt", puntos);

            comando.ExecuteNonQuery();

            conexion.Close();

            return true;
        }

        internal ClaseAlumno buscarUsuario(ClaseAlumno alumnoSeleccionado)
        {
            ClaseAlumno cA = new ClaseAlumno();
            String cadenaSql = "select * from alumnos where Nombre=?nomb";
            
            conexion.Open();
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.Add("?nomb", MySqlDbType.String).Value = alumnoSeleccionado;

            MySqlDataReader datos = comando.ExecuteReader();

            if (datos.Read())
            {
                cA.Identificador = datos["identificador"].ToString();
                cA.Nombre = datos["nombre"].ToString();
                cA.Mail = datos["mail"].ToString();
                cA.Ciclo = datos["ciclo"].ToString();
                cA.Curso = (Int16) datos["curso"];
                cA.Foto = (byte[])datos["foto"];
            }

            conexion.Close();
            return cA;
        }

        internal List<ClaseAlumno> listar()
        {
            conexion.Open();

            String cadenaSql = "select * from alumnos where activo=1";
            comando = new MySqlCommand(cadenaSql, conexion);
            datos = comando.ExecuteReader();
            
            while (datos.Read())
            {
                ClaseAlumno cA = new ClaseAlumno
                {
                    Identificador = Convert.ToString(datos["Identificador"]),
                    Nombre = Convert.ToString(datos["Nombre"]),
                    Mail = Convert.ToString(datos["mail"]),
                    Ciclo = Convert.ToString(datos["Ciclo"]),
                    Curso = Convert.ToInt16(datos["Curso"]),
                    Foto = (byte[])datos["Foto"]
                };
                listaAlumnos.Add(cA);
            }

            conexion.Close();
            return listaAlumnos;
        }
    }
}
