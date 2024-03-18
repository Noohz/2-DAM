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
                cA.Nombre1 = Convert.ToString(datos["Nombre"]);
                cA.Mail1 = Convert.ToString(datos["Mail"]);
                cA.Ciclo1 = Convert.ToString(datos["Ciclo"]);
                cA.Curso1 = Convert.ToInt16(datos["Curso"]);
                cA.Foto1 = Convert.ToString(datos["Foto"]);

                listaAlumno.Add(cA);

            }

            conexion.Close();
            return listaAlumno;
        }

        // Método para obtener las faltas de asistencia de un alumno en concreto.
        public List<Faltasasistencia> listarFaltas(String idAlumno)
        {
            conexion.Open();

            String cadenaSql = "select * from faltasasistencia where IdentificadorAlumno = ?idAl"; // El parámetro ?idAl se refiere al parámetro que se le pasa al método.
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?idAl", idAlumno);
            //comando.Parameters.Add("?idAl", MySqlDbType.VarChar).Value = idAlumno;

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                Faltasasistencia fA = new Faltasasistencia();
                fA.Indice1 = Convert.ToInt16(datos["Indice"]);
                fA.IdentificadorAlumno1 = Convert.ToString(datos["IdentificadorAlumnos"]);
                fA.Fecha1 = Convert.ToString(datos["Fecha"]);
                fA.Modulo1 = Convert.ToString(datos["Modulo"]);

                listaFaltas.Add(fA);

            }

            conexion.Close();
            return listaFaltas;
        }

        // Método para obtener las calificaciones de un alumno.
        public List<Calificaciones> listarCalificaciones(String idAlumno)
        {
            conexion.Open();

            String cadenaSql = "select * from calificaciones where IdentificadorAlumno = ?idAl"; // El parámetro ?idAl se refiere al parámetro que se le pasa al método.
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?idAl", idAlumno);
            //comando.Parameters.Add("?idAl", MySqlDbType.VarChar).Value = idAlumno;

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                Calificaciones cAlif = new Calificaciones();
                cAlif.Indice1 = Convert.ToInt16(datos["Indice"]);
                cAlif.IdentificadorAlumno1 = Convert.ToString(datos["IdentificadorAlumnos"]);
                cAlif.Modulo1 = Convert.ToString(datos["Modulo"]);
                cAlif.Puntos1 = Convert.ToInt16(datos["Puntos"]);

                listaCalificaciones.Add(cAlif);

            }

            conexion.Close();
            return listaCalificaciones;
        }

        public List<Modulos> listadoModulosXCursosXCiclos(String ciclo, int curso)
        {
            conexion.Open();

            String cadenaSql = "select * from modulos where ciclo = ?cic and curso = ?cur";
            comando = new MySqlCommand(cadenaSql, conexion);

            comando.Parameters.AddWithValue("?cic", ciclo);
            comando.Parameters.AddWithValue("?cur", curso);

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                Modulos mod = new Modulos();
                mod.IdModulo1 = Convert.ToString(datos["IdModulo"]);
                mod.Ciclo1 = Convert.ToString(datos["ciclo"]);
                mod.Curso1 = Convert.ToInt16(datos["curso"]);
                mod.NombreCompleto1 = Convert.ToString(datos["NombreCompleto"]);

                listaModulos.Add(mod);
            }

            conexion.Close();
            return listaModulos;
        }
    }
}
