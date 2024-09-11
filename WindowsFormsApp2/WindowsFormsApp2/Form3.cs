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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            using (NegociosEntities BD = new NegociosEntities())
            {
                var categories = BD.CATEGORIA
                    .Select(c => new { c.IdCategoria, c.NombreCategoria })
                    .OrderBy(c => c.NombreCategoria)
                    .ToList();

                cbxCategoria.DataSource = categories;
                cbxCategoria.DisplayMember = "NombreCategoria";
                cbxCategoria.ValueMember = "IdCategoria";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (NegociosEntities BD = new NegociosEntities())
            {
                var selectedCategory = (int)cbxCategoria.SelectedValue;

                var query = BD.PRODUCTO
                    .Where(product => product.IdCategoria == selectedCategory)
                    .Select(product => new
                    {
                        product.NombreProducto,
                        AverageOrderPrice = product.DETALLEPEDIDO.Average(detail => detail.PrecioUnidad)
                    })
                    .OrderBy(result => result.NombreProducto)
                    .ToList();

                dataGridView1.DataSource = query;
            }
        }

        private void cbxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
