using PozetkaAPI.ModelsRozetka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozetkaAPI.Models
{
    public class ProductResponse
    {
        public bool success { get; set; }
        public ContentProduct content { get; set; }
    }

    public class ContentProduct
    {
        public List<Item> items { get; set; }
        public MetaProduct _meta { get; set; }
    }

    public class MetaProduct
    {
        public int totalCount { get; set; }
        public int pageCount { get; set; }
        public int currentPage { get; set; }
        public int perPage { get; set; }
    }
}
