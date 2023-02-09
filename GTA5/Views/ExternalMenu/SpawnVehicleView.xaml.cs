using GTA5.Data;

using GTA5Core.Client;
using GTA5Core.Feature;
using GTA5Core.Settings;
using GTA5Core.RAGE;
using GTA5Core.RAGE.Vehicles;

namespace GTA5.Views.ExternalMenu;

/// <summary>
/// SpawnVehicleView.xaml 的交互逻辑
/// </summary>
public partial class SpawnVehicleView : UserControl
{
    public SpawnVehicleView()
    {
        InitializeComponent();
        this.DataContext = this;
        ExternalMenuWindow.WindowClosingEvent += ExternalMenuWindow_WindowClosingEvent;

        // 载具列表
        foreach (var vType in VehicleHash.VehicleTypes)
        {
            ComboBox_VehicleTypes.Items.Add(new IconMenu()
            {
                Icon = "\xe610",
                Title = vType.Key
            });
        }
        ComboBox_VehicleTypes.SelectedIndex = 0;

        // 载具附加功能
        foreach (var item in MiscData.VehicleExtras)
        {
            ComboBox_VehicleExtras.Items.Add(item.Name);
        }
    }

    private void ExternalMenuWindow_WindowClosingEvent()
    {

    }

    private void ComboBox_VehicleTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        lock (this)
        {
            var index = ComboBox_VehicleTypes.SelectedIndex;
            if (index != -1)
            {
                ListBox_VehicleInfo.Items.Clear();

                Task.Run(() =>
                {
                    var typeName = VehicleHash.VehicleTypes.ElementAt(index).Key;
                    foreach (var item in VehicleHash.VehicleTypes[typeName])
                    {
                        this.Dispatcher.BeginInvoke(DispatcherPriority.Background, () =>
                        {
                            if (index == ComboBox_VehicleTypes.SelectedIndex)
                            {
                                ListBox_VehicleInfo.Items.Add(new ModelInfo()
                                {
                                    Name = item.Key,
                                    DisplayName = item.Value,
                                    PreviewImage = RAGEHelper.GetVehicleImage(item.Key)
                                });
                            }
                        });
                    }
                });

                ListBox_VehicleInfo.SelectedIndex = 0;
            }
        }
    }

    private void Button_SpawnOnlineVehicleA_Click(object sender, RoutedEventArgs e)
    {
        if (ListBox_VehicleInfo.SelectedItem is ModelInfo info)
        {
            Vehicle2.SpawnVehicle(info.Name, -255.0f, 5, 0);
        }
    }

    private void Button_SpawnOnlineVehicleB_Click(object sender, RoutedEventArgs e)
    {
        if (ListBox_VehicleInfo.SelectedItem is ModelInfo info)
        {
            Vehicle2.SpawnVehicle(info.Name, 0.0f, 5, 0);
        }
    }

    /////////////////////////////////////////////////////////////////////////////////

    private void CheckBox_VehicleGodMode_Click(object sender, RoutedEventArgs e)
    {
        MenuSetting.Vehicle.GodMode = CheckBox_VehicleGodMode.IsChecked == true;
        Vehicle.GodMode(CheckBox_VehicleGodMode.IsChecked == true);
    }

    private void CheckBox_VehicleSeatbelt_Click(object sender, RoutedEventArgs e)
    {
        MenuSetting.Vehicle.Seatbelt = CheckBox_VehicleSeatbelt.IsChecked == true;
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

    private void Button_RepairVehicle_Click(object sender, RoutedEventArgs e)
    {
        Vehicle.FixVehicleByBST();
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
            Vehicle.Extras((short)MiscData.VehicleExtras[index].ID);
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
