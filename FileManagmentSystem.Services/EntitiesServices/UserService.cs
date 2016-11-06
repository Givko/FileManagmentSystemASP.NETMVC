using FileManagmentSystem.DataAccess;
using FileManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagmentSystem.Services.EntitiesServices
{
    public class UserService : BaseService<User>
    {
        public UserService( )
            :base()
        {
            this.Repo = new UserRepository();
        }
    }
}
