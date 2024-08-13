using System.Collections.Generic;
using System.Linq;
using ProductSearchApp.Models;

namespace ProductSearchApp.Services
{
    public class ProductService
    {
        // A list of dummy products to simulate a database
        private readonly List<Product> _products = new List<Product>
        {
            new Product { Name = "Super White", Color = "White", Finish = "Matte", ProductType = "Interior", Price = 25.99m },
            new Product { Name = "Ocean Blue", Color = "Blue", Finish = "Gloss", ProductType = "Exterior", Price = 35.50m },
            new Product { Name = "Sunset Yellow", Color = "Yellow", Finish = "Satin", ProductType = "Interior", Price = 29.99m },
            new Product { Name = "Forest Green", Color = "Green", Finish = "Eggshell", ProductType = "Interior", Price = 32.99m },
            new Product { Name = "Sky Gray", Color = "Gray", Finish = "Flat", ProductType = "Exterior", Price = 27.50m },
            new Product { Name = "Midnight Black", Color = "Black", Finish = "Matte", ProductType = "Exterior", Price = 30.00m },
            new Product { Name = "Ruby Red", Color = "Red", Finish = "Gloss", ProductType = "Interior", Price = 28.45m },
            new Product { Name = "Creamy Beige", Color = "Beige", Finish = "Eggshell", ProductType = "Interior", Price = 26.95m },
            new Product { Name = "Ocean Mist", Color = "Light Blue", Finish = "Satin", ProductType = "Exterior", Price = 34.20m },
            new Product { Name = "Charcoal Gray", Color = "Dark Gray", Finish = "Flat", ProductType = "Interior", Price = 33.99m }
        };

        public ProductService()
        {
            // Dynamically add more products to reach 50 total
            var additionalColors = new[] { "Pink", "Orange", "Violet", "Magenta", "Cyan", "Mocha", "Peach", "Lime Green", "Navy", "Chocolate" };
            var finishes = new[] { "Matte", "Gloss", "Satin", "Eggshell", "Flat" };
            var types = new[] { "Interior", "Exterior" };

            int count = _products.Count;
            foreach (var color in additionalColors)
            {
                foreach (var finish in finishes)
                {
                    foreach (var type in types)
                    {
                        if (++count > 50) break;
                        _products.Add(new Product
                        {
                            Name = $"{color} {finish}",
                            Color = color,
                            Finish = finish,
                            ProductType = type,
                            Price = 20.00m + 10 * count % 20 // Example price formula
                        });
                    }
                }
            }
        }

        // Method to search products based on a query
        public List<Product> SearchProducts(string query)
        {
            // If the query is empty, return all products
            if (string.IsNullOrEmpty(query))
            {
                return _products;
            }

            // Return products that match the query (case insensitive)
            return _products.Where(p =>
                p.Name.Contains(query, System.StringComparison.OrdinalIgnoreCase) ||
                p.Color.Contains(query, System.StringComparison.OrdinalIgnoreCase) ||
                p.Finish.Contains(query, System.StringComparison.OrdinalIgnoreCase) ||
                p.ProductType.Contains(query, System.StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }
    }
}
