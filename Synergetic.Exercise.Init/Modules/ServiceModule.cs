using Autofac;
using Synergetic.Exercise.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Synergetic.Exercise.Init.Modules
{
    public class ServiceModule : Autofac.Module
    {
        public Assembly ProjectAssembly { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException("builder");

            builder.RegisterAssemblyTypes(typeof(CompanyService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
