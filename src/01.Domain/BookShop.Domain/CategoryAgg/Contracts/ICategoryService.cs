using BookShop.Domain.CategoryAgg.Entities;

namespace BookShop.Domain.CategoryAgg.Contracts
{
    public interface ICategoryService
    {
        public List<Category> GetCategories();
        public void Create(string title);
        public void Delete(int id);
    }
}
