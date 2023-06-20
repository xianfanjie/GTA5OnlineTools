using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5MenuExtra.Views.HeistsEditor.Casino;

/// <summary>
/// MoneyView.xaml 的交互逻辑
/// </summary>
public partial class MoneyView : UserControl
{
    private const int player_ratio = 1971696 + 1497 + 736 + 92;
    private const int player_money = 262145 + 29011;     // -1638885821

    private const int ai_ratio = 262145 + 29023;
    private const int lester_ratio = 262145 + 28998;     // joaat("CH_LESTER_CUT")

    public MoneyView()
    {
        InitializeComponent();
    }

    private void Button_Read_Click(object sender, RoutedEventArgs e)
    {
        TextBox_Casino_Player1.Text = Hacks.ReadGA<int>(player_ratio + 1).ToString();
        TextBox_Casino_Player2.Text = Hacks.ReadGA<int>(player_ratio + 2).ToString();
        TextBox_Casino_Player3.Text = Hacks.ReadGA<int>(player_ratio + 3).ToString();
        TextBox_Casino_Player4.Text = Hacks.ReadGA<int>(player_ratio + 4).ToString();

        TextBox_Casino_Lester.Text = Hacks.ReadGA<int>(lester_ratio).ToString();

        TextBox_CasinoPotential_Money.Text = Hacks.ReadGA<int>(player_money + 1).ToString();
        TextBox_CasinoPotential_Artwork.Text = Hacks.ReadGA<int>(player_money + 2).ToString();
        TextBox_CasinoPotential_Gold.Text = Hacks.ReadGA<int>(player_money + 3).ToString();
        TextBox_CasinoPotential_Diamonds.Text = Hacks.ReadGA<int>(player_money + 4).ToString();

        TextBox_CasinoAI_1.Text = Hacks.ReadGA<int>(ai_ratio + 1).ToString();
        TextBox_CasinoAI_2.Text = Hacks.ReadGA<int>(ai_ratio + 2).ToString();
        TextBox_CasinoAI_3.Text = Hacks.ReadGA<int>(ai_ratio + 3).ToString();
        TextBox_CasinoAI_4.Text = Hacks.ReadGA<int>(ai_ratio + 4).ToString();
        TextBox_CasinoAI_5.Text = Hacks.ReadGA<int>(ai_ratio + 5).ToString();

        TextBox_CasinoAI_6.Text = Hacks.ReadGA<int>(ai_ratio + 6).ToString();
        TextBox_CasinoAI_7.Text = Hacks.ReadGA<int>(ai_ratio + 7).ToString();
        TextBox_CasinoAI_8.Text = Hacks.ReadGA<int>(ai_ratio + 8).ToString();
        TextBox_CasinoAI_9.Text = Hacks.ReadGA<int>(ai_ratio + 9).ToString();
        TextBox_CasinoAI_10.Text = Hacks.ReadGA<int>(ai_ratio + 10).ToString();

        TextBox_CasinoAI_11.Text = Hacks.ReadGA<int>(ai_ratio + 11).ToString();
        TextBox_CasinoAI_12.Text = Hacks.ReadGA<int>(ai_ratio + 12).ToString();
        TextBox_CasinoAI_13.Text = Hacks.ReadGA<int>(ai_ratio + 13).ToString();
        TextBox_CasinoAI_14.Text = Hacks.ReadGA<int>(ai_ratio + 14).ToString();
        TextBox_CasinoAI_15.Text = Hacks.ReadGA<int>(ai_ratio + 15).ToString();

        NotifierHelper.Show(NotifierType.Success, "读取 赌场抢劫 玩家分红数据 成功");
    }

    private void Button_Write_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (TextBox_Casino_Player1.Text.Trim() != "" &&
                TextBox_Casino_Player2.Text.Trim() != "" &&
                TextBox_Casino_Player3.Text.Trim() != "" &&
                TextBox_Casino_Player4.Text.Trim() != "" &&

                TextBox_Casino_Lester.Text.Trim() != "" &&

                TextBox_CasinoPotential_Money.Text.Trim() != "" &&
                TextBox_CasinoPotential_Artwork.Text.Trim() != "" &&
                TextBox_CasinoPotential_Gold.Text.Trim() != "" &&
                TextBox_CasinoPotential_Diamonds.Text.Trim() != "" &&

                TextBox_CasinoAI_1.Text.Trim() != "" &&
                TextBox_CasinoAI_2.Text.Trim() != "" &&
                TextBox_CasinoAI_3.Text.Trim() != "" &&
                TextBox_CasinoAI_4.Text.Trim() != "" &&
                TextBox_CasinoAI_5.Text.Trim() != "" &&

                TextBox_CasinoAI_6.Text.Trim() != "" &&
                TextBox_CasinoAI_7.Text.Trim() != "" &&
                TextBox_CasinoAI_8.Text.Trim() != "" &&
                TextBox_CasinoAI_9.Text.Trim() != "" &&
                TextBox_CasinoAI_10.Text.Trim() != "" &&

                TextBox_CasinoAI_11.Text.Trim() != "" &&
                TextBox_CasinoAI_12.Text.Trim() != "" &&
                TextBox_CasinoAI_13.Text.Trim() != "" &&
                TextBox_CasinoAI_14.Text.Trim() != "" &&
                TextBox_CasinoAI_15.Text.Trim() != "")
            {
                Hacks.WriteGA(player_ratio + 1, Convert.ToInt32(TextBox_Casino_Player1.Text.Trim()));
                Hacks.WriteGA(player_ratio + 2, Convert.ToInt32(TextBox_Casino_Player2.Text.Trim()));
                Hacks.WriteGA(player_ratio + 3, Convert.ToInt32(TextBox_Casino_Player3.Text.Trim()));
                Hacks.WriteGA(player_ratio + 4, Convert.ToInt32(TextBox_Casino_Player4.Text.Trim()));

                Hacks.WriteGA(lester_ratio, Convert.ToInt32(TextBox_Casino_Lester.Text.Trim()));

                Hacks.WriteGA(player_money + 1, Convert.ToInt32(TextBox_CasinoPotential_Money.Text.Trim()));
                Hacks.WriteGA(player_money + 2, Convert.ToInt32(TextBox_CasinoPotential_Artwork.Text.Trim()));
                Hacks.WriteGA(player_money + 3, Convert.ToInt32(TextBox_CasinoPotential_Gold.Text.Trim()));
                Hacks.WriteGA(player_money + 4, Convert.ToInt32(TextBox_CasinoPotential_Diamonds.Text.Trim()));

                Hacks.WriteGA(ai_ratio + 1, Convert.ToInt32(TextBox_CasinoAI_1.Text.Trim()));
                Hacks.WriteGA(ai_ratio + 2, Convert.ToInt32(TextBox_CasinoAI_2.Text.Trim()));
                Hacks.WriteGA(ai_ratio + 3, Convert.ToInt32(TextBox_CasinoAI_3.Text.Trim()));
                Hacks.WriteGA(ai_ratio + 4, Convert.ToInt32(TextBox_CasinoAI_4.Text.Trim()));
                Hacks.WriteGA(ai_ratio + 5, Convert.ToInt32(TextBox_CasinoAI_5.Text.Trim()));

                Hacks.WriteGA(ai_ratio + 6, Convert.ToInt32(TextBox_CasinoAI_6.Text.Trim()));
                Hacks.WriteGA(ai_ratio + 7, Convert.ToInt32(TextBox_CasinoAI_7.Text.Trim()));
                Hacks.WriteGA(ai_ratio + 8, Convert.ToInt32(TextBox_CasinoAI_8.Text.Trim()));
                Hacks.WriteGA(ai_ratio + 9, Convert.ToInt32(TextBox_CasinoAI_9.Text.Trim()));
                Hacks.WriteGA(ai_ratio + 10, Convert.ToInt32(TextBox_CasinoAI_10.Text.Trim()));

                Hacks.WriteGA(ai_ratio + 11, Convert.ToInt32(TextBox_CasinoAI_11.Text.Trim()));
                Hacks.WriteGA(ai_ratio + 12, Convert.ToInt32(TextBox_CasinoAI_12.Text.Trim()));
                Hacks.WriteGA(ai_ratio + 13, Convert.ToInt32(TextBox_CasinoAI_13.Text.Trim()));
                Hacks.WriteGA(ai_ratio + 14, Convert.ToInt32(TextBox_CasinoAI_14.Text.Trim()));
                Hacks.WriteGA(ai_ratio + 15, Convert.ToInt32(TextBox_CasinoAI_15.Text.Trim()));

                NotifierHelper.Show(NotifierType.Success, "写入 赌场抢劫 玩家分红数据 成功");
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
