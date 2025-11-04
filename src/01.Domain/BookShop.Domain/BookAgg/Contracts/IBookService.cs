using BookShop.Domain.BookAgg.Enitities;

namespace BookShop.Domain.BookAgg.Contracts
{
    public interface IBookService
    {
        public List<Book> GetBooks();
        public void Create(Book book);
        public List<Book> LastFiveBooks();
    }
}
