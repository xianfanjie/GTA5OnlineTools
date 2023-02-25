using GTA5Menu.Data;
using GTA5Menu.Utils;

using GTA5Core.Feature;
using GTA5Core.RAGE.Onlines;
using GTA5Core.RAGE.Teleports;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.ExternalMenu;

/// <summary>
/// WorldFunctionView.xaml 的交互逻辑
/// </summary>
public partial class WorldFunctionView : UserControl
{
    /// <summary>
    /// 坐标微调距离
    /// </summary>
    private float Move_Distance = 1.5f;

    public WorldFunctionView()
    {
        InitializeComponent();
        this.DataContext = this;
        ExternalMenuWindow.WindowClosingEvent += ExternalMenuWindow_WindowClosingEvent;

        // 如果配置文件存在就读取
        if (File.Exists(GTA5Util.File_Config_Teleports))
        {
            using var streamReader = new StreamReader(GTA5Util.File_Config_Teleports);
            var teleportInfos = JsonHelper.JsonDese<List<TeleportData.TeleportInfo>>(streamReader.ReadToEnd());

            TeleportData.Custom.Clear();
            foreach (var info in teleportInfos)
            {
                TeleportData.Custom.Add(info);
            }
        }

        // 加载传送分类目录
        foreach (var item in TeleportData.TeleportClasses)
        {
            ComboBox_TeleportClass.Items.Add(new IconMenu()
            {
                Icon = item.Icon,
                Title = item.Name
            });
        }
        ComboBox_TeleportClass.SelectedIndex = 0;
    }

    private void ExternalMenuWindow_WindowClosingEvent()
    {

    }

    private void Button_LocalWeather_Click(object sender, RoutedEventArgs e)
    {
        var btnContent = (e.OriginalSource as Button).Content.ToString();
        var index = OnlineData.LocalWeathers.FindIndex(t => t.Name == btnContent);
        if (index != -1)
        {
            World.SetLocalWeather(OnlineData.LocalWeathers[index].Value);
        }
    }

    private void Button_KillNPC_Click(object sender, RoutedEventArgs e)
    {
        World.KillAllNPC(false);
    }

    private void Button_KillAllHostilityNPC_Click(object sender, RoutedEventArgs e)
    {
        World.KillAllNPC(true);
    }

    private void Button_KillAllPolice_Click(object sender, RoutedEventArgs e)
    {
        World.KillAllPolice();
    }

    private void Button_DestroyAllVehicles_Click(object sender, RoutedEventArgs e)
    {
        World.DestroyAllVehicles();
    }

    private void Button_DestroyAllNPCVehicles_Click(object sender, RoutedEventArgs e)
    {
        World.DestroyAllNPCVehicles(false);
    }

    private void Button_DestroyAllHostilityNPCVehicles_Click(object sender, RoutedEventArgs e)
    {
        World.DestroyAllNPCVehicles(true);
    }

    private void Button_TPAllNPCToMe_Click(object sender, RoutedEventArgs e)
    {
        World.TeleportAllNPCToMe(false);
    }

    private void Button_TPHostilityNPCToMe_Click(object sender, RoutedEventArgs e)
    {
        World.TeleportAllNPCToMe(true);
    }

    /////////////////////////////////////////////////////////////////////////////

    private void Button_ToWaypoint_Click(object sender, RoutedEventArgs e)
    {
        Teleport.ToWaypoint();
    }

    private void Button_ToObjective_Click(object sender, RoutedEventArgs e)
    {
        Teleport.ToObjective();
    }

    #region 自定义传送
    private void ComboBox_TeleportClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var index = ComboBox_TeleportClass.SelectedIndex;
        if (index != -1)
        {
            ListBox_TeleportInfos.Items.Clear();

            foreach (var item in TeleportData.TeleportClasses[index].TeleportInfos)
            {
                ListBox_TeleportInfos.Items.Add(item);
            }

            ListBox_TeleportInfos.SelectedIndex = 0;
        }
    }

    private void Button_Teleport_Click(object sender, RoutedEventArgs e)
    {
        var index1 = ComboBox_TeleportClass.SelectedIndex;
        var index2 = ListBox_TeleportInfos.SelectedIndex;
        if (index1 != -1 && index2 != -1)
        {
            var position = TeleportData.TeleportClasses[index1].TeleportInfos[index2];
            Teleport.SetTeleportPosition(new()
            {
                X = position.X,
                Y = position.Y,
                Z = position.Z
            });
        }
    }

    private void ListBox_TeleportInfo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        Button_Teleport_Click(null, null);
    }

    /////////////////////////////////////////////////////////////////////////////

    private void Slider_MoveDistance_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        Move_Distance = (float)Slider_MoveDistance.Value;
    }

    private void Button_MoveDistance_Click(object sender, RoutedEventArgs e)
    {
        var btnContent = (e.OriginalSource as Button).Content.ToString();
        switch (btnContent)
        {
            case "向前":
                Teleport.MoveFoward(Move_Distance);
                break;
            case "向后":
                Teleport.MoveBack(Move_Distance);
                break;
            case "向左":
                Teleport.MoveLeft(Move_Distance);
                break;
            case "向右":
                Teleport.MoveRight(Move_Distance);
                break;
            case "向上":
                Teleport.MoveUp(Move_Distance);
                break;
            case "向下":
                Teleport.MoveDown(Move_Distance);
                break;
        }
    }
    #endregion
}
