using Auxilium.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Auxilium
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AuxContext>
    {
        public AuxContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .Build();
            var builder = new DbContextOptionsBuilder<AuxContext>();
            var connectionString = configuration.GetConnectionString("AuxiliumConnectionString");
            builder.UseSqlServer(connectionString);
            return new AuxContext(builder.Options);
        }
    }
}
