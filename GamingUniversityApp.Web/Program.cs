namespace GamingUniversityApp.Web
{
    using Data;
    using Data.Models;
    using GamingUniversityApp.Services.Data;
    using GamingUniversityApp.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Services.Mapping;
    using Web.Infrastructure.Extensions;
    using Web.Models;

    public class Program
	{
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
				?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

			// Configure DbContext with SQL Server
			builder.Services.AddDbContext<GamingUniversityAppDbContext>(options =>
				options.UseSqlServer(connectionString));

			// Add Identity services with ApplicationUser and IdentityRole<Guid>
			builder.Services
				.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
				{
					ConfigureIdentity(builder, options);
				})
				.AddEntityFrameworkStores<GamingUniversityAppDbContext>()
				.AddDefaultTokenProviders();

			builder.Services.AddDatabaseDeveloperPageExceptionFilter();
			builder.Services.ConfigureApplicationCookie(cfg =>
			{
				cfg.LoginPath = "/Identity/Account/Login";
			});

			builder.Services.RegisterRepositories(typeof(ApplicationUser).Assembly);
			builder.Services.RegisterUserDefinedServices(typeof(ICourseService).Assembly);

			builder.Services.AddScoped<IAssignmentService, AssignmentService>();

			// Add MVC services for controllers and views
			builder.Services.AddControllersWithViews();
			builder.Services.AddRazorPages();
			WebApplication app = builder.Build();

			AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).Assembly);

			// Configure the HTTP request pipeline
			if (app.Environment.IsDevelopment())
			{
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			// Authentication and Authorization middleware
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.MapRazorPages();
			app.ApplyMigrations();
			app.Run();
		}
		private static void ConfigureIdentity(WebApplicationBuilder builder, IdentityOptions options)
		{
			options.Password.RequireDigit = builder.Configuration.GetValue<bool>("Identity:Password:RequireDigits");
			options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
			options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
			options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
			options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
			options.Password.RequiredUniqueChars = builder.Configuration.GetValue<int>("Identity:Password:RequiredUniqueChars");

			options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:Password:RequireConfirmedAccount");
			options.SignIn.RequireConfirmedEmail = builder.Configuration.GetValue<bool>("Identity:Password:RequireConfirmedEmail");
			options.SignIn.RequireConfirmedPhoneNumber = builder.Configuration.GetValue<bool>("Identity:Password:RequireConfirmedPhoneNumber");

			options.User.RequireUniqueEmail = builder.Configuration.GetValue<bool>("Identity:Password:RequireUniqueEmail");
		}
	}
}
