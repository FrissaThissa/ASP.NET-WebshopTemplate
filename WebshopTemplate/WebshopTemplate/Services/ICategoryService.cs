using WebshopTemplate.Models;

namespace WebshopTemplate.Services
{
    public interface ICategoryService
    {
        public List<Category> GetAllCategories();
        public List<Category> GetCategoryTree();
        public List<Category> GetHeadCategories();
        public List<Category> GetSubCategories(Category category);
        public void CreateCategory();
    }
}
