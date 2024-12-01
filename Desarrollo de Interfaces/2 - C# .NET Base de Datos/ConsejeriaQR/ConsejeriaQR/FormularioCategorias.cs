using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    public partial class FormularioCategorias : Form
    {
        ClaseConectar cnxC;       
        List<Usuarios> datosUsuario = new List<Usuarios>();

        public FormularioCategorias(List<Usuarios> listaUsuario, ClaseConectar cnx)
        {
            InitializeComponent();
            this.Text = "Selecciona una categoría";                      

            datosUsuario = listaUsuario;
            cnxC = cnx;

            if (listaUsuario[0].Departamento.Equals("Administrador"))
            {
                btnRegistrarProfesor.Visible = true;
            }
        }

        private void BtnCerrarCategorias_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnRegistrarProfesor_Click(object sender, EventArgs e)
        {
            FormularioRegistro fR = new FormularioRegistro(cnxC);
            fR.Show();
        }

        private void BtnGestionPrestamos_Click(object sender, EventArgs e)
        {
            FormularioGestionPrestamos fGP = new FormularioGestionPrestamos(datosUsuario, cnxC);
            fGP.Show();
        }
    }
}
