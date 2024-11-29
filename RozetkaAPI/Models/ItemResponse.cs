using RozetkaAPI.ModelsRozetka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozetkaAPI.Models
{
    public class ItemResponse
    {
        public bool success { get; set; }
        public Item content { get; set; }
    }
}
