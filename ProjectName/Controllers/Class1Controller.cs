using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ProjectName.Models;

namespace ProjectName.Controllers
{
    public class Class1pluralController : Controller
    {
        private readonly ProjectNameContext _db;

        public Class1pluralController(ProjectNameContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Class1> model = _db.Class1plural.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Class1 class1)
        {
            _db.Class1plural.Add(class1);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Class1 thisClass1 = _db.Class1plural.FirstOrDefault(class1plural => class1plural.Class1Id == id);
            return View(thisClass1);
        }

        public ActionResult Edit(int id)
        {
            var thisClass1 = _db.Class1plural.FirstOrDefault(class1plural => class1plural.Class1Id == id);
            return View(thisClass1);
        }

        [HttpPost]
        public ActionResult Edit (Class1 class1)
        {
            _db.Entry(class1).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisClass1 = _db.Class1plural.FirstOrDefault(class1plural => class1plural.Class1Id == id);
            return View(thisClass1);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisClass1 = _db.Class1plural.FirstOrDefault(class1plural => class1plural.Class1Id == id);
            _db.Class1plural.Remove(thisClass1);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}