using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace FileManagment.App.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<FileManagment.App.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FileManagment.App.AppContext context)
        {
        }
    }
}
