using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5MenuExtra.Views.HeistsEdit;

/// <summary>
/// ApartmentView.xaml 的交互逻辑
/// </summary>
public partial class ApartmentView : UserControl
{
    public ApartmentView()
    {
        InitializeComponent();
    }

    #region 前置任务
    private async void WriteStatWithDelay(string hash, int value)
    {
        await Hacks.WriteIntStat(hash, value);
    }

    ////////////////////////////////////////////////////

    private void Button_HEIST_PLANNING_STAGE_Click(object sender, RoutedEventArgs e)
    {
        WriteStatWithDelay("_HEIST_PLANNING_STAGE", -1);
    }
    #endregion
}
