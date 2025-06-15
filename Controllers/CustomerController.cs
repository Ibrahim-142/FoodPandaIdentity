using FoodPandaIdentity.Models;
using FoodPandaIdentity.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodPandaIdentity.Controllers
{
    [Authorize(Policy = "RequireUser")]
    public class CustomerController : Controller
    {
        private readonly ICartRepository _repo;
        private readonly UserManager<ApplicationUser> _userManager;
        public CustomerController(ICartRepository repo, UserManager<ApplicationUser> userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }
        public IActionResult OrderHistory()
        {
            var orders = _repo.GetPlacedOrders(_userManager.GetUserId(User));
            return View(orders);
        }
        public ViewResult CustomerDashboard()
        {
            return View();
        }
    }
}
