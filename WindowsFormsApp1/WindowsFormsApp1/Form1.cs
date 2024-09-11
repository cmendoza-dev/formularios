using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        Conexion.SQLConexion cn;

        public Form1()
        {
            InitializeComponent();
            cn  = new Conexion.SQLConexion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cn.VerificaConexion())
            {
                MessageBox.Show("Conexion OK");
            }
            else
            {
                MessageBox.Show("Conexion érronea");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cn.retornaDatosDesconectados("select * from producto");

        }
    }
}
