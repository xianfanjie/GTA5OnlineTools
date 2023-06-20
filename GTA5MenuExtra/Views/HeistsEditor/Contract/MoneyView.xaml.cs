using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5MenuExtra.Views.HeistsEditor.Contract;

/// <summary>
/// MoneyView.xaml 的交互逻辑
/// </summary>
public partial class MoneyView : UserControl
{
    private const int fixer_ratio = 262145 + 31955;     // -2108119120  joaat("FIXER_FINALE_LEADER_CASH_REWARD")     Global_262145.f_31955
    private const int tuner_ratio = 262145 + 31249;     // -920277662   joaat("TUNER_ROBBERY_LEADER_CASH_REWARD0")   Global_262145.f_31249[0]

    public MoneyView()
    {
        InitializeComponent();
    }

    private void Button_Read_Click(object sender, RoutedEventArgs e)
    {
        TextBox_FIXER_Value.Text = Globals.ReadGA<int>(fixer_ratio).ToString();
        TextBox_TUNER_Value0.Text = Globals.ReadGA<int>(tuner_ratio + 1).ToString();
        TextBox_TUNER_Value1.Text = Globals.ReadGA<int>(tuner_ratio + 2).ToString();
        TextBox_TUNER_Value2.Text = Globals.ReadGA<int>(tuner_ratio + 3).ToString();
        TextBox_TUNER_Value3.Text = Globals.ReadGA<int>(tuner_ratio + 4).ToString();
        TextBox_TUNER_Value4.Text = Globals.ReadGA<int>(tuner_ratio + 5).ToString();
        TextBox_TUNER_Value5.Text = Globals.ReadGA<int>(tuner_ratio + 6).ToString();
        TextBox_TUNER_Value6.Text = Globals.ReadGA<int>(tuner_ratio + 7).ToString();
        TextBox_TUNER_Value7.Text = Globals.ReadGA<int>(tuner_ratio + 8).ToString();

        NotifierHelper.Show(NotifierType.Success, "读取 事所合约 玩家分红数据 成功");
    }

    private void Button_Write_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (TextBox_FIXER_Value.Text.Trim() != "" &&
                TextBox_TUNER_Value0.Text.Trim() != "" &&
                TextBox_TUNER_Value1.Text.Trim() != "" &&
                TextBox_TUNER_Value2.Text.Trim() != "" &&
                TextBox_TUNER_Value3.Text.Trim() != "" &&
                TextBox_TUNER_Value4.Text.Trim() != "" &&
                TextBox_TUNER_Value5.Text.Trim() != "" &&
                TextBox_TUNER_Value6.Text.Trim() != "" &&
                TextBox_TUNER_Value7.Text.Trim() != "")
            {
                Globals.WriteGA(fixer_ratio, Convert.ToInt32(TextBox_FIXER_Value.Text.Trim()));
                Globals.WriteGA(tuner_ratio + 1, Convert.ToInt32(TextBox_TUNER_Value0.Text.Trim()));
                Globals.WriteGA(tuner_ratio + 2, Convert.ToInt32(TextBox_TUNER_Value1.Text.Trim()));
                Globals.WriteGA(tuner_ratio + 3, Convert.ToInt32(TextBox_TUNER_Value2.Text.Trim()));
                Globals.WriteGA(tuner_ratio + 4, Convert.ToInt32(TextBox_TUNER_Value3.Text.Trim()));
                Globals.WriteGA(tuner_ratio + 5, Convert.ToInt32(TextBox_TUNER_Value4.Text.Trim()));
                Globals.WriteGA(tuner_ratio + 6, Convert.ToInt32(TextBox_TUNER_Value5.Text.Trim()));
                Globals.WriteGA(tuner_ratio + 7, Convert.ToInt32(TextBox_TUNER_Value6.Text.Trim()));
                Globals.WriteGA(tuner_ratio + 8, Convert.ToInt32(TextBox_TUNER_Value7.Text.Trim()));

                NotifierHelper.Show(NotifierType.Success, "写入 事所合约 玩家分红数据 成功");
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
