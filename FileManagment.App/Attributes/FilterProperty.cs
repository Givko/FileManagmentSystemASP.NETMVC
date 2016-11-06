using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagmentSystem.App.Attributes
{
    public class FilterPropertyAttribute : Attribute
    {
        public string DisplayName { get; set; }

        public string DropDownTargetPropery { get; set; }

    }
}
