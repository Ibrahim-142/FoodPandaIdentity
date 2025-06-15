namespace FoodPandaIdentity.Models.Interfaces
{
    public interface ICartRepository
    {
        public List<CartItems> GetCartItems(string userId);
        public void AddToCart(string userId, int productId);

        public void RemoveFromCart(string userId, int productId);
        public void PlaceOrder(string userId);
        public List<PlacedOrders> GetPlacedOrders(string userId);
        public List<PlacedOrders> GetPlacedOrdersAdmin();


    }
}
