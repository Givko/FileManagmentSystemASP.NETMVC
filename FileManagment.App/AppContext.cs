using System.Data.Entity;
using FileManagmentSystem.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using FileManagment.App.Migrations;

namespace FileManagment.App
{

    public class AppContext : DbContext
    {
        public AppContext()
            : base("name=FileManagmentSystemContext")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppContext, Configuration>());
        }
        

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<ChangedPasswords> ChangedPasswords { get; set; }
    }

}