using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaAPI.ModelsRozetka
{
    public class OrderStatusHistory
    {
        public int status_id { get; set; }
        public string created { get; set; }
        public OrderStatus status { get; set; }
    }
}
