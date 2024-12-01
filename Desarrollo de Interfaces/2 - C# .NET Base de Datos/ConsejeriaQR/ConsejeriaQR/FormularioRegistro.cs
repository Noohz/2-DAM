using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    /// <summary>
    /// Este Form permite a los usuarios con el rol de Administrador añadir un usuario nuevo a la BBDD.
    /// </summary>
    public partial class FormularioRegistro : Form
    {
        ClaseConectar cnxR;

        public FormularioRegistro(ClaseConectar cnxC)
        {
            InitializeComponent();
            this.Text = "Registro de profesor";
            cnxR = cnxC;

            tBnombreRegistro.GotFocus += (sender, e) => EventoPlaceholderTextBox.HandlePlaceholder(sender, "");
            tBnombreRegistro.LostFocus += (sender, e) => EventoPlaceholderTextBox.HandlePlaceholder(sender, "Nombre de usuario");

            cBDepartamento.SelectedIndex = 2;

            tBcontraseniaRegistro.GotFocus += (sender, e) => EventoPlaceholderTextBox.HandlePlaceholder(sender, "");
            tBcontraseniaRegistro.LostFocus += (sender, e) => EventoPlaceholderTextBox.HandlePlaceholder(sender, "Contraseña");
        }

        /// <summary>
        /// Evento que contiene la funcionalidad para realizar el registro del usuario en la BBDD.
        /// </summary>
        /// <param name="sender"> Control que ha llamado al evento. </param>
        /// <param name="e"> Los argumentos que realiza el evento. </param>
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (tBnombreRegistro.Text != "" && tBcontraseniaRegistro.Text != "")
            {
                if (cnxR.RegistrarProfesor(tBnombreRegistro.Text, cBDepartamento.Text, tBcontraseniaRegistro.Text) == 1)
                {
                    MessageBox.Show("Usuario registrado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tBnombreRegistro.Text = "Nombre de Usuario";
                    tBnombreRegistro.ForeColor = Color.FromKnownColor(KnownColor.GrayText);
                    cBDepartamento.SelectedIndex = 2;
                    tBcontraseniaRegistro.Text = "Contraseña";
                    tBcontraseniaRegistro.ForeColor = Color.FromKnownColor(KnownColor.GrayText);
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
