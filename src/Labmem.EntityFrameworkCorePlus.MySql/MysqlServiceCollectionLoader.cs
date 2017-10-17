using Labmem.EntityFrameworkCorePlus.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Labmem.EntityFrameworkCorePlus.MySql
{
    public class MysqlServiceCollectionLoader : ILabmemServiceCollectionLoader
    {
        public string SupportDatabase { get; set; } = "MySql";

        public IServiceCollection GetServiceCollection()
        {
            return new ServiceCollection()
                .AddSingleton<ILabmemServiceCollectionLoader, MysqlServiceCollectionLoader>()
                .AddSingleton<IPrecision, PrecisionBuilder>();
        }

        public DbContextOptionsBuilder UseConnectionString(DbContextOptionsBuilder builder, string connstr)
        {
            return builder.UseMySql(connstr);
        }
    }
}
