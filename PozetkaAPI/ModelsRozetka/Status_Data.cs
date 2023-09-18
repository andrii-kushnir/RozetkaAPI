using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozetkaAPI.ModelsRozetka
{
    public class Status_Data
    {
        public int id { get; set; }
        public string name { get; set; }
        public string name_ua { get; set; }
        public string name_en { get; set; }
        public int type { get; set; }
        public int status { get; set; }
        public string color { get; set; }
    }
}
