using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Google.Protobuf.Collections;

namespace EjercicioAltura
{
    public partial class Form1 : Form
    {

        ConectarBD cnx = new ConectarBD();
        List<ClaseAltura> cAltura = new List<ClaseAltura>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            cAltura = cnx.DatosAltura();
            dataGridView1.DataSource = cAltura;
        }

        private void btnIntroducirDatos_Click(object sender, System.EventArgs e)
        {
            cnx.insertarDatosAltura(textBoxProvincia.Text, textBoxSituacionAltMax.Text, Convert.ToInt16(textBoxAlturaMaxima.Text), textBoxSituacionAltMin.Text, Convert.ToInt16(textBoxAlturaMinima.Text));
        }
    }
}
