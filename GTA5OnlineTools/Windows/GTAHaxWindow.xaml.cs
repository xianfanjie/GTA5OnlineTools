using GTA5.Utils;
using GTA5Core.RAGE.Stats;
using GTA5Shared.Helper;

namespace GTA5OnlineTools.Windows;

/// <summary>
/// GTAHaxWindow.xaml 的交互逻辑
/// </summary>
public partial class GTAHaxWindow
{
    public GTAHaxWindow()
    {
        InitializeComponent();
    }

    private void Window_GTAHax_Loaded(object sender, RoutedEventArgs e)
    {
        TextBox_PreviewGTAHax.Text = "INT32\n";

        // STAT列表
        foreach (var item in StatData.StatClasses)
        {
            ListBox_GTAHaxClass.Items.Add(item.Name);
        }
        ListBox_GTAHaxClass.SelectedIndex = 0;
    }

    private void Window_GTAHax_Closing(object sender, CancelEventArgs e)
    {

    }

    private void TextBox_AppendText_MP(string str, string value)
    {
        TextBox_PreviewGTAHax.AppendText($"$MPx{str}\n");
        TextBox_PreviewGTAHax.AppendText($"{value}\n");
    }

    private void TextBox_AppendText_NoMP(string str, string value)
    {
        TextBox_PreviewGTAHax.AppendText($"${str}\n");
        TextBox_PreviewGTAHax.AppendText($"{value}\n");
    }

    private void ListBox_GTAHaxClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var statClassName = ListBox_GTAHaxClass.SelectedItem.ToString();
        int index = StatData.StatClasses.FindIndex(t => t.Name == statClassName);
        if (index != -1)
        {
            TextBox_PreviewGTAHax.Clear();
            TextBox_PreviewGTAHax.AppendText("INT32\n");

            for (int i = 0; i < StatData.StatClasses[index].StatInfos.Count; i++)
            {
                var hash = StatData.StatClasses[index].StatInfos[i].Hash;
                var value = StatData.StatClasses[index].StatInfos[i].Value;

                if (hash.IndexOf("_") == 0)
                {
                    TextBox_AppendText_MP(hash, value.ToString());
                }
                else
                {
                    TextBox_AppendText_NoMP(hash, value.ToString());
                }
            }
        }
    }

    private void Button_ImportGTAHax_Click(object sender, RoutedEventArgs e)
    {
        var stat = TextBox_PreviewGTAHax.Text;
        if (string.IsNullOrWhiteSpace(stat))
        {
            NotifierHelper.Show(NotifierType.Warning, "stat代码不能为空，操作取消");
            return;
        }

        GTAHaxUtil.ImportGTAHax(TextBox_PreviewGTAHax.Text);
    }
}
