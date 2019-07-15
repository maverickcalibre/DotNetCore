using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
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

        public Restaurant Add(Restaurant newRestaurant)
        {
            if(newRestaurant != null)
            {
                restaurants.Add(newRestaurant);
                newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            }

            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            
            return restaurant;
        }


        public int Commit()
        {
            return 0;
        }

        Restaurant IRestaurantData.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
