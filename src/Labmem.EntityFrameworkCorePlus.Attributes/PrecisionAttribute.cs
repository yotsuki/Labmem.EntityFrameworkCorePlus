using Labmem.EntityFrameworkCorePlus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labmem.EntityFrameworkCorePlus.Attributes
{
    public class PrecisionAttribute: PropertyAttribute
    {
        public override Type BindingInterface { get; } = typeof(IPrecision);
        
        public byte Precision { get; set; }
        public byte Scale { get; set; }
        public PrecisionAttribute(byte precision, byte scale)
        {
            Precision = precision;
            Scale = scale;
        }
    }
}
