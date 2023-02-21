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
        SaveConfig();
    }

    /// <summary>
    /// 保存配置文件
    /// </summary>
    private void SaveConfig()
    {
        if (Directory.Exists(GTA5Util.Dir_Config))
        {
            // 写入到Json文件
            File.WriteAllText(GTA5Util.File_Config_Teleports, JsonHelper.JsonSeri(TeleportData.Custom));
        }
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

    #region 自定义传送
    private void UpdateCustonTeleportList()
    {
        ListBox_TeleportInfos.Items.Clear();

        foreach (var item in TeleportData.TeleportClasses[0].TeleportInfos)
        {
            ListBox_TeleportInfos.Items.Add(item.Name);
        }

        ListBox_TeleportInfos.SelectedIndex = 0;
    }

    private void ComboBox_TeleportClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var index = ComboBox_TeleportClass.SelectedIndex;
        if (index != -1)
        {
            ListBox_TeleportInfos.Items.Clear();

            foreach (var item in TeleportData.TeleportClasses[index].TeleportInfos)
            {
                ListBox_TeleportInfos.Items.Add(item.Name);
            }

            ListBox_TeleportInfos.SelectedIndex = 0;
        }
    }

    private void ListBox_TeleportInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var index1 = ComboBox_TeleportClass.SelectedIndex;
        var index2 = ListBox_TeleportInfos.SelectedIndex;
        if (index1 != -1 && index2 != -1)
        {
            var position = TeleportData.TeleportClasses[index1].TeleportInfos[index2].Position;

            TextBox_CustomTeleportName.Text = TeleportData.TeleportClasses[index1].TeleportInfos[index2].Name;
            TextBox_Position_X.Text = $"{position.X:0.000}";
            TextBox_Position_Y.Text = $"{position.Y:0.000}";
            TextBox_Position_Z.Text = $"{position.Z:0.000}";
        }
        else if (index2 == -1)
        {
            TextBox_CustomTeleportName.Clear();
            TextBox_Position_X.Clear();
            TextBox_Position_Y.Clear();
            TextBox_Position_Z.Clear();
        }
    }

    private void Button_AddCustomTeleport_Click(object sender, RoutedEventArgs e)
    {
        var vector3 = Teleport.GetPlayerPosition();

        TeleportData.Custom.Add(new TeleportData.TeleportInfo()
        {
            Name = $"保存点 : {DateTime.Now:yyyyMMdd_HHmmss_ffff}",
            Position = vector3
        });

        UpdateCustonTeleportList();

        ListBox_TeleportInfos.SelectedIndex = ListBox_TeleportInfos.Items.Count - 1;
    }

    private void Button_EditCustomTeleport_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var tempName = TextBox_CustomTeleportName.Text.Trim();
            var tempX = TextBox_Position_X.Text.Trim();
            var tempY = TextBox_Position_Y.Text.Trim();
            var tempZ = TextBox_Position_Z.Text.Trim();

            if (string.IsNullOrEmpty(tempName) ||
                string.IsNullOrEmpty(tempX) || string.IsNullOrEmpty(tempY) || string.IsNullOrEmpty(tempZ))
            {
                NotifierHelper.Show(NotifierType.Warning, "部分坐标数据不能为空");
                return;
            }

            var index1 = ComboBox_TeleportClass.SelectedIndex;
            var index2 = ListBox_TeleportInfos.SelectedIndex;
            if (index1 == 0 && index2 != -1)
            {
                TeleportData.TeleportClasses[index1].TeleportInfos[index2].Position = new Vector3()
                {
                    X = Convert.ToSingle(tempX),
                    Y = Convert.ToSingle(tempY),
                    Z = Convert.ToSingle(tempZ)
                };

                TeleportData.TeleportClasses[index1].TeleportInfos[index2].Name = tempName;

                UpdateCustonTeleportList();

                ListBox_TeleportInfos.SelectedIndex = index2; ;
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
        var index1 = ComboBox_TeleportClass.SelectedIndex;
        var index2 = ListBox_TeleportInfos.SelectedIndex;
        if (index1 == 0 && index2 != -1)
        {
            TeleportData.TeleportClasses[index1].TeleportInfos.Remove(TeleportData.TeleportClasses[index1].TeleportInfos[index2]);

            UpdateCustonTeleportList();

            ListBox_TeleportInfos.SelectedIndex = ListBox_TeleportInfos.Items.Count - 1;
        }
        else
        {
            NotifierHelper.Show(NotifierType.Warning, "当前自定义传送坐标选中项为空");
        }
    }

    private void Button_ToWaypoint_Click(object sender, RoutedEventArgs e)
    {
        Teleport.ToWaypoint();
    }

    private void Button_ToObjective_Click(object sender, RoutedEventArgs e)
    {
        Teleport.ToObjective();
    }

    private void ListBox_TeleportInfo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        Button_Teleport_Click(null, null);
    }

    private void Button_Teleport_Click(object sender, RoutedEventArgs e)
    {
        var index1 = ComboBox_TeleportClass.SelectedIndex;
        var index2 = ListBox_TeleportInfos.SelectedIndex;
        if (index1 != -1 && index2 != -1)
        {
            var position = TeleportData.TeleportClasses[index1].TeleportInfos[index2].Position;
            Teleport.SetTeleportPosition(position);
        }
    }

    private void Button_SaveCustomTeleport_Click(object sender, RoutedEventArgs e)
    {
        SaveConfig();

        NotifierHelper.Show(NotifierType.Success, $"保存到自定义传送坐标文件成功");
    }

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
