using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Aerolineas
{
    public partial class Form1 : Form
    {
        ClaseConectar cnx = new ClaseConectar();

        List<Usuariosavion> listaUsuario = new List<Usuariosavion>();

        public Form1()
        {
            InitializeComponent();
            this.Text = "Iniciar / Registrar usuario";
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            if (tBUsuarioRegistro.Text != "" || tBContraseniaRegistro.Text != "" || tBEmail.Text != "")
            {
                string contraseniaCifrada = cifrar(tBContraseniaRegistro.Text);

                int codigo = cnx.registrarUsuario(tBUsuarioRegistro.Text, tBEmail.Text, contraseniaCifrada);

                if (codigo == 1)
                {
                    MessageBox.Show("Usuario registrado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tBUsuarioRegistro.Text = "";
                    tBContraseniaRegistro.Text = "";
                    tBEmail.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Error, debes completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (tBUsuario.Text != "" || tBContraseniaLogin.Text != "")
            {
                string usuario = tBUsuario.Text;
                string contraseniaCifrada = cifrar(tBContraseniaLogin.Text);

                listaUsuario = cnx.iniciarSesion(usuario, contraseniaCifrada);

                if (listaUsuario[0].Nombre.ToLower() == usuario.ToLower() && listaUsuario[0].Clave == contraseniaCifrada)
                {
                    MessageBox.Show("Sesión iniciada correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tBUsuario.Text = "";
                    tBContraseniaLogin.Text = "";

                    ReservarVuelo rV = new ReservarVuelo(listaUsuario);
                    rV.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Error, los datos introducidos son incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error, debes completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public String cifrar(string contrasenia)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();

            ASCIIEncoding encoding = new ASCIIEncoding();

            byte[] stream = null;

            StringBuilder sb = new StringBuilder();

            stream = md5.ComputeHash(encoding.GetBytes(contrasenia));

            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);

            Console.WriteLine(sb.ToString());

            return sb.ToString();
        }

        private void btnCerrarRegistro_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrarLogeo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tBContraseniaLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAcceder_Click(sender, e);
            }
        }
    }
}
