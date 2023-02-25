using GTA5Menu.Data;
using GTA5Menu.Utils;

using GTA5Core.RAGE;
using GTA5Core.RAGE.Vehicles;
using GTA5Core.Feature;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.SpawnVehicle;

/// <summary>
/// MyVehicleView.xaml 的交互逻辑
/// </summary>
public partial class MyVehicleView : UserControl
{
    public ObservableCollection<ModelInfo> MyFavorites { get; private set; } = new();

    private List<VehicleData> MyVehicles = new();

    public static Action<ModelInfo> ActionAddMyFavorite;

    public MyVehicleView()
    {
        InitializeComponent();
        this.DataContext = this;
        SpawnVehicleWindow.WindowClosingEvent += SpawnVehicleWindow_WindowClosingEvent;

        ActionAddMyFavorite = AddMyFavorite;

        // 如果配置文件不存在就创建
        if (!File.Exists(GTA5Util.File_Config_Vehicles))
        {
            // 保存配置文件
            SaveConfig();
        }

        // 如果配置文件存在就读取
        if (File.Exists(GTA5Util.File_Config_Vehicles))
        {
            using var streamReader = new StreamReader(GTA5Util.File_Config_Vehicles);
            MyVehicles = JsonHelper.JsonDese<List<VehicleData>>(streamReader.ReadToEnd());
        }

        // 填充数据
        foreach (var item in MyVehicles)
        {
            var classes = VehicleHash.VehicleClasses.Find(v => v.Name == item.Class);
            if (classes != null)
            {
                var info = classes.VehicleInfos.Find(v => v.Value == item.Value);
                if (info != null)
                {
                    MyFavorites.Add(new()
                    {
                        Class = classes.Name,
                        Name = info.Name,
                        Value = info.Value,
                        Image = RAGEHelper.GetVehicleImage(info.Value),
                        Mod = info.Mod
                    });
                    continue;
                }
            }
        }
    }

    private void SpawnVehicleWindow_WindowClosingEvent()
    {
        SaveConfig();
    }

    /// <summary>
    /// 保存配置文件
    /// </summary>
    private void SaveConfig()
    {
        if (Directory.Exists(GTA5Util.Dir_Config))
        {
            MyVehicles.Clear();
            foreach (ModelInfo info in ListBox_VehicleInfo.Items)
            {
                MyVehicles.Add(new()
                {
                    Class = info.Class,
                    Name = info.Name,
                    Value = info.Value,
                });
            }
            // 写入到Json文件
            File.WriteAllText(GTA5Util.File_Config_Vehicles, JsonHelper.JsonSeri(MyVehicles));
        }
    }

    private void AddMyFavorite(ModelInfo model)
    {
        if (!MyFavorites.Contains(model))
        {
            MyFavorites.Add(model);
            MyVehicles.Add(new()
            {
                Class = model.Class,
                Name = model.Name,
                Value = model.Value,
            });

            NotifierHelper.Show(NotifierType.Success, $"添加载具 {model.Name} 到我的收藏成功");
        }
        else
        {
            NotifierHelper.Show(NotifierType.Warning, $"载具 {model.Name} 已存在，请勿重复添加");
        }
    }

    private async void MenuItem_SpawnVehicleA_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (ListBox_VehicleInfo.SelectedItem is ModelInfo info)
        {
            await Vehicle2.SpawnVehicle(info.Value, -255.0f, 5, info.Mod);
        }
        else
        {
            NotifierHelper.Show(NotifierType.Warning, "请选择正确的载具，操作取消");
        }
    }

    private async void MenuItem_SpawnVehicleB_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (ListBox_VehicleInfo.SelectedItem is ModelInfo info)
        {
            await Vehicle2.SpawnVehicle(info.Value, 0.0f, 5, info.Mod);
        }
        else
        {
            NotifierHelper.Show(NotifierType.Warning, "请选择正确的载具，操作取消");
        }
    }

    private void MenuItem_DeleteMyFavorite_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (ListBox_VehicleInfo.SelectedItem is ModelInfo info)
        {
            MyFavorites.Remove(info);
            MyVehicles.Remove(MyVehicles.Find(v => v.Value == info.Value));

            NotifierHelper.Show(NotifierType.Success, $"从我的收藏删除载具 {info.Name} 成功");
        }
        else
        {
            NotifierHelper.Show(NotifierType.Warning, "请选择正确的载具，操作取消");
        }
    }

    private void ListBox_VehicleInfo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        MenuItem_SpawnVehicleA_Click(null, null);
    }
}
