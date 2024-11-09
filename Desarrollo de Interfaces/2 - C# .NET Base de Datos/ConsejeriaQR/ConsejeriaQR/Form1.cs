using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    public partial class Form1 : Form
    {
        ClaseConectar cnx = new ClaseConectar();
        List<Usuarios> listaUsuario = new List<Usuarios>();

        public Form1()
        {
            InitializeComponent();
            this.Text = "Iniciar Sesión";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cierra completamente toda la aplicación.
        }

        // Después de que el usuario inicie sesión correctamente aparecerá el próximo formulario y este se ocultará.
        private void btniniciarSesion_Click(object sender, EventArgs e)
        {
            if (cnx.IniciarSesion(tBcorreo.Text, tBcontrasenia.Text))
            {
                listaUsuario = cnx.ObtenerDatosUsuario(tBcorreo.Text);
                FormularioCategorias fP = new FormularioCategorias(listaUsuario, cnx);
                fP.Show();
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
