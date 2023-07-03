using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5MenuExtra.Views.HeistsEditor.Casino;

/// <summary>
/// MissionView.xaml 的交互逻辑
/// </summary>
public partial class MissionView : UserControl
{
    private readonly Dictionary<string, int> STAT_DIC = new();

    public MissionView()
    {
        InitializeComponent();
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

    ////////////////////////////////////////////////////

    private void STAT_Build()
    {
        ClearLogger();
        TextBox_Logger.AppendText("INT32\n");

        STAT_DIC.Clear();

        //////////////////////////////////////////

        // 解锁所有侦察点
        if (Button_H3OPT_ACCESSPOINTS.IsChecked == true)
            AppendLogger("MPx_H3OPT_ACCESSPOINTS", -1);

        // 解锁所有兴趣点
        if (Button_H3OPT_H3OPT_POI.IsChecked == true)
            AppendLogger("MPx_H3OPT_POI", -1);

        // 抢劫方式
        var index = ListBox_H3OPT_APPROACH.SelectedIndex;
        if (index != 0)
        {
            AppendLogger("MPx_H3OPT_APPROACH", index);

            // 困难模式
            if (CheckBox_H3_HARD_APPROACH.IsChecked == true)
                AppendLogger("MPx_H3_HARD_APPROACH", index);

            // 最近抢劫
            AppendLogger("MPx_H3_LAST_APPROACH", index == 3 ? new Random().Next(1, 3) : 3);
        }

        // 抢劫物品
        index = ListBox_H3OPT_TARGET.SelectedIndex;
        if (index != 0)
        {
            AppendLogger("MPx_H3OPT_TARGET", index - 1);
        }

        /////////////////////////////

        // 赌场准备和工具
        var bitSet1 = 1;

        // security
        if (ListBox_H3OPT_KEYLEVELS.SelectedIndex != 0)
            bitSet1 += 1 << 1;

        // weapon
        bitSet1 += 1 << 2;

        // vehicle
        bitSet1 += 1 << 3;

        // hackingDevice
        bitSet1 += 1 << 4;

        // drone
        if (ListBox_H3OPT_APPROACH.SelectedIndex == 1)
            bitSet1 += 1 << 5;

        // vault laser
        if (ListBox_H3OPT_APPROACH.SelectedIndex == 1)
            bitSet1 += 1 << 6;

        // vault drill
        if (ListBox_H3OPT_APPROACH.SelectedIndex == 2)
            bitSet1 += 1 << 7;

        // vault explosives
        if (ListBox_H3OPT_APPROACH.SelectedIndex == 3)
            bitSet1 += 1 << 8;

        // breaching/thermal charges
        if (ListBox_H3OPT_APPROACH.SelectedIndex == 3)
            bitSet1 += 1 << 9;

        AppendLogger("MPx_H3OPT_BITSET1", bitSet1);

        /////////////////////////////

        // 门禁卡等级
        index = ListBox_H3OPT_KEYLEVELS.SelectedIndex;
        if (index != 0)
        {
            AppendLogger("MPx_H3OPT_KEYLEVELS", index);
        }

        // shipment
        AppendLogger("MPx_H3OPT_DISRUPTSHIP", 3);

        // 枪手队员
        index = ListBox_H3OPT_CREWWEAP.SelectedIndex;
        if (index != 0)
        {
            AppendLogger("MPx_H3OPT_CREWWEAP", index);
        }

        // 车手队员
        index = ListBox_H3OPT_CREWDRIVER.SelectedIndex;
        if (index != 0)
        {
            AppendLogger("MPx_H3OPT_CREWDRIVER", index);
        }

        // 黑客队员
        index = ListBox_H3OPT_CREWHACKER.SelectedIndex;
        if (index != 0)
        {
            AppendLogger("MPx_H3OPT_CREWHACKER", index);
        }

        // 武器类型
        index = ListBox_H3OPT_WEAPS.SelectedIndex;
        if (index != 0)
        {
            AppendLogger("MPx_H3OPT_WEAPS", index);
        }

        // 逃亡载具
        index = ListBox_H3OPT_VEHS.SelectedIndex;
        if (index != 0)
        {
            AppendLogger("MPx_H3OPT_VEHS", index);
        }

        /////////////////////////////

        // 选择队友支援
        var bitSet0 = 1;

        // patrol routes
        bitSet0 += 1 << 1;

        // duggan shipments
        bitSet0 += 1 << 2;

        // infiltration suits - stealth specific
        if (ListBox_H3OPT_APPROACH.SelectedIndex == 1)
            bitSet0 += 1 << 3;

        // power drills
        bitSet0 += 1 << 4;

        // emp - stealth specific
        if (ListBox_H3OPT_APPROACH.SelectedIndex == 1)
            bitSet0 += 1 << 5;

        // decoy
        bitSet0 += 1 << 6;

        // clean vehicle
        bitSet0 += 1 << 7;

        // bugstars
        bitSet0 += 1 << 8;

        // sechs
        bitSet0 += 1 << 10;

        // sechs
        bitSet0 += 1 << 12;

        // noose exit disguise
        if (ListBox_H3OPT_APPROACH.SelectedIndex == 2)
            bitSet0 += 1 << 14;

        // noose
        bitSet0 += 1 << 16;

        // firefighter
        bitSet0 += 1 << 17;

        // highroller
        bitSet0 += 1 << 18;

        // boring machine - aggressive specific
        if (ListBox_H3OPT_APPROACH.SelectedIndex == 3)
            bitSet0 += 1 << 19;

        // reinforced armor - aggressive specific
        if (ListBox_H3OPT_APPROACH.SelectedIndex == 3)
            bitSet0 += 1 << 20;

        AppendLogger("MPx_H3OPT_BITSET0", bitSet0);

        /////////////////////////////

        // 抢劫面具
        index = ListBox_H3OPT_MASKS.SelectedIndex;
        if (index != 0)
        {
            AppendLogger("MPx_H3OPT_MASKS", index);
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
        AudioHelper.PlayClickSound();

        Button_STAT_Build.IsEnabled = false;
        STAT_Build();
        Button_STAT_Build.IsEnabled = true;
    }

    private void Button_STAT_Run_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        Button_STAT_Run.IsEnabled = false;
        STAT_Run();
        Button_STAT_Run.IsEnabled = true;
    }
}
