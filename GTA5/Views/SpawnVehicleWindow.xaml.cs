using GTA5.Data;

using GTA5Core.RAGE;
using GTA5Core.RAGE.Vehicles;

namespace GTA5.Views;

/// <summary>
/// SpawnVehicleWindow.xaml 的交互逻辑
/// </summary>
public partial class SpawnVehicleWindow
{
    public SpawnVehicleWindow()
    {
        InitializeComponent();
    }

    private void Window_SpawnVehicle_Loaded(object sender, RoutedEventArgs e)
    {
        // 载具分类列表
        foreach (var vTypes in VehicleHash.VehicleTypes)
        {
            ListBox_VehicleTypes.Items.Add(new IconMenu()
            {
                Icon = "\xe610",
                Title = vTypes.Key
            });
        }
        ListBox_VehicleTypes.SelectedIndex = 0;

        // 主色调
        foreach (var color in VehicleColor.Colors)
        {
            ComboBox_Primary.Items.Add(color.Value);
        }
        ComboBox_Primary.SelectedIndex = 0;

        // 副色调
        foreach (var color in VehicleColor.Colors)
        {
            ComboBox_Secondary.Items.Add(color.Value);
        }
        ComboBox_Secondary.SelectedIndex = 0;

        // 珠光色
        foreach (var color in VehicleColor.Colors)
        {
            ComboBox_Pearlescent.Items.Add(color.Value);
        }
        ComboBox_Pearlescent.SelectedIndex = 0;

        // 大灯颜色
        foreach (var color in VehicleColor.Lights)
        {
            ComboBox_ColoredLight.Items.Add(color.Value);
        }
        ComboBox_ColoredLight.SelectedIndex = 0;

        // 喇叭
        foreach (var color in VehicleColor.Horns)
        {
            ComboBox_Horn.Items.Add(color.Value);
        }
        ComboBox_Horn.SelectedIndex = 0;

        ///////////////////////////////////////////////

        // 车轮类型
        foreach (var wheel in VehicleWheel.WheelTypes)
        {
            ComboBox_WheelType.Items.Add(wheel.Key);
        }
        ComboBox_WheelType.SelectedIndex = 0;

        // 车轮颜色
        foreach (var color in VehicleColor.Colors)
        {
            ComboBox_WheelColor.Items.Add(color.Value);
        }
        ComboBox_WheelColor.SelectedIndex = 0;

        // 班尼车轮
        foreach (var color in VehicleColor.Bennys)
        {
            ComboBox_BennyWheel.Items.Add(color.Value);
        }
        ComboBox_BennyWheel.SelectedIndex = 0;
    }

    private void Window_SpawnVehicle_Closing(object sender, CancelEventArgs e)
    {

    }

    private void ListBox_VehicleTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        lock (this)
        {
            var index = ListBox_VehicleTypes.SelectedIndex;
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
                            if (index == ListBox_VehicleTypes.SelectedIndex)
                            {
                                ListBox_VehicleInfo.Items.Add(new VehicleInfo()
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
        if (ListBox_VehicleInfo.SelectedItem is VehicleInfo info)
        {
            //Vehicle.SpawnVehicle(RAGEHelper.JOAAT(model.Name), -255.0f, 5);
            //Vehicle.SpawnVehicle(vehicleSpawn.VehicleHash, -255.0f);
        }
    }

    private void Button_SpawnOnlineVehicleB_Click(object sender, RoutedEventArgs e)
    {
        if (ListBox_VehicleInfo.SelectedItem is VehicleInfo info)
        {
            //Vehicle.SpawnVehicle(vehicleSpawn.VehicleHash, -255.0f, 5);
            //Vehicle.SpawnVehicle(vehicleSpawn.VehicleHash, -255.0f);
        }
    }
}
