using BusinessObjects.Models;

namespace DataAccess
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            var lstCategories = new List<Category>();
            using (var context = new Lab1231Context())
            {
                lstCategories = context.Categories.ToList();
            }
            return lstCategories;
        }
    }
}
