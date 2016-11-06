using FileManagmentSystem.App.ViewModels.Pager;
using FileManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FileManagmentSystem.App.Filters
{
    public abstract class BaseFilter<TEntity> : IFilter
        where TEntity : BaseEntity
    {
        public string Prefix { get; set; }

        public PagerVM ParentPager { get; set; }

        public abstract Expression<Func<TEntity, bool>> BuildFilter();
    }
}
