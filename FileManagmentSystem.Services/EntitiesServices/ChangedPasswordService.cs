using FileManagmentSystem.DataAccess;
using FileManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagmentSystem.Services.EntitiesServices
{
    public class ChangedPasswordService : BaseService<ChangedPasswords>
    {
        public ChangedPasswordService()
            :base()
        {
            this.Repo = new ChangedPasswordRepository();
        }
    }
}
