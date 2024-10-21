using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace ConsejeriaQR
{
    public class ClaseConectar
    {
        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader datos;

        List<usuarios> listaUsuario = new List<usuarios>();

        String CADENA_CONEXION = "server=localhost;Database=conserjeriaqr;Uid=root;pwd='';old guids=true";

        // Método que utiliza la contraseña que introduce el usuario y la encripta utilizando PBKDF2. Si esta coincide con la contraseña encriptada de la BD podrá iniciar sesión.
        internal bool iniciarSesion(string correo, string contrasenia)
        {
            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();

                string cadenaSql = "SELECT Salt, Hash FROM usuarios WHERE correo = @correo";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@correo", correo);
                    using (datos = comando.ExecuteReader())
                    {
                        if (datos.Read())
                        {
                            string saltBase64 = datos["Salt"].ToString();
                            string hashBase64 = datos["Hash"].ToString();

                            byte[] salt = Convert.FromBase64String(saltBase64);

                            byte[] hashedPassword = HashPassword(contrasenia, salt);

                            if (hashBase64 == Convert.ToBase64String(hashedPassword))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        // Método que encripta la contraseña que recibe utilizando PBKDF2. Después ejecuta el insert para almacenarlo en la base de datos. Si "codigo" devuelve 1 es que la operación se ha completado.
        internal int registrarProfesor(string nombreUsuario, string correoUsuario, string contraseniaUsuario)
        {
            int codigo;

            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();

                byte[] salt = GenerateSalt();
                byte[] hashedPassword = HashPassword(contraseniaUsuario, salt);

                string saltBase64 = Convert.ToBase64String(salt);
                string hashedBase64 = Convert.ToBase64String(hashedPassword);

                string cadenaSql = "INSERT INTO usuarios VALUES (0, @nombre, @correo, @Salt, @Hash)";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombreUsuario);
                    comando.Parameters.AddWithValue("@correo", correoUsuario);
                    comando.Parameters.AddWithValue("@Salt", saltBase64);
                    comando.Parameters.AddWithValue("@Hash", hashedBase64);

                    codigo = comando.ExecuteNonQuery();
                }
            }
            return codigo;
        }

        // Método que devuelve una lista con los datos del usuario que ha iniciado sesión.
        internal List<usuarios> obtenerDatosUsuario(string correo)
        {
            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();

                string cadenaSql = "SELECT * FROM usuarios WHERE correo = @correo";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@correo", correo);

                    using (datos = comando.ExecuteReader())
                    {
                        while (datos.Read())
                        {
                            usuarios usr = new usuarios();
                            usr.Id = (int)datos["id"];
                            usr.Nombre = (string)datos["nombre"];
                            usr.Correo = (string)datos["correo"];
                            usr.Salt = (string)datos["Salt"];
                            usr.Hash = (string)datos["Hash"];

                            listaUsuario.Add(usr);
                        }
                    }
                }
            }
            return listaUsuario;
        }

        // Método para comprobar si el QR que se le pasa por parámetro ya existe en la BD.
        internal bool comprobarQRExistente(string claveQR)
        {
            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();

                string cadenaSql = "SELECT * FROM articulos WHERE claveQR = ?claveQR";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@claveQR", claveQR);

                    using (datos = comando.ExecuteReader())
                    {
                        if (datos.Read())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        // Método que se encarga de insertar el artículo según los datos que recibe por los parámetros.
        internal int insertarArticulo(string nombreArticulo, string descripcionArticulo, string codigoArticulo, string claveQR, byte[] imagenQR, byte[] imagenArticulo)
        {
            int codigo;

            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();                                

                string cadenaSql = "INSERT INTO articulos VALUES (0, @nombre, @descripcion, @codigo, @claveQR, @imagenQR, @imagen, true)";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombreArticulo);
                    comando.Parameters.AddWithValue("@descripcion", descripcionArticulo);
                    comando.Parameters.AddWithValue("@codigo", codigoArticulo);
                    comando.Parameters.AddWithValue("@claveQR", claveQR);
                    comando.Parameters.AddWithValue("@imagenQR", imagenQR);
                    comando.Parameters.AddWithValue("@imagen", imagenArticulo);

                    codigo = comando.ExecuteNonQuery();
                }
            }
            return codigo;
        }

        // Métodos para encriptar la contraseña...
        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private static byte[] HashPassword(string contrasenia, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(contrasenia, salt, 10000, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(32);
            }
        }        
    }
}
