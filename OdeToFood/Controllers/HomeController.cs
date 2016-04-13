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
        OdeToFoodDb _db = new OdeToFoodDb();

        public ActionResult Index()
        {
            var model = _db.Restaurants.ToList();

            /*
             * Check the routing values of the controller
             */
            //var controller = RouteData.Values["controller"];
            //var action = RouteData.Values["action"];
            //var id = RouteData.Values["id"];
            //var message = String.Format("{0}::{1} {2}", controller, action, id);

            //ViewBag.Message = message;

            return View(model);
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

        /*
         * "The Dispose API in .NET is just a way to clean up resources
         * that might be open. Anything that implements the IDisposable
         * interface or has a Dispose method you should call it as soon
         * as possible to make sure everything is cleaned up as earlier
         * as possible.
         */
        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}