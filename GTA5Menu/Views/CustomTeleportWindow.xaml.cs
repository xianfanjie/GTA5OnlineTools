using GTA5Menu.Utils;

using GTA5Core.Feature;
using GTA5Core.RAGE.Teleports;
using GTA5Shared.Helper;

namespace GTA5Menu.Views;

/// <summary>
/// CustomTeleportWindow.xaml 的交互逻辑
/// </summary>
public partial class CustomTeleportWindow
{
    /// <summary>
    /// 坐标微调距离
    /// </summary>
    private float Move_Distance = 1.5f;

    public CustomTeleportWindow()
    {
        InitializeComponent();
    }

    private void Window_CustomTeleport_Loaded(object sender, RoutedEventArgs e)
    {
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
            List<TeleportData.TeleportInfo> teleportInfos = JsonHelper.JsonDese<List<TeleportData.TeleportInfo>>(streamReader.ReadToEnd());

            TeleportData.Custom.Clear();
            foreach (var info in teleportInfos)
            {
                TeleportData.Custom.Add(info);
                ListBox_TeleportInfos.Items.Add(info);
            }
        }
    }

    private void Window_CustomTeleport_Closing(object sender, CancelEventArgs e)
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
            TeleportData.Custom.Clear();
            foreach (TeleportData.TeleportInfo info in ListBox_TeleportInfos.Items)
            {
                TeleportData.Custom.Add(info);
            }
            // 写入到Json文件
            File.WriteAllText(GTA5Util.File_Config_Teleports, JsonHelper.JsonSeri(TeleportData.Custom));
        }
    }

    private void UpdateCustonTeleportList()
    {
        ListBox_TeleportInfos.Items.Clear();
        foreach (var item in TeleportData.Custom)
        {
            ListBox_TeleportInfos.Items.Add(item);
        }
    }

    private void Button_AddCustomTeleport_Click(object sender, RoutedEventArgs e)
    {
        var vector3 = Teleport.GetPlayerPosition();

        TeleportData.Custom.Add(new TeleportData.TeleportInfo()
        {
            Name = $"保存点 : {DateTime.Now:yyyyMMdd_HHmmss_ffff}",
            X = vector3.X,
            Y = vector3.Y,
            Z = vector3.Z
        });

        UpdateCustonTeleportList();

        ListBox_TeleportInfos.SelectedIndex = ListBox_TeleportInfos.Items.Count - 1;
    }

    private void Button_EditCustomTeleport_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var tempName = TextBox_CustomName.Text.Trim();
            var tempX = TextBox_Position_X.Text.Trim();
            var tempY = TextBox_Position_Y.Text.Trim();
            var tempZ = TextBox_Position_Z.Text.Trim();

            if (string.IsNullOrEmpty(tempName) ||
                string.IsNullOrEmpty(tempX) ||
                string.IsNullOrEmpty(tempY) ||
                string.IsNullOrEmpty(tempZ))
            {
                NotifierHelper.Show(NotifierType.Warning, "部分坐标数据不能为空");
                return;
            }

            var index = ListBox_TeleportInfos.SelectedIndex;
            if (index != -1)
            {
                TeleportData.Custom[index].Name = tempName;

                TeleportData.Custom[index].X = Convert.ToSingle(tempX);
                TeleportData.Custom[index].Y = Convert.ToSingle(tempY);
                TeleportData.Custom[index].Z = Convert.ToSingle(tempZ);

                UpdateCustonTeleportList();

                ListBox_TeleportInfos.SelectedIndex = index;
            }
            else
            {
                NotifierHelper.Show(NotifierType.Warning, "当前自定义传送坐标选中项为空");
            }
        }
        catch (Exception ex)
        {
            NotifierHelper.ShowException(ex);
        }
    }

    private void Button_DeleteCustomTeleport_Click(object sender, RoutedEventArgs e)
    {
        var index = ListBox_TeleportInfos.SelectedIndex;
        if (index != -1)
        {
            TeleportData.Custom.RemoveAt(index);

            UpdateCustonTeleportList();
        }
        else
        {
            NotifierHelper.Show(NotifierType.Warning, "当前自定义传送坐标选中项为空");
        }
    }

    private void ListBox_TeleportInfo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        Button_Teleport_Click(null, null);
    }

    private void Button_Teleport_Click(object sender, RoutedEventArgs e)
    {
        var index = ListBox_TeleportInfos.SelectedIndex;
        if (index != -1)
        {
            var position = TeleportData.Custom[index];
            Teleport.SetTeleportPosition(new()
            {
                X = position.X,
                Y = position.Y,
                Z = position.Z
            });
        }
    }

    private void Button_SaveCustomTeleport_Click(object sender, RoutedEventArgs e)
    {
        SaveConfig();

        NotifierHelper.Show(NotifierType.Success, $"保存到自定义传送坐标文件成功");
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
}
