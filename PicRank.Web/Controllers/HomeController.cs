using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PicRank.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "PicRank";
            ViewBag.Dupa = "dupa";


            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult hello()
        {
            return View();
        }
    }
}
