using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaAPI.ModelsRozetka
{
    public class ChatMessage
    {
        public int id { get; set; }
        public int chat_id { get; set; }
        public string body { get; set; }
        public string created { get; set; }
        public string read { get; set; }
        public string receiver_id { get; set; }
        public int sender { get; set; }
        public object seller { get; set; }
        public string seller_id { get; set; }
        public int status { get; set; }
    }
}
