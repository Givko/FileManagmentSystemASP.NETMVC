using FileManagmentSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagmentSystem.Models
{
    /// <summary>
    /// Represents an entity class that describes a file in the system
    /// </summary>
    public class File : BaseEntity
    {
        /// <summary>
        /// The name of the file with which it will be stored on the server
        /// </summary>
        [Required]
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
        
        /// <summary>
        /// The path where the file is stored on the server
        /// </summary>
        [Required]
        public string Path { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
