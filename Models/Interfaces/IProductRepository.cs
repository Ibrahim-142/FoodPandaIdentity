namespace FoodPandaIdentity.Models.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();

        void AddProduct(Product p);

        void EditProduct(int id,  Product p);

        void DeleteProduct(int id);
    }
}
