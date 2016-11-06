using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagmentSystem.App.ViewModels.Pager;

namespace FileManagmentSystem.App.Filters
{
    public interface IFilter
    {
        PagerVM ParentPager { get; set; }
        string Prefix { get; set; }
    }
}
