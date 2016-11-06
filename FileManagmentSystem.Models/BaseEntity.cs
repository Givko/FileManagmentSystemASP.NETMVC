using System;
using System.ComponentModel.DataAnnotations;

namespace FileManagmentSystem.Models
{
    public abstract class BaseEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime LastChangedOn { get; set; }
        
        public DateTime? DeletedOn { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
