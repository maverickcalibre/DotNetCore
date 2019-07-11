﻿using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
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
        public IEnumerable<Restaurant> GetAll() => from r in restaurants
                                                   orderby r.Name
                                                   select r;
    }
}
