using GTA5Menu.Data;

using GTA5Core.GTA;
using GTA5Core.GTA.Vehicles;
using GTA5Core.Features;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.OnlineVehicle;

/// <summary>
/// FindVehicleView.xaml 的交互逻辑
/// </summary>
public partial class FindVehicleView : UserControl
{
    public List<ModelInfo> AllVehicles { get; set; } = new();
    public ObservableCollection<ModelInfo> FindVehicles { get; set; } = new();

    public FindVehicleView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;

        // 填充全部载具
        foreach (var info in VehicleHash.AllVehicles)
        {
            AllVehicles.Add(new()
            {
                Class = info.Class,
                Name = info.Name,
                Value = info.Value,
                Image = info.Image,
                Mod = info.Mods
            });
        }
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {

    }

    /////////////////////////////////////////////////

    private void FindVehiclesByModeName()
    {
        if (FindVehicles.Count != 0)
            FindVehicles.Clear();

        var name = TextBox_ModelName.Text;
        if (string.IsNullOrWhiteSpace(name))
            return;

        var result = AllVehicles.FindAll(v => v.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase));
        if (result.Count == 0)
            return;

        result.ForEach(v => FindVehicles.Add(v));
    }

    private void TextBox_ModelName_TextChanged(object sender, TextChangedEventArgs e)
    {
        FindVehiclesByModeName();
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

    private void MenuItem_AddMyFavorite_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (ListBox_VehicleInfo.SelectedItem is ModelInfo info)
        {
            MyVehicleView.ActionAddMyFavorite(info);
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
