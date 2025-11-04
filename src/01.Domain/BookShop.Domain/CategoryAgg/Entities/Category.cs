using BookShop.Domain.BookAgg.Enitities;

namespace BookShop.Domain.CategoryAgg.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ImgAddress { get; set; }

        public List<Book> Books { get; set; } = [];
    }
}
