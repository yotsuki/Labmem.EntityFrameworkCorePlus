using System;
using System.Collections.Generic;
using System.Text;

namespace Labmem.EntityFrameworkCorePlus.Attributes
{
    public class PrimaryKeyAttribute: EntityTypeAttribute
    {
        public override Type BindingInterface { get; } = typeof(IPrimaryKey);
        public string[] PrimaryKeys { get; set; }
        public PrimaryKeyAttribute(params string[] keys)
        {
            PrimaryKeys = keys;
        }
    }
}
