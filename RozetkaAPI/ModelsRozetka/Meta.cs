using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaAPI.ModelsRozetka
{
    public class Meta
    {
        public int totalCount { get; set; }
        public int pageCount { get; set; }
        public int currentPage { get; set; }
        public int perPage { get; set; }
    }
}
