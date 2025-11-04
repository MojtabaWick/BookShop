using BookShop.Domain.BookAgg.Enitities;
using BookShop.Domain.CategoryAgg.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.EFCore.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
