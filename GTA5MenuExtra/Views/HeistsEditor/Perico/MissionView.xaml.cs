using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5MenuExtra.Views.HeistsEditor.Perico;

/// <summary>
/// MissionView.xaml 的交互逻辑
/// </summary>
public partial class MissionView : UserControl
{
    private readonly Dictionary<string, int> STAT_DIC = new();

    public MissionView()
    {
        InitializeComponent();

        TextBox_Logger.AppendText("INT32\n");
    }

    private string GetListBoxSelectedItemContent(ListBox ListBox)
    {
        if (ListBox.SelectedItem is ListBoxItem item)
            return item.Content.ToString();

        return string.Empty;
    }

    private void ClearLogger()
    {
        TextBox_Logger.Clear();
    }

    private void AppendLogger(string hash, int value)
    {
        TextBox_Logger.AppendText($"${hash}\n");
        TextBox_Logger.AppendText($"{value}\n");

        STAT_DIC.Add(hash, value);
    }

    private void AppendLogger(string log)
    {
        TextBox_Logger.AppendText($"[{DateTime.Now:T}] {log}\n");
        TextBox_Logger.ScrollToEnd();
    }

    private void STAT_Build()
    {
        ClearLogger();
        TextBox_Logger.AppendText("INT32\n");

        STAT_DIC.Clear();

        if (CheckBox_H4CNF_BS_GEN.IsChecked == true)
        {
            AppendLogger("MPx_H4CNF_BS_GEN", 131071);
        }
        if (CheckBox_H4CNF_BS_ENTR.IsChecked == true)
        {
            AppendLogger("MPx_H4CNF_BS_ENTR", 63);
        }
        if (CheckBox_H4CNF_BS_ABIL.IsChecked == true)
        {
            AppendLogger("MPx_H4CNF_BS_ABIL", 63);
        }
        if (CheckBox_H4CNF_APPROACH.IsChecked == true)
        {
            AppendLogger("MPx_H4CNF_APPROACH", -1);
        }

        //////////////////////////

        if (GetListBoxSelectedItemContent(ListBox_H4_PROGRESS) == "普通模式")
        {
            AppendLogger("MPx_H4_PROGRESS", 126823);
        }
        else if (GetListBoxSelectedItemContent(ListBox_H4_PROGRESS) == "困难模式")
        {
            AppendLogger("MPx_H4_PROGRESS", 131055);
        }

        //////////////////////////

        if (GetListBoxSelectedItemContent(ListBox_H4CNF_TARGET) == "西西米托龙舌兰")
        {
            AppendLogger("MPx_H4CNF_TARGET", 0);
        }
        else if (GetListBoxSelectedItemContent(ListBox_H4CNF_TARGET) == "红宝石项链")
        {
            AppendLogger("MPx_H4CNF_TARGET", 1);
        }
        else if (GetListBoxSelectedItemContent(ListBox_H4CNF_TARGET) == "不记名债券")
        {
            AppendLogger("MPx_H4CNF_TARGET", 2);
        }
        else if (GetListBoxSelectedItemContent(ListBox_H4CNF_TARGET) == "粉钻")
        {
            AppendLogger("MPx_H4CNF_TARGET", 3);
        }
        else if (GetListBoxSelectedItemContent(ListBox_H4CNF_TARGET) == "玛德拉索文件")
        {
            AppendLogger("MPx_H4CNF_TARGET", 4);
        }
        else if (GetListBoxSelectedItemContent(ListBox_H4CNF_TARGET) == "猎豹雕像")
        {
            AppendLogger("MPx_H4CNF_TARGET", 5);
        }

        //////////////////////////

        // 现金
        if (GetListBoxSelectedItemContent(ListBox_H4LOOT) == "已发现/侦察 现金（室内/室外）")
        {
            AppendLogger("MPx_H4LOOT_CASH_I", -1);
            AppendLogger("MPx_H4LOOT_CASH_C", -1);
            AppendLogger("MPx_H4LOOT_CASH_I_SCOPED", -1);
            AppendLogger("MPx_H4LOOT_CASH_C_SCOPED", -1);
            AppendLogger("MPx_H4LOOT_CASH_V", 90000);
        }
        else
        {
            if (CheckBox_H4LOOT_Random.IsChecked == false)
            {
                AppendLogger("MPx_H4LOOT_CASH_I", 0);
                AppendLogger("MPx_H4LOOT_CASH_C", 0);
                AppendLogger("MPx_H4LOOT_CASH_I_SCOPED", 0);
                AppendLogger("MPx_H4LOOT_CASH_C_SCOPED", 0);
                AppendLogger("MPx_H4LOOT_CASH_V", 0);
            }
        }

        // 大麻
        if (GetListBoxSelectedItemContent(ListBox_H4LOOT) == "已发现/侦察 大麻（室内/室外）")
        {
            AppendLogger("MPx_H4LOOT_WEED_I", -1);
            AppendLogger("MPx_H4LOOT_WEED_C", -1);
            AppendLogger("MPx_H4LOOT_WEED_I_SCOPED", -1);
            AppendLogger("MPx_H4LOOT_WEED_C_SCOPED", -1);
            AppendLogger("MPx_H4LOOT_WEED_V", 145000);
        }
        else
        {
            if (CheckBox_H4LOOT_Random.IsChecked == false)
            {
                AppendLogger("MPx_H4LOOT_WEED_I", 0);
                AppendLogger("MPx_H4LOOT_WEED_C", 0);
                AppendLogger("MPx_H4LOOT_WEED_I_SCOPED", 0);
                AppendLogger("MPx_H4LOOT_WEED_C_SCOPED", 0);
                AppendLogger("MPx_H4LOOT_WEED_V", 0);
            }
        }

        // 可可
        if (GetListBoxSelectedItemContent(ListBox_H4LOOT) == "已发现/侦察 可可（室内/室外）")
        {
            AppendLogger("MPx_H4LOOT_COKE_I", -1);
            AppendLogger("MPx_H4LOOT_COKE_C", -1);
            AppendLogger("MPx_H4LOOT_COKE_I_SCOPED", -1);
            AppendLogger("MPx_H4LOOT_COKE_C_SCOPED", -1);
            AppendLogger("MPx_H4LOOT_COKE_V", 220000);
        }
        else
        {
            if (CheckBox_H4LOOT_Random.IsChecked == false)
            {
                AppendLogger("MPx_H4LOOT_COKE_I", 0);
                AppendLogger("MPx_H4LOOT_COKE_C", 0);
                AppendLogger("MPx_H4LOOT_COKE_I_SCOPED", 0);
                AppendLogger("MPx_H4LOOT_COKE_C_SCOPED", 0);
                AppendLogger("MPx_H4LOOT_COKE_V", 0);
            }
        }

        // 黄金
        if (GetListBoxSelectedItemContent(ListBox_H4LOOT) == "已发现/侦察 黄金（室内/室外）")
        {
            AppendLogger("MPx_H4LOOT_GOLD_I", -1);
            AppendLogger("MPx_H4LOOT_GOLD_C", -1);
            AppendLogger("MPx_H4LOOT_GOLD_I_SCOPED", -1);
            AppendLogger("MPx_H4LOOT_GOLD_C_SCOPED", -1);
            AppendLogger("MPx_H4LOOT_GOLD_V", 320000);
        }
        else
        {
            if (CheckBox_H4LOOT_Random.IsChecked == false)
            {
                AppendLogger("MPx_H4LOOT_GOLD_I", 0);
                AppendLogger("MPx_H4LOOT_GOLD_C", 0);
                AppendLogger("MPx_H4LOOT_GOLD_I_SCOPED", 0);
                AppendLogger("MPx_H4LOOT_GOLD_C_SCOPED", 0);
                AppendLogger("MPx_H4LOOT_GOLD_V", 0);
            }
        }

        //////////////////////////

        // 画作
        if (GetListBoxSelectedItemContent(ListBox_H4LOOT_PAINT) == "已发现/侦察 画作（室内/室外）")
        {
            AppendLogger("MPx_H4LOOT_PAINT", -1);
            AppendLogger("MPx_H4LOOT_PAINT_SCOPED", -1);
            AppendLogger("MPx_H4LOOT_PAINT_V", 180000);
        }
        else
        {
            if (CheckBox_H4LOOT_Random.IsChecked == false)
            {
                AppendLogger("MPx_H4LOOT_PAINT", 0);
                AppendLogger("MPx_H4LOOT_PAINT_SCOPED", 0);
                AppendLogger("MPx_H4LOOT_PAINT_V", 0);
            }
        }

        //////////////////////////

        if (GetListBoxSelectedItemContent(ListBox_H4_MISSIONS) == "潜水艇：虎鲸")
        {
            AppendLogger("MPx_H4_MISSIONS", 65283);
        }
        else if (GetListBoxSelectedItemContent(ListBox_H4_MISSIONS) == "飞机：阿尔科诺斯特")
        {
            AppendLogger("MPx_H4_MISSIONS", 65413);
        }
        else if (GetListBoxSelectedItemContent(ListBox_H4_MISSIONS) == "飞机：梅杜莎")
        {
            AppendLogger("MPx_H4_MISSIONS", 65289);
        }
        else if (GetListBoxSelectedItemContent(ListBox_H4_MISSIONS) == "直升机：隐形歼灭者")
        {
            AppendLogger("MPx_H4_MISSIONS", 65425);
        }
        else if (GetListBoxSelectedItemContent(ListBox_H4_MISSIONS) == "船只：巡逻艇")
        {
            AppendLogger("MPx_H4_MISSIONS", 65313);
        }
        else if (GetListBoxSelectedItemContent(ListBox_H4_MISSIONS) == "船只：长鳍")
        {
            AppendLogger("MPx_H4_MISSIONS", 65345);
        }
        else if (GetListBoxSelectedItemContent(ListBox_H4_MISSIONS) == "全部载具可用")
        {
            AppendLogger("MPx_H4_MISSIONS", 65535);
        }

        //////////////////////////

        if (GetListBoxSelectedItemContent(ListBox_H4CNF_WEAPONS) == "侵略者（连发散弹，连发手枪，手雷，砍刀）")
        {
            AppendLogger("MPx_H4CNF_WEAPONS", 1);
        }
        else if (GetListBoxSelectedItemContent(ListBox_H4CNF_WEAPONS) == "阴谋者（军用步枪，单发手枪，粘弹，指虎）")
        {
            AppendLogger("MPx_H4CNF_WEAPONS", 2);
        }
        else if (GetListBoxSelectedItemContent(ListBox_H4CNF_WEAPONS) == "神枪手（轻狙，连发手枪，燃烧瓶，小刀）")
        {
            AppendLogger("MPx_H4CNF_WEAPONS", 3);
        }
        else if (GetListBoxSelectedItemContent(ListBox_H4CNF_WEAPONS) == "破坏者（MK2冲锋枪，单发手枪，土质炸弹，小刀）")
        {
            AppendLogger("MPx_H4CNF_WEAPONS", 4);
        }
        else if (GetListBoxSelectedItemContent(ListBox_H4CNF_WEAPONS) == "神射手（MK2突击步枪，单发手枪，土质炸弹，砍刀）")
        {
            AppendLogger("MPx_H4CNF_WEAPONS", 5);
        }

        //////////////////////////

        if (CheckBox_H4CNF_WEP_DISRP.IsChecked == true)
        {
            AppendLogger("MPx_H4CNF_WEP_DISRP", 3);
        }
        if (CheckBox_H4CNF_ARM_DISRP.IsChecked == true)
        {
            AppendLogger("MPx_H4CNF_ARM_DISRP", 3);
        }
        if (CheckBox_H4CNF_HEL_DISRP.IsChecked == true)
        {
            AppendLogger("MPx_H4CNF_HEL_DISRP", 3);
        }

        //////////////////////////

        if (CheckBox_H4CNF_GRAPPEL.IsChecked == true)
        {
            AppendLogger("MPx_H4CNF_GRAPPEL", -1);
        }
        if (CheckBox_H4CNF_UNIFORM.IsChecked == true)
        {
            AppendLogger("MPx_H4CNF_UNIFORM", -1);
        }
        if (CheckBox_H4CNF_BOLTCUT.IsChecked == true)
        {
            AppendLogger("MPx_H4CNF_BOLTCUT", -1);
        }

        //////////////////////////

        if (GetListBoxSelectedItemContent(ListBox_H4CNF_TROJAN) == "机场")
        {
            AppendLogger("MPx_H4CNF_TROJAN", 1);
        }
        else if (GetListBoxSelectedItemContent(ListBox_H4CNF_TROJAN) == "北船坞")
        {
            AppendLogger("MPx_H4CNF_TROJAN", 2);
        }
        else if (GetListBoxSelectedItemContent(ListBox_H4CNF_TROJAN) == "主码头-东")
        {
            AppendLogger("MPx_H4CNF_TROJAN", 3);
        }
        else if (GetListBoxSelectedItemContent(ListBox_H4CNF_TROJAN) == "主码头-西")
        {
            AppendLogger("MPx_H4CNF_TROJAN", 4);
        }
        else if (GetListBoxSelectedItemContent(ListBox_H4CNF_TROJAN) == "混合粉")
        {
            AppendLogger("MPx_H4CNF_TROJAN", 5);
        }

        //////////////////////////

        if (CheckBox_H4_PLAYTHROUGH_STATUS.IsChecked == true)
        {
            AppendLogger("MPx_H4_PLAYTHROUGH_STATUS", 10);
        }
    }

    private async void STAT_Run()
    {
        if (STAT_DIC.Count == 0)
        {
            NotifierHelper.Show(NotifierType.Warning, "STAT代码不能为空，操作取消");
            return;
        }

        ClearLogger();

        AppendLogger("正在执行STAT代码中...");

        var index = 1;
        foreach (var item in STAT_DIC)
        {
            AppendLogger($"正在执行 第 {index++}/{STAT_DIC.Count} 条代码");

            await STATS.STAT_SET_INT(item.Key, item.Value);
        }

        AppendLogger("STAT代码执行完毕");
    }

    private void Button_STAT_Build_Click(object sender, RoutedEventArgs e)
    {
        Button_STAT_Build.IsEnabled = false;
        STAT_Build();
        Button_STAT_Build.IsEnabled = true;
    }

    private void Button_STAT_Run_Click(object sender, RoutedEventArgs e)
    {
        Button_STAT_Run.IsEnabled = false;
        STAT_Run();
        Button_STAT_Run.IsEnabled = true;
    }
}
