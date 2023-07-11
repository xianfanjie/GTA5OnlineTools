using GTA5OnlineTools.Data;
using GTA5OnlineTools.Utils;

using GTA5Shared.Helper;

using Downloader;

namespace GTA5OnlineTools.Windows;

/// <summary>
/// OnlineLuaWindow.xaml 的交互逻辑
/// </summary>
public partial class OnlineLuaWindow
{
    private DownloadService _downloader;

    private bool isUseKiddion = true;
    private string tempPath = string.Empty;

    private const string kiddion = "https://api.crazyzhang.cn/lua/Kiddion.json";
    private const string yimMenu = "https://api.crazyzhang.cn/lua/YimMenu.json";

    public ObservableCollection<LuaInfo> OnlineLuas { get; set; } = new();

    public OnlineLuaWindow()
    {
        InitializeComponent();
    }

    private void Window_OnlineLua_Loaded(object sender, RoutedEventArgs e)
    {
        // 初始化下载库
        _downloader = new();

        RadioButton_Kiddion.IsChecked = true;
    }

    private async void Window_OnlineLua_Closing(object sender, CancelEventArgs e)
    {
        await _downloader.Clear();
        _downloader.Dispose();
    }

    //////////////////////////////////////////////////////////

    private void ClearLogger()
    {
        this.Dispatcher.Invoke(() =>
        {
            TextBox_Logger.Clear();
        });
    }

    private void AppendLogger(string log)
    {
        this.Dispatcher.Invoke(() =>
        {
            TextBox_Logger.AppendText($"{log}\n");
            TextBox_Logger.ScrollToEnd();
        });
    }

    //////////////////////////////////////////////////////////

    private async void Button_RefushList_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        try
        {
            OnlineLuas.Clear();

            Button_StartDownload.IsEnabled = false;
            Button_CancelDownload.IsEnabled = false;

            string content;
            if (isUseKiddion)
                content = await HttpHelper.DownloadString(kiddion);
            else
                content = await HttpHelper.DownloadString(yimMenu);

            if (string.IsNullOrEmpty(content))
            {
                AppendLogger("无法获取服务器Lua列表，返回结果为空");
                NotifierHelper.Show(NotifierType.Warning, "无法获取服务器Lua列表，返回结果为空");
                return;
            }

            var result = JsonHelper.JsonDese<List<LuaInfo>>(content);
            if (result != null)
            {
                foreach (var item in result)
                {
                    OnlineLuas.Add(item);
                }
            }

            Button_StartDownload.IsEnabled = true;
            Button_CancelDownload.IsEnabled = false;
        }
        catch (Exception ex)
        {
            AppendLogger($"获取服务器Lua列表异常：{ex.Message}");
            NotifierHelper.Show(NotifierType.Error, $"获取服务器Lua列表异常\n{ex.Message}");
        }
    }

    private void Button_StartDownload_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        var index = ListBox_DownloadAddress.SelectedIndex;
        if (index == -1)
        {
            AppendLogger("请选择要下载的内容，操作取消");
            NotifierHelper.Show(NotifierType.Warning, "请选择要下载的内容，操作取消");
            return;
        }

        ClearLogger();

        StackPanel_ToggleOption.IsEnabled = false;
        Button_StartDownload.IsEnabled = false;
        Button_CancelDownload.IsEnabled = true;

        ResetState();

        var adddress = OnlineLuas[index].Download;

        _downloader.DownloadStarted += DownloadStarted;
        _downloader.DownloadProgressChanged += DownloadProgressChanged;
        _downloader.DownloadFileCompleted += DownloadFileCompleted;

        if (isUseKiddion)
            tempPath = Path.Combine(FileHelper.Dir_Kiddion_Scripts, "GTA5OnlineLua.zip");
        else
            tempPath = Path.Combine(FileHelper.Dir_AppData_YimMenu_Scripts, "GTA5OnlineLua.zip");

        _downloader.DownloadFileTaskAsync(adddress, tempPath);
    }

    private async void Button_CancelDownload_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        _downloader.CancelAsync();
        await _downloader.Clear();

        ResetState();
        AppendLogger("下载取消");

        StackPanel_ToggleOption.IsEnabled = true;
        Button_StartDownload.IsEnabled = true;
        Button_CancelDownload.IsEnabled = false;
    }

    //////////////////////////////////////////////////////////

    private void ResetState()
    {
        ProgressBar_Download.Minimum = 0;
        ProgressBar_Download.Maximum = 1024;
        ProgressBar_Download.Value = 0;

        TaskbarItemInfo.ProgressValue = 0;

        TextBlock_Percentage.Text = "0KB / 0MB";
    }

    private void DownloadStarted(object sender, DownloadStartedEventArgs e)
    {
        this.Dispatcher.Invoke(() =>
        {
            AppendLogger($"下载开始 文件大小 {CoreUtil.GetFileForamtSize(e.TotalBytesToReceive)}");

            ProgressBar_Download.Minimum = 0;
            ProgressBar_Download.Maximum = e.TotalBytesToReceive;
        });
    }

    private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        this.Dispatcher.Invoke(() =>
        {
            TextBlock_Percentage.Text = $"{CoreUtil.GetFileForamtSize(e.ReceivedBytesSize)} / {CoreUtil.GetFileForamtSize(e.TotalBytesToReceive)}";

            ProgressBar_Download.Value = e.ReceivedBytesSize;
            TaskbarItemInfo.ProgressValue = ProgressBar_Download.Value / ProgressBar_Download.Maximum;
        });
    }

    private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
        this.Dispatcher.Invoke(() =>
        {
            if (e.Error != null)
            {
                ResetState();
                StackPanel_ToggleOption.IsEnabled = true;
                Button_StartDownload.IsEnabled = true;
                Button_CancelDownload.IsEnabled = false;

                AppendLogger($"下载失败 {e.Error.Message}");
                return;
            }

            try
            {
                AppendLogger("下载成功，开始解压中...");

                using var archive = ZipFile.OpenRead(tempPath);

                if (isUseKiddion)
                    archive.ExtractToDirectory(FileHelper.Dir_Kiddion_Scripts);
                else
                    archive.ExtractToDirectory(FileHelper.Dir_AppData_YimMenu_Scripts);

                archive.Dispose();
                AppendLogger("解压成功，开始删除临时文件中...");
                File.Delete(tempPath);
                AppendLogger("删除临时文件成功，操作结束");
            }
            catch (Exception ex)
            {
                AppendLogger($"解压时发生异常：{ex.Message}");
            }
            finally
            {
                StackPanel_ToggleOption.IsEnabled = true;
                Button_StartDownload.IsEnabled = true;
                Button_CancelDownload.IsEnabled = false;
            }
        });
    }

    private void RadioButton_ScriptMode_Checked(object sender, RoutedEventArgs e)
    {
        OnlineLuas.Clear();

        isUseKiddion = RadioButton_Kiddion.IsChecked == true;
    }

    private void Button_ScriptDir_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (isUseKiddion)
            ProcessHelper.OpenDir(FileHelper.Dir_Kiddion_Scripts);
        else
            ProcessHelper.OpenDir(FileHelper.Dir_AppData_YimMenu_Scripts);
    }

    private void Button_ClearScriptDir_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (isUseKiddion)
        {
            ProcessHelper.CloseProcess("Kiddion");
            FileHelper.ClearDirectory(FileHelper.Dir_Kiddion_Scripts);

            FileHelper.ExtractResFile(FileHelper.Res_Kiddion_Scripts_Readme, FileHelper.File_Kiddion_Scripts_Readme);
            NotifierHelper.Show(NotifierType.Success, "清空Kiddion Lua脚本文件夹成功");
        }
        else
        {
            FileHelper.ClearDirectory(FileHelper.Dir_AppData_YimMenu_Scripts);
            NotifierHelper.Show(NotifierType.Success, "清空YimMenu Lua脚本文件夹成功");
        }
    }
}
