using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInvoke.Models
{
    public class Forums
    {
        public Int64 ForumID { get; set; }
        public string ForumName { get; set; }
        public DateTime ForumDateTime { get; set; }
        public string GameName { get; set; }
    }
}