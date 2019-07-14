using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string searchTerm);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Labizza Pizza", Location = "Florida", Cuisine = CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Chicken Kitchen", Location = "Georgia", Cuisine = CuisineType.Mexican },
                new Restaurant { Id = 3, Name = "Masala Plaza", Location = "New York", Cuisine = CuisineType.Indian }
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string searchTerm) 
            => from r in restaurants
               where string.IsNullOrEmpty(searchTerm) || r.Name.Contains(searchTerm)
               orderby r.Name
               select r;

        public Restaurant GetById(int id) => restaurants.SingleOrDefault(r => r.Id == id);

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }
    }
}
