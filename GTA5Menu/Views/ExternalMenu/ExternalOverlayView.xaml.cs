using GTA5HotKey;
using GTA5Overlay;
using GTA5Core.Native;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.ExternalMenu;

/// <summary>
/// ExternalOverlayView.xaml 的交互逻辑
/// </summary>
public partial class ExternalOverlayView : UserControl
{
    private Overlay overlay;

    public ExternalOverlayView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent; ;
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {
        CloseESP();
    }

    /////////////////////////////////////////////////

    private void Button_Overaly_Run_Click(object sender, RoutedEventArgs e)
    {
        if (overlay == null)
        {
            GameOverlay.TimerService.EnableHighPrecisionTimers();

            Task.Run(() =>
            {
                overlay = new Overlay();
                overlay.Run();
            });
        }
        else
        {
            NotifierHelper.Show(NotifierType.Warning, "ESP程序已经运行了，请勿重复启动");
        }
    }

    private void Button_Overaly_Exit_Click(object sender, RoutedEventArgs e)
    {
        CloseESP();
    }

    private void CloseESP()
    {
        if (overlay != null)
        {
            overlay.Dispose();
            overlay = null;
        }
    }

    private void CheckBox_ESP_2DBox_Click(object sender, RoutedEventArgs e)
    {
        if (CheckBox_ESP_2DBox.IsChecked == true)
        {
            Setting.ESP_2DBox = true;

            Setting.ESP_3DBox = false;
            CheckBox_ESP_3DBox.IsChecked = false;
        }
        else
        {
            Setting.ESP_2DBox = false;
        }
    }

    private void CheckBox_ESP_3DBox_Click(object sender, RoutedEventArgs e)
    {
        if (CheckBox_ESP_3DBox.IsChecked == true)
        {
            Setting.ESP_3DBox = true;

            Setting.ESP_2DBox = false;
            CheckBox_ESP_2DBox.IsChecked = false;
        }
        else
        {
            Setting.ESP_3DBox = false;
        }
    }

    private void CheckBox_ESP_2DLine_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_2DLine = CheckBox_ESP_2DLine.IsChecked == true;
    }

    private void CheckBox_ESP_Bone_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_Bone = CheckBox_ESP_Bone.IsChecked == true;
    }

    private void CheckBox_ESP_2DHealthBar_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_2DHealthBar = CheckBox_ESP_2DHealthBar.IsChecked == true;
    }

    private void CheckBox_ESP_HealthText_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_HealthText = CheckBox_ESP_HealthText.IsChecked == true;
    }

    private void CheckBox_ESP_NameText_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_NameText = CheckBox_ESP_NameText.IsChecked == true;
    }

    private void CheckBox_AimBot_Enabled_Click(object sender, RoutedEventArgs e)
    {
        Setting.AimBot_Enabled = CheckBox_AimBot_Enabled.IsChecked == true;
    }

    private void CheckBox_ESP_Player_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_Player = CheckBox_ESP_Player.IsChecked == true;
    }

    private void CheckBox_ESP_NPC_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_NPC = CheckBox_ESP_NPC.IsChecked == true;
    }

    private void RadioButton_Overlay_RunMode0_Click(object sender, RoutedEventArgs e)
    {
        if (RadioButton_Overlay_RunMode0.IsChecked == true)
        {
            Setting.VSync = true;
            Setting.FPS = 300;

            CloseESP();
        }
        else if (RadioButton_Overlay_RunMode1.IsChecked == true)
        {
            Setting.VSync = false;
            Setting.FPS = 300;

            CloseESP();
        }
        else if (RadioButton_Overlay_RunMode2.IsChecked == true)
        {
            Setting.VSync = false;
            Setting.FPS = 144;

            CloseESP();
        }
        else if (RadioButton_Overlay_RunMode3.IsChecked == true)
        {
            Setting.VSync = false;
            Setting.FPS = 90;

            CloseESP();
        }
        else if (RadioButton_Overlay_RunMode4.IsChecked == true)
        {
            Setting.VSync = false;
            Setting.FPS = 60;

            CloseESP();
        }
    }

    private void CheckBox_ESP_Crosshair_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_Crosshair = CheckBox_ESP_Crosshair.IsChecked == true;
    }

    private void RadioButton_AimbotKey_CONTROL_Click(object sender, RoutedEventArgs e)
    {
        if (RadioButton_AimbotKey_CONTROL.IsChecked == true)
        {
            Setting.AimBot_Key = WinVK.CONTROL;
        }
        else if (RadioButton_AimbotKey_SHIFT.IsChecked == true)
        {
            Setting.AimBot_Key = WinVK.SHIFT;
        }
        else if (RadioButton_AimbotKey_LBUTTON.IsChecked == true)
        {
            Setting.AimBot_Key = WinVK.LBUTTON;
        }
        else if (RadioButton_AimbotKey_RBUTTON.IsChecked == true)
        {
            Setting.AimBot_Key = WinVK.RBUTTON;
        }
        else if (RadioButton_AimbotKey_XBUTTON1.IsChecked == true)
        {
            Setting.AimBot_Key = WinVK.XBUTTON1;
        }
        else if (RadioButton_AimbotKey_XBUTTON2.IsChecked == true)
        {
            Setting.AimBot_Key = WinVK.XBUTTON2;
        }
    }

    private void RadioButton_AimBot_BoneIndex_Click(object sender, RoutedEventArgs e)
    {
        if (RadioButton_AimBot_BoneIndex_0.IsChecked == true)
        {
            Setting.AimBot_BoneIndex = 0;
        }
        else if (RadioButton_AimBot_BoneIndex_7.IsChecked == true)
        {
            Setting.AimBot_BoneIndex = 7;
        }
        else if (RadioButton_AimBot_BoneIndex_8.IsChecked == true)
        {
            Setting.AimBot_BoneIndex = 8;
        }
    }

    private void RadioButton_AimbotFov_Height_Click(object sender, RoutedEventArgs e)
    {
        var windowData = Memory.GetGameWindowData();

        if (RadioButton_Crosshair_NearBy.IsChecked == true)
        {
            Setting.AimBot_Fov = 250.0f;
        }
        else if (RadioButton_AimbotFov_14Height.IsChecked == true)
        {
            Setting.AimBot_Fov = windowData.Height / 4.0f;
        }
        else if (RadioButton_AimbotFov_12Height.IsChecked == true)
        {
            Setting.AimBot_Fov = windowData.Height / 2.0f;
        }
        else if (RadioButton_AimbotFov_Height.IsChecked == true)
        {
            Setting.AimBot_Fov = windowData.Height;
        }
        else if (RadioButton_AimbotFov_Width.IsChecked == true)
        {
            Setting.AimBot_Fov = windowData.Width;
        }
        else if (RadioButton_AimbotFov_All.IsChecked == true)
        {
            Setting.AimBot_Fov = 8848.0f;
        }
    }

    private void CheckBox_NoTopMostHide_Click(object sender, RoutedEventArgs e)
    {
        Setting.NoTopMostHide = CheckBox_NoTopMostHide.IsChecked == true;
    }

    private void CheckBox_ESP_InfoText_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_InfoText = CheckBox_ESP_InfoText.IsChecked == true;
    }

    private void CheckBox_ESP_Pickup_Click(object sender, RoutedEventArgs e)
    {
        Setting.ESP_Pickup = CheckBox_ESP_Pickup.IsChecked == true;
    }
}