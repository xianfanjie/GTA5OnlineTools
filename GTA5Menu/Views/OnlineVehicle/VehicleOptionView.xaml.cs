using GTA5Core.Features;
using GTA5Core.GTA.Onlines;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.OnlineVehicle;

/// <summary>
/// VehicleOptionView.xaml 的交互逻辑
/// </summary>
public partial class VehicleOptionView : UserControl
{
    private class Options
    {
        public bool GodMode = false;
        public bool Seatbelt = false;
        public bool Parachute = false;

        public bool Extra = false;
        public short ExtraFlag = 0;
    }
    private readonly Options _options = new();

    public VehicleOptionView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;
        GTA5MenuWindow.LoopTime1000MsEvent += GTA5MenuWindow_LoopTime1000MsEvent;

        // 载具附加功能
        foreach (var item in OnlineData.VehicleExtras)
        {
            ComboBox_VehicleExtras.Items.Add(item.Name);
        }
        ComboBox_VehicleExtras.SelectedIndex = 0;
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {

    }

    private void GTA5MenuWindow_LoopTime1000MsEvent()
    {
        // 载具无敌
        if (_options.GodMode)
            Vehicle.GodMode(true);
        // 载具安全带
        if (_options.Seatbelt)
            Vehicle.Seatbelt(true);
        // 载具降落伞
        if (_options.Parachute)
            Vehicle.Parachute(true);

        // 载具附加功能
        if (_options.Extra)
            Vehicle.Extras(_options.ExtraFlag);
    }

    /////////////////////////////////////////////////

    private void CheckBox_VehicleGodMode_Click(object sender, RoutedEventArgs e)
    {
        _options.GodMode = CheckBox_VehicleGodMode.IsChecked == true;
        Vehicle.GodMode(_options.GodMode);
    }

    private void CheckBox_VehicleSeatbelt_Click(object sender, RoutedEventArgs e)
    {
        _options.Seatbelt = CheckBox_VehicleSeatbelt.IsChecked == true;
        Vehicle.Seatbelt(_options.Seatbelt);
    }

    private void CheckBox_VehicleParachute_Click(object sender, RoutedEventArgs e)
    {
        _options.Parachute = CheckBox_VehicleParachute.IsChecked == true;
        Vehicle.Parachute(_options.Parachute);
    }

    private void Button_FillVehicleHealth_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        Vehicle.FillHealth();
    }

    private async void Button_RepairVehicle_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        await Vehicle.FixVehicleByBST();
    }

    private void Button_TurnOffBST_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        Online.InstantBullShark(false);
    }

    private void ComboBox_VehicleExtras_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var index = ComboBox_VehicleExtras.SelectedIndex;
        if (index == -1 || index == 0)
        {
            _options.Extra = false;
            return;
        }

        _options.Extra = true;
        _options.ExtraFlag = (short)OnlineData.VehicleExtras[index].Value;
        Vehicle.Extras(_options.ExtraFlag);
    }

    private void CheckBox_TriggerRCBandito_Click(object sender, RoutedEventArgs e)
    {
        Online.TriggerRCBandito(CheckBox_TriggerRCBandito.IsChecked == true);
    }

    private void CheckBox_TriggerMiniTank_Click(object sender, RoutedEventArgs e)
    {
        Online.TriggerMiniTank(CheckBox_TriggerMiniTank.IsChecked == true);
    }

    private void Button_Unlock167Vehicle_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        Vehicle.Unlock167Vehicle();
    }
}
