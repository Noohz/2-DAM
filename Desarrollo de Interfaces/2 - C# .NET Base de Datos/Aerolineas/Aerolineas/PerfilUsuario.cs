using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aerolineas
{
    public partial class PerfilUsuario : Form
    {
        ClaseConectar cnx = new ClaseConectar();
        List<Usuariosavion> usuario = new List<Usuariosavion>();

        public PerfilUsuario(List<Usuariosavion> datosUsuario)
        {
            InitializeComponent();
            this.Text = "Perfil de " + datosUsuario[0].Nombre;
            lblBienvenida.Text = "Bienvenido/a: " + datosUsuario[0].Nombre;
            usuario = datosUsuario;
        }

        private void tBOldEmail_TextChanged(object sender, EventArgs e)
        {
            if (tBOldEmail.Text.ToLower().Equals(usuario[0].Mail.ToLower()))
            {
                tBNewEmail.Enabled = true;
            }
            else
            {
                tBNewEmail.Enabled = false;
                tBNewEmail.Clear();
            }
        }

        private void btnModificarMail_Click(object sender, EventArgs e)
        {
            if (tBOldEmail.Text != "" && tBNewEmail.Text != "")
            {
                int codigo = cnx.modificarCorreo(usuario[0].Nombre, tBNewEmail.Text);

                if (codigo == 1)
                {
                    MessageBox.Show("Correo modificado con éxito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tBOldEmail.Clear();
                    tBNewEmail.Clear();
                    tBNewEmail.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error al modificar el correo...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error, todos los campos deben ser completados...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModCorreo_Click(object sender, EventArgs e)
        {
            gBOpcionesMail.Visible = true;
            btnCerrar.Visible = false;
            gBOpcionesPwd.Visible = false;
        }

        private void btnCerrarModEmail_Click(object sender, EventArgs e)
        {
            gBOpcionesMail.Visible = false;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnModCrontrasenia_Click(object sender, EventArgs e)
        {
            gBOpcionesPwd.Visible = true;
            btnCerrar.Visible = false;
            gBOpcionesMail.Visible = false;

        }

        private void tBOldPwd_TextChanged(object sender, EventArgs e)
        {
            string contraseniaCifrada = cifrar(tBOldPwd.Text);

            if (contraseniaCifrada.Equals(usuario[0].Clave))
            {
                tBNewPwd.Enabled = true;
            }
            else
            {
                tBNewPwd.Enabled = false;
                tBNewPwd.Clear();
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

        private void btnModificarPwd_Click(object sender, EventArgs e)
        {
            if (tBOldPwd.Text != "" && tBNewPwd.Text != "")
            {
                string nuevaContrasenia = cifrar(tBNewPwd.Text);


                int codigo = cnx.modificarContrasenia(usuario[0].Nombre, nuevaContrasenia);

                if (codigo == 1)
                {
                    MessageBox.Show("Contraseña modificada con éxito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tBOldPwd.Clear();
                    tBNewPwd.Clear();
                    tBNewPwd.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error al modificar la contraseña...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error, todos los campos deben ser completados...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrarPwd_Click(object sender, EventArgs e)
        {
            gBOpcionesPwd.Visible = false;
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
