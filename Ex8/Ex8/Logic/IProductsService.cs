using Ex8.Models;
using System.Collections.Generic;

namespace Ex8.Logic
{
    public interface IProductsService
    {
        IEnumerable<Product> ListAll();
        bool Edit(int id, Product product);
        bool DeleteById(int id);
    }
}
