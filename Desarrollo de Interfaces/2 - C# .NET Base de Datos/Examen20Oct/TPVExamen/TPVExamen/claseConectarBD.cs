using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace TPVExamen
{
    class claseConectarBD
    {
        List<claseFrutas> listaFrutas = new List<claseFrutas>();
        List<claseClientes> listaClientes = new List<claseClientes>();

        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader datos;
        public static int nivelEmpleado;
        public static string nombEmpleado;

        public claseConectarBD()
        {
            conexion = new MySqlConnection();
            conexion.ConnectionString = "server=localhost;Database=frutasmoralas;Uid=root;pwd='';old guids=true";

        }

        public List<claseFrutas> listarFrutas()
        {
            conexion.Open();

            String cadenaSql = "select * from frutas2 where activo = 1";
            comando = new MySqlCommand(cadenaSql, conexion);
            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                claseFrutas f = new claseFrutas();
                f.Id = Convert.ToInt16(datos["id"]);
                f.Nombre = Convert.ToString(datos["nombre"]);
                f.Precio = (float)(datos["precio"]);
                f.Imagen = (byte[])(datos["imagen"]);
                f.Procedencia = Convert.ToString(datos["procedencia"]);
                f.Stock = Convert.ToDouble(datos["stock"]);
                f.Activo = Convert.ToInt16(datos["activo"]);

                listaFrutas.Add(f);

            }

            conexion.Close();

            return listaFrutas;
        }

        internal bool buscarUsuario(string dni, string contrasenia)
        {
            string contraseniaMD5 = CrearMD5(contrasenia);

            conexion.Open();

            try
            {
                string consultaSql = "select * from empleados where dni = ?dni and password = ?contrasenia";
                comando = new MySqlCommand(consultaSql, conexion);

                comando.Parameters.AddWithValue("?dni", dni);
                comando.Parameters.AddWithValue("?contrasenia", contraseniaMD5);

                datos = comando.ExecuteReader();

                if (datos.Read())
                {
                    nivelEmpleado = datos.GetInt32("nivel");
                    nombEmpleado = Convert.ToString(datos["dni"]);

                    return true;
                }

                return false;
            }
            finally
            {
                conexion.Close();
            }
        }

        public int nivelUsuario()
        {
            return nivelEmpleado;
        }

        public static string CrearMD5(string contrasenia)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(contrasenia);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // convertir el array de byte en un string hexadecimal
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    //x2 es un argumento, parámetro para decir que se formateaen hexadecimal
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().ToLower();
            }
        }

        internal void crearTienda(string nombre)
        {
            conexion.Open();

            string nombreTabla = "frutas" + nombre;

            string cadenaSql = "CREATE TABLE `" + nombreTabla + "` (`id` int(11) NOT NULL," +
                "`nombre` varchar(25) COLLATE latin1_spanish_ci NOT NULL," +
                "`precio` float NOT NULL," +
                "`imagen` mediumblob NOT NULL," +
                "`procedencia` varchar(100) COLLATE latin1_spanish_ci NOT NULL," +
                "`stock` int(11) NOT NULL," +
                "`activo` int(11) NOT NULL," +
                "`stockMinimo` int(11) NOT NULL) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;";

            comando = new MySqlCommand(cadenaSql, conexion);

            comando.ExecuteNonQuery();

            conexion.Close();
        }

        internal void cerrarTienda(string nombre)
        {
            conexion.Open();

            string nombreTabla = "frutas" + nombre;

            string cadenaSql = "Drop table " + nombreTabla;
            comando = new MySqlCommand(cadenaSql, conexion);

            comando.ExecuteNonQuery();

            conexion.Close();
        }

        internal void insertarFruta(int id, string nombre, string precio, byte[] imagen, string procedencia, string stock, string stockMinimo, string nombreInsertar)
        {
            conexion.Open();

            string nombreTablaInsertar = "frutas" + nombreInsertar;

            String cadenaSql = "insert into " + nombreTablaInsertar + " (id, nombre, precio, imagen, procedencia, stock, activo, stockMinimo) values (?id, ?nom, ?pre, ?img, ?proce, ?stck, 1, ?stckMin)";
            comando = new MySqlCommand(cadenaSql, conexion);

            comando.Parameters.AddWithValue("?id", id);
            comando.Parameters.AddWithValue("?nom", nombre);
            comando.Parameters.AddWithValue("?pre", precio);
            comando.Parameters.AddWithValue("?img", imagen);
            comando.Parameters.AddWithValue("?proce", procedencia);
            comando.Parameters.AddWithValue("?stck", stock);
            comando.Parameters.AddWithValue("?stckMin", stockMinimo);

            comando.ExecuteNonQuery();


            conexion.Close();
        }

        internal void darBajaIndependiente(int id, string nombreInsertar)
        {
            conexion.Open();

            string nombreTablaInsertar = "frutas" + nombreInsertar;

            String cadenaSql = "update " + nombreTablaInsertar + " set activo = 0 where ID = ?id";
            comando = new MySqlCommand(cadenaSql, conexion);

            comando.Parameters.AddWithValue("?id", id);

            comando.ExecuteNonQuery();

            conexion.Close();
        }

        internal void modificarFrutaIndependiente(string id, string nombre, string precio, byte[] imagen, string stock, string procedencia, string stockMin, string nombreInsertar)
        {
            conexion.Open();

            string nombreTablaInsertar = "frutas" + nombreInsertar;

            String cadenaSql = "update " + nombreTablaInsertar + " set Nombre = ?nom, Precio = ?pre, Imagen = ?img, Stock = ?stck, Procedencia = ?proced, stockMinimo = ?stckMin where ID = ?id";
            comando = new MySqlCommand(cadenaSql, conexion);

            comando.Parameters.AddWithValue("?id", id);
            comando.Parameters.AddWithValue("?nom", nombre);
            comando.Parameters.AddWithValue("?pre", precio);
            comando.Parameters.AddWithValue("?img", imagen);
            comando.Parameters.AddWithValue("?stck", stock);
            comando.Parameters.AddWithValue("?proced", procedencia);
            comando.Parameters.AddWithValue("?stckMin", stockMin);

            comando.ExecuteNonQuery();


            conexion.Close();
        }

        public List<claseFrutas> stockBajoMinimo(string nombreTienda)
        {
            conexion.Open();

            string nombreTabla = "frutas" + nombreTienda;

            string cadenaSql = "select * from " + nombreTabla + " where stock < stockMinimo and activo = 1";
            comando = new MySqlCommand(cadenaSql, conexion);

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                claseFrutas f = new claseFrutas();
                f.Id = Convert.ToInt16(datos["id"]);
                f.Nombre = Convert.ToString(datos["nombre"]);
                f.Precio = (float)(datos["precio"]);
                f.Imagen = (byte[])(datos["imagen"]);
                f.Procedencia = Convert.ToString(datos["procedencia"]);
                f.Stock = Convert.ToDouble(datos["stock"]);
                f.Activo = Convert.ToInt16(datos["activo"]);

                listaFrutas.Add(f);
            }

            conexion.Close();

            return listaFrutas;
        }

        internal string correoProveedor(string nombreProveedor)
        {
            conexion.Open();

            string correoProveedor = null;

            string cadenaSql = "select mail from proveedores where Nombre = ?Nombre";
            comando = new MySqlCommand(cadenaSql, conexion);

            comando.Parameters.AddWithValue("?Nombre", nombreProveedor);

            datos = comando.ExecuteReader();

            if (datos.Read())
            {
                correoProveedor = Convert.ToString(datos["mail"]);
            }

            conexion.Close();
            return correoProveedor;
        }

        public List<claseClientes> puntosClientes()
        {
            conexion.Open();

            string consultaSql = "select * from clientes where puntos > 100";
            comando = new MySqlCommand(consultaSql, conexion);
            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                claseClientes cliente = new claseClientes();
                cliente.Dni = Convert.ToString(datos["dni"]);
                cliente.Nombre = Convert.ToString(datos["nombre"]);
                cliente.Mail = Convert.ToString(datos["mail"]);
                cliente.Puntos = Convert.ToInt32(datos["puntos"]);
                listaClientes.Add(cliente);
            }

            conexion.Close();

            return listaClientes;
        }

        public void ActualizarPuntosCliente(string dni, int puntos)
        {

            conexion.Open();
            string consultaSql = "update clientes set puntos = ?puntos where dni = ?dni";
            MySqlCommand comando = new MySqlCommand(consultaSql, conexion);

            comando.Parameters.AddWithValue("@puntos", puntos);
            comando.Parameters.AddWithValue("@dni", dni);
            comando.ExecuteNonQuery();
            conexion.Close();
        }

    }
}
