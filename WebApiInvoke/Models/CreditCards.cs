using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInvoke.Models
{
    public class CreditCards
    {
        public Int64 CardID { get; set; }
        public Int64 UserID { get; set; }
        public string CustomerUserName { get; set; }
        public string CardNumber { get; set; }
        public Int64 CardCvCode { get; set; } 
        public string CardHolderName { get; set; }
        public string CardHolderSurName { get; set; }
        public DateTime CardDateTime { get; set; }
        public string CardType { get; set; }

    }
}