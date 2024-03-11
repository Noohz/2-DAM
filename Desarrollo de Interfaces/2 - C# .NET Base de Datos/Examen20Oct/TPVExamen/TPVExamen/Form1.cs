using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace TPVExamen
{
    public partial class Form1 : Form
    {
        claseConectarBD conexion = new claseConectarBD();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLoggin_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.ShowDialog();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e) // No es funcional del todo. Si el timer no se para en el método ProcesarPuntosClientes sigue enviando correos aunque los puntos del cliente se hayan actualizado a 0.
        {
            ProcesarPuntosClientes();
        }

        public void ProcesarPuntosClientes()
        {

            List<claseClientes> clientes = conexion.puntosClientes();

            foreach (claseClientes cliente in clientes)
            {
                if (cliente.Puntos >= 100)
                {
                    Random aleatorioPwd = new Random();
                    int codigoPromoción = aleatorioPwd.Next(1000000);

                    EnviarCorreoPromocion(cliente.Mail, codigoPromoción);

                    conexion.ActualizarPuntosCliente(cliente.Dni, 0);

                }
            }

            timer1.Enabled = false;
        }

        public void EnviarCorreoPromocion(string destinatario, int codigoDescuento)
        {
            //correo saliente y pwd
            string email = "aramoss27@educarex.es";
            string password = "yxkjvpygfnvyizjq";

            var loginInfo = new NetworkCredential(email, password);

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Credentials = loginInfo;
            client.EnableSsl = true;

            MailMessage mensaje = new MailMessage();
            mensaje.From = new MailAddress("aramoss27@educarex.es");
            mensaje.To.Add(destinatario);
            mensaje.Subject = "¡Código de Descuento!";
            mensaje.Body = "¡Código de descuento! Debido a tus compras recientes has sido candidato para un codigo de descuento en tu próxima compra: " + codigoDescuento;

            client.Send(mensaje);
            timer1.Enabled = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

    }
}
