using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Collections.Generic;
using FileManagmentSystem.Models;
using FileManagmentSystem.DataAccess.Interfaces;

namespace FileManagmentSystem.DataAccess
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        private FileManagmentSystemContext<TEntity> dbContext { get; set; }

        public BaseRepository()
        {
            dbContext = new FileManagmentSystemContext<TEntity>();
        }
        private void Add(TEntity item)
        {
            item.CreatedOn = DateTime.Now;
            item.LastChangedOn = DateTime.Now;
            dbContext.Items.Add(item);
            dbContext.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return dbContext.Items.Find(id);
        }

        public void Delete(TEntity itemToDelete)
        {
            var itemToBeDeleted = dbContext.Items.Find(itemToDelete.Id);
            itemToBeDeleted.IsDeleted = true;
            itemToBeDeleted.DeletedOn = DateTime.Now;
            dbContext.Entry(itemToBeDeleted).State = EntityState.Modified;

            dbContext.SaveChanges();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> expr = null, int page = 1, int pageSize = 1)
        {
            List<TEntity> result = null;

            if (expr != null)
            {
                result = dbContext.Items.Where(expr).OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                result = dbContext.Items.OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }

            return result;
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> expr)
        {
            return dbContext.Items.Where(expr).ToList();
        }

        public List<TEntity> GetAll()
        {
            List<TEntity> result = dbContext.Items.ToList();

            return result;
        }

        public int Count(Expression<Func<TEntity, bool>> expr = null)
        {
            return expr == null ? dbContext.Items.Count() : dbContext.Items.Count(expr);
        }

        private void Update(TEntity item)
        {
            item.LastChangedOn = DateTime.Now;
            dbContext.Entry(item).State = EntityState.Modified;

            dbContext.SaveChanges();
        }

        public void Save(TEntity item)
        {
            if (item.Id > 0)
            {
                Update(item);
            }
            else
            {
                Add(item);
            }
        }
    }
}