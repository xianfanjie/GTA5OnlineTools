using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5MenuExtra.Views.HeistsEditor.Doomsday;

/// <summary>
/// MoneyView.xaml 的交互逻辑
/// </summary>
public partial class MoneyView : UserControl
{
    private const int player_ratio = 1967630 + 812 + 50;    // 
    private const int player_money = 262145 + 9305;         // joaat("GANGOPS_THE_IAA_JOB_CASH_REWARD")

    public MoneyView()
    {
        InitializeComponent();
    }

    private void Button_Read_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        TextBox_Doomsday_Player1.Text = Globals.ReadGA<int>(player_ratio + 1).ToString();
        TextBox_Doomsday_Player2.Text = Globals.ReadGA<int>(player_ratio + 2).ToString();
        TextBox_Doomsday_Player3.Text = Globals.ReadGA<int>(player_ratio + 3).ToString();
        TextBox_Doomsday_Player4.Text = Globals.ReadGA<int>(player_ratio + 4).ToString();

        TextBox_Doomsday_ActI.Text = Globals.ReadGA<int>(player_money + 0).ToString();
        TextBox_Doomsday_ActII.Text = Globals.ReadGA<int>(player_money + 1).ToString();
        TextBox_Doomsday_ActIII.Text = Globals.ReadGA<int>(player_money + 2).ToString();

        NotifierHelper.Show(NotifierType.Success, "读取 末日抢劫 玩家分红数据 成功");
    }

    private void Button_Write_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        try
        {
            if (TextBox_Doomsday_Player1.Text.Trim() != "" &&
                TextBox_Doomsday_Player2.Text.Trim() != "" &&
                TextBox_Doomsday_Player3.Text.Trim() != "" &&
                TextBox_Doomsday_Player4.Text.Trim() != "" &&

                TextBox_Doomsday_ActI.Text.Trim() != "" &&
                TextBox_Doomsday_ActII.Text.Trim() != "" &&
                TextBox_Doomsday_ActIII.Text.Trim() != "")
            {
                Globals.WriteGA(player_ratio + 1, Convert.ToInt32(TextBox_Doomsday_Player1.Text.Trim()));
                Globals.WriteGA(player_ratio + 2, Convert.ToInt32(TextBox_Doomsday_Player2.Text.Trim()));
                Globals.WriteGA(player_ratio + 3, Convert.ToInt32(TextBox_Doomsday_Player3.Text.Trim()));
                Globals.WriteGA(player_ratio + 4, Convert.ToInt32(TextBox_Doomsday_Player4.Text.Trim()));

                Globals.WriteGA(player_money + 0, Convert.ToInt32(TextBox_Doomsday_ActI.Text.Trim()));
                Globals.WriteGA(player_money + 1, Convert.ToInt32(TextBox_Doomsday_ActII.Text.Trim()));
                Globals.WriteGA(player_money + 2, Convert.ToInt32(TextBox_Doomsday_ActIII.Text.Trim()));

                NotifierHelper.Show(NotifierType.Success, "写入 末日抢劫 玩家分红数据 成功");
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
