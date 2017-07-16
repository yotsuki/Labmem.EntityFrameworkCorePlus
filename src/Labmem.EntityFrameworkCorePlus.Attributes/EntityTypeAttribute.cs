using System;
using System.Collections.Generic;
using System.Text;

namespace Labmem.EntityFrameworkCorePlus.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]

    public abstract class EntityTypeAttribute : Attribute
    {
        public virtual Type BindingInterface { get; }
    }
}
