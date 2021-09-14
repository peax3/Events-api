using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace Main.Extensions
{
	public static class ServicesExtensions
	{
		public static void ConfigureDbConnection(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
			});
		}
	}
}