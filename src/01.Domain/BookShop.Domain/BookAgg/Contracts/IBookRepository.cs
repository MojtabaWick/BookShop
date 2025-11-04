using BookShop.Domain.BookAgg.Enitities;

namespace BookShop.Domain.BookAgg.Contracts
{
    public interface IBookRepository
    {
        public List<Book> GetBooks();
        public void Create(Book book);
        public List<Book> LatestFiveBooks();
    }
}
