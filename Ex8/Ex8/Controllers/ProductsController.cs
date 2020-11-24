using Ex8.Logic;
using Ex8.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Ex8.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService service)
        {
            _productsService = service;
        }

        public IActionResult Index()
        {
            return View(_productsService.ListAll().ToList());
        }

        
        public IActionResult Edit(int id)
        {
            var productToEdit = _productsService.ListAll().FirstOrDefault(x => x.Id == id);

            if (productToEdit != null)
            {
                return View(productToEdit);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            try
            {
                _productsService.Edit(id, product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var product = _productsService.ListAll().FirstOrDefault(x => x.Id == id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Product productToDelete)
        {
            try
            {
                _productsService.DeleteById(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}

