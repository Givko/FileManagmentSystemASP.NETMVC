using FileManagment.App.Filters.EntityFilters;
using FileManagmentSystem.App.ViewModels.FileViewModels;
using FileManagmentSystem.Models;
using FileManagmentSystem.Services.EntitiesServices;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;
using System;
using FileManagmentSystem.App.ViewModels.Pager;
using FileManagmentSystem.App.Attributes;

namespace FileManagment.App.Controllers
{
    [AuthenticationFilter]
    public class FileController : BaseController<File, FileEditVM, FileListVM, FileFilter, FileService>
    {
        protected override void PopulateItemToItemVM(File item, FileEditVM itemLVM)
        {
            itemLVM.Category = item.Category;
            itemLVM.Description = item.Description;
            itemLVM.FileName = item.FileName;
            itemLVM.CreatedOn = item.CreatedOn;
            itemLVM.LastChangedOn = item.LastChangedOn;
            itemLVM.FileNameGivenByUser = item.FileNameGivenByUser;
            itemLVM.UserId = item.UserId;
            if (itemLVM.UserId > 0)
            {
                itemLVM.Username = new UserService().GetById(item.UserId).Username;
            }
            itemLVM.Id = item.Id;
            itemLVM.IsDeleted = item.IsDeleted;
        }

        protected override void PopulateItemVMToItem(FileEditVM viewModel, File item)
        {
            item.Id = viewModel.Id;
            item.IsDeleted = viewModel.IsDeleted;
            item.CreatedOn = viewModel.CreatedOn;
            item.LastChangedOn = viewModel.LastChangedOn;
            item.FileName = viewModel.FileName;
            item.Category = viewModel.Category;
            item.Description = viewModel.Description;
            item.FileNameGivenByUser = viewModel.FileNameGivenByUser;
            item.Path = WebConfigurationManager.AppSettings["FilePath"];
            item.UserId = FileManagmentSystem.App.Authentication.AuthenticationManager.LoggedUser.Id;
        }

        protected override ActionResult Redirect(File item = null)
        {
            return RedirectToAction("Index", "File");
        }

        protected override void PopulateIndex(FileListVM itemLVM)
        {
            Func<IEnumerable<File>, IOrderedEnumerable<File>> order = null;

            string sortBy = this.Request.QueryString["Filter.SortBy"];
            string controllerName = GetControllerName();
            string actionName = GetActionName();

            switch (sortBy)
            {
                case "FileNameGivenByUser":
                    order = f => f.OrderBy(t => t.FileNameGivenByUser);
                    break;
                case "Discription":
                    order = f => f.OrderBy(t => t.Description);
                    break;
                case "Category":
                    order = f => f.OrderBy(t => t.Category.ToString());
                    break;
                default:
                    order = f => f.OrderBy(t => t.FileNameGivenByUser);
                    break;
            }
            
                itemLVM.Items = order(this.Service.GetAll(itemLVM.Filter.BuildFilter()))
                   .Skip((itemLVM.Pager.CurrentPage - 1) * 10)
                   .Take(10)
                   .ToList();
                itemLVM.Pager = new PagerVM(this.Service.GetAll(itemLVM.Filter.BuildFilter()).Count, itemLVM.Pager.CurrentPage, "Pager.", actionName, controllerName);
            

            itemLVM.Filter.ParentPager = itemLVM.Pager;
            itemLVM.Filter.Prefix = "Filter.";
        }

        public ActionResult DownLoadFile(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            File file = this.Service.GetById(id.Value);
            this.Service.DownloadFile(file);
            return new EmptyResult();
        }

        protected override void PopulateDetailsViewModel(FileEditVM model, File entity)
        {
            model.Id = entity.Id;
            model.FileName = entity.FileName;
            model.FileNameGivenByUser = entity.FileNameGivenByUser;
            model.Description = entity.Description;
            model.Category = entity.Category;
            model.Username = entity.User.Username; 
        }
    }
}