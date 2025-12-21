using EF;
using Microsoft.EntityFrameworkCore;

namespace WebService.Extentions
{
    public static class DbContextExtention
    {

        public static void ConfigureMySqlConetxt(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BlogDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("BlogDbContext");
                options.UseMySql(connectionString,
                    new MySqlServerVersion(new Version(8, 0, 44)));

            });
        }
    }
}
