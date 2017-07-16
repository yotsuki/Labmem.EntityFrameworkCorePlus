using Labmem.EntityFrameworkCorePlus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Labmem.EntityFrameworkCorePlus.SqlServer
{
    public class SqlServerServiceCollectionLoader : ILabmemServiceCollectionLoader
    {
        public string SupportDatabase { get; set; } = "SqlServer";
        

        public IServiceCollection GetServiceCollection()
        {
            return new ServiceCollection().AddSingleton<IPrecision, PrecisionBuilder>();
        }
    }
}
