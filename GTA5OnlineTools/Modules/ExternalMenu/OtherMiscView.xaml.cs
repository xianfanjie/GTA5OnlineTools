using GTA5OnlineTools.Helper;
using GTA5OnlineTools.GTA.SDK;
using GTA5OnlineTools.GTA.Core;
using GTA5OnlineTools.GTA.Data;
using GTA5OnlineTools.GTA.Client;

namespace GTA5OnlineTools.Modules.ExternalMenu;

/// <summary>
/// OtherMiscView.xaml 的交互逻辑
/// </summary>
public partial class OtherMiscView : UserControl
{
    private List<PerVehInfo> PerVehInfos = new();

    public OtherMiscView()
    {
        InitializeComponent();
        this.DataContext = this;
        ExternalMenuWindow.WindowClosingEvent += ExternalMenuWindow_WindowClosingEvent;

        // Ped列表
        foreach (var item in PedData.PedDataClass)
        {
            ListBox_PedModel.Items.Add(item.DisplayName);
        }
        ListBox_PedModel.SelectedIndex = 0;

        long pCPlayerInfo = Globals.GetCPlayerInfo();
        TextBox_PlayerName.Text = Memory.ReadString(pCPlayerInfo + Offsets.CPed_CPlayerInfo_Name, 20);
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
                        Name = Vehicle.FindVehicleDisplayName(hash, true),
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
            Online.ModelChange(PedData.PedDataClass[index].Hash);
    }

    private void ListBox_PedModel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        Button_ModelChange_Click(null, null);
    }


    private void Button_ReadPlayerName_Click(object sender, RoutedEventArgs e)
    {


        long pCPlayerInfo = Globals.GetCPlayerInfo();
        TextBox_PlayerName.Text = Memory.ReadString(pCPlayerInfo + Offsets.CPed_CPlayerInfo_Name, 64);
    }

    private void CheckBox_IngnoreInputRule_Click(object sender, RoutedEventArgs e)
    {
        TextBox_PlayerName.MaxLength = CheckBox_IngnoreInputRule.IsChecked == true ? 64 : 20;
    }

    private void Button_WritePlayerName_Click(object sender, RoutedEventArgs e)
    {


        try
        {
            string playerName = TextBox_PlayerName.Text.Trim();
            TextBox_PlayerName.Text = playerName;

            if (CheckBox_IngnoreInputRule.IsChecked == false)
            {
                if (!Regex.IsMatch(playerName, "^[A-Za-z0-9_\\s-]{3,20}$"))
                {
                    NotifierHelper.Show(NotifierType.Warning, "玩家昵称不合法，规则：3到20位（字母，数字，下划线，减号，空格）");
                    return;
                }
            }

            long pCPlayerInfo = Globals.GetCPlayerInfo();
            string name = Memory.ReadString(pCPlayerInfo + Offsets.CPed_CPlayerInfo_Name, 64);

            if (playerName.Equals(name))
            {
                NotifierHelper.Show(NotifierType.Information, "玩家昵称未改动，无需修改");
                return;
            }

            playerName += "\0";

            var pointers = Memory.FindPatterns(name);
            foreach (var item in pointers)
            {
                Memory.WriteString(item, playerName);
            }

            Memory.WriteString(pCPlayerInfo + Offsets.CPed_CPlayerInfo_Name, playerName);

            NotifierHelper.Show(NotifierType.Success, "修改玩家昵称成功，切换战局生效");
        }
        catch (Exception ex)
        {
            NotifierHelper.ShowException(ex);
        }
    }
}
