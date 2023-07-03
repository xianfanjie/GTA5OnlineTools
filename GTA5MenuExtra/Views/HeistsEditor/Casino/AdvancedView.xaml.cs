using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5MenuExtra.Views.HeistsEditor.Casino;

/// <summary>
/// AdvancedView.xaml 的交互逻辑
/// </summary>
public partial class AdvancedView : UserControl
{
    public AdvancedView()
    {
        InitializeComponent();
    }

    private async void STAT_SET_INT(string hash, int value)
    {
        await STATS.STAT_SET_INT(hash, value);
    }

    private void Button_Reset_H3OPT_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        STAT_SET_INT("MPx_H3OPT_BITSET1", 0);
        STAT_SET_INT("MPx_H3OPT_BITSET0", 0);
        STAT_SET_INT("MPx_H3OPT_POI", 0);
        STAT_SET_INT("MPx_H3OPT_ACCESSPOINTS", 0);
        STAT_SET_INT("MPx_CAS_HEIST_FLOW", 0);

        STAT_SET_INT("MPx_H3OPT_BITSET1", -1);
        STAT_SET_INT("MPx_H3OPT_BITSET0", -1);
    }

    private void Button_CAS_HEIST_FLOW_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        STAT_SET_INT("MPx_CAS_HEIST_FLOW", -1610744257);
    }
}
