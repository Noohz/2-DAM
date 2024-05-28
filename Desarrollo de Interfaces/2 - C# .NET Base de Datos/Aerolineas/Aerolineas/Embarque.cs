using System;
using System.Drawing;
using System.Windows.Forms;

namespace Aerolineas
{
    public partial class Embarque : Form
    {
        int segundos = 0;
        ClaseConectar cnxE = null;

        public Embarque(ClaseConectar cnx)
        {
            InitializeComponent();
            this.Text = "Ventana de embarque";
            cnxE = cnx;
        }

        private void tBQRAuto_TextChanged(object sender, EventArgs e)
        {
            if (tBQRAuto.Text.Length > 0)
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            segundos++;
            if (segundos == 3)
            {
                timer1.Enabled = false;
                segundos = 0;
                String codigoQR = tBQRAuto.Text;

                int codigo = cnxE.OcuparButaca(codigoQR);

                if (codigo == 1)
                {
                    panelValidacion.BackColor = Color.Green;
                    MessageBox.Show("Butaca ocupada con éxito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    panelValidacion.BackColor = Color.Red;
                    MessageBox.Show("No se ha podido ocupar la butaca", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                tBQRAuto.Focus();
                tBQRAuto.Text = "";
                panelValidacion.BackColor = Color.White;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
