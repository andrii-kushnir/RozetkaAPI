using RozetkaAPI.ModelsRozetka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozetkaAPI.Models
{
    public class MessagesOrderResponse
    {
        public bool success { get; set; }
        public ContentMessagesOrder content { get; set; }
    }

    public class ContentMessagesOrder
    {
        public List<Chat> chats { get; set; }
        public Meta _meta { get; set; }
    }
}
