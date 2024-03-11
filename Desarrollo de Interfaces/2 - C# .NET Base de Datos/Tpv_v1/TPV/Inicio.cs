using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Windows.Forms;

namespace TPV
{
    public partial class Inicio : Form
    {
        String password = "12345";
        List<String> ProductosBajoMinimo = new List<string>();
        public Inicio()
        {
            InitializeComponent();
        }

        private void txtContrasena_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtContrasena.Text.Equals(password))
                {
                    backEnd be = new backEnd();
                    be.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Constraseña incorrecta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public int mandarMensaje()
        {
            Random aleatorioPwd = new Random();
            int numero = aleatorioPwd.Next(1000000);
            try
            {
                string email = "aramoss27@educarex.es";
                string password = "yxkjvpygfnvyizjq";
                var loginInfo = new NetworkCredential(email, password);
                var msg = new MailMessage();
                var smtpClient = new SmtpClient("smtp.gmail.com", 25);
                msg.From = new MailAddress("aramoss27@educarex.es");
                msg.To.Add(new MailAddress("aramoss27@educarex.es"));
                msg.Subject = "Contraseña";

                msg.Body = "Se adjunta nueva contraseña: " + numero;

                msg.IsBodyHtml = true;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = loginInfo;
                smtpClient.Send(msg);
                smtpClient.Dispose();

                MessageBox.Show("Mensaje enviado");

                return numero;
            }
            catch (Exception)
            {
                MessageBox.Show("Mensaje no enviado");
                return -1;
            }
        }

        private void btnRecordar_Click(object sender, EventArgs e)
        {
            password = Convert.ToString(mandarMensaje());
        }

        private void button1_Click(object sender, EventArgs e)
        {       
            this.Hide();
            Thread.Sleep(50);

            TPV tpv = new TPV();
            tpv.ShowDialog();
        }
    }
}
