using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Client.Pages
{
    /// <summary>
    /// Page2.xaml 的交互逻辑
    /// </summary>
    public partial class Page2 : Page
    {
        SQLiteDatabaseHelper udbHelper = new SQLiteDatabaseHelper();

        public Page2()
        {
            InitializeComponent();
            Loaded += Page2_Loaded;
        }

        private void Page2_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUrls();
        }

        private void LoadUrls()
        {
            var urls = udbHelper.GetAllUrls();
            UrlsItemsControl.ItemsSource = urls;
        }

        //private void UrlText_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    if (sender is TextBlock textBlock && textBlock.DataContext is Urls urlItem)
        //    {
        //        OpenUrl(urlItem.Url);
        //    }
        //}

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string url)
            {
                OpenUrl(url);
            }
        }

        //private void DeleteButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (sender is Button button && button.Tag is int id)
        //    {
        //        var result = MessageBox.Show("确定要删除这个链接吗？", "确认删除", MessageBoxButton.YesNo, MessageBoxImage.Question);

        //        if (result == MessageBoxResult.Yes)
        //        {
        //            udbHelper.(id);
        //            LoadUrls(); // 重新加载
        //            MessageBox.Show("删除成功！");
        //        }
        //    }
        //}

        private void OpenUrl(string url)
        {
            try
            {
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "https://" + url;
                }
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法打开链接: {ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
