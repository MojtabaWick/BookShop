using BookShop.Domain.CategoryAgg.Contracts;
using BookShop.Domain.CategoryAgg.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Presentation.MVC.Controllers
{
    public class CategoryController(ICategoryService categoryService) : Controller
    {
        public IActionResult Index()
        {
            var categories = categoryService.GetCategories();

            return View(categories);
        }
        public IActionResult DeleteCategory(int userId)
        {
            categoryService.Delete(userId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int userId)
        {
            var result = categoryService.GetUpdateCategoryDetails(userId);

            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateCategory(UpdateGetCategoryDto model)
        {
            var result = categoryService.Update(model.Id, model);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = result.Message;
            }
                
            return View(model);
        }
    }
}
