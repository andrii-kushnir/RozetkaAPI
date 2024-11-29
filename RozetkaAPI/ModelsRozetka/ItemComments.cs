using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RozetkaAPI.ModelsRozetka
{
    public class ItemComments
    {
        public int id { get; set; }
        public int? record_id { get; set; }
        public string user_id { get; set; }
        public string email { get; set; }
        public int parent_comment_id { get; set; }
        public int owox_id { get; set; }
        public int parent_id { get; set; }
        public int seller_id { get; set; }
        public string status { get; set; }
        public string name { get; set; }
        public string text { get; set; }
        public string rating { get; set; }
        public int mark { get; set; }
        public int positive_vote_count { get; set; }
        public int negative_vote_count { get; set; }
        public string dignity { get; set; }
        public string shortcomings { get; set; }
        public string created { get; set; }
        public string changed { get; set; }
        public bool is_reade { get; set; }
        public bool is_important { get; set; }
        public int from_buyer { get; set; }
        public int allow_html { get; set; }
        public Record record { get; set; }
        public object dispute { get; set; }
        public bool has_children { get; set; }
        public bool is_un_reade_child { get; set; }
        public Item item { get; set; }
        public string type { get; set; }
        public string orders_created { get; set; }
        public string orders_completed { get; set; }
        public int? orders_id { get; set; }
        //public object[] children { get; set; }
    }

    public class Record
    {
        public string id { get; set; }
        public string title { get; set; }
    }
}
