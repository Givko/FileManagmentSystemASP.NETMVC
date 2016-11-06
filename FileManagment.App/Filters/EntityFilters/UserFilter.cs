using FileManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using FileManagmentSystem.App.Attributes;
using System.Web.Mvc;

namespace FileManagmentSystem.App.Filters.EntityFilters
{
    public class UserFilter : BaseFilter<User>
    {
        public UserFilter()
        {

        }

        [FilterProperty(DisplayName = "Username ")]
        public string Username { get; set; }

        [FilterProperty(DisplayName = "First name ")]
        public string FirstName { get; set; }

        [FilterProperty(DisplayName = "Last name ")]
        public string LastName { get; set; }

        public override Expression<Func<User, bool>> BuildFilter()
        {
            Expression<Func<User, bool>> filter =
                  u => (string.IsNullOrEmpty(this.FirstName) || u.FirstName.Contains(this.FirstName.Trim()))
                  && (string.IsNullOrEmpty(this.LastName) || u.LastName.Contains(this.LastName.Trim()))
                 && (string.IsNullOrEmpty(this.Username) || u.Username.Contains(this.Username));

            return filter;
        }
    }
}
