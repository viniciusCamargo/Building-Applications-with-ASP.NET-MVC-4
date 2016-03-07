using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*
             * Check the routing values of the controller
             */
            //var controller = RouteData.Values["controller"];
            //var action = RouteData.Values["action"];
            //var id = RouteData.Values["id"];
            //var message = String.Format("{0}::{1} {2}", controller, action, id);

            //ViewBag.Message = message;

            return View();
        }

        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "Vinicius";
            model.Location = "Caxias do Sul";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}