using FoodPandaIdentity.Models;
using Microsoft.AspNetCore.SignalR;

namespace FoodPandaIdentity.Hubs
{
    public class ProductHub : Hub
    {
        public async Task SendProductUpdate(Product product)
        {
            await Clients.All.SendAsync("ReceiveProductUpdate", product);
        }
    }
}