namespace FoodPandaIdentity.Models
{
        public class PlacedOrders
        {
            public int Id { get; set; }
            public string Name { get; set; } 
            public int Quantity { get; set; }
            public decimal TotalBill { get; set; }
            public string UserId { get; set; } 
        }

    
}

