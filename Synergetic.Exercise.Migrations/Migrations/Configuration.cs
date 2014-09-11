namespace Synergetic.Exercise.Data.Migrations
{
    using Synergetic.Exercise.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DatabaseContext context)
        {
            var company1 = new Company{
                Name = "Compaq",
                Description = "Description for Compaq"
            };
            var company2 = new Company {
                Name = "Dell",
                Description = "Description for Dell"
            };
            context.Set<Company>().AddOrUpdate(p => p.Name, company1);
            context.Set<Company>().AddOrUpdate(p => p.Name, company2);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
