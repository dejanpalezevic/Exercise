using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Synergetic.Exercise.Common
{
    public static class ContextRegistrationHelper
    {
        public static IEnumerable<Type> FindSubclassesOf(Type entityType)
        {
            var entityTypes = Assembly.GetAssembly(entityType).GetTypes()
                                      .Where(x => x.IsSubclassOf(entityType) && !x.IsAbstract);
            return entityTypes;
        }
    }
}
