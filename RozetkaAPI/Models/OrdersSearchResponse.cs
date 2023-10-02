using RozetkaAPI.ModelsRozetka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaAPI.Models
{
    public class OrdersSearchResponse
    {
        public bool success { get; set; }
        public ContentOrdersSearch content { get; set; }
    }

    public class ContentOrdersSearch
    {
        public List<Order> orders { get; set; }
        public Meta _meta { get; set; }
    }
}
