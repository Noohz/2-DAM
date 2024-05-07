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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Primero compruebo que los campos no estén vacios.
            if (tBUsuarioRegistro.Text != "" && tBContraseniaRegistro.Text != "")
            {
                // Obtengo el nombre y lo modifico a minúsculas.
                string nombreUsuario = tBUsuarioRegistro.Text.ToLower();
                // Si el nombre del usuario es admin, si el usuario no ha introducido un email se le preguntará si desea introducirlo o dejarlo a NULL.
                if (nombreUsuario.Equals("admin") && tBEmailRegistro.Text == "")
                {
                    DialogResult dR = MessageBox.Show("¿Deseas dejar el campo de email vacío?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dR == DialogResult.Yes)
                    {
                        string contraseniaCifrada = cifrar(tBContraseniaRegistro.Text);

                        int codigo = cnx.registrarUsuario(tBUsuarioRegistro.Text, null, contraseniaCifrada);

                        if (codigo == 1)
                        {
                            MessageBox.Show("Usuario registrado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tBUsuarioRegistro.Text = "";
                            tBContraseniaRegistro.Text = "";
                            tBEmailRegistro.Text = "";
                        }
                    }
                 // En cambio, si el usuario no es admin se le obligará a introducir un email.
                } else if (tBEmailRegistro.Text != "") 
                {
                    string contraseniaCifrada = cifrar(tBContraseniaRegistro.Text);

                    int codigo = cnx.registrarUsuario(tBUsuarioRegistro.Text, tBEmailRegistro.Text, contraseniaCifrada);

                    if (codigo == 1)
                    {
                        MessageBox.Show("Usuario registrado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tBUsuarioRegistro.Text = "";
                        tBContraseniaRegistro.Text = "";
                        tBEmailRegistro.Text = "";
                    }
                } else
                {
                    MessageBox.Show("Error, debes de introducir un email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Obtengo el usuario y la contraseña cifrada.
                string usuario = tBUsuario.Text;
                string contraseniaCifrada = cifrar(tBContraseniaLogin.Text);

                // Una lista que contiene los datos del usuario.
                listaUsuario = cnx.iniciarSesion(usuario, contraseniaCifrada);

                // Si el nombre y la contraseña (después de cifrar) que introduce el usuario coincide con los datos de la base de datos se accederá a la pantalla adecuada.
                if (listaUsuario.Count != 0)
                {
                    if (usuario.ToLower().Equals("admin"))
                    {
                        MessageBox.Show("¡Has iniciado sesión como administrador!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tBUsuario.Text = "";
                        tBContraseniaLogin.Text = "";

                        Administracion admin = new Administracion();
                        admin.ShowDialog();
                        listaUsuario.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Sesión iniciada correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tBUsuario.Text = "";
                        tBContraseniaLogin.Text = "";

                        ReservarVuelo rV = new ReservarVuelo(listaUsuario);
                        rV.ShowDialog();
                        listaUsuario.Clear();
                    }
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

        private void btnCerrarRegistro_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tBEmailRegistro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegistrar_Click(sender, e);
            }
        }
    }
}
