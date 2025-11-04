using BookShop.Domain.BookAgg.Enitities;
using BookShop.Domain.CategoryAgg.Entities;

namespace BookShop.Presentation.MVC.Models.ViewModels
{
    public class ListBookViewModel
    {
        public List<Book> Books { get; set; } = [];
        public List<Category> Categories { get; set; } = [];
    }
}
