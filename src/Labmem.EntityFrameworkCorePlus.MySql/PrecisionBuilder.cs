using Labmem.EntityFrameworkCorePlus.Attributes;
using Labmem.EntityFrameworkCorePlus.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Labmem.EntityFrameworkCorePlus.MySql
{
    public class PrecisionBuilder : IPrecision
    {
        public PropertyBuilder Build(PropertyBuilder builder, PropertyAttribute attr) => Build(builder, (PrecisionAttribute)attr);
        public PropertyBuilder Build(PropertyBuilder builder, PrecisionAttribute attr)
        {
            if (attr == null) {
                return builder;
            }
            if (builder.Metadata.ClrType != typeof(decimal) && builder.Metadata.ClrType != typeof(decimal?)) {
                return builder;
            }
            builder.Metadata.MySql().ColumnType = $"decimal({attr.Precision}, {attr.Scale})";
            return builder;
        }
    }
}
