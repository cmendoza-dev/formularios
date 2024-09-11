using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Modelo;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //listaProductos(txtBuscar.Text);

        private void Form1_Load(object sender, EventArgs e)
        {
           LoadData();
        }
        //Mostrar solo aquellos productos que han sido pedidos más de 20 veces.
        private void LoadData()
        {
            using (NegociosEntities BD = new NegociosEntities())
            {
                var query = BD.DETALLEPEDIDO
                    .GroupBy(detail => detail.PRODUCTO.NombreProducto)
                    .Select(group => new
                    {
                        ProductName = group.Key,
                        OrderCount = group.Count()
                    })
                    .Where(group => group.OrderCount > 20)
                    .ToList();

                dataGridView1.DataSource = query;
            }
        }

        void listaProductos(string dato)
        {
            try
            {
                using (NegociosEntities BD = new NegociosEntities())
                {
                    var sql = from p in BD.PRODUCTO
                              where p.NombreProducto.Contains(dato)
                              select new
                              {
                                  p.IdProducto,
                                   p.NombreProducto,
                                   p.PrecioUnidad,
                                   p.UnidadesEnExistencia,
                                   p.CATEGORIA.NombreCategoria
                              };
                    this.dataGridView1.DataSource = sql.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //listaProductos(txtBuscar.Text);
        }
    }
}
