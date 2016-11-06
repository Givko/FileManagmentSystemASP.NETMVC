using FileManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagmentSystem.DataAccess.Service
{
    public class AuthenticationService
    {
        public User LoggedUser { get; set; }

        public void AuthenticateUser(string username, string password)
        {
            UserRepository repo = new UserRepository();
            List<User> users = repo.GetAll((u) => u.Username == username && u.Password == password).ToList();

            this.LoggedUser = users.Count > 0 ? users[0] : null;
        }
    }
}
