using GTA5Core.Features;

namespace GTA5Heists.Views.Apartment;

/// <summary>
/// MissionView.xaml 的交互逻辑
/// </summary>
public partial class MissionView : UserControl
{
    public MissionView()
    {
        InitializeComponent();
    }

    private async void WriteStatWithDelay(string hash, int value)
    {
        await Hacks.WriteIntStat(hash, value);
    }

    ////////////////////////////////////////////////////

    private void Button_HEIST_PLANNING_STAGE_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_HEIST_PLANNING_STAGE", -1);
    }
}
