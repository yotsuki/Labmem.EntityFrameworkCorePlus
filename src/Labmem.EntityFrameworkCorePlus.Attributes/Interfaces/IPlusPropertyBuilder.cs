using Labmem.EntityFrameworkCorePlus.Attributes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmem.EntityFrameworkCorePlus.Interfaces
{
    public interface IPlusPropertyBuilder
    {
        PropertyBuilder Build(PropertyBuilder builder, PropertyAttribute attr);
    }
}
