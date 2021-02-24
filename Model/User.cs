using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authwebapi.Model
{
    public class User
    {
        public int id { get; set; }

        public string username { get; set; }

        public string phone { get; set; }

        public DateTime created { get; set; }

        public string salt { get; set; }
    }
}
