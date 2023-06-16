using GTA5Menu.Data;
using GTA5Menu.Utils;
using GTA5Menu.Config;

using GTA5Core.RAGE;
using GTA5Core.RAGE.Vehicles;
using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.ExternalMenu;

/// <summary>
/// SpawnVehicleView.xaml 的交互逻辑
/// </summary>
public partial class SpawnVehicleView : UserControl
{
    public SpawnVehicleView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += ExternalMenuWindow_WindowClosingEvent;

        // 如果配置文件存在就读取
        if (File.Exists(GTA5Util.File_Config_Vehicles))
        {
            using var streamReader = new StreamReader(GTA5Util.File_Config_Vehicles);
            var vehicles = JsonHelper.JsonDese<List<Vehicles>>(streamReader.ReadToEnd());

            // 清理缓存
            VehicleHash.Favorites.Clear();

            // 填充数据
            foreach (var item in vehicles)
            {
                var classes = VehicleHash.VehicleClasses.Find(v => v.Name == item.Class);
                if (classes != null)
                {
                    var info = classes.VehicleInfos.Find(v => v.Value == item.Value);
                    if (info != null)
                    {
                        VehicleHash.Favorites.Add(new()
                        {
                            Name = info.Name,
                            Value = info.Value,
                            Mod = info.Mod
                        });
                        continue;
                    }
                }
            }
        }

        // 载具列表
        foreach (var vClass in VehicleHash.VehicleClasses)
        {
            ComboBox_VehicleClasses.Items.Add(new IconMenu()
            {
                Icon = vClass.Icon,
                Title = vClass.Name
            });
        }
        ComboBox_VehicleClasses.SelectedIndex = 0;
    }

    private void ExternalMenuWindow_WindowClosingEvent()
    {

    }

    /////////////////////////////////////////////////

    private void ComboBox_VehicleClasses_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        lock (this)
        {
            var index = ComboBox_VehicleClasses.SelectedIndex;
            if (index == -1)
                return;

            ListBox_VehicleInfo.Items.Clear();

            Task.Run(() =>
            {
                foreach (var item in VehicleHash.VehicleClasses[index].VehicleInfos)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        if (index == ComboBox_VehicleClasses.SelectedIndex)
                        {
                            ListBox_VehicleInfo.Items.Add(new ModelInfo()
                            {
                                Class = VehicleHash.VehicleClasses[index].Name,
                                Name = item.Name,
                                Value = item.Value,
                                Image = RAGEHelper.GetVehicleImage(item.Value),
                                Mod = item.Mod
                            });
                        }
                        else
                        {
                            return;
                        }
                    });
                }
            });

            ListBox_VehicleInfo.SelectedIndex = 0;
        }
    }

    private async void Button_SpawnOnlineVehicleA_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (ListBox_VehicleInfo.SelectedItem is ModelInfo info)
        {
            await Vehicle2.SpawnVehicle(info.Value, -255.0f, 5, info.Mod);
        }
    }

    private async void Button_SpawnOnlineVehicleB_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (ListBox_VehicleInfo.SelectedItem is ModelInfo info)
        {
            await Vehicle2.SpawnVehicle(info.Value, 0.0f, 5, info.Mod);
        }
    }

    private void ListBox_VehicleInfo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        Button_SpawnOnlineVehicleA_Click(null, null);
    }
}
