using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EF
{

    public class BlogDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
    {
        public BlogDbContext CreateDbContext(string[] args)
        {
            // 直接在工厂中配置连接字符串
            var connectionString = "Server=localhost;Port=3306;Database=ZBlogDb;User=root;Password=123456;";

            var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>();
            optionsBuilder.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(8, 0, 44)));

            return new BlogDbContext(optionsBuilder.Options);
        }
    }
    
}
