using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GamingUniversityApp.Data
{
    public class GamingUniversityAppDbContextFactory : IDesignTimeDbContextFactory<GamingUniversityAppDbContext>
    {
        public GamingUniversityAppDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<GamingUniversityAppDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new GamingUniversityAppDbContext(optionsBuilder.Options);
        }
    }
}
