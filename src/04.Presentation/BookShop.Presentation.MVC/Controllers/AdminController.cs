using BookShop.Domain.UserAgg.Contracts;
using BookShop.Services.UserAgg;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Presentation.MVC.Controllers
{
    public class AdminController(IUserService userService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Users()
        {
            var users = userService.GetUsersSummary();

            return View(users);
        }
        public IActionResult ActiveUser(int userId)
        {
            userService.Active(userId);

            return RedirectToAction("Users");
        }
        [HttpGet]
        public IActionResult DeActiveUser(int userId)
        {
            userService.DeActive(userId);

            return RedirectToAction("Users");
        }
        public IActionResult DeleteUser(int userId)
        {
            userService.Delete(userId);
            return RedirectToAction("Users");
        }

    }
}
