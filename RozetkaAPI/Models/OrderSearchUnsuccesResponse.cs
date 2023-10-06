using RozetkaAPI.ModelsRozetka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozetkaAPI.Models
{
    public class OrderSearchUnsuccesResponse
    {
        public bool success { get; set; }
        public ContentOrderSearchUnsucces content { get; set; }
    }

    public class ContentOrderSearchUnsucces
    {
        public List<OrderWithStatusHistory> orders { get; set; }
        public Meta _meta { get; set; }
    }
}
