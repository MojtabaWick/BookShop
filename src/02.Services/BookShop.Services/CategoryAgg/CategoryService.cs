using BookShop.Domain.CategoryAgg.Contracts;
using BookShop.Domain.CategoryAgg.Entities;
using BookShop.Infrastructure.EFCore.Repositories.CategoryAgg;

namespace BookShop.Services.CategoryAgg
{
    public class CategoryService(ICategoryRepository _categoryRepository) : ICategoryService
    {
        public List<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }

        public void Create(string title)
        {
            _categoryRepository.Create(title);
        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }
    }
}
