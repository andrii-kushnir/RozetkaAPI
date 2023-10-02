using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaAPI.ModelsRozetka
{
    public class OrderStatusPayment
    {
        public int order_id { get; set; }
        public int status_payment_id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public int value { get; set; }
        public int? payment_invoice_id { get; set; }
        public string created_at { get; set; }
    }
}
