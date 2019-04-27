using SuperHeroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroes.Controllers
{
    public class HomeController : Controller
    {
        // member variables
        ApplicationDbContext db;

        // constructor
        public HomeController()
        {
            db = new ApplicationDbContext(); // instantiate new database with context
        }

        // member methods
        public ActionResult Index()
        {
            var superheroes = db.Superheroes.Select(s => s).ToList();
            return View(superheroes);
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