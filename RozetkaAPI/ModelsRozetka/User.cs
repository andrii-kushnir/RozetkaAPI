﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaAPI.ModelsRozetka
{
    public class User
    {
        public int id { get; set; }
        public bool has_email { get; set; }
        public string contact_fio { get; set; }
        public string email { get; set; }
    }
}
