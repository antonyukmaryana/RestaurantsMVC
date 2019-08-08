using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using RestaurantsMVC.Models;

namespace RestaurantsMVC.Controllers
{
    public class CuisinesController : Controller
    {
        private readonly RestaurantsMVCContext _db;

        public CuisinesController(RestaurantsMVCContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Cuisine> model = _db.Cuisines.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cuisine cuisine)
        {
            _db.Cuisines.Add(cuisine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisines => cuisines.CuisineId == id);
            ViewBag.RestaurantList = _db.Restaurants.Where(r => r.CuisineId == id);
            return View(thisCuisine);
        }

        public ActionResult Edit(int id)
        {
            var thisCuisine= _db.Cuisines.FirstOrDefault(cuisines => cuisines.CuisineId == id);
            return View(thisCuisine);
        }

        [HttpPost]
        public ActionResult Edit (Cuisine cuisine)
        {
            _db.Entry(cuisine).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisCuisine = _db.Cuisines.FirstOrDefault(cuisines => cuisines.CuisineId == id);
            return View(thisCuisine);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisCuisine = _db.Cuisines.FirstOrDefault(cuisines => cuisines.CuisineId == id);
            _db.Cuisines.Remove(thisCuisine);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}