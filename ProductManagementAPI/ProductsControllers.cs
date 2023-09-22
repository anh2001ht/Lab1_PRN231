using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace ProductManagementAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsControllers : ControllerBase
    {
        private IProductRepository repos = new ProductRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts() => repos.GetProducts();

        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            repos.AddProduct(product);
            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult DeleteProduct(int id)
        {
            var p = repos.GetProductById(id);
            if (p != null)
            {
                repos.DeleteProduct(p);
                return NoContent();
            }
            else return NotFound();
        }
        [HttpGet("id")]
        public IActionResult GetProduct(int id)
        {
            var p = repos.GetProductById(id);
            return Ok(p);
        }
        [HttpPut("id")]
        public IActionResult UpdateProduct(Product product)
        {
            repos.UpdateProduct(product);
            return NoContent();
        }
    }
}
