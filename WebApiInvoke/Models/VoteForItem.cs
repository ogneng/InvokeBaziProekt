using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInvoke.Models
{
    public class VoteForItem
    {
        public Int64 WorkshopID { get; set; }
        public Int64 UserID { get; set; }
        public Int64 ItemID { get; set; }
    }
}