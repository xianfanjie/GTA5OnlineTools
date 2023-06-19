using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5Heists.Views.Perico;

/// <summary>
/// MoneyView.xaml 的交互逻辑
/// </summary>
public partial class MoneyView : UserControl
{
    public MoneyView()
    {
        InitializeComponent();
    }

    private void Button_Read_Click(object sender, RoutedEventArgs e)
    {
        // 佩里克岛抢劫玩家分红比例
        TextBox_Cayo_Player1.Text = Hacks.ReadGA<int>(1977693 + 823 + 56 + 1).ToString();
        TextBox_Cayo_Player2.Text = Hacks.ReadGA<int>(1977693 + 823 + 56 + 2).ToString();
        TextBox_Cayo_Player3.Text = Hacks.ReadGA<int>(1977693 + 823 + 56 + 3).ToString();
        TextBox_Cayo_Player4.Text = Hacks.ReadGA<int>(1977693 + 823 + 56 + 4).ToString();

        TextBox_Cayo_Tequila.Text = Hacks.ReadGA<int>(262145 + 29982 + 0).ToString();
        TextBox_Cayo_RubyNecklace.Text = Hacks.ReadGA<int>(262145 + 29982 + 1).ToString();
        TextBox_Cayo_BearerBonds.Text = Hacks.ReadGA<int>(262145 + 29982 + 2).ToString();
        TextBox_Cayo_PinkDiamond.Text = Hacks.ReadGA<int>(262145 + 29982 + 3).ToString();
        TextBox_Cayo_MadrazoFiles.Text = Hacks.ReadGA<int>(262145 + 29982 + 4).ToString();
        TextBox_Cayo_BlackPanther.Text = Hacks.ReadGA<int>(262145 + 29982 + 5).ToString();

        TextBox_Cayo_LocalBagSize.Text = Hacks.ReadGA<int>(262145 + 29732).ToString();

        TextBox_Cayo_FencingFee.Text = Hacks.ReadGA<float>(262145 + 29982 + 9).ToString();
        TextBox_Cayo_PavelCut.Text = Hacks.ReadGA<float>(262145 + 29982 + 10).ToString();
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
                // 佩里克岛抢劫玩家分红比例
                Hacks.WriteGA(1977693 + 823 + 56 + 1, Convert.ToInt32(TextBox_Cayo_Player1.Text.Trim()));
                Hacks.WriteGA(1977693 + 823 + 56 + 2, Convert.ToInt32(TextBox_Cayo_Player2.Text.Trim()));
                Hacks.WriteGA(1977693 + 823 + 56 + 3, Convert.ToInt32(TextBox_Cayo_Player3.Text.Trim()));
                Hacks.WriteGA(1977693 + 823 + 56 + 4, Convert.ToInt32(TextBox_Cayo_Player4.Text.Trim()));

                Hacks.WriteGA(262145 + 29982 + 0, Convert.ToInt32(TextBox_Cayo_Tequila.Text.Trim()));
                Hacks.WriteGA(262145 + 29982 + 1, Convert.ToInt32(TextBox_Cayo_RubyNecklace.Text.Trim()));
                Hacks.WriteGA(262145 + 29982 + 2, Convert.ToInt32(TextBox_Cayo_BearerBonds.Text.Trim()));
                Hacks.WriteGA(262145 + 29982 + 3, Convert.ToInt32(TextBox_Cayo_PinkDiamond.Text.Trim()));
                Hacks.WriteGA(262145 + 29982 + 4, Convert.ToInt32(TextBox_Cayo_MadrazoFiles.Text.Trim()));
                Hacks.WriteGA(262145 + 29982 + 5, Convert.ToInt32(TextBox_Cayo_BlackPanther.Text.Trim()));

                Hacks.WriteGA(262145 + 29732, Convert.ToInt32(TextBox_Cayo_LocalBagSize.Text.Trim()));

                Hacks.WriteGA(262145 + 29982 + 9, Convert.ToSingle(TextBox_Cayo_FencingFee.Text.Trim()));
                Hacks.WriteGA(262145 + 29982 + 10, Convert.ToSingle(TextBox_Cayo_PavelCut.Text.Trim()));
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
