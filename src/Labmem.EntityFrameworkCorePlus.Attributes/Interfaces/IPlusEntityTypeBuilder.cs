using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Labmem.EntityFrameworkCorePlus.Attributes
{
    public interface IPlusEntityTypeBuilder
    {
        EntityTypeBuilder Build(EntityTypeBuilder builder, EntityTypeAttribute attr);
    }
}
