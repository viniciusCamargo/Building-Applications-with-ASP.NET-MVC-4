using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public class OdeToFoodDb : DbContext
    {
        /*
         * "If I want the Entity Framework to use (certain) connection string, what
         * I do when I call in base class constructor is say: base("name=NameOfMyConnectionString")"
         */
        public OdeToFoodDb() : base("name=DefaultConnection")
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }
    }
}