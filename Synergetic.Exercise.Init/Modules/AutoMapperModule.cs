using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Synergetic.Exercise.Init.Modules
{
    public class AutoMapperModule : Autofac.Module
    {
        private IList<Assembly> _assembliesWithMappings;

        public IList<Assembly> AssembliesWithMappings
        {
            private get
            {
                return _assembliesWithMappings ?? (_assembliesWithMappings = new List<Assembly>());
            }

            set
            {
                _assembliesWithMappings = value;
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            foreach (var assemblyContainingMappings in AssembliesWithMappings)
            {
                builder.RegisterAssemblyTypes(assemblyContainingMappings)
                       .AsClosedTypesOf(typeof(ITypeConverter<,>))
                       .AsSelf();

                builder.RegisterAssemblyTypes(assemblyContainingMappings)
                       .AsClosedTypesOf(typeof(ValueResolver<,>))
                       .AsSelf();

                builder.RegisterAssemblyTypes(assemblyContainingMappings)
                       .AsClosedTypesOf(typeof(IMappingAction<,>))
                       .AsSelf();

                builder.RegisterAssemblyTypes(assemblyContainingMappings).Where(
                    t => typeof(Profile).IsAssignableFrom(t))
                    .As<Profile>().SingleInstance();
            }
        }
    }
}
