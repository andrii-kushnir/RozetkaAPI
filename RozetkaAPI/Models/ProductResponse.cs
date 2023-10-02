using RozetkaAPI.ModelsRozetka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaAPI.Models
{
    public class ProductResponse
    {
        public bool success { get; set; }
        public ContentProduct content { get; set; }
    }

    public class ContentProduct
    {
        public List<Item> items { get; set; }
        public Meta _meta { get; set; }
    }
}
