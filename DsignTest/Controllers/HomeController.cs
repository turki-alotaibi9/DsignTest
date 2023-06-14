using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DsignTest.Controllers
{
    public class HomeController : Controller
    {   
        public ActionResult LoginPage()
        {
            return View("LoginPage");
        }

        public ActionResult Register()
        {
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}