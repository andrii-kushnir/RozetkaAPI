using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozetkaAPI.ModelsRozetka
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public object name_ua { get; set; }
        public int market_id { get; set; }
        public string article { get; set; }
        public string price_offer_id { get; set; }
        public string price { get; set; }
        public int stock_quantity { get; set; }
        public object weight { get; set; }
        public int commission_percent { get; set; }
        public string commission_sum { get; set; }
        public CatalogCategory catalog_category { get; set; }
        public int catalog_id { get; set; }
        public int? group_id { get; set; }
        public string photo_preview { get; set; }
        public string[] photo { get; set; }
        public int moderation_status { get; set; }
        public int sla_id { get; set; }
        public int sla_rz_id { get; set; }
        public string url { get; set; }
        public int sold { get; set; }
        public string uploader_offer_id { get; set; }
        public int uploader_status { get; set; }
        public object details { get; set; }
    }
}
