using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bankomat.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]


        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult leftOne()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.myMessage = "daniel test";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}