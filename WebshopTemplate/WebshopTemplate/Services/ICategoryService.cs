using WebshopTemplate.Models;

namespace WebshopTemplate.Services
{
    public interface ICategoryService
    {
        public List<Category> GetAllCategories();
        public Category GetCategoryById(int id);
        public Category GetCategoryByName(string name);
        public List<Category> GetCategoryTree();
        public List<Category> GetHeadCategories();
        public List<Category> GetHeadCategories(Category category);
        public List<Category> GetSubCategories(Category category);
        public void CreateCategory(Category category);
        public void UpdateCategory(Category category);
    }
}