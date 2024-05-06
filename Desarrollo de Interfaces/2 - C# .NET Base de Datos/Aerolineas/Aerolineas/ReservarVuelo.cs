using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Aerolineas
{
    public partial class ReservarVuelo : Form
    {
        ClaseConectar cnx = new ClaseConectar();

        List<Horariosaviones> listaHorarios = new List<Horariosaviones>();
        List<ModeloAvion> butacasAvion = new List<ModeloAvion>();
        List<String> listaReservas = new List<string>();
        List<Billeteavion> listaFacturacion = new List<Billeteavion>();

        public ReservarVuelo(List<Usuariosavion> listaUsuario)
        {
            InitializeComponent();
            this.Text = "Reservar Vuelo";
            lblBienvenida.Text = "Bienvenido/a: " + listaUsuario[0].Nombre;
            lblBienvenidaMail.Text = "Correo: " + listaUsuario[0].Mail;

            listaHorarios = cnx.obtenerSesionAviones();
            listaFacturacion.Clear();

            foreach (var horarios in listaHorarios)
            {
                comboBoxVuelos.Items.Add(horarios.IdVuelo + " " + horarios.Ruta + " " + horarios.FechaSalida);
            }
        }

        private void btnCerrarReserva_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxVuelos_SelectedIndexChanged(object sender, EventArgs e)
        {
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

            listaFacturacion = cnx.obtenerButacasOcupadas(listaHorarios[seleccion].IdVuelo); // IDVUELO = IDAVION?

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
                    boton.Text = "P" + "_" + boton.Text + "_" + fila;
                    contador++;
                }
                else
                {
                    boton.BackColor = Color.Orange;
                    boton.Name = boton.Text + "_" + fila;
                    boton.Text = "T" + "_" + boton.Text + "_" + fila;
                    contador++;
                }

                boton.Tag = boton.Name;
                boton.Click += Boton_Click;

                columna++;
                if (columna == 6)
                {
                    columna = 0;
                    fila += 1;
                }

                tlp.Controls.Add(boton);
            }
        }

        private void Boton_Click(object sender, EventArgs e)
        {
            Button btnX = (Button)sender;
            Console.WriteLine(btnX.Tag);
            if (btnX.BackColor == Color.Green || btnX.BackColor == Color.Yellow || btnX.BackColor == Color.Orange)
            {
                btnX.BackColor = Color.Pink;
                listaReservas.Add(btnX.Tag.ToString());
                btnComprarVuelo.Enabled = true;
            }
            else if (btnX.BackColor == Color.Pink)
            {
                if (btnX.Text.StartsWith("B"))
                {
                    btnX.BackColor = Color.Green;
                }
                else if (btnX.Text.StartsWith("P"))
                {
                    btnX.BackColor = Color.Yellow;
                }
                else
                {
                    btnX.BackColor = Color.Orange;
                }
                listaReservas.RemoveAt(listaReservas.IndexOf(btnX.Tag.ToString()));
            }

            if (listaReservas.Count == 0)
            {
                btnComprarVuelo.Enabled = false;
            }
        }

        private void btnComprarVuelo_Click(object sender, EventArgs e)
        {
            // Implementar la gestion de pagar como en cine.
        }
    }
}
