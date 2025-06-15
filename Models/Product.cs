namespace FoodPandaIdentity.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public Product() { }

        public Product(string Name, string Category, string Description, decimal Price, string ImageUrl)
        {
            this.Name = Name;
            this.Category = Category;
            this.Description = Description;
            this.Price = Price;
            this.ImageUrl = ImageUrl;
        }


    }

}
