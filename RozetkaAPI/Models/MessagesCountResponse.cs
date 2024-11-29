using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozetkaAPI.Models
{
    public class MessagesCountResponse
    {
        public bool success { get; set; }
        public ContentMessagesCount content { get; set; }
    }

    public class ContentMessagesCount
    {
        public int totalUnread { get; set; }
        public int totalUnreadMessages { get; set; }
        public int total { get; set; }
        public int ordersChatUnread { get; set; }
        public int ordersChatAll { get; set; }
        public int orderMessagesUnread { get; set; }
        public int itemSellerMessagesUnread { get; set; }
        public int itemsChatUnread { get; set; }
        public int itemsChatFeatured { get; set; }
        public int itemsChatAll { get; set; }
        public int sellerChatUnread { get; set; }
        public int sellerChatAll { get; set; }
        public int deletedChats { get; set; }
        public int customerRequestsUnread { get; set; }
        public int customerRequestsAll { get; set; }
        public int customerRequestsInProcessingCount { get; set; }
        public int orderRefundAll { get; set; }
        public int orderRefundRead { get; set; }
        public int orderRefundUnread { get; set; }
    }
}
