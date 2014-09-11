using Synergetic.Exercise.Common;
using Synergetic.Exercise.Data.Maps;
using Synergetic.Exercise.Model.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synergetic.Exercise.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            ConfigureModel(modelBuilder);
            Database.SetInitializer<DatabaseContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigureModel(DbModelBuilder modelBuilder)
        {
            AddEntityMapsTo(modelBuilder);

            RegisterAllEntitiesTo(modelBuilder);
        }

        private static void AddEntityMapsTo(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(CompanyMap).Assembly);
        }

        private static void RegisterAllEntitiesTo(DbModelBuilder modelBuilder)
        {
            var entities = FindEntities();
            modelBuilder.RegisterAllEntities(entities);
        }

        private static IEnumerable<Type> FindEntities()
        {
            return ContextRegistrationHelper.FindSubclassesOf(typeof(Entity));
        }
    }
}
