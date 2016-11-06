using FileManagmentSystem.App.Filters;
using FileManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Web.Mvc;
using FileManagmentSystem.App.Attributes;
using FileManagmentSystem.App.Authentication;
using System.Globalization;

namespace FileManagment.App.Filters.EntityFilters
{
    public class FileFilter : BaseFilter<File>
    {
        private string charsList = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public FileFilter()
        {
            this.Columns = new List<SelectListItem>() {
                new SelectListItem()
                {
                    Text="Users File Name",
                    Value = "FileNameGivenByUser"
                },
                new SelectListItem()
                {
                    Text="Discription",
                    Value = "Discription"
                },
                new SelectListItem()
                {
                    Text="Category",
                    Value = "Category"
                }
            };

            this.Symbols = new List<SelectListItem>();

            for (int i = 0; i < charsList.Length; i++)
            {
                this.Symbols.Add(new SelectListItem()
                {
                    Text = charsList[i].ToString(),
                    Value = charsList[i].ToString()
                });
            }
        }

        public string SortBy { get; set; }

        [FilterProperty(DisplayName = "Sort by: ", DropDownTargetPropery = "SortBy")]
        public List<SelectListItem> Columns { get; set; }

        public string Symbol { get; set; }

        [FilterProperty(DisplayName = "Choose symbol: ", DropDownTargetPropery = "Symbol")]
        public List<SelectListItem> Symbols { get; set; }

        public override Expression<Func<File, bool>> BuildFilter()
        {
            return f => ((f.UserId == AuthenticationManager.LoggedUser.Id) &&
                         (f.IsDeleted == false) && (String.IsNullOrEmpty(this.Symbol) || f.FileNameGivenByUser.ToLower().StartsWith(this.Symbol.ToLower())));
        }
    }
}