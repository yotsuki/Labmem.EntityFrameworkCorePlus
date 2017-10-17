using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmem.EntityFrameworkCorePlus.Interfaces
{
    public interface IPlusDbContext
    {
        ILabmemServiceCollectionLoader Loader { get; set; }
        IServiceProvider GetPlusServiceProvider();
    }
}
