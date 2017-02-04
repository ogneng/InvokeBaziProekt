using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInvoke.Models
{
    public class Achievements
    {
        public Int64 IAchievementID { get; set; }

        public Int64 UserID { get; set; }

        public string AchievementTitle { get; set; }

        public string GameName { get; set; }

    }
}