using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5MenuExtra.Views.HeistsEditor.Apartment;

/// <summary>
/// MoneyView.xaml 的交互逻辑
/// </summary>
public partial class MoneyView : UserControl
{
    private const int apart_ratio = 1938365 + 3008;     // +1 +2 +3 +4
    private const int apart_money = 262145 + 9300;

    public MoneyView()
    {
        InitializeComponent();
    }

    private void Button_Read_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        TextBox_Apart_Player1.Text = Globals.ReadGA<int>(apart_ratio + 1).ToString();
        TextBox_Apart_Player2.Text = Globals.ReadGA<int>(apart_ratio + 2).ToString();
        TextBox_Apart_Player3.Text = Globals.ReadGA<int>(apart_ratio + 3).ToString();
        TextBox_Apart_Player4.Text = Globals.ReadGA<int>(apart_ratio + 4).ToString();

        TextBox_Apart_Fleeca.Text = Globals.ReadGA<int>(apart_money + 0).ToString();
        TextBox_Apart_PrisonBreak.Text = Globals.ReadGA<int>(apart_money + 1).ToString();
        TextBox_Apart_HumaneLabs.Text = Globals.ReadGA<int>(apart_money + 2).ToString();
        TextBox_Apart_SeriesA.Text = Globals.ReadGA<int>(apart_money + 3).ToString();
        TextBox_Apart_PacificStandard.Text = Globals.ReadGA<int>(apart_money + 4).ToString();

        NotifierHelper.Show(NotifierType.Success, "读取 公寓抢劫 玩家分红数据 成功");
    }

    private void Button_Write_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

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
                Globals.WriteGA(apart_ratio + 1, Convert.ToInt32(TextBox_Apart_Player1.Text.Trim()));
                Globals.WriteGA(apart_ratio + 2, Convert.ToInt32(TextBox_Apart_Player2.Text.Trim()));
                Globals.WriteGA(apart_ratio + 3, Convert.ToInt32(TextBox_Apart_Player3.Text.Trim()));
                Globals.WriteGA(apart_ratio + 4, Convert.ToInt32(TextBox_Apart_Player4.Text.Trim()));

                Globals.WriteGA(apart_money + 0, Convert.ToInt32(TextBox_Apart_Fleeca.Text.Trim()));
                Globals.WriteGA(apart_money + 1, Convert.ToInt32(TextBox_Apart_PrisonBreak.Text.Trim()));
                Globals.WriteGA(apart_money + 2, Convert.ToInt32(TextBox_Apart_HumaneLabs.Text.Trim()));
                Globals.WriteGA(apart_money + 3, Convert.ToInt32(TextBox_Apart_SeriesA.Text.Trim()));
                Globals.WriteGA(apart_money + 4, Convert.ToInt32(TextBox_Apart_PacificStandard.Text.Trim()));

                NotifierHelper.Show(NotifierType.Success, "写入 公寓抢劫 玩家分红数据 成功");
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
