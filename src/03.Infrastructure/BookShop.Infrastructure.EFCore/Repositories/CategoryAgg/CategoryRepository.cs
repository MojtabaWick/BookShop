using BookShop.Domain.CategoryAgg.Contracts;
using BookShop.Domain.CategoryAgg.Dtos;
using BookShop.Domain.CategoryAgg.Entities;
using BookShop.Domain.UserAgg.Dtos;
using BookShop.Domain.UserAgg.Entities;
using BookShop.Infrastructure.EFCore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.EFCore.Repositories.CategoryAgg
{
    public class CategoryRepository(AppDbContext _context) : ICategoryRepository
    {
        public List<CategorySummeryDto> GetCategories()
        {
            return _context.Categories.Select(c=> new CategorySummeryDto
            {
                Id = c.Id,
                Title = c.Title,
                ImgAddress = c.ImgAddress,
                BooksCount = c.Books.Count,
            }).ToList();
        }

        public void Create(string title)
        {
            _context.Categories.Add(new Category { Title = title });
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            _context.Categories.Where(x => x.Id == id).ExecuteDelete();
        }
        public UpdateGetCategoryDto GetUpdateCategoryDetails(int categoryId)
        {
            var category = _context.Categories
            .Where(x => x.Id == categoryId)
            .AsNoTracking()
            .Select(u => new UpdateGetCategoryDto
            {
                Id = u.Id,
                Title= u.Title,
                ImgAddress= u.ImgAddress,
            }).FirstOrDefault();

            return category;
        }
        public bool Update(int categoryId, UpdateGetCategoryDto model)
        {
            try
            {
                var category = _context.Categories
                .FirstOrDefault(u => u.Id == categoryId);

                if (category is not null)
                {
                    category.Title = model.Title;

                    category.ImgAddress = (!string.IsNullOrEmpty(model.ImgAddress)) ? model.ImgAddress : category.ImgAddress;

                    _context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
