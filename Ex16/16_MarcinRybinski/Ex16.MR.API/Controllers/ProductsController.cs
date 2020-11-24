using Ex16.MR.BLL.Models.DTO;
using Ex16.MR.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Type = Ex16.MR.BLL.Models.Type;

namespace Ex16.MR.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<ShowProductDto>> GetAllProducts()
        {
            return Ok(_productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<ShowProductDto> GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return BadRequest($"Product with id = {id} does not exist.");
            return Ok(product);
        }

        [HttpPost]
        public ActionResult CreateProduct(CreateProductDto productToCreate)
        {
            if (!Enum.IsDefined(typeof(Type), productToCreate.Type)) 
                return BadRequest("Wrong type (should be 0 - for Food, 1 - for Drink, 2 - for Other).");
            var addedProduct = _productService.AddProduct(productToCreate);
            return Ok(addedProduct);
        }

        [HttpPut]
        public ActionResult UpdateProduct(UpdateProductDto product)
        {
            if (!Enum.IsDefined(typeof(Type), product.Type))
                return BadRequest("Wrong type (should be 0 - for Food, 1 - for Drink, 2 - for Other).");
            var updateStatus = _productService.UpdateProduct(product);
            return updateStatus == false 
                ? StatusCode(500, $"Product with id = {product.Id} does not exist.") 
                : Ok($"Product {product.Id} updated.");
        }

        [HttpDelete]
        public ActionResult DeleteProduct([FromHeader] int id)
        {
            var deleteStatus = _productService.DeleteProduct(id);
            return deleteStatus == false
                ? StatusCode(500, $"Product with id = {id} does not exist.")
                : Ok($"Product {id} deleted.");
        }
    }
}
