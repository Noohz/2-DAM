using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Aerolineas
{
    public partial class ReservarVuelo : Form
    {
        ClaseConectar cnx = new ClaseConectar();
        List<Horariosaviones> listaHorarios = new List<Horariosaviones>();

        public ReservarVuelo(List<Usuariosavion> listaUsuario)
        {
            InitializeComponent();
            this.Text = "Reservar Vuelo";
            lblBienvenida.Text = "Bienvenido/a: " + listaUsuario[0].Nombre;
            lblBienvenidaMail.Text = "Correo: " + listaUsuario[0].Mail;

            listaHorarios = cnx.obtenerSesionAviones();

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
            ComboBox cB = (ComboBox)sender;
            int seleccion = cB.SelectedIndex;

            lblPrecioTurista.Text = listaHorarios[seleccion].PrecioTurista.ToString();
            lblPrecioPrimera.Text = listaHorarios[seleccion].PrecioPrimera.ToString();
            lblPrecioBussines.Text = listaHorarios[seleccion].PrecioBussines.ToString();
            lblIdAvion.Text = listaHorarios[seleccion].IdVuelo.ToString();
            lblFechaSalida.Text = listaHorarios[seleccion].FechaSalida.ToString();
            lblTrayecto.Text = listaHorarios[seleccion].Ruta.ToString();
        }
    }
}
