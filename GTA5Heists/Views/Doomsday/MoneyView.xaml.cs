using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5Heists.Views.Doomsday;

/// <summary>
/// MoneyView.xaml 的交互逻辑
/// </summary>
public partial class MoneyView : UserControl
{
    private const int doomsday_player_ration = 1967630 + 812 + 50;  // 
    private const int doomsday_player_money = 262145 + 9305;        // joaat("GANGOPS_THE_IAA_JOB_CASH_REWARD")

    public MoneyView()
    {
        InitializeComponent();
    }

    private void Button_Read_Click(object sender, RoutedEventArgs e)
    {
        // 末日抢劫玩家分红比例
        TextBox_Doomsday_Player1.Text = Hacks.ReadGA<int>(doomsday_player_ration + 1).ToString();
        TextBox_Doomsday_Player2.Text = Hacks.ReadGA<int>(doomsday_player_ration + 2).ToString();
        TextBox_Doomsday_Player3.Text = Hacks.ReadGA<int>(doomsday_player_ration + 3).ToString();
        TextBox_Doomsday_Player4.Text = Hacks.ReadGA<int>(doomsday_player_ration + 4).ToString();

        TextBox_Doomsday_ActI.Text = Hacks.ReadGA<int>(doomsday_player_money + 0).ToString();
        TextBox_Doomsday_ActII.Text = Hacks.ReadGA<int>(doomsday_player_money + 1).ToString();
        TextBox_Doomsday_ActIII.Text = Hacks.ReadGA<int>(doomsday_player_money + 2).ToString();
    }

    private void Button_Write_Click(object sender, RoutedEventArgs e)
    {
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
                // 末日抢劫玩家分红比例
                Hacks.WriteGA(doomsday_player_ration + 1, Convert.ToInt32(TextBox_Doomsday_Player1.Text.Trim()));
                Hacks.WriteGA(doomsday_player_ration + 2, Convert.ToInt32(TextBox_Doomsday_Player2.Text.Trim()));
                Hacks.WriteGA(doomsday_player_ration + 3, Convert.ToInt32(TextBox_Doomsday_Player3.Text.Trim()));
                Hacks.WriteGA(doomsday_player_ration + 4, Convert.ToInt32(TextBox_Doomsday_Player4.Text.Trim()));

                Hacks.WriteGA(doomsday_player_money + 0, Convert.ToInt32(TextBox_Doomsday_ActI.Text.Trim()));
                Hacks.WriteGA(doomsday_player_money + 1, Convert.ToInt32(TextBox_Doomsday_ActII.Text.Trim()));
                Hacks.WriteGA(doomsday_player_money + 2, Convert.ToInt32(TextBox_Doomsday_ActIII.Text.Trim()));
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
