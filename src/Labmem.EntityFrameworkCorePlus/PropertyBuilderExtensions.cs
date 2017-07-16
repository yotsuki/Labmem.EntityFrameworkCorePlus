using Labmem.EntityFrameworkCorePlus.Attributes;
using Labmem.EntityFrameworkCorePlus.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Labmem.EntityFrameworkCorePlus
{
    public static class PropertyBuilderExtensions
    {
        public static ModelBuilder PlusBuild<T>(this ModelBuilder modelBuilder) where T : ILabmemServiceCollectionLoader
            => PlusBuild(modelBuilder, typeof(T));

        public static ModelBuilder PlusBuild(this ModelBuilder modelBuilder, Type loaderType)
        {
            return PlusBuild(modelBuilder, ((ILabmemServiceCollectionLoader)Activator.CreateInstance(loaderType)).GetServiceCollection().BuildServiceProvider());
        }
        public static ModelBuilder PlusBuild(this ModelBuilder modelBuilder, IServiceProvider serviceProvider)
        {
            var entitytypes = modelBuilder.Model.GetEntityTypes();
            foreach(var type in entitytypes) {
                var typebuilder = modelBuilder.Entity(type.Name);
                typebuilder.PlusBuild(serviceProvider);
            }
            return modelBuilder;
        }
        public static EntityTypeBuilder PlusBuild(this EntityTypeBuilder entityTypeBuilder, IServiceProvider serviceProvider)
        {
            var entitytype = entityTypeBuilder.Metadata.ClrType;
            List<Property> keys = new List<Property>();

            foreach(var property in entitytype.GetTypeInfo().GetProperties()) {
                var attrs = property.GetCustomAttributes(true);
                if(attrs.Any(a=>a is KeyAttribute)) {
                    keys.Add((Property)entityTypeBuilder.Metadata.FindProperty(property));
                }
                if (entityTypeBuilder.Metadata.FindNavigation(property) == null) {
                    entityTypeBuilder.Property(property.Name).PlusBuild(serviceProvider);
                }
            }
            if(keys.Count > 1) {
                foreach(var property in keys) {
                    var key = entityTypeBuilder.Metadata.FindKey(property);
                    if(key != null) {
                        entityTypeBuilder.Metadata.RemoveKey(new Property[] { property });
                    }
                }
                var builder = entityTypeBuilder.GetType().GetTypeInfo().GetProperty("Builder", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(entityTypeBuilder) as InternalEntityTypeBuilder;
                var method = builder.GetType().GetTypeInfo().GetMethod("PrimaryKey", BindingFlags.NonPublic | BindingFlags.Instance);
                method.Invoke(builder,new object[] { keys.AsReadOnly(), ConfigurationSource.Explicit });
            }

            return entityTypeBuilder;
        }
        public static PropertyBuilder PlusBuild(this PropertyBuilder propertyBuilder, IServiceProvider serviceProvider)
        {
            foreach (var cad in propertyBuilder.Metadata.PropertyInfo.CustomAttributes
                .Where(a => a.AttributeType.GetTypeInfo().IsSubclassOf(typeof(PropertyAttribute)))) {
                
                var attr = (PropertyAttribute)Activator.CreateInstance(cad.AttributeType, cad.ConstructorArguments.Select(ca => ca.Value).ToArray());
                var service = serviceProvider.GetService(attr.BindingInterface) as IPlusPropertyBuilder;
                if (service != null) {
                    service.Build(propertyBuilder, attr);
                }
            }
            return propertyBuilder;
        }
    }
}
