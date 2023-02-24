using GTA5Menu.Data;

using GTA5Core.RAGE;
using GTA5Core.RAGE.Vehicles;
using GTA5Core.Feature;

using CommunityToolkit.Mvvm.Input;

namespace GTA5Menu.Views;

/// <summary>
/// SpawnVehicleWindow.xaml 的交互逻辑
/// </summary>
public partial class SpawnVehicleWindow
{
    public SpawnVehicleWindow()
    {
        InitializeComponent();
        this.DataContext = this;
    }

    private void Window_SpawnVehicle_Loaded(object sender, RoutedEventArgs e)
    {
        // 载具分类列表
        foreach (var vClass in VehicleHash.VehicleClasses)
        {
            ListBox_VehicleClasses.Items.Add(new IconMenu()
            {
                Icon = vClass.Icon,
                Title = vClass.Name
            });
        }
        ListBox_VehicleClasses.SelectedIndex = 0;
    }

    private void Window_SpawnVehicle_Closing(object sender, CancelEventArgs e)
    {

    }

    private void ListBox_VehicleTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        lock (this)
        {
            var index = ListBox_VehicleClasses.SelectedIndex;
            if (index == -1)
                return;

            ListBox_VehicleInfo.Items.Clear();

            Task.Run(() =>
            {
                foreach (var item in VehicleHash.VehicleClasses[index].VehicleInfos)
                {
                    this.Dispatcher.BeginInvoke(DispatcherPriority.Background, () =>
                    {
                        if (index == ListBox_VehicleClasses.SelectedIndex)
                        {
                            ListBox_VehicleInfo.Items.Add(new ModelInfo()
                            {
                                Name = item.Name,
                                Value = item.Value,
                                Image = RAGEHelper.GetVehicleImage(item.Value),
                                Mod = item.Mod
                            });
                        }
                    });
                }
            });

            ListBox_VehicleInfo.SelectedIndex = 0;
        }
    }

    [RelayCommand]
    private async void SpawnVehicleA()
    {
        if (ListBox_VehicleInfo.SelectedItem is ModelInfo info)
        {
            await Vehicle2.SpawnVehicle(info.Value, -255.0f, 5, info.Mod);
        }
    }

    [RelayCommand]
    private async void SpawnVehicleB()
    {
        if (ListBox_VehicleInfo.SelectedItem is ModelInfo info)
        {
            await Vehicle2.SpawnVehicle(info.Value, 0.0f, 5, info.Mod);
        }
    }
}
