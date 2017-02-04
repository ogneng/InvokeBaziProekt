using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInvoke.Models
{
    public class Comments
    {
        public Int64 CommentID { get; set; }
        public string CommentContent { get; set; }

        public DateTime CommentDateTime { get; set; }
        public Int64 UserID { get; set; }
        public Int64 TopicID { get; set; }
    }
}