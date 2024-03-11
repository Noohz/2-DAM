using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Farmacia_version_2._0
{
    public partial class FormularioPrincipal : Form
    {
        ClaseConectarBD cnx = new ClaseConectarBD();
        List<ClaseMedicamento> listaMedicamento = new List<ClaseMedicamento>();
        List<ClaseMedicamento> listaCesta = new List<ClaseMedicamento>();
        List<ClaseMedicamento> MedEncontrados = new List<ClaseMedicamento>();
        List<ClaseTarjetaSanitaria> listaTarjetas = new List<ClaseTarjetaSanitaria>();
        List<ClaseTratamiento> listaTratamientos = new List<ClaseTratamiento>();

        public FormularioPrincipal()
        {
            InitializeComponent();

        }

        private void btnGestion_Click(object sender, EventArgs e)
        {

        }

        private void grbFuncionalidad_Enter(object sender, EventArgs e)
        {

        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {
            listaMedicamento = cnx.listar();
            cargarTPV(listaMedicamento);
            grbAcceso.Focus();
        }

        private void cargarTPV(List<ClaseMedicamento> listaMedicamento)
        {
            int filas = Convert.ToInt32(numericUpDownFilas.Value);
            int columnas = Convert.ToInt32(numericUpDownColumnas.Value);
            int nTabs = listaMedicamento.Count / (filas * columnas);

            int indiceLista = 0;

            for (int indicePaneles = 0; indicePaneles < nTabs; indicePaneles++)
            {
                TabPage tp = new TabPage("Hoja " + (indicePaneles + 1));

                // Dentro del tabPage construyo un TableLayoutPanel.
                TableLayoutPanel tlp = new TableLayoutPanel();
                tlp.AutoSize = true;
                tlp.RowCount = filas;
                tlp.ColumnCount = columnas;
                tp.Controls.Add(tlp);
                tabControl_Med.Controls.Add(tp);


                int anchoContenedor = tabControl_Med.Width - 35;
                int altoContenedor = tabControl_Med.Height - 50;

                // Crear los botones dentro de tlp y añadir la imagen de los medicamentos.
                for (int contMed = 0; contMed < filas * columnas; contMed++)
                {
                    Button btnX = new Button();
                    btnX.Height = altoContenedor / filas;
                    btnX.Width = anchoContenedor / columnas;
                    tlp.Controls.Add(btnX);

                    btnX.Tag = listaMedicamento[indiceLista].Nombre;

                    // Evento de los botones.
                    btnX.MouseHover += BtnX_MouseHover;
                    btnX.Click += BtnX_Click;

                    try
                    {
                        // Añadir la imagen del medicamento.
                        MemoryStream ms = new MemoryStream(listaMedicamento[indiceLista].Imagen);

                        btnX.BackgroundImage = System.Drawing.Image.FromStream(ms);
                        btnX.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar la imagen " + ex.Message);
                    }

                    indiceLista++;
                }
            }
        }

        private void BtnX_Click(object sender, EventArgs e)
        {
            Button btnX = (Button)sender;
            string nombreMedicamento = btnX.Tag.ToString();

            ClaseMedicamento medicamentoSeleccionado = null;

            foreach (var medicamento in listaMedicamento)
            {
                if (medicamento.Nombre == nombreMedicamento)
                {
                    medicamentoSeleccionado = medicamento;
                    break;
                }
            }

            if (medicamentoSeleccionado != null)
            {
                listaCesta.Add(medicamentoSeleccionado);
                dtgCestaCompra.Rows.Add(medicamentoSeleccionado.Nombre, medicamentoSeleccionado.Precio);

                decimal totalPagar = 0;
                foreach (DataGridViewRow row in dtgCestaCompra.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        totalPagar += Convert.ToDecimal(row.Cells[1].Value);
                    }
                }
                lbTotalPagar.Text = totalPagar.ToString() + "€";
            }
        }

        private void BtnX_MouseHover(object sender, EventArgs e)
        {
            Button btnX = (Button)sender;

            foreach (ClaseMedicamento cM in listaMedicamento)
            {
                if (cM.Nombre == btnX.Tag.ToString())
                {
                    lbNombre.Text = cM.Nombre;
                    lbPrecio.Text = cM.Precio.ToString();
                    lbStockMin.Text = cM.StockMin.ToString();
                    lbStockActual.Text = cM.StockAct.ToString();
                }
            }
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string dni = txtdni.Text;
                string pwd = txtPwd.Text;

                string contrasenia = CrearMD5(pwd);
                ClaseEmpleado emp = cnx.buscarUsuario(dni, contrasenia);

                try
                {
                    if (!string.IsNullOrEmpty(emp.Dni))
                    {
                        grbFuncionalidad.Enabled = true;
                        grbAccesorio.Enabled = true;
                        tabControl_Med.Enabled = true;
                        dtgCestaCompra.Enabled = true;

                        grbAcceso.Enabled = false;
                        txtdni.Text = "";
                        txtPwd.Text = "";

                        if (emp.Nivel == 1)
                        {
                            MessageBox.Show("Nivel de usuario: Administrador", "Sesión iniciada correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (emp.Nivel == 2)
                        {
                            MessageBox.Show("Nivel de usuario: Trabajador", "Sesión iniciada correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al iniciar sesión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormularioPrincipal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                grbFuncionalidad.Enabled = false;
                grbAccesorio.Enabled = false;
                tabControl_Med.Enabled = false;

                grbAcceso.Enabled = true;
            }
        }

        public static string CrearMD5(string pwd)
        {
            // se pasa como parámetro el contenido del cuadro de texto pwd.txt
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pwd);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // convertir el array de byte en un string hexadecimal
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    //x2 es un argumento, parámetro para decir que se formatea en hexadecimal
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().ToLower();
            }
        }

        private void tabControl_Med_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {


        }

        private void mandar_mail(string pdfTicket)
        {

        }

        //private string imprimirTicket()
        //{


        //}

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            listaMedicamento.Clear();
            listaMedicamento = cnx.listar();
            tabControl_Med.Controls.Clear();
            cargarTPV(listaMedicamento);
        }

        private void numericUpDownFilas_ValueChanged(object sender, EventArgs e)
        {
            listaMedicamento.Clear();
            listaMedicamento = cnx.listar();
            tabControl_Med.Controls.Clear();
            cargarTPV(listaMedicamento);
        }

        private void numericUpDownColumnas_ValueChanged(object sender, EventArgs e)
        {
            listaMedicamento.Clear();
            listaMedicamento = cnx.listar();
            tabControl_Med.Controls.Clear();
            cargarTPV(listaMedicamento);
        }

        private void txtBuscarNombre_TextChanged(object sender, EventArgs e)
        {
            string medicamentoBuscado = txtBuscarNombre.Text.Trim().ToLower();

            tabControl_Med.TabPages.Clear();

            int indicePaneles = 0;
            TabPage tabPage = new TabPage("Hoja " + (indicePaneles + 1));

            int filas = Convert.ToInt32(numericUpDownFilas.Value);
            int columnas = Convert.ToInt32(numericUpDownColumnas.Value);

            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.AutoSize = true;
            tlp.RowCount = filas;
            tlp.ColumnCount = columnas;

            foreach (ClaseMedicamento cM in listaMedicamento)
            {
                if (cM.Nombre.ToLower().StartsWith(medicamentoBuscado))
                {
                    
                                     
                    int anchoContenedor = tabControl_Med.Width - 35;
                    int altoContenedor = tabControl_Med.Height - 50;

                    Button btnX = new Button();

                    btnX.Height = altoContenedor / filas;
                    btnX.Width = anchoContenedor / columnas;
                    btnX.Tag = cM.Nombre;
                    


                    btnX.MouseHover += BtnX_MouseHover;
                    btnX.Click += BtnX_Click;

                    try
                    {
                        MemoryStream ms = new MemoryStream(cM.Imagen);
                        btnX.BackgroundImage = System.Drawing.Image.FromStream(ms);
                        btnX.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar la imagen " + ex.Message);
                    }

                    tlp.Controls.Add(btnX);
                }

            }
            tabPage.Controls.Add(tlp);
            tabControl_Med.TabPages.Add(tabPage);
            txtBuscarNombre.Focus();
        }

        private void txtCodigoBarra_TextChanged(object sender, EventArgs e)
        {
            string medicamentoBuscado = txtCodigoBarra.Text.Trim().ToLower();

            tabControl_Med.TabPages.Clear();

            int indicePaneles = 0;
            TabPage tabPage = new TabPage("Hoja " + (indicePaneles + 1));

            int filas = Convert.ToInt32(numericUpDownFilas.Value);
            int columnas = Convert.ToInt32(numericUpDownColumnas.Value);

            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.AutoSize = true;
            tlp.RowCount = filas;
            tlp.ColumnCount = columnas;

            foreach (ClaseMedicamento cM in listaMedicamento)
            {
                string indiceMedicamento = cM.Indice.ToString();

                if (indiceMedicamento.ToLower().StartsWith(medicamentoBuscado))
                {


                    int anchoContenedor = tabControl_Med.Width - 35;
                    int altoContenedor = tabControl_Med.Height - 50;

                    Button btnX = new Button();

                    btnX.Height = altoContenedor / filas;
                    btnX.Width = anchoContenedor / columnas;
                    btnX.Tag = cM.Nombre;



                    btnX.MouseHover += BtnX_MouseHover;
                    btnX.Click += BtnX_Click;

                    try
                    {
                        MemoryStream ms = new MemoryStream(cM.Imagen);
                        btnX.BackgroundImage = System.Drawing.Image.FromStream(ms);
                        btnX.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar la imagen " + ex.Message);
                    }

                    tlp.Controls.Add(btnX);
                }

            }
            tabPage.Controls.Add(tlp);
            tabControl_Med.TabPages.Add(tabPage);
            txtCodigoBarra.Focus();
        }

        private void dtgCestaCompra_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string nombreMedicamento = dtgCestaCompra.Rows[e.RowIndex].Cells[0].Value.ToString();

                DialogResult result = MessageBox.Show("¿Quieres eliminar el medicamento: " + nombreMedicamento + "?", "Eliminar Medicamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dtgCestaCompra.Rows.RemoveAt(e.RowIndex);

                    decimal totalPagar = 0;
                    foreach (DataGridViewRow row in dtgCestaCompra.Rows)
                    {
                        if (row.Cells[1].Value != null)
                        {
                            totalPagar += Convert.ToDecimal(row.Cells[1].Value);
                        }
                    }
                    lbTotalPagar.Text = totalPagar.ToString("C");
                }
            }
        }
    }
}
