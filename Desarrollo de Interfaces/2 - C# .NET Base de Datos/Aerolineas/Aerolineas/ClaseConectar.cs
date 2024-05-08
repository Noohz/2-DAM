using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Aerolineas
{
    internal class ClaseConectar
    {
        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader datos;

        List<Usuariosavion> listaUsuario = new List<Usuariosavion>();
        List<Horariosaviones> listaHorarios = new List<Horariosaviones>();
        List<ModeloAvion> butacasAvion = new List<ModeloAvion>();
        List<Billeteavion> listaFacturacion = new List<Billeteavion>();
        List<ModeloAvion> listaIdAviones = new List<ModeloAvion>();


        public ClaseConectar()
        {
            conexion = new MySqlConnection();
            conexion.ConnectionString = "server=localhost;Database=aerolineas2;Uid=root;pwd='';old guids=true";
        }

        // Método para crear un nuevo modelo del avión en la base de datos.
        internal int crearModeloAvion(string idAvion, string modelo, int asientosBussines, int asientosPrimera, int asientosTurista)
        {
            conexion.Open();

            string cadenaSql = "INSERT INTO modeloavion VALUES(?idAvion, ?modelo, ?asientosBussines, ?asientosPrimera, ?asientosTurista)";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?idAvion", idAvion);
            comando.Parameters.AddWithValue("?modelo", modelo);
            comando.Parameters.AddWithValue("?asientosBussines", asientosBussines);
            comando.Parameters.AddWithValue("?asientosPrimera", asientosPrimera);
            comando.Parameters.AddWithValue("?asientosTurista", asientosTurista);

            int codigo = comando.ExecuteNonQuery();

            conexion.Close();

            return codigo;
        }

        internal int crearNuevaRuta(int selectedIndex, string ruta, string fechaSalida, int precioBussines, int precioPrimera, int precioTurista)
        {
            conexion.Open();

            string cadenaSql = "";

            conexion.Close();

            return codigo;
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
                if (datos["correo"] != DBNull.Value)
                {
                    uS.Mail = (string)datos["correo"];
                }
                uS.Clave = (string)datos["clave"];

                listaUsuario.Add(uS);
            }

            conexion.Close();

            return listaUsuario;
        }

        // Metodo para insertar la compra del usuario en la tabla billeteavion.
        internal int insertarFacturacion(int idVuelo, string idAsiento, string usuarioActivo, DateTime fechaActual, string precioTotal)
        {
            conexion.Open();

            string cadenaSql = "INSERT INTO billeteavion VALUES(?idVuelo, ?idAsiento, ?usuario, ?fecha, ?precioTotal, 0)";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?idVuelo", idVuelo);
            comando.Parameters.AddWithValue("?idAsiento", idAsiento);
            comando.Parameters.AddWithValue("?usuario", usuarioActivo);
            comando.Parameters.AddWithValue("?fecha", fechaActual);
            comando.Parameters.AddWithValue("?precioTotal", precioTotal);

            int codigo = comando.ExecuteNonQuery();

            conexion.Close();

            return codigo;
        }

        // Método para modificar la clave del usuario en la BD.
        internal int modificarContrasenia(string nombre, string contraseniaCifrada)
        {
            conexion.Open();

            string cadenaSql = "UPDATE usuariosavion SET clave = ?contraseniaCifrada WHERE nombre = ?nombre ";
            comando = new MySqlCommand (cadenaSql, conexion);
            comando.Parameters.AddWithValue("?contraseniaCifrada", contraseniaCifrada);
            comando.Parameters.AddWithValue("?nombre", nombre);

            int codigo = comando.ExecuteNonQuery();

            conexion.Close();

            return codigo;
        }

        // Método para modificar la dirección de correo del usuario en la BD.
        internal int modificarCorreo(string nombre, string newEmail)
        {
            conexion.Open();

            string cadenaSql = "UPDATE usuariosavion SET correo = ?newEmail WHERE nombre = ?nombre";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?newEmail", newEmail);
            comando.Parameters.AddWithValue("?nombre", nombre);

            int codigo = comando.ExecuteNonQuery();

            conexion.Close();

            return codigo;
        }

        // Método para obtener el número de butacas de cada tipo que tiene el avión.
        internal List<ModeloAvion> obtenerButacasAvion(string idAvion)
        {
            conexion.Open();

            string cadenaSql = "SELECT * FROM modeloavion WHERE idAvion = ?idAvion";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?idAvion", idAvion);

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                ModeloAvion mV = new ModeloAvion();
                mV.IdAvion = (string)datos["idAvion"];
                mV.Modelo = (string)datos["Modelo"];
                mV.FBussines = (int)datos["FBussines"];
                mV.FPrimera = (int)datos["FPrimera"];
                mV.FTurista = (int)datos["FTurista"];

                butacasAvion.Add(mV);
            }

            conexion.Close();

            return butacasAvion;
        }

        // Método para obtener´las butacas ocupadas
        internal List<Billeteavion> obtenerButacasOcupadas(int idVuelo)
        {
            conexion.Open();

            string cadenaSql = "SELECT * FROM billeteavion WHERE idVuelo = ?idVuelo";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?idVuelo", idVuelo);

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                Billeteavion bV = new Billeteavion();
                bV.IdVuelo = (int)datos["idVuelo"];
                bV.IdAsiento = (string)datos["idAsiento"];
                bV.Comprador = (string)datos["comprador"];
                bV.FechaReserva = (DateTime)datos["fechaReserva"];
                bV.PrecioFinalBillete = (int)datos["precioFinalBillete"];
                bV.Ocupado = (bool)datos["ocupado"];

                listaFacturacion.Add(bV);
            }

            conexion.Close();

            return listaFacturacion;
        }

        // Método para obtener los ids de los aviones para usarlo en el comboBox de administración Crear Nueva Ruta.
        internal List<ModeloAvion> obtenerIdsAviones()
        {
            conexion.Open();

            string cadenaSql = "SELECT idAvion FROM modeloavion";
            comando = new MySqlCommand(@cadenaSql, conexion);

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                ModeloAvion mV = new ModeloAvion();
                mV.IdAvion = (string)datos["idAvion"];
                listaIdAviones.Add(mV);
            }

            conexion.Close();

            return listaIdAviones;
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
