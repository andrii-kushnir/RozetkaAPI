using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PozetkaAPI.Models
{
    public class LogoutResponse
    {
        public bool success { get; set; }
        public ContentLogout content { get; set; }
    }

    public class ContentLogout
    {
        public bool logout { get; set; }
    }

}
