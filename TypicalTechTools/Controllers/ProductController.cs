using Microsoft.AspNetCore.Mvc;
using TypicalTechTools.Models;
using TypicalTechTools.Models.Repositories;

namespace TypicalTools.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Show all products
        public IActionResult Index()
        {
            var products = _productRepository.GetAllProducts();
            return View(products);
        }

        // Show details of a product
        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // Show form to create a new product
        public IActionResult Create()
        {
            string authenticated = HttpContext.Session.GetString("Authenticated") ?? "False";
            if (!authenticated.Equals("True", StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToAction("AdminLogin", "Admin");
            }

            return View();
        }

        // POST: Create a new product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                string authenticated = HttpContext.Session.GetString("Authenticated") ?? "False";
                if (!authenticated.Equals("True", StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("AdminLogin", "Admin");
                }

                // Set the UpdatedDate before saving
                product.UpdatedDate = DateTime.UtcNow;

                _productRepository.CreateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // Show form to edit an existing product
        public IActionResult Edit(int id)
        {
            string authenticated = HttpContext.Session.GetString("Authenticated") ?? "False";
            if (!authenticated.Equals("True", StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToAction("AdminLogin", "Admin");
            }

            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Edit an existing product price
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, decimal productPrice)
        {
            string authenticated = HttpContext.Session.GetString("Authenticated") ?? "False";
            if (!authenticated.Equals("True", StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToAction("AdminLogin", "Admin");
            }

            var existingProduct = _productRepository.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.ProductPrice = productPrice;
            existingProduct.UpdatedDate = DateTime.UtcNow;


            _productRepository.UpdateProductPrice(existingProduct);
            return RedirectToAction(nameof(Index));
        }

        // Show confirmation page to delete a product
        public IActionResult Delete(int id)
        {
            string authenticated = HttpContext.Session.GetString("Authenticated") ?? "False";
            if (!authenticated.Equals("True", StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToAction("AdminLogin", "Admin");
            }

            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Delete a product
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            string authenticated = HttpContext.Session.GetString("Authenticated") ?? "False";
            if (!authenticated.Equals("True", StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToAction("AdminLogin", "Admin");
            }

            _productRepository.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        // Privacy page
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
