using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiInvoke.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult GetAllGames()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }
        public ActionResult Items()
        {
            return View();
        }
        public ActionResult Forums()
        {
            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }
    }
}
