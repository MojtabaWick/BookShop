using BookShop.Domain.BookAgg.Contracts;
using BookShop.Domain.BookAgg.Enitities;
using BookShop.Infrastructure.EFCore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.EFCore.Repositories.BookAgg
{
    public class BookRepository(AppDbContext appDbContext) : IBookRepository
    {
        public List<Book> GetBooks()
        {
            return appDbContext.Books.Include(x => x.Category).ToList();
        }

        public void Create(Book book)
        {
            appDbContext.Books.Add(book);
            appDbContext.SaveChanges();
        }

        public List<Book> LatestFiveBooks()
        {
            return appDbContext.Books
                 .OrderByDescending(b => b.Id)
                 .Take(5)
                 .OrderBy(b => b.Id)
                 .ToList();
        }
    }
}
