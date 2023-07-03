using GTA5Core.GTA.Enum;
using GTA5Core.GTA.Stats;
using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5MenuExtra;

/// <summary>
/// StatScriptsWindow.xaml 的交互逻辑
/// </summary>
public partial class StatScriptsWindow
{
    public StatScriptsWindow()
    {
        InitializeComponent();
    }

    private void Window_StatScripts_Loaded(object sender, RoutedEventArgs e)
    {
        // STAT列表
        foreach (var item in StatData.StatClasses)
        {
            ListBox_STATList.Items.Add(item.Name);
        }
        ListBox_STATList.SelectedIndex = 0;
    }

    private void Window_StatScripts_Closing(object sender, CancelEventArgs e)
    {

    }

    private void Button_LoadSession_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        Online.LoadSession((int)SessionType.Invite_Only);
    }

    private void AppendTextBox(string log)
    {
        this.Dispatcher.Invoke(() =>
        {
            TextBox_Logger.AppendText($"[{DateTime.Now:T}] {log}\n");
            TextBox_Logger.ScrollToEnd();
        });
    }

    private void Button_ExecuteAutoScript_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        var item = ListBox_STATList.SelectedItem;
        if (item != null)
            AutoScript(item.ToString());
    }

    private void AutoScript(string statClassName)
    {
        TextBox_Logger.Clear();

        Task.Run(async () =>
        {
            try
            {
                var result = StatData.StatClasses.Find(t => t.Name == statClassName);
                if (result != null)
                {
                    AppendTextBox($"正在执行 {result.Name} 脚本代码");

                    var count = result.StatInfos.Count;
                    for (int i = 0; i < count; i++)
                    {
                        AppendTextBox($"正在执行 第 {i + 1}/{count} 条代码");

                        await STATS.STAT_SET_INT(result.StatInfos[i].Hash, result.StatInfos[i].Value);
                    }

                    AppendTextBox($"{result.Name} 脚本代码执行完毕");
                }
            }
            catch (Exception ex)
            {
                AppendTextBox($"错误：{ex.Message}");
            }
        });
    }
}
