using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozetkaAPI.Models
{
    public class OrderChangeResponse
    {
        public bool success { get; set; }
        public ContentOrderChangeResponse content { get; set; }
    }

    public class ContentOrderChangeResponse
    {
        public int id { get; set; }
        public string created { get; set; }
        public string changed { get; set; }
        public int status { get; set; }
        public int status_group { get; set; }
    }
}
