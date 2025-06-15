using FoodPandaIdentity.Models;
using FoodPandaIdentity.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FoodPandaIdentity.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace FoodPandaIdentity.Controllers
{
    [Authorize(Policy = "RequireAdmin")]
    public class AdminController : Controller
    {
        private readonly IProductRepository _proRepo;
        private readonly IHubContext<ProductHub> _hubContext;

        public AdminController(IProductRepository proRepo, IHubContext<ProductHub> hubContext)
        {
            _proRepo = proRepo;
            _hubContext = hubContext;
        }

        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(string name, string category, string price, string description, string imageUrl)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name) ||
                    string.IsNullOrWhiteSpace(category) ||
                    string.IsNullOrWhiteSpace(price) ||
                    string.IsNullOrWhiteSpace(description) ||
                    string.IsNullOrWhiteSpace(imageUrl))
                {
                    TempData["ErrorMessage"] = "All fields are required.";
                    return RedirectToAction("ErrorAdmin");

                }

                if (!decimal.TryParse(price, out decimal parsedPrice) || parsedPrice <= 0)
                {
                    TempData["ErrorMessage"] = "Price must be a valid positive number.";
                    return RedirectToAction("ErrorAdmin");

                }
                if (!imageUrl.Contains("/"))
                {
                    TempData["ErrorMessage"] = "Image URL must contain a '/'.";
                    return RedirectToAction("ErrorAdmin");

                }
                Product product = new Product(name, category, description, parsedPrice, imageUrl);
                _proRepo.AddProduct(product);
                return RedirectToAction("AdminDashboard");
            }
            catch (Exception ex)
            {
                TempData["ErrorSource"] = "AddProduct";
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("ErrorAdmin");
            }
        }


        public ViewResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteProduct(string id)
        {
            try
            {
                if (!int.TryParse(id, out int parsedId) || parsedId <= 0)
                {
                    TempData["ErrorSource"] = "Delete Function";

                    TempData["ErrorMessage"] = "Invalid product ID.";
                    return RedirectToAction("ErrorAdmin");
                }
                    _proRepo.DeleteProduct(int.Parse(id));
                return RedirectToAction("AdminDashboard");
            }
            catch (Exception ex)
            {
                TempData["ErrorSource"] = "DeleteProduct";
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("ErrorAdmin");
            }
        }

        public ViewResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(string id, string name, string category, string price, string description, string imageUrl)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id) ||
                    string.IsNullOrWhiteSpace(name) ||
                    string.IsNullOrWhiteSpace(category) ||
                    string.IsNullOrWhiteSpace(price) ||
                    string.IsNullOrWhiteSpace(description) ||
                    string.IsNullOrWhiteSpace(imageUrl))
                {
                    TempData["ErrorMessage"] = "All fields are required.";
                    return RedirectToAction("ErrorAdmin");

                }
                if (!int.TryParse(id, out int parsedId) ||parsedId<=0)
                {
                    TempData["ErrorMessage"] = "Invalid product ID.";
                    return RedirectToAction("ErrorAdmin");

                }
                if (!decimal.TryParse(price, out decimal parsedPrice) || parsedPrice <= 0)
                {
                    TempData["ErrorMessage"] = "Price must be a valid positive number.";
                    return RedirectToAction("ErrorAdmin");

                }
                if (!imageUrl.Contains("/"))
                {
                    TempData["ErrorMessage"] = "Image URL must contain a '/'.";
                    return RedirectToAction("ErrorAdmin");

                }

                Product product = new Product(name, category, description, parsedPrice, imageUrl);
                _proRepo.EditProduct(parsedId, product);
                await _hubContext.Clients.All.SendAsync("ReceiveProductUpdate", product);

                return RedirectToAction("AdminDashboard");
            }
            catch (Exception ex)
            {
                TempData["ErrorSource"] = "EditProduct";
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("ErrorAdmin");
            }
        }



        public ViewResult AdminDashboard()
        {
            return View();
        }

        public ViewResult ErrorAdmin()
        {
            return View();
        }
    }
}
