using GTA5Core.Features;
using GTA5Core.GTA.Onlines;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.ExternalMenu;

/// <summary>
/// WorldFunctionView.xaml 的交互逻辑
/// </summary>
public partial class WorldFunctionView : UserControl
{
    private class Options
    {
        public float RPxN = 1.0f;
        public float APxN = 1.0f;
        public float REPxN = 1.0f;
    }
    private readonly Options _options = new();

    public WorldFunctionView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;
        GTA5MenuWindow.LoopSpeedNormalEvent += GTA5MenuWindow_LoopSpeedNormalEvent;
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {

    }

    private void GTA5MenuWindow_LoopSpeedNormalEvent()
    {
        // 角色RP
        if (_options.RPxN != 1.0)
            Online.RPMultiplier(_options.RPxN);
        // 竞技场AP
        if (_options.APxN != 1.0)
            Online.APMultiplier(_options.APxN);
        // 车友会RP
        if (_options.REPxN != 1.0)
            Online.REPMultiplier(_options.REPxN);
    }

    /////////////////////////////////////////////////////////////

    private void Button_LocalWeather_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        var btnContent = (e.OriginalSource as Button).Content.ToString();
        var index = OnlineData.LocalWeathers.FindIndex(t => t.Name == btnContent);
        if (index != -1)
        {
            World.SetLocalWeather(OnlineData.LocalWeathers[index].Value);
        }
    }

    private void Slider_RPxN_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _options.RPxN = (float)Slider_RPxN.Value;
        Online.RPMultiplier(_options.RPxN);
    }

    private void Slider_APxN_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _options.APxN = (float)Slider_APxN.Value;
        Online.APMultiplier(_options.APxN);
    }

    private void Slider_REPxN_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        _options.REPxN = (float)Slider_REPxN.Value;
        Online.REPMultiplier(_options.REPxN);
    }

    /////////////////////////////////////////////////////////////

    private void Button_KillNPC_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.KillAllNPC();
    }

    private void Button_KillAllHostilityNPC_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.KillAllNPC(true);
    }

    private void Button_KillAllPolice_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.KillAllPolice();
    }

    private void Button_DestroyAllVehicles_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.DestroyAllVehicles();
    }

    private void Button_DestroyAllNPCVehicles_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.DestroyAllNPCVehicles();
    }

    private void Button_DestroyAllHostilityNPCVehicles_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.DestroyAllNPCVehicles(true);
    }

    private void Button_TPAllNPCToMe_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.TeleportAllNPCToMe();
    }

    private void Button_TPHostilityNPCToMe_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.TeleportAllNPCToMe(true);
    }

    private void Button_TPNPCTo9999_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.TeleportAllNPCTo9999();
    }

    private void Button_TPHostilityNPCTo9999_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.TeleportAllNPCTo9999(true);
    }

    private void Button_RemoveAllCCTV_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        World.RemoveAllCCTV();
    }
}
