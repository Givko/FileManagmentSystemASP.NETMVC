using FileManagmentSystem.App.ViewModels;
using FileManagmentSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileManagmentSystem.App.ViewModels.FileViewModels
{
    public class FileEditVM : BaseVM
    {
        public string FileName { get; set; }
        /// <summary>
        /// The name of the file given by the user
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string FileNameGivenByUser { get; set; }

        /// <summary>
        /// The discription of the file
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public FileCategory Category { get; set; }

        [Required]
        public int UserId { get; set; }

        public string Username { get; set; }

    }
}