using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEF6.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //SE CREA EL OBJETO DE APLICACION, UN SINGLETON?
            if (Session["IsLoggedIn"] == null)
                Session["IsLoggedIn"] = 0;

            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}