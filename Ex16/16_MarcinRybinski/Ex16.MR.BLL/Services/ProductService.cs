using AutoMapper;
using Ex16.MR.BLL.MappingProfiles;
using Ex16.MR.BLL.Models;
using Ex16.MR.BLL.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Ex16.MR.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly List<Product> _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Sword",
                Price = 100.00M,
                Type = Type.Other
            },
            new Product
            {
                Id = 2,
                Name = "Water",
                Price = 5.00M,
                Type = Type.Drink
            },
            new Product
            {
                Id = 3,
                Name = "Sausage",
                Price = 10.00M,
                Type = Type.Food
            }
        };

        public ProductService()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
                cfg.AddProfile(new ProductMappingProfile()));
            mapperConfig.AssertConfigurationIsValid();
            var mapper = new Mapper(mapperConfig);
            _mapper = mapper;
        }

        public List<ShowProductDto> GetAllProducts()
        {
            return _mapper.Map<List<Product>, List<ShowProductDto>>(_products);
        }

        public ShowProductDto GetProductById(int id)
        {
            if (_products.All(p => p.Id != id)) return null;
            {
                var product = _products.FirstOrDefault(p => p.Id == id);
                return MapToShowProductDto(product);
            }

        }

        public ShowProductDto AddProduct(CreateProductDto createProduct)
        {
            var productToAdd = MapToProductToCreate(createProduct);
            productToAdd.Id = _products.Max(p => p.Id) + 1;
            _products.Add(productToAdd);
            return MapToShowProductDto(productToAdd);
        }

        public bool UpdateProduct(UpdateProductDto product)
        {
            if (_products.All(p => p.Id != product.Id)) return false;

            var productToUpdate = _products.FirstOrDefault(p => p.Id == product.Id);
            _products.RemoveAt(_products.IndexOf(productToUpdate));
            _products.Add(MapToProductToUpdate(product));
            return true;
        }

        public bool DeleteProduct(int id)
        {
            if (_products.All(p => p.Id != id)) return false;

            var productToDelete = _products.FirstOrDefault(p => p.Id == id);
            _products.RemoveAt(_products.IndexOf(productToDelete));
            return true;
        }

        public ShowProductDto MapToShowProductDto(Product product)
        {
            return _mapper.Map<Product, ShowProductDto>(product);
        }

        public Product MapToProductToCreate(CreateProductDto productToAdd)
        {
            return _mapper.Map<CreateProductDto, Product>(productToAdd);
        }
        
        public Product MapToProductToUpdate(UpdateProductDto product)
        {
            return _mapper.Map<UpdateProductDto, Product>(product);
        }
    }
}
