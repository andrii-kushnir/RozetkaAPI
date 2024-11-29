using RozetkaAPI.ModelsRozetka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozetkaAPI.Models
{
    public class MessagesItemResponse
    {
        public bool success { get; set; }
        public ContentMessagesItem content { get; set; }
    }

    public class ContentMessagesItem
    {
        public List<ItemComments> itemComments { get; set; }
        public Meta _meta { get; set; }
    }
}
