using GTA5Core.Features;
using GTA5Core.GTA.Onlines;
using GTA5Shared.Helper;

namespace GTA5Menu.Views.ExternalMenu;

/// <summary>
/// OnlineOptionView.xaml 的交互逻辑
/// </summary>
public partial class OnlineOptionView : UserControl
{
    public OnlineOptionView()
    {
        InitializeComponent();
        GTA5MenuWindow.WindowClosingEvent += GTA5MenuWindow_WindowClosingEvent;
        GTA5MenuWindow.LoopTime1000MsEvent += GTA5MenuWindow_LoopTime1000MsEvent;
    }

    private void GTA5MenuWindow_WindowClosingEvent()
    {

    }

    private void GTA5MenuWindow_LoopTime1000MsEvent()
    {
        // 免费更改角色外观
        if (CheckBox_FreeChangeAppearance.IsChecked == true)
            Online.FreeChangeAppearance(true);

        // 移除被动模式冷却
        if (CheckBox_RemovePassiveModeCooldown.IsChecked == true)
            Online.PassiveModeCooldown(true);
        // 移除自杀冷却
        if (CheckBox_RemoveSuicideCooldown.IsChecked == true)
            Online.SuicideCooldown(true);
        // 移除天基炮冷却
        if (CheckBox_DisableOrbitalCooldown.IsChecked == true)
            Online.DisableOrbitalCooldown(true);
        // 非公开战局运货
        if (CheckBox_AllowSellOnNonPublic.IsChecked == true)
            Online.AllowSellOnNonPublic(true);
        // 战局雪天 (自己可见)
        if (CheckBox_OnlineSnow.IsChecked == true)
            Online.SessionSnow(true);

        // 角色RP
        if (Slider_RPxN.Value != 1.0)
            Online.RPMultiplier((float)Slider_RPxN.Value);
        // 竞技场AP
        if (Slider_APxN.Value != 1.0)
            Online.APMultiplier((float)Slider_APxN.Value);
        // 车友会RP
        if (Slider_REPxN.Value != 1.0)
            Online.REPMultiplier((float)Slider_REPxN.Value);
    }

    /////////////////////////////////////////////////

    private void Button_Sessions_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (sender is Button button)
        {
            var btnContent = button.Content.ToString();

            var session = OnlineData.Sessions.Find(t => t.Name == btnContent);
            if (session != null)
                Online.LoadSession(session.Value);
        }
    }

    private void Button_EmptySession_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        Online.EmptySession();
    }

    private void Button_Disconnect_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        Online.Disconnect();
    }

    private void Button_StopCutscene_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        Online.StopCutscene();
    }

    private void CheckBox_FreeChangeAppearance_Click(object sender, RoutedEventArgs e)
    {
        Online.FreeChangeAppearance(CheckBox_FreeChangeAppearance.IsChecked == true);
    }

    private void CheckBox_RemovePassiveModeCooldown_Click(object sender, RoutedEventArgs e)
    {
        Online.PassiveModeCooldown(CheckBox_RemovePassiveModeCooldown.IsChecked == true);
    }

    private void CheckBox_RemoveSuicideCooldown_Click(object sender, RoutedEventArgs e)
    {
        Online.SuicideCooldown(CheckBox_RemoveSuicideCooldown.IsChecked == true);
    }

    private void CheckBox_DisableOrbitalCooldown_Click(object sender, RoutedEventArgs e)
    {
        Online.DisableOrbitalCooldown(CheckBox_DisableOrbitalCooldown.IsChecked == true);
    }

    private void CheckBox_AllowSellOnNonPublic_Click(object sender, RoutedEventArgs e)
    {
        Online.AllowSellOnNonPublic(CheckBox_AllowSellOnNonPublic.IsChecked == true);
    }

    private void CheckBox_OnlineSnow_Click(object sender, RoutedEventArgs e)
    {
        Online.SessionSnow(CheckBox_OnlineSnow.IsChecked == true);
    }

    private void CheckBox_OffRadar_Click(object sender, RoutedEventArgs e)
    {
        Online.OffRadar(CheckBox_OffRadar.IsChecked == true);
    }

    private void CheckBox_GhostOrganization_Click(object sender, RoutedEventArgs e)
    {
        Online.GhostOrganization(CheckBox_GhostOrganization.IsChecked == true);
    }

    private void CheckBox_BribeOrBlindCops_Click(object sender, RoutedEventArgs e)
    {
        Online.BribeOrBlindCops(CheckBox_BribeOrBlindCops.IsChecked == true);
    }

    private void CheckBox_BribeAuthorities_Click(object sender, RoutedEventArgs e)
    {
        Online.BribeAuthorities(CheckBox_BribeAuthorities.IsChecked == true);
    }

    private void CheckBox_RevealPlayers_Click(object sender, RoutedEventArgs e)
    {
        Online.RevealPlayers(CheckBox_RevealPlayers.IsChecked == true);
    }

    private void Button_Blips_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (sender is Button button)
        {
            var btnContent = button.Content.ToString();

            var blip = OnlineData.Blips.Find(t => t.Name == btnContent);
            if (blip != null)
                Teleport.ToBlips(blip.Value);
        }
    }

    private void Button_MerryweatherServices_Click(object sender, RoutedEventArgs e)
    {
        AudioHelper.PlayClickSound();

        if (sender is Button button)
        {
            var btnContent = button.Content.ToString();

            var service = OnlineData.MerryWeatherServices.Find(t => t.Name == btnContent);
            if (service != null)
                Online.MerryWeatherServices(service.Value);
        }
    }

    private void CheckBox_InstantBullShark_Click(object sender, RoutedEventArgs e)
    {
        Online.InstantBullShark(CheckBox_InstantBullShark.IsChecked == true);
    }

    private void CheckBox_BackupHeli_Click(object sender, RoutedEventArgs e)
    {
        Online.CallBackupHeli(CheckBox_BackupHeli.IsChecked == true);
    }

    private void CheckBox_Airstrike_Click(object sender, RoutedEventArgs e)
    {
        Online.CallAirstrike(CheckBox_Airstrike.IsChecked == true);
    }

    private void Slider_RPxN_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        Online.RPMultiplier((float)Slider_RPxN.Value);
    }

    private void Slider_APxN_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        Online.APMultiplier((float)Slider_APxN.Value);
    }

    private void Slider_REPxN_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        Online.REPMultiplier((float)Slider_REPxN.Value);
    }
}
