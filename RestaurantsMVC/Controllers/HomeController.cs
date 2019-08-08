
using Microsoft.AspNetCore.Mvc;
using RestaurantsMVC.Models;

namespace RestaurantsMVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}