using System.Windows.Forms;

namespace Rayuela
{
    public partial class ImagenURL : Form
    {
        public string textoTB;

        public ImagenURL()
        {
            InitializeComponent();

        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            textoTB = tBURL.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
