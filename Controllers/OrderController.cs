using FoodPandaIdentity.Models;
using FoodPandaIdentity.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodPandaIdentity.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartRepository _repo;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(ICartRepository repo, UserManager<ApplicationUser> userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }

        private string GetUserId()
        {
            return _userManager.GetUserId(User);
        }
        [Authorize(Policy = "RequireUser")]

        public IActionResult ShoppingCart()
        {
            var items = _repo.GetCartItems(GetUserId());
            return View(items);
        }
        [Authorize(Policy = "RequireUser")]

        [HttpGet]
        public IActionResult AddToCart(int id)
        {
            var userId = GetUserId();
            _repo.AddToCart(userId, id);
            TempData["Message"] = "Product added to cart!";
            return RedirectToAction("ShoppingCart");
        }
        [Authorize(Policy = "RequireUser")]

        public IActionResult RemoveFromCart(int id)
        {
            _repo.RemoveFromCart(GetUserId(), id);
            TempData["Message"] = "Product removed from cart!";
            return RedirectToAction("ShoppingCart");
        }
        [Authorize(Policy = "RequireUser")]

        public IActionResult PlaceOrder()
        {
            var userId = GetUserId();
            _repo.PlaceOrder(userId);
            TempData["Message"] = "Order placed successfully!";
            return RedirectToAction("OrderHistory", "Customer");
        }
        [Authorize(Policy = "RequireAdmin")]
        public IActionResult ViewPlacedOrders_Admin()
        {
            var orders = _repo.GetPlacedOrdersAdmin();
            return View(orders);
        }
    }
}
