using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaAPI.ModelsRozetka
{
    public class Chat
    {
        public int id { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public string subject { get; set; }
        public User user { get; set; }
        public string read_market { get; set; }
        public int trash_market { get; set; }
        public int star_market { get; set; }
        public int order_id { get; set; }
        public int type { get; set; }
        public int? item_id { get; set; }
        public int user_id { get; set; }
        public int unread_messages_count { get; set; }
    }
}
