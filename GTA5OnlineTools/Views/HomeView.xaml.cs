using GTA5Shared.Helper;

namespace GTA5OnlineTools.Views;

/// <summary>
/// HomeView.xaml 的交互逻辑
/// </summary>
public partial class HomeView : UserControl
{
    string content = "网络异常，获取最新公告内容失败！这并不影响小助手程序使用\n\n" +
        "建议你定期去小助手网址查看是否有最新版本：https://crazyzhang.cn/\n\n" +
        "强烈建议大家使用最新版本以获取bug修复和安全性更新";

    public HomeView()
    {
        InitializeComponent();
        this.DataContext = this;
        MainWindow.WindowClosingEvent += MainWindow_WindowClosingEvent;

        GetNoticeInfo();
        GetChangeInfo();
    }

    private void MainWindow_WindowClosingEvent()
    {

    }

    private async void GetNoticeInfo()
    {
        try
        {
            var notice = await HttpHelper.DownloadString("https://api.crazyzhang.cn/update/server/notice.txt");

            if (string.IsNullOrEmpty(notice))
                TextBox_Notice.Text = content;
            else
                TextBox_Notice.Text = notice;
        }
        catch (Exception ex)
        {
            TextBox_Notice.Text = ex.Message;
        }
    }

    private async void GetChangeInfo()
    {
        try
        {
            var change = await HttpHelper.DownloadString("https://api.crazyzhang.cn/update/server/change.txt");

            if (string.IsNullOrEmpty(change))
                TextBox_Change.Text = content;
            else
                TextBox_Change.Text = change;
        }
        catch (Exception ex)
        {
            TextBox_Change.Text = ex.Message;
        }
    }
}
