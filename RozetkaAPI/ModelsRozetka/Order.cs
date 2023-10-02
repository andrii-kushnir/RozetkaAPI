using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaAPI.ModelsRozetka
{
    public class Order
    {
        public int id { get; set; }
        public int market_id { get; set; }
        public string created { get; set; }
        public string changed { get; set; }
        public string amount { get; set; }
        public string amount_with_discount { get; set; }
        public string cost { get; set; }
        public string cost_with_discount { get; set; }
        public int status { get; set; }
        public int status_group { get; set; }
        public List<Items_Photos> items_photos { get; set; }
        public List<Seller_Comment> seller_comment { get; set; }
        public string seller_comment_created { get; set; }
        public string current_seller_comment { get; set; }
        public string comment { get; set; }
        public string user_phone { get; set; }
        public int? user_rating { get; set; }
        public User_Title user_title { get; set; }
        public string recipient_phone { get; set; }
        public Recipient_Title recipient_title { get; set; }
        public int from_warehouse { get; set; }
        public string ttn { get; set; }
        public int total_quantity { get; set; }
        public bool can_copy { get; set; }
        public int created_type { get; set; }
        public bool is_viewed { get; set; }
        public int callback_off { get; set; }
        public bool is_fulfillment { get; set; }
        public int? duplicate_order_id { get; set; }
        public bool? can_prolong { get; set; }
        public int is_review_request_send { get; set; }
        public string review_request_status { get; set; }
    }

    public class Items_Photos
    {
        public int id { get; set; }
        public string url { get; set; }
        public string item_name { get; set; }
        public string item_url { get; set; }
        public string item_price { get; set; }

    }

    public class Seller_Comment
    {
        public string comment { get; set; }
        public string created { get; set; }
        public int seller_id { get; set; }
        public string seller_fio { get; set; }
    }

    public class User_Title
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string second_name { get; set; }
        public string full_name { get; set; }
    }

    public class Recipient_Title
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string second_name { get; set; }
        public string full_name { get; set; }
    }
}
