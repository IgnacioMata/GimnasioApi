using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GimnasioApi.Data
{
    public class GimnasioContextFactory : IDesignTimeDbContextFactory<GimnasioContext>
    {
        public GimnasioContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<GimnasioContext>();
            var connectionString = configuration.GetConnectionString("GimnasioConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new GimnasioContext(optionsBuilder.Options);
        }
    }
}
