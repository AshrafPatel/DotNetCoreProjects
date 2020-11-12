using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductShopDemo.Models
{
    public class Database
    {
        public static List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product
                {
                    ProductId = 1,
                    Name = "Product 1",
                    Price = (decimal) 25.50
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Product 2",
                    Price = (decimal) 5.50
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Product 3",
                    Price = (decimal) 75.50
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Product 4",
                    Price = (decimal) 7.17
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Product 5",
                    Price = (decimal) 99.99
                },
                new Product
                {
                    ProductId = 6,
                    Name = "Product Of The Week",
                    Price = (decimal) 121.64
                },
            };

            return products;
        }

        public static Product GetProduct(string slug)
        {
            List<Product> product = Database.GetAllProducts();
            foreach (Product p in product)
            {
                if (p.SlugName == slug)
                {
                    return p;
                }
            }
            return null;
        }
    }
}
