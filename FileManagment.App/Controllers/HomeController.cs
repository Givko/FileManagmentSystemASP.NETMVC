using FileManagmentSystem.App.Authentication;
using FileManagmentSystem.App.ViewModels;
using FileManagmentSystem.App.ViewModels.UserViewModel;
using FileManagmentSystem.Models;
using FileManagmentSystem.Services;
using FileManagmentSystem.Services.EntitiesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FileManagment.App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountLoginVM viewModel)
        {
            AuthenticationManager.Authenticate(viewModel.Username, viewModel.Password);

            if (AuthenticationManager.LoggedUser == null)
            {
                ModelState.AddModelError("AuthenticationFailed", "WrongUsernameOrPassword");

                return View(viewModel);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserVM userVM)
        {
            TryUpdateModel(userVM);

            if (!ModelState.IsValid)
            {
                return View(userVM);
            }

            User user = new User();

            PopulateUserVMtoUserEntity(userVM, user);

            UserService service = new UserService();
            service.Save(user);

            user = service.GetById(user.Id);
            EmailService eSrvc = new EmailService(user);
            eSrvc.SendRegistrationEmail();

            return View("RegisteredView");
        }

        private void PopulateUserVMtoUserEntity(UserVM userVM, User user)
        {
            user.Email = userVM.Email;
            user.Password = Guid.NewGuid().ToString();
            user.FirstName = userVM.FirstName;
            user.LastName = userVM.LastName;
            user.Username = userVM.Username;
        }
    }
}