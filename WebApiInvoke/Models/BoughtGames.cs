using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInvoke.Models
{
    public class BoughtGames
    {
        public Int64 BoughtGameID { get; set; }
        public Int64 UserID { get; set; }
        public string GameName { get; set; }
    }
}