using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInvoke.Models
{
    public class Friendship
    {
        public Int64 FriendshipID { get; set; }
        public Int64 FromUserID { get; set; }
        public Int64 ToUserID { get; set; }
        public DateTime ForumDateTime { get; set; }
        public string ForumName { get; set; }
     
    }
}