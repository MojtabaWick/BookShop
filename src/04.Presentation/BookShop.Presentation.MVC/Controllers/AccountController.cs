using BookShop.Domain.UserAgg.Contracts;
using BookShop.Domain.UserAgg.Dtos;
using BookShop.Presentation.MVC.Database;
using BookShop.Presentation.MVC.Models;
using BookShop.Presentation.MVC.Models.ViewModels;
using BookShop.Services.UserAgg;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Presentation.MVC.Controllers
{
    public class AccountController(IUserService userService) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var loginResullt = userService.Login(model.Mobile, model.Password);

            if (loginResullt.IsSuccess)
            {
                if (loginResullt.Data!.IsAdmin)
                {
                    InMemoryDatabase.OnlineUser = new OnlineUser
                    {
                        Id = loginResullt.Data.Id,
                        IsAdmin = loginResullt.Data.IsAdmin,
                        Username = loginResullt.Data.Username
                    };

                    ViewBag.FullName = loginResullt.Data.FullName;

                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    // Redirect to user
                }
            }
            else
            {
                ViewBag.Error = loginResullt.Message;
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }


        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var userModel = new RegisterUserInputDto
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.Mobile,
                Password = model.Password,
                Username = model.Username,
                IsAdmin = model.IsAdmin,
            };

            var registerResult = userService.Register(userModel);

            if (registerResult.IsSuccess)
            {
                RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = registerResult.Message;
            }

            return View(model);
        }
    }
}
