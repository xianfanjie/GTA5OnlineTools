using GTA5Core.Features;
using GTA5Core.RAGE.Onlines;

using GTA5Menu.Options;

namespace GTA5Menu.Views.ExternalMenu;

/// <summary>
/// VehicleOptionView.xaml 的交互逻辑
/// </summary>
public partial class VehicleOptionView : UserControl
{
    public VehicleOptionView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;

        // 载具附加功能
        foreach (var item in OnlineData.VehicleExtras)
        {
            ComboBox_VehicleExtras.Items.Add(item.Name);
        }
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {
        
    }

    /////////////////////////////////////////////////

    private void CheckBox_VehicleGodMode_Click(object sender, RoutedEventArgs e)
    {
        Setting.Vehicle.GodMode = CheckBox_VehicleGodMode.IsChecked == true;
        Vehicle.GodMode(CheckBox_VehicleGodMode.IsChecked == true);
    }

    private void CheckBox_VehicleSeatbelt_Click(object sender, RoutedEventArgs e)
    {
        Setting.Vehicle.Seatbelt = CheckBox_VehicleSeatbelt.IsChecked == true;
        Vehicle.Seatbelt(CheckBox_VehicleSeatbelt.IsChecked == true);
    }

    private void CheckBox_VehicleParachute_Click(object sender, RoutedEventArgs e)
    {
        Vehicle.Parachute(CheckBox_VehicleParachute.IsChecked == true);
    }

    private void CheckBox_VehicleInvisibility_Click(object sender, RoutedEventArgs e)
    {
        Vehicle.Invisible(CheckBox_VehicleInvisibility.IsChecked == true);
    }

    private void Button_FillVehicleHealth_Click(object sender, RoutedEventArgs e)
    {
        Vehicle.FillHealth();
    }

    private async void Button_RepairVehicle_Click(object sender, RoutedEventArgs e)
    {
        await Vehicle.FixVehicleByBST();
    }

    private void Button_TurnOffBST_Click(object sender, RoutedEventArgs e)
    {
        Online.InstantBullShark(false);
    }

    private void ComboBox_VehicleExtras_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var index = ComboBox_VehicleExtras.SelectedIndex;
        if (index != -1)
        {
            Vehicle.Extras((short)OnlineData.VehicleExtras[index].Value);
        }
    }

    private void CheckBox_TriggerRCBandito_Click(object sender, RoutedEventArgs e)
    {
        Online.TriggerRCBandito(CheckBox_TriggerRCBandito.IsChecked == true);
    }

    private void CheckBox_TriggerMiniTank_Click(object sender, RoutedEventArgs e)
    {
        Online.TriggerMiniTank(CheckBox_TriggerMiniTank.IsChecked == true);
    }
}
