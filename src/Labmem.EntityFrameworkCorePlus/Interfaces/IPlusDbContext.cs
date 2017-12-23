using Microsoft.Extensions.DependencyInjection;
using System;

namespace Labmem.EntityFrameworkCorePlus.Interfaces
{
    public interface IPlusDbContext
    {
        ILabmemServiceCollectionLoader Loader { get; set; }
        IServiceProvider GetPlusServiceProvider();
    }
}
