using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var lstProducts = new List<Product>();
            using (var context = new Lab1231Context())
            {
                lstProducts = context.Products.ToList();
            }
            return lstProducts;

        }

        public static Product GetProductById(int id)
        {
            using (var context = new Lab1231Context())
            {
                var product = context.Products.FirstOrDefault(x => x.ProductId == id);
                return product;
            }
        }

        public static void AddProduct(Product product)
        {
            using (var context = new Lab1231Context())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public static void UpdateProduct(Product product)
        {
            using (var context = new Lab1231Context())
            {
                context.Products.Update(product);
                context.SaveChanges();
            }
        }
        public static void DeleteProduct(Product product)
        {
            using (var context = new Lab1231Context())
            {
                var p = context.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
                context.Products.Remove(p);
                context.SaveChanges();
            }
        }
    }
}
