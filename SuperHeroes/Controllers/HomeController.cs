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

        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View(superhero);
        }
        [HttpPost]
        public ActionResult Create(Superhero superhero)
        {
            db.Superheroes.Add(superhero);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int Id)
        {
            var superhero = db.Superheroes.Where(s => s.Id == Id).FirstOrDefault();
            return View(superhero);
        }
    }
}