namespace FileManagmentSystem.DataAccess
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FileManagmentSystemContext<TEntity> : DbContext
        where TEntity : BaseEntity
    {
        public FileManagmentSystemContext()
            : base("name=FileManagmentSystemContext")
        {
        }

        public virtual DbSet<TEntity> Items { get; set; }
    }
}