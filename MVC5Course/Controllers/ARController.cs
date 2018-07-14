using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewTest()
        {
            string model = "ViewData";
            return View((object)model);
        }

        public ActionResult PartialViewTest()
        {
            string model = "ViewData";
            return PartialView("ViewTest", (object)model);
        }

        public ActionResult ContentTest()
        {
            return Content("TTTTT Content!", "text/plain", System.Text.Encoding.GetEncoding("Big5"));
        }

        public ActionResult FileResultTest(string dl)
        {
            if (string.IsNullOrEmpty(dl))
            {
                return File(Server.MapPath("~/App_Data/FIFA_series_logo.svg.png"), "image/png");

            }
            else
            {
                return File(Server.MapPath("~/App_Data/FIFA_series_logo.svg.png"), "image/png", "fifa-dl");
            }

        }

    }
}