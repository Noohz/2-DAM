using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace TPV
{
    class claseAccesoBD
    {
        List<claseFruta> listaFrutas = new List<claseFruta>();

        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader datos;

        public claseAccesoBD()
        {
            conexion = new MySqlConnection();
            conexion.ConnectionString = "server=localhost;Database=dam2023;Uid=root;pwd='';old guids=true";

            List<claseFruta> listaFrutas = new List<claseFruta>();
        }

        public List<claseFruta> listarFrutas()
        {
            conexion.Open();

            String cadenaSql = "select * from frutas where activo = 1";
            comando = new MySqlCommand(cadenaSql, conexion);
            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                claseFruta f = new claseFruta();
                f.Id = Convert.ToInt16(datos["id"]);
                f.Nombre = Convert.ToString(datos["nombre"]);
                f.Precio = (float)(datos["precio"]);
                f.Imagen = (byte[])(datos["imagen"]);
                f.Stock = Convert.ToDouble(datos["stock"]);
                f.Activo = Convert.ToInt16(datos["activo"]);

                listaFrutas.Add(f);

            }

            conexion.Close();

            return listaFrutas;
        }

        internal void modificarStock(List<claseCesta> listaCesta, List<claseFruta> listaFrutas) //Cambiar stock al pagar
        {
            conexion.Open();

            String cadenaSql = "update frutas set stock = stock - @peso where id = @id";
            comando = new MySqlCommand(cadenaSql, conexion);

            foreach (claseCesta cC in listaCesta)
            {
                comando.Parameters.AddWithValue("@peso", cC.Peso);
                comando.Parameters.AddWithValue("@id", cC.Articulo);

                comando.ExecuteNonQuery();
            }

            conexion.Close();
        }

        internal void insertarStock(double stock, int id) // Añadir stock a  la fruta
        {
            conexion.Open();

            String cadenaSql = "update frutas set stock = stock + @stock where id = @id"; // Realiza un update que suma el stock que hay al nuevo que se va a introducir para aumentar el stock de la fruta.
            comando = new MySqlCommand(cadenaSql, conexion);

            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@stock", stock);

            comando.ExecuteNonQuery();

            conexion.Close();
        }

        internal void insertarFruta(int id, string nombre, string precio, byte[] imagen, string stock)
        {
            conexion.Open();

            String cadenaSql = "insert into frutas values (?id, ?nom, ?pre, ?img, ?stck, 1)";
            comando = new MySqlCommand(cadenaSql, conexion);

            comando.Parameters.AddWithValue("?id", id);
            comando.Parameters.AddWithValue("?nom", nombre);
            comando.Parameters.AddWithValue("?pre", precio);
            comando.Parameters.AddWithValue("?img", imagen);
            comando.Parameters.AddWithValue("?stck", stock);

            comando.ExecuteNonQuery();

            conexion.Close();
        }

        internal void eliminarFruta(int id)
        {
            conexion.Open();

            String cadenaSql = "update frutas set activo = 0 where ID = ?id";
            comando = new MySqlCommand(cadenaSql, conexion);

            comando.Parameters.AddWithValue("?id", id);

            comando.ExecuteNonQuery();

            conexion.Close();
        }

        internal void modificarFruta(string id, string nombre, string precio, byte[] imagen, string stock)
        {
            conexion.Open();

            String cadenaSql = "update frutas set Nombre = ?nom, Precio = ?pre, Imagen = ?img, Stock = ?stck where ID = ?id";
            comando = new MySqlCommand(cadenaSql, conexion);

            comando.Parameters.AddWithValue("?id", id);
            comando.Parameters.AddWithValue("?nom", nombre);
            comando.Parameters.AddWithValue("?pre", precio);
            comando.Parameters.AddWithValue("?img", imagen);
            comando.Parameters.AddWithValue("?stck", stock);

            comando.ExecuteNonQuery();


            conexion.Close();
        }

        internal string buscarPorDNI(string dni)
        {
            string email = null; // Variable para almacenar el email del cliente

            conexion.Open();

            String cadenaSql = "select mail from clientes where dni = ?dni";
            comando = new MySqlCommand(cadenaSql, conexion);

            comando.Parameters.AddWithValue("?dni", dni);

            datos = comando.ExecuteReader();

            if (datos.Read())
            {
                email = datos.GetString("mail");
            }

            conexion.Close();

            return email;
        }

        internal string buscarPorBarCodeFruta(string id)
        {
            string nombre = "";

            conexion.Open();
            String cadenaSql = "select nombre from frutas where id = ?id";
            comando = new MySqlCommand(cadenaSql, conexion);

            comando.Parameters.AddWithValue("@id", id);

            datos = comando.ExecuteReader();

            if (datos.Read())
            {
                nombre = datos["nombre"].ToString();
            }

            conexion.Close();
            return nombre;
        }
    }
}
