using BusinessObjects.Models;

namespace Repositories
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        Product GetProductById(int id);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
        List<Category> GetCategories();
        List<Product> GetProducts();
    }
}
