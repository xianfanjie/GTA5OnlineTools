using GTA5OnlineTools.Utils;

using GTA5.Views;
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
    private ExternalMenuWindow ExternalMenuWindow = null;
    private SpawnVehicleWindow SpawnVehicleWindow = null;
    private HeistsEditWindow HeistsEditWindow = null;
    private OutfitsEditWindow OutfitsEditWindow = null;
    private StatScriptsWindow StatScriptsWindow = null;
    private SessionChatWindow SessionChatWindow = null;
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
        if (ProcessUtil.IsGTA5Run())
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
                case "HeistsEdit":
                    HeistsEditClick();
                    break;
                case "OutfitsEdit":
                    OutfitsEditClick();
                    break;
                case "StatScripts":
                    StatScriptsClick();
                    break;
                case "SessionChat":
                    SessionChatClick();
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
        if (ExternalMenuWindow == null)
        {
            ExternalMenuWindow = new ExternalMenuWindow();
            ExternalMenuWindow.Owner = MainWindow.MainWindowInstance;
            ExternalMenuWindow.Show();
        }
        else
        {
            if (ExternalMenuWindow.IsVisible)
            {
                if (!ExternalMenuWindow.Topmost)
                {
                    ExternalMenuWindow.Topmost = true;
                    ExternalMenuWindow.Topmost = false;
                }

                ExternalMenuWindow.WindowState = WindowState.Normal;
            }
            else
            {
                ExternalMenuWindow = null;
                ExternalMenuWindow = new ExternalMenuWindow();
                ExternalMenuWindow.Owner = MainWindow.MainWindowInstance;
                ExternalMenuWindow.Show();
            }
        }
    }

    private void SpawnVehicleClick()
    {
        if (SpawnVehicleWindow == null)
        {
            SpawnVehicleWindow = new SpawnVehicleWindow();
            SpawnVehicleWindow.Owner = MainWindow.MainWindowInstance;
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
                SpawnVehicleWindow.Owner = MainWindow.MainWindowInstance;
                SpawnVehicleWindow.Show();
            }
        }
    }

    private void HeistsEditClick()
    {
        if (HeistsEditWindow == null)
        {
            HeistsEditWindow = new HeistsEditWindow();
            HeistsEditWindow.Owner = MainWindow.MainWindowInstance;
            HeistsEditWindow.Show();
        }
        else
        {
            if (HeistsEditWindow.IsVisible)
            {
                HeistsEditWindow.Topmost = true;
                HeistsEditWindow.Topmost = false;
                HeistsEditWindow.WindowState = WindowState.Normal;
            }
            else
            {
                HeistsEditWindow = null;
                HeistsEditWindow = new HeistsEditWindow();
                HeistsEditWindow.Owner = MainWindow.MainWindowInstance;
                HeistsEditWindow.Show();
            }
        }
    }

    private void OutfitsEditClick()
    {
        if (OutfitsEditWindow == null)
        {
            OutfitsEditWindow = new OutfitsEditWindow();
            OutfitsEditWindow.Owner = MainWindow.MainWindowInstance;
            OutfitsEditWindow.Show();
        }
        else
        {
            if (OutfitsEditWindow.IsVisible)
            {
                OutfitsEditWindow.Topmost = true;
                OutfitsEditWindow.Topmost = false;
                OutfitsEditWindow.WindowState = WindowState.Normal;
            }
            else
            {
                OutfitsEditWindow = null;
                OutfitsEditWindow = new OutfitsEditWindow();
                OutfitsEditWindow.Owner = MainWindow.MainWindowInstance;
                OutfitsEditWindow.Show();
            }
        }
    }

    private void StatScriptsClick()
    {
        if (StatScriptsWindow == null)
        {
            StatScriptsWindow = new StatScriptsWindow();
            StatScriptsWindow.Owner = MainWindow.MainWindowInstance;
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
                StatScriptsWindow.Owner = MainWindow.MainWindowInstance;
                StatScriptsWindow.Show();
            }
        }
    }

    private void SessionChatClick()
    {
        if (SessionChatWindow == null)
        {
            SessionChatWindow = new SessionChatWindow();
            SessionChatWindow.Owner = MainWindow.MainWindowInstance;
            SessionChatWindow.Show();
        }
        else
        {
            if (SessionChatWindow.IsVisible)
            {
                SessionChatWindow.Topmost = true;
                SessionChatWindow.Topmost = false;
                SessionChatWindow.WindowState = WindowState.Normal;
            }
            else
            {
                SessionChatWindow = null;
                SessionChatWindow = new SessionChatWindow();
                SessionChatWindow.Owner = MainWindow.MainWindowInstance;
                SessionChatWindow.Show();
            }
        }
    }

    private void SpeedMeterClick()
    {
        if (SpeedMeterWindow == null)
        {
            SpeedMeterWindow = new SpeedMeterWindow();
            SpeedMeterWindow.Owner = MainWindow.MainWindowInstance;
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
                SpeedMeterWindow.Owner = MainWindow.MainWindowInstance;
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
            if (ExternalMenuWindow != null)
            {
                ExternalMenuWindow.Close();
                ExternalMenuWindow = null;
            }

            if (SpawnVehicleWindow != null)
            {
                SpawnVehicleWindow.Close();
                SpawnVehicleWindow = null;
            }

            if (HeistsEditWindow != null)
            {
                HeistsEditWindow.Close();
                HeistsEditWindow = null;
            }

            if (OutfitsEditWindow != null)
            {
                OutfitsEditWindow.Close();
                OutfitsEditWindow = null;
            }

            if (StatScriptsWindow != null)
            {
                StatScriptsWindow.Close();
                StatScriptsWindow = null;
            }

            if (SessionChatWindow != null)
            {
                SessionChatWindow.Close();
                SessionChatWindow = null;
            }

            if (SpeedMeterWindow != null)
            {
                SpeedMeterWindow.Close();
                SpeedMeterWindow = null;
            }
        });
    }
}
