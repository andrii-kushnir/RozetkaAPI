using PozetkaAPI.ModelsRozetka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozetkaAPI.Models
{

    public class OrderExtraResponse
    {
        public bool success { get; set; }
        public Content content { get; set; }
        public Reminder_To_Check_Payment_For_Duplicates reminder_to_check_payment_for_duplicates { get; set; }
    }

    public class Content
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
        public object[] items_photos { get; set; }
        public object[] seller_comment { get; set; }
        public string seller_comment_created { get; set; }
        public string current_seller_comment { get; set; }
        public string comment { get; set; }
        public string user_phone { get; set; }
        public int from_warehouse { get; set; }
        public string ttn { get; set; }
        public int total_quantity { get; set; }
        public bool can_copy { get; set; }
        public int created_type { get; set; }
        public string payment_type_name { get; set; }
        public int callback_off { get; set; }
        public bool is_fulfillment { get; set; }
        public int? duplicate_order_id { get; set; }
        public bool invoice_exist { get; set; }
        public bool can_create_invoice { get; set; }
        public Chatuser chatUser { get; set; }
        public Chatmessage[] chatMessages { get; set; }
        public User1 user { get; set; }
        public Delivery delivery { get; set; }
        public List<Purchase> purchases { get; set; }
        public Status_Available[] status_available { get; set; }
        public bool is_access_change_order { get; set; }
        public string payment_type { get; set; }
        public object[] credit_info { get; set; }
        public Order_Status_History[] order_status_history { get; set; }
        public string payment_type_title { get; set; }
        public Delivery_Service delivery_service { get; set; }
        public Status_Data status_data { get; set; }
        public Status_Payment status_payment { get; set; }
        public string payment_status { get; set; }
        public bool can_edit { get; set; }
        public Feedback[] feedback { get; set; }
        public int feedback_count { get; set; }
        public bool is_promo { get; set; }
        public int? payment_invoice_id { get; set; }
        public Delivery_Prices delivery_prices { get; set; }
    }

    public class Chatuser
    {
        public int id { get; set; }
        public string created { get; set; }
        public string updated { get; set; }
        public string subject { get; set; }
        public User user { get; set; }
        public object read_market { get; set; }
        public int trash_market { get; set; }
        public int star_market { get; set; }
        public int order_id { get; set; }
        public int type { get; set; }
        public object item_id { get; set; }
        public int user_id { get; set; }
        public int unread_messages_count { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public bool has_email { get; set; }
        public string contact_fio { get; set; }
        public string email { get; set; }
    }

    public class User1
    {
        public int id { get; set; }
        public bool has_email { get; set; }
        public string contact_fio { get; set; }
        public string email { get; set; }
    }

    public class Delivery
    {
        public int delivery_service_id { get; set; }
        public string delivery_service_name { get; set; }
        public string recipient_title { get; set; }
        public int place_id { get; set; }
        public string place_street { get; set; }
        public string place_number { get; set; }
        public string place_house { get; set; }
        public string place_flat { get; set; }
        public string cost { get; set; }
        public string reserve_date { get; set; }
        public City city { get; set; }
        public int delivery_method_id { get; set; }
        public string ref_id { get; set; }
        public string name_logo { get; set; }
    }

    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public string region_title { get; set; }
        public string title { get; set; }
        public int status { get; set; }
    }

    public class Delivery_Service
    {
        public int id { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public int status { get; set; }
        public bool can_edit { get; set; }
        public bool can_use { get; set; }
        public object owox_market_id { get; set; }
        public int owox_id { get; set; }
    }

    public class Status_Payment
    {
        public int order_id { get; set; }
        public int status_payment_id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public int value { get; set; }
        public string created_at { get; set; }
    }

    public class Delivery_Prices
    {
        public string delivery_price { get; set; }
        public string post_pay_commission { get; set; }
    }

    public class Chatmessage
    {
        public int chat_id { get; set; }
        public string body { get; set; }
        public string created { get; set; }
        public int user_id { get; set; }
        public int sender_hide { get; set; }
        public object seller { get; set; }
        public object seller_id { get; set; }
    }

    public class Status_Available
    {
        public int parent_id { get; set; }
        public int child_id { get; set; }
        public int market_id { get; set; }
        public int id { get; set; }
        public int delivery_type { get; set; }
        public int market_group { get; set; }
    }

    public class Order_Status_History
    {
        public int status_id { get; set; }
        public string created { get; set; }
        public Status status { get; set; }
    }

    public class Status
    {
        public int id { get; set; }
        public string name { get; set; }
        public int status_group { get; set; }
        public int status { get; set; }
    }

    public class Feedback
    {
        public int id { get; set; }
        public string comment { get; set; }
    }

    public class Reminder_To_Check_Payment_For_Duplicates
    {
        public bool to_show_reminder { get; set; }
        public object message { get; set; }
    }

}
