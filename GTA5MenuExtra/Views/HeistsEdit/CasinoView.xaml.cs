using GTA5MenuExtra.Utils;

using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5MenuExtra.Views.HeistsEdit;

/// <summary>
/// CasinoView.xaml 的交互逻辑
/// </summary>
public partial class CasinoView : UserControl
{
    public CasinoView()
    {
        InitializeComponent();

        TextBox_PreviewGTAHax.Text = "INT32\n";
    }

    private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        ProcessHelper.OpenLink(e.Uri.OriginalString);
        e.Handled = true;
    }

    private string GetSelectedComboBoxItemContent(ComboBox comboBox)
    {
        return (comboBox.SelectedItem as ComboBoxItem).Content.ToString();
    }

    #region 前置任务
    private void TextBox_AppendText_MP(string stat, string value)
    {
        TextBox_PreviewGTAHax.AppendText($"$MPx{stat}\n");
        TextBox_PreviewGTAHax.AppendText($"{value}\n");
    }

    private void Button_BuildGTAHax_Click(object sender, RoutedEventArgs e)
    {
        TextBox_PreviewGTAHax.Clear();
        TextBox_PreviewGTAHax.AppendText("INT32\n");

        if (CheckBox_Reset_P1P2.IsChecked == true)
        {
            TextBox_AppendText_MP("_H3OPT_BITSET1", "0");
            TextBox_AppendText_MP("_H3OPT_BITSET0", "0");
            TextBox_AppendText_MP("_H3OPT_POI", "0");
            TextBox_AppendText_MP("_H3OPT_ACCESSPOINTS", "0");
            TextBox_AppendText_MP("_CAS_HEIST_FLOW", "0");
        }

        if (RadioButton_H3_P1.IsChecked == true)
        {
            if (CheckBox_H3OPT_BITSET1.IsChecked == true)
            {
                TextBox_AppendText_MP("_H3OPT_BITSET1", "0");
            }

            if (GetSelectedComboBoxItemContent(ListBox_H3OPT_APPROACH) == "不选择抢劫方式")
            {

            }
            else if (GetSelectedComboBoxItemContent(ListBox_H3OPT_APPROACH) == "隐迹潜踪")
            {
                TextBox_AppendText_MP("_H3OPT_APPROACH", "1");
            }
            else if (GetSelectedComboBoxItemContent(ListBox_H3OPT_APPROACH) == "兵不厌诈")
            {
                TextBox_AppendText_MP("_H3OPT_APPROACH", "2");
            }
            else if (GetSelectedComboBoxItemContent(ListBox_H3OPT_APPROACH) == "气势汹汹")
            {
                TextBox_AppendText_MP("_H3OPT_APPROACH", "3");
            }

            if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_TARGET) == "不选择抢劫物品")
            {

            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_TARGET) == "现金")
            {
                TextBox_AppendText_MP("_H3OPT_TARGET", "0");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_TARGET) == "黄金")
            {
                TextBox_AppendText_MP("_H3OPT_TARGET", "1");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_TARGET) == "艺术品")
            {
                TextBox_AppendText_MP("_H3OPT_TARGET", "2");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_TARGET) == "钻石")
            {
                TextBox_AppendText_MP("_H3OPT_TARGET", "3");
            }

            if (CheckBox_H3OPT_ACCESSPOINTS.IsChecked == true)
            {
                TextBox_AppendText_MP("_H3OPT_ACCESSPOINTS", "-1");
            }

            if (CheckBox_H3OPT_POI.IsChecked == true)
            {
                TextBox_AppendText_MP("_H3OPT_POI", "-1");
            }

            if (CheckBox_H3OPT_BITSET1_1.IsChecked == true)
            {
                TextBox_AppendText_MP("_H3OPT_BITSET1", "-1");
            }
        }
        else if (RadioButton_H3_P2.IsChecked == true)
        {
            if (CheckBox_H3OPT_BITSET0.IsChecked == true)
            {
                TextBox_AppendText_MP("_H3OPT_BITSET0", "0");
            }

            //////////////////////////////////////

            if (GetSelectedComboBoxItemContent(ComboBox_H3OPT_VEH) == "不选择逃亡载具")
            {

            }
            else if (GetSelectedComboBoxItemContent(ComboBox_H3OPT_VEH) == "载具类型一")
            {
                TextBox_AppendText_MP("_H3OPT_VEHS", "0");
            }
            else if (GetSelectedComboBoxItemContent(ComboBox_H3OPT_VEH) == "载具类型二")
            {
                TextBox_AppendText_MP("_H3OPT_VEHS", "1");
            }
            else if (GetSelectedComboBoxItemContent(ComboBox_H3OPT_VEH) == "载具类型三")
            {
                TextBox_AppendText_MP("_H3OPT_VEHS", "2");
            }
            else if (GetSelectedComboBoxItemContent(ComboBox_H3OPT_VEH) == "载具类型四")
            {
                TextBox_AppendText_MP("_H3OPT_VEHS", "3");
            }

            //////////////////////////////////////

            if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_WEAPS) == "不选择武器类型")
            {

            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_WEAPS) == "武器类型一")
            {
                TextBox_AppendText_MP("_H3OPT_WEAPS", "0");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_WEAPS) == "武器类型二")
            {
                TextBox_AppendText_MP("_H3OPT_WEAPS", "1");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_WEAPS) == "武器类型三")
            {
                TextBox_AppendText_MP("_H3OPT_WEAPS", "2");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_WEAPS) == "武器类型四")
            {
                TextBox_AppendText_MP("_H3OPT_WEAPS", "3");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_WEAPS) == "武器类型五")
            {
                TextBox_AppendText_MP("_H3OPT_WEAPS", "4");
            }

            //////////////////////////////////////

            if (CheckBox_H3OPT_DISRUPTSHIP.IsChecked == true)
            {
                TextBox_AppendText_MP("_H3OPT_DISRUPTSHIP", "3");
            }

            if (CheckBox_H3OPT_KEYLEVELS.IsChecked == true)
            {
                TextBox_AppendText_MP("_H3OPT_KEYLEVELS", "2");
            }

            //////////////////////////////////////

            if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWWEAP) == "不选择枪手")
            {

            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWWEAP) == "卡尔·阿不拉季（5％分红）")
            {
                TextBox_AppendText_MP("_H3OPT_CREWWEAP", "1");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWWEAP) == "古斯塔沃·莫塔（9％分红）")
            {
                TextBox_AppendText_MP("_H3OPT_CREWWEAP", "2");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWWEAP) == "查理·里德（7％分红）")
            {
                TextBox_AppendText_MP("_H3OPT_CREWWEAP", "3");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWWEAP) == "切斯特·麦考伊（10％分红）")
            {
                TextBox_AppendText_MP("_H3OPT_CREWWEAP", "4");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWWEAP) == "帕里克·麦克瑞利（8％分红）")
            {
                TextBox_AppendText_MP("_H3OPT_CREWWEAP", "5");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWWEAP) == "枪手零分红")
            {
                TextBox_AppendText_MP("_H3OPT_CREWWEAP", "6");
            }

            //////////////////////////////////////

            if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWDRIVER) == "不选择车手")
            {

            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWDRIVER) == "卡里姆·登茨（5％分红）")
            {
                TextBox_AppendText_MP("_H3OPT_CREWDRIVER", "1");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWDRIVER) == "塔丽娜·马丁内斯（7％分红）")
            {
                TextBox_AppendText_MP("_H3OPT_CREWDRIVER", "2");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWDRIVER) == "淘艾迪（9％分红）")
            {
                TextBox_AppendText_MP("_H3OPT_CREWDRIVER", "3");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWDRIVER) == "扎克·尼尔森（6％分红）")
            {
                TextBox_AppendText_MP("_H3OPT_CREWDRIVER", "4");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWDRIVER) == "切斯特·麦考伊（10％分红）")
            {
                TextBox_AppendText_MP("_H3OPT_CREWDRIVER", "5");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWDRIVER) == "车手零分红")
            {
                TextBox_AppendText_MP("_H3OPT_CREWDRIVER", "6");
            }

            //////////////////////////////////////

            if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWHACKER) == "不选择黑客")
            {

            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWHACKER) == "里奇·卢肯斯（3％分红）")
            {
                TextBox_AppendText_MP("_H3OPT_CREWHACKER", "1");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWHACKER) == "克里斯汀·费尔兹（7％分红）")
            {
                TextBox_AppendText_MP("_H3OPT_CREWHACKER", "2");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWHACKER) == "尤汗·布莱尔（5％分红）")
            {
                TextBox_AppendText_MP("_H3OPT_CREWHACKER", "3");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWHACKER) == "阿维·施瓦茨曼（10％分红）")
            {
                TextBox_AppendText_MP("_H3OPT_CREWHACKER", "4");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWHACKER) == "佩奇·哈里斯（9％分红）")
            {
                TextBox_AppendText_MP("_H3OPT_CREWHACKER", "5");
            }
            else if (GetSelectedComboBoxItemContent(ComboBoxItem_H3OPT_CREWHACKER) == "黑客零分红")
            {
                TextBox_AppendText_MP("_H3OPT_CREWHACKER", "6");
            }

            //////////////////////////////////////

            if (CheckBox_H3OPT_BITSET0_0.IsChecked == true)
            {
                TextBox_AppendText_MP("_H3OPT_BITSET0", "-1");
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
    #endregion

    #region 高级设置
    private async void WriteStatWithDelay(string hash, int value)
    {
        await Hacks.WriteIntStat(hash, value);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_BITSET1_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET1", -1);
        WriteStatWithDelay("_H3OPT_BITSET1", 0);
    }

    private void Button_H3OPT_APPROACH_1_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET1", 0);
        WriteStatWithDelay("_H3OPT_APPROACH", 1);
        WriteStatWithDelay("_H3OPT_BITSET1", -1);
    }

    private void Button_H3OPT_APPROACH_2_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET1", 0);
        WriteStatWithDelay("_H3OPT_APPROACH", 2);
        WriteStatWithDelay("_H3OPT_BITSET1", -1);
    }

    private void Button_H3OPT_APPROACH_3_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET1", 0);
        WriteStatWithDelay("_H3OPT_APPROACH", 3);
        WriteStatWithDelay("_H3OPT_BITSET1", -1);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_TARGET_0_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET1", 0);
        WriteStatWithDelay("_H3OPT_TARGET", 0);
        WriteStatWithDelay("_H3OPT_BITSET1", -1);
    }

    private void Button_H3OPT_TARGET_1_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET1", 0);
        WriteStatWithDelay("_H3OPT_TARGET", 1);
        WriteStatWithDelay("_H3OPT_BITSET1", -1);
    }

    private void Button_H3OPT_TARGET_2_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET1", 0);
        WriteStatWithDelay("_H3OPT_TARGET", 2);
        WriteStatWithDelay("_H3OPT_BITSET1", -1);
    }

    private void Button_H3OPT_TARGET_3_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET1", 0);
        WriteStatWithDelay("_H3OPT_TARGET", 3);
        WriteStatWithDelay("_H3OPT_BITSET1", -1);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_ACCESSPOINTS_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET1", 0);
        WriteStatWithDelay("_H3OPT_ACCESSPOINTS", -1);
        WriteStatWithDelay("_H3OPT_BITSET1", -1);
    }

    private void Button_H3OPT_ACCESSPOINTS_0_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET1", 0);
        WriteStatWithDelay("_H3OPT_ACCESSPOINTS", 0);
        WriteStatWithDelay("_H3OPT_BITSET1", -1);
    }

    private void Button_H3OPT_H3OPT_POI_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET1", 0);
        WriteStatWithDelay("_H3OPT_POI", -1);
        WriteStatWithDelay("_H3OPT_BITSET1", -1);
    }

    private void Button_H3OPT_H3OPT_POI_0_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET1", 0);
        WriteStatWithDelay("_H3OPT_POI", 0);
        WriteStatWithDelay("_H3OPT_BITSET1", -1);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_BITSET0_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_DISRUPTSHIP_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_DISRUPTSHIP", 3);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_KEYLEVELS_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_KEYLEVELS", 2);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_CREWWEAP_1_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_CREWWEAP", 1);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWWEAP_2_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_CREWWEAP", 2);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWWEAP_3_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_CREWWEAP", 3);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWWEAP_4_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_CREWWEAP", 4);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWWEAP_5_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_CREWWEAP", 5);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWWEAP_6_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_CREWWEAP", 6);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_CREWDRIVER_1_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_CREWDRIVER", 1);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWDRIVER_2_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_CREWDRIVER", 2);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWDRIVER_3_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_CREWDRIVER", 3);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWDRIVER_4_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_CREWDRIVER", 4);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWDRIVER_5_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_CREWDRIVER", 5);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWDRIVER_6_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_CREWDRIVER", 6);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_CREWHACKER_1_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_CREWHACKER", 1);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWHACKER_2_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_CREWHACKER", 2);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWHACKER_3_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_CREWHACKER", 3);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWHACKER_4_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_CREWHACKER", 4);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWHACKER_5_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_CREWHACKER", 5);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWHACKER_6_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_CREWHACKER", 6);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_WEAPS_0_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_WEAPS", 0);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_WEAPS_1_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_WEAPS", 1);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_WEAPS_2_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_WEAPS", 2);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_WEAPS_3_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_WEAPS", 3);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_WEAPS_4_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_WEAPS", 4);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_VEH_0_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_VEHS", 0);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_VEH_1_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_VEHS", 1);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_VEH_2_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_VEHS", 2);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_VEH_3_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_H3OPT_BITSET0", 0);
        WriteStatWithDelay("_H3OPT_VEHS", 3);
        WriteStatWithDelay("_H3OPT_BITSET0", -1);
    }

    private void Button_CAS_HEIST_FLOW_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_CAS_HEIST_FLOW", -1610744257);
    }
    #endregion

}
