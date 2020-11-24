using Ex16.MR.BLL.Models.DTO;
using System.Collections.Generic;

namespace Ex16.MR.BLL.Services
{
    public interface IProductService
    {
        List<ShowProductDto> GetAllProducts();
        ShowProductDto GetProductById(int id);
        ShowProductDto AddProduct(CreateProductDto createProduct);
        bool UpdateProduct(UpdateProductDto product);
        bool DeleteProduct(int id);
    }
}