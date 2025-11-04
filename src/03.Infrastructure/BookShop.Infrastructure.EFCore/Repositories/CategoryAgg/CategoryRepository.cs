using BookShop.Domain.CategoryAgg.Contracts;
using BookShop.Domain.CategoryAgg.Entities;
using BookShop.Infrastructure.EFCore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.EFCore.Repositories.CategoryAgg
{
    public class CategoryRepository(AppDbContext _context) : ICategoryRepository
    {
        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
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
    }
}
