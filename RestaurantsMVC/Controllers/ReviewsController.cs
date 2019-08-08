using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using RestaurantsMVC.Models;

namespace RestaurantsMVC.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly RestaurantsMVCContext  _db;
        public  ReviewsController(RestaurantsMVCContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Review> model = _db.Reviews.ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create (Review review)
        {
            _db.Reviews.Add(review);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

       public ActionResult Edit (int id)
       {
           var thisReview = _db.Reviews.FirstOrDefault(reviews=> reviews.ReviewId ==id);
           return View(thisReview);   
       }
       [HttpPost]
       public ActionResult Edit (Review review)
       {
           _db.Entry(review).State = EntityState.Modified;
           _db.SaveChanges();
           return RedirectToAction("Index");
       } 
       public ActionResult Delete (int id)
       {
           var thisReview = _db.Reviews.FirstOrDefault(reviews =>reviews.ReviewId==id);
           return View (thisReview);
       }
       [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisReview = _db.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            _db.Reviews.Remove(thisReview);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}