using PozetkaAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RozetkaUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ApiManager.Current.Login();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ApiManager.Current.Logout();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var order = ApiManager.Current.GetOrderWithExtra(780274619).content;
            //_dgvOrders.DataSource = order;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var orders = ApiManager.Current.GetOrdersSearch().content.orders.OrderByDescending(o => o.changed).ToList();
            _dgvOrders.DataSource = orders;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var statuses = ApiManager.Current.GetOrderStatus().content.orderStatuses.OrderBy(s => s.id).ToList();
            _dgvOrders.DataSource = statuses;
        }
    }
}
