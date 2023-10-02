using RozetkaAPI.ModelsRozetka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaAPI.Models
{
    public class OrdersSearchExpandResponse
    {
        public bool success { get; set; }
        public ContentOrdersSearchExpand content { get; set; }
    }

    public class ContentOrdersSearchExpand
    {
        public List<OrderWithExpand> orders { get; set; }
        public Meta _meta { get; set; }
    }
}
