using FileManagmentSystem.App.Attributes;
using FileManagmentSystem.App.Filters.EntityFilters;
using FileManagmentSystem.App.ViewModels.UserViewModel;
using FileManagmentSystem.Models;
using FileManagmentSystem.Services.EntitiesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileManagment.App.Controllers
{
    [AuthenticationFilter]
    public class UserController : BaseController<User,UserVM,UserListVM,UserFilter,UserService>
    {
        public UserController()
            :base()
        {

        }
        protected override void PopulateItemVMToItem(UserVM userVM, User user)
        {
            user.Id = userVM.Id;
            user.Username = userVM.Username;
            user.Password = userVM.Password;
            user.FirstName = userVM.FirstName;
            user.LastName = userVM.LastName;
            user.Email = userVM.Email;
            user.IsDeleted = userVM.IsDeleted;
        }

        protected override ActionResult Redirect(User item = null)
        {
            return RedirectToAction("Index", "User");
        }

        protected override void PopulateItemToItemVM(User user, UserVM userVM)
        {
            userVM.Id = user.Id;
            userVM.Username = user.Username;
            userVM.Password = user.Password;
            userVM.FirstName = user.FirstName;
            userVM.LastName = user.LastName;
            user.Email = userVM.Email;
            userVM.IsDeleted = user.IsDeleted;
        }

        protected override void PopulateDetailsViewModel(UserVM model, User entity)
        {
            model.Email = entity.Email;
            model.Id = entity.Id;
            model.LastName = entity.LastName;
            model.Username = entity.Username;
            model.CreatedOn = entity.CreatedOn;
            model.LastChangedOn = entity.LastChangedOn;
            model.IsDeleted = entity.IsDeleted;
            model.FirstName = entity.FirstName;
        }
    }
}