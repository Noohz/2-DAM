using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ExamenRec
{
    public partial class Form1 : Form
    {
        ConectarBD cnx = new ConectarBD();
        List<ClaseAlumno> listaAlumnos = new List<ClaseAlumno>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listaAlumnos = cnx.listar();
            cargarRayuela(listaAlumnos);
        }

        private void cargarRayuela(List<ClaseAlumno> listaAlumnos)
        {
            int filas = 4;
            int columnas = 5;
            int nTabs = listaAlumnos.Count / (filas * columnas);

            int indiceLista = 0;

            for (int indicePaneles = 0; indicePaneles < nTabs; indicePaneles++)
            {
                TabPage tp = new TabPage("DAM " + (indicePaneles + 1));

                TableLayoutPanel tlp = new TableLayoutPanel();
                tlp.AutoSize = true;
                tlp.RowCount = filas;
                tlp.ColumnCount = columnas;
                tp.Controls.Add(tlp);
                tabControl1.Controls.Add(tp);


                int anchoContenedor = tabControl1.Width - 35;
                int altoContenedor = tabControl1.Height - 50;

                for (int contMed = 0; contMed < filas * columnas; contMed++)
                {
                    Button btnX = new Button();
                    btnX.Height = altoContenedor / filas;
                    btnX.Width = anchoContenedor / columnas;
                    tlp.Controls.Add(btnX);

                    btnX.Tag = listaAlumnos[indiceLista].Nombre;

                    btnX.Click += BtnX_Click;

                    try
                    {                        
                        MemoryStream ms = new MemoryStream(listaAlumnos[indiceLista].Foto);

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
            Button btnx = (Button)sender;
            String nombreAlumno = btnx.Tag.ToString();

            ClaseAlumno alumnoSeleccionado = null;

            foreach (var alumno in listaAlumnos)
            {
                if (alumno.Nombre == nombreAlumno)
                {
                    alumnoSeleccionado = alumno;

                    InformacioUsuario iU = new InformacioUsuario(alumnoSeleccionado);
                    iU.ShowDialog();
                    this.Hide();
                    break;
                }
            }
        }
    }
}
