using FoodPandaIdentity.Models.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace FoodPandaIdentity.Models.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ProductDBContext _context = new ProductDBContext();
        
        public List<CartItems> GetCartItems(string userId)
        {
            return _context.CartItems.Include(c => c.Product)
                                     .Where(c => c.UserId == userId).ToList();
        }

        public void AddToCart(string userId, int productId)
        {
            var existingItem = _context.CartItems
                .FirstOrDefault(c => c.UserId == userId && c.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                _context.CartItems.Add(new CartItems
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = 1
                });
            }

            _context.SaveChanges();
        }

        public void RemoveFromCart(string userId, int productId)
        {
            var item = _context.CartItems
                .FirstOrDefault(c => c.UserId == userId && c.ProductId == productId);

            if (item != null)
            {
                if(item.Quantity > 1)
                item.Quantity--;
                else 
                    _context.CartItems.Remove(item);
                _context.SaveChanges();
            }
        }
        public void PlaceOrder(string userId)
        {
            var cartItems = _context.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToList();

            foreach (var item in cartItems)
            {
                var order = new PlacedOrders
                {
                    Name = item.Product.Name,
                    Quantity = item.Quantity,
                    TotalBill = item.Product.Price * item.Quantity,
                    UserId = userId
                };

                _context.PlacedOrders.Add(order);
            }

            _context.CartItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }

        public List<PlacedOrders> GetPlacedOrders(string userId)
        {
            return _context.PlacedOrders
                          .Where(po => po.UserId == userId)
                          .ToList();
        }

        public List<PlacedOrders> GetPlacedOrdersAdmin()
        {
            return _context.PlacedOrders
                          .ToList();
        }

    }
}
