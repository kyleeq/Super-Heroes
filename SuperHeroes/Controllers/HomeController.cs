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

        public ActionResult Edit(int Id)
        {
            var superhero = db.Superheroes.Where(s => s.Id == Id).FirstOrDefault();
            return View(superhero);
        }
        [HttpPost]
        public ActionResult Edit(Superhero superhero)
        {
            var edittedSuperhero = db.Superheroes.Where(s => s.Id == superhero.Id).FirstOrDefault();
            edittedSuperhero.name = superhero.name;
            edittedSuperhero.alterEgo = superhero.alterEgo;
            edittedSuperhero.primaryAbility = superhero.primaryAbility;
            edittedSuperhero.secondaryAbility = superhero.secondaryAbility;
            edittedSuperhero.catchPhrase = superhero.catchPhrase;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            var superhero = db.Superheroes.Where(s => s.Id == Id).FirstOrDefault();
            return View(superhero);
        }
    }
}