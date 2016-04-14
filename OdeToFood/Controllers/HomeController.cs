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
            //var model = _db.Restaurants.ToList();


            /* T H E   C O M P R E H E N S I O N   Q U E R Y   S Y N T A X */

            //var model =
            //from r in _db.Restaurants
            //orderby r.Name // descending or ascending (default)
            //orderby r.Reviews.Count() descending
            //orderby r.Reviews.Average(review => review.Rating) descending
            //select r;

            /*
             * "This is creating a new anonymous type that has properties named
             * Id, Name, City and Country. The C# compiler will just give it those 
             * property names if you don't specify something equals (=). And we're
             * also adding in this NumberOfReviews equals r.Reviews.Count. I could
             * take this and still pass it to my View. But being an anonymously
             * typed object, we have the problem that we don't know its name, it's
             * anonymous. What would I put as a strongly typed model directive here?
             * Well, what I could do instead is create a new model. I'll call it a 
             * View Model because it's dedicated to this View."
             */

            //select new RestaurantListViewModel
            //{
            //    Id = r.Id,
            //    Name = r.Name,
            //    City = r.City,
            //    Country = r.Country,
            //    CountOfReviews = r.Reviews.Count()
            //};

            /*
             * ViewModels are usefull because sometimes you need extra information
             * from different places that your current entity (model) doesn't have
             */

            /* T H E   E X T E N S I O N   M E T H O D   S Y N T A X */
            var model =
                _db.Restaurants
                    .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                    .Select(r => new RestaurantListViewModel
                        {
                            Id = r.Id,
                            Name = r.Name,
                            City = r.City,
                            Country = r.Country,
                            CountOfReviews = r.Reviews.Count()
                        });

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