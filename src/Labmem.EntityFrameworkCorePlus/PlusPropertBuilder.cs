using Labmem.EntityFrameworkCorePlus.Attributes;
using Labmem.EntityFrameworkCorePlus.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Labmem.EntityFrameworkCorePlus
{
    public class PlusPropertBuilder
    {
        public PropertyBuilder Builder { get; private set; }
        public IPlusDbContext Context { get; private set; }
        public PlusPropertBuilder(PropertyBuilder propertyBuilder,IPlusDbContext context)
        {
            Builder = propertyBuilder;
            Context = context;
        }

        public PropertyBuilder Build()
        {
            var serviceProvider = Context.GetPlusServiceProvider();
            foreach(var cad  in Builder.Metadata.PropertyInfo.CustomAttributes
                .Where(a => a.AttributeType.GetTypeInfo().IsSubclassOf(typeof(PropertyAttribute)))) {
                var attr = (PropertyAttribute)Activator.CreateInstance(cad.AttributeType, cad.ConstructorArguments.Select(ca => ca.Value));
                var service = serviceProvider.GetService(attr.BindingInterface) as IPlusPropertyBuilder;
                service.Build(Builder, attr);
            }
            return Builder;
        }
    }
}
