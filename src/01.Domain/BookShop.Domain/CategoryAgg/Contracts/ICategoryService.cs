using BookShop.Domain._common;
using BookShop.Domain.CategoryAgg.Dtos;
using BookShop.Domain.CategoryAgg.Entities;

namespace BookShop.Domain.CategoryAgg.Contracts
{
    public interface ICategoryService
    {
        public List<CategorySummeryDto> GetCategories();
        public void Create(string title);
        public void Delete(int id);
        public UpdateGetCategoryDto GetUpdateCategoryDetails(int categoryId);
        public Result<bool> Update(int categoryId, UpdateGetCategoryDto model);
    }
}
