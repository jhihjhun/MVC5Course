using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HandleError(ExceptionType = typeof(NotImplementedException), View = "Error_NotImplementedException")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            throw new NotImplementedException();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}