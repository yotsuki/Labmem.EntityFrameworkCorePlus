using Labmem.EntityFrameworkCorePlus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmem.EntityFrameworkCorePlus.Attributes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Labmem.EntityFrameworkCorePlus.SqlServer
{
    public class PrecisionBuilder : IPrecision
    {
        public PropertyBuilder Build(PropertyBuilder builder, PropertyAttribute attr) => Build(builder, (PrecisionAttribute)attr);
        public PropertyBuilder Build(PropertyBuilder builder, PrecisionAttribute attr)
        {
            if(attr == null) {
                return builder;
            }
            if(builder.Metadata.ClrType != typeof(decimal) && builder.Metadata.ClrType != typeof(decimal?)) {
                return builder;
            }
            builder.ForSqlServerHasColumnType($"decimal({attr.Precision},{attr.Scale})");
            return builder;
        }
    }
}
