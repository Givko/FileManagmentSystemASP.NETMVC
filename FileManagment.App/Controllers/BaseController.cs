using System.Net;
using System.Web.Mvc;
using FileManagmentSystem.App.Attributes;
using FileManagmentSystem.App.Filters;
using FileManagmentSystem.App.ViewModels;
using FileManagmentSystem.Models;
using FileManagmentSystem.Services;

namespace FileManagment.App.Controllers
{
    [AuthenticationFilter]
    public abstract class BaseController<TEntity, TEditVM, TListVM, TFilter, TService> : Controller
            where TEntity : BaseEntity, new()
            where TEditVM : BaseVM, new()
            where TFilter : BaseFilter<TEntity>, new()
            where TListVM : BaseListVM<TEntity, TFilter>, new()
            where TService : BaseService<TEntity>, new()
    {
        protected TService Service { get; set; }

        public BaseController()
        {
            this.Service = new TService();
        }

        protected abstract void PopulateItemToItemVM(TEntity item, TEditVM itemLVM);
        protected abstract void PopulateItemVMToItem(TEditVM viewModel, TEntity item);

        protected abstract ActionResult Redirect(TEntity item = null);

        public ActionResult Index()
        {

            TListVM itemLVM = new TListVM();
            itemLVM.Filter = new TFilter();
            TryUpdateModel(itemLVM);

            PopulateIndex(itemLVM);
            return View(itemLVM);
        }

        protected virtual void PopulateIndex(TListVM itemLVM)
        {
            string controllerName = GetControllerName();
            string actionName = GetActionName();

            itemLVM.Pager.Controller = controllerName;
            itemLVM.Pager.Action = actionName;

            itemLVM.Items = this.Service.GetAll(itemLVM.Filter.BuildFilter(), itemLVM.Pager.CurrentPage);
            itemLVM.Filter.ParentPager = itemLVM.Pager;
            itemLVM.Pager.Prefix = "Pager.";
            itemLVM.Filter.Prefix = "Filter.";
        }

        protected string GetActionName()
        {
            return this.ControllerContext.RouteData.Values["action"].ToString();
        }

        protected string GetControllerName()
        {
            return this.ControllerContext.RouteData.Values["controller"].ToString();
        }

        [HttpGet]
        public virtual ActionResult Edit(int? id)
        {
            TEntity item = null;
            TEditVM itemVM = new TEditVM();

            if (id == null)
            {
                item = new TEntity();
            }
            else
            {
                item = this.Service.GetById(id.Value);
            }

            PopulateHttpGetEdit(item, itemVM);

            PopulateItemToItemVM(item, itemVM);
            TryUpdateModel(itemVM);
            ModelState.Clear();

            return View(itemVM);
        }

        public virtual ActionResult Details(int? id)
        {

            TEditVM viewModel = new TEditVM();

            this.PopulateDetailsViewModel(viewModel, this.Service.GetById(id.Value));

            if (viewModel == null)
            {
                return this.HttpNotFound();
            }

            return this.View(viewModel);
        }

        protected virtual void PopulateDetailsViewModel(TEditVM model, TEntity entity)
        {

        }

        protected virtual void PopulateHttpGetEdit(TEntity entity, TEditVM itemVM)
        {

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(TEditVM viewModel)
        {

            TryUpdateModel(viewModel);
            TEntity item = new TEntity();

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            PopulateHttpPostEdit(item, viewModel);
            PopulateItemVMToItem(viewModel, item);
            this.Service.Save(item);

            return Redirect(item);
        }

        protected virtual void PopulateHttpPostEdit(TEntity item, TEditVM viewModel)
        {

        }

        public ActionResult Delete(int id)
        {
            if (FileManagmentSystem.App.Authentication.AuthenticationManager.LoggedUser == null)
            {
                return RedirectToAction("Login", "Home");
            }

            TEntity item = this.Service.GetById(id);
            PopulateDelete(item);
            this.Service.Delete(item);

            return Redirect(item);
        }

        protected virtual void PopulateDelete(TEntity item)
        {

        }
    }
}