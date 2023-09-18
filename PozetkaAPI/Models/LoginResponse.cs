using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozetkaAPI.Models
{
    public class LoginResponse
    {
        public bool success { get; set; }
        public ContentLogin content { get; set; }
    }

    public class ContentLogin
    {
        public int id { get; set; }
        public string access_token { get; set; }
        public string[] permissions { get; set; }
        public string[] roles { get; set; }
        public Market market { get; set; }
        public bool needInterview { get; set; }
        public string lang { get; set; }
    }


    public class Market
    {
        public int id { get; set; }
        public string logo { get; set; }
        public string business_model { get; set; }
        public string title { get; set; }
        public string title_translit { get; set; }
        public string market_url { get; set; }
        public bool war_block { get; set; }
        public string status { get; set; }
        public string status_label { get; set; }
        public string status_description { get; set; }
        public bool fulfillment_available { get; set; }
    }
}
