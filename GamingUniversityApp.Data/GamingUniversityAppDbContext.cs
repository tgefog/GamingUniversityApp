using GamingUniversityApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GamingUniversityApp.Data
{
	public class GamingUniversityAppDbContext : DbContext
	{
        public GamingUniversityAppDbContext()
        {
              
        }
        public GamingUniversityAppDbContext(DbContextOptions options)
            :base(options)
        {
            
        }
        public virtual DbSet<Course> Courses { get; set; } = null!;
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
