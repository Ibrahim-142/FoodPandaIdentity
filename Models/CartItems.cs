﻿namespace FoodPandaIdentity.Models
{
    public class CartItems
    {
        public int Id { get; set; }
        public string UserId { get; set; }  
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
