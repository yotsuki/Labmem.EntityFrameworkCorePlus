using Labmem.EntityFrameworkCorePlus.Attributes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Labmem.EntityFrameworkCorePlus.MySql
{
    public class PrimaryKeyBuilder : IPrimaryKey
    {
        public EntityTypeBuilder Build(EntityTypeBuilder builder, EntityTypeAttribute attr)
        {
            var attrPk = attr as PrimaryKeyAttribute;
            builder.HasKey(attrPk.PrimaryKeys);
            return builder;
        }
    }
}
