using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaAPI.ModelsRozetka
{
    public class Delivery
    {
        public int delivery_service_id { get; set; }
        public string delivery_service_name { get; set; }
        public string recipient_title { get; set; }
        public string recipient_phone { get; set; }
        public bool? another_recipient { get; set; }
        public int? delivery_method_id { get; set; }
        public int? place_id { get; set; }
        public string place_street { get; set; }
        public string place_number { get; set; }
        public string place_house { get; set; }
        public string place_flat { get; set; }
        public string cost { get; set; }
        public string reserve_date { get; set; }
        public City city { get; set; }
        public string ref_id { get; set; }
        public string name_logo { get; set; }
    }

    public class City
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string city_name { get; set; }
        public string name { get; set; }
        public string name_ua { get; set; }
        public string name_en { get; set; }
        public string region_title { get; set; }
        public string title { get; set; }
        public int status { get; set; }
    }
}
