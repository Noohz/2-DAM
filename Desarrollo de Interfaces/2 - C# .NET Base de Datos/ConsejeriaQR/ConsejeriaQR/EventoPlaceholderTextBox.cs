using System.Drawing;
using System.Windows.Forms;

namespace ConsejeriaQR
{
    /// <summary>
    /// Clase que se encarga de añadir el "placeholder" que tienen los textBox de los forms "FormularioInicioSesion" y "FormularioRegistro".
    /// </summary>
    internal class EventoPlaceholderTextBox
    {
        private static string TEXTO_TEXTBOX_USUARIO = "Nombre de usuario";
        private static string TEXTO_TEXTBOX_CONTRASENIA = "Contraseña";

        /// <summary>
        /// Método que se encarga de eliminar el contenido del texto del textBox.
        /// </summary>
        /// <param name="textBox"> El textBox al que se le realizará el cambio. </param>
        /// <param name="texto"> El texto que recibe, en este caso siempre debería ser vacío. </param>
        public static void BorrarTexto(TextBox textBox, string texto)
        {
            if (textBox.Text.Equals(TEXTO_TEXTBOX_USUARIO) || textBox.Text.Equals(TEXTO_TEXTBOX_CONTRASENIA))
            {
                textBox.Text = texto;
                textBox.ForeColor = Color.FromKnownColor(KnownColor.WindowText);
            }            
        }

        /// <summary>
        /// Método que se encarga de añadir un "Placeholder" al textBox.
        /// </summary>
        /// <param name="textBox"> El textBox al que se le realizará el cambio. </param>
        /// <param name="texto"> El texto que debería aparecer en el "Placeholder". </param>
        public static void AñadirPlaceholder(TextBox textBox, string texto)
        {
            if (textBox.Text.Equals(""))
            {
                textBox.Text = texto;
                textBox.ForeColor = Color.FromKnownColor(KnownColor.GrayText);
            }            
        }

        /// <summary>
        /// Método que se encarga de gestionar los eventos que recibe mediante los parámetros para luego poder llamar al método correcto.
        /// </summary>
        /// <param name="sender"> Esto es el Control que ha llamado al evento, siempre debería ser un textBox. </param>
        /// <param name="texto"> El texto que se va a introducir en el textBox como "Placeholder". </param>
        public static void HandlePlaceholder(object sender, string texto)
        {
            if (sender is TextBox textBox)
            {
                if (textBox.Focused)
                {
                    BorrarTexto(textBox, texto);
                }
                else if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    AñadirPlaceholder(textBox, texto);
                }
            }
        }
    }
}
