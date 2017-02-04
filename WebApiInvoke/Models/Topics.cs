using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInvoke.Models
{
    public class Topics
    {
        public Int64 TopicID { get; set; }
        public Int64 UserID { get; set; }
        public Int64 ForumID { get; set; }
        public string TopicName { get; set; }
        public string TopicDescription { get; set; }
        public DateTime TopicDateTime { get; set; }     
    }
}