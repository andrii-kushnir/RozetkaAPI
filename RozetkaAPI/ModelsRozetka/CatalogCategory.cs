﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaAPI.ModelsRozetka
{
    public class CatalogCategory
    {
        public int? id { get; set; }
        public int category_id { get; set; }
        public string name { get; set; }
        public int parent_id { get; set; }
    }
}
