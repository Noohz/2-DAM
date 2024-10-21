using System;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    public partial class FormularioRegistro : Form
    {
        ClaseConectar cnxR;

        public FormularioRegistro(ClaseConectar cnxC)
        {
            InitializeComponent();
            this.Text = "Registro de profesor";
            cnxR = cnxC;
            
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (tBnombreRegistro.Text != "" && tBcontraseniaRegistro.Text != "" && tBcorreoRegistro.Text != "")
            {
                if (cnxR.registrarProfesor(tBnombreRegistro.Text, tBcorreoRegistro.Text, tBcontraseniaRegistro.Text) == 1)
                {
                    MessageBox.Show("Profesor registrado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tBnombreRegistro.Text = "";
                    tBcontraseniaRegistro.Text = "";
                    tBcorreoRegistro.Text = "";
                }
            } else
            {
                MessageBox.Show("Error, debes completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {            
            this.Close();
        }
    }
}
