using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaAPI.ModelsRozetka
{
    public class OrderStatus
    {
        public int id { get; set; }
        public string name { get; set; }
        public string name_ua { get; set; }
        public string name_uk { get; set; }
        public string name_en { get; set; }
        public int status_group { get; set; }
        public int status { get; set; }
        public string color { get; set; }
        public string title { get; set; }
    }
}
