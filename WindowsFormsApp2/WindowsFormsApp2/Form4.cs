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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            LoadYears();
        }

        private void LoadYears()
        {
            using (NegociosEntities BD = new NegociosEntities())
            {
                var years = BD.PEDIDO
                    .Select(order => order.FechaPedido.Year)
                    .Distinct()
                    .OrderBy(year => year)
                    .ToList();

                cbxYear.DataSource = years;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (NegociosEntities BD = new NegociosEntities())
            {
                var selectedYear = (int)cbxYear.SelectedItem;

                var query = BD.PEDIDO
                    .Where(order => order.FechaPedido.Year == selectedYear)
                    .GroupBy(order => order.IdEmpleado)
                    .Select(group => new
                    {
                        EmployeeID = group.Key,
                        TotalSales = group.Sum(order => order.DETALLEPEDIDO.
                        Sum(detail => detail.Cantidad * detail.PrecioUnidad))
                    })
                    .OrderByDescending(result => result.TotalSales)
                    .ToList();

                dataGridView1.DataSource = query;
            }
        }
    }
}
