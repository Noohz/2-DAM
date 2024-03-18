using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Rayuela
{
    internal class Clase_Conectar
    {

        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader datos;

        List<Alumno> listaAlumno = new List<Alumno>();
        List<Cursos> listaCursos = new List<Cursos>();
        List<Modulos> listaModulos = new List<Modulos>();
        List<Calificaciones> listaCalificaciones = new List<Calificaciones>();
        List<Faltasasistencia> listaFaltas = new List<Faltasasistencia>();

        public Clase_Conectar()
        {
            conexion = new MySqlConnection();
            conexion.ConnectionString = "server=localhost;Database=rayuela;Uid=root;pwd='';old guids=true";
        }

        // Método para obtener los alumnos.
        public List<Alumno> listarAlumnos()
        {
            conexion.Open();

            String cadenaSql = "select * from alumnos where Activo = 1 order by nombre";
            comando = new MySqlCommand(cadenaSql, conexion); // Esto establece el comando SQL.

            datos = comando.ExecuteReader(); // Esto ejecuta el comando.

            while (datos.Read())
            {
                Alumno cA = new Alumno();
                cA.Identificador1 = Convert.ToString(datos["Identificador"]);
            }

            conexion.Close();
        }
    }
}
