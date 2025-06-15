using FoodPandaIdentity.Models;
using FoodPandaIdentity.Models.Interfaces;
using FoodPandaIdentity.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodPandaIdentity.Controllers
{
    [Authorize(Policy = "RequireUser")]
    public class FoodController : Controller
    {
        IProductRepository _repo;
        public FoodController(IProductRepository proRepo)
        {
            _repo = proRepo;
        }

        public ViewResult FoodDetails()
        {
            return View();
        }
        public ViewResult FoodCategories()
        {
            return View();
        }
        public ViewResult FastFood()
        {
            var products = _repo.GetAllProducts()
                                  .Where(p => p.Category == "Fast Food")
                                  .ToList();
            return View("FastFood", products);
        }

        public ViewResult Breakfast()
        {
            var products = _repo.GetAllProducts()
                                     .Where(p => p.Category == "Breakfast")
                                     .ToList();
            return View("Breakfast", products);
        }

        public ViewResult DesiFood()
        {
            var products = _repo.GetAllProducts()
                                  .Where(p => p.Category == "Desi")
                                  .ToList();
            return View("DesiFood", products);
        }
        public IActionResult FoodDetailsDB()
        {
            List<Product> products = _repo.GetAllProducts();
            return View("FoodDetailsDB", products);
        }

    }
}
