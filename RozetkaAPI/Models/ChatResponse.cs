using RozetkaAPI.ModelsRozetka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozetkaAPI.Models
{
    public class ChatResponse
    {
        public bool success { get; set; }
        public Chat content { get; set; }
    }
}
