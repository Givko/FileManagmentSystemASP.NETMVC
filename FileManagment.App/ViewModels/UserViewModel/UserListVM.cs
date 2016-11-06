using FileManagmentSystem.App.Filters.EntityFilters;
using FileManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagmentSystem.App.ViewModels.UserViewModel
{
    public class UserListVM : BaseListVM<User,UserFilter>
    {
        public UserListVM()
            :base()
        {

        }
    }
}
