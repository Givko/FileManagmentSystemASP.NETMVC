using System;

namespace FileManagmentSystem.App.ViewModels
{
    public class BaseVM
    {
        public int Id { get; set; }

        public DateTime LastChangedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
