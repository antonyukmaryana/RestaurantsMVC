using Microsoft.EntityFrameworkCore;

namespace RestaurantsMVC.Models
{
    public class RestaurantsMVCContext : DbContext
    {
        public virtual DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Restaurant>  Restaurants { get; set; }
        public RestaurantsMVCContext(DbContextOptions options) : base(options) { }
    }
}