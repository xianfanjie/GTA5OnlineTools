using GTA5Core.Feature;
using GTA5Core.RAGE.Stats;

namespace GTA5.Views;

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
        Online.LoadSession(11);
    }

    private void AppendTextBox(string str)
    {
        this.Dispatcher.Invoke(() =>
        {
            TextBox_Logger.AppendText($"[{DateTime.Now:T}] {str}\n");
            TextBox_Logger.ScrollToEnd();
        });
    }

    private void Button_ExecuteAutoScript_Click(object sender, RoutedEventArgs e)
    {
        var index = ListBox_STATList.SelectedIndex;
        if (index != -1)
        {
            AutoScript(ListBox_STATList.SelectedItem.ToString());
        }
    }

    private void AutoScript(string statClassName)
    {
        TextBox_Logger.Clear();

        Task.Run(async () =>
        {
            try
            {
                var index = StatData.StatClasses.FindIndex(t => t.Name == statClassName);
                if (index != -1)
                {
                    AppendTextBox($"正在执行 {StatData.StatClasses[index].Name} 脚本代码");

                    for (int i = 0; i < StatData.StatClasses[index].StatInfos.Count; i++)
                    {
                        AppendTextBox($"正在执行 第 {i + 1}/{StatData.StatClasses[index].StatInfos.Count} 条代码");

                        Hacks.STATS_WriteInt(StatData.StatClasses[index].StatInfos[i].Hash, StatData.StatClasses[index].StatInfos[i].Value);
                        await Task.Delay(500);
                    }

                    AppendTextBox($"{StatData.StatClasses[index].Name} 脚本代码执行完毕");
                }
            }
            catch (Exception ex)
            {
                AppendTextBox($"错误：{ex.Message}");
            }
        });
    }
}
