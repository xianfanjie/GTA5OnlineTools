using GTA5Menu.Data;
using GTA5Menu.Utils;
using GTA5Menu.Config;

using GTA5Core.RAGE;
using GTA5Core.RAGE.Peds;
using GTA5Core.Feature;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.ExternalMenu;

/// <summary>
/// OtherMiscView.xaml 的交互逻辑
/// </summary>
public partial class OtherMiscView : UserControl
{
    private readonly List<PerVehInfo> PerVehInfos = new();

    public List<BlipInfo2> MyFavorites { get; private set; } = new();

    public OtherMiscView()
    {
        InitializeComponent();
        this.DataContext = this;
        ExternalMenuWindow.WindowClosingEvent += ExternalMenuWindow_WindowClosingEvent;

        // Ped列表
        foreach (var item in PedHash.PedHashData)
        {
            ListBox_PedModel.Items.Add(item.Name);
        }
        ListBox_PedModel.SelectedIndex = 0;

        // 如果配置文件存在就读取
        if (File.Exists(GTA5Util.File_Config_Blips))
        {
            using var streamReader = new StreamReader(GTA5Util.File_Config_Blips);
            var blips = JsonHelper.JsonDese<List<Blips>>(streamReader.ReadToEnd());

            // 填充数据
            foreach (var info in blips)
            {
                MyFavorites.Add(new()
                {
                    Value = info.Value,
                    Color = info.Color,
                    Image = RAGEHelper.GetBlipModelImage(info.Value),
                    Image2 = RAGEHelper.GetBlipColorImage(info.Color)
                });
            }
        }
    }

    private void ExternalMenuWindow_WindowClosingEvent()
    {

    }

    private void Button_RefushPersonalVehicleList_Click(object sender, RoutedEventArgs e)
    {
        lock (this)
        {
            ListBox_PersonalVehicle.Items.Clear();
            PerVehInfos.Clear();

            Task.Run(() =>
            {
                int max_slots = Hacks.ReadGA<int>(Offsets.oVMSlots);
                for (int i = 0; i < max_slots; i++)
                {
                    long hash = Hacks.ReadGA<long>(Offsets.oVMSlots + 1 + (i * 142) + 66);
                    if (hash == 0)
                        continue;

                    string plate = Hacks.ReadGAString(Offsets.oVMSlots + 1 + (i * 142) + 1);

                    PerVehInfos.Add(new PerVehInfo()
                    {
                        Index = i,
                        Name = Vehicle2.FindVehicleNameByHash(hash),
                        Hash = hash,
                        Plate = plate
                    });
                }

                foreach (var item in PerVehInfos)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        ListBox_PersonalVehicle.Items.Add($"[{item.Plate}]\t{item.Name}");
                    });
                }
            });
        }
    }

    private void Button_SpawnPersonalVehicle_Click(object sender, RoutedEventArgs e)
    {
        var index = ListBox_PersonalVehicle.SelectedIndex;
        if (index != -1)
            Vehicle.RequestPersonalVehicle(PerVehInfos[index].Index);
    }

    private void Button_GetInOnlinePV_Click(object sender, RoutedEventArgs e)
    {
        Online.GetInOnlinePV();
    }

    ////////////////////////////////////////////////////////////////////////////////

    private void Button_ModelChange_Click(object sender, RoutedEventArgs e)
    {
        var index = ListBox_PedModel.SelectedIndex;
        if (index != -1)
            Online.ModelChange(Hacks.Joaat(PedHash.PedHashData[index].Value));
    }

    private void ListBox_PedModel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        Button_ModelChange_Click(null, null);
    }

    ////////////////////////////////////////////////////////////////////////////////

    private void Button_BlipTeleport_Click(object sender, RoutedEventArgs e)
    {
        if (ListBox_BlipModels.SelectedItem is BlipInfo2 info)
        {
            Teleport.ToBlips(info.Value, info.Color);
        }
    }

    private void ListBox_BlipModels_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        Button_BlipTeleport_Click(null, null);
    }
}
