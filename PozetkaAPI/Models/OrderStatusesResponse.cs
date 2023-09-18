using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozetkaAPI.Models
{
    public class OrderStatusesResponse
    {
        public bool success { get; set; }
        public ContentOrderStatuses content { get; set; }
    }

    public class ContentOrderStatuses
    {
        public List<OrderStatus> orderStatuses { get; set; }
        public MetaOrderStatuses _meta { get; set; }
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
    }

    public class MetaOrderStatuses
    {
        public int totalCount { get; set; }
        public int pageCount { get; set; }
        public int currentPage { get; set; }
        public int perPage { get; set; }
    }
}
