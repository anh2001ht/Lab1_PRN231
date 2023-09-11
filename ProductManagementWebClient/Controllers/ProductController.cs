using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ProductManagementWebClient.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient client = null;
        private string ProductApiUrl = "";
        public ProductController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "https://localhost:7071/api/ProductsControllers";
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Product> lstProducts = JsonSerializer.Deserialize<List<Product>>(strData, options);
            return View(lstProducts);
        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{ProductApiUrl}/id?id={id}");
            
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Product deleted successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "Failed to delete the product.";
                return RedirectToAction("Index");
            }
        }
    }
}
