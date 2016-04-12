using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ReviewsController : Controller
    {
        /* 
         * All public methods on the controller can be invoked by the
         * user on the browser, execpt if you use ChildActionOnly attribute.
         * Then you can only access it as a child request not as http request
         */
        [ChildActionOnly]
        public ActionResult BestReview()
        {
            var bestReview = from r in _reviews
                             orderby r.Rating descending
                             select r;

            return PartialView("_Review", bestReview.First());
        }

        // GET: Reviews
        public ActionResult Index()
        {
            var model =
                from r in _reviews
                orderby r.Country
                select r;

            return View(model);
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int id)
        {
            var review = _reviews.Single(r => r.Id == id);
            /*
             * "(...) linq query to say give me a single object that
             * is in this collection (_reviews) that matches this
             * criteria (r.Id == id): the id property (r.Id) has to match
             * this incoming id parameter (id).
             */

            return View(review);
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var review = _reviews.Single(r => r.Id == id);
            /*
             * "What the TryUpdateModel() will do is go through a process known
             * as model binding, in fact model binding happens anytime you even
             * have a parameter in an action method. It's what ASP.NET MVC does
             * when it goes out and it looks around at a request to try to find
             * things to move in to an object for you.  So when I have a parameter
             * called ID on the edit action, the model binder in ASP.NET MVC will
             * find that ID, move it into that for me. When I say TryUpdateModel
             * on review, the model binder will go out and look at review, see that
             * it has a rating property, and then go out and try to find something
             * called rating. But fortunately, there should be a posted form input
             * named rating. The MVC runtime will find that and just move it into
             * my review. If anything fails, if any validation errors occur,
             * TryUpdateModel will return false and I don't want to save that
             * review."
             */
            if (TryUpdateModel(review))
            {
                return RedirectToAction("Index");
            }

            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reviews/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        static List<RestaurantReview> _reviews = new List<RestaurantReview>
        {
            new RestaurantReview
            {
                Id = 1,
                Name = "Cinnamon Club",
                City = "London",
                Country = "UK",
                Rating = 10
            },
            new RestaurantReview
            {
                Id = 2,
                Name = "Marrakesh",
                City = "D.C",
                Country = "USA",
                Rating = 10
            },
            new RestaurantReview
            {
                Id = 3,
                Name = "The House of Elliot",
                City = "Ghent",
                Country = "Belgium",
                Rating = 10
            }
        };
    }
}
