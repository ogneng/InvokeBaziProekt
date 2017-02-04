using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInvoke.Models
{
    public class EarnedAchievements
    {
        public Int64 UserID { get; set; }
        public Int64 AchivmentID { get; set; }
        public DateTime EarnedAchivmentDate { get; set; }
    }
}