using System;
using System.Windows.Forms;

namespace TPVExamen
{
    public partial class Login : Form
    {
        claseConectarBD conexion = new claseConectarBD();
        BackEnd bE = new BackEnd();
        public Login()
        {
            InitializeComponent();
        }

        private void buttonIniciarSesion_Click(object sender, EventArgs e)
        {
            string dni = textBoxUsuario.Text;
            string contrasenia = textBoxContraseña.Text;


            if (conexion.buscarUsuario(dni, contrasenia))
            {
                bE.ShowDialog();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrecta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxContraseña_KeyUp(object sender, KeyEventArgs e)
        {
            string dni = textBoxUsuario.Text;
            string contrasenia = textBoxContraseña.Text;

            if (e.KeyCode == Keys.Enter)
            {
                if (conexion.buscarUsuario(dni, contrasenia))
                {
                    bE.ShowDialog();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña incorrecta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
