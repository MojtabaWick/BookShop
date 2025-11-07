using BookShop.Domain.BookAgg.Enitities;
using BookShop.Domain.CategoryAgg.Dtos;
using BookShop.Domain.CategoryAgg.Entities;

namespace BookShop.Presentation.MVC.Models.ViewModels
{
    public class CreateBookViewModel
    {
        public List<CategorySummeryDto> Categories { get; set; }
        public Book? Book { get; set; }
    }
}
