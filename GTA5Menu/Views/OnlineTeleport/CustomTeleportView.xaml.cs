using GTA5Menu.Utils;
using GTA5Menu.Config;

using GTA5Core.Features;
using GTA5Core.RAGE.Teleports;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.OnlineTeleport;

/// <summary>
/// CustomTeleportView.xaml 的交互逻辑
/// </summary>
public partial class CustomTeleportView : UserControl
{
    public CustomTeleportView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;

        // 如果配置文件不存在就创建
        if (!File.Exists(GTA5Util.File_Config_Teleports))
        {
            // 保存配置文件
            SaveConfig();
        }

        // 如果配置文件存在就读取
        if (File.Exists(GTA5Util.File_Config_Teleports))
        {
            using var streamReader = new StreamReader(GTA5Util.File_Config_Teleports);
            var teleports = JsonHelper.JsonDese<Teleports>(streamReader.ReadToEnd());

            // 加载读取的配置文件到UI中，由于Json结构不一样，需要转换
            foreach (var custom in teleports.CustomLocations)
            {
                ListBox_Teleports.Items.Add(new TeleportInfo()
                {
                    Name = custom.Name,
                    X = custom.X,
                    Y = custom.Y,
                    Z = custom.Z
                });
            }
        }
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {
        SaveConfig();
    }

    /// <summary>
    /// 保存配置文件
    /// </summary>
    private void SaveConfig()
    {
        if (Directory.Exists(FileHelper.Dir_Config))
        {
            var teleports = new Teleports
            {
                CustomLocations = new()
            };
            // 加载到配置文件
            foreach (TeleportInfo info in ListBox_Teleports.Items)
            {
                teleports.CustomLocations.Add(new()
                {
                    Name = info.Name,
                    X = info.X,
                    Y = info.Y,
                    Z = info.Z,
                    Pitch = 0.0f,
                    Yaw = 0.0f,
                    Roll = 0.0f,
                });
            }
            // 写入到Json文件
            File.WriteAllText(GTA5Util.File_Config_Teleports, JsonHelper.JsonSeri(teleports));
        }
    }

    private void ListBox_Teleports_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        Button_Teleport_Click(null, null);
    }

    private void Button_Teleport_Click(object sender, RoutedEventArgs e)
    {
        if (ListBox_Teleports.SelectedItem is TeleportInfo item)
        {
            Teleport.SetTeleportPosition(new()
            {
                X = item.X,
                Y = item.Y,
                Z = item.Z
            });
        }
        else
        {
            NotifierHelper.Show(NotifierType.Warning, "当前自定义传送坐标选中项为空");
        }
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

    /////////////////////////////////////////////////////////////////////////////

    private void Button_MoveDistance_Click(object sender, RoutedEventArgs e)
    {
        var moveDistance = (float)Slider_MoveDistance.Value;

        var btnContent = (e.OriginalSource as Button).Content.ToString();
        switch (btnContent)
        {
            case "向前":
                Teleport.MoveFoward(moveDistance);
                break;
            case "向后":
                Teleport.MoveBack(moveDistance);
                break;
            case "向左":
                Teleport.MoveLeft(moveDistance);
                break;
            case "向右":
                Teleport.MoveRight(moveDistance);
                break;
            case "向上":
                Teleport.MoveUp(moveDistance);
                break;
            case "向下":
                Teleport.MoveDown(moveDistance);
                break;
        }
    }
}
