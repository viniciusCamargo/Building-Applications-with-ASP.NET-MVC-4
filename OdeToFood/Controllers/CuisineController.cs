using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class CuisineController : Controller
    {
        // GET: Cuisine
        [HttpGet]
        public ActionResult Search(string name = "french")
        {
            var message = Server.HtmlEncode(name);

            // I could use a FileResult to return PDF files, spreadsheets, etc.
            // i.e. return File(Server.MapPath("~/Content/site.css"), "text/css");

            // Or a permanent redirect (http 301)
            // i.e. return RedirectPermanent("http://www.google.com");

            // Or an action with a parameter as defined at RouteConfig
            // return RedirectToAction("Index", "Home", new { name = name });

            // Or a file
            // return File(Server.MapPath("~/Content/site.css"), "text/css");

            // Or a json file
            // return Json(new { Message = message, Name = "Scott" }, JsonRequestBehavior.AllowGet);

            // Note: a method with the same "signature" is a method with same name and
            // parameters

            return Content(message);
        }
    }
}