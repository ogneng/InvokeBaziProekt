using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInvoke.Models
{
    public class PurchaseStatistics
    {
        public String Month { get; set; }
        public Int64 TotalGames { get; set; }
        public Int64 TotalItems { get; set; }
        public Int64 Total { get; set; }

    }
}