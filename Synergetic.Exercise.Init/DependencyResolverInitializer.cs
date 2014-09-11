using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Synergetic.Exercise.Init.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Synergetic.Exercise.Init
{
    public static class DependencyResolverInitializer
    {
        public static void Initialize(Assembly webProjectAssembly)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(webProjectAssembly);
            builder.RegisterModule(new EntityFrameworkModule());
            builder.RegisterModule(new ServiceModule());

            builder.RegisterModule(
                new AutoMapperModule
                {
                    AssembliesWithMappings =
                        new List<Assembly>
                                {
                                    webProjectAssembly
                                }
                });

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // AutoMapper initialization
            Mapper.Initialize(configuration =>
            {
                configuration.ConstructServicesUsing(type => DependencyResolver.Current.GetService(type));
                container.Resolve<IEnumerable<Profile>>().ToList().ForEach(configuration.AddProfile);
            });
        }
    }
}
