using RozetkaAPI.ModelsRozetka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaAPI.Models
{
    public class OrderStatusesResponse
    {
        public bool success { get; set; }
        public ContentOrderStatuses content { get; set; }
    }

    public class ContentOrderStatuses
    {
        public List<OrderStatus> orderStatuses { get; set; }
        public Meta _meta { get; set; }
    }

    public class OrderStatus
    {
        public int id { get; set; }
        public string name { get; set; }
        public string name_uk { get; set; }
        public string name_en { get; set; }
        public int status_group { get; set; }
        public int status { get; set; }
        public string color { get; set; }
        public string title { get; set; }
        public List<StatusAvailable> status_available { get; set; }
    }

    public class StatusAvailable
    {
        public int parent_id { get; set; }
        public int child_id { get; set; }
        public int delivery_type { get; set; }
    }
}
