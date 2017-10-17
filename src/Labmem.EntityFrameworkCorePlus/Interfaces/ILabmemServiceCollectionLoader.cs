using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmem.EntityFrameworkCorePlus.Interfaces
{
    public interface ILabmemServiceCollectionLoader
    {
        string SupportDatabase { get; set; }
        IServiceCollection GetServiceCollection();
        DbContextOptionsBuilder UseConnectionString(DbContextOptionsBuilder builder, string connstr);
    }
}
