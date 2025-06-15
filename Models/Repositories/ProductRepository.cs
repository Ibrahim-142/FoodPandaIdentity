using FoodPandaIdentity.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodPandaIdentity.Models.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDBContext db = new ProductDBContext();

        public List<Product> GetAllProducts()
        {
            return db.Products.ToList();
        }

        public void AddProduct(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
        }

        public void EditProduct(int id, Product newProduct)
        {
            var product = db.Products.Find(id);
            if (product != null)
            {
                product.Name = newProduct.Name;
                product.Category = newProduct.Category;
                product.Description = newProduct.Description;
                product.Price = newProduct.Price;
                product.ImageUrl = newProduct.ImageUrl;
                db.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            var product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }
    }
}
