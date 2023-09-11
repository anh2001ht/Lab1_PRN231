using BusinessObjects.Models;
using DataAccess;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product product) => ProductDAO.AddProduct(product);

        public void DeleteProduct(Product product) => ProductDAO.DeleteProduct(product);
        public List<Category> GetCategories() => CategoryDAO.GetCategories();

        public Product GetProductById(int id) => ProductDAO.GetProductById(id);

        public List<Product> GetProducts() => ProductDAO.GetProducts();

        public void UpdateProduct(Product product) => ProductDAO.UpdateProduct(product);
    }
}
