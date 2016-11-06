using FileManagmentSystem.App.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileManagmentSystem.App.ViewModels.ChangePasswordViewModels
{
    public class ChangePasswordEditVM
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string OldPassword { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        [IsEqual("Password")]
        public string VerifyPassword { get; set; }

    }
}