using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobaMartWeb.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Categories()
        {
            ViewBag.Message = "Your product categories page.";

            return View();
        }

        public ActionResult Products(string type)
        {
            ViewBag.Message = "Your products page.";

            return View();
        }

        public ActionResult Details(string type, int id)
        {
            ViewBag.Message = "Your product details page.";

            return View();
        }
    }
}