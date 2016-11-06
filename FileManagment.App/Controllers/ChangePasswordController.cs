using System.Net;
using System.Linq;
using System.Web.Mvc;
using FileManagmentSystem.App.ViewModels.ChangePasswordViewModels;
using FileManagmentSystem.Models;
using FileManagmentSystem.Services.EntitiesServices;

namespace FileManagment.App.Controllers
{
    public class ChangePasswordController : Controller
    {
        [HttpGet]
        public ActionResult ChangePassword()
        {
            ChangePasswordEditVM itemVM = new ChangePasswordEditVM();
            TryUpdateModel(itemVM);
            ModelState.Clear();

            return View(itemVM);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordEditVM itemVM)
        {

            TryUpdateModel(itemVM);

            WebClient s = new WebClient();

            if (!ModelState.IsValid)
            {
                return View(itemVM);
            }
            ChangedPasswordService cpService = new ChangedPasswordService();
            UserService userService = new UserService();
            User user = userService.GetAll(u => u.Password == itemVM.OldPassword).FirstOrDefault();
            if (user == null)
            {
                return View(itemVM);
            }
            ChangedPasswords entity = new ChangedPasswords();
            PopulateEntity(entity, itemVM);
            cpService.Save(entity);
            user.Password = itemVM.Password;
            userService.Save(user);

            return RedirectToAction("Index", "Home");
        }

        private void PopulateEntity(ChangedPasswords entity, ChangePasswordEditVM itemVM)
        {
            entity.CurrentPassword = itemVM.Password;
            entity.OldPassword = itemVM.OldPassword;
            entity.UserId = itemVM.UserId;
        }
    }
}