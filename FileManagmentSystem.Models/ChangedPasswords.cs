using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagmentSystem.Models
{
    public class ChangedPasswords : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        [MaxLength(50)]
        public string OldPassword { get; set; }

        [Required]
        [MaxLength(50)]
        public string CurrentPassword { get; set; }
        
    }
}
