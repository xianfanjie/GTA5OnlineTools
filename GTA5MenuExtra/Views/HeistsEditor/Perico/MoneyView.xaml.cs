using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5MenuExtra.Views.HeistsEditor.Perico;

/// <summary>
/// MoneyView.xaml 的交互逻辑
/// </summary>
public partial class MoneyView : UserControl
{
    /// <summary>
    /// 玩家分红
    /// </summary>
    private const int player_ratio = 1978495 + 825 + 56;
    /// <summary>
    /// 主要目标价值
    /// </summary>
    private const int target_money = 262145 + 30189;    // 132820683    joaat("IH_PRIMARY_TARGET_VALUE_TEQUILA")     Global_262145.f_30189
    /// <summary>
    /// 背包容量
    /// </summary>
    private const int bag_size = 262145 + 29939;        // 1859395035   Global_262145.f_29939

    public MoneyView()
    {
        InitializeComponent();
    }

    private void Button_Read_Click(object sender, RoutedEventArgs e)
    {
        TextBox_Cayo_Player1.Text = Globals.ReadGA<int>(player_ratio + 1).ToString();
        TextBox_Cayo_Player2.Text = Globals.ReadGA<int>(player_ratio + 2).ToString();
        TextBox_Cayo_Player3.Text = Globals.ReadGA<int>(player_ratio + 3).ToString();
        TextBox_Cayo_Player4.Text = Globals.ReadGA<int>(player_ratio + 4).ToString();

        TextBox_Cayo_Tequila.Text = Globals.ReadGA<int>(target_money + 0).ToString();
        TextBox_Cayo_RubyNecklace.Text = Globals.ReadGA<int>(target_money + 1).ToString();
        TextBox_Cayo_BearerBonds.Text = Globals.ReadGA<int>(target_money + 2).ToString();
        TextBox_Cayo_PinkDiamond.Text = Globals.ReadGA<int>(target_money + 3).ToString();
        TextBox_Cayo_MadrazoFiles.Text = Globals.ReadGA<int>(target_money + 4).ToString();
        TextBox_Cayo_BlackPanther.Text = Globals.ReadGA<int>(target_money + 5).ToString();

        TextBox_Cayo_LocalBagSize.Text = Globals.ReadGA<int>(bag_size).ToString();

        TextBox_Cayo_FencingFee.Text = Globals.ReadGA<float>(target_money + 9).ToString();
        TextBox_Cayo_PavelCut.Text = Globals.ReadGA<float>(target_money + 10).ToString();

        NotifierHelper.Show(NotifierType.Success, "读取 佩里克岛 玩家分红数据 成功");
    }

    private void Button_Write_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (TextBox_Cayo_Player1.Text.Trim() != "" &&
                TextBox_Cayo_Player2.Text.Trim() != "" &&
                TextBox_Cayo_Player3.Text.Trim() != "" &&
                TextBox_Cayo_Player4.Text.Trim() != "" &&

                TextBox_Cayo_Tequila.Text.Trim() != "" &&
                TextBox_Cayo_RubyNecklace.Text.Trim() != "" &&
                TextBox_Cayo_BearerBonds.Text.Trim() != "" &&
                TextBox_Cayo_PinkDiamond.Text.Trim() != "" &&
                TextBox_Cayo_MadrazoFiles.Text.Trim() != "" &&
                TextBox_Cayo_BlackPanther.Text.Trim() != "" &&

                TextBox_Cayo_LocalBagSize.Text.Trim() != "" &&

                TextBox_Cayo_FencingFee.Text.Trim() != "" &&
                TextBox_Cayo_PavelCut.Text.Trim() != "")
            {
                Globals.WriteGA(player_ratio + 1, Convert.ToInt32(TextBox_Cayo_Player1.Text.Trim()));
                Globals.WriteGA(player_ratio + 2, Convert.ToInt32(TextBox_Cayo_Player2.Text.Trim()));
                Globals.WriteGA(player_ratio + 3, Convert.ToInt32(TextBox_Cayo_Player3.Text.Trim()));
                Globals.WriteGA(player_ratio + 4, Convert.ToInt32(TextBox_Cayo_Player4.Text.Trim()));

                Globals.WriteGA(target_money + 0, Convert.ToInt32(TextBox_Cayo_Tequila.Text.Trim()));
                Globals.WriteGA(target_money + 1, Convert.ToInt32(TextBox_Cayo_RubyNecklace.Text.Trim()));
                Globals.WriteGA(target_money + 2, Convert.ToInt32(TextBox_Cayo_BearerBonds.Text.Trim()));
                Globals.WriteGA(target_money + 3, Convert.ToInt32(TextBox_Cayo_PinkDiamond.Text.Trim()));
                Globals.WriteGA(target_money + 4, Convert.ToInt32(TextBox_Cayo_MadrazoFiles.Text.Trim()));
                Globals.WriteGA(target_money + 5, Convert.ToInt32(TextBox_Cayo_BlackPanther.Text.Trim()));

                Globals.WriteGA(bag_size, Convert.ToInt32(TextBox_Cayo_LocalBagSize.Text.Trim()));

                Globals.WriteGA(target_money + 9, Convert.ToSingle(TextBox_Cayo_FencingFee.Text.Trim()));
                Globals.WriteGA(target_money + 10, Convert.ToSingle(TextBox_Cayo_PavelCut.Text.Trim()));

                NotifierHelper.Show(NotifierType.Success, "写入 佩里克岛 玩家分红数据 成功");
            }
            else
            {
                NotifierHelper.Show(NotifierType.Warning, "部分数据为空，请检查后重新写入");
            }
        }
        catch (Exception ex)
        {
            NotifierHelper.ShowException(ex);
        }
    }
}
