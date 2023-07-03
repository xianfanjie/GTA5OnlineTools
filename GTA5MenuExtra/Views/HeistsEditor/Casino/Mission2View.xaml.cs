using GTA5Core.Features;

namespace GTA5MenuExtra.Views.HeistsEditor.Casino;

/// <summary>
/// Mission2View.xaml 的交互逻辑
/// </summary>
public partial class Mission2View : UserControl
{
    public Mission2View()
    {
        InitializeComponent();
    }

    private async void STAT_SET_INT(string hash, int value)
    {
        await STATS.STAT_SET_INT(hash, value);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_DISRUPTSHIP_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_DISRUPTSHIP", 3);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_KEYLEVELS_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_KEYLEVELS", 2);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_CREWWEAP_1_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_CREWWEAP", 1);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWWEAP_2_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_CREWWEAP", 2);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWWEAP_3_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_CREWWEAP", 3);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWWEAP_4_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_CREWWEAP", 4);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWWEAP_5_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_CREWWEAP", 5);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWWEAP_6_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_CREWWEAP", 6);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_CREWDRIVER_1_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_CREWDRIVER", 1);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWDRIVER_2_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_CREWDRIVER", 2);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWDRIVER_3_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_CREWDRIVER", 3);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWDRIVER_4_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_CREWDRIVER", 4);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWDRIVER_5_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_CREWDRIVER", 5);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWDRIVER_6_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_CREWDRIVER", 6);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_CREWHACKER_1_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_CREWHACKER", 1);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWHACKER_2_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_CREWHACKER", 2);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWHACKER_3_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_CREWHACKER", 3);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWHACKER_4_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_CREWHACKER", 4);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWHACKER_5_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_CREWHACKER", 5);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_CREWHACKER_6_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_CREWHACKER", 6);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_WEAPS_0_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_WEAPS", 0);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_WEAPS_1_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_WEAPS", 1);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_WEAPS_2_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_WEAPS", 2);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_WEAPS_3_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_WEAPS", 3);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_WEAPS_4_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_WEAPS", 4);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_VEH_0_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_VEHS", 0);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_VEH_1_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_VEHS", 1);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_VEH_2_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_VEHS", 2);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_H3OPT_VEH_3_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_VEHS", 3);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    ////////////////////////////////////////////////////

    private void Button_H3OPT_BITSET0_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
    }

    private void Button_CAS_HEIST_FLOW_Click(object sender, RoutedEventArgs e)
    {
        STAT_SET_INT("MPx_CAS_HEIST_FLOW", -1610744257);
    }
}
