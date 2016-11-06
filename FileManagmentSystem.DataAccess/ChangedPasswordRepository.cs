using FileManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagmentSystem.DataAccess
{
   public class ChangedPasswordRepository : BaseRepository<ChangedPasswords>
    {
        public ChangedPasswordRepository()
            :base()
        {

        }
    }
}
