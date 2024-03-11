using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GestorSQL
{
    public partial class Form1 : Form
    {
        ConectarBD cnx = new ConectarBD();
        List<string> listadeBD = new List<string>();
        resultadoConsulta rC = new resultadoConsulta();
        String nombreImagen;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonRealizarConexion_Click(object sender, EventArgs e)
        {
            string server = textBoxServidor.Text.ToLower();
            string database = textBoxBD.Text.ToLower();
            string usr = textBoxUSR.Text.ToLower();
            string pwd = textBoxPWD.Text.ToLower();

            ConectarBD conexionBD = new ConectarBD(server, database, usr, pwd);

            if (conexionBD.comprobarConexion())
            {
                MessageBox.Show("Se ha realizado la conexión con exito.", "Conexión exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conexionBD.comprobarConexion();

                List<string> listaBD = conexionBD.listarBD();
                listViewDB.Items.Clear();

                foreach (string nombreBD in listaBD)
                {
                    ListViewItem item = new ListViewItem(nombreBD);
                    listViewDB.Items.Add(item);
                }

                buttonConsultaSQL.Enabled = true;
                buttonImportarBD.Visible = true;
                buttonExportarBD.Visible = true;
            }
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Deseas salir?", "Cerrar Aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void buttonServidor_Click(object sender, EventArgs e)
        {
            string nombreServer = Interaction.InputBox("Introduce el nombre del servidor.", "Nombre servidor");

            textBoxServidor.Text = nombreServer;
        }

        private void buttonBD_Click(object sender, EventArgs e)
        {
            string nombreDB = Interaction.InputBox("Introduce el nombre de la Base de Datos.", "Nombre BD");

            textBoxBD.Text = nombreDB;
        }

        private void buttonUSR_Click(object sender, EventArgs e)
        {
            string nombreUsr = Interaction.InputBox("Introduce el nombre del usuario.", "Nombre usuario");

            textBoxUSR.Text = nombreUsr;
        }

        private void buttonPWD_Click(object sender, EventArgs e)
        {
            string nombrePwd = Interaction.InputBox("Introduce la contraseña del usuario.", "Contraseña usuario");

            textBoxPWD.Text = nombrePwd;
        }

        private void buttonConsultaSQL_Click(object sender, EventArgs e)
        {
            string consultaSql = Interaction.InputBox("Introduce la consulta SQL que deseas ejecutar.", "Consulta SQL");

            textBoxConsultaSql.Text = consultaSql;

            if (textBoxConsultaSql.Text == "")
            {
                buttonEjecutar.Enabled = false;
            } else
            {
                buttonEjecutar.Enabled = true;
            }

            labelConsultaSQL.Visible = true;
            textBoxConsultaSql.Visible = true;
            buttonEjecutar.Visible = true;
        }

        private void buttonMostrar_Click(object sender, EventArgs e)
        {
            // Que reconozca 2 tipos de consultas Insert/Delete y Select/Show
            string consultaSql = textBoxConsultaSql.Text.ToLower();

            if (consultaSql.Contains("insert") || consultaSql.Contains("delete") || consultaSql.Contains("update"))
            {
                // Que se use ExecuteNonQuery
                ConectarBD conexionBD = new ConectarBD(textBoxServidor.Text, textBoxBD.Text, textBoxUSR.Text, textBoxPWD.Text);
                conexionBD.ExecuteNonQuery(consultaSql);

            }
            else if (consultaSql.Contains("select") || consultaSql.Contains("show"))
            {
                // Que se use ExecuteReader
                ConectarBD conexionBD = new ConectarBD(textBoxServidor.Text, textBoxBD.Text, textBoxUSR.Text, textBoxPWD.Text);
                string resultado = conexionBD.ExecuteReader(consultaSql);

                rC.SetResultado(resultado);
                rC.ShowDialog();
            }
        }

        private void buttonImportarBD_Click(object sender, EventArgs e)
        {
            DialogResult importar = MessageBox.Show("¿Deseas importar una base de datos?", "Importar BD", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (importar == DialogResult.Yes)
            {
                string nombreBDCrear = Interaction.InputBox("Introduce el nombre de la base de datos a la que deseas importar los datos.", "Importar BD");

                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "sql | *.sql";

                if (opf.ShowDialog() == DialogResult.OK)
                {
                    cnx.crearBD(nombreBDCrear);

                    nombreImagen = opf.FileName;
                    ConectarBD conexionBD = new ConectarBD(textBoxServidor.Text, nombreBDCrear, textBoxUSR.Text, textBoxPWD.Text);
                    conexionBD.ImportarBD(nombreImagen);
                }
            }
        }

        private void buttonExportarBD_Click(object sender, EventArgs e)
        {
            List<string> listaBD = cnx.listarBD();

            string directorio = "C:\\BackUpBD\\";

            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }

            foreach (string nombreBD in listaBD)
            {
                string nombreArchivo = directorio + "\\" + nombreBD + ".sql";
                ConectarBD conexionBD = new ConectarBD(textBoxServidor.Text, nombreBD, textBoxUSR.Text, textBoxPWD.Text);
                conexionBD.ExportarDB(nombreArchivo);
            }
        }

        private void listViewDB_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewDB.SelectedItems.Count > 0)
            {
                string bdSeleccionada = listViewDB.SelectedItems[0].Text;

                ConectarBD conexionBD = new ConectarBD(textBoxServidor.Text, bdSeleccionada, textBoxUSR.Text, textBoxPWD.Text);

                List<string> tablas = conexionBD.listarTablas();

                listViewTablas.Items.Clear();

                foreach (string tabla in tablas)
                {
                    ListViewItem item = new ListViewItem(tabla);
                    listViewTablas.Items.Add(item);
                }
            }
        }
    }
}
