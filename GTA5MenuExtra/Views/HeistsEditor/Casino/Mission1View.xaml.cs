using GTA5Core.Features;

namespace GTA5MenuExtra.Views.HeistsEditor.Casino;

/// <summary>
/// Mission1View.xaml 的交互逻辑
/// </summary>
public partial class Mission1View : UserControl
{
    public Mission1View()
    {
        InitializeComponent();
    }

    private async void STAT_SET_INT(string hash, int value)
    {
        await STATS.STAT_SET_INT(hash, value);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_ACCESSPOINTS_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET1", 0);
        STAT_SET_INT("MPx_H3OPT_ACCESSPOINTS", -1);
        STAT_SET_INT("MPx_H3OPT_BITSET1", -1);
    }

    private void Button_H3OPT_H3OPT_POI_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET1", 0);
        STAT_SET_INT("MPx_H3OPT_POI", -1);
        STAT_SET_INT("MPx_H3OPT_BITSET1", -1);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_APPROACH_1_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET1", 0);
        STAT_SET_INT("MPx_H3OPT_APPROACH", 1);
        STAT_SET_INT("MPx_H3OPT_BITSET1", -1);
    }

    private void Button_H3OPT_APPROACH_2_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET1", 0);
        STAT_SET_INT("MPx_H3OPT_APPROACH", 2);
        STAT_SET_INT("MPx_H3OPT_BITSET1", -1);
    }

    private void Button_H3OPT_APPROACH_3_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET1", 0);
        STAT_SET_INT("MPx_H3OPT_APPROACH", 3);
        STAT_SET_INT("MPx_H3OPT_BITSET1", -1);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_TARGET_0_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET1", 0);
        STAT_SET_INT("MPx_H3OPT_TARGET", 0);
        STAT_SET_INT("MPx_H3OPT_BITSET1", -1);
    }

    private void Button_H3OPT_TARGET_1_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET1", 0);
        STAT_SET_INT("MPx_H3OPT_TARGET", 1);
        STAT_SET_INT("MPx_H3OPT_BITSET1", -1);
    }

    private void Button_H3OPT_TARGET_2_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET1", 0);
        STAT_SET_INT("MPx_H3OPT_TARGET", 2);
        STAT_SET_INT("MPx_H3OPT_BITSET1", -1);
    }

    private void Button_H3OPT_TARGET_3_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET1", 0);
        STAT_SET_INT("MPx_H3OPT_TARGET", 3);
        STAT_SET_INT("MPx_H3OPT_BITSET1", -1);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_ACCESSPOINTS_0_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET1", 0);
        STAT_SET_INT("MPx_H3OPT_ACCESSPOINTS", 0);
        STAT_SET_INT("MPx_H3OPT_BITSET1", -1);
    }

    private void Button_H3OPT_H3OPT_POI_0_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET1", 0);
        STAT_SET_INT("MPx_H3OPT_POI", 0);
        STAT_SET_INT("MPx_H3OPT_BITSET1", -1);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_BITSET1_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET1", -1);
        STAT_SET_INT("MPx_H3OPT_BITSET1", 0);
    }

    private void Button_CAS_HEIST_FLOW_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_CAS_HEIST_FLOW", -1610744257);
    }
}
