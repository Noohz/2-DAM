using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ConsejeriaQR
{
    public partial class FormularioConfirmaciónPrestamo : Form
    {
        ClaseConectar cnxFCP;
        Articulos articulo;
        List<Usuarios> user;

        public FormularioConfirmaciónPrestamo(ClaseConectar cnxFPB, Articulos datosArticulo, List<Usuarios> usuario)
        {
            InitializeComponent();
            cnxFCP = cnxFPB;
            articulo = datosArticulo;
            user = usuario;

        }

        private void BtnConfirmarPrestamo_Click(object sender, EventArgs e)
        {
            if (calendarioFechaDevolucion.Value < DateTime.Now)
            {
                MessageBox.Show("La fecha de devolución no puede ser anterior al día actual...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (var conexion = new MySqlConnection(cnxFCP.CADENA_CONEXION))
                {
                    conexion.Open();
                    using (var transaccion = conexion.BeginTransaction())
                    {
                        try
                        {
                            if (cnxFCP.ActualizarArticulo(articulo, 0) == 1)
                            {
                                if (cnxFCP.PrestarArticulo(articulo, user, calendarioFechaDevolucion.Value) == 1)
                                {
                                    MessageBox.Show("El artículo se ha prestado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    transaccion.Commit();
                                }
                                else
                                {
                                    MessageBox.Show("Ha ocurrido un error al realizar el préstamo...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    transaccion.Rollback();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error al actualizar el estado del artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                transaccion.Rollback();
                            }
                        }
                        catch (Exception ex)
                        {
                            transaccion.Rollback();
                            MessageBox.Show("Ha ocurrido un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    this.Close();
                }
            }
        }

    }
}
