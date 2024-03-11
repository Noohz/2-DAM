using System;
using System.Collections;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace ConectarBD
{
    public partial class Form1 : Form
    {
        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader datos;
        ArrayList lista = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion = new MySqlConnection();

            conexion.ConnectionString = "Server=localhost;Port=3306;DataBase=dam2023;user=root;Pwd='';old guids=true;";
            conexion.Open();
            String cadenaSql = "show tables";
            comando = new MySqlCommand(cadenaSql, conexion);
            datos = comando.ExecuteReader();
            while (datos.Read())
            {
                listBox1.Items.Add(datos.GetString(0));
            }

            conexion.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            conexion.Open();
            String cadenaSql = "select * from " + listBox1.SelectedItem.ToString();
            comando = new MySqlCommand(cadenaSql, conexion);
            datos = comando.ExecuteReader();
            listBox2.Items.Clear();
            while (datos.Read())
            {
                listBox2.Items.Add(datos.GetString(0));
                lista.Add(datos.GetString(1));
            }

            conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.lista2 = lista;
            f2.Show();

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}

