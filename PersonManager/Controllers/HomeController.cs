using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonManager.Models;

namespace PersonManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.TablaP = new List<Person>();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public ActionResult Index(Person model)
        {
            ViewBag.TablaP = Person.Persona(model);
            ModelState.Clear();

            return View();   
        }  
        [HttpPost]
        public ActionResult DeleteRow(Person model)
        {
            ViewBag.TablaP = Person.DeleteRow(model);
            ModelState.Clear();

            return View("Index");
        }
        [HttpGet]
        public ActionResult GetOlder()
        {
            ViewBag.TablaP = Person.GetOlder();
            return View("Index");
        }
            [HttpGet]
        public ActionResult GetCommon()
        {
            ViewBag.TablaP = Person.GetCommon();
            return View("Index");
        }            [HttpGet]
        public ActionResult ShowAll()
        {
            ViewBag.TablaP = Person.Added;
            return View("Index");
        }
        [HttpPost]
        public ActionResult UpdateRecord(Person Model)
        {
            ViewBag.TablaP = Person.UpdateRecord(Model);
            ModelState.Clear();
            return View("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}