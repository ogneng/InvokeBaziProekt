﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInvoke.Models
{
    public class Users
    {
        public Int64 UserID { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string Gender { get; set; }
    }
}