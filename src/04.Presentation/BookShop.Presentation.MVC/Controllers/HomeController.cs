using BookShop.Domain.BookAgg.Contracts;
using BookShop.Domain.CategoryAgg.Contracts;
using BookShop.Presentation.MVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Presentation.MVC.Controllers
{
    public class HomeController(IBookService _bookService, ICategoryService _categoryService) : Controller
    {

        public IActionResult Index()
        {
            var model = new ListBookViewModel
            {
                Books = _bookService.LastFiveBooks(),
                Categories = _categoryService.GetCategories()
            };

            return View(model);
        }
        [HttpGet]
        public IActionResult CreateBook()
        {
            var model = new CreateBookViewModel()
            {
                Categories = _categoryService.GetCategories(),
                Book = null
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult CreateBook(CreateBookViewModel model)
        {
            _bookService.Create(model.Book);
            return RedirectToAction("Index");
        }
    }
}
