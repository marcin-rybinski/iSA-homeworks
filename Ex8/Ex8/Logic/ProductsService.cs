using Ex8.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ex8.Logic
{
    public class ProductsService : IProductsService
    {
        private static List<Product> _products = new List<Product>
        {
            new Product {Id = 1, Name = "Playstation 4", Description = "Buy this, ignore the rest.", Price = 299.99},
            new Product {Id = 2, Name = "Xbox One", Description = "No one cares.", Price = 999.99},
            new Product {Id = 3, Name = "Nintendo Switch", Description = "Some day...", Price = 319.99}
        };

        public IEnumerable<Product> ListAll()
        {
            return _products;
        }

        public bool Edit(int id, Product product)
        {
            var currentProduct = _products.FirstOrDefault(x => x.Id == id);
            currentProduct.Name = product.Name;
            currentProduct.Price = product.Price;
            currentProduct.Description = product.Description;

            return true;
        }

        public bool DeleteById(int id)
        {
            return _products.Remove(_products.FirstOrDefault(x => x.Id == id));
        }
    }
}
