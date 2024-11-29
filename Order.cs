using RozetkaAPI.ModelsRozetka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderR = RozetkaAPI.ModelsRozetka.Order;

namespace RozetkaUI
{
    public partial class Order : Form
    {
        private OrderR _order;

        public Order()
        {
            InitializeComponent();
        }

        public Order(OrderR order) : this()
        {
            _order = order;
        }

        private void Order_Load(object sender, EventArgs e)
        {
            textBox1.Text = _order.id.ToString();
            textBox3.Text = _order.created;
            textBox4.Text = _order.user_phone;
            textBox7.Text = _order.amount_with_discount;
            textBox8.Text = _order.cost_with_discount;
            textBox11.Text = _order.status.ToString();
            richTextBox1.Text = _order.comment;
            if (_order is OrderWithExpand orderExpand)
            {
                textBox2.Text = orderExpand.user.contact_fio;
                var city = orderExpand.delivery.city?.title == null ? "" : Regex.Replace(orderExpand.delivery.city.title, @"Селище міського типу", @"смт");
                textBox5.Text = $"{city}, {orderExpand.delivery.place_street} {(orderExpand.delivery.place_house ?? "")},{(orderExpand.delivery.place_flat ?? "")}{(orderExpand.delivery.place_number != null ? ", Відділення № " + orderExpand.delivery.place_number : "")}";
                textBox6.Text = orderExpand.user.has_email && orderExpand.user.email != "true" ? orderExpand.user.email : ""; ;
                _dgvPurchases.DataSource = orderExpand.purchases;
                textBox9.Text = orderExpand.recipient_title.full_name == orderExpand.user.contact_fio ? orderExpand.user.contact_fio : $"{orderExpand.recipient_title.full_name} ({orderExpand.recipient_phone})";
                switch (orderExpand.user_rating)
                {
                    case null:
                        textBox10.Text = "Мало замавлень у покупця";
                        break;
                    case 1:
                        textBox10.Text = "Високий відсоток викупу замовлень";
                        break;
                    case 2:
                        textBox10.Text = "Середній відсоток викупу замовлень";
                        break;
                    case 3:
                        textBox10.Text = "Низький відсоток викупу замовлень";
                        break;
                    default:
                        textBox10.Text = "";
                        break;
                }
            }
        }
    }
}
