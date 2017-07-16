using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labmem.EntityFrameworkCorePlus.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class PropertyAttribute: Attribute
    {
        public virtual Type BindingInterface { get; }
    }
}
