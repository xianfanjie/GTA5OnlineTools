using GTA5OnlineTools.Utils;

using GTA5Shared.Helper;

using Downloader;

namespace GTA5OnlineTools.Windows;

/// <summary>
/// UpdateWindow.xaml 的交互逻辑
/// </summary>
public partial class UpdateWindow
{
    private DownloadService _downloader;

    public UpdateWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 更新窗口加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Window_Update_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {
            // 初始化下载库
            _downloader = new();

            // 删除未下载完的文件
            var tempPath = CoreUtil.GetHalfwayFilePath();
            if (File.Exists(tempPath))
                File.Delete(tempPath);

            // 防止未获取到更新信息情况
            if (CoreUtil.UpdateInfo == null)
            {
                Button_StartUpdate.IsEnabled = false;
                Button_CancelUpdate.IsEnabled = false; 
                return;
            }

            // 如果需要更新，则播放提示音
            if (CoreUtil.ServerVersion > CoreUtil.ClientVersion)
                AudioHelper.SP_GTA5Email.Play();

            // 显示最新的更新日期和时间
            TextBlock_LatestUpdateInfo.Text = $"{CoreUtil.UpdateInfo.Latest.Date}\n{CoreUtil.UpdateInfo.Latest.Change}";
            // 加载更新日志
            foreach (var item in CoreUtil.UpdateInfo.Download)
            {
                ListBox_DownloadAddress.Items.Add(item.Name);
            }
            // 选中第一项
            if (ListBox_DownloadAddress.Items.Count > 0)
                ListBox_DownloadAddress.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            NotifierHelper.ShowException(ex);
        }
    }

    /// <summary>
    /// 更新窗口关闭事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void Window_Update_Closing(object sender, CancelEventArgs e)
    {
        await _downloader.Clear();
        _downloader.Dispose();
    }

    /// <summary>
    /// 超链接请求导航事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        ProcessHelper.OpenLink(e.Uri.OriginalString);
        e.Handled = true;
    }

    //////////////////////////////////////////////////////////

    /// <summary>
    /// 开始更新按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_StartUpdate_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        var index = ListBox_DownloadAddress.SelectedIndex;
        if (index == -1)
            return;

        Button_StartUpdate.IsEnabled = false;
        Button_CancelUpdate.IsEnabled = true;

        TextBlock_DonloadInfo.Text = "下载开始";
        TextBlock_Percentage.Text = "0KB / 0MB";

        CoreUtil.UpdateAddress = CoreUtil.UpdateInfo.Download[index].Url;

        // 获取未下载完临时文件路径
        var tempPath = CoreUtil.GetHalfwayFilePath(); ;

        _downloader.DownloadStarted += Downloader_DownloadStarted;
        _downloader.DownloadProgressChanged += DownloadProgressChanged;
        _downloader.DownloadFileCompleted += DownloadFileCompleted;

        _downloader.DownloadFileTaskAsync(CoreUtil.UpdateAddress, tempPath);
    }

    /// <summary>
    /// 取消更新按钮点击事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void Button_CancelUpdate_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        _downloader.CancelAsync();
        await _downloader.Clear();

        Button_StartUpdate.IsEnabled = true;
        Button_CancelUpdate.IsEnabled = false;

        ResetState("下载取消");
    }

    //////////////////////////////////////////////////////////

    private void ResetState(string reson)
    {
        ProgressBar_Update.Minimum = 0;
        ProgressBar_Update.Maximum = 1024;
        ProgressBar_Update.Value = 0;

        TaskbarItemInfo.ProgressValue = 0;

        TextBlock_DonloadInfo.Text = reson;
        TextBlock_Percentage.Text = "0KB / 0MB";
    }

    /// <summary>
    /// 下载开始事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="NotImplementedException"></exception>
    private void Downloader_DownloadStarted(object sender, DownloadStartedEventArgs e)
    {
        this.Dispatcher.Invoke(() =>
        {
            TextBlock_DonloadInfo.Text = $"下载开始 文件大小 {GetFileForamtSize(e.TotalBytesToReceive)}";

            ProgressBar_Update.Minimum = 0;
            ProgressBar_Update.Maximum = e.TotalBytesToReceive;
        });
    }

    /// <summary>
    /// 下载进度变更事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        this.Dispatcher.Invoke(() =>
        {
            TextBlock_Percentage.Text = $"{GetFileForamtSize(e.ReceivedBytesSize)} / {GetFileForamtSize(e.TotalBytesToReceive)}";

            ProgressBar_Update.Value = e.ReceivedBytesSize;
            TaskbarItemInfo.ProgressValue = ProgressBar_Update.Value / ProgressBar_Update.Maximum;
        });
    }

    /// <summary>
    /// 下载文件完成事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
        this.Dispatcher.Invoke(async () =>
        {
            if (e.Error != null)
            {
                ResetState($"下载失败 {e.Error.Message}");
                return;
            }

            try
            {
                AudioHelper.SP_DownloadOK.Play();

                // 下载临时文件完整路径
                var oldPath = CoreUtil.GetHalfwayFilePath();
                // 下载完成后文件真正路径
                var newPath = CoreUtil.GetFullFilePath();

                // 下载完成后新文件重命名
                FileUtil.FileReName(oldPath, newPath);

                await Task.Delay(100);

                // 下载完成后旧文件重命名
                var oldFileName = $"[旧版本小助手请手动删除] {Guid.NewGuid()}.exe";
                // 旧版本小助手重命名
                FileUtil.FileReName(FileUtil.File_MainApp, FileUtil.GetCurrFullPath(oldFileName));

                TextBlock_DonloadInfo.Text = "更新下载完成，程序将在3秒内重新启动";

                App.AppMainMutex.Dispose();
                await Task.Delay(1000);
                ProcessHelper.OpenProcess(newPath);
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                NotifierHelper.ShowException(ex);
            }
        });
    }

    //////////////////////////////////////////////////////////

    /// <summary>
    /// 文件大小转换
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    private string GetFileForamtSize(long size)
    {
        var kb = size / 1024.0f;

        if (kb > 1024.0f)
            return $"{kb / 1024.0f:0.00}MB";
        else
            return $"{kb:0.00}KB";
    }
}
