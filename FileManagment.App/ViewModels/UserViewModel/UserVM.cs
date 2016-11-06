using FileManagmentSystem.App.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagmentSystem.App.ViewModels.UserViewModel
{
    public class UserVM : BaseVM
    {
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        [Unique("FileManagmentSystem.Models.User")]
        public string Username { get; set; }
        
        [MaxLength(50)]
        [MinLength(5)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        [Unique("FileManagmentSystem.Models.User")]
        public string Email { get; set; }
    }
}
