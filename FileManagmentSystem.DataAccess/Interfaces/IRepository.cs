using FileManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FileManagmentSystem.DataAccess.Interfaces
{
    interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        TEntity GetById(int id);
        void Delete(TEntity itemToDelete);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> expr = null, int page = 1, int pageSize = 1);
        List<TEntity> GetAll();
        int Count(Expression<Func<TEntity, bool>> expr = null);
        void Save(TEntity item);
    }
}
