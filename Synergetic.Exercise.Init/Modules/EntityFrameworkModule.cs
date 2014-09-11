using Autofac;
using Synergetic.Exercise.Data;
using Synergetic.Exercise.Data.Implementations;
using Synergetic.Exercise.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synergetic.Exercise.Init.Modules
{
    public class EntityFrameworkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            builder.RegisterType<DatabaseContext>().As<DbContext>().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(Repository<>).Assembly)
                .Where(type => type.ImplementsInterface(typeof(IRepository<>))).AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>))
            .InstancePerLifetimeScope();
        }
    }
}
