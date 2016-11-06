using FileManagmentSystem.App.Filters;
using FileManagmentSystem.App.ViewModels.Pager;
using FileManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagmentSystem.App.ViewModels
{
    public abstract class BaseListVM<TEntity, TFilter>
        where TEntity : BaseEntity
        where TFilter : BaseFilter<TEntity>, new()
    {
        public List<TEntity> Items { get; set; }

        public PagerVM Pager { get; set; }

        public TFilter Filter { get; set; }

        public BaseListVM()
        {
            this.Filter = new TFilter();
            this.Pager = new PagerVM();
            this.Items = new List<TEntity>();
        }
    }
}
