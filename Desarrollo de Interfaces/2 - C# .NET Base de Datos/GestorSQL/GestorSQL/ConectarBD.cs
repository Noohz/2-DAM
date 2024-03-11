using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GestorSQL
{
    internal class ConectarBD
    {
        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader datos;

        public ConectarBD()
        {
            conexion = new MySqlConnection();
            conexion.ConnectionString = "server=localhost;database=dam2023;uid=root;pwd=''";
        }

        public ConectarBD(string server, string database, string usr, string pwd)
        {
            conexion = new MySqlConnection();
            conexion.ConnectionString = "server=" + server + ";Database=" + database + ";Uid=" + usr + ";pwd=" + pwd;
        }

        internal bool comprobarConexion()
        {
            try
            {
                conexion.Open();
                conexion.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        internal void ExecuteNonQuery(string consultaSql)
        {
            conexion.Open();

            comando = new MySqlCommand(consultaSql, conexion);
            comando.ExecuteNonQuery();

            conexion.Close();
        }

        internal string ExecuteReader(string consultaSql)
        {
            conexion.Open();
            StringBuilder resultado = new StringBuilder();

            comando = new MySqlCommand(consultaSql, conexion);
            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                for (int i = 0; i < datos.FieldCount; i++)
                {
                    resultado.Append(datos[i].ToString());
                    if (i < datos.FieldCount - 1)
                    {
                        resultado.Append("; ");
                    }
                }
                resultado.AppendLine();
            }

            conexion.Close();

            return resultado.ToString();
        }

        internal void ImportarBD(string nombreFichero)
        {
            comando = new MySqlCommand();

            using (MySqlBackup mb = new MySqlBackup(comando))
            {
                try
                {
                    comando.Connection = conexion;
                    conexion.Open();

                    mb.ImportFromFile(nombreFichero);

                    conexion.Close();
                }
                catch (MySqlException ex)
                {
                    //MessageBox.Show("Ha ocurrido un error a la hora de importar la BD: " + ex.Message, "Error de Importación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        internal void ExportarDB(string nombreFichero)
        {
            comando = new MySqlCommand();

            using (MySqlBackup mb = new MySqlBackup(comando))
            {
                comando.Connection = conexion;
                conexion.Open();
                mb.ExportInfo.AddCreateDatabase = true;
                mb.ExportToFile(nombreFichero);

                conexion.Close();
            }
        }

        internal void crearBD(string nombreBDCrear)
        {
            string consultaSql = "create database " + nombreBDCrear;

            try
            {
                conexion.Open();
                comando = new MySqlCommand(consultaSql, conexion);

                comando.ExecuteNonQuery();


            } catch (MySqlException ex)
            {
                MessageBox.Show("Error al crear la base de datos " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexion.Close();
        }

        internal List<string> listarBD()
        {
            List<string> listaNombreTablas = new List<string>();
            String cadenaSql = "show databases";

            conexion.Open();
            comando = new MySqlCommand(cadenaSql, conexion);
            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                listaNombreTablas.Add((String)(datos[0]));
            }

            conexion.Close();
            return listaNombreTablas;
        }

        internal List<string> listarTablas()
        {
            List<string> listaNombreTablas = new List<string>();
            string cadenaSql = "show tables";

            conexion.Open();
            comando = new MySqlCommand(cadenaSql, conexion);
            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                listaNombreTablas.Add(datos[0].ToString());
            }

            conexion.Close();
            return listaNombreTablas;
        }



        /*internal List<String> CargarCabeceraTabla(string nombreTabla)
        {
            List<string> listaCampos = new List<string>();
            String cadenaSql = "select * from " + nombreTabla;

            conexion.Open();
            comando = new MySqlCommand(cadenaSql, conexion);
            datos = comando.ExecuteReader();

            while (datos.Read())
            {

            }



            return listaCampos;
        }*/
    }
}
