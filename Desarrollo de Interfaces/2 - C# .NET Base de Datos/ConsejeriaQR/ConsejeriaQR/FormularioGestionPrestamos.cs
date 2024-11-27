﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    public partial class FormularioGestionPrestamos : Form
    {
        ClaseConectar cnxGP;
        List<Usuarios> datosUsuarioLogeado;

        public FormularioGestionPrestamos(List<Usuarios> datosUsuario, ClaseConectar cnxC)
        {
            InitializeComponent();
            this.Text = "Panel de Gestión de Préstamos";

            datosUsuarioLogeado = datosUsuario;

            lblNombreUsuario.Text = datosUsuarioLogeado[0].Nombre;
            cnxGP = cnxC;
        }

        private void BtnVolverGestionPrestamos_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void BtnAniadirArticulo_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();

            InterfazAniadirArticulos iAA = new InterfazAniadirArticulos(cnxGP);
            Panel panelAniadirArticulo = iAA.GenerarPanelAniadirArticulos(panel3.Width, panel3.Height);
            Panel panelDatosBD = iAA.GenerarPanelDatosArticulosBD(panel3.Width, panel3.Height);

            List<Control> paneles = new List<Control> { panelAniadirArticulo, panelDatosBD };

            panel3.Controls.AddRange(paneles.ToArray());
        }

        private void BtnEliminarArticulo_Click(object sender, EventArgs e)
        {
            if (datosUsuarioLogeado[0].Nombre.Equals("admin"))
            {
                panel3.Controls.Clear();

                InterfazEliminarArticulos iEA = new InterfazEliminarArticulos(cnxGP);
                Panel panelEliminarArticulo = iEA.GenerarPanelEliminarArticulos(panel3.Width, panel3.Height);
                panel3.Controls.Add(panelEliminarArticulo);
            } else
            {
                MessageBox.Show("Solo el administrador puede acceder a este módulo...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void BtnPrestarArticulo_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();

            InterfazPrestarArticulo iPA = new InterfazPrestarArticulo(cnxGP, datosUsuarioLogeado);
            Panel panelPrestarArticulo = iPA.GenerarPanelPrestarArticulos(panel3.Width, panel3.Height);
            panel3.Controls.Add(panelPrestarArticulo);
        }

        private void BtnArticulosPrestados_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();

            InterfazArticulosPrestados iAP = new InterfazArticulosPrestados(cnxGP, datosUsuarioLogeado);
            Panel panelArticuloPrestado = iAP.GenerarPanelArticulosPrestados(panel3.Width, panel3.Height);
            panel3.Controls.Add(panelArticuloPrestado);

        }

        private void btnArticulosMantenimiento_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();

            InterfarArticulosMantenimiento iAM = new InterfarArticulosMantenimiento(cnxGP);
            Panel panelArticulosMantenimiento = iAM.GenerarPanelArticulosMantenimiento(panel3.Width, panel3.Height);
            panel3.Controls.Add(panelArticulosMantenimiento);
        }
    }
}