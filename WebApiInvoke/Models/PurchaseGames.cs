using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInvoke.Models
{
    public class PurchaseGames
    {
        public Int64 PurcheGameID { get; set; }
        public Int64 CardID { get; set; }
        public string GameName { get; set; }
        public DateTime PurcheGameDateTime { get; set; }

      
    }
}