using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInvoke.Models
{
    public class TopBuyer
    {
        public Int64 UserID { get; set; }
        public String UserName { get; set; }
        public String Month { get; set; }
        public Int64 Profit { get; set; }
    }
}