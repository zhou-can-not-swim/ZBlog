using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EF
{
    //这个类是必须要的，在数据迁移的时候最先使用工厂类
    public class BlogDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
    {

        public BlogDbContext CreateDbContext(string[] args)
        {
            // 直接在工厂中配置连接字符串
            var connectionString = "Server=localhost;Port=3306;Database=zblog;User=root;Password=123456;";

            var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>();
            optionsBuilder.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(8, 0, 44)));

            return new BlogDbContext(optionsBuilder.Options);//最终目的创建BlogContext的实例化，开始调用BlogDBContext,Programe.cs文件不被调用
        }
    }
    
}
