using GTA5Core.Features;
using GTA5Core.GTA.Stats;

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
        Online.LoadSession(11);
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

                        await Globals.WriteIntStat(StatData.StatClasses[index].StatInfos[i].Hash, StatData.StatClasses[index].StatInfos[i].Value);
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
