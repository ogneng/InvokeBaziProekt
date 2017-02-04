using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInvoke.Models
{
    public class SetsGames
    {
        public Int64 SetGameID { get; set; }
        public Int64 UserID { get; set; }
        public string AdminUsername { get; set; }
        public string GameName { get; set; }
        public DateTime SetGameDate { get; set; }
    }
}