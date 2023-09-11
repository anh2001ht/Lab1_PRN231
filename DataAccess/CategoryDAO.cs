using BusinessObjects.Models;

namespace DataAccess
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            var lstCategories = new List<Category>();
            using (var context = new Prn221dbContext())
            {
                lstCategories = context.Categories.ToList();
            }
            return lstCategories;
        }
    }
}
