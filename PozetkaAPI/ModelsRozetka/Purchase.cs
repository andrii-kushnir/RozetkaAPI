using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozetkaAPI.ModelsRozetka
{
    public class Purchase
    {
        public int id { get; set; }
        public string cost { get; set; }
        public string cost_with_discount { get; set; }
        public string price { get; set; }
        public string price_with_discount { get; set; }
        public int quantity { get; set; }
        public int item_id { get; set; }
        public string item_name { get; set; }
        public int kit_id { get; set; }
        public Item item { get; set; }
        public object conf_details { get; set; }
        public object ttn { get; set; }
        public object order_status { get; set; }
        public int status { get; set; }
        public bool is_additional_item { get; set; }
    }
}
