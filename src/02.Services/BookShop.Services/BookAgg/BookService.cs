using BookShop.Domain.BookAgg.Contracts;
using BookShop.Domain.BookAgg.Enitities;
using BookShop.Domain.FileAgg.Contracts;

namespace BookShop.Services.BookAgg
{
    public class BookService(IFileService _fileService, IBookRepository bookRepository) : IBookService
    {

        public List<Book> GetBooks()
        {
            return bookRepository.GetBooks();
        }

        public void Create(Book book)
        {
            book.ImageUrl = _fileService.Upload(book.File);
            bookRepository.Create(book);
        }

        public List<Book> LastFiveBooks()
        {
            return bookRepository.LatestFiveBooks();
        }
    }
}



