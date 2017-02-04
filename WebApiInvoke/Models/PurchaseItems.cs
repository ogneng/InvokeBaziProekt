using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInvoke.Models
{
    public class PurchaseItems
    {
        public Int64 PurcheItemID { get; set; }
        public Int64 CardID { get; set; }
        public string GameName { get; set; }
        public Int64 ItemID { get; set; }
        public DateTime PurcheItemDateTime { get; set; }
    }
}