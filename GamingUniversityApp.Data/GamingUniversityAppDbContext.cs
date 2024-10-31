﻿namespace GamingUniversityApp.Data
{
	using Microsoft.EntityFrameworkCore;
	using Models;
	using System.Reflection;
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
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Submission> Submissions { get; set; } = null!;
        public virtual DbSet<Assignment> Assignments { get; set; } = null!;
		public virtual DbSet<StudentCourse> StudentCourses { get; set; } = null!;
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}