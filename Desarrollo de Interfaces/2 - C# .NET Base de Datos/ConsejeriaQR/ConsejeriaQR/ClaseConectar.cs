﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace ConsejeriaQR
{
    /// <summary>
    /// Clase utilizada de gestionar la conexión con la BBDD y de todas las respectivas consultas a ella.
    /// </summary>
    public class ClaseConectar
    {
        private MySqlConnection conexion;
        private MySqlCommand comando;
        private MySqlDataReader datos;

        private List<Usuarios> listaUsuario = new List<Usuarios>();
        private List<Articulos> listaCategoriaArticulos = new List<Articulos>();
        private List<Articulos> listaArticulos = new List<Articulos>();
        private List<ArticulosDGV> listaArticulosDGV = new List<ArticulosDGV>();
        private List<Prestamos> listaArticulosPrestados = new List<Prestamos>();
        private List<Articulos> listaArticulosEnMantenimiento = new List<Articulos>();
        private List<ArticulosAulaDGV> inventarioAula = new List<ArticulosAulaDGV>();

        public String CADENA_CONEXION = "server=localhost;Database=conserjeriaqr;Uid=root;pwd='';old guids=true";

        /// <summary>
        /// Método que utiliza la contraseña que introduce el usuario y la encripta utilizando PBKDF2. Si esta coincide con la contraseña encriptada de la BD podrá iniciar sesión.
        /// </summary>
        /// <param name="usuario"> Texto con el nombre del usuario introducido. </param>
        /// <param name="contrasenia"> Texto con la contraseña introducida por el usuario. </param>
        /// <returns> Verdadero / Falso => dependiendo de si encuentra el usuario en la BBDD o no. </returns>
        internal bool IniciarSesion(string usuario, string contrasenia)
        {
            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();

                string cadenaSql = "SELECT Salt, Hash FROM usuarios WHERE nombre = @usuario";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
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

        /// <summary>
        /// Método que encripta la contraseña que recibe utilizando PBKDF2. Después ejecuta el insert para almacenarlo en la base de datos. Si "codigo" devuelve 1 es que la operación se ha completado.
        /// </summary>
        /// <param name="nombreUsuario"> Texto con el nombre introducido por el usuario. </param>
        /// <param name="correoUsuario"> Texto con el correo introducido por el usuario. </param>
        /// <param name="contraseniaUsuario"> Texto con la contraseña introducido por el usuario. </param>
        /// <returns> Codigo => 1 si se realiza la insercción en la BBDD o 0 si no. </returns>
        internal int RegistrarProfesor(string nombreUsuario, string departamento, string contraseniaUsuario)
        {
            int codigo;

            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();

                byte[] salt = GenerateSalt();
                byte[] hashedPassword = HashPassword(contraseniaUsuario, salt);

                string saltBase64 = Convert.ToBase64String(salt);
                string hashedBase64 = Convert.ToBase64String(hashedPassword);

                string cadenaSql = "INSERT INTO usuarios VALUES (0, @nombre, @departamento, @Salt, @Hash)";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombreUsuario);
                    comando.Parameters.AddWithValue("@departamento", departamento);
                    comando.Parameters.AddWithValue("@Salt", saltBase64);
                    comando.Parameters.AddWithValue("@Hash", hashedBase64);

                    codigo = comando.ExecuteNonQuery();
                }
            }
            return codigo;
        }

        /// <summary>
        /// Método que devuelve una lista con los datos del usuario que ha iniciado sesión.
        /// </summary>
        /// <param name="correo"> Texto con el correo del usuario a buscar. </param>
        /// <returns> listaUsuario => Lista con los datos del usuario que ha encontrado. </returns>
        internal List<Usuarios> ObtenerDatosUsuario(string usuario)
        {
            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();

                string cadenaSql = "SELECT * FROM usuarios WHERE nombre = @usuario";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);

                    using (datos = comando.ExecuteReader())
                    {
                        while (datos.Read())
                        {
                            Usuarios usr = new Usuarios
                            {
                                Id = (int)datos["id"],
                                Nombre = (string)datos["nombre"],
                                Departamento = (string)datos["departamento"],
                                Salt = (string)datos["Salt"],
                                Hash = (string)datos["Hash"]
                            };

                            listaUsuario.Add(usr);
                        }
                    }
                }
            }
            return listaUsuario;
        }

        /// <summary>
        /// Método para comprobar si el QR que se le pasa por parámetro ya existe en la BD.
        /// </summary>
        /// <param name="claveQR"> Texto con el código QR a buscar </param>
        /// <returns> True / False => Dependiendo de si encuentra un QR con el código a buscar </returns>
        internal bool ComprobarQRExistente(string claveQR)
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

        internal bool ComprobarQRExistenteAula(string claveQR)
        {
            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();

                string cadenaSql = "SELECT * FROM articulosaula WHERE CodigoQR = @claveQR";

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

        /// <summary>
        /// Método que se encarga de insertar el artículo según los datos que recibe por los parámetros.
        /// </summary>
        /// <param name="nombreArticulo"> Texto con el nombre del artículo. </param>
        /// <param name="categoriaArticulo"> Texto con la categoría a la que pertenece el artículo. </param>
        /// <param name="descripcionArticulo"> Texto con la descripción del artículo. </param>
        /// <param name="codigoArticulo"> Texto con el código del artículo. </param>
        /// <param name="claveQR"> Texto con el código QR del artículo. </param>
        /// <param name="imagenQR"> byte[] que contiene los datos de la imágen. </param>
        /// <param name="imagenArticulo"> byte[] que contiene los datos de la imágen QR. </param>
        /// <returns> Codigo => 1 si se realiza la insercción en la BBDD o 0 si no. </returns>
        internal int InsertarArticulo(string nombreArticulo, string categoriaArticulo, string descripcionArticulo, string codigoArticulo, string claveQR, byte[] imagenQR, byte[] imagenArticulo)
        {
            int codigo;

            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();

                string cadenaSql = "INSERT INTO articulos VALUES (0, @nombre, @categoria, @descripcion, @codigo, @claveQR, @imagenQR, @imagen, true, false)";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombreArticulo);
                    comando.Parameters.AddWithValue("@categoria", categoriaArticulo);
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

        /// <summary>
        /// Método que devuelve una lista con las categorias de los artículos que hay en la tabla Articulos en la BD sin repetirse.
        /// </summary>
        /// <returns> listaNombreArticulos => Una lista con las categorias de los artículos que hay en la BBDD. </returns>
        internal List<Articulos> ObtenerCategoriaArticulos()
        {
            listaCategoriaArticulos.Clear();
            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();

                string cadenaSql = "SELECT DISTINCT categoria FROM articulos";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    using (datos = comando.ExecuteReader())
                    {
                        while (datos.Read())
                        {
                            Articulos articulo = new Articulos
                            {
                                Categoria = (string)datos["categoria"]
                            };

                            listaCategoriaArticulos.Add(articulo);
                        }
                    }
                }
            }
            return listaCategoriaArticulos;
        }

        /// <summary>
        /// Método que devuelve una lista con todos los datos de los artículos que coincidan con el nombre que se le pasa por parámetros.
        /// </summary>
        /// <returns> listaArticulos => Lista con la información de los artículos. </returns>
        internal List<Articulos> ObtenerArticulos()
        {
            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                listaArticulos.Clear();

                conexion.Open();

                string cadenaSql = "SELECT * FROM articulos WHERE activo = 1";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    using (datos = comando.ExecuteReader())
                    {
                        while (datos.Read())
                        {
                            Articulos articulo = new Articulos
                            {
                                Id = (int)datos["id"],
                                Nombre = (string)datos["nombre"],
                                Categoria = (string)datos["categoria"],
                                Descripcion = (string)datos["descripcion"],
                                Codigo = (string)datos["codigo"],
                                ClaveQR = (string)datos["claveQR"],
                                ImagenQR = (byte[])datos["imagenQR"],
                                Imagen = (byte[])datos["imagen"],
                                Activo = (bool)datos["activo"],
                                Mantenimiento = (bool)datos["mantenimiento"]
                            };

                            listaArticulos.Add(articulo);
                        }
                    }
                }
            }

            return listaArticulos;
        }

        /// <summary>
        /// Método para almacenar en una lista los artículos activos en la BD para introducirselos al DataGridView. Esta lista si almacena los articulos que no estan activos.
        /// </summary>
        /// <returns> listaArticulosDGV => Lista que contiene los datos de los artículos independientemente de si están activos o no.</returns>
        internal List<ArticulosDGV> ObtenerArticulosDGV()
        {
            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                listaArticulosDGV.Clear();

                conexion.Open();

                string cadenaSql = "SELECT * FROM articulos";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    using (datos = comando.ExecuteReader())
                    {
                        while (datos.Read())
                        {
                            ArticulosDGV articuloDGV = new ArticulosDGV
                            {
                                Id = (int)datos["id"],
                                Nombre = (string)datos["nombre"],
                                Categoria = (string)datos["categoria"],
                                Descripcion = (string)datos["descripcion"],
                                Codigo = (string)datos["codigo"],
                                Activo = (bool)datos["activo"],
                                Mantenimiento = (bool)datos["mantenimiento"]
                            };

                            listaArticulosDGV.Add(articuloDGV);
                        }
                    }
                }
            }

            return listaArticulosDGV;
        }

        /// <summary>
        /// Método que se encargará de eliminar el articulo que coincida con los parámetros.
        /// </summary>
        /// <param name="datosArticulo"> Objeto de la clase Articulos que contiene los datos del artículo a eliminar. </param>
        /// <returns> Codigo => 1 si se realiza la insercción en la BBDD o 0 si no. </returns>
        internal int EliminarArticulo(Articulos datosArticulo)
        {
            int codigo = 0;
            int id = datosArticulo.Id;
            string claveQR = datosArticulo.ClaveQR;

            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();

                string cadenaSql = "DELETE FROM articulos WHERE id = @id AND claveQR = @claveQR";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@claveQR", claveQR);

                    codigo = comando.ExecuteNonQuery();
                }
            }

            return codigo;
        }

        /// <summary>
        /// Método para introducir los datos del prestamo en la tabla prestamos.
        /// </summary>
        /// <param name="articulo"> Objeto de la clase Articulos que contiene la información del artículo a prestar. </param>
        /// <param name="user"> Lista con los datos del usuario que va a prestar el artículo. </param>
        /// <param name="fecha"> DateTime con la fecha de devolución aproximada. </param>
        /// <returns> Codigo => 1 si se realiza la insercción en la BBDD o 0 si no. </returns>
        internal int PrestarArticulo(Articulos articulo, string nombreProfe, DateTime fecha)
        {

            int codigo = 0;
            int id = articulo.Id;
            string nombreArticulo = articulo.Nombre;
            string categoriaArticulo = articulo.Categoria;
            string nombreProfesor = nombreProfe;
            string codigoArticulo = articulo.Codigo;
            DateTime fechaPrestamo = DateTime.Now;
            DateTime fechaDevolucion = fecha;
            byte[] imagenArticulo = articulo.Imagen;

            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();

                string cadenaSql = "INSERT INTO prestamos VALUES (0, @idArticulo, @nombreArticulo, @categoria, @nombreProfesor, @codigo, @fechaPrestamo, @fechaDevolucion, @imagenArticulo)";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@idArticulo", id);
                    comando.Parameters.AddWithValue("@nombreArticulo", nombreArticulo);
                    comando.Parameters.AddWithValue("@categoria", categoriaArticulo);
                    comando.Parameters.AddWithValue("@nombreProfesor", nombreProfesor);
                    comando.Parameters.AddWithValue("@codigo", codigoArticulo);
                    comando.Parameters.AddWithValue("@fechaPrestamo", fechaPrestamo);
                    comando.Parameters.AddWithValue("@fechaDevolucion", fechaDevolucion);
                    comando.Parameters.AddWithValue("@imagenArticulo", imagenArticulo);

                    codigo = comando.ExecuteNonQuery();
                }
            }

            return codigo;
        }

        /// <summary>
        /// Método para actualizar el activo de un producto a 0 para que ya no aparezca en las búsquedas.
        /// </summary>
        /// <param name="articulo"> Objeto de la clase Articulos que contiene la información del artículo. </param>
        /// <param name="activo"> int el estado del articulo </param>
        /// <returns> Codigo => 1 si se realiza la insercción en la BBDD o 0 si no. </returns>
        internal int ActualizarArticulo(Articulos articulo, int activo)
        {
            int codigo = 0;
            int idArticulo = articulo.Id;
            string claveQR = articulo.ClaveQR;

            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();
                string cadenaSql = "UPDATE articulos SET activo = @activo WHERE id = @id AND claveQR = @claveQR";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@activo", activo);
                    comando.Parameters.AddWithValue("@id", idArticulo);
                    comando.Parameters.AddWithValue("@claveQR", claveQR);

                    codigo = comando.ExecuteNonQuery();
                }
            }
            return codigo;
        }

        /// <summary>
        /// Método que devuelve una lista de la clase Pestamos con los artículos que pertenecen a X profesor.
        /// </summary>
        /// <param name="datosUser"> Lista que contiene los datos del usuario logeado actual </param>
        /// <returns> listaArticulosPrestados => Lista con los articulos que tiene prestados el profesor </returns>
        internal List<Prestamos> ObtenerArticulosPrestados(List<Usuarios> datosUser)
        {
            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                listaArticulosPrestados.Clear();

                string nombreUsuario = datosUser[0].Nombre;

                conexion.Open();

                string cadenaSql = "SELECT * FROM prestamos WHERE nombreProfesor = @nombreProfesor";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@nombreProfesor", nombreUsuario);

                    using (datos = comando.ExecuteReader())
                    {
                        while (datos.Read())
                        {
                            Prestamos artPrestados = new Prestamos
                            {
                                Id = (int)datos["id"],
                                IdArticulo = (int)datos["idArticulo"],
                                NombreArticulo = (string)datos["nombreArticulo"],
                                Categoria = (string)datos["categoria"],
                                NombreProfesor = (string)datos["nombreProfesor"],
                                Codigo = (string)datos["codigo"],
                                FechaPrestamo = (DateTime)datos["fechaPrestamo"],
                                FechaDevolucion = (DateTime)datos["fechaDevolucion"],
                                Imagen = (byte[])datos["imagen"]
                            };

                            listaArticulosPrestados.Add(artPrestados);
                        }
                    }
                }
            }

            return listaArticulosPrestados;
        }

        /// <summary>
        /// Método que se encarga de realizar las consultas a la BBDD para devolver el artículo prestado, 
        /// insertar el artículo en la tabla prestamosHistorico para tener un registro de los prestamos realizados
        /// y actualizar los parámetros de activo y mantenmiento.
        /// </summary>
        /// <param name="datosArticulo"> Lista con los datos del artículo prestado. </param>
        /// <param name="activo"> int que se utiliza para marcar el artículo como activo en el update. </param>
        /// <param name="mantenimiento"> int que indica si el artículo deberá estar en mantenimiento o no, este parámetro dependerá de la respuesta del MessageBox. </param>
        /// <returns> Resultado => 1 si se realizan correctamente todas las queries en la BBDD o 0 si no. </returns>
        internal int DevolverArticulo(Prestamos datosArticulo, int activo, int mantenimiento)
        {
            int resultado = 0;

            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();
                using (MySqlTransaction transaccion = conexion.BeginTransaction())
                {
                    bool exito = true;

                    string cadenaSqlDelete = "DELETE FROM prestamos WHERE idArticulo = @idArticulo AND nombreArticulo = @nombreArticulo";
                    using (comando = new MySqlCommand(cadenaSqlDelete, conexion, transaccion))
                    {
                        comando.Parameters.AddWithValue("@idArticulo", datosArticulo.IdArticulo);
                        comando.Parameters.AddWithValue("@nombreArticulo", datosArticulo.NombreArticulo);

                        exito = comando.ExecuteNonQuery() == 1;
                    }

                    if (exito)
                    {
                        string cadenaSqlInsert = "INSERT INTO prestamoshistorico VALUES (0, @idArticulo, @nombreArticulo, @nombreProfesor, @codigo, @fechaPrestamo, @fechaDevolucionInicial, @fechaDevolucionFinal, @imagen)";
                        using (MySqlCommand insert = new MySqlCommand(cadenaSqlInsert, conexion, transaccion))
                        {
                            insert.Parameters.AddWithValue("@idArticulo", datosArticulo.IdArticulo);
                            insert.Parameters.AddWithValue("@nombreArticulo", datosArticulo.NombreArticulo);
                            insert.Parameters.AddWithValue("@nombreProfesor", datosArticulo.NombreProfesor);
                            insert.Parameters.AddWithValue("@codigo", datosArticulo.Codigo);
                            insert.Parameters.AddWithValue("@fechaPrestamo", datosArticulo.FechaPrestamo);
                            insert.Parameters.AddWithValue("@fechaDevolucionInicial", datosArticulo.FechaDevolucion);
                            insert.Parameters.AddWithValue("@fechaDevolucionFinal", DateTime.Now);
                            insert.Parameters.AddWithValue("@imagen", datosArticulo.Imagen);

                            exito = insert.ExecuteNonQuery() == 1;
                        }
                    }

                    if (exito)
                    {
                        string cadenaSqlUpdate = "UPDATE articulos SET activo = @activo, mantenimiento = @mantenimiento WHERE id = @idArticulo";
                        using (MySqlCommand update = new MySqlCommand(cadenaSqlUpdate, conexion, transaccion))
                        {
                            update.Parameters.AddWithValue("@activo", activo);
                            update.Parameters.AddWithValue("@mantenimiento", mantenimiento);
                            update.Parameters.AddWithValue("@idArticulo", datosArticulo.IdArticulo);

                            exito = update.ExecuteNonQuery() == 1;
                        }
                    }

                    if (exito)
                    {
                        transaccion.Commit();
                        resultado = 1;
                    }
                    else
                    {
                        transaccion.Rollback();
                        resultado = 0;
                    }
                }
            }

            return resultado;
        }

        /// <summary>
        /// Método que obtiene todos los artículos que tengan Mantenimiento = 1 de la BBDD y los almacena en una lista.
        /// </summary>
        /// <returns> listaArticulosEnMantenimiento => Lista con los artículos que están en mantenimiento. </returns>
        internal List<Articulos> ObtenerArticulosEnMantenimiento()
        {
            listaArticulosEnMantenimiento.Clear();
            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();

                string cadenaSql = "SELECT * FROM articulos WHERE mantenimiento = 1";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    using (datos = comando.ExecuteReader())
                    {
                        while (datos.Read())
                        {
                            Articulos articulo = new Articulos
                            {
                                Id = (int)datos["id"],
                                Nombre = (string)datos["nombre"],
                                Categoria = (string)datos["categoria"],
                                Descripcion = (string)datos["descripcion"],
                                Codigo = (string)datos["codigo"],
                                ClaveQR = (string)datos["claveQR"],
                                ImagenQR = (byte[])datos["imagenQR"],
                                Imagen = (byte[])datos["imagen"],
                                Activo = (bool)datos["activo"],
                                Mantenimiento = (bool)datos["mantenimiento"]
                            };

                            listaArticulosEnMantenimiento.Add(articulo);
                        }
                    }
                }
            }

            return listaArticulosEnMantenimiento;
        }

        /// <summary>
        /// Método que se encarga de insertar todos los datos del fichero .CSV
        /// </summary>
        /// <param name="articulosFichero"> Lista con los datos de los artículos a insertar. </param>
        internal void InsertarArticuloFichero(List<Articulos> articulosFichero)
        {
            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();

                using (MySqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        foreach (var articulo in articulosFichero)
                        {
                            string consultaSQL = "INSERT INTO articulos VALUES (0, @nombre, @categoria, @descripcion, @codigo, @claveQR, @imagenQR, @imagen, true, @mantenimiento)";

                            using (comando = new MySqlCommand(consultaSQL, conexion, transaccion))
                            {
                                comando.Parameters.AddWithValue("@nombre", articulo.Nombre);
                                comando.Parameters.AddWithValue("@categoria", articulo.Categoria);
                                comando.Parameters.AddWithValue("@descripcion", articulo.Descripcion);
                                comando.Parameters.AddWithValue("@codigo", articulo.Codigo);
                                comando.Parameters.AddWithValue("@claveQR", articulo.ClaveQR);
                                comando.Parameters.AddWithValue("@imagenQR", articulo.ImagenQR);
                                comando.Parameters.AddWithValue("@imagen", articulo.Imagen);
                                comando.Parameters.AddWithValue("@mantenimiento", articulo.Mantenimiento);

                                comando.ExecuteNonQuery();
                            }
                        }

                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Método para modificar los datos del artículo que coincide con el idArticulo que recibe por parámetro.
        /// </summary>
        /// <param name="idArticulo"> El ID del artículo a modificar. </param>
        /// <param name="nombreArticuloMod"> El nuevo nombre del artículo. </param>
        /// <param name="descripcionArticuloMod"> La nueva descripción del artículo. </param>
        /// <param name="codigoArticuloMod"> El nuevo código del artículo. </param>
        /// <param name="claveQRArticuloMod"> La nueva claveQR del artículo. </param>
        /// <param name="imagenQR"> La nueva imágen del códigoQR. </param>
        /// <returns> Resultado => 1 si se realizan correctamente todas las queries en la BBDD o 0 si no. </returns>
        internal int ModificarArticulo(string idArticulo, string nombreArticuloMod, string descripcionArticuloMod, string codigoArticuloMod, string claveQRArticuloMod, byte[] imagenQR)
        {
            int codigo = 0;

            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();
                string cadenaSql = "UPDATE articulos SET nombre = @nombreArticuloMod, descripcion = @descripcionArticuloMod, codigo = @codigoArticuloMod, " +
                    "claveQR = @claveQRArticuloMod, imagenQR = @imagenQR WHERE id = @idArticulo";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@nombreArticuloMod", nombreArticuloMod);
                    comando.Parameters.AddWithValue("@descripcionArticuloMod", descripcionArticuloMod);
                    comando.Parameters.AddWithValue("@codigoArticuloMod", codigoArticuloMod);
                    comando.Parameters.AddWithValue("@claveQRArticuloMod", claveQRArticuloMod);
                    comando.Parameters.AddWithValue("@imagenQR", imagenQR);
                    comando.Parameters.AddWithValue("@idArticulo", idArticulo);

                    codigo = comando.ExecuteNonQuery();
                }
            }
            return codigo;
        }

        /// <summary>
        /// Inserta un nuevo artículo en el inventario de un aula.
        /// </summary>
        /// <param name="aula"> Nombre o identificador del aula donde se encuentra el artículo. </param>
        /// <param name="tipoArticulo"> Tipo de artículo. </param>
        /// <param name="cantidad"> Cantidad del artículo. </param>
        /// <param name="modelo"> Modelo del artículo. </param>
        /// <param name="caracteristicas"> Características adicionales del artículo. </param>
        /// <param name="estado"> Estado del artículo. </param>
        /// <param name="claveQR"> Código QR del artículo. </param>
        /// <param name="imagenQR"> Imagen asociada al código QR del artículo. </param>
        /// <returns> Retorna el número de filas afectadas por la inserción. </returns>
        internal int InsertarArticuloAula(string aula, string tipoArticulo, decimal cantidad, string modelo, string caracteristicas, string estado, string claveQR, byte[] imagenQR)
        {
            int codigo;

            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();

                string cadenaSql = "INSERT INTO articulosaula VALUES (0, @Aula, @TipoArticulo, @Cantidad, @Modelo, @Caracteristicas, @Estado, @CodigoQR, @imagenQR)";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@Aula", aula);
                    comando.Parameters.AddWithValue("@TipoArticulo", tipoArticulo);
                    comando.Parameters.AddWithValue("@Cantidad", cantidad);
                    comando.Parameters.AddWithValue("@Modelo", modelo);
                    comando.Parameters.AddWithValue("@Caracteristicas", caracteristicas);
                    comando.Parameters.AddWithValue("@Estado", estado);
                    comando.Parameters.AddWithValue("@CodigoQR", claveQR);
                    comando.Parameters.AddWithValue("@imagenQR", imagenQR);

                    codigo = comando.ExecuteNonQuery();
                }
            }
            return codigo;
        }

        /// <summary>
        /// Inserta una lista de artículos en el inventario del aula desde un archivo.
        /// </summary>
        /// <param name="articulosFicheroAula"> Lista de artículos a insertar en el inventario del aula. </param>
        internal void InsertarFicheroAula(List<ArticulosAula> articulosFicheroAula)
        {
            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();

                using (MySqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        foreach (var articulo in articulosFicheroAula)
                        {
                            string consultaSQL = "INSERT INTO articulosaula VALUES (0, @Aula, @TipoArticulo, @Cantidad, @Modelo, @Caracteristicas, @Estado, @CodigoQR, @imagenQR)";

                            using (comando = new MySqlCommand(consultaSQL, conexion, transaccion))
                            {
                                comando.Parameters.AddWithValue("@Aula", articulo.Aula);
                                comando.Parameters.AddWithValue("@TipoArticulo", articulo.TipoArticulo);
                                comando.Parameters.AddWithValue("@Cantidad", articulo.Cantidad);
                                comando.Parameters.AddWithValue("@Modelo", articulo.Modelo);
                                comando.Parameters.AddWithValue("@Caracteristicas", articulo.Caracteristicas);
                                comando.Parameters.AddWithValue("@Estado", articulo.Estado);
                                comando.Parameters.AddWithValue("@CodigoQR", articulo.CodigoQR);
                                comando.Parameters.AddWithValue("@imagenQR", articulo.ImagenQR);

                                comando.ExecuteNonQuery();
                            }
                        }

                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Carga el inventario de un aula específico desde la base de datos.
        /// </summary>
        /// <param name="aulaSeleccionada"> El aula cuyo inventario se desea cargar. </param>
        /// <returns> Lista de artículos presentes en el inventario del aula seleccionada. </returns>
        internal List<ArticulosAulaDGV> CargarInventarioAula(string aulaSeleccionada)
        {
            inventarioAula.Clear();
            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();

                string cadenaSql = "SELECT * FROM articulosaula WHERE Aula = @aulaSeleccionada";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@aulaSeleccionada", aulaSeleccionada);

                    using (datos = comando.ExecuteReader())
                    {
                        while (datos.Read())
                        {
                            ArticulosAulaDGV articulo = new ArticulosAulaDGV
                            {
                                Id = (int)datos["ID"],
                                Aula = (string)datos["Aula"],
                                TipoArticulo = (string)datos["TipoArticulo"],
                                Cantidad = (int)datos["Cantidad"],
                                Modelo = (string)datos["Modelo"],
                                Caracteristicas = (string)datos["Caracteristicas"],
                                Estado = (string)datos["Estado"]
                            };

                            inventarioAula.Add(articulo);
                        }
                    }
                }
            }

            return inventarioAula;
        }

        /// <summary>
        /// Modifica los datos de un artículo existente en el inventario de un aula.
        /// </summary>
        /// <param name="idArticulo"> ID del artículo a modificar. </param>
        /// <param name="aula"> Aula donde se encuentra el artículo. </param>
        /// <param name="tipoArticulo"> Nuevo tipo de artículo. </param>
        /// <param name="cantidad"> Nueva cantidad del artículo. </param>
        /// <param name="modelo"> Nuevo modelo del artículo. </param>
        /// <param name="caracteristicas"> Nuevas características del artículo. </param>
        /// <param name="estado"> Nuevo estado del artículo. </param>
        /// <returns> El número de filas afectadas por la actualización. </returns>
        internal int ModificarArticuloAula(int idArticulo, string aula, string tipoArticulo, decimal cantidad, string modelo, string caracteristicas, string estado)
        {
            int codigo = 0;

            using (conexion = new MySqlConnection(CADENA_CONEXION))
            {
                conexion.Open();
                string cadenaSql = "UPDATE articulosaula SET Aula = @aula, TipoArticulo = @tipoArticulo, Cantidad = @cantidad, " +
                    "Modelo = @modelo, Caracteristicas = @caracteristicas, Estado = @estado WHERE ID = @idArticulo";

                using (comando = new MySqlCommand(cadenaSql, conexion))
                {
                    comando.Parameters.AddWithValue("@aula", aula);
                    comando.Parameters.AddWithValue("@tipoArticulo", tipoArticulo);
                    comando.Parameters.AddWithValue("@cantidad", cantidad);
                    comando.Parameters.AddWithValue("@modelo", modelo);
                    comando.Parameters.AddWithValue("@caracteristicas", caracteristicas);
                    comando.Parameters.AddWithValue("@estado", estado);
                    comando.Parameters.AddWithValue("@idArticulo", idArticulo);

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
