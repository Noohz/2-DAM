using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Aerolineas
{
    public class ClaseConectar
    {
        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader datos;

        List<Usuariosavion> listaUsuario = new List<Usuariosavion>();
        List<Horariosaviones> listaHorarios = new List<Horariosaviones>();
        List<ModeloAvion> butacasAvion = new List<ModeloAvion>();
        List<Billeteavion> listaFacturacion = new List<Billeteavion>();
        List<ModeloAvion> listaIdAviones = new List<ModeloAvion>();
        List<Aeropuertos> datosAeropuertos = new List<Aeropuertos>();
        List<int> billetesCompradosUsr = new List<int>();
        List<Horariosaviones> listaHorariosDescuento = new List<Horariosaviones>();

        public ClaseConectar()
        {
            conexion = new MySqlConnection();
            conexion.ConnectionString = "server=localhost;Database=aerolineas2;Uid=root;pwd='';old guids=true";
            //conexion.ConnectionString = "Server=servidoraws.c5s9z61ogvyq.us-east-1.rds.amazonaws.com;Database=aerolineas2;Uid=admin;pwd=Pilukina_2024;old guids=true";
        }

        // Método para cancelar la butaca de un cliente.
        internal int cancelarReservaButaca(int idVuelo, string idAsiento, string usuarioActivo)
        {
            conexion.Open();

            string cadenaSql = "DELETE FROM billeteavion WHERE idVuelo = ?idVuelo AND idAsiento = ?idAsiento AND comprador = ?usuarioActivo";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?idVuelo", idVuelo);
            comando.Parameters.AddWithValue("?idAsiento", idAsiento);
            comando.Parameters.AddWithValue("?usuarioActivo", usuarioActivo);

            int codigo = comando.ExecuteNonQuery();

            conexion.Close();

            return codigo;
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

        // Método para crear una nueva ruta en la tabla horariosavion.
        internal int crearNuevaRuta(int ultimoIdVuelo, string ruta, string fechaSalida, int precioBussines, int precioPrimera, int precioTurista, string idAvion)
        {
            conexion.Open();



            string cadenaSql = "INSERT INTO horariosaviones VALUES(?ultimoIdVuelo, ?ruta, ?fechaSalida, ?precioBussines, ?precioPrimera, ?precioTurista, ?idAvion)";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?ultimoIdVuelo", ultimoIdVuelo);
            comando.Parameters.AddWithValue("?ruta", ruta);
            comando.Parameters.AddWithValue("?fechaSalida", DateTime.Parse(fechaSalida).ToUniversalTime()); // He tenido que usar .ToUniversalTime por que a la hora de realizar la inserción le estaba sumando 2 horas por la diferencia horaria.
            comando.Parameters.AddWithValue("?precioBussines", precioBussines);
            comando.Parameters.AddWithValue("?precioPrimera", precioPrimera);
            comando.Parameters.AddWithValue("?precioTurista", precioTurista);
            comando.Parameters.AddWithValue("?idAvion", idAvion);

            int codigo = comando.ExecuteNonQuery();

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
        internal int insertarFacturacion(int idVuelo, string idAsiento, string usuarioActivo, DateTime fechaActual, string precioTotal, string claveQR)
        {
            conexion.Open();

            string cadenaSql = "INSERT INTO billeteavion VALUES(?idVuelo, ?idAsiento, ?usuario, ?fecha, ?precioTotal, 0, ?claveQR)";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?idVuelo", idVuelo);
            comando.Parameters.AddWithValue("?idAsiento", idAsiento);
            comando.Parameters.AddWithValue("?usuario", usuarioActivo);
            comando.Parameters.AddWithValue("?fecha", fechaActual);
            comando.Parameters.AddWithValue("?precioTotal", precioTotal);
            comando.Parameters.AddWithValue("?claveQR", claveQR);

            int codigo = comando.ExecuteNonQuery();

            conexion.Close();

            return codigo;
        }

        // Método para modificar un avión de la tabla Modeloavion.
        internal int modificarAvion(string idAvion, string FBussines, string FPrimera, string FTurista)
        {
            conexion.Open();

            string cadenaSql = "UPDATE modeloavion SET FBussines = ?FBussines, FPrimera = ?FPrimera, FTurista = ?FTurista WHERE idAvion = ?idAvion";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?idAvion", idAvion);
            comando.Parameters.AddWithValue("?FBussines", FBussines);
            comando.Parameters.AddWithValue("?FPrimera", FPrimera);
            comando.Parameters.AddWithValue("?FTurista", FTurista);

            int codigo = comando.ExecuteNonQuery();

            conexion.Close();

            return codigo;
        }

        // Método para modificar la clave del usuario en la BD.
        internal int modificarContrasenia(string nombre, string contraseniaCifrada)
        {
            conexion.Open();

            string cadenaSql = "UPDATE usuariosavion SET clave = ?contraseniaCifrada WHERE nombre = ?nombre ";
            comando = new MySqlCommand(cadenaSql, conexion);
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
                bV.Ocupado = (int)datos["ocupado"];

                listaFacturacion.Add(bV);
            }

            conexion.Close();

            return listaFacturacion;
        }

        // Método para obtener todos los datos de la tabla aeropuertos.
        internal List<Aeropuertos> obtenerDatosAeropuertos()
        {
            conexion.Open();

            string cadenaSql = "SELECT * FROM aeropuertos";
            comando = new MySqlCommand(cadenaSql, conexion);

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                Aeropuertos aP = new Aeropuertos();
                aP.Id = (string)datos["id"];
                aP.Ciudad = (string)datos["Ciudad"];
                aP.Pais = (string)datos["Pais"];

                datosAeropuertos.Add(aP);
            }

            conexion.Close();

            return datosAeropuertos;
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

            string cadenaSql = "SELECT * FROM horariosaviones ORDER BY fechaSalida ASC";
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

        // Método para obtener el último idVuelo de la tabla horariosavion.
        internal int obtenerUltimoIdVuelo()
        {
            int ultimoID = 0;

            conexion.Open();

            String cadenaSql = "SELECT idVuelo FROM horariosaviones ORDER BY idVuelo DESC LIMIT 1";
            comando = new MySqlCommand(cadenaSql, conexion);

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                ultimoID = (int)datos["idVuelo"];
            }

            conexion.Close();

            return ultimoID;
        }

        // Método para ocupar la butaca reservada.
        internal int OcuparButaca(string codigoQR)
        {
            conexion.Open();

            string cadenaSql = "UPDATE billeteavion SET ocupado = 1 WHERE codigoqr = ?codigoQR AND ocupado = 0";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?codigoQR", codigoQR);

            int codigo = comando.ExecuteNonQuery();

            conexion.Close();

            return codigo;
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

        // Método que reserva temporalmente la butaca que el usuario selecciona en la tabla billetereservado.
        internal void reservarButacaTemporal(int idVuelo, string idAsiento, string usuarioActivo)
        {
            conexion.Open();

            string cadenaSql = "INSERT INTO billetereservado VALUES (?idVuelo, ?idAsiento, ?usuarioActivo)";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?idVuelo", idVuelo);
            comando.Parameters.AddWithValue("?idAsiento", idAsiento);
            comando.Parameters.AddWithValue("?usuarioActivo", usuarioActivo);

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                Billetereservado bR = new Billetereservado();
                bR.IdVuelo = (int)datos["idVuelo"];
                bR.IdAsiento = (string)datos["idAsiento"];
                bR.Comprador = (string)datos["comprador"];
            }

            conexion.Close();
        }

        // Método que elimina la reserva que hizo el usuario temporalmente en la tabla billetereservado.
        internal void cancelarButacaTemporal(int idVuelo, string idAsiento, string usuarioActivo)
        {
            conexion.Open();

            string cadenaSql = "DELETE FROM billetereservado WHERE idVuelo = ?idVuelo AND idAsiento = ?idAsiento AND comprador = ?usuarioActivo";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?idVuelo", idVuelo);
            comando.Parameters.AddWithValue("?idAsiento", idAsiento);
            comando.Parameters.AddWithValue("?usuarioActivo", usuarioActivo);

            comando.ExecuteNonQuery();

            conexion.Close();
        }

        // Método para comprobar si una butaca ya está siendo reservada temporalmente por alguien.
        internal bool comprobarButacaReservadaTemporal(int idVuelo, string idAsiento)
        {
            conexion.Open();

            string cadenaSql = "SELECT COUNT(*) FROM billetereservado WHERE idVuelo = ?idVuelo AND idAsiento = ?idAsiento";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?idVuelo", idVuelo);
            comando.Parameters.AddWithValue("?idAsiento", idAsiento);

            int count = comando.ExecuteNonQuery();

            if (count > 0)
            {
                return true;
            }

            conexion.Close();

            return false;
        }

        // Método para obtener las veces que un usuario a comprado billetes que ya han salido.
        internal int obtenerBilletesComprados(int id, string usuarioActivo)
        {
            int billetes = 0;

            conexion.Open();

            string cadenaSql = "SELECT * FROM billeteavion WHERE idVuelo = ?id AND comprador = ?usuarioActivo";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?id", id);
            comando.Parameters.AddWithValue("?usuarioActivo", usuarioActivo);

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                billetes++;
            }

            conexion.Close();

            return billetes;
        }

        // Método para comprobar si existe algún vuelo en la fecha y ruta que introduce el usuario.
        internal bool comprobarFechaSalidaAvion(string salida, string destino, string fecha)
        {
            string ruta = salida + "-" + destino;
            DateTime fechaSalida = DateTime.Parse(fecha);

            conexion.Open();

            string cadenaSql = "SELECT * FROM horariosaviones WHERE ruta = ?ruta AND fechaSalida = ?fechaSalida";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?ruta", ruta);
            comando.Parameters.AddWithValue("?fechaSalida", fechaSalida);

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                return true;
            }

            conexion.Close();

            return false;
        }

        // Método para comprobar si el QR que se le pasa por parámetro ya existe en la BD.
        internal bool comprobarQRExistente(string claveQR)
        {
            conexion.Open();

            string cadenaSql = "SELECT * FROM billeteavion WHERE codigoqr = ?claveQR";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.AddWithValue("?claveQR", claveQR);

            datos = comando.ExecuteReader();

            while (datos.Read())
            {
                return true;
            }

            conexion.Close();

            return false;
        }

        internal List<Horariosaviones> obtenerSesionAvionesDescuento()
        {
            conexion.Open();

            string cadenaSql = "SELECT * FROM horariosaviones WHERE fechaSalida BETWEEN NOW() AND (NOW() + INTERVAL 12 HOUR)";
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

                listaHorariosDescuento.Add(hS);
            }

            conexion.Close();

            return listaHorariosDescuento;
        }
    }
}
