using BookShop.Domain.BookAgg.Enitities;
using BookShop.Domain.CategoryAgg.Entities;
using BookShop.Domain.UserAgg.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.EFCore.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
