using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiInvoke.Models
{
    public class Game
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int Price { get; set; }

        public DateTime Date { get; set; }

        public string Developer { get; set; }

        public string Genre { get; set; }
    }
}