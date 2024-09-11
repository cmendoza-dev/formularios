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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            using (NegociosEntities BD = new NegociosEntities())
            {
                var customers = BD.CLIENTE
                    .Select(c => new { c.IdCliente, c.NombreCia})
                    .OrderBy(c => c.NombreCia)
                    .ToList();

                cbxCliente.DataSource = customers;
                cbxCliente.DisplayMember = "NombreCia";
                cbxCliente.ValueMember = "IdCliente";
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            using (NegociosEntities BD = new NegociosEntities())
            {
                var selectedCustomer = cbxCliente.SelectedValue.ToString();
                var startDate = dtpStart.Value;
                var endDate = dtpEnd.Value;

                var query = BD.PEDIDO
                    .Where(order => order.IdCliente == selectedCustomer &&
                                    order.FechaPedido >= startDate &&
                                    order.FechaPedido <= endDate)
                    .OrderBy(order => order.FechaPedido)
                    .Select(order => new
                    {
                        order.IdPedido,
                        order.FechaPedido,
                        TotalAmount = order.DETALLEPEDIDO.Sum(detail => detail.Cantidad * detail.PrecioUnidad)
                    })
                    .ToList();

                dataGridView1.DataSource = query;
            }
        }

        private void cbxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
