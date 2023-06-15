using GTA5Menu;
using GTA5Menu.Views;
using GTA5Core.Views;
using GTA5Core.Native;
using GTA5Shared.Helper;

using CommunityToolkit.Mvvm.Input;

namespace GTA5OnlineTools.Views;

/// <summary>
/// GTA5View.xaml 的交互逻辑
/// </summary>
public partial class GTA5View : UserControl
{
    private GTA5MenuWindow GTA5MenuWindow = null;

    private SpawnVehicleWindow SpawnVehicleWindow = null;
    private CustomTeleportWindow CustomTeleportWindow = null;
    private StatScriptsWindow StatScriptsWindow = null;
    private SpeedMeterWindow SpeedMeterWindow = null;

    /// <summary>
    /// 关闭全部GTA5窗口委托
    /// </summary>
    public static Action ActionCloseAllGTA5Window;

    public GTA5View()
    {
        InitializeComponent();
        this.DataContext = this;
        MainWindow.WindowClosingEvent += MainWindow_WindowClosingEvent;

        ActionCloseAllGTA5Window = CloseAllGTA5Window;
    }

    private void MainWindow_WindowClosingEvent()
    {

    }

    [RelayCommand]
    private void GTA5ViewClick(string modelName)
    {
        AudioHelper.PlayClickSound();

        if (ProcessHelper.IsGTA5Run())
        {
            // GTA5内存模块初始化窗口
            if (!Memory.IsInitialized)
            {
                var gTA5InitWindow = new GTA5InitWindow
                {
                    Owner = MainWindow.MainWindowInstance
                };
                if (gTA5InitWindow.ShowDialog() == false)
                    return;
            }

            switch (modelName)
            {
                case "ExternalMenu":
                    ExternalMenuClick();
                    break;
                case "SpawnVehicle":
                    SpawnVehicleClick();
                    break;
                case "CustomTeleport":
                    CustomTeleportClick();
                    break;
                case "StatScripts":
                    StatScriptsClick();
                    break;
                case "SpeedMeter":
                    SpeedMeterClick();
                    break;
            }
        }
        else
        {
            NotifierHelper.Show(NotifierType.Warning, "未发现《GTA5》进程，请先运行《GTA5》游戏");
        }
    }

    ///////////////////////////////////////////////////////////////////

    #region 第三方模块按钮点击事件
    private void ExternalMenuClick()
    {
        if (GTA5MenuWindow == null)
        {
            GTA5MenuWindow = new GTA5MenuWindow();
            GTA5MenuWindow.Show();
        }
        else
        {
            if (GTA5MenuWindow.IsVisible)
            {
                if (!GTA5MenuWindow.Topmost)
                {
                    GTA5MenuWindow.Topmost = true;
                    GTA5MenuWindow.Topmost = false;
                }

                GTA5MenuWindow.WindowState = WindowState.Normal;
            }
            else
            {
                GTA5MenuWindow = null;
                GTA5MenuWindow = new GTA5MenuWindow();
                GTA5MenuWindow.Show();
            }
        }
    }

    private void SpawnVehicleClick()
    {
        if (SpawnVehicleWindow == null)
        {
            SpawnVehicleWindow = new SpawnVehicleWindow();
            SpawnVehicleWindow.Show();
        }
        else
        {
            if (SpawnVehicleWindow.IsVisible)
            {
                SpawnVehicleWindow.Topmost = true;
                SpawnVehicleWindow.Topmost = false;
                SpawnVehicleWindow.WindowState = WindowState.Normal;
            }
            else
            {
                SpawnVehicleWindow = null;
                SpawnVehicleWindow = new SpawnVehicleWindow();
                SpawnVehicleWindow.Show();
            }
        }
    }

    private void CustomTeleportClick()
    {
        if (CustomTeleportWindow == null)
        {
            CustomTeleportWindow = new CustomTeleportWindow();
            CustomTeleportWindow.Show();
        }
        else
        {
            if (CustomTeleportWindow.IsVisible)
            {
                CustomTeleportWindow.Topmost = true;
                CustomTeleportWindow.Topmost = false;
                CustomTeleportWindow.WindowState = WindowState.Normal;
            }
            else
            {
                CustomTeleportWindow = null;
                CustomTeleportWindow = new CustomTeleportWindow();
                CustomTeleportWindow.Show();
            }
        }
    }

    private void StatScriptsClick()
    {
        if (StatScriptsWindow == null)
        {
            StatScriptsWindow = new StatScriptsWindow();
            StatScriptsWindow.Show();
        }
        else
        {
            if (StatScriptsWindow.IsVisible)
            {
                StatScriptsWindow.Topmost = true;
                StatScriptsWindow.Topmost = false;
                StatScriptsWindow.WindowState = WindowState.Normal;
            }
            else
            {
                StatScriptsWindow = null;
                StatScriptsWindow = new StatScriptsWindow();
                StatScriptsWindow.Show();
            }
        }
    }

    private void SpeedMeterClick()
    {
        if (SpeedMeterWindow == null)
        {
            SpeedMeterWindow = new SpeedMeterWindow();
            SpeedMeterWindow.Show();
        }
        else
        {
            if (SpeedMeterWindow.IsVisible)
            {
                SpeedMeterWindow.Topmost = true;
                SpeedMeterWindow.Topmost = false;
                SpeedMeterWindow.WindowState = WindowState.Normal;
            }
            else
            {
                SpeedMeterWindow = null;
                SpeedMeterWindow = new SpeedMeterWindow();
                SpeedMeterWindow.Show();
            }
        }
    }
    #endregion

    ///////////////////////////////////////////////////////////////////

    /// <summary>
    /// 关闭全部GTA5窗口
    /// </summary>
    private void CloseAllGTA5Window()
    {
        Memory.CloseHandle();

        this.Dispatcher.Invoke(() =>
        {
            if (GTA5MenuWindow != null)
            {
                GTA5MenuWindow.Close();
                GTA5MenuWindow = null;
            }

            if (SpawnVehicleWindow != null)
            {
                SpawnVehicleWindow.Close();
                SpawnVehicleWindow = null;
            }

            if (StatScriptsWindow != null)
            {
                StatScriptsWindow.Close();
                StatScriptsWindow = null;
            }

            if (SpeedMeterWindow != null)
            {
                SpeedMeterWindow.Close();
                SpeedMeterWindow = null;
            }
        });
    }
}
