using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CinesNavalmoral
{
    public partial class FormularioBack : Form
    {
        ClaseConectar cnx = new ClaseConectar();
        List<ClaseSalaCine> numSalas = new List<ClaseSalaCine>();

        String nombreImagen;
        int segundos = 0;

        public FormularioBack()
        {
            InitializeComponent();

            numSalas = cnx.obtenerIdSala();

            foreach (var sala in numSalas)
            {
                cBSala.Items.Add(sala.IdSala);
            }

            dateTPSesion.Format = DateTimePickerFormat.Custom;
            dateTPSesion.CustomFormat = "yyyy-MM-dd";
        }

        private void btnProgramarSesion_Click(object sender, EventArgs e)
        {
            if (tBTitulo != null && cBSala.SelectedIndex != -1)
            {
                if (cnx.comprobarSalaHoraLibre(dateTPSesion.Text, cBSala.SelectedIndex))
                {
                    if (nombreImagen != null)
                    {
                        /*crear fichero binario a partir del fichero físico*/
                        FileStream fs = new FileStream(nombreImagen, FileMode.Open, FileAccess.Read);
                        /*se prepara la secuencia de datos o caracteres que se van a leer*/
                        BinaryReader br = new BinaryReader(fs);
                        /*Lee el número especificado de bytes de la secuencia actual en una matriz de bytes y hace avanzar la posición actual en función del número de bytes leídos.*/
                        byte[] bloque = br.ReadBytes((int)fs.Length);

                        if (cnx.programarNuevaSesion(tBTitulo.Text, tBsesion.Text, cBSala.SelectedIndex, bloque) == 1)
                        {
                            MessageBox.Show("Pelicula añadida.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tBTitulo.ResetText();
                            pctImagen.Image = null;
                            cBSala.SelectedIndex = -1;
                            numHoras.Value = 0;
                            numHoras.Enabled = false;
                            numMin.Value = 0;
                            numMin.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debes introducir una imágen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("Debes completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op1 = new OpenFileDialog();  /*cuadro de diálogo para cargar un fichero externo*/
            op1.Filter = "imagenes|*.jpg;*.png"; /* filtro de fichero imágenes*/
            if (op1.ShowDialog() == DialogResult.OK) /*si se acepta el ficero seleccionado*/
            {
                nombreImagen = op1.FileName;  /* nombre del fichero: Ruta completa+nombre*/
                pctImagen.Image = Image.FromFile(nombreImagen);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numHoras_ValueChanged(object sender, EventArgs e)
        {
            String cadenaDateTime = tBsesion.Text;
            String nuevaCadena = cadenaDateTime.Substring(0, 11);
            nuevaCadena += numHoras.Value + ":" + numMin.Value;
            tBsesion.Text = nuevaCadena;
        }

        private void numMin_ValueChanged(object sender, EventArgs e)
        {
            String cadenaDateTime = tBsesion.Text;
            String nuevaCadena = cadenaDateTime.Substring(0, 11);
            nuevaCadena += numHoras.Value + ":" + numMin.Value;
            tBsesion.Text = nuevaCadena;
        }

        private void dateTPSesion_ValueChanged(object sender, EventArgs e)
        {
            String resultadoDTP_sesion = dateTPSesion.Value.ToString("yyyy-MM-dd-");

            if (dateTPSesion.Value >= DateTime.Now)
            {
                tBsesion.Text = resultadoDTP_sesion;
                numHoras.Enabled = true;
                numMin.Enabled = true;
            }
            else
            {
                MessageBox.Show("Fecha no válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrearSala_Click(object sender, EventArgs e)
        {
            // Un if para comprobar que la sala tenga un tamaño.
            if (numFilas.Value > 0 && numColumnas.Value > 0)
            {
                int codigo = cnx.generarSala(Convert.ToInt16(numFilas.Value), Convert.ToInt16(numColumnas.Value));

                if (codigo == 1)
                {
                    MessageBox.Show("Nueva sala creada.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    numSalas.Clear();
                    numSalas = cnx.obtenerIdSala();
                    cBSala.Items.Clear();

                    foreach (var item in numSalas)
                    {
                        cBSala.Items.Add(item.IdSala);
                    }
                }
                else
                {
                    MessageBox.Show("Error al crear la sala.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tBQREnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String cadenaBuscada = tBQREnter.Text;
                String[] vector = cadenaBuscada.Split('x');
                String sesion = vector[0];

                // Estos replaces son para usar el escanner.
                sesion = sesion.Replace("'", "-");
                sesion = sesion.Replace("?", ":");

                // Este es para poder introducirlo a mano.
                sesion = sesion.Replace('_', ':');

                int codigo = cnx.OcuparButaca(sesion, vector[1], vector[2], vector[3]);

                if (codigo == 1)
                {
                    panelValidacion.BackColor = Color.Green;
                    MessageBox.Show("Butaca ocupada con éxito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    panelValidacion.BackColor = Color.Red;
                    MessageBox.Show("No se ha podido ocupar la butaca", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                tBQREnter.Focus();
                tBQREnter.Text = "";
                panelValidacion.BackColor = Color.White;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (tBQRAuto.Text.Length > 0)
                timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            segundos++;
            if (segundos == 3)
            {
                timer1.Enabled = false;
                segundos = 0;
                String cadenaBuscar = tBQRAuto.Text;
                String[] vector = cadenaBuscar.Split('x');
                String sesion = vector[0];

                // Estos replaces son para usar el escanner.
                sesion = sesion.Replace("'", "-");
                sesion = sesion.Replace("?", ":");

                // Este es para poder introducirlo a mano.
                sesion = sesion.Replace('_', ':');

                int codigo = cnx.OcuparButaca(sesion, vector[1], vector[2], vector[3]);

                if (codigo == 1)
                {
                    panelValidacion.BackColor = Color.Green;
                    MessageBox.Show("Butaca ocupada con éxito", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    panelValidacion.BackColor = Color.Red;
                    MessageBox.Show("No se ha podido ocupar la butaca", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                tBQRAuto.Focus();
                tBQRAuto.Text = "";
                panelValidacion.BackColor = Color.White;
            }
        }
    }
}
