using Newtonsoft.Json;
using RozetkaAPI;
using RozetkaAPI.ModelsRozetka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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
            _cbPays.Items.AddRange(new string[] { "Усі онлайн-оплати", "Оплата карткою (RozetkaPay)", "GooglePay", "ApplePay" });
            _cbPays.SelectedIndex = 0;
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
            statuses[10] = "Відправлення протерміновано";
            statuses[11] = "Не прийшов за замовленням";
            statuses[12] = "Відмова при отриманні";
            statuses[13] = "Скасовано адміністратором";
            statuses[15] = "Некоректна ТТН";
            statuses[16] = "Немає в наявності/ брак";
            statuses[17] = "Не влаштовують умови оплати";
            statuses[18] = "Не вдалося зв'язатися";
            statuses[19] = "Замовлення повернено";
            statuses[20] = "Товар не підходить за характеристиками";
            statuses[24] = "Скасування. Не влаштовує доставка";
            statuses[25] = "Тестове замовлення";
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
            var statuses = ApiManager.Current.GetOrderStatus(Convert.ToInt32(_tbStatus.Text))?.content.orderStatuses.OrderBy(s => s.id).ToList();
            label5.Text = "Всього: " + statuses.Count;
            _dgvStatuses.DataSource = statuses;
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
            if (MessageBox.Show("Ви реально хочете змінити статус замовлення? Ця дія відбувається на ROZETKA.UA.", "Зміна статусу", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var order = ApiManager.Current.ChangeStatus(Convert.ToInt32(_tbId.Text), _cbOrderStatus.SelectedIndex);
            }
        }

        private void _bSendTTN_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(_tbTTN.Text))
                if (MessageBox.Show("Ви реально хочете послати номет NNY на ROZETKA.UA? Статус замовлення зміниться на 3(Комплектується. Дані підтверджені)", "Посилання TTN", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var result = ApiManager.Current.ChangeStatus(Convert.ToInt32(_tbId.Text), 0, _tbTTN.Text.Trim());
                }
        }

        private void _bGetMessagesOrder_Click(object sender, EventArgs e)
        {
            var chats = ApiManager.Current.GetMessagesOrder("orders", false)?.content.chats.OrderByDescending(o => o.created).ToList();
            _dgvMessages.DataSource = chats;
            label8.Text = "Всього: " + chats.Count;
        }

        private void _bGetMessagesSeller_Click(object sender, EventArgs e)
        {
            var chats = ApiManager.Current.GetMessagesOrder("items", false)?.content.chats.OrderByDescending(o => o.created).ToList();
            _dgvMessages.DataSource = chats;
            label8.Text = "Всього: " + chats.Count;
        }

        private void _bGetMessagesDeleted_Click(object sender, EventArgs e)
        {
            var chats = ApiManager.Current.GetMessagesOrder("deleted")?.content.chats.OrderByDescending(o => o.created).ToList();
            _dgvMessages.DataSource = chats;
            label8.Text = "Всього: " + chats.Count;
        }

        private void _bGetMessagesItem_Click(object sender, EventArgs e)
        {
            var itemComments = ApiManager.Current.GetMessagesItem()?.content.itemComments.OrderByDescending(o => o.created).ToList();
            _dgvMessages.DataSource = itemComments;
            label8.Text = "Всього: " + itemComments.Count;
        }

        private void _bSetMessagesAnswer_Click(object sender, EventArgs e)
        {
            var message = ApiManager.Current.SetMessagesAnswer(47161389, "Так, це тест №2! Дякуємо.", 995248);
        }

        private void _bOpenChat_Click(object sender, EventArgs e)
        {
            var chat = ApiManager.Current.OpenChat(46906557);
        }

        private void _bSetMessagesCount_Click(object sender, EventArgs e)
        {
            var chats = ApiManager.Current.GetMessagesCount();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var item = ApiManager.Current.GetItem(404103315);
        }

        private void _btOrdersForPay_Click(object sender, EventArgs e)
        {
            string idPay;
            switch (_cbPays.SelectedIndex)
            {
                case 0:
                    idPay = "4524,5307,5405";
                    break;
                case 1:
                    idPay = "4524";
                    break;
                case 2:
                    idPay = "5307";
                    break;
                case 3:
                    idPay = "5405";
                    break;
                default:
                    return;
            }
            var orders = ApiManager.Current.GetOrdersByPay(idPay)?.content.orders.Where(o => o.status_payment.status_payment_id == 2 && o.ttn != "").OrderByDescending(o => o.created).ToList();
            _orders = orders;
            label5.Text = "Всього: " + orders.Count;
            _dgvOrders.DataSource = orders;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var orders = ApiManager.Current.GetOrdersRozDeliveryAndCash()?.content.orders.ToList();
            _orders = orders;
            label5.Text = "Всього: " + orders.Count;
            _dgvOrders.DataSource = orders;

            //var pp = new RoutePoint()
            //{
            //    Point = "sd",
            //    Lat = 50.210834,
            //    Lon = 25.019667
            //};
            ////GetLocationAsync(pp).Wait();
            //Task.Run(async () => await GetLocationAsync(pp)).Wait();
            //MessageBox.Show(pp.Point);
        }

        public static async Task GetLocationAsync(RoutePoint point)
        {
            string result = null;
            try
            {
                var format = new NumberFormatInfo() { NumberDecimalSeparator = "." };
                var uri = $"http://nominatim.openstreetmap.org/reverse?format=json&lat={point.Lat.ToString(format)}&lon={point.Lon.ToString(format)}&layer=address";
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Referer", uri);
                var response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                var responseStr = await response.Content.ReadAsStringAsync();
                var address = JsonConvert.DeserializeObject<LocarionOpenstreetmap>(responseStr);
                var ad = address.address;
                result = $"{ad.city ?? ad.village ?? ad.state + ", " + ad.district}, {(ad.road == null ? "" : ad.road + ", ")}{ad.house_number}";
            }
            catch (Exception) { }
            if (result != null)
                point.Point = result;
        }

        public class RoutePoint
        {
            public string Point { get; set; }
            public Double Lat { get; set; }
            public Double Lon { get; set; }
            public DateTime Time { get; set; }
        }


        public class LocarionOpenstreetmap
        {
            public string osm_type { get; set; }
            public string lat { get; set; }
            public string lon { get; set; }
            public string addresstype { get; set; }
            public string name { get; set; }
            public string display_name { get; set; }
            public Address address { get; set; }
        }

        public class Address
        {
            public string house_number { get; set; }
            public string road { get; set; }
            public string village { get; set; }
            public string city { get; set; }
            public string district { get; set; }
            public string state { get; set; }
            public string postcode { get; set; }
        }
    }
}
