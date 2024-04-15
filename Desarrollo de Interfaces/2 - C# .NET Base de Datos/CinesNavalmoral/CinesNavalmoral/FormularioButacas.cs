using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CinesNavalmoral
{
    public partial class FormularioButacas : Form
    {
        ClaseConectar cnx = new ClaseConectar();
        List<ClaseFacturacionCine> listaFacturacion = new List<ClaseFacturacionCine>();
        List<String> listaReservas = new List<string>();

        public FormularioButacas(string titulo, string sesion, string sala)
        {
            InitializeComponent();

            this.Text = "Película: " + titulo;

            lblTitulo.Text = titulo;
            lblNSala.Text = sala;
            lblSesion.Text = sesion;

            int[] arrayButacas = cnx.TotalButacas(sala);
            int totalButacas = arrayButacas[0] * arrayButacas[1];

            lblNTotalButacas.Text = totalButacas.ToString();

            // Lista con la información de los asientos ocupados.
            listaFacturacion = cnx.ButacasOcupadas(sala, sesion);

            int numButacasLibres = Convert.ToInt16(lblNTotalButacas.Text) - listaFacturacion.Count;
            lblNButacasLibres.Text = numButacasLibres.ToString();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormularioButacas_Load(object sender, EventArgs e)
        {
            cargarButacas(listaFacturacion);
        }

        private void cargarButacas(List<ClaseFacturacionCine> listaFacturacion)
        {
            int salaActual = Convert.ToInt16(lblNSala.Text);
            int[] arrayButacas = cnx.TotalButacas(lblNSala.Text);

            int totalButacas = arrayButacas[0] * arrayButacas[1];

            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.AutoSize = true;
            tlp.RowCount = arrayButacas[0];
            tlp.ColumnCount = arrayButacas[1];
            flPrincipal.Controls.Add(tlp);

            for (int filas = 0; filas < arrayButacas[0]; filas++)
            {
                for (int columnas = 0; columnas < arrayButacas[1]; columnas++)
                {
                    Button botonButaca = new Button();
                    botonButaca.Tag = filas + "," + columnas;
                    botonButaca.Width = 30;
                    botonButaca.Height = 20;
                    botonButaca.BackColor = Color.Green;
                    botonButaca.Click += BotonButaca_Click;

                    // Añadir las butacas ocupadas.               
                    foreach (var facturacion in listaFacturacion)
                    {
                        if (facturacion.Fila == filas && facturacion.Columna == columnas)
                        {
                            botonButaca.BackColor = Color.Red;
                            botonButaca.Enabled = false;
                            break;
                        }
                    }

                    // Añadir el boton al TLP.
                    tlp.Controls.Add(botonButaca);
                }
            }
        }

        private void BotonButaca_Click(object sender, EventArgs e)
        {
            Button btnX = (Button)sender;

            if (btnX.BackColor == Color.Green)
            {
                btnX.BackColor = Color.Blue;
                btnPagar.Enabled = true;

                // Añadir a la lista de reserva el tag del botón seleccionado.
                // Por ejemplo Fila/Columna: 10,5
                listaReservas.Add(btnX.Tag.ToString());
            }
            else
            {
                btnX.BackColor = Color.Green;

                // Cuando el botón vuelva al color verde (Que el cliente ya no quiere esa butaca) se elimina del array.
                listaReservas.RemoveAt(listaReservas.IndexOf(btnX.Tag.ToString()));

                if (listaReservas.Count == 0)
                {
                    btnPagar.Enabled = false;
                }
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            string[] butaca = new string[2];

            string mensaje = "¿Deseas realizar la compra de las siguientes butacas?\n";

            foreach (string compra in listaReservas) // Un foreach para recorrer la lista de reservas.
            {
                butaca = compra.Split(','); // Un array para almacenar los datos que estaban separados por una coma. (ANTES: 0","1 >> AHORA: 0 , 1).

                string fila = butaca[0];
                string columna = butaca[1];
                mensaje += "Fila: " + fila + ", Columna: " + columna + "\n";
            }

            DialogResult confirmacion = MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                cnx.InsertarFacturacion(lblNSala.Text, Convert.ToInt16(butaca[0]), Convert.ToInt16(butaca[1]));
                listaReservas.Clear();
                btnPagar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Operación cancelada", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
