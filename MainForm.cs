using RozetkaAPI;
using RozetkaAPI.ModelsRozetka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderR = RozetkaAPI.ModelsRozetka.Order;

namespace RozetkaUI
{
    public partial class MainForm : Form
    {
        private object _orders;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _cbOrderType.Items.AddRange(new string[] { "Всі замовлення", "В обробці", "Успішно завершені", "Нові", "Доставляються", "Неуспішно завершені" });
            _cbOrderType.SelectedIndex = 0;
            string[] statuses = new string[52];
            for (var i = 0; i < 52; i++)
                statuses[i] = "-";
            statuses[1] = "Нове замовлення";
            statuses[2] = "Комплектується. Дані підтверджені";
            statuses[3] = "Передано до служби доставки";
            statuses[4] = "Доставляється";
            statuses[5] = "Очікує в пункті самовивозу";
            statuses[6] = "Замовлення виконано";
            statuses[7] = "Не оброблено продавцем протягом дня";
            statuses[13] = "Скасовано адміністратором";
            statuses[15] = "Некоректна ТТН";
            statuses[16] = "Немає в наявності/ брак";
            statuses[18] = "Не вдалося зв'язатися";
            statuses[26] = "Обробляється менеджером";
            statuses[40] = "Клієнт передумав";
            statuses[45] = "Клієнт відмовився";
            statuses[49] = "Повторне замовлення";
            _cbOrderStatus.Items.AddRange(statuses);
            _cbOrderStatus.SelectedIndex = 1;
            _cbOrderStatus1.Items.AddRange(statuses);
            _cbOrderStatus1.SelectedIndex = 1;
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

        private void button5_Click(object sender, EventArgs e)
        {
            var statuses = ApiManager.Current.GetOrderStatus()?.content.orderStatuses.OrderBy(s => s.id).ToList();
            label5.Text = "Всього: " + statuses.Count;
            _dgvOrders.DataSource = statuses;
        }

        private void _btOrders_Click(object sender, EventArgs e)
        {
            //var orders = ApiManager.Current.GetOrdersSearch(_cbOrderType.SelectedIndex + 1)?.content.orders.OrderByDescending(o => o.changed).ToList();
            //_orders = orders;
            //_dgvOrders.DataSource = orders;
        }

        private void _btOrdersExpand_Click(object sender, EventArgs e)
        {
            var orders = ApiManager.Current.GetOrdersExpandSearch(_cbOrderType.SelectedIndex + 1)?.content.orders.OrderByDescending(o => o.created).ToList();
            _orders = orders;
            label5.Text = "Всього: " + orders.Count;
            _dgvOrders.DataSource = orders;
        }

        private void _btOrdersForStatus_Click(object sender, EventArgs e)
        {
            var orders = ApiManager.Current.GetOrdersByStatuserSearch(_cbOrderStatus.SelectedIndex)?.content.orders.OrderByDescending(o => o.created).ToList();
            _orders = orders;
            label5.Text = "Всього: " + orders.Count;
            _dgvOrders.DataSource = orders;
        }

        private void _dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OrderR pool = null;
            if (_orders is List<OrderR> orders)
            {
                pool = orders[e.RowIndex];
            }
            else if (_orders is List<OrderWithExpand> ordersE)
            {
                pool = ordersE[e.RowIndex];
            }
            var win = new Order(pool);
            win.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var order = ApiManager.Current.GetOneOrder(Convert.ToInt32(_tbId.Text));
            var win = new Order(order);
            win.Show();
        }

        private void _btChangeStatus_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви реально хочете змінити статус замовлення? Ця дія відбувається на ROZETKA.UA.", "Зміна статусу", MessageBoxButtons.YesNo) ==  DialogResult.Yes)
            {
                var order = ApiManager.Current.ChangeStatus(Convert.ToInt32(_tbId.Text), _cbOrderStatus.SelectedIndex);
            }
        }
    }
}
