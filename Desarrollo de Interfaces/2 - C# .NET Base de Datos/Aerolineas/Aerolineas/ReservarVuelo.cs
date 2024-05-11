using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Aerolineas
{
    public partial class ReservarVuelo : Form
    {
        ClaseConectar cnx = new ClaseConectar();

        List<Horariosaviones> listaHorarios = new List<Horariosaviones>(); // Lista que contiene los horarios de los aviones.
        List<ModeloAvion> butacasAvion = new List<ModeloAvion>(); // Lista que contiene la cantidad de butacas de cada tipo.
        List<String> listaReservas = new List<string>(); // Lista que contiene las butacas que se han hecho click.
        List<Billeteavion> listaFacturacion = new List<Billeteavion>(); // Lista que contiene las bútacas vendidas.
        List<Usuariosavion> datosUsuario = new List<Usuariosavion>(); // Lista que contiene los datos del usuario activo.

        string usuarioActivo; // Variable que contiene el usuario de la sesión activo.

        public ReservarVuelo(List<Usuariosavion> listaUsuario)
        {
            InitializeComponent();
            this.Text = "Reservar Vuelo";
            datosUsuario = listaUsuario; // IMPORTANTE
            lblBienvenida.Text = "Bienvenido/a: " + datosUsuario[0].Nombre;
            usuarioActivo = datosUsuario[0].Nombre;
            lblBienvenidaMail.Text = "Correo: " + datosUsuario[0].Mail;

            listaHorarios = cnx.obtenerSesionAviones();
            listaFacturacion.Clear();

            foreach (var horarios in listaHorarios)
            {
                comboBoxVuelos.Items.Add(horarios.IdVuelo + " " + horarios.Ruta + " " + horarios.FechaSalida);
            }
        }

        private void btnCerrarReserva_Click(object sender, EventArgs e)
        {
            usuarioActivo = "";
            this.Close();
        }

        private void comboBoxVuelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaReservas.Clear();
            lblPrecioTotal.Text = "0";
            lblPrecioTotalDTO.Text = "0";

            // Obtener el item seleccionado del comboBox.
            ComboBox cB = (ComboBox)sender;
            int seleccion = cB.SelectedIndex;

            listaFacturacion.Clear();

            // Uso el item para establecer las cantidades relacionadas con los datos del comboBox.
            lblPrecioTurista.Text = listaHorarios[seleccion].PrecioTurista.ToString();
            lblPrecioPrimera.Text = listaHorarios[seleccion].PrecioPrimera.ToString();
            lblPrecioBussines.Text = listaHorarios[seleccion].PrecioBussines.ToString();
            lblIdAvion.Text = listaHorarios[seleccion].IdAvion.ToString();
            lblFechaSalida.Text = listaHorarios[seleccion].FechaSalida.ToString();
            lblTrayecto.Text = listaHorarios[seleccion].Ruta.ToString();

            // Configuración del FlowLayoutPanel y los botones.
            fLPrincipal.Controls.Clear();
            butacasAvion.Clear();

            listaFacturacion = cnx.obtenerButacasOcupadas(listaHorarios[seleccion].IdVuelo);

            // Guardo en una lista el resultado de la consulta pasandole el ID del avión para que me devuelva los datos del avión.
            butacasAvion = cnx.obtenerButacasAvion(listaHorarios[seleccion].IdAvion);
            // Guardo en una variable el contenido de cada butaca para usarlo a la hora de crear el TableLayoutPanel.
            int butacasBussines = butacasAvion[0].FBussines * 6;
            int butacasPrimera = butacasAvion[0].FPrimera * 6;
            int butacasTurista = butacasAvion[0].FTurista * 6;
            int totalButacas = butacasBussines + butacasPrimera + butacasTurista;
            int columna = 0;
            int fila = 0;
            int contador = 0;

            // Un tableLayoutPanel que contendrá los botones.
            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.AutoSize = true;
            tlp.ColumnCount = 6;
            fLPrincipal.Controls.Add(tlp);

            for (int i = 0; i < totalButacas; i++)
            {
                Button boton = new Button();
                boton.AutoSize = true;

                // 3 if que se encargarán de comprobar en que posición está el botón para asignarle su Letra adecuada.
                if (columna == 0 || columna == 5)
                {
                    if (columna == 0)
                    {
                        boton.Text += "V_I";
                    }
                    else
                    {
                        boton.Text += "V_D";
                    }
                }
                if (columna == 1 || columna == 4)
                {
                    if (columna == 1)
                    {
                        boton.Text += "C_I";
                    }
                    else
                    {
                        boton.Text += "C_D";
                    }
                }
                if (columna == 2 || columna == 3)
                {
                    if (columna == 2)
                    {
                        boton.Text += "P_I";
                    }
                    else
                    {
                        boton.Text += "P_D";
                    }
                }

                // Otros 3 if que se encargan de concatenar al nombre del botón si es Bussines, Primera o turista.
                if (contador < butacasBussines)
                {
                    boton.BackColor = Color.Green;
                    boton.Name = boton.Text + "_" + fila;
                    boton.Text = "B" + "_" + boton.Text + "_" + fila;
                    contador++;
                }
                else if (contador < (butacasPrimera + butacasBussines))
                {
                    boton.BackColor = Color.Yellow;
                    boton.Name = boton.Text + "_" + fila;
                    boton.Text = "Pr" + "_" + boton.Text + "_" + fila;
                    contador++;
                }
                else
                {
                    boton.BackColor = Color.Orange;
                    boton.Name = boton.Text + "_" + fila;
                    boton.Text = "T" + "_" + boton.Text + "_" + fila;
                    contador++;
                }

                // En este punto el nombre del boton sería algo como: V/C/P_I/D_Fila
                boton.Tag = boton.Text;
                boton.Click += Boton_Click;

                columna++;
                if (columna == 6)
                {
                    columna = 0;
                    fila += 1;
                }

                foreach (var item in listaFacturacion)
                {
                    if (item.IdAsiento == boton.Name)
                    {
                        if (item.Comprador.Equals(datosUsuario[0].Nombre))
                        {
                            boton.BackColor = Color.Blue;
                            boton.Enabled = false;
                        } else
                        {
                            boton.BackColor = Color.Red;
                            boton.Enabled = false;
                        }                       
                    }
                }

                tlp.Controls.Add(boton);
            }
        }

        private void Boton_Click(object sender, EventArgs e)
        {
            Button btnX = (Button)sender;
            int precioTotal = int.Parse(lblPrecioTotal.Text);
            int precioTotalDTO = 0;

            if (btnX.BackColor == Color.Green || btnX.BackColor == Color.Yellow || btnX.BackColor == Color.Orange)
            {
                btnX.BackColor = Color.Pink;
                listaReservas.Add(btnX.Tag.ToString());

                if (btnX.Text.StartsWith("B"))
                {
                    precioTotal += int.Parse(lblPrecioBussines.Text);
                }
                else if (btnX.Text.StartsWith("P"))
                {
                    precioTotal += int.Parse(lblPrecioPrimera.Text);
                }
                else
                {
                    precioTotal += int.Parse(lblPrecioTurista.Text);
                }

                btnComprarVuelo.Enabled = true;
            }
            else if (btnX.BackColor == Color.Pink)
            {
                if (btnX.Text.StartsWith("B"))
                {
                    btnX.BackColor = Color.Green;
                    precioTotal -= int.Parse(lblPrecioBussines.Text);
                }
                else if (btnX.Text.StartsWith("P"))
                {
                    btnX.BackColor = Color.Yellow;
                    precioTotal -= int.Parse(lblPrecioPrimera.Text);
                }
                else
                {
                    btnX.BackColor = Color.Orange;
                    precioTotal -= int.Parse(lblPrecioTurista.Text);
                }
                listaReservas.RemoveAt(listaReservas.IndexOf(btnX.Tag.ToString()));
            }

            if (listaReservas.Count == 0)
            {
                btnComprarVuelo.Enabled = false;
            }

            lblPrecioTotal.Text = precioTotal.ToString();

            DateTime fechaActual = DateTime.Now; // Almaceno en la variable la fecha actual para usarla en el descuento.
            DateTime fechaSalida = DateTime.Parse(lblFechaSalida.Text); // Casteo la fecha de salida a datetime para luego poder restarlo.

            int dias = (fechaSalida - fechaActual).Days; // Resto ambas fechas usando .Days para que tenga en cuenta los días.

            if (dias > 15)  // Decrementa un 20%
            {
                double pDto = double.Parse(lblPrecioTotal.Text) * 0.20;
                double pTotalDto = double.Parse(lblPrecioTotal.Text) - pDto;

                lblPrecioTotalDTO.Text = pTotalDto.ToString();
            }
            else if (dias >= 10 && dias <= 14) // Incrementa un 15%
            {
                double pDto = double.Parse(lblPrecioTotal.Text) * 0.15;
                double pTotalDto = double.Parse(lblPrecioTotal.Text) + pDto;

                lblPrecioTotalDTO.Text = pTotalDto.ToString();
            }
            else if (dias >= 2 && dias <= 9) // Incrementa un 20%
            {
                double pDto = double.Parse(lblPrecioTotal.Text) * 0.20;
                double pTotalDto = double.Parse(lblPrecioTotal.Text) + pDto;

                lblPrecioTotalDTO.Text = pTotalDto.ToString();
            }
            else if (dias == 1) // Decrementa un 50%
            {
                double pDto = double.Parse(lblPrecioTotal.Text) * 0.50;
                double pTotalDto = double.Parse(lblPrecioTotal.Text) - pDto;

                lblPrecioTotalDTO.Text = pTotalDto.ToString();
            }

            int butacasBussines = butacasAvion[0].FBussines * 6;
            int butacasPrimera = butacasAvion[0].FPrimera * 6;
            int butacasTurista = butacasAvion[0].FTurista * 6;
            int totalButacas = butacasBussines + butacasPrimera + butacasTurista;
            double cantidadVendida = ((double)listaFacturacion.Count / totalButacas) * 100;

            if (cantidadVendida > 80) // Si se han vendido más del 80% de los billetes se incrementa un 50% el precio anterior.
            {
                double pDto = double.Parse(lblPrecioTotalDTO.Text) * 0.5;
                double pFinal = double.Parse(lblPrecioTotalDTO.Text) + pDto;
                lblPrecioTotalDTO.Text = pFinal.ToString();
            } else if (cantidadVendida >= 50 && cantidadVendida <= 80) // Si se han vendido entre el 50% y 80% de los billetes se incrementan un 20% 
            {
                double pDto = double.Parse(lblPrecioTotalDTO.Text) * 0.2;
                double pFinal = double.Parse(lblPrecioTotalDTO.Text) + pDto;
                lblPrecioTotalDTO.Text = pFinal.ToString();
            } else if (cantidadVendida < 10) // Si se han vendido menos del 10% el precio se decrementa un 10%
            {
                double pDto = double.Parse(lblPrecioTotalDTO.Text) * 0.1;
                double pFinal = double.Parse(lblPrecioTotalDTO.Text) - pDto;
                lblPrecioTotalDTO.Text = pFinal.ToString();
            }
        }

        private void btnComprarVuelo_Click(object sender, EventArgs e)
        {
            string mensaje = "¿Deseas realizar la compra de las siguientes butacas?\n";

            for (int i = 0; i < listaReservas.Count; i++)
            {
                mensaje += listaReservas[i] + "\n";
            }

            DialogResult confirmacion = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                int seleccion = comboBoxVuelos.SelectedIndex;
                int idVuelo = listaHorarios[seleccion].IdVuelo;
                bool compraExitosa = false;

                for (int i = 0; i < listaReservas.Count; i++)
                {
                    String nombreBoton = listaReservas[i];
                    String idAsiento = nombreBoton.Replace("B_", "").Replace("Pr_", "").Replace("T_", "");

                    int codigo = cnx.insertarFacturacion(idVuelo, idAsiento, usuarioActivo, DateTime.Now, lblPrecioTotal.Text); // MODIFICAR ESTO PARA USAR EL PRECIO TOTAL CON DESCUENTO.

                    if (codigo == 1)
                    {
                        compraExitosa = true;
                    }
                }

                if (compraExitosa)
                {
                    MessageBox.Show("Compra realizada con éxito.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error, no se ha podido realizar la compra...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                listaReservas.Clear();
                btnComprarVuelo.Enabled = false;
                usuarioActivo = "";
                this.Close();
            }
            else
            {
                MessageBox.Show("Operación cancelada", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnPerfil_Click(object sender, EventArgs e)
        {
            PerfilUsuario pS = new PerfilUsuario(datosUsuario);
            DialogResult modificar = pS.ShowDialog();

            if (modificar == DialogResult.OK)
            {
                datosUsuario = cnx.iniciarSesion(datosUsuario[0].Nombre, datosUsuario[0].Clave);
                lblBienvenidaMail.Text = "Correo: " + datosUsuario[0].Mail;
            }
        }
    }
}
