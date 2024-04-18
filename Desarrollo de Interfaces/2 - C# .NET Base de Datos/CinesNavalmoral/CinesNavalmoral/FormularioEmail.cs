using System;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace CinesNavalmoral
{
    public partial class FormularioEmail : Form
    {
        public string textoTB;

        public FormularioEmail(string fileName)
        {
            InitializeComponent();
            this.Text = "Recibir correo";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            textoTB = tBEmail.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }        
    }
}
