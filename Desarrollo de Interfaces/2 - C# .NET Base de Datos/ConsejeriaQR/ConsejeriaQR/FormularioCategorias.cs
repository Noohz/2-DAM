using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    public partial class FormularioCategorias : Form
    {
        ClaseConectar cnxC;       
        List<usuarios> datosUsuario = new List<usuarios>();

        public FormularioCategorias(List<usuarios> listaUsuario, ClaseConectar cnx)
        {
            InitializeComponent();
            this.Text = "Selecciona una categoría";                      

            datosUsuario = listaUsuario;
            cnxC = cnx;

            if (listaUsuario[0].Correo.Equals("admin"))
            {
                btnRegistrarProfesor.Visible = true;
            }
        }

        private void btnCerrarCategorias_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegistrarProfesor_Click(object sender, EventArgs e)
        {
            FormularioRegistro fR = new FormularioRegistro(cnxC);
            fR.Show();
        }

        private void btnGestionPrestamos_Click(object sender, EventArgs e)
        {
            FormularioGestionPrestamos fGP = new FormularioGestionPrestamos(datosUsuario, cnxC);
            fGP.Show();
        }
    }
}
