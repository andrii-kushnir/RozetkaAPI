using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozetkaAPI.Models
{
    public class OrdersSearchResponse
    {
        public bool success { get; set; }
        public ContentOrdersSearch content { get; set; }
    }

    public class ContentOrdersSearch
    {
        public List<Order> orders { get; set; }
        public MetaOrdersSearch _meta { get; set; }
    }

    public class MetaOrdersSearch
    {
        public int totalCount { get; set; }
        public int pageCount { get; set; }
        public int currentPage { get; set; }
        public int perPage { get; set; }
    }

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
        public Items_Photos[] items_photos { get; set; }
        public object[] seller_comment { get; set; }
        public string seller_comment_created { get; set; }
        public string current_seller_comment { get; set; }
        public string comment { get; set; }
        public string user_phone { get; set; }
        public int? user_rating { get; set; }
        public int from_warehouse { get; set; }
        public string ttn { get; set; }
        public int total_quantity { get; set; }
        public bool mk_created { get; set; }
        public bool can_copy { get; set; }
        public int created_type { get; set; }
        public bool is_viewed { get; set; }
        public string payment_type { get; set; }
        public string payment_type_name { get; set; }
        public int credit_status { get; set; }
        public object[] credit_info { get; set; }
        public bool credit_broker { get; set; }
        public int callback_off { get; set; }
        public bool is_fulfillment { get; set; }
        public int? duplicate_order_id { get; set; }
        public bool is_delivery_edit_available { get; set; }
        public bool can_prolong { get; set; }
        public int is_review_request_send { get; set; }
        public string review_request_status { get; set; }
    }
}
