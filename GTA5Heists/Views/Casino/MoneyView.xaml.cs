using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5Heists.Views.Casino;

/// <summary>
/// MoneyView.xaml 的交互逻辑
/// </summary>
public partial class MoneyView : UserControl
{
    private const int casino_player_radio = 1971696 + 2325;
    private const int casino_player_money = 262145 + 29011;     // -1638885821

    private const int casino_ai_radio = 262145 + 29023;
    private const int casino_lester_radio = 262145 + 28998;     // joaat("CH_LESTER_CUT")

    public MoneyView()
    {
        InitializeComponent();
    }

    private void Button_Read_Click(object sender, RoutedEventArgs e)
    {
        // 赌场抢劫玩家分红比例
        TextBox_Casino_Player1.Text = Hacks.ReadGA<int>(casino_player_radio + 1).ToString();
        TextBox_Casino_Player2.Text = Hacks.ReadGA<int>(casino_player_radio + 2).ToString();
        TextBox_Casino_Player3.Text = Hacks.ReadGA<int>(casino_player_radio + 3).ToString();
        TextBox_Casino_Player4.Text = Hacks.ReadGA<int>(casino_player_radio + 4).ToString();

        TextBox_Casino_Lester.Text = Hacks.ReadGA<int>(casino_lester_radio).ToString();

        TextBox_CasinoPotential_Money.Text = Hacks.ReadGA<int>(casino_player_money + 1).ToString();
        TextBox_CasinoPotential_Artwork.Text = Hacks.ReadGA<int>(casino_player_money + 2).ToString();
        TextBox_CasinoPotential_Gold.Text = Hacks.ReadGA<int>(casino_player_money + 3).ToString();
        TextBox_CasinoPotential_Diamonds.Text = Hacks.ReadGA<int>(casino_player_money + 4).ToString();

        TextBox_CasinoAI_1.Text = Hacks.ReadGA<int>(casino_ai_radio + 1).ToString();
        TextBox_CasinoAI_2.Text = Hacks.ReadGA<int>(casino_ai_radio + 2).ToString();
        TextBox_CasinoAI_3.Text = Hacks.ReadGA<int>(casino_ai_radio + 3).ToString();
        TextBox_CasinoAI_4.Text = Hacks.ReadGA<int>(casino_ai_radio + 4).ToString();
        TextBox_CasinoAI_5.Text = Hacks.ReadGA<int>(casino_ai_radio + 5).ToString();

        TextBox_CasinoAI_6.Text = Hacks.ReadGA<int>(casino_ai_radio + 6).ToString();
        TextBox_CasinoAI_7.Text = Hacks.ReadGA<int>(casino_ai_radio + 7).ToString();
        TextBox_CasinoAI_8.Text = Hacks.ReadGA<int>(casino_ai_radio + 8).ToString();
        TextBox_CasinoAI_9.Text = Hacks.ReadGA<int>(casino_ai_radio + 9).ToString();
        TextBox_CasinoAI_10.Text = Hacks.ReadGA<int>(casino_ai_radio + 10).ToString();

        TextBox_CasinoAI_11.Text = Hacks.ReadGA<int>(casino_ai_radio + 11).ToString();
        TextBox_CasinoAI_12.Text = Hacks.ReadGA<int>(casino_ai_radio + 12).ToString();
        TextBox_CasinoAI_13.Text = Hacks.ReadGA<int>(casino_ai_radio + 13).ToString();
        TextBox_CasinoAI_14.Text = Hacks.ReadGA<int>(casino_ai_radio + 14).ToString();
        TextBox_CasinoAI_15.Text = Hacks.ReadGA<int>(casino_ai_radio + 15).ToString();
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
                // 赌场抢劫玩家分红比例
                Hacks.WriteGA(casino_player_radio + 1, Convert.ToInt32(TextBox_Casino_Player1.Text.Trim()));
                Hacks.WriteGA(casino_player_radio + 2, Convert.ToInt32(TextBox_Casino_Player2.Text.Trim()));
                Hacks.WriteGA(casino_player_radio + 3, Convert.ToInt32(TextBox_Casino_Player3.Text.Trim()));
                Hacks.WriteGA(casino_player_radio + 4, Convert.ToInt32(TextBox_Casino_Player4.Text.Trim()));

                Hacks.WriteGA(casino_lester_radio, Convert.ToInt32(TextBox_Casino_Lester.Text.Trim()));

                Hacks.WriteGA(casino_player_money + 1, Convert.ToInt32(TextBox_CasinoPotential_Money.Text.Trim()));
                Hacks.WriteGA(casino_player_money + 2, Convert.ToInt32(TextBox_CasinoPotential_Artwork.Text.Trim()));
                Hacks.WriteGA(casino_player_money + 3, Convert.ToInt32(TextBox_CasinoPotential_Gold.Text.Trim()));
                Hacks.WriteGA(casino_player_money + 4, Convert.ToInt32(TextBox_CasinoPotential_Diamonds.Text.Trim()));

                Hacks.WriteGA(casino_ai_radio + 1, Convert.ToInt32(TextBox_CasinoAI_1.Text.Trim()));
                Hacks.WriteGA(casino_ai_radio + 2, Convert.ToInt32(TextBox_CasinoAI_2.Text.Trim()));
                Hacks.WriteGA(casino_ai_radio + 3, Convert.ToInt32(TextBox_CasinoAI_3.Text.Trim()));
                Hacks.WriteGA(casino_ai_radio + 4, Convert.ToInt32(TextBox_CasinoAI_4.Text.Trim()));
                Hacks.WriteGA(casino_ai_radio + 5, Convert.ToInt32(TextBox_CasinoAI_5.Text.Trim()));

                Hacks.WriteGA(casino_ai_radio + 6, Convert.ToInt32(TextBox_CasinoAI_6.Text.Trim()));
                Hacks.WriteGA(casino_ai_radio + 7, Convert.ToInt32(TextBox_CasinoAI_7.Text.Trim()));
                Hacks.WriteGA(casino_ai_radio + 8, Convert.ToInt32(TextBox_CasinoAI_8.Text.Trim()));
                Hacks.WriteGA(casino_ai_radio + 9, Convert.ToInt32(TextBox_CasinoAI_9.Text.Trim()));
                Hacks.WriteGA(casino_ai_radio + 10, Convert.ToInt32(TextBox_CasinoAI_10.Text.Trim()));

                Hacks.WriteGA(casino_ai_radio + 11, Convert.ToInt32(TextBox_CasinoAI_11.Text.Trim()));
                Hacks.WriteGA(casino_ai_radio + 12, Convert.ToInt32(TextBox_CasinoAI_12.Text.Trim()));
                Hacks.WriteGA(casino_ai_radio + 13, Convert.ToInt32(TextBox_CasinoAI_13.Text.Trim()));
                Hacks.WriteGA(casino_ai_radio + 14, Convert.ToInt32(TextBox_CasinoAI_14.Text.Trim()));
                Hacks.WriteGA(casino_ai_radio + 15, Convert.ToInt32(TextBox_CasinoAI_15.Text.Trim()));
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
