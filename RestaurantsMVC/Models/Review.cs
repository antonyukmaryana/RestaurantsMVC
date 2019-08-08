using System;
using System.Collections.Generic;

namespace RestaurantsMVC.Models
{
    public class Review
    {
        public string Name {get; set;}
        public string ReviewText {get; set;}
        public int ReviewId {get; set;}
        public int RestaurantId {get; set;}
        public  DateTime Date {get; set;}
        public virtual Restaurant Restaurant {get; set;}

    }
    
}