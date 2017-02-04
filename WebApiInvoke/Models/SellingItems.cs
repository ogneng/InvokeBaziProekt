using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInvoke.Models
{
    public class SellingItems
    {
        public Int64 SelingItemID { get; set; }
        public Int64 ItemID { get; set; }
        public string GameName { get; set; }
        public int ItemQuantity { get; set; }
    }
}