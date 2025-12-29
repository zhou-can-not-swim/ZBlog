using System.Configuration;
using System.Data;
using System.Windows;

namespace Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SQLiteDatabaseHelper DatabaseHelper { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 初始化数据库帮助类
            DatabaseHelper = new SQLiteDatabaseHelper();

            // 可选：添加一些测试数据
            // DatabaseHelper.AddUrls(new Urls { Name = "测试", Url = "https://example.com" });
        }
    }

}
