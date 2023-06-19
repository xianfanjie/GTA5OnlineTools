using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5Heists.Views.Apartment;

/// <summary>
/// MoneyView.xaml 的交互逻辑
/// </summary>
public partial class MoneyView : UserControl
{
    private const int apart_radio = 1938365 + 3008;
    private const int apart_money = 262145 + 9300;

    public MoneyView()
    {
        InitializeComponent();
    }

    private void Button_Read_Click(object sender, RoutedEventArgs e)
    {
        // 公寓抢劫玩家分红比例
        TextBox_Apart_Player1.Text = Hacks.ReadGA<int>(apart_radio + 1).ToString();
        TextBox_Apart_Player2.Text = Hacks.ReadGA<int>(apart_radio + 2).ToString();
        TextBox_Apart_Player3.Text = Hacks.ReadGA<int>(apart_radio + 3).ToString();
        TextBox_Apart_Player4.Text = Hacks.ReadGA<int>(apart_radio + 4).ToString();

        TextBox_Apart_Fleeca.Text = Hacks.ReadGA<int>(apart_money + 0).ToString();
        TextBox_Apart_PrisonBreak.Text = Hacks.ReadGA<int>(apart_money + 1).ToString();
        TextBox_Apart_HumaneLabs.Text = Hacks.ReadGA<int>(apart_money + 2).ToString();
        TextBox_Apart_SeriesA.Text = Hacks.ReadGA<int>(apart_money + 3).ToString();
        TextBox_Apart_PacificStandard.Text = Hacks.ReadGA<int>(apart_money + 4).ToString();

        NotifierHelper.Show(NotifierType.Success, "读取公寓抢劫玩家分红数据成功");
    }

    private void Button_Write_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (TextBox_Apart_Player1.Text.Trim() != "" &&
                TextBox_Apart_Player2.Text.Trim() != "" &&
                TextBox_Apart_Player3.Text.Trim() != "" &&
                TextBox_Apart_Player4.Text.Trim() != "" &&

                TextBox_Apart_Fleeca.Text.Trim() != "" &&
                TextBox_Apart_PrisonBreak.Text.Trim() != "" &&
                TextBox_Apart_HumaneLabs.Text.Trim() != "" &&
                TextBox_Apart_SeriesA.Text.Trim() != "" &&
                TextBox_Apart_PacificStandard.Text.Trim() != "")
            {
                // 公寓抢劫玩家分红比例
                Hacks.WriteGA(apart_radio + 1, Convert.ToInt32(TextBox_Apart_Player1.Text.Trim()));
                Hacks.WriteGA(apart_radio + 2, Convert.ToInt32(TextBox_Apart_Player2.Text.Trim()));
                Hacks.WriteGA(apart_radio + 3, Convert.ToInt32(TextBox_Apart_Player3.Text.Trim()));
                Hacks.WriteGA(apart_radio + 4, Convert.ToInt32(TextBox_Apart_Player4.Text.Trim()));

                Hacks.WriteGA(apart_money + 0, Convert.ToInt32(TextBox_Apart_Fleeca.Text.Trim()));
                Hacks.WriteGA(apart_money + 1, Convert.ToInt32(TextBox_Apart_PrisonBreak.Text.Trim()));
                Hacks.WriteGA(apart_money + 2, Convert.ToInt32(TextBox_Apart_HumaneLabs.Text.Trim()));
                Hacks.WriteGA(apart_money + 3, Convert.ToInt32(TextBox_Apart_SeriesA.Text.Trim()));
                Hacks.WriteGA(apart_money + 4, Convert.ToInt32(TextBox_Apart_PacificStandard.Text.Trim()));

                NotifierHelper.Show(NotifierType.Success, "写入公寓抢劫玩家分红数据成功");
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
