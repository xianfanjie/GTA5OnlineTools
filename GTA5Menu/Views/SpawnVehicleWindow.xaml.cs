using GTA5Menu.Data;

using GTA5Core.Feature;
using GTA5Core.RAGE;
using GTA5Core.RAGE.Vehicles;

namespace GTA5Menu.Views;

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
        foreach (var vClass in VehicleHash.VehicleClasses)
        {
            ListBox_VehicleClasses.Items.Add(new IconMenu()
            {
                Icon = vClass.Icon,
                Title = vClass.Name
            });
        }
        ListBox_VehicleClasses.SelectedIndex = 0;

        // 主色调
        foreach (var color in VehicleColor.Colors)
        {
            ComboBox_Primary.Items.Add(color.Name);
        }
        ComboBox_Primary.SelectedIndex = 0;

        // 副色调
        foreach (var color in VehicleColor.Colors)
        {
            ComboBox_Secondary.Items.Add(color.Name);
        }
        ComboBox_Secondary.SelectedIndex = 0;

        // 珠光色
        foreach (var color in VehicleColor.Colors)
        {
            ComboBox_Pearlescent.Items.Add(color.Name);
        }
        ComboBox_Pearlescent.SelectedIndex = 0;

        // 大灯颜色
        foreach (var color in VehicleColor.Lights)
        {
            ComboBox_ColoredLight.Items.Add(color.Name);
        }
        ComboBox_ColoredLight.SelectedIndex = 0;

        // 喇叭
        foreach (var color in VehicleColor.Horns)
        {
            ComboBox_Horn.Items.Add(color.Name);
        }
        ComboBox_Horn.SelectedIndex = 0;

        ///////////////////////////////////////////////

        // 车轮类型
        foreach (var wClass in VehicleWheel.WheelClasses)
        {
            ComboBox_WheelType.Items.Add(wClass.Name);
        }
        ComboBox_WheelType.SelectedIndex = 0;

        // 车轮颜色
        foreach (var color in VehicleColor.Colors)
        {
            ComboBox_WheelColor.Items.Add(color.Name);
        }
        ComboBox_WheelColor.SelectedIndex = 0;

        // 班尼车轮
        foreach (var color in VehicleColor.Bennys)
        {
            ComboBox_BennyWheel.Items.Add(color.Name);
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
                                Image = RAGEHelper.GetVehicleImage(item.Value)
                            });
                        }
                    });
                }
            });

            ListBox_VehicleInfo.SelectedIndex = 0;
        }
    }

    private void Button_SpawnOnlineVehicleA_Click(object sender, RoutedEventArgs e)
    {
        if (ListBox_VehicleInfo.SelectedItem is ModelInfo info)
        {
            Vehicle2.SpawnVehicle(info.Value, -255.0f, 5, 0);
        }
    }

    private void Button_SpawnOnlineVehicleB_Click(object sender, RoutedEventArgs e)
    {
        if (ListBox_VehicleInfo.SelectedItem is ModelInfo info)
        {
            Vehicle2.SpawnVehicle(info.Value, 0.0f, 5, 0);
        }
    }
}
