using Service;
using WebService.Impl;

namespace WebService.Extentions
{
    public static class ServiceExtention
    {
        public static void ConfigureServiceScope(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBlogService, BlogService>();
            //services.AddScoped<ITagService, TagService>();
        }
    }
}
