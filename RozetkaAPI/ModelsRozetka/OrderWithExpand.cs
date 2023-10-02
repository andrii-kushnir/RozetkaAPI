using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaAPI.ModelsRozetka
{
    public class OrderWithExpand : Order
    {
        public Chat chatUser { get; set; }
        public List<ChatMessage> chatMessages { get; set; }
        public User user { get; set; }
        public Delivery delivery { get; set; }
        public List<Purchase> purchases { get; set; }
        public bool is_access_change_order { get; set; }
        public string payment_status { get; set; }
        public OrderStatusPayment status_payment { get; set; }
        public string payment_type { get; set; }
        public string payment_type_name { get; set; }
        public string payment_type_title { get; set; }
        public bool can_edit { get; set; }
        public List<OrderStatusHistory> order_status_history { get; set; }
        public string credit_status { get; set; }
        public bool is_free_delivery { get; set; }
        public bool can_create_invoice { get; set; }
    }
}
