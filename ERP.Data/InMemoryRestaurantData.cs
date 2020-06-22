using System;
using System.Collections.Generic;
using System.Linq;
using ERP.Core;

namespace ERP.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                //new Restaurant {Id = 1, Name = "AScott's Pizza", Location = "La bella italia", Cuisine = CuisineType.Italian},
                //new Restaurant {Id = 2, Name = "CScott's Pizza", Location = "La bella italia", Cuisine = CuisineType.Italian},
                //new Restaurant {Id = 3, Name = "BScott's Pizza", Location = "La bella italia", Cuisine = CuisineType.Italian}
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.ProductName.ToLower().StartsWith(name.ToLower())
                   orderby r.ProductName
                   select r;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Create(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null) {
                restaurant.ProductCfdiKey = updatedRestaurant.ProductCfdiKey;
                restaurant.ProductId = updatedRestaurant.ProductId;
                restaurant.ProductType = updatedRestaurant.ProductType;
                restaurant.ProductUnit = updatedRestaurant.ProductUnit;
                restaurant.ProductName = updatedRestaurant.ProductName;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
    }
}