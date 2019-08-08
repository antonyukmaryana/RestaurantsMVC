using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ProjectName.Models;

namespace ProjectName.Controllers
{
    public class Class2pluralController : Controller
    {
        private readonly ProjectNameContext _db;

        public Class2pluralController(ProjectNameContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Class2> model = _db.Class2plural.Include(class2table => class2table.Class1).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.Class1Id = new SelectList(_db.Categories, "Class1Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Class2 item)
        {
            _db.Class2plural.Add(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Class2 thisClass2 = _db.Class2plural.FirstOrDefault(class2table => class2table.Class2Id == id);
            return View(thisClass2);
        }

        public ActionResult Edit(int id)
        {
            var thisClass2 = _db.Class2plural.FirstOrDefault(class2table => class2table.Class2Id == id);
            ViewBag.Class1Id = new SelectList(_db.Categories, "Class1Id", "Name");
            return View(thisClass2);
        }

        [HttpPost]
        public ActionResult Edit (Class2 item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisClass2 = _db.Class2plural.FirstOrDefault(class2table => class2table.Class2Id == id);
            return View(thisClass2);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisClass2 = _db.Class2plural.FirstOrDefault(class2table => class2table.Class2Id == id);
            _db.Class2plural.Remove(thisClass2);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}