﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Aerolineas
{
    internal class ClaseConectar
    {
        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader datos;

        List<Usuariosavion> listaUsuario = new List<Usuariosavion>();
        List<Horariosaviones> listaHorarios = new List<Horariosaviones>();

        public ClaseConectar()
        {
            conexion = new MySqlConnection();
            conexion.ConnectionString = "server=localhost;Database=aerolineas2;Uid=root;pwd='';old guids=true";
        }

        // Método para comprobar si el usuario que introduce el cliente existe en la BD.
        internal List<Usuariosavion> iniciarSesion(string usuario, string contraseniaCifrada)
        {
            conexion.Open();

            string cadenaSql = "SELECT * FROM usuariosavion WHERE nombre = ?usuario AND clave = ?contrasenia";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?usuario", usuario);
            comando.Parameters.AddWithValue("?contrasenia", contraseniaCifrada);

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                Usuariosavion uS = new Usuariosavion();
                uS.Nombre = (string)datos["nombre"];
                uS.Mail = (string)datos["correo"];
                uS.Clave = (string)datos["clave"];

                listaUsuario.Add(uS);
            }

            conexion.Close();

            return listaUsuario;
        }

        // Método para almacenar en una lista los datos de la tabla horariosaviones.
        internal List<Horariosaviones> obtenerSesionAviones()
        {
            conexion.Open();

            string cadenaSql = "SELECT * FROM horariosaviones";
            comando = new MySqlCommand(cadenaSql, conexion);

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                Horariosaviones hS = new Horariosaviones();
                hS.IdVuelo = (int)datos["idVuelo"];
                hS.Ruta = (string)datos["ruta"];
                hS.FechaSalida = (DateTime)datos["fechaSalida"];
                hS.PrecioBussines = (int)datos["precioBussines"];
                hS.PrecioPrimera = (int)datos["precioPrimera"];
                hS.PrecioTurista = (int)datos["precioTurista"];
                hS.IdAvion = (string)datos["idAvion"];

                listaHorarios.Add(hS);
            }

            conexion.Close();

            return listaHorarios;
        }

        // Método para registrar un nuevo usuario.
        internal int registrarUsuario(string usuario, string email, string contraseniaCifrada)
        {
            conexion.Open();

            string cadenaSql = "INSERT INTO usuariosavion VALUES(?usuario, ?email, ?contrasenia)";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?usuario", usuario);
            comando.Parameters.AddWithValue("?email", email);
            comando.Parameters.AddWithValue("?contrasenia", contraseniaCifrada);

            int codigo = comando.ExecuteNonQuery();

            conexion.Close();

            return codigo;
        }
    }
}