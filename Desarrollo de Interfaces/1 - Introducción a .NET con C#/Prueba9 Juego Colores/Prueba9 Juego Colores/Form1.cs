// Aitor Ramos Sánchez

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Prueba9_Juego_Colores
{

    public partial class Form1 : Form
    {

        int contador = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // Opción 1: Cambiar botón de verde a rojo y después que vuelva a verde y pase al siguiente botón.
        private void btnOpcion1_Click(object sender, EventArgs e)
        {
            resetearBotones();

            contador = 0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Cuando ya pasa el rojo vuelve a verde. Todo lo que no sea posición inicial. Desactiva
            if (contador != 0)
            {
                flowLayoutPanel1.Controls[contador - 1].BackColor = Color.Green;
            }
            //empezar por aquí activando el rojo desde principio hasta el fin
            if (contador < flowLayoutPanel1.Controls.Count)
            {
                flowLayoutPanel1.Controls[contador].BackColor = Color.Red;
                contador++;
            }
            else
            {
                contador = 0;
            }
        }

        // Opción 2: Cambiar botón de verde a rojo y después que vuelva a verde y pase al siguiente botón pero empezando desde abajo.
        private void btnOpcion2_Click(object sender, EventArgs e)
        {
            resetearBotones();

            contador = flowLayoutPanel1.Controls.Count - 1;
            timer2.Start();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            //retroceso
            if (contador == 0)
            {
                flowLayoutPanel1.Controls[contador].BackColor = Color.Green;
            }
            //si llega a la última posición
            if (contador == flowLayoutPanel1.Controls.Count - 1)
            {
                flowLayoutPanel1.Controls[contador].BackColor = Color.Red;
            }
            //mientras no llegue a la última posición
            if (contador != 0)
            {
                //coloca el rojo
                flowLayoutPanel1.Controls[contador - 1].BackColor = Color.Red;
                //retorna al verde
                flowLayoutPanel1.Controls[contador].BackColor = Color.Green;
                contador--;
            }
            else
            {
                //vuelve al final
                contador = flowLayoutPanel1.Controls.Count - 1;
            }
        }

        // Opción 3: Va cambiando los botones a color rojo de 1 en 1 y después vuelve a cambiarlos a verde.
        private void btnOpcion3_Click(object sender, EventArgs e)
        {
            resetearBotones();

            contador = 0;
            timer3.Start();
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            //arrastra todos los colores si está en verde pasa a rojo. Siempre y cuando no llegue al final
            if (contador < flowLayoutPanel1.Controls.Count)
            {
                //si está verde pasa a rojo
                if (flowLayoutPanel1.Controls[contador].BackColor == Color.Green)
                {
                    flowLayoutPanel1.Controls[contador].BackColor = Color.Red;
                }
                //si está en rojo pasa a verde
                else if (flowLayoutPanel1.Controls[contador].BackColor == Color.Red)
                {
                    flowLayoutPanel1.Controls[contador].BackColor = Color.Green;
                }
                //avanzar
                contador++;
            }
            else
            {
                //resetear a 0 cuando el cursor llega hasta el final
                contador = 0;
            }
        }

        // Opción 4: Va cambiando los botones a color rojo de 1 en 1 y después vuelve a cambiarlos a verde pero empezando desde abajo.
        private void btnOpcion4_Click(object sender, EventArgs e)
        {
            resetearBotones();

            contador = flowLayoutPanel1.Controls.Count - 1;
            timer4.Start();
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            //si contador menor que 0 se va a la última posición del panel
            if (contador < 0)
            {
                contador = flowLayoutPanel1.Controls.Count - 1;
            }
            else
            {
                //si tiene botón rojo se pasa a verde
                if (flowLayoutPanel1.Controls[contador].BackColor == Color.Red)
                {
                    flowLayoutPanel1.Controls[contador].BackColor = Color.Green;
                }//si tiene color verde pasa a rojo
                else if (flowLayoutPanel1.Controls[contador].BackColor == Color.Green)
                {
                    flowLayoutPanel1.Controls[contador].BackColor = Color.Red;
                }
                //retrocede
                contador--;
            }
        }

        private void resetearBotones()
        {

            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();

            //recorrer todo el panel de botones y ponerlos a verde
            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                flowLayoutPanel1.Controls[i].BackColor = Color.Green;
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}

