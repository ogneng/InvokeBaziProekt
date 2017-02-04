using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInvoke.Models
{
    public class Admins
    {
        public Int64 UserID { get; set; }

        public string AdminUserName { get; set; }

        public string AdminName { get; set; }

        public string AdminSurName { get; set; }

        public Int64 Phone { get; set; } // treba da e string
    }
}