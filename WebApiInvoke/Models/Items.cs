using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInvoke.Models
{
    public class Items
    {
        public Int64 ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public string ItemDescription { get; set; }
        public int ItemPrice { get; set; }
        public string GameName { get; set; }
        public Int64 UserID { get; set; }
        public string ItemArtistUserName { get; set; }
        public Int64 WorkShopID { get; set; }
    }
}