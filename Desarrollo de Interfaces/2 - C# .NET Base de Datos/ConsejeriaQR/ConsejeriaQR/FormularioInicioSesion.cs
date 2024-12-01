using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    /// <summary>
    /// El primer formulario que aparece nada más iniciar la aplicación. Le pedirá el nombre y contraseña al usuario que se utilizarán en una consulta SQL para comprobar si son correctos o no
    /// </summary>
    public partial class FormularioInicioSesion : Form
    {
        ClaseConectar cnx = new ClaseConectar();
        List<Usuarios> listaUsuario = new List<Usuarios>();

        public FormularioInicioSesion()
        {
            InitializeComponent();
            this.Text = "Iniciar Sesión";

            tBusuario.GotFocus += (sender, e) => EventoPlaceholderTextBox.HandlePlaceholder(sender, "");
            tBusuario.LostFocus += (sender, e) => EventoPlaceholderTextBox.HandlePlaceholder(sender, "Nombre de usuario");

            tBcontrasenia.GotFocus += (sender, e) => EventoPlaceholderTextBox.HandlePlaceholder(sender, "");
            tBcontrasenia.LostFocus += (sender, e) => EventoPlaceholderTextBox.HandlePlaceholder(sender, "Contraseña");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cierra completamente toda la aplicación.
        }

        // Después de que el usuario inicie sesión correctamente aparecerá el próximo formulario y este se ocultará.
        private void btniniciarSesion_Click(object sender, EventArgs e)
        {
            if (cnx.IniciarSesion(tBusuario.Text, tBcontrasenia.Text))
            {
                listaUsuario = cnx.ObtenerDatosUsuario(tBusuario.Text);
                FormularioCategorias fP = new FormularioCategorias(listaUsuario, cnx);
                fP.Show();

                tBusuario.Text = "Nombre de Usuario";
                tBcontrasenia.Text = "Contraseña";

                this.Hide();
            }
            else
            {
                MessageBox.Show("El usuario o la contraseña son incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Esto simplemente se encarga de permitir que el usuario pueda iniciar sesión si pulsa la tecla "Enter" cuando está en el textBox de la contraseña.
        private void tBcontrasenia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btniniciarSesion_Click(sender, e);
            }
        }
    }
}
