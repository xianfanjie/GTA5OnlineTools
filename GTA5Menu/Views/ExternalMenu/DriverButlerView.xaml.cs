using GTA5Menu.Data;

using GTA5Core.Feature;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.ExternalMenu;

/// <summary>
/// DriverButlerView.xaml 的交互逻辑
/// </summary>
public partial class DriverButlerView : UserControl
{
    public ObservableCollection<PerVehInfo> PerVehInfos { get; set; } = new();

    public DriverButlerView()
    {
        InitializeComponent();
        this.DataContext = this;
        ExternalMenuWindow.WindowClosingEvent += ExternalMenuWindow_WindowClosingEvent;
    }

    private void ExternalMenuWindow_WindowClosingEvent()
    {

    }

    private async void Button_RefushPersonalVehicleList_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        PerVehInfos.Clear();

        await Task.Run(() =>
        {
            int max_slots = Hacks.ReadGA<int>(Offsets.oVMSlots);
            for (int i = 0; i < max_slots; i++)
            {
                long hash = Hacks.ReadGA<long>(Offsets.oVMSlots + 1 + (i * 142) + 66);
                if (hash == 0)
                    continue;

                string plate = Hacks.ReadGAString(Offsets.oVMSlots + 1 + (i * 142) + 1);

                var vInfo = Vehicle2.FindVehicleNameByHash(hash);
                if (vInfo == null)
                    continue;

                this.Dispatcher.Invoke(() =>
                {
                    PerVehInfos.Add(new()
                    {
                        Index = i,
                        Name = vInfo.Name,
                        Hash = hash,
                        Plate = plate,
                        Image = vInfo.Image
                    });
                });
            }
        });
    }

    private void Button_SpawnPersonalVehicle_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (ListBox_PersonalVehicle.SelectedItem is PerVehInfo info)
            Vehicle.RequestPersonalVehicle(info.Index);
    }

    private void Button_GetInOnlinePV_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        Online.GetInOnlinePV();
    }

    private void ListBox_PersonalVehicle_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        Button_SpawnPersonalVehicle_Click(null,null);
    }
}
