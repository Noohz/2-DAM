using System;
using System.Collections.Generic;
using Farmacio_version_2._0;
using MySql.Data.MySqlClient;
namespace Farmacia_version_2._0
{
    class ClaseConectarBD
    {
        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader datos;
        List<ClaseMedicamento> listaMedicamentos = new List<ClaseMedicamento>();
        List<ClaseTarjetaSanitaria> listaTarjetas = new List<ClaseTarjetaSanitaria>();
        List<ClaseTratamiento> listaTratamientos = new List<ClaseTratamiento>();
        List<ClaseEmpleado> listaEmpleados = new List<ClaseEmpleado>();
        List<ClaseFacturacion> listaFacturas = new List<ClaseFacturacion>();
        public ClaseConectarBD()
        {
            conexion = new MySqlConnection();
            conexion.ConnectionString = "Server=localhost;Database=farmacia;Uid=root;pwd='';old guids=true";

        }
        public List<ClaseMedicamento> listar()
        {
            conexion.Open();
            String cadenaSql = "select * from medicamento where activo=1";
            comando = new MySqlCommand(cadenaSql, conexion);
            datos = comando.ExecuteReader();
            while (datos.Read())
            {
                ClaseMedicamento cm = new ClaseMedicamento();
                cm.Indice = Convert.ToInt16(datos["indice"]);
                cm.Nombre = Convert.ToString(datos["nombre"]);
                cm.Precio = Convert.ToDouble(String.Format("{0:0.00}", datos["precio"]));
                cm.Imagen = (byte[])datos["imagen"];
                cm.StockAct = Convert.ToInt16(datos["stockactual"]);
                cm.StockMin = Convert.ToInt16(datos["stockminimo"]);
                listaMedicamentos.Add(cm);
            }
            conexion.Close();
            return listaMedicamentos;
        }

        internal void Insertar(String nombreM, Double precio, byte[] imagen, int stockMin, int stockActual)
        {
            conexion.Open();
            String cadenaSql = "insert into medicamento values(null,?nom,?precio,?imagen,?stockmin,?stockactual)";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.Add("?nom", MySqlDbType.VarChar).Value = nombreM;
            comando.Parameters.Add("?precio", MySqlDbType.Double).Value = precio;
            comando.Parameters.Add("?imagen", MySqlDbType.Blob).Value = imagen;
            comando.Parameters.Add("?stockmin", MySqlDbType.Int16).Value = stockMin;
            comando.Parameters.Add("?stockActual", MySqlDbType.Int16).Value = stockActual;



            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public ClaseEmpleado buscarUsuario(String dni, String pwd)
        {
            ClaseEmpleado emp = new ClaseEmpleado();
            String sql = "select * from empleados where dni=?dni and password=?pwd";
            conexion.Open();
            comando = new MySqlCommand(sql, conexion);
            comando.Parameters.Add("?dni", MySqlDbType.String).Value = dni;
            comando.Parameters.Add("?pwd", MySqlDbType.String).Value = pwd;
            MySqlDataReader datos = comando.ExecuteReader();
            int nivel = 0;
            if (datos.Read())
            {

                emp.Dni = datos["dni"].ToString();
                emp.Nombre = datos["nombre"].ToString();
                emp.Nivel = Convert.ToInt16(datos["nivel"]);

            }



            conexion.Close();

            return emp;
        }

        public void insertarFacturas(List<ClaseMedicamento> listaCesta, string dniVendedor, double total)
        {
            string cadenaProductos = "";
            for (int i = 0; i < listaCesta.Count; i++)
            {
                cadenaProductos += listaCesta[i].Nombre + ",";
            }
            conexion.Open();
            String cadenaSql = "insert into facturacion values(null,?dni,?cadenaProd,?fecha,?total)";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.Add("?dni", MySqlDbType.VarChar).Value = dniVendedor;
            comando.Parameters.Add("?cadenaProd", MySqlDbType.VarChar).Value = cadenaProductos;
            comando.Parameters.Add("?fecha", MySqlDbType.DateTime).Value = DateTime.Now;
            comando.Parameters.Add("?total", MySqlDbType.Double).Value = total;
            comando.ExecuteNonQuery();
            conexion.Close();

        }

        internal void modificarMedicamento(ClaseMedicamento med)
        {
            conexion.Open();
            String cadenaSql = "update  medicamento set nombre=?nom,precio=?pr,stockminimo=?sm,stockactual=?sa,imagen=?im where indice=?id";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.Add("?id", MySqlDbType.Int16).Value = med.Indice;
            comando.Parameters.Add("?nom", MySqlDbType.VarChar).Value = med.Nombre;
            comando.Parameters.Add("?pr", MySqlDbType.Double).Value = med.Precio;

            comando.Parameters.Add("?sa", MySqlDbType.Int16).Value = med.StockAct;
            comando.Parameters.Add("?sm", MySqlDbType.Int16).Value = med.StockMin;
            comando.Parameters.Add("?im", MySqlDbType.Blob).Value = (byte[])med.Imagen;
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public void Lanzar_actualizacion(List<ClaseMedicamento> listaCesta)
        {
            conexion.Open();
            for (int i = 0; i < listaCesta.Count; i++)
            {
                string NombreMed = listaCesta[i].Nombre;
                String cadenaSql = "update medicamento set stockactual=stockactual-1 where nombre= '" + NombreMed + "'";
                comando = new MySqlCommand(cadenaSql, conexion);
                comando.ExecuteNonQuery();
            }
            //  String cadenaSql = ""
            conexion.Close();
        }

        public List<ClaseTarjetaSanitaria> listarTarjetas()
        {
            conexion.Open();
            String cadenaSql = "select * from tarjetaSanitaria";
            comando = new MySqlCommand(cadenaSql, conexion);
            datos = comando.ExecuteReader();
            while (datos.Read())
            {
                ClaseTarjetaSanitaria cTS = new ClaseTarjetaSanitaria();
                cTS.Dni = Convert.ToString(datos["dni"]);
                cTS.Nombre = Convert.ToString(datos["nombre"]);
                cTS.Email = Convert.ToString(datos["email"]);
                cTS.FechaNacimiento = Convert.ToDateTime(datos["fechaNacimiento"]);
                listaTarjetas.Add(cTS);
            }
            conexion.Close();
            return listaTarjetas;

        }

        public List<ClaseTratamiento> listarTratamientos(string dni, int mes)
        {
            conexion.Open();
            String cadenaSql = "select * from tratamientos where dni=?d and mes=?m and recogido=0";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.Add("?d", MySqlDbType.VarChar).Value = dni;
            comando.Parameters.Add("?m", MySqlDbType.Int16).Value = mes;
            datos = comando.ExecuteReader();
            while (datos.Read())
            {
                ClaseTratamiento cT = new ClaseTratamiento();
                cT.Identificador = Convert.ToInt16(datos["identificador"]);
                cT.Dni = Convert.ToString(datos["dni"]);
                cT.Medicamento = Convert.ToString(datos["medicamento"]);
                cT.Mes = Convert.ToInt16(datos["mes"]);
                cT.Recogido = Convert.ToInt16(datos["recogido"]);

                listaTratamientos.Add(cT);
            }
            conexion.Close();
            return listaTratamientos;
        }

        public void actualizarTratamiento(List<ClaseMedicamento> listaCesta, string dni, int mes)
        {
            conexion.Open();
            for (int i = 0; i < listaCesta.Count; i++)
            {
                String cadenaSql = "update tratamientos set recogido=1 where dni=?d and medicamento=?m and mes=?mes";
                comando = new MySqlCommand(cadenaSql, conexion);
                comando.Parameters.Add("?d", MySqlDbType.VarChar).Value = dni;
                comando.Parameters.Add("?m", MySqlDbType.VarChar).Value = listaCesta[i].Nombre;
                comando.Parameters.Add("?mes", MySqlDbType.Int16).Value = mes;
                comando.ExecuteNonQuery();
            }
            conexion.Close();
        }

        internal void ActualizarVentaEmpleado(string dni, double total)
        {
            conexion.Open();
            String cadenaSql = "update empleados set ventas=ventas+?total where dni=?dni";
            comando = new MySqlCommand(cadenaSql, conexion);
            comando.Parameters.Add("?dni", MySqlDbType.VarChar).Value = dni;
            comando.Parameters.Add("?total", MySqlDbType.Double).Value = total;
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }


}
