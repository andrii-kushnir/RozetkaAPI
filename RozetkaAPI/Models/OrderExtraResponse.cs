using RozetkaAPI.ModelsRozetka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaAPI.Models
{

    public class OrderExtraResponse
    {
        public bool success { get; set; }
        public OrderWithExpand content { get; set; }
    }
}
