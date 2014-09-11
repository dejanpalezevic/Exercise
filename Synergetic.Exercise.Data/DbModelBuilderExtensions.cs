using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Synergetic.Exercise.Data
{
    public static class DbModelBuilderExtensions
    {
        public static void RegisterAllEntities(this DbModelBuilder modelBuilder, IEnumerable<Type> entityTypes)
        {
            var entityMethod = GetEntityMethodInDbModelBuilder();
            foreach (var entityType in entityTypes)
            {
                InvokeEntityMethodOnModelBuilderForEntity(modelBuilder, entityMethod, entityType);
            }
        }

        private static void InvokeEntityMethodOnModelBuilderForEntity(DbModelBuilder modelBuilder, MethodInfo entityMethod, Type type)
        {
            entityMethod.MakeGenericMethod(type).Invoke(modelBuilder, new object[] { });
        }

        private static MethodInfo GetEntityMethodInDbModelBuilder()
        {
            var entityMethod = typeof(DbModelBuilder).GetMethod("Entity");
            return entityMethod;
        }
    }
}
